using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ReversePolarity.ImportStrategies.Yaml;
using ReversePolarity.Internal;

namespace ReversePolarity
{
    public static class ServiceCollectionRpExtensions
    {
        public static void ConfigureJsProvidable(this IServiceCollection services, Action<IFromJsServiceCollection>? configure = null)
        {
            var jsServices = new JsProvidableAdapter(services);
            configure?.Invoke(jsServices);
        }

        public static void AddReversePolarity(this IServiceCollection services, Action<ReversePolarityOptions>? configure = null)
        {
            var jsServices = new JsProvidableAdapter(services);
            var yamlStrategy = new YamlImportStrategy();
            var options = new ReversePolarityOptions(jsServices, yamlStrategy);

            services.AddSingleton<IJsModules>();
        }
    }
}
