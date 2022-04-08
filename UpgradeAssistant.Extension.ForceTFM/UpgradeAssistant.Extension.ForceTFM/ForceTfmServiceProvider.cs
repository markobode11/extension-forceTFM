using System;
using Microsoft.DotNet.UpgradeAssistant;
using Microsoft.DotNet.UpgradeAssistant.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace UpgradeAssistant.Extension.ForceTFM
{
    public class ForceTfmServiceProvider : IExtensionServiceProvider
    {

        public void AddServices(IExtensionServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddExtensionOption<TfmOption>("ForceTFM");
            services.AddExtensionOption<TfmOptionMap>("TFMOptionMap");

            services.Services.AddTransient<ITargetFrameworkSelector, CustomTargetFrameworkSelector>();
        }
    }
}