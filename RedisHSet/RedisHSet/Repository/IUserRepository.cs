using RedisHSet.Entities;

namespace RedisHSet.Repository
{
    public interface IUserRepository
    {
        List<User> CreateUsers(int count);
    }
}

