using Balance.Application.Services;
using Balance.Core.Interfaces.Repos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;

namespace Balance.Api.DI
{
    public class DIRegister
    {
        WebApplicationBuilder _builder;
        IServiceCollection _services;

        IConfiguration _configuration;
        string tokenSercurityKey = string.Empty;
        public DIRegister(WebApplicationBuilder builder, IConfiguration configuration)
        {
            _builder = builder;
            _services = builder.Services;

            _configuration = configuration;
            tokenSercurityKey = _configuration.GetValue<string>("SecurityKeys:AuthTokenSecurityKey");
        }
        public void RegisterDependencies()
        {

            string connString = _builder.Configuration.GetConnectionString("DefaultConnectionString");

            _services.AddScoped<IDbConnection, SqlConnection>(sp =>
            {
                return new SqlConnection(connString);
            });

            _services.AddScoped<IAuthService, AuthService>(sp =>
            {
                return new AuthService(tokenSercurityKey);
            });

            _services.AddScoped<IUserService, UserService>();
        }

    }
}
