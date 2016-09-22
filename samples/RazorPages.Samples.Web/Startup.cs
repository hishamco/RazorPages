﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorPages.Samples.Web.Data;

namespace RazorPages.Samples.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase());
            services.AddDistributedMemoryCache();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddSession();
            services
                .AddMvcCore(options => options.Filters.Add(new HelloWorldFilter()))
                .AddAuthorization()
                .AddViews()
                .AddRazorViewEngine()
                .AddRazorPages(options => 
                {
                    //options.AuthorizeFolder("/", "default");
                    options.AuthorizePage("/Secure");
                    options.AllowAnonymousToPage("/Index");
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }

        private class HelloWorldFilter : IResourceFilter
        {
            public void OnResourceExecuted(ResourceExecutedContext context)
            {
            }

            public void OnResourceExecuting(ResourceExecutingContext context)
            {
                Console.WriteLine("Hello from resource filter!");
            }
        }
    }
}
