using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Dynatrace;
using Microsoft.Azure.Management.Dynatrace.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.Dynatrace.Tests.Tests
{
    public class DynatraceTest
    {

        [Fact]
        public void TestResourceLifeCycle()
        {

            using (var context = MockContext.Start(GetType()))
            {
                string rgName = CreateName("dynatrace-sdk-test-rg");
                string resourceName = CreateName("dynatrace-sdk-test-resource");

                CreateResourceGroup(context, rgName);
                MonitorResource rp = CreateResource(context, rgName, resourceName);
                Assert.NotNull(rp);

                DeleteResource(context, rgName, resourceName);
                DeleteResourceGroup(context, rgName);
            }
        }

        private MonitorResource CreateResource(MockContext context, string rgName, string resourceName)
        {
            DynatraceObservabilityClient client = GetDynatraceObservabilityClient(context);
            return client.Monitors.Create(
                rgName,
                resourceName,
                new MonitorResource(
                    name: resourceName,
                    type: "Dynatrace.Observability/monitors",
                    location: "eastus"
                    )
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            DynatraceObservabilityClient client = GetDynatraceObservabilityClient(context);
            client.Monitors.Delete(rgName, resourceName);
        }


        private ResourceGroup CreateResourceGroup(MockContext context, string rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            return client.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = "westus2"
                });
        }

        private string CreateName(string prefix) => TestUtilities.GenerateName(prefix);

        private void DeleteResourceGroup(MockContext context, string rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            client.ResourceGroups.Delete(rgName);
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private DynatraceObservabilityClient GetDynatraceObservabilityClient(MockContext context)
        {
            return context.GetServiceClient<DynatraceObservabilityClient>();
        }

    }
}
