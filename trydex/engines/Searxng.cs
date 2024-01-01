using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace SearchApp.Engines
{
    public class Searxng : ISearchEngine
    {
        private const string ApiUrl = "https://etsi.me/search";
        

        public string Search(string searchQuery)
        {
            // Если вам нужно синхронное поведение, можете использовать GetUrlAsync
            return GetUrlAsync().Result;
        }

        public async Task<string> GetUrlAsync()
        {

            var client = new RestClient("https://etsi.me/search");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/119.0");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
            request.AddHeader("Accept-Language", "ru,en-US;q=0.7,en;q=0.3");
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Origin", "null");
            request.AddHeader("DNT", "1");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader("Sec-Fetch-Dest", "document");
            request.AddHeader("Sec-Fetch-Mode", "navigate");
            request.AddHeader("Sec-Fetch-Site", "same-origin");
            request.AddHeader("Pragma", "no-cache");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("TE", "trailers");
            request.AddParameter("application/x-www-form-urlencoded", "q=fds&category_general=1&pageno=1&language=ru&safesearch=0&format=json", ParameterType.RequestBody);
            var response = client.Execute(request);

            return $"URL: {response}";

            }

            /*
            using (HttpClient httpClient = new HttpClient(clientHandler))
            { 
                

                // Отправляем POST-запрос с данными
                

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiUrl);


                request.Headers.Add("authority", "etsi.me");
                //request.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng;q=0.8,application/signed-exchange;v=b3;q=0.7");
                request.Headers.Add("accept-language", "ru,en;q=0.9,zh-TW;q=0.8,zh;q=0.7");
                request.Headers.Add("cache-control", "max-age=0");
                request.Headers.Add("dnt", "1");
                request.Headers.Add("origin", "null");
                request.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"119\", \"Chromium\";v=\"119\", \"Not?A_Brand\";v=\"24\"");
                request.Headers.Add("sec-ch-ua-mobile", "?0");
                request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                request.Headers.Add("sec-fetch-dest", "document");
                request.Headers.Add("sec-fetch-mode", "navigate");
                request.Headers.Add("sec-fetch-site", "same-origin");
                request.Headers.Add("sec-fetch-user", "?1");
                request.Headers.Add("upgrade-insecure-requests", "1");
                request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36");

                request.Content = new StringContent("q=trydex&category_general=1&pageno=1&language=ru&time_range=&safesearch=0&format=json");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                HttpResponseMessage response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                

                
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize JSON response
                var searchResult = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResult>(responseBody);

                // Return the value of the "url" key from the first item in the "results" array
                if (searchResult.Results?.Length > 0)
                {
                    return $"URL: {searchResult.Results[0]?.Url ?? "No results found."}";
                }
                else
                {
                    return $"No results found.";
                }
            } 
            */
            
        }
/*
        // Classes to represent the structure of the JSON response
        private class SearchResult
        {
            public string Query { get; set; }
            public int NumberOfResults { get; set; }
            public Result[] Results { get; set; }
        }

        private class Result
        {
            public string Url { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string ImgSrc { get; set; }
            public string Engine { get; set; }
            public string[] ParsedUrl { get; set; }
            public string Template { get; set; }
            public string[] Engines { get; set; }
            public int[] Positions { get; set; }
            public double Score { get; set; }
            public string Category { get; set; }
        }
        */
    }

