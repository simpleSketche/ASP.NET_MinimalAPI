using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSampleLibrary(this IServiceCollection services)
        {
            services.AddSingleton<ITestLib, TestClass>();

            return services;
        }
    }
}
