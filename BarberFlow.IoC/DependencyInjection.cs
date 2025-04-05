using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberFlow.Domain.Account;
using BarberFlow.Domain.Interfaces;
using BarberFlow.Infra.Data.Context;
using BarberFlow.Infra.Data.Identity;
using BarberFlow.Infra.Data.Persistence;
using BarberFlow.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberFlow.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
    {
        // Dbcontext with PostgresSQL configuration
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => 
                b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        //Identity configuration
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        // Register Repositories
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();

        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedRoleInitial, ISeedRoleInitial>();
        // Register Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
