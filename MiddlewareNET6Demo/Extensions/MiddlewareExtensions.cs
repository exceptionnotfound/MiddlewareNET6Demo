using MiddlewareNET6Demo.Middleware;

namespace MiddlewareNET6Demo.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLayoutMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LayoutMiddleware>();
        }

        public static IApplicationBuilder UseSimpleResponseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SimpleResponseMiddleware>();
        }
    }
}
