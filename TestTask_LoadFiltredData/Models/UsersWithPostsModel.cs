using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_LoadFiltredData.Models
{
    internal class UsersWithPostsModel
    {
        public required UserModel User { get; set; } 
        public required List<PostModel> Posts { get; set; }
    }
}
