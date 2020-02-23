// Copyright @JJSoft - All Rights Reserved
// Filename: Startup.cs
// Created By  :  Frankie
// Created Date:  22/02/2020  17:05
// Last Edit:
//    Author:   Frankie
//    Date:     22/02/2020  20:40

namespace GroceryServer.API
{
    using GroceryServer.API.Configurations;
    using GroceryServer.Constants;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            this.Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddMvc();

            services.AddMvcCore().AddDataAnnotations().AddAuthorization();

            services.AddOptions();
            services.AddRegisterService(this.Environment, this.Configuration);
            services.AddDefaultPolicy();
            services.BuildServiceProvider();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(Policies.DefaultPolicy);
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllers();
                    });

        }
    }
}