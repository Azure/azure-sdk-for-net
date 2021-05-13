
using Microsoft.Azure.Management.AgFoodPlatform.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Management.AgFoodPlatform.Tests
{
    public class AgFoodPlatformTests
    {
        [Fact]
        public void TestResourceLifeCycle()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string rgName = CreateName("agfood-sdk-test-rg");
                string resourceName = CreateName("agfood-sdk-test-resource");

                CreateResourceGroup(context, rgName);
                FarmBeats rp = CreateResource(context, rgName, resourceName);
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

        private FarmBeats CreateResource(MockContext context, string rgName, string resourceName)
        {
            AzureAgFoodPlatformRPService client = GetAgFoodPlatformManagementClient(context);
            return client.FarmBeatsModels.CreateOrUpdate(
                rgName,
                resourceName,
                new FarmBeats(
                    "westus2",
                    tags: new Dictionary<string, string>() { { "first", "second" } })
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            AzureAgFoodPlatformRPService client = GetAgFoodPlatformManagementClient(context);
            client.FarmBeatsModels.Delete(rgName, resourceName);
        }

        private void AssertNoResource(MockContext context, string rgName)
        {
            FarmBeatsListResponse resources = ListResources(context, rgName);
            Assert.Null(resources.Value);
        }

        private FarmBeatsListResponse ListResources(MockContext context, string rgName)
        {
            AzureAgFoodPlatformRPService client = GetAgFoodPlatformManagementClient(context);
            return client.FarmBeatsModels.ListByResourceGroup(rgName);
        }

        private string CreateName(string prefix) => TestUtilities.GenerateName(prefix);

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private AzureAgFoodPlatformRPService GetAgFoodPlatformManagementClient(MockContext context)
        {
            return context.GetServiceClient<AzureAgFoodPlatformRPService>();
        }
    }
}
