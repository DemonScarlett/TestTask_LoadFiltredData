using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_LoadFiltredData.Models
{
    //  "company": {
    //  "name": "Romaguera-Crona",
    //    "catchPhrase": "Multi-layered client-server neural-net",
    //    "bs": "harness real-time e-markets"
    //  }
    internal class CompanyModel
    {
        public required string Name { get; set; }
        public string? CatchPhrase { get; set; }
        public string? BS { get; set; }
    }
}
