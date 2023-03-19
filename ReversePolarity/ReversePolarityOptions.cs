using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolarity
{
    public class ReversePolarityOptions
    {
        public IFromJsServiceCollection Services { get; }
        public IJsModuleImportStrategy ImportStrategy { get; }
    }
}
