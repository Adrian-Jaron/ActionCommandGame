using ActionCommandGame.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GameController (IGameService gameService) : ControllerBase
    {
        [HttpGet("perform-action/{playerId:int}")]
        public async Task<IActionResult> PerformAction(int playerId)
        {
            var result = await gameService.PerformAction(playerId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result); 
        }

        [HttpPost("buy/{playerId:int}/{itemId:int}")]
        public async Task<IActionResult> Buy(int playerId, int itemId)
        {
            var result = await gameService.Buy(playerId, itemId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
