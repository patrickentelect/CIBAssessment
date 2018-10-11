using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhonebookApi.Data.Models;
using PhonebookApi.Data.Repositories;
using PhonebookApi.Service.Services;

namespace phonebookApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCorsService(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = "Data Source=phonebook.db";
                services.AddDbContext<PhoneBookApiContext>
                    (options => options.UseSqlite(connection));

            services.AddTransient<IEntryService, EntryService>();
            services.AddTransient<IPhoneBookService, PhonebookBookService>();
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UpdateDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowSpecificOrigin");
            app.UseMvc();
        }

        private void ConfigureCorsService(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //TODO: move to appsettings
                var allowedOrigins = new[]
                {
                    "http://localhost:3000"
                };

                options.AddPolicy(
                    "AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins(allowedOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PhoneBookApiContext>())
                {
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}
