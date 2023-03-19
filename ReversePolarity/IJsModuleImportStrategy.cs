using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolarity
{
    public interface IJsModuleImportStrategy
    {
        IEnumerable<IJsModule> ListOfImports { get; }
        IJsModule Import(string name);
    }
}
