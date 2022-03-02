using MiddlewareNET6Demo.Middleware;
using MiddlewareNET6Demo.Extensions;
using MiddlewareNET6Demo.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ILoggingService, LoggingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//The most basic way to add a middleware to the pipeline is to use the Run() method.
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello Dear Readers!");
//});

//Add our custom middleware.
//Comment out any you don't want to use.
app.UseLayoutMiddleware();
app.UseLoggingMiddleware();

//This one is commented out because it will return a response, and the request will never get to the main app.
//app.UseSimpleResponseMiddleware();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
