using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_LoadFiltredData.Models;

namespace TestTask_LoadFiltredData
{
    internal class DataOutputService
    {
        public static string FormatLine(string title, string value)
        {
            return $"{title}: {value}";
        }
    }
}
