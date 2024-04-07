using Microsoft.AspNetCore.Mvc;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("api/search/")]
public class LoadBalancerController : ControllerBase
{
    private static readonly string[] servers =  {
        "http://localhost:5259/api/search",
        "http://localhost:5260/api/search"
    };

    private static int next = 0;

    [HttpGet]
    [Route("{query}/{maxAmount}/{caseSensitive}")]
    public string Get(string query, int maxAmount, bool caseSensitive)
        {

            string server = $"{servers[next]}/{query}/{maxAmount}/{caseSensitive}";
            next = (next + 1) % servers.Length;

            Response.Redirect(server);
            return server;
        }
}