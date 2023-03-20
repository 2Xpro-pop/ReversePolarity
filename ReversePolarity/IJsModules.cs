using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ReversePolarity
{
    public interface IJsModules: ICollection<IJsModule>, IServiceProvider
    {
        public IServiceCollection Services { get; }
    }
}
