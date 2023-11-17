using System.Net;

namespace Library.Infrastructure.ErrorHandling
{
    public partial class ErrorHandlingMiddleware
    {
        public class ExceptionResponse
        {
            public string Message { get; }
            public HttpStatusCode HttpStatusCode { get; }

            public ExceptionResponse(string code, string message, HttpStatusCode httpStatusCode)
            {
                Message = message;
                HttpStatusCode = httpStatusCode;
            }
        }
    }
}
