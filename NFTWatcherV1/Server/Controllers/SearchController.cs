using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NFTWatcherV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<CollectionFromSearch>>>> SearchCollections(string searchText)
        {
            var response = await _searchService.SearchCollections(searchText);
            return Ok(response);
        }
    }
}
