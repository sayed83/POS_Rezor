using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POS_Rezor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace POS_Rezor
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
            string dbConnectionString = Configuration.GetConnectionString("POSDBConnection");
            string assemblyName = typeof(AppDbContext).Namespace;
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(dbConnectionString,optionsBuilder => optionsBuilder.MigrationsAssembly(assemblyName));
                //options.UseSqlServer(Configuration.GetConnectionString("POSDBConnection"));
            });
            services.AddRazorPages();
            services.AddSingleton<IEmployeeRepository,MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
                //options.ConstraintMap.Add("even", typeof(EventConstraint));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
