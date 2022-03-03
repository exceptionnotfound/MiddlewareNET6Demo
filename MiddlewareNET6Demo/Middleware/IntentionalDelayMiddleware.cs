namespace MiddlewareNET6Demo.Middleware
{
    public class IntentionalDelayMiddleware
    {
        private readonly RequestDelegate _next;

        public IntentionalDelayMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await Task.Delay(100);

            await _next(context);

            await Task.Delay(100);
        }
    }
}
