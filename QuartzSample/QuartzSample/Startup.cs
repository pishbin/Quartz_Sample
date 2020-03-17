﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using QuartzSample.Data;
using Quartz.Spi;
using QuartzSample.Jobs;
using Quartz;
using Quartz.Impl;

namespace QuartzSample
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
            //#region Quarts Setting
            //services.AddSingleton<IJobFactory, SingletonJobFactory>();
            //services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            //services.AddSingleton<RemoveCartJob>();
            //services.AddSingleton(new JobSchedule(jobType: typeof(RemoveCartJob), cronExpression: "0/5 * * * * ?"));
            //services.AddHostedService<QuartzHostedService>();

            //#endregion

            #region Quartz

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<RemoveCartJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(RemoveCartJob), cronExpression:
                "0/5 * * * * ?"
            ));

            services.AddHostedService<QuartzHostedService>();

            #endregion
            services.AddControllersWithViews();

            services.AddDbContext<QuartzSampleDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("QuartzSampleDbContext")));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
