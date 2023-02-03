using RedisHSet.Entities;

namespace RedisHSet.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly List<User> _users = new();
        private readonly Random _random = new();

        public List<User> CreateUsers(int count)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (var i = 0; i < count; i++)
            {
                var name = new string(Enumerable.Repeat(chars, 7).Select(s => s[_random.Next(s.Length)]).ToArray());
                _users.Add(new User(i + 1, name, name + "@gmail.com"));
            }

            return _users;
        }
    }
}
