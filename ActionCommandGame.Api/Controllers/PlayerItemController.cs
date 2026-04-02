using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Model.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerItemController(IPlayerItemService playerItemService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await playerItemService.Get(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Find(int playerId)
        {
            var filter = new PlayerItemFilter { PlayerId = playerId };
            var result = await playerItemService.Find(filter);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPost("{playerId:int}/{itemId:int}")]
        public async Task<IActionResult> Create(int playerId, int itemId)
        {
            var result = await playerItemService.Create(playerId, itemId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);

            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await playerItemService.Delete(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}

