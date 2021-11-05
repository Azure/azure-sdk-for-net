
using Microsoft.Azure.Management.Datadog.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.Datadog.Tests
{
    public class DatadogTests
    {
        [Fact]
        public void TestResourceLifeCycle()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string rgName = CreateName("datadog-sdk-test-rg");
                string resourceName = CreateName("datadog-sdk-test-resource");

                CreateResourceGroup(context, rgName);
                DatadogMonitorResource rp = CreateResource(context, rgName, resourceName);
                Assert.NotNull(rp);

                DeleteResource(context, rgName, resourceName);
                AssertNoResource(context, rgName);

                DeleteResourceGroup(context, rgName);
            }
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

        private void DeleteResourceGroup(MockContext context, string rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            client.ResourceGroups.Delete(rgName);
        }

        private DatadogMonitorResource CreateResource(MockContext context, string rgName, string resourceName)
        {
            MicrosoftDatadogClient client = GetDatadogManagementClient(context);
            return client.Monitors.Create(
                rgName,
                resourceName,
                new DatadogMonitorResource(
                    type: "Microsoft.Datadog/monitors",
                    location: "westus2",
                    sku: new ResourceSku("drawdown_testing_20200904_Monthly"),
                    identity: new IdentityProperties(type: "SystemAssigned"),
                    properties: new MonitorProperties(userInfo: new UserInfo(name: "Mama Baba", emailAddress: "liftrdevredmond@microsoft.com", phoneNumber: "+1 (425) 5381111"))
                    )
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            MicrosoftDatadogClient client = GetDatadogManagementClient(context);
            client.Monitors.Delete(rgName, resourceName);
        }

        private void AssertNoResource(MockContext context, string rgName)
        {
            IPage<DatadogMonitorResource> resources = ListResources(context, rgName);
            Assert.Null(resources.GetEnumerator().Current);
        }

        private IPage<DatadogMonitorResource> ListResources(MockContext context, string rgName)
        {
            MicrosoftDatadogClient client = GetDatadogManagementClient(context);
            return client.Monitors.List();
        }

        private string CreateName(string prefix) => TestUtilities.GenerateName(prefix);

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private MicrosoftDatadogClient GetDatadogManagementClient(MockContext context)
        {
            return context.GetServiceClient<MicrosoftDatadogClient>();
        }
    }
}
