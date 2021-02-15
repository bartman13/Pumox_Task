using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PumoxBackend.Models;
using System;
using System.Collections.Generic;


namespace PumoxBackend.DataTransferObject
{
    public class SearchRequest
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public virtual ICollection<string> EmployeeJobTitles{ get; set; }
    }
}
