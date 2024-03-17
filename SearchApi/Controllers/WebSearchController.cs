using System;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace SearchApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WebSearchController : ControllerBase
{
    IDatabase dbContext;
    ISearchLogic _searchlogic;

    [HttpGet]
    [Route("search")]
    public async Task<SearchResult> GetSearchResults(String[] query, int maxAmount, bool CaseSensitive) {

        var results = _searchlogic.Search(query, maxAmount, CaseSensitive);

        return results;
    }

}
