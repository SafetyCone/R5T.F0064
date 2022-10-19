using System;
using System.Threading.Tasks;

using R5T.F0037;

using Instances = R5T.F0064.F001.Instances;


public static class ProgramBuilderExtensions
{
	public static ProgramBuilder AuditServicesToTextFile(this ProgramBuilder programBuilder,
		string servicesAuditTextFilePath)
	{
		Instances.ProgramOperator.AuditServicesToTextFile(
			programBuilder,
			servicesAuditTextFilePath);

		return programBuilder;
	}

	public static Task<ProgramBuilder> AuditServicesToTextFile(this Task<ProgramBuilder> gettingProgramBuilder,
		string servicesAuditTextFilePath)
	{
		return Instances.ProgramOperator.AuditServicesToTextFile(
			gettingProgramBuilder,
			servicesAuditTextFilePath);
	}
}
