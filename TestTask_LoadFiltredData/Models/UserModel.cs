using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_LoadFiltredData.Models
{
    internal class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public AddressModel? Address { get; set; }
        public CompanyModel? Company { get; set; }
    }
}
