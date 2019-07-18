using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MvcDemoBusiness.Realization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcDemoWeb
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();  
        }
    }
}
