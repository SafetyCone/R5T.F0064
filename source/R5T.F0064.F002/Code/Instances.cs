using System;

using R5T.F0032;


namespace R5T.F0064.F002
{
    public static class Instances
    {
        public static IJsonOperator JsonOperator { get; } = F0032.JsonOperator.Instance;
        public static IProgramOperator ProgramOperator { get; } = F002.ProgramOperator.Instance;
        public static IServiceCollectionOperator ServiceCollectionOperator { get; } = F002.ServiceCollectionOperator.Instance;
        public static IServiceDescriptorOperator ServiceDescriptorOperator { get; } = F002.ServiceDescriptorOperator.Instance;
    }
}