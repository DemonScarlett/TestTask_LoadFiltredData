using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_LoadFiltredData
{
    [Flags]
    internal enum FiltersEnum
    {
        CityLetter = 0,
        PostTitle = 1,
        CompanyName = 2
    }
}
