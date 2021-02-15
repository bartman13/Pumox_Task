using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PumoxBackend.DataTransferObject;
using PumoxBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace PumoxBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PumoxContext _context; 

        public CompanyController(PumoxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public IActionResult CompanyCreate([FromBody] CompanyTransfer value)
        {
            var company = _mapper.Map<Company>(value);
            _context.Companies.Add(company);
            _context.SaveChanges();
            return Ok(new CompanyCreateResponse {Id = company.Id });
        }
        [HttpPost("search")]
        public async Task<IActionResult> CompanySearch([FromBody] SearchRequest value)
        {
            if(value.EmployeeDateOfBirthFrom == null && value.EmployeeDateOfBirthTo == null)
            {
                value.EmployeeDateOfBirthFrom = DateTime.MaxValue;
                value.EmployeeDateOfBirthTo = DateTime.MinValue; // zamiana na wartości tak aby nie były brane pod uwagę w zapytaniu  wprzypadku null
            }
            value.EmployeeDateOfBirthFrom ??= DateTime.MinValue;
            value.EmployeeDateOfBirthTo ??= DateTime.MaxValue;
            List<JobTitle> titles;
            try
            {
                titles = value.EmployeeJobTitles.Distinct().Select(title => (JobTitle)Enum.Parse(typeof(JobTitle), title)).ToList();
            }
            catch(ArgumentNullException)
            {
                titles = new List<JobTitle>();
            }
            catch (ArgumentException)
            {
                return BadRequest("The job titles allowed: Administrator, Developer, Architect, Manager");
            }
            
            var companies = await _context.Companies
                .Include(company => company.Employees)
                .Where(company => value.Keyword != null &&
                company.Name.Contains(value.Keyword) ||
                company.Employees.Any(emp => emp.FirstName.Contains(value.Keyword) || emp.LastName.Contains(value.Keyword)) ||
                company.Employees.Any(employ => value.EmployeeDateOfBirthFrom <= employ.DateOfBirth && value.EmployeeDateOfBirthTo >= employ.DateOfBirth) ||
                company.Employees.Any(employ => titles.Contains(employ.JobTitle)))
                .Select(company => _mapper.Map<CompanyTransfer>(company))
                .ToListAsync();
            return Ok(new SearchResponse {Results = companies }); 
        }
        [HttpPut("update/{id?}")]
        public IActionResult CompanyUpdate(int id,[FromBody]  CompanyTransfer value )
        {
            try
            {
                var company = _context.Companies.SingleOrDefault(el => el.Id == id);
                _mapper.Map(value,company);
                _context.Companies.Update(company);
                _context.SaveChanges();
                return Ok();
            }
            catch(ArgumentNullException)
            {
                return BadRequest("Element with given Id does not exist");
            }
        }
        [HttpDelete("delete/{id?}")]
        public  IActionResult CompanyDelete(int id)
        {

            try
            {
                _context.Companies.Remove(_context.Companies.SingleOrDefault(el => el.Id == id));
                _context.SaveChanges();
                return Ok();
            }
            catch(ArgumentNullException)
            {
                return BadRequest("Element with given Id does not exist");
            }
        }
       
    }
}
