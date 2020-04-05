using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration)
        {
            service.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            service.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false);

            service.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "News API", Version = "v1" });
            });
        }
    }
}
