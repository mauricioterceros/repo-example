using Microsoft.OpenApi.Models;
using UPB.PracticeTwo.Managers;

// This link for serilog
// https://rmauro.dev/setup-serilog-in-net6-as-logging-provider/
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Singleton vs Transient vs Scoped
builder.Services.AddSingleton<StudentManager>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var configurationBuilder = new ConfigurationBuilder()
        .SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
IConfiguration Configuration = configurationBuilder.Build();
string siteTitle = Configuration.GetSection("Title").Value;
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = siteTitle
    });
});

// build app
var app = builder.Build();


// Configure the HTTP request pipeline. FOR LATER
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


// Run app
app.Run();
