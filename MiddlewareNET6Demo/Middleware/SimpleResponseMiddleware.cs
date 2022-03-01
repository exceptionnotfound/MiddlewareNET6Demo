namespace MiddlewareNET6Demo.Middleware
{
    /// <summary>
    /// This class will add a simple text line to the body tag of the response.
    /// </summary>
    public class SimpleResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public SimpleResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello Dear Readers!");
        }
    }
}
