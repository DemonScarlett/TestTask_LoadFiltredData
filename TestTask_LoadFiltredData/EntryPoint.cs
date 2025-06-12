using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_LoadFiltredData
{
    internal class EntryPoint
    {
        public async Task Main()
        {
            var dataLoadServiceAsync = new DataLoadService();
            var dataProcessService = new DataProcessService();

            FiltersEnum usedFilters;

            try
            {
                var users = await dataLoadServiceAsync.GetUsers();
                var posts = await dataLoadServiceAsync.GetPosts();

                var linkedUsers = dataProcessService.LinkPostsAndUsers(users, posts);

                Console.WriteLine("Hello! Please enter the first letter of the hometowns of the users you want to see.");
                var cityFirstLetter = Console.ReadLine()[0];
                var usersToDisplay = dataProcessService.FilterUsersByCityFirstLetter(linkedUsers, cityFirstLetter);
                usedFilters = FiltersEnum.CityLetter;

                Console.WriteLine("Do you want to use more filters?" +
                                    " Enter t if you whant to filter by post title and c if you want to filter by user`s company. " +
                                    "Or any other symbol to skip additional filter");
                var filters = Console.ReadLine();

                if(filters.Contains('t'))
                {
                    Console.WriteLine("Please enter a post title");
                    var postTitle = Console.ReadLine();
                    usersToDisplay = dataProcessService.FilterUsersByPostTitleFragment(usersToDisplay, postTitle);
                    usedFilters = usedFilters | FiltersEnum.PostTitle;
                }

                if(filters.Contains('c'))
                {
                    Console.WriteLine("Please enter a company name");
                    var companyName = Console.ReadLine();
                    usersToDisplay = dataProcessService.FilterUsersByCompany(usersToDisplay, companyName);
                    usedFilters = usedFilters | FiltersEnum.CompanyName;
                }

                if(usersToDisplay is null || !usersToDisplay.Any())
                {
                    Console.WriteLine("There is no users with this requirements. Try to be less demanding)");
                }

                foreach (var user in usersToDisplay)
                {
                    Console.WriteLine(DataOutputService.FormatLine("Name", user.User.Name));
                    Console.WriteLine(DataOutputService.FormatLine("City", user.User.Address.City));
                    Console.WriteLine(DataOutputService.FormatLine("Posts count", user.Posts.Count.ToString()));

                    if (usedFilters.HasFlag(FiltersEnum.PostTitle))
                    {
                        user.Posts.ForEach(post => Console.WriteLine(DataOutputService.FormatLine("Post title", post.Title)));
                    }

                    if(usedFilters.HasFlag(FiltersEnum.CompanyName))
                    {
                        Console.WriteLine(DataOutputService.FormatLine("Company", user.User.Company.Name));
                    }

                    Console.ReadKey();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Oops.... Something went wrong");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
