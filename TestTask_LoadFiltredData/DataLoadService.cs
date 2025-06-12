using System.Net.Http.Json;
using TestTask_LoadFiltredData.Models;

namespace TestTask_LoadFiltredData
{
    internal class DataLoadService
    {
        static HttpClient client = new HttpClient();
        private const string GET_USERS_URL = "https://jsonplaceholder.typicode.com/users";
        private const string GET_POSTS_URL = "https://jsonplaceholder.typicode.com/posts";

        public async Task<IEnumerable<UserModel>?> GetUsers()
        {
            var response = await client.GetFromJsonAsync<IEnumerable<UserModel>>(GET_USERS_URL);
            return response;
        }

        public async Task<IEnumerable<PostModel>?> GetPosts()
        {
            var response = await client.GetFromJsonAsync<IEnumerable<PostModel>>(GET_POSTS_URL);
            return response;
        }
    }
}
