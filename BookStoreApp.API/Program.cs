using BookStoreApp.API.MVCS.Models.DBM;
using BookStoreApp.API.MVCS.Repositories.Implementations;
using BookStoreApp.API.MVCS.Repositories.Interfaces;
using BookStoreApp.API.MVCS.Services._DB.Implementations;
using BookStoreApp.API.MVCS.Services.Implementations;
using BookStoreApp.API.MVCS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


MongoDBSettings? mongoDBSettings =
    builder.Configuration
        .GetSection("MongoDBSettings")
        .Get<MongoDBSettings>();

if (mongoDBSettings == null)
{
    throw new InvalidOperationException("MongoDBSettings section is missing in the configuration.");
}


if (string.IsNullOrWhiteSpace(mongoDBSettings.URI))
{
    throw new InvalidOperationException("MongoDBSettings.URI is missing.");
}

if (string.IsNullOrWhiteSpace(mongoDBSettings.DatabaseName))
{
    throw new InvalidOperationException("MongoDBSettings.DatabaseName is missing.");
}



builder.Services
    .Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"))
    .AddDbContext<BookStoreDbContext>(options =>
        options.UseMongoDB(
            mongoDBSettings.URI,
            mongoDBSettings.DatabaseName));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

#region ADD_DEPENDENCY_INJECTION_SERVICES
builder.Services
    .AddScoped<IBookStoreRepository, BookStoreRepository>()
    .AddScoped<IBookAppServices, BookAppServices>();
#endregion ADD_DEPENDENCY_INJECTION_SERVICES


// ADD SERILOG FOR LOGGING
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration)
    );

// ADD CORS POLICY
// ALLOWS ALL ORIGINS, METHODS, AND HEADERS - USE WITH CAUTION IN PRODUCTION ENVIRONMENTS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // ADD SWAGGER UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// APPLY THE CORS POLICY
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
