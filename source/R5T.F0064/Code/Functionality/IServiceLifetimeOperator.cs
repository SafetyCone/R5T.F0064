using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0064
{
	[FunctionalityMarker]
	public partial interface IServiceLifetimeOperator : IFunctionalityMarker
	{
        public string ToStringStandard(ServiceLifetime serviceLifetime)
        {
            var representation = serviceLifetime switch
            {
                ServiceLifetime.Scoped => Instances.ServiceLifetimeNames.Scoped,
                ServiceLifetime.Singleton => Instances.ServiceLifetimeNames.Singleton,
                ServiceLifetime.Transient => Instances.ServiceLifetimeNames.Transient,
                _ => throw F0000.EnumerationOperator.Instance.SwitchDefaultCaseException(serviceLifetime),
            };

            return representation;
        }
    }
}