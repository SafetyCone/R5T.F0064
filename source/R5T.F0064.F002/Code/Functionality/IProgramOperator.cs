using System;
using System.Threading.Tasks;

using R5T.F0037;
using R5T.T0132;


namespace R5T.F0064.F002
{
	[FunctionalityMarker]
	public partial interface IProgramOperator : IFunctionalityMarker
	{
		public ProgramBuilder AuditServicesToJsonFile(
			ProgramBuilder programBuilder,
			string servicesAuditJsonFilePath)
		{
			Instances.ServiceCollectionOperator.DescribeToJsonFile_Synchronous(
				servicesAuditJsonFilePath,
				programBuilder.Services);

			return programBuilder;
		}

		public async Task<ProgramBuilder> AuditServicesToJsonFile(
			Task<ProgramBuilder> gettingProgramBuilder,
			string servicesAuditJsonFilePath)
		{
			var programBuilder = await gettingProgramBuilder;

			this.AuditServicesToJsonFile(
				programBuilder,
				servicesAuditJsonFilePath);

			return programBuilder;
		}
	}
}