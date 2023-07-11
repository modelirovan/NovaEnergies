using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovaEnergies.Core.Enums;
using NovaEnergies.Core.Services;
using StackExchange.Redis;

namespace NovaEnergies.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class RouteController : Controller
    {
        private readonly ISearchService _searchService;

        public RouteController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("search/")]
        public async Task<IActionResult> GetRoutesAsync(DateTime startDate, DateTime endDate, decimal price, int ttl, FilterEnum filter)
        {
            var routes = new List<Route>();

            var res = await _searchService.GetRoutesAsync(new Core.Clients.Requests.SearchServiceRequest
            {
                TTL = TimeSpan.FromMinutes(ttl),
                DateFrom = startDate,
                DateTo = endDate,
                RoutePrice = price,
                Filter = filter
            });

            return Json(res);
        }


        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }

        [HttpGet]
        [Route("time/{number}")]
       // [ResponseCache(Duration = 30)]
        public int Get(int number)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            IDatabase db = redis.GetDatabase();
            var val = db.StringGet("vadik");

            return DateTime.Now.Second;
        }

    }
}
