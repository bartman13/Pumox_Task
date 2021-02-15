using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxBackend.DataTransferObject
{
    public class SearchResponse
    {   
        public virtual ICollection<CompanyTransfer> Results { get; set; }
    }
}
