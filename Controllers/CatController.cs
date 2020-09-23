using System.Collections.Generic;
using kakao.Services;
using kakao.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kakao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> _logger;
        CatService _catService;

        public CatController(ILogger<CatController> logger)
        {
            _logger = logger;
            _catService = new CatService();
        }

        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            return _catService.Get();
        }
    }
}
