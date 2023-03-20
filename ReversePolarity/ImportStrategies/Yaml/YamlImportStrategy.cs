using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReversePolarity.ImportStrategies.Yaml
{
    public class YamlImportStrategy : IJsModuleImportStrategy
    {

        public IEnumerable<IJsModule> ListOfImports => throw new NotImplementedException();

        public IJsModule Import(string module)
        {
            var builder = new JsYamlModuleBuilder()
                .SetYamlConfiguration($"{module}/module.yaml");
        }
    }
}
