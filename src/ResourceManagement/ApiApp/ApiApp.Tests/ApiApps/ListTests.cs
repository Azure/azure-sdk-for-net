using System.Net;
using Microsoft.Azure.Management.ApiApps.Tests.TestSupport;
using Xunit;

namespace Microsoft.Azure.Management.ApiApps.Tests.ApiApps
{
    public class ListTests : ApiAppTestBase
    {
        [Fact]
        public void CanListApiAppsInSubscription()
        {
            UndoCtx.Start();
            using (var client = GetArmClient<ApiAppManagementClient>())
            {
                var response = client.ApiApps.ListAll();
                // Can't assert any more really in this test until we get deployment
                // working so we know what to look for. Results depend on what's
                // currently deployed in the subscription.
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
