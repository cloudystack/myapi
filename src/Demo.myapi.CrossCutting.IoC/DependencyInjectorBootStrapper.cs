using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Demo.myapi.BusinessLogic.Core.Services;
using Demo.myapi.BusinessLogic.Core.Services.Interfaces;
using Demo.myapi.BusinessLogic.Interfaces;
using Demo.myapi.BusinessLogic.Services;
using Demo.myapi.BusinessLogic.Services.Interfaces;
using Demo.myapi.CrossCutting.Identity;
using Demo.myapi.DataAccess.Core.Interfaces;
using Demo.myapi.DataAccess.DynamoDb.Services;
using System;

namespace Demo.myapi.CrossCutting.IoC
{
    public class DependencyInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services,
                                            IHostingEnvironment env, 
                                            IConfiguration configuration)
        {
            // Business Logic
            services.AddScoped<IAppSettingQueryService, AppSettingQueryService>();
            services.AddScoped<IAppSettingService, AppSettingService>();

            services.AddScoped<IBusinessManagerService, BusinessManagerService>();

            // Data Access
            services.AddScoped<IAppSettingDataService, AppSettingDynamoDbDataService>();

            // CrossCutting
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
