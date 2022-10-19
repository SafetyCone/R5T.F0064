using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0064
{
	[FunctionalityMarker]
	public partial interface IServiceDescriptorOperator : IFunctionalityMarker
	{
        /// <summary>
        /// Get services by service type name, but preserving the order of implementation types of the same service type.
        /// This is important, since only the last service type for an implementation will be provided by the service provider if multiple implementations for the same service are registered and a single service is requested (as opposed to an IEnumerable of the service, in which case all implementation types will be provided).
        /// </summary>
        public Dictionary<string, List<ServiceDescriptor>> GetServicesByServiceNamePreservingImplementationTypeOrder(IEnumerable<ServiceDescriptor> serviceDescriptors)
        {
            var serviceDescriptorsByServiceTypeFullName = new Dictionary<string, List<ServiceDescriptor>>();

            foreach (var serviceDescriptor in serviceDescriptors)
            {
                var serviceFullName = serviceDescriptor.ServiceType.FullName;

                var serviceDescriptorsForServiceTypeFullName = serviceDescriptorsByServiceTypeFullName.AcquireValue(serviceFullName, () => new List<ServiceDescriptor>());

                serviceDescriptorsForServiceTypeFullName.Add(serviceDescriptor);
            }

            return serviceDescriptorsByServiceTypeFullName;
        }

        /// <summary>
        /// Orders services alphabetically by service type name, but preserves the order of implementation types of the same service type.
        /// This is important, since only the last service type for an implementation will be provided by the service provider if multiple implementations for the same service are registered and a single service is requested (as opposed to an IEnumerable of the service, in which case all implementation types will be provided).
        /// </summary>
        public IEnumerable<ServiceDescriptor> OrderAlphabeticallyByServiceNamePreservingImplementationTypeOrder(IEnumerable<ServiceDescriptor> serviceDescriptors)
        {
            var serviceDescriptorsByServiceTypeFullName = serviceDescriptors.GetServicesByServiceNamePreservingImplementationTypeOrder();

            var output = serviceDescriptorsByServiceTypeFullName
                .OrderAlphabetically(xPair => F0000.NamespacedTypeNameOperator.Instance.GetTypeName(xPair.Key))
                .SelectMany(xPair => xPair.Value)
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="OrderAlphabeticallyByServiceNamePreservingImplementationTypeOrder(IEnumerable{MicrosoftServiceDescriptor})"/> as the default order-by-service.
        /// </summary>
        public IEnumerable<ServiceDescriptor> OrderByService(IEnumerable<ServiceDescriptor> serviceDescriptors)
        {
            var output = this.OrderAlphabeticallyByServiceNamePreservingImplementationTypeOrder(serviceDescriptors);
            return output;
        }

        /// <summary>
        /// Describes all aspects of the service descriptor, even if they are null.
        /// </summary>
        /// <param name="isLastImplementationOfServiceType">Note: the last implementation of a service type will be the service that is actually provided if multiple implementations for a service type are registered, but only one is requested.</param>
        public string Describe_Full(
            ServiceDescriptor serviceDescriptor,
            bool isLastImplementationOfServiceType = true)
        {
            var stringBuilder = new StringBuilder();

            var serviceNamespacedTypeName = F0000.NamespacedTypeNameOperator.Instance.GetNamespacedTypeName_FromFullName(serviceDescriptor.ServiceType.FullName);
            var serviceNameUnmodified = F0000.NamespacedTypeNameOperator.Instance.GetTypeName(serviceNamespacedTypeName);

            var serviceName = isLastImplementationOfServiceType
                ? $"{Z0000.Strings.Instance.Asterix} {serviceNameUnmodified}"
                : serviceNameUnmodified
                ;

            var serviceTypeStandardRepresentation = serviceDescriptor.GetServiceTypeStandardRepresentation();
            var implementationTypeStandardRepresentation = serviceDescriptor.GetImplementationTypeStandardRepresentation();
            var lifetimeStandardRepresentation = serviceDescriptor.GetLifetimeStandardRepresentation();
            var implementationInstanceRepresentation = this.GetImplementationInstanceStandardRepresentation(serviceDescriptor);
            var implementationFactoryRepresentation = this.GetImplementationFactoryStandardRepresentation(serviceDescriptor);

            stringBuilder
                .AppendLine("-----")
                .AppendLine(serviceName)
                .AppendLine($"{nameof(serviceDescriptor.Lifetime)}: {lifetimeStandardRepresentation}")
                .AppendLine($"Service Type: {serviceTypeStandardRepresentation}")
                .AppendLine($"Implementation Type: {implementationTypeStandardRepresentation}")
                .AppendLine($"Implementation Instance: { implementationInstanceRepresentation }")
                .AppendLine($"Implementation Factory: { implementationFactoryRepresentation }")
                ;

            var description = stringBuilder.ToString();
            return description;
        }

        /// <summary>
        /// Does not describe parts of the service descriptor that are null.
        /// </summary>
        /// <inheritdoc cref="Describe_Full(ServiceDescriptor, bool)" path="/param[@name='isLastImplementationOfServiceType']"/>
        public string Describe_Truncate(
            ServiceDescriptor serviceDescriptor,
            bool isLastImplementationOfServiceType = true)
        {
            var stringBuilder = new StringBuilder();

            var serviceNamespacedTypeName = F0000.NamespacedTypeNameOperator.Instance.GetNamespacedTypeName_FromFullName(serviceDescriptor.ServiceType.FullName);
            var serviceNameUnmodified = F0000.NamespacedTypeNameOperator.Instance.GetTypeName(serviceNamespacedTypeName);

            var serviceName = isLastImplementationOfServiceType
                ? $"{Z0000.Strings.Instance.Asterix} {serviceNameUnmodified}"
                : serviceNameUnmodified
                ;

            var serviceTypeStandardRepresentation = serviceDescriptor.GetServiceTypeStandardRepresentation();
            var lifetimeStandardRepresentation = serviceDescriptor.GetLifetimeStandardRepresentation();

            stringBuilder
                .AppendLine("-----")
                .AppendLine(serviceName)
                .AppendLine($"{nameof(serviceDescriptor.Lifetime)}: {lifetimeStandardRepresentation}")
                .AppendLine($"Service Type: {serviceTypeStandardRepresentation}")
                ;

            if(serviceDescriptor.ImplementationType is object)
            {
                var implementationTypeStandardRepresentation = serviceDescriptor.GetImplementationTypeStandardRepresentation();

                stringBuilder.AppendLine($"Implementation Type: {implementationTypeStandardRepresentation}");
            }

            if(serviceDescriptor.ImplementationInstance is object)
            {
                var implementationInstanceRepresentation = this.GetImplementationInstanceStandardRepresentation(serviceDescriptor);

                stringBuilder.AppendLine($"Implementation Instance: {implementationInstanceRepresentation}");
            }

            if(serviceDescriptor.ImplementationFactory is object)
            {
                var implementationFactoryRepresentation = this.GetImplementationFactoryStandardRepresentation(serviceDescriptor);

                stringBuilder.AppendLine($"Implementation Factory: {implementationFactoryRepresentation}");
            }

            var description = stringBuilder.ToString();
            return description;
        }

        /// <summary>
        /// Chooses <see cref="Describe_Truncate(ServiceDescriptor, bool)"/> as the default.
        /// </summary>
        /// <inheritdoc cref="Describe_Full(ServiceDescriptor, bool)" path="/param[@name='isLastImplementationOfServiceType']"/>
        public string Describe(
            ServiceDescriptor serviceDescriptor,
            bool isLastImplementationOfServiceType = true)
        {
            var description = this.Describe_Truncate(
                serviceDescriptor,
                isLastImplementationOfServiceType);

            return description;
        }

        public string GetServiceTypeStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var output = Instances.IdentityNameProvider.GetIdentityNameValue(serviceDescriptor.ServiceType);
            return output;
        }

        public string GetImplementationTypeStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var hasImplementationType = serviceDescriptor.ImplementationType is object;

            var output = hasImplementationType
                ? Instances.IdentityNameProvider.GetIdentityNameValue(serviceDescriptor.ImplementationType)
                : Z0000.Strings.Instance.Null_TextRepresentation
                ;

            return output;
        }

        public string GetLifetimeStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var output = serviceDescriptor.Lifetime.ToStringStandard();
            return output;
        }

        public string GetImplementationInstanceStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var hasImplementationInstance = serviceDescriptor.ImplementationInstance is object;
            if(!hasImplementationInstance)
            {
                return Z0000.Strings.Instance.Null_TextRepresentation;
            }

            var implementationInstanceType = serviceDescriptor.ImplementationInstance.GetType();

            var implementationInstanceTypeIdentityName = Instances.IdentityNameProvider.GetIdentityNameValue(implementationInstanceType);
            return implementationInstanceTypeIdentityName;
        }

        public string GetImplementationFactoryStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var hasImplementationFactory = serviceDescriptor.ImplementationFactory is object;
            if (!hasImplementationFactory)
            {
                return Z0000.Strings.Instance.Null_TextRepresentation;
            }

            throw new NotImplementedException();

            //// The below needs testing!
            //var implementationFactoryType = serviceDescriptor.ImplementationInstance.GetType();

            //var implementationFactoryTypeIdentityName = Instances.IdentityNameProvider.GetIdentityName(implementationFactoryType);
            //return implementationFactoryTypeIdentityName;
        }

        public ServiceDescriptorDescription ToServiceDescriptorDescription(ServiceDescriptor serviceDescriptor)
        {
            var serviceTypeStandardRepresentation = serviceDescriptor.GetServiceTypeStandardRepresentation();
            var implementationTypeStandardRepresentation = serviceDescriptor.GetImplementationTypeStandardRepresentation();

            var serviceDescriptorDescription = new ServiceDescriptorDescription
            {
                ImplementationType = implementationTypeStandardRepresentation,
                ServiceType = serviceTypeStandardRepresentation,
                ServiceLifetime = serviceDescriptor.Lifetime,
            };
            return serviceDescriptorDescription;
        }
    }
}