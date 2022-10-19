using System;


namespace R5T.F0064
{
	public class ServiceLifetimeNames : IServiceLifetimeNames
	{
		#region Infrastructure

	    public static IServiceLifetimeNames Instance { get; } = new ServiceLifetimeNames();

	    private ServiceLifetimeNames()
	    {
        }

	    #endregion
	}
}