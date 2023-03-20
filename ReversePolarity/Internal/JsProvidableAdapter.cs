using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ReversePolarity.Internal
{
    public class JsProvidableAdapter : IFromJsServiceCollection
    {
        private readonly IServiceCollection _services;

        public JsProvidableAdapter(IServiceCollection services)
        {
            _services = services;
        }

        public ServiceDescriptor this[int index] { get => ((IList<ServiceDescriptor>)_services)[index]; set => ((IList<ServiceDescriptor>)_services)[index] = value; }

        public int Count => _services.Count;

        public bool IsReadOnly => _services.IsReadOnly;


        public void Add(ServiceDescriptor item)
        {
            var desriptor = new ServiceDescriptor(item.ServiceType, services =>
            {
                var jsModules = services.GetRequiredService<IJsModules>();
                var fromJsService = jsModules.GetService(item.ServiceType);

                if (item.ImplementationInstance != null)
                {
                    return fromJsService ?? item.ImplementationInstance!;
                }

                if (item.ImplementationFactory != null)
                {
                    return fromJsService ?? item.ImplementationFactory.Invoke(services);
                }

                return null;

            }, item.Lifetime);

            _services.Add(desriptor);
        }
        public void Clear() => _services.Clear();
        public bool Contains(ServiceDescriptor item) => _services.Contains(item);
        public void CopyTo(ServiceDescriptor[] array, int arrayIndex) => _services.CopyTo(array, arrayIndex);
        public IEnumerator<ServiceDescriptor> GetEnumerator() => _services.GetEnumerator();
        public int IndexOf(ServiceDescriptor item) => _services.IndexOf(item);
        public void Insert(int index, ServiceDescriptor item) => _services.Insert(index, item);
        public bool Remove(ServiceDescriptor item) => _services.Remove(item);
        public void RemoveAt(int index) => _services.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_services).GetEnumerator();
    }
}
