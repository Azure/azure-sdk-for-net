using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Elastic;
using Microsoft.Azure.Management.Elastic.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.Elastic.Tests.Tests
{
    public class ElasticTest
    {

        [Fact]
        public void TestResourceLifeCycle()
        {

            using (var context = MockContext.Start(GetType()))
            {
                string rgName = CreateName("elastic-sdk-test-rg");
                string resourceName = CreateName("elastic-sdk-test-resource");

                CreateResourceGroup(context, rgName);
                ElasticMonitorResource rp = CreateResource(context, rgName, resourceName);
                Assert.NotNull(rp);

                DeleteResource(context, rgName, resourceName);
                DeleteResourceGroup(context, rgName);
            }
        }

        private ElasticMonitorResource CreateResource(MockContext context, string rgName, string resourceName)
        {
            MicrosoftElasticClient client = GetMicrosoftElasticClient(context);
            return client.Monitors.Create(
                rgName,
                resourceName,
                new ElasticMonitorResource(
                    name: resourceName,
                    type: "Microsoft.Elastic/monitors",
                    location: "westus2",
                    properties: new MonitorProperties(userInfo: new UserInfo(firstName:"varun",lastName:"kunchakuri",emailAddress: "liftrelasticdev@microsoft.com"))
                    )
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            MicrosoftElasticClient client = GetMicrosoftElasticClient(context);
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

        private MicrosoftElasticClient GetMicrosoftElasticClient(MockContext context)
        {
            return context.GetServiceClient<MicrosoftElasticClient>();
        }

    }
}
