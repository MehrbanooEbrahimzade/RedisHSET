using Microsoft.AspNetCore.Mvc;
using System.Net;
using RedisHSet.Entities;
using RedisHSet.Services;

namespace RedisHSet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> SetHSet()
        {
            _logger.LogInformation("Set data");
            await _userService.Set();
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<User>>> GetRandomUsers()
        {
            _logger.LogInformation("Get randomly");
            return Ok(await _userService.Get());
        }

    }
}