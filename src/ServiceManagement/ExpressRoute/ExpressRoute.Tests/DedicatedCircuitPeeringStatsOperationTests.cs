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
        public void CanGetPeeringStatsIfPeeringExists()
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

                var newPrivatePeeringParams = new BorderGatewayProtocolPeeringNewParameters()
                {
                    PeerAutonomousSystemNumber = PrivatePeerAsn,
                    PrimaryPeerSubnet = PrivatePrimaryPeerSubnet,
                    SecondaryPeerSubnet = PrivateSecondaryPeerSubnet,
                    SharedKey = TestUtilities.GenerateName("SharedKey"),
                    VirtualLanId = PrivateVlanId
                };
                newResponse = expressRouteClient.BorderGatewayProtocolPeerings.New(serviceKey.ToString(),
                                                                                   BgpPeeringAccessType.Private,
                                                                                   newPrivatePeeringParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                var getResponse = expressRouteClient.BorderGatewayProtocolPeerings.Get(serviceKey.ToString(), BgpPeeringAccessType.Private);
                TestUtilities.ValidateOperationResponse(getResponse);
                Assert.Equal(getResponse.BgpPeering.PeerAsn, newPrivatePeeringParams.PeerAutonomousSystemNumber);
                Assert.Equal(getResponse.BgpPeering.PrimaryPeerSubnet, newPrivatePeeringParams.PrimaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.SecondaryPeerSubnet, newPrivatePeeringParams.SecondaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.VlanId, newPrivatePeeringParams.VirtualLanId);
                Assert.Equal(getResponse.BgpPeering.State, BgpPeeringState.Enabled);

                // TODO: need to debug this call to check response
                var getArpInfoResponse = expressRouteClient.DedicatedCircuitPeeringArpInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary);
                TestUtilities.ValidateOperationResponse(getArpInfoResponse);
                Assert.NotNull(getArpInfoResponse.DedicatedCircuitPeeringArpInfo);           

                var getRouteTableInfoResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Secondary);
                TestUtilities.ValidateOperationResponse(getRouteTableInfoResponse);
                Assert.NotNull(getRouteTableInfoResponse.DedicatedCircuitPeeringRouteTableInfo);

                var getRouteTableSummaryResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableSummary.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary);
                TestUtilities.ValidateOperationResponse(getRouteTableSummaryResponse);
                Assert.NotNull(getRouteTableSummaryResponse.DedicatedCircuitPeeringRouteTableSummary);

                var getPeeringStatsResponse = expressRouteClient.DedicatedCircuitPeeringStats.Get(serviceKey.ToString(), BgpPeeringAccessType.Private);
                TestUtilities.ValidateOperationResponse(getPeeringStatsResponse);
                Assert.NotNull(getPeeringStatsResponse.DedicatedCircuitPeeringStats);

                var getCircuitStatsResponse = expressRouteClient.DedicatedCircuitStats.Get(serviceKey.ToString());
                TestUtilities.ValidateOperationResponse(getCircuitStatsResponse);
                Assert.NotNull(getCircuitStatsResponse.DedicatedCircuitStats);

            }
        }

        [Fact]
        public void CanGetPeeringStatsIfPeeringNotExists()
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

                var newPrivatePeeringParams = new BorderGatewayProtocolPeeringNewParameters()
                {
                    PeerAutonomousSystemNumber = PrivatePeerAsn,
                    PrimaryPeerSubnet = PrivatePrimaryPeerSubnet,
                    SecondaryPeerSubnet = PrivateSecondaryPeerSubnet,
                    SharedKey = TestUtilities.GenerateName("SharedKey"),
                    VirtualLanId = PrivateVlanId
                };
                newResponse = expressRouteClient.BorderGatewayProtocolPeerings.New(serviceKey.ToString(),
                                                                                   BgpPeeringAccessType.Private,
                                                                                   newPrivatePeeringParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                var getResponse = expressRouteClient.BorderGatewayProtocolPeerings.Get(serviceKey.ToString(), BgpPeeringAccessType.Private);
                TestUtilities.ValidateOperationResponse(getResponse);
                Assert.Equal(getResponse.BgpPeering.PeerAsn, newPrivatePeeringParams.PeerAutonomousSystemNumber);
                Assert.Equal(getResponse.BgpPeering.PrimaryPeerSubnet, newPrivatePeeringParams.PrimaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.SecondaryPeerSubnet, newPrivatePeeringParams.SecondaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.VlanId, newPrivatePeeringParams.VirtualLanId);
                Assert.Equal(getResponse.BgpPeering.State, BgpPeeringState.Enabled);


                // TODO: need to debug this call to check response
                var getArpInfoResponse = expressRouteClient.DedicatedCircuitPeeringArpInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary);
                TestUtilities.ValidateOperationResponse(getArpInfoResponse);

                var getRouteTableInfoResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableInfo.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Secondary);
                TestUtilities.ValidateOperationResponse(getRouteTableInfoResponse);

                var getRouteTableSummaryResponse = expressRouteClient.DedicatedCircuitPeeringRouteTableSummary.Get(serviceKey.ToString(), BgpPeeringAccessType.Private, DevicePath.Primary);
                TestUtilities.ValidateOperationResponse(getRouteTableSummaryResponse);

                var getPeeringStatsResponse = expressRouteClient.DedicatedCircuitPeeringStats.Get(serviceKey.ToString(), BgpPeeringAccessType.Private);
                TestUtilities.ValidateOperationResponse(getPeeringStatsResponse);

                var getCircuitStatsResponse = expressRouteClient.DedicatedCircuitStats.Get(serviceKey.ToString());
                TestUtilities.ValidateOperationResponse(getCircuitStatsResponse);

            }
        }
    }
}