using RedisHSet.Entities;

namespace RedisHSet.Services
{
    public interface IUserService
    {
        public Task Set();
        public Task<List<User>> Get();
    }
}
