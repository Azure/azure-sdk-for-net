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
       [Fact(Skip = "TODO: we have a prod bug which will cause this fail, will re-record after fix that")]
        public void CanNotGetStats()
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

                DedicatedCircuitStatsGetResponse response;
                string expectedException = "Can not find any subinterface for peering type 'Private' for circuit '" + serviceKey + "'";
                var exception = Assert.Throws<CloudException>(() => response = expressRouteClient.DedicatedCircuitStats.Get(serviceKey.ToString(), BgpPeeringAccessType.Private));
                Assert.True(exception.Error.Message.Contains(expectedException));

                ExpressRouteOperationStatusResponse statusResponse;
                exception = Assert.Throws<CloudException>(() => statusResponse = expressRouteClient.DedicatedCircuitPeeringArpInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary));              
                exception = Assert.Throws<CloudException>(() => statusResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary));
                exception = Assert.Throws<CloudException>(() => statusResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableSummary.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary));

                

            }
        }
    }
}