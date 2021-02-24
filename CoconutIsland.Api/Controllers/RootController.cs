using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoconutIsland.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class RootController : ControllerBase
    {
        private readonly ILogger<RootController> _logger;

        public RootController(ILogger<RootController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public void Get() { }
    }
}