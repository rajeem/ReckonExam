using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReckonExam.Core.Api;
using ReckonExam.Core.Interfaces;
using System.Threading.Tasks;

namespace ReckonExam.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRestApiService _apiService;
        private readonly IStringSearchService _stringSearchService;

        public HomeController(ILogger<HomeController> logger, IRestApiService apiService, IStringSearchService stringSearchService)
        {
            _logger = logger;
            _apiService = apiService;
            _stringSearchService = stringSearchService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mainText = await _apiService.Get<MainText>(ReckonExam.Core.Enums.RestEndPoints.TextToSearchUrl);
            var subText = await _apiService.Get<SubText>(ReckonExam.Core.Enums.RestEndPoints.SubTextsUrl);
            var searchResult = _stringSearchService.Search(mainText, subText);
            searchResult.Candidate = "Rajeem Cariazo";
            await _apiService.Post(ReckonExam.Core.Enums.RestEndPoints.SubmitResultUrl, searchResult);
            return Ok();
        }
    }
}
