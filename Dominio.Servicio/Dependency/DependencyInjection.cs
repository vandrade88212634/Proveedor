using Common.Utils.RestServices.Interface;
using Common.Utils.RestServices;
using Common.Utils.Utils.Interface;
using Common.Utils.Utils;


using Dominio.Servicio.Servicios.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


using Microsoft.Extensions.Caching.Memory;

using System.Text;
using Dominio.Servicio.Servicios;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Dominio.Servicio.Dependency
{
    
    public static class DependencyInyection
    {

        
        public static IServiceCollection AddInfraestructuraServices(this IServiceCollection services,
                IConfiguration configuration)
        {
          

       



           
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILoginService, LoginService>();
            
            
            services.AddScoped<MemoryCache, MemoryCache>();
            services.AddScoped<Utils, Utils>();
            
           
         
         


            // Infrastructure

          
            services.AddTransient<IHeaderClaims, HeaderClaims>();
            services.AddTransient<IRestService, RestService>();
            services.AddTransient<IMemoryCache, MemoryCache>();
            services.AddTransient<IUtils, Utils>();
            services.AddTransient<IAuthentication, Authentication>();
           
            services.AddTransient<IBinnacle, Binnacle>();
            services.AddScoped<ILoginService, LoginService>();

            // Common




            ////Utils
            //services.AddTransient<IUtils, Utils>();
            //services.AddTransient<IAuthentication, Authentication>();



          


            return services;
        }


        
        #region methods




        private static IConfigurationRoot GetConnection()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        #endregion

    }

}
