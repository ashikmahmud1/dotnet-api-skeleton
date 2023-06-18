using API.ActionFilters;
using API.Extensions;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),
    "/nlog.config"));

builder.Services.ConfigureCors();

builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService();

builder.Services.ConfigureRepositoryManager();

builder.Services.ConfigureServiceManager();

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

builder.Services.ConfigureVersioning();

builder.Services.AddMemoryCache();

builder.Services.ConfigureRateLimitingOptions();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication();

builder.Services.ConfigureIdentity();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddControllers(config => {
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();

app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseIpRateLimiting();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
