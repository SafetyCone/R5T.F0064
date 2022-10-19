using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.F0064
{
    public class ServiceDescriptorDescription
    {
        public string ServiceType { get; set; }
        public string ImplementationType { get; set; }
        public ServiceLifetime ServiceLifetime { get; set; }
    }
}
