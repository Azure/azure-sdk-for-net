using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.RecoveryServices.Tests
{
    public static class ClientManagementUtilities
    {
        public static RecoveryServicesClient GetManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<RecoveryServicesClient>();
        }

        public static ResourceManagementClient GetResourcesClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }
    }
}
