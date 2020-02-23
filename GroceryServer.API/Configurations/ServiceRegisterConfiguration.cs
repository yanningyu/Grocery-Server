// Copyright @JJSoft - All Rights Reserved
// Filename: ServiceRegisterConfiguration.cs
// Created By  :  Frankie
// Created Date:  22/02/2020  20:42
// Last Edit:
//    Author:   Frankie
//    Date:     23/02/2020  10:37

namespace GroceryServer.API.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using GroceryServer.Constants;
    using GroceryServer.Infrastructure.ConsumerStructure;
    using GroceryServer.Infrastructure.ConsumerStructure.Interfaces;
    using GroceryServer.Services;
    using GroceryServer.Services.Interfaces;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceRegisterConfiguration
    {
        public static void AddRegisterService(this IServiceCollection services, IHostingEnvironment environment, IConfiguration configuration)
        {
            services.AddTransient<IAppSettingService, AppsettingService>();
            services.AddOptions();
            services.AddTransient<IConsumerFactory, ConsumerFactory>();

            // add Consumer mappings
            var allAssemblies = new List<Assembly>();
            var objExecutingAssemblies = Assembly.GetExecutingAssembly();
            var arrReferencedAssmblyNames = objExecutingAssemblies.GetReferencedAssemblies();
            foreach (var arrReferencedAssemblyName in arrReferencedAssmblyNames)
            {
                allAssemblies.Add(Assembly.Load(arrReferencedAssemblyName));
            }

            foreach (var assembly in allAssemblies)
            {
                var hasImplementedConsumer = assembly.GetTypes().Any(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition().FullName == typeof(IConsumer<,>).FullName));

                if (!hasImplementedConsumer)
                {
                    continue;
                }

                var q = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition().FullName == typeof(IConsumer<,>).FullName));
                foreach (var t in q.ToList())
                {
                    Type.GetType(t.Name);
                    var firstOrDefault = t.GetInterfaces().FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        services.AddTransient(Type.GetType(firstOrDefault.AssemblyQualifiedName), Type.GetType(t.AssemblyQualifiedName));
                    }
                }
            }
        }

        public static void AddDefaultPolicy(this IServiceCollection services)
        {
            services.AddCors(
                options =>
                    {
                        // this defines a CORS policy called "default"
                        options.AddPolicy(
                            Policies.DefaultPolicy,
                            policy =>
                                {
                                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("etag");
                                });
                    });
        }
    }
}