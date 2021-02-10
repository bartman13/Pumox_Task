using System;
using System.Collections.Generic;

#nullable disable

namespace PumoxBackend.Models
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte JobTitle { get; set; }
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
