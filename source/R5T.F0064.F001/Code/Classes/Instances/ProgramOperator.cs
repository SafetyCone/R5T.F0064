using System;


namespace R5T.F0064.F001
{
	public class ProgramOperator : IProgramOperator
	{
		#region Infrastructure

	    public static IProgramOperator Instance { get; } = new ProgramOperator();

	    private ProgramOperator()
	    {
        }

	    #endregion
	}
}