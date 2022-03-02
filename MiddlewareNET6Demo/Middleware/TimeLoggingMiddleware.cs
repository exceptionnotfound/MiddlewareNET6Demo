using MiddlewareNET6Demo.Logging;
using System.Diagnostics;

namespace MiddlewareNET6Demo.Middleware
{
    public class TimeLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingService _logger;

        public TimeLoggingMiddleware(RequestDelegate next, ILoggingService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            await _next(context);

            watch.Stop();
            _logger.Log(LogLevel.Information, "Time to execute: " + watch.ElapsedMilliseconds + " milliseconds.");
        }
    }
}
