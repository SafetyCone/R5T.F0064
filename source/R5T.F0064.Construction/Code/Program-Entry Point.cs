using System;
using System.Threading.Tasks;

using R5T.F0037;


namespace R5T.F0064.Construction
{
    partial class Program : IAsynchronousProgram
    {
        static async Task Main()
        {
            await F0037.Instances.Program
                .ConfigureServices(servicesBuilder =>
                {
                    return servicesBuilder.UseServicesConfigurer<ServicesConfigurer>();
                })
                .AuditServicesToTextFile(
                    @"C:\Temp\Services.txt")
                .AuditServicesToJsonFile(
                    @"C:\Temp\Services.json")
                .Run<Program>();
        }
    }
}