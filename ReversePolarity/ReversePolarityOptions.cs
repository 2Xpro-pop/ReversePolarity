using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolarity
{
    public class ReversePolarityOptions
    {
        public ReversePolarityOptions(IFromJsServiceCollection services, IJsModuleImportStrategy importStrategy)
        {
            Services = services;
            ImportStrategy = importStrategy;
        }

        public IFromJsServiceCollection Services { get; }
        public IJsModuleImportStrategy ImportStrategy { get; set; }
    }
}
