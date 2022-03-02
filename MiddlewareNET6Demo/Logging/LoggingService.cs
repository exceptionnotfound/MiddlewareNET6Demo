namespace MiddlewareNET6Demo.Logging
{
    public class LoggingService : ILoggingService
    {

        public void Log(LogLevel logLevel, string message)
        {
            //Implementation for logging
        }
    }

    public interface ILoggingService
    {
        public void Log(LogLevel level, string message);
    }
}
