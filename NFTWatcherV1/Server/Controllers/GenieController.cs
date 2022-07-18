using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NFTWatcherV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenieController : ControllerBase
    {
        private readonly IGenieService _genieService;

        public GenieController(IGenieService genieService)
        {
            _genieService = genieService;
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Collection>>>> GetCollections(string searchText)
        {
            var response = await _genieService.GetCollections(searchText);
            return Ok(response);
        }

        [HttpGet("collection/listings/{collectionAddress}")]
        public async Task<ActionResult<ServiceResponse<List<Listing>>>> GetCollectionListings(string collectionAddress)
        {
            var response = await _genieService.GetCollectionListings(collectionAddress);
            return Ok(response);
        }

        [HttpGet("collection/{collectionAddress}")]
        public async Task<ActionResult<ServiceResponse<Collection>>> GetCollection(string collectionAddress)
        {
            var response = await _genieService.GetCollection(collectionAddress);
            return Ok(response);
        }
    }
}
