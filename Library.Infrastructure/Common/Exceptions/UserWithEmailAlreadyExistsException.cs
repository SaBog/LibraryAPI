using System.Net;

namespace Library.Application.Common.Exceptions
{
    public class UserWithEmailAlreadyExistsException : StatusCodeException
    {
        public UserWithEmailAlreadyExistsException(string email) :
            base($"User with  \"{email}\" already exist")
        {
            statusCode = HttpStatusCode.BadRequest;
        }
    }
}
