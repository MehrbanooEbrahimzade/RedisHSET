using RedisHSet.Entities;
using RedisHSet.Repository;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisHSet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConnectionMultiplexer _redis;

        public UserService(IUserRepository userRepository, IConnectionMultiplexer redis)
        {
            _userRepository = userRepository;
            _redis = redis;
        }

        public async Task SetData(int count)
        {
            var users = _userRepository.CreateUsers(count);

            foreach (var user in users)
            {
                await _redis.GetDatabase().HashSetAsync("user", user.Id, JsonSerializer.Serialize(user));
            }
        }

        public async Task<List<User>> GetAll()
        {
            var usersHash = await _redis.GetDatabase().HashGetAllAsync("user");
            return usersHash.Select(userH => JsonSerializer.Deserialize<User>(userH.Value)).ToList();
        }

        public async Task<User> GetById(int id)
        {
            var user = await _redis.GetDatabase().HashGetAsync("user", id.ToString());
            return JsonSerializer.Deserialize<User>(user);
        }
        public async Task<List<User>> GetRandomly(int count)
        {
            var users = await _redis.GetDatabase().HashRandomFieldsWithValuesAsync("user", count);
            return users.Select(user => JsonSerializer.Deserialize<User>(user.Value)).ToList();
        }

    }
}
