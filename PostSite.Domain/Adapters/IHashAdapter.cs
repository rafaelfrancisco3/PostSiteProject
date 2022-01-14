namespace PostSite.Domain.Adapters
{
    public interface IHashAdapter
    {
        public string Hash(string password);
        public bool verify(string password, string passwordHash);
    }
}
