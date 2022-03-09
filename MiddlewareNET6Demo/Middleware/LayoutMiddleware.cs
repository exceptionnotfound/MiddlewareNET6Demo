namespace MiddlewareNET6Demo.Middleware
{
    /// <summary>
    /// This class shows the basic layout of any given Middleware class in .NET 6.
    /// </summary>
    public class LayoutMiddleware
    {
        private readonly RequestDelegate _next;

        //A middleware class must include a public constructor, and that constructor must have a parameter of type RequestDelegate.
        public LayoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //This method is REQUIRED, and must take a first parameter of type HttpContext.
        public async Task InvokeAsync(HttpContext context)
        {
            //Code that modifies the response

            await _next(context); //This line is required, otherwise the next middleware in the pipeline will not be called.

            //Logging or other code that DOES NOT modify the response
        }
    }
}
