using System;

using R5T.F0017.F002;


namespace R5T.F0064
{
    public static class Instances
    {
        public static IIdentityNameProvider IdentityNameProvider { get; } = F0017.F002.IdentityNameProvider.Instance;
        public static IServiceDescriptorOperator ServiceDescriptorOperator { get; } = F0064.ServiceDescriptorOperator.Instance;
        public static IServiceLifetimeNames ServiceLifetimeNames { get; } = F0064.ServiceLifetimeNames.Instance;
        public static IServiceLifetimeOperator ServiceLifetimeOperator { get; } = F0064.ServiceLifetimeOperator.Instance;
    }
}