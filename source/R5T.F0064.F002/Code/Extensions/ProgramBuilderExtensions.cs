using System;
using System.Threading.Tasks;

using R5T.F0037;

using Instances = R5T.F0064.F002.Instances;


public static class ProgramBuilderExtensions
{
	public static ProgramBuilder AuditServicesToJsonFile(this ProgramBuilder programBuilder,
		string servicesAuditJsonFilePath)
	{
		Instances.ProgramOperator.AuditServicesToJsonFile(
			programBuilder,
			servicesAuditJsonFilePath);

		return programBuilder;
	}

	public static Task<ProgramBuilder> AuditServicesToJsonFile(this Task<ProgramBuilder> gettingProgramBuilder,
		string servicesAuditJsonFilePath)
	{
		return Instances.ProgramOperator.AuditServicesToJsonFile(
			gettingProgramBuilder,
			servicesAuditJsonFilePath);
	}
}
