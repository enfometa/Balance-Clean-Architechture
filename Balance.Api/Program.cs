using Balance.Api.DI;
using Balance.Api.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Register app dependencies like db context, repos, services
DIRegister dIRegister = new DIRegister(builder, configuration);
dIRegister.RegisterDependencies();

//Add JWT authentication service
string tokenSecurityKey = configuration.GetValue<string>("SecurityKeys:AuthTokenSecurityKey");
builder.Services.AddJWTAuthenticationService(tokenSecurityKey);

builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CORSPolicy");

app.Run();
