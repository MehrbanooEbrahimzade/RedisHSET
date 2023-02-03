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

        [HttpPost("{count}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> SetHSet(int count)
        {
            _logger.LogInformation("Set data");
            await _userService.SetData(count);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            _logger.LogInformation("Get All Users");
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<User>>> GetUserById(int id)
        {
            _logger.LogInformation("Get User By Id");
            return Ok(await _userService.GetById(id));
        }

        [HttpGet("[action]/{count}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<User>>> GetRandomUsers(int count)
        {
            _logger.LogInformation("Get randomly");
            return Ok(await _userService.GetRandomly(count));
        }

    }
}