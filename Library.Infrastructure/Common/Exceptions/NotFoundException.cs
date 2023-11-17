using System.Net;

namespace Library.Application.Common.Exceptions
{

    public class NotFoundException : StatusCodeException
    {
        public NotFoundException(string name, object key) :
            base($"Entity \"{name}\" ({key}) not found.")
        {
            statusCode = HttpStatusCode.NotFound;
        }

        public NotFoundException(string message) :
            base(message)
        {
            statusCode = HttpStatusCode.NotFound;
        }

    }
}
