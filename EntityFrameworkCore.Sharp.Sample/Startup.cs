using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CnSharp.EntityFrameworkCore;
using EntityFrameworkCore.Sharp.Sample.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EntityFrameworkCore.Sharp.Sample
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<AuditingOptions>(new AuditingOptions
            {
                ModifiedByProperty = "UpdatedBy",
                ModifiedDateProperty = "UpdatedDate"
            });
            services.AddSingleton<MultiTenantOptions>(new MultiTenantOptions { TenantIdField = "CompanyId" });
            services.AddSingleton<IAuditorAware<string>, MyAuditorAware>();
            services.AddSingleton<ITenantAware<string>, MyTenantAware>();
            services.AddScoped<HostRepo>();
            services.AddSingleton<IAuditingTimeProvider, MyAuditingTimeProvider>();
            services.AddDbContext<MyDbContext>(b =>
            {
                b.UseSqlite("filename=./saas.db");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
