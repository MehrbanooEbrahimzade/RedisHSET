namespace RedisHSet.Entities
{
    public class User
    {
        public User(int id ,string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }
        public int Id { get; set; }
        public string UserName { get;private set; }
        public string Email { get;private set; }

    }
}
