using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayerApp.Web.Data;
using PlayerApp.Web.Infrastructure.Interfaces;
using PlayerApp.Web.Infrastructure.Repositories;

namespace Web
{
    public class Startup
    {
        async Task DatabaseCreation(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetRequiredService<AppDbContext>();

            if (!db.Database.CanConnect() && !db.Database.GetMigrations().Any())
            {
                db.Database.EnsureCreated();
            }

            else if (db.Database.GetMigrations().Any())
                db.Database.Migrate();

            if (db.Managers.Any() && db.Clubs.Any())
                return;

            db.Managers.AddRange(Seed.ManagerSeed);
            db.Clubs.AddRange(Seed.ClubSeed);
            db.Players.AddRange(Seed.PlayerSeed);
            await db.SaveChangesAsync();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=.\\SQLExpress;Database=PlayerApp;Trusted_Connection=True;");
            });

            services.AddScoped<IPlayer, PlayerRepo>();
            services.AddScoped<IManager, ManagerRepo>();
            services.AddScoped<IClub, ClubRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(s =>
            {
                if (env.IsDevelopment())
                    s.UseProxyToSpaDevelopmentServer("http://localhost:3000");
            });

            DatabaseCreation(serviceProvider).Wait();
        }
    }
}
