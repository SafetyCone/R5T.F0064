using System;


namespace R5T.F0064.F002
{
	public class ServiceCollectionOperator : IServiceCollectionOperator
	{
		#region Infrastructure

	    public static IServiceCollectionOperator Instance { get; } = new ServiceCollectionOperator();

	    private ServiceCollectionOperator()
	    {
        }

	    #endregion
	}
}