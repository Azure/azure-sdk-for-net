using Microsoft.Azure.Management.Logz.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.Logz.Tests.Tests
{
    public class LogzTest
    {

        [Fact]
        public void TestResourceLifeCycle()
        {

            using (var context = MockContext.Start(GetType()))
            {
                string rgName = CreateName("logz-sdk-test-rg");
                string resourceName = CreateName("logz-sdk-test-resource");

                CreateResourceGroup(context, rgName);
                LogzMonitorResource rp = CreateResource(context, rgName, resourceName);
                Assert.NotNull(rp);

                DeleteResource(context, rgName, resourceName);
                DeleteResourceGroup(context, rgName);
            }
        }

        private LogzMonitorResource CreateResource(MockContext context, string rgName, string resourceName)
        {
            MicrosoftLogzClient client = GetMicrosoftLogzClient(context);
            return client.Monitors.Create(
                rgName,
                resourceName,
                new LogzMonitorResource(
                    name: resourceName,
                    type: "Microsoft.Logz/monitors",
                    location: "westus2",
                    properties: new MonitorProperties(userInfo: new UserInfo(firstName: "varun", lastName: "kunchakuri", emailAddress: "liftrlogzdev@microsoft.com"))
                    )
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            MicrosoftLogzClient client = GetMicrosoftLogzClient(context);
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

        private MicrosoftLogzClient GetMicrosoftLogzClient(MockContext context)
        {
            return context.GetServiceClient<MicrosoftLogzClient>();
        }

    }
}
