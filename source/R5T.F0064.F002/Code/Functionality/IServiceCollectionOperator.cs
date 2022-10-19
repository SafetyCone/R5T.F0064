using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0064.F002
{
	[FunctionalityMarker]
	public partial interface IServiceCollectionOperator : IFunctionalityMarker,
		F0064.IServiceCollectionOperator
	{
        public void DescribeServices(
            IServiceCollection services,
            Action<IEnumerable<ServiceDescriptorInformation>> serviceDescriptorInformationSetAction)
        {
            void Internal(Dictionary<string, List<ServiceDescriptor>> servicesByServiceNameOrderedByServiceName)
            {
                var serviceDescriptorInformationSet = servicesByServiceNameOrderedByServiceName
                        .SelectMany(xPair => xPair.Value)
                        .Select(xServiceDescriptor => Instances.ServiceDescriptorOperator.GetInformation(xServiceDescriptor))
                        ;

                serviceDescriptorInformationSetAction(serviceDescriptorInformationSet);
            }

            this.DescribeServices(
                services,
                Internal);
        }

        public void DescribeToJsonFile_Synchronous(
            string jsonFilePath,
            IServiceCollection services)
        {
            void Internal(IEnumerable<ServiceDescriptorInformation> serviceDescriptorInformationSet)
            {
                Instances.JsonOperator.Serialize_Synchronous(
                    jsonFilePath,
                    serviceDescriptorInformationSet);
            }

            this.DescribeServices(
                services,
                Internal);
        }
    }
}