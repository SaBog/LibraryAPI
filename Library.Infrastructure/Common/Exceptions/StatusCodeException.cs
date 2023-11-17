using System.Net;

namespace Library.Application.Common.Exceptions
{
    public class StatusCodeException : Exception
    {
        public HttpStatusCode statusCode;

        public StatusCodeException(string message) : base(message) { }

        public StatusCodeException(string message, HttpStatusCode statusCode) : base(message)
        {
            this.statusCode = statusCode;
        }
    }
}
