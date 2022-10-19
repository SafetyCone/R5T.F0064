using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0132;


namespace R5T.F0064
{
	[FunctionalityMarker]
	public partial interface IServiceCollectionOperator : IFunctionalityMarker
	{
        public void DescribeToTextFile_Synchronous(
            string textFilePath,
            IServiceCollection services)
        {
            var stringBuilder = new StringBuilder();

            this.DescribeToStringBuilder(
                stringBuilder,
                services);

            var text = stringBuilder.ToString();

            using var fileWriter = F0000.StreamWriterOperator.Instance.NewWrite(textFilePath);

            fileWriter.WriteLine(text);
        }

        public async Task DescribeToTextFile(
            string textFilePath,
            IServiceCollection services)
        {
            var stringBuilder = new StringBuilder();

            this.DescribeToStringBuilder(
                stringBuilder,
                services);

            var text = stringBuilder.ToString();

            using var fileWriter = F0000.StreamWriterOperator.Instance.NewWrite(textFilePath);

            await fileWriter.WriteAsync(text);
            await fileWriter.FlushAsync();
        }

        public void DescribeServices(
            IServiceCollection services,
            Action<Dictionary<string, List<ServiceDescriptor>>> servicesByServiceNameOrderedByServiceNameAction)
        {
            // Get all service descriptors, grouped by service definition namespaced type name, in the order in which they appear in the service collection.
            // The order is essential, since if there are multiple service implementation types for a service definition type, when the service definition is requested only the last service implementatin will be provided.
            var servicesByServiceName = services.GetServicesByServiceNamePreservingImplementationTypeOrder();

            // Order the service descriptor sets by the type name (not namespaced type name) of their service definitions.
            var servicesByServiceNameOrderedByServiceName = servicesByServiceName
                .OrderAlphabetically(xPair => F0000.NamespacedTypeNameOperator.Instance.GetTypeName(xPair.Key))
                .ToDictionary(
                    xPair => xPair.Key,
                    xPair => xPair.Value);

            servicesByServiceNameOrderedByServiceNameAction(servicesByServiceNameOrderedByServiceName);
        }

        public void DescribeToStringBuilder(
            StringBuilder stringBuilder,
            IServiceCollection services)
        {
            void Internal(Dictionary<string, List<ServiceDescriptor>> servicesByServiceNameOrderedByServiceName)
            {
                var serviceCount = services.Count;

                stringBuilder.AppendLine($"Services count: {serviceCount}\nNote: services with '{Z0000.Strings.Instance.Asterix}' are the last implementation type for services with multiple implementation types.\n\n");

                foreach (var pair in servicesByServiceNameOrderedByServiceName)
                {
                    var implementationsForService = pair.Value;

                    var implementationCount = implementationsForService.Count;
                    if (implementationCount > 1)
                    {
                        var currentImplementationCounter = 1;

                        foreach (var serviceDescriptor in implementationsForService)
                        {
                            // If there are multiple service implementations for a service definition, the last implementation will be provided for a request of the service definition.
                            if (currentImplementationCounter == implementationCount)
                            {
                                var description = Instances.ServiceDescriptorOperator.Describe(serviceDescriptor, true);

                                stringBuilder.AppendLine(description);
                            }
                            else
                            {
                                var description = Instances.ServiceDescriptorOperator.Describe(serviceDescriptor, false);

                                stringBuilder.AppendLine(description);

                                currentImplementationCounter++;
                            }
                        }
                    }
                    else
                    {
                        // Only one implementation for the service.
                        var serviceDescriptor = implementationsForService.Single();

                        var description = Instances.ServiceDescriptorOperator.Describe(serviceDescriptor, false);

                        stringBuilder.AppendLine(description);
                    }
                }
            }

            this.DescribeServices(
                services,
                Internal);
        }

        public IEnumerable<ServiceDescriptorDescription> GetDescriptions(
            IServiceCollection services)
        {
            var output = services.Select(xService => xService.ToServiceDescriptorDescription());
            return output;
        }
    }
}