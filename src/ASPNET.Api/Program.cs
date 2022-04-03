using ASPNET.Api.Configuration;
using ASPNET.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWebApiConfig();
builder.Services.AddSwaggerConfig();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.ResolveDependencies();
var app = builder.Build();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();



app.UseApiConfig(app.Environment);

app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.Run();