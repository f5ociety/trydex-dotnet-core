using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchApp.Engines
{
    public class Github : ISearchEngine
    {
        private const string ApiUrl = "https://github.com/search?q=";

        public string Search(string searchQuery)
        {
            // Если вам нужно синхронное поведение, можете использовать GetFullNameAsync
            return GetRepositoryNameAsync(searchQuery).Result;
        }
        public async Task<string> GetRepositoryNameAsync(string searchQuery)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = await httpClient.GetAsync(ApiUrl + searchQuery);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response
                var searchResult = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResult>(responseBody);

                // Return the value of the "name" key from the first item
                if (searchResult.Payload?.Results?.Length > 0)
                {
                    return searchResult.Payload.Results[0]?.Repo?.Repository?.Name ?? "No repositories found.";
                }
                else
                {
                    return "No repositories found.";
                }
            }
        }

        // Classes to represent the structure of the JSON response
        private class SearchResult
        {
            public Payload Payload { get; set; }
            public string Title { get; set; }
        }

        private class Payload
        {
            public Result[] Results { get; set; }
        }

        private class Result
        {
            public Repo Repo { get; set; }
        }

        private class Repo
        {
            public Repository Repository { get; set; }
        }

        private class Repository
        {
            public string Name { get; set; }
        }
    }
}
