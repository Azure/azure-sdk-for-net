namespace Microsoft.WindowsAzure.Management.ExpressRoute.Testing
{
    using System;
    using System.Linq;
    using System.Net;
    using Azure.Management.ExpressRoute.Testing;
    using Azure.Test;
    using ExpressRoute;
    using ExpressRoute.Models;
    using Hyak.Common;
    using Management;
    using Xunit;

    public class DedicatedCircuitPeeringStatsOperationTests : ExpressRouteTestBase
    {
        [Fact]
        public void CanGetCircuitStats()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider =
                    expressRouteClient.DedicatedCircuitServiceProviders.List()
                        .Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newCircuitParams = new DedicatedCircuitNewParameters()
                                           {
                                               Bandwidth = bandwidth,
                                               CircuitName = circuitName,
                                               Location = location,
                                               ServiceProviderName = provider.Name
                                           };
                var newResponse = expressRouteClient.DedicatedCircuits.New(newCircuitParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                Guid serviceKey;
                Assert.True(Guid.TryParse(newResponse.Data, out serviceKey));

                ulong stats = (ulong)0;


                var getCircuitStatsResponse = expressRouteClient.DedicatedCircuitStats.Get(serviceKey.ToString());
                TestUtilities.ValidateOperationResponse(getCircuitStatsResponse);
                Assert.NotNull(getCircuitStatsResponse.DedicatedCircuitStats);
                Assert.Equal(stats, getCircuitStatsResponse.DedicatedCircuitStats.PrimaryBytesIn);
                Assert.Equal(stats, getCircuitStatsResponse.DedicatedCircuitStats.PrimaryBytesOut);
                Assert.Equal(stats, getCircuitStatsResponse.DedicatedCircuitStats.SecondaryBytesIn);
                Assert.Equal(stats, getCircuitStatsResponse.DedicatedCircuitStats.SecondaryBytesOut);
            }
        }

        [Fact]
        public void CanNotGetPeeringStatsIfPeeringNotExist()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider = expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newCircuitParams = new DedicatedCircuitNewParameters()
                {
                    Bandwidth = bandwidth,
                    CircuitName = circuitName,
                    Location = location,
                    ServiceProviderName = provider.Name
                };
                var newResponse = expressRouteClient.DedicatedCircuits.New(newCircuitParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                Guid serviceKey;
                Assert.True(Guid.TryParse(newResponse.Data, out serviceKey));

                DedicatedCircuitPeeringStatsGetResponse response;
                string expectedException = "Can not find any subinterface for peering type 'Private' for circuit '" + serviceKey + "'";
                var exception = Assert.Throws<CloudException>(() => response = expressRouteClient.DedicatedCircuitPeeringStats.Get(serviceKey.ToString(), BgpPeeringAccessType.Private));
                Assert.True(exception.Error.Message.Contains(expectedException));

                DedicatedCircuitPeeringArpInfoGetResponse arpResponse;
                exception = Assert.Throws<CloudException>(() => arpResponse = expressRouteClient.DedicatedCircuitPeeringArpInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary));

                DedicatedCircuitPeeringRouteTableInfoGetResponse routeTableInfoGetResponse;
                exception = Assert.Throws<CloudException>(() => routeTableInfoGetResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary));

                DedicatedCircuitPeeringRouteTableSummaryGetResponse routeTableSummaryGetResponse;
                exception = Assert.Throws<CloudException>(() => routeTableSummaryGetResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableSummary.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary));

                

            }
        }
    }
}