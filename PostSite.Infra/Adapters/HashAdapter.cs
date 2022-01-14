using PostSite.Domain.Ports.Driven;

namespace PostSite.Infra.Adapters
{
    internal class HashAdapter : IHashAdapter
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
