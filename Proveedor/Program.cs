using Common.Utils.JWT;
using Dominio.Servicio.Servicios;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Dominio.Servicio.Dependency;
using Common.Utils.Utils;
using Common.Utils.Utils.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

internal class Program
{
   
    private static void Main(string[] args)
    {

        var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory()) // Establece el directorio base
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Lee appsettings.json
             .AddEnvironmentVariables() // Agrega soporte para variables de entorno
             .Build();

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

      
        builder.Services.AddEndpointsApiExplorer();

        //Configurando JWT VAP
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
        ValidateIssuer = true,
        ValidIssuer = configuration["Token:Issuer"],
        ValidateAudience = true,
        ValidAudience = configuration["Token:Audience"],
        ValidateLifetime = true
    };
});



        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "API de Proveedores",
                Version = "v1",
                Description = "API para gestionar proveedores"
            });

            // Configurar los comentarios de la documentación (si es necesario)
            var xmlFile = Path.Combine("swagger.xml");
            if (File.Exists(xmlFile))
            {
                c.IncludeXmlComments(xmlFile);
            }

            // Configuración de seguridad
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "Ingrese el token JWT en el formato: Bearer {token}"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
        });

         



        builder.Services.AddSingleton<ProveedorRepository>();

        builder.Services.AddInfraestructuraServices(builder.Configuration);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
        });

        
        var app = builder.Build();
        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseCors("CorsPolicy");


        app.MapControllers();

        app.Run();
    }

    
}