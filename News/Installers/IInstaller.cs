using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News
{
    public interface IInstaller
    {
        public void InstallService(IServiceCollection service, IConfiguration configuration);
    }
}
