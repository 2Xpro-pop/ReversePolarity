using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace ReversePolarity
{
    public interface IJsModule: IServiceProvider
    {
        public string Name { get; }
        IConfiguration Configuration { get; }
        bool IsActive { get; set; }
    }
}
