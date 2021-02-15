using System;
using System.Collections.Generic;

#nullable disable

namespace PumoxBackend.Models
{
    public partial class Company 
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
    
}
