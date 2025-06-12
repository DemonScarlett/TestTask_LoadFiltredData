using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_LoadFiltredData.Models;

namespace TestTask_LoadFiltredData
{
    internal class DataProcessService
    {
        //more filters: By post title contains, by company

        public List<UsersWithPostsModel> LinkPostsAndUsers(IEnumerable<UserModel> users, IEnumerable<PostModel> posts)
        {
            var result = new List<UsersWithPostsModel>();

            foreach (var user in users)
            {
                result.Add(new UsersWithPostsModel
                { 
                    User = user,
                    Posts = posts.Where(p => p.UserId == user.Id).ToList()
                });
            }

            return result;
        }

        public IEnumerable<UsersWithPostsModel> FilterUsersByCityFirstLetter(IEnumerable<UsersWithPostsModel> users, char letter)
        {
            return users.Where(user => user.User.Address != null && char.ToUpperInvariant(user.User.Address.City[0]) == char.ToUpperInvariant(letter));
        }

        public IEnumerable<UsersWithPostsModel> FilterUsersByPostTitleFragment(IEnumerable<UsersWithPostsModel> users, string titleFragment)
        {
            var result = new List<UsersWithPostsModel>();


            foreach(var user in users)
            {
                var posts = user.Posts.Where(post => post.Title.Contains(titleFragment));

                if(posts.Any())
                {
                    result.Add(new UsersWithPostsModel
                    {
                        User = user.User,
                        Posts = posts.ToList()
                    });
                }
            }

            return result;
        }

        public IEnumerable<UsersWithPostsModel> FilterUsersByCompany(IEnumerable<UsersWithPostsModel> users, string companyName)
        {
            return users.Where(user => user.User.Company != null && user.User.Company.Name.Equals(companyName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
