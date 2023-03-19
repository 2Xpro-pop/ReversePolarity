using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ReversePolarity.ImportStrategies.Yaml
{
    public class JsYamlModule : IJsModule
    {
        public string Name => throw new NotImplementedException();

        public IConfiguration Configuration { get; }

        public JsYamlModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool IsActive
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public object GetService(Type serviceType) => throw new NotImplementedException();
    }
}
