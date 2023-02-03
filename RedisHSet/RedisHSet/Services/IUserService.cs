using RedisHSet.Entities;

namespace RedisHSet.Services
{
    public interface IUserService
    {
        public Task SetData(int count);
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<List<User>> GetRandomly(int count);
    }
}
