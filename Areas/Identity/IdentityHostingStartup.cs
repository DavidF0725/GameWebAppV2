using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyGameWebApp.Areas.Identity.Data;
using MyGameWebApp.Data;

[assembly: HostingStartup(typeof(MyGameWebApp.Areas.Identity.IdentityHostingStartup))]
namespace MyGameWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyGameWebAppDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MyGameWebAppDBContextConnection")));

                services.AddDefaultIdentity<MyGameWebAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MyGameWebAppDBContext>();
            });
        }
    }
}