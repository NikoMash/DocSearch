using System;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace SearchApi.Controllers
{

    [ApiController]
    [Route("api/search")]
    public class SearchApiController : ControllerBase
    {

        [HttpGet]
        [Route("{query}/{maxAmount}/{caseSensitive}/")]
        public SearchResult Search(string query, int maxAmount, bool caseSensitive) {

            var searchResult = Logic.SearchFactory.GetSearchLogic();

            return searchResult.Search(query.Split(","), maxAmount, caseSensitive);
        }
    }
}