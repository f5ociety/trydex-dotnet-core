using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchApp.Engines
{
    public class Example : ISearchEngine
    {
        private const string ApiUrl = "https://jsonplaceholder.typicode.com/todos/1";

        public string Search(string searchQuery)
        {
            // Если вам нужно синхронное поведение, можете использовать GetTitle
            return GetTitleAsync().Result;
        }

        public async Task<string> SearchAsync(string searchQuery)
        {
            // Если нужно асинхронное поведение, вызывайте GetTitleAsync напрямую
            return await GetTitleAsync();
        }

        private async Task<string> GetTitleAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response
                var todoItem = Newtonsoft.Json.JsonConvert.DeserializeObject<TodoItem>(responseBody);

                // Return the value of the "title" key
                return todoItem.Title;
            }
        }

        // Class to represent the structure of the JSON response
        private class TodoItem
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public bool Completed { get; set; }
        }
    }
}
