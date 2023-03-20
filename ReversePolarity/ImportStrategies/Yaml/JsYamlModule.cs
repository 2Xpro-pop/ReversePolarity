using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;
using Jint.Native;
using Jint.Native.Object;
using Microsoft.Extensions.Configuration;

namespace ReversePolarity.ImportStrategies.Yaml
{
    public class JsYamlModule : IJsModule
    {
        private bool _isActive = true;
        private readonly Engine _jsEngine;
        public JsYamlModule(IConfiguration configuration, string name, Engine jsEngine)
        {
            _jsEngine = jsEngine ?? throw new ArgumentNullException(nameof(jsEngine));

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string Name
        {
            get;
        }

        public IConfiguration Configuration
        {
            get;
        }
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _jsEngine.Execute($"{(value ? "en" : "dis")}able()");
                }
                _isActive = value;
            }
        }

        public async Task CallbackAsync(string callback, params object[] parametres)
        {
            ThrowIfNotActive();

            _jsEngine.Invoke(callback, parametres);
        }
        public async ValueTask<T> CallbackAsync<T>(string callback, params object[] parametres)
        {
            ThrowIfNotActive();

            return (T)_jsEngine.Invoke(callback, parametres).ToObject();
        }
        public object GetService(Type serviceType) => throw new NotImplementedException();

        private void ThrowIfNotActive()
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("Module is not active!");
            }
        }
    }
}
