using System.Text.Json.Serialization;
using BarberFlow.API.Middlewares.Filters;
using BarberFlow.API.Middlewares.Logging;
using BarberFlow.IoC;
using CleanArchMvc.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddControllers(options => 
    options.Filters.Add(typeof(ApiExceptionFilter)))
.AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ApiLoggingFilter>();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarberFlow.API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
