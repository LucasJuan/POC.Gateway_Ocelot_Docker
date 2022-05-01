using POC.Gateway;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

builder.Logging.AddJsonConsole();
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", false, true);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();

