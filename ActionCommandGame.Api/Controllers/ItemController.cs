using ActionCommandGame.Services;
using ActionCommandGame.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController(IItemService itemService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await itemService.Get(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var result = await itemService.Find();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}