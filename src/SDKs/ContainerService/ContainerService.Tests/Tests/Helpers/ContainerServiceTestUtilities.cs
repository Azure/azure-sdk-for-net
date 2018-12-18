using ContainerService.Tests;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.ContainerService.Tests
{
    public class ContainerServiceTestUtilities
    {

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        internal static ContainerServiceClient GetContainerServiceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ContainerServiceClient>(handlers: handler);
            return client;
        }

        public static ResourceGroup CreateResourceGroup(ResourceManagementClient client)
        {
            var resourceGroupName = TestUtilities.GenerateName("aks_rg");

            return client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup
            {
                Location = "westus"
            });
        }
    }
}
