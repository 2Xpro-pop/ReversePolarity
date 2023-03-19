using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolarity.ImportStrategies.Yaml
{
    public class YamlImportStrategy : IJsModuleImportStrategy
    {
        private readonly IJsModules _modules;
        public YamlImportStrategy(IJsModules jsModules)
        {
            _modules = jsModules;
        }

        public IEnumerable<IJsModule> ListOfImports => throw new NotImplementedException();

        public IJsModule Import(string module)
        {

        }
    }
}
