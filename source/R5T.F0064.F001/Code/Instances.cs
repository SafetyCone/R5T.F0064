using System;


namespace R5T.F0064.F001
{
    public static class Instances
    {
        public static IProgramOperator ProgramOperator { get; } = F001.ProgramOperator.Instance;
        public static IServiceCollectionOperator ServiceCollectionOperator { get; } = F0064.ServiceCollectionOperator.Instance;
    }
}