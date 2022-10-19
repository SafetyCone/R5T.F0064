using System;
using System.Threading.Tasks;

using R5T.F0037;
using R5T.T0132;


namespace R5T.F0064.F001
{
	[FunctionalityMarker]
	public partial interface IProgramOperator : IFunctionalityMarker,
		F0037.IProgramOperator
	{
		public ProgramBuilder AuditServicesToTextFile(
			ProgramBuilder programBuilder,
			string servicesAuditTextFilePath)
		{
			Instances.ServiceCollectionOperator.DescribeToTextFile_Synchronous(
				servicesAuditTextFilePath,
				programBuilder.Services);

			return programBuilder;
		}

		public async Task<ProgramBuilder> AuditServicesToTextFile(
			Task<ProgramBuilder> gettingProgramBuilder,
			string servicesAuditTextFilePath)
        {
			var programBuilder = await gettingProgramBuilder;

			this.AuditServicesToTextFile(
				programBuilder,
				servicesAuditTextFilePath);

			return programBuilder;
		}
	}
}