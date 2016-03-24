using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using RemoteApp.Tests;

namespace Microsoft.Azure.Management.RemoteApp.Tests
{
    public class RemoteAppTestBase
    {
        protected RemoteAppManagementClient GetClient(MockContext context, RemoteAppDelegatingHandler handler)
        {
            RemoteAppManagementClient client = context.GetServiceClient<RemoteAppManagementClient>(true, handler);

            return client;
        }
    }
}
