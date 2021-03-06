﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Business;
using EmployeeService.Business.Clients;
using EmployeeService.Common;
using EmployeeService.Framework;
using EmployeeService.Framework.Options;
using EmployeeService.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using EmployeeService.Business.Infrastructure;

namespace EmployeeService
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

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehavior<,>));            
            services.AddMediatR(typeof(Business.Application.Employees.Queries.GetEmployeeQueryHandler).GetTypeInfo().Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Employee API",
                    Version = "v1",
                    Description = "Backing API for the Employee"                    
                });
            });

            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);

            var sp = services.BuildServiceProvider();
            var _appSetting = (sp.GetService<IOptions<AppSettings>>()).Value as AppSettings;

            services.AddSingleton<IAppSettings>(_appSetting);
            services.AddScoped<IEmployeeBusinessController, EmployeeBusinessController>();

            services.AddSingleton(AutoMapperConfiguration.Configure());
            services
                .AddPolicies(Configuration)
                .AddHttpClient<IEmployeeClient, EmployeeClient, EmployeeClientOptions>(Configuration, nameof(ApplicationOptions.EmployeeClient));

           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Employee API V1");
            });           

            app.UseAuthentication();
            app.UseMiddleware<CustomResponseHeaderMiddleware>();
           //app.UseMiddleware<LoggingMiddleware>();            
            app.UseMvc();
        }
    }
}
