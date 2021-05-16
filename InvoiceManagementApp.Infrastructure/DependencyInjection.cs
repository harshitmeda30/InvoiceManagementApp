using InvoiceManagementApp.Infrastructure.Data;
using InvoiceManagementApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManagementApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            return services;
        }
    }
}
