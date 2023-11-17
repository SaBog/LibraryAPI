using Library.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Library.Infrastructure.ErrorHandling
{
    public partial class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = ex switch
            {
                StatusCodeException exception => exception,
                _ => new StatusCodeException(ex.Message, HttpStatusCode.InternalServerError)
            };

            context.Response.ContentType = "text/html";
            context.Response.StatusCode = (int)response.statusCode;

            return context.Response.WriteAsync(response.Message);
        }
    }
}
