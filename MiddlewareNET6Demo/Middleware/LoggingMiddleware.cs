using MiddlewareNET6Demo.Logging;

namespace MiddlewareNET6Demo.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingService _logger;

        public LoggingMiddleware(RequestDelegate next, ILoggingService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Log the incoming request path
            _logger.Log(LogLevel.Information, context.Request.Path);

            await _next(context);

            //Log the response headers
            var uniqueResponseHeaders 
                = context.Response.Headers
                                  .Select(x => x.Key)
                                  .Distinct();

            //Log these headers
            _logger.Log(LogLevel.Information, string.Join(", ", uniqueResponseHeaders);
        }
    }
}
