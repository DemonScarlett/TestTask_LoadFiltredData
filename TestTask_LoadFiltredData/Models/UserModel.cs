using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_LoadFiltredData.Models
{
  //  {
  //  "id": 1,
  //  "name": "Leanne Graham",
  //  "username": "Bret",
  //  "email": "Sincere@april.biz",
  //  "address": {
  //    "street": "Kulas Light",
  //    "suite": "Apt. 556",
  //    "city": "Gwenborough",
  //    "zipcode": "92998-3874",
  //    "geo": {
  //      "lat": "-37.3159",
  //      "lng": "81.1496"
  //    }
  //  },
  //  "phone": "1-770-736-8031 x56442",
  //  "website": "hildegard.org",
  //  "company": {
  //  "name": "Romaguera-Crona",
  //    "catchPhrase": "Multi-layered client-server neural-net",
  //    "bs": "harness real-time e-markets"
  //  }
  //}
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
