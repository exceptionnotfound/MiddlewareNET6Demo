using MiddlewareNET6Demo.Middleware;
using MiddlewareNET6Demo.Extensions;
using MiddlewareNET6Demo.Logging;
using MiddlewareNET6Demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ILoggingService, LoggingService>();

var app = builder.Build();

var middlewareSettings = builder.Configuration.GetSection("MiddlewareSettings").Get<MiddlewareSettings>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//The most basic way to add a middleware to the pipeline is to use the Run() method.
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello Dear Readers!");
//});

//At this point, we can add our custom middleware
//Comment out any you don't want to use.
//The basic way to add a middleware class to our pipeline is to call UseMiddleware<T>
app.UseMiddleware<LayoutMiddleware>();

//We can also use custom extensions to add middleware to the pipeline.
app.UseLoggingMiddleware();

//We can conditionally add middleware to the pipeline based on application settings.
if(middlewareSettings.UseTimeLoggingMiddleware)
    app.UseTimeLoggingMiddleware();

if (middlewareSettings.UseCultureMiddleware)
    app.UseCultureMiddleware();

if(middlewareSettings.UseIntentionalDelayMiddleware)
    app.UseIntentionalDelayMiddleware();

//The middleware below is commented out because it will return a response,
//and the request will never get to the main app.
//Uncomment this if you'd like to see how it behaves.

//app.UseSimpleResponseMiddleware();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
