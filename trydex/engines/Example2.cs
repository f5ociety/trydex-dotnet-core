using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchApp.Engines
{
    public class Example2 : ISearchEngine
    {
        private const string ApiUrl = "https://jsonplaceholder.typicode.com/comments?postId=2";
        
        public string Search(string searchQuery)
        {
            // Если вам нужно синхронное поведение, можете использовать GetTitle
            return GetTitleAsync().Result;
        }
        
        public async Task<string> GetTitleAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response as an array
                var comments = Newtonsoft.Json.JsonConvert.DeserializeObject<Comment[]>(responseBody);

                // Return the value of the "title" key from the first element
                if (comments.Length > 0)
                {
                    return comments[0].Name;
                }
                else
                {
                    return "No comments found.";
                }
            }
        }

        // Class to represent the structure of the JSON response
        private class Comment
        {
            public int PostId { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Body { get; set; }
        }
    }
}
