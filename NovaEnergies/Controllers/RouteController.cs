using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovaEnergies.Core.Services;

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
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> GetRoutesAsync(DateTime startDate, DateTime endDate, decimal price, int ttl)
        {
            var routes = new List<Route>();

            var res = await _searchService.GetRoutesAsync(new Core.Clients.Requests.SearchServiceRequest
            {
                TTL = DateTime.from ttl,
                DateFrom = startDate,
                DateTo = endDate,
                RoutePrice = price,
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
        [ResponseCache(Duration = 30)]
        public int Get(int number)
        {
            return DateTime.Now.Second;
        }

    }
}
