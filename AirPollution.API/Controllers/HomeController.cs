using AirPollution.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AirPollution.API.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
           _homeService = homeService;
        }

        [HttpGet]        
        public int GetInt()
        {
            var x = _homeService.GetInt();

            return x;
        }

        [HttpPost]
        public int PostInt([FromBody] int x)
        {
            //return x;
            return _homeService.PostInt(x);

        }
    }
}
