using System;
using System.Collections.Generic;
using System.Text;
using ImpromptuInterface;
using Jint;
using Microsoft.Extensions.Configuration;

namespace ReversePolarity.ImportStrategies.Yaml
{
    public class JsYamlModuleBuilder
    {
        private readonly IConfigurationBuilder configurationBuilder;
        private string? _entryPointPath;
        private Engine _jsEngine;

        public JsYamlModuleBuilder()
        {
            configurationBuilder = new ConfigurationBuilder();
        }

        public JsYamlModuleBuilder SetYamlConfiguration(string path, Action<IConfigurationBuilder> action = null)
        {
            configurationBuilder.AddYamlFile(path);

            action(configurationBuilder);

            return this;
        }

        public JsYamlModuleBuilder SetEntryPoint(string path)
        {
            _entryPointPath = path;
            return this;
        }

        public JsYamlModuleBuilder SetJsEngine(Engine engine)
        {
            _jsEngine = engine;
            return this;
        }

        public JsYamlModuleBuilder SetJsEngine(Action<Options> engineOptions)
        {
            _jsEngine = new Engine(engineOptions);
            return this;
        }

        public JsYamlModule Build()
        {
            _jsEngine ??= new Engine();


        }

    }
}
