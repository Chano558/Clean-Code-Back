using CleanArchitectureApplication.Validators;
using CleanArchitectureDomain.Interfaces;
using CleanArchitectureInfrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureInfrastructure
{
    public static class Installer
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<SqlServerDbContext>();
            services.AddDbContext<SqlServerDbContext>(options =>
            {
                // options.EnableSensitiveDataLogging();
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(30);
                    sqlServerOptions.EnableRetryOnFailure();
                    sqlServerOptions.MigrationsHistoryTable("_Migrations");
                    sqlServerOptions.MigrationsAssembly("Foodly.Infrastructure");
                });
            });
            services.AddScoped<IUserRepository, UserRepository>(); // cada vez que haga un request se vuelve a llamar
            //builder.Services.AddSingleton<IUserRepository, UserRepository>(); // se crea y perdura en el tiempo
            //services.AddTransient<IUserRepository, UserRepository>(); // cada vez que se llame se vuelve a generar
        }
    }
}