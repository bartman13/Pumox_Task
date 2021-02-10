using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PumoxBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {

        PumoxContext _context; 

        public CompanyController(PumoxContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CompanyCreate()
        {
            return Ok();
        }
        [HttpPost("search")]
        public IActionResult CompanySearch()
        {
            return Ok();
        }
        [HttpPut("update/{id?}")]
        public IActionResult CompanyUpdate()
        {
            return Ok();
        }
        [HttpDelete("delete/{id?}")]
        public IActionResult CompanyDelete()
        {
            return Ok();
        }
    }
}
