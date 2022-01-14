namespace PostSite.Domain.Ports.Driven
{
    public interface IHashAdapter
    {
        public string Hash(string password);
        public bool verify(string password, string passwordHash);
    }
}
