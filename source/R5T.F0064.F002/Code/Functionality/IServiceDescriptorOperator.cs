using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0064.F002
{
	[FunctionalityMarker]
	public partial interface IServiceDescriptorOperator : IFunctionalityMarker,
		F0064.IServiceDescriptorOperator
	{
		public ServiceDescriptorInformation GetInformation(ServiceDescriptor serviceDescriptor)
        {
			var serviceTypeStandardRepresentation = this.GetServiceTypeStandardRepresentation(serviceDescriptor);
			var lifetimeStandardRepresentation = this.GetLifetimeStandardRepresentation(serviceDescriptor);

			var implementationTypeRepresentation = serviceDescriptor.ImplementationType is object
				? this.GetImplementationTypeStandardRepresentation(serviceDescriptor)
				: null
				;

			var implementationInstanceRepresentation = serviceDescriptor.ImplementationInstance is object
				? this.GetImplementationInstanceStandardRepresentation(serviceDescriptor)
				: null
				;

			var implementationFactoryRepresentation = serviceDescriptor.ImplementationFactory is object
				? this.GetImplementationFactoryStandardRepresentation(serviceDescriptor)
				: null
				;

			var serviceDescriptorInformation = new ServiceDescriptorInformation
			{
				ServiceType = serviceTypeStandardRepresentation,
				ServiceLifetime = lifetimeStandardRepresentation,
				ImplementationType = implementationTypeRepresentation,
				ImplementationInstanceType = implementationInstanceRepresentation,
				ImplementationFactoryType = implementationFactoryRepresentation,
			};

			return serviceDescriptorInformation;
		}
	}
}