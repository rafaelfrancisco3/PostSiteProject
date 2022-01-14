namespace PostSite.Domain.Utils
{
    public class Response
    {
        public ResponseType Type { get; set; }
        public string Message { get; set; }

        public Response()
        {
        }

        public Response(ResponseType type, string message)
        {
            Type = type;
            Message = message;
        }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }

        public Response()
        {
        }

        public Response(
            ResponseType type,
            string message,
            T data) 
            : base(type, message)
        {
            Data = data;
        }
    }
}
