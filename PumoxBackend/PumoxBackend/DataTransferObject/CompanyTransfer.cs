using PumoxBackend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PumoxBackend.DataTransferObject
{
    public class CompanyTransfer
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int EstablishmentYear { get; set; } 
        public virtual ICollection<EmployeeTransfer> Employees { get; set; }
    }
}
