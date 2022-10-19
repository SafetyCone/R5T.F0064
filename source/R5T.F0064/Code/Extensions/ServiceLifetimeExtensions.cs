using System;

using Microsoft.Extensions.DependencyInjection;

using Instances = R5T.F0064.Instances;


public static class ServiceLifetimeExtensions
{
    public static string ToStringStandard(this ServiceLifetime serviceLifetime)
    {
        var representation = Instances.ServiceLifetimeOperator.ToStringStandard(serviceLifetime);
        return representation;
    }
}
