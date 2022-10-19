using System;

using R5T.T0131;


namespace R5T.F0064
{
	[DraftValuesMarker]
	public partial interface IServiceLifetimeNames : IDraftValuesMarker
	{
		public string Singleton => "Singleton";
		public string Scoped => "Scoped";
		public string Transient => "Transient";
	}
}