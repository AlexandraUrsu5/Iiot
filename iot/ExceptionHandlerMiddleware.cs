using System.Net;
using System.Text.Json;

namespace iot.API
{
    public class ErrorModel
    {
        public string Message { get; set; }
    }
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private ErrorModel error = new ErrorModel();

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception err)
            {
                var response = context.Response;
                var request = context.Request;
                response.ContentType = "application/json";

                switch (err)
                {
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ArgumentException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                error.Message = err.Message;
                _logger.LogError(err, $"The {request.Method} method for URL: {request.Path} threw error:");

                var result = JsonSerializer.Serialize(error);
                await response.WriteAsync(result);
            }
        }
    }
}
