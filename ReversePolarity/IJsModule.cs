using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ReversePolarity
{
    public interface IJsModule: IServiceProvider
    {
        public string Name { get; }
        IConfiguration Configuration { get; }
        bool IsActive { get; set; }
        Task CallbackAsync(string callback, params object[] parametres);
        ValueTask<T> CallbackAsync<T>(string callback, params object[] parametres);
    }
}
