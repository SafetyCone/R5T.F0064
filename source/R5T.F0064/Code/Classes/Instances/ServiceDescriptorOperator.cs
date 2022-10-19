using System;


namespace R5T.F0064
{
	public class ServiceDescriptorOperator : IServiceDescriptorOperator
	{
		#region Infrastructure

	    public static IServiceDescriptorOperator Instance { get; } = new ServiceDescriptorOperator();

	    private ServiceDescriptorOperator()
	    {
        }

	    #endregion
	}
}