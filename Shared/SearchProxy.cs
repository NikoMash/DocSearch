using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace Core
{
    public class SearchProxy : ISearchLogic
    {
        private string serverEndPoint = "http://localhost:5217/api/search/";

        private HttpClient mHttp;

        public SearchProxy()
        {
            {
            mHttp = new HttpClient();
            }
        }

        public SearchResult Search(string[] query, int maxAmount, bool caseSensitive)
        {
            var task = mHttp.GetFromJsonAsync<SearchResult>($"{serverEndPoint}{string.Join(",", query)}/{maxAmount}/{caseSensitive}");
            task.Wait();

            return task.Result;
        }
    }
}