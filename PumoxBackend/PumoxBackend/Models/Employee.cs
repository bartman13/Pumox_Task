using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PumoxBackend.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        [Column(TypeName = "varchar(50)")]
        public JobTitle JobTitle { get; set; }
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
