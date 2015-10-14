
namespace Networks.Tests
{
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Test;
    using Networks.Tests.Helpers;
    using ResourceGroups.Tests;
    using Xunit;
    using Microsoft.Azure.Management.Network;

    public class ExpressRouteServiceProviderTests
    {
        [Fact]
        public void ExpressRouteServiceProviderTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var listServiceProviders = networkResourceProviderClient.ExpressRouteServiceProviders.List();

                // Verify properties
                Assert.Equal(HttpStatusCode.OK, listServiceProviders.StatusCode);

                Assert.True(listServiceProviders.ExpressRouteServiceProviders.Any());
                Assert.True(listServiceProviders.ExpressRouteServiceProviders[0].PeeringLocations.Any());
                Assert.True(listServiceProviders.ExpressRouteServiceProviders[0].BandwidthsOffered.Any());
                Assert.NotNull(listServiceProviders.ExpressRouteServiceProviders[0].Name);
            }
        }
    }
}