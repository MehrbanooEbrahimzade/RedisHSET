using RedisHSet.Entities;

namespace RedisHSet.Services
{
    public class UserService : IUserService
    {
        private readonly  ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public async Task Set()
        {
            _logger.LogInformation("Hello World! ");
        }

        public async Task<List<User>> Get()
        {
            return new List<User>();
        }
    }
}
