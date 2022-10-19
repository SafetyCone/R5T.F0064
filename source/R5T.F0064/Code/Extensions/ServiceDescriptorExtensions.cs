using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using R5T.F0064;

using Instances = R5T.F0064.Instances;



public static class ServiceDescriptorExtensions
{
    /// <inheritdoc cref="IServiceDescriptorOperator.GetServicesByServiceNamePreservingImplementationTypeOrder(IEnumerable{ServiceDescriptor})"/>
    public static Dictionary<string, List<ServiceDescriptor>> GetServicesByServiceNamePreservingImplementationTypeOrder(this IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        var output = Instances.ServiceDescriptorOperator.GetServicesByServiceNamePreservingImplementationTypeOrder(serviceDescriptors);
        return output;
    }

    /// <inheritdoc cref="IServiceDescriptorOperator.OrderAlphabeticallyByServiceNamePreservingImplementationTypeOrder(IEnumerable{ServiceDescriptor})"/>
    public static IEnumerable<ServiceDescriptor> OrderAlphabeticallyByServiceNamePreservingImplementationTypeOrder(this IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        var output = Instances.ServiceDescriptorOperator.OrderAlphabeticallyByServiceNamePreservingImplementationTypeOrder(serviceDescriptors);
        return output;
    }

    /// <inheritdoc cref="IServiceDescriptorOperator.OrderByService(IEnumerable{ServiceDescriptor})"/>
    public static IEnumerable<ServiceDescriptor> OrderByService(this IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        var output = Instances.ServiceDescriptorOperator.OrderByService(serviceDescriptors);
        return output;
    }

    public static string GetServiceTypeStandardRepresentation(this ServiceDescriptor serviceDescriptor)
    {
        var output = Instances.ServiceDescriptorOperator.GetServiceTypeStandardRepresentation(serviceDescriptor);
        return output;
    }

    public static string GetImplementationTypeStandardRepresentation(this ServiceDescriptor serviceDescriptor)
    {
        var output = Instances.ServiceDescriptorOperator.GetImplementationTypeStandardRepresentation(serviceDescriptor);
        return output;
    }

    public static string GetLifetimeStandardRepresentation(this ServiceDescriptor serviceDescriptor)
    {
        var output = Instances.ServiceDescriptorOperator.GetLifetimeStandardRepresentation(serviceDescriptor);
        return output;
    }

    public static ServiceDescriptorDescription ToServiceDescriptorDescription(this ServiceDescriptor serviceDescriptor)
    {
        var serviceDescriptorDescription = Instances.ServiceDescriptorOperator.ToServiceDescriptorDescription(serviceDescriptor);
        return serviceDescriptorDescription;
    }
}
