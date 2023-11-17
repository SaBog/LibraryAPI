using System.Net;

namespace Library.Application.Common.Exceptions
{
    public class UserAuthenticationException : StatusCodeException
    {
        public UserAuthenticationException() :
            base("Invalid login or password")
        {
            statusCode = HttpStatusCode.BadRequest;

        }
    }
}
