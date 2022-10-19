using System;


namespace R5T.F0064
{
	public class ServiceLifetimeOperator : IServiceLifetimeOperator
	{
		#region Infrastructure

	    public static IServiceLifetimeOperator Instance { get; } = new ServiceLifetimeOperator();

	    private ServiceLifetimeOperator()
	    {
        }

	    #endregion
	}
}