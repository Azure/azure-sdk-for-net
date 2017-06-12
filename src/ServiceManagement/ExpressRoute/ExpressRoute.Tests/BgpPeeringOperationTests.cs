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

    public class BgpPeeringTests : ExpressRouteTestBase
    {
        [Fact]
        public void CanCreateGetUpdateAndRemovePrivateAndPublicPeerings()
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
                var newPublicPeeringParams = new BorderGatewayProtocolPeeringNewParameters()
                {
                    PeerAutonomousSystemNumber = PublicPeerAsn,
                    PrimaryPeerSubnet = PublicPrimaryPeerSubnet,
                    SecondaryPeerSubnet = PublicSecondaryPeerSubnet,
                    SharedKey = TestUtilities.GenerateName("SharedKey"),
                    VirtualLanId = PublicVlanId
                };
                newResponse = expressRouteClient.BorderGatewayProtocolPeerings.New(serviceKey.ToString(),
                                                                                   BgpPeeringAccessType.Public,
                                                                                   newPublicPeeringParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                getResponse = expressRouteClient.BorderGatewayProtocolPeerings.Get(serviceKey.ToString(), BgpPeeringAccessType.Public);
                TestUtilities.ValidateOperationResponse(getResponse);
                Assert.Equal(getResponse.BgpPeering.PeerAsn, newPublicPeeringParams.PeerAutonomousSystemNumber);
                Assert.Equal(getResponse.BgpPeering.PrimaryPeerSubnet, newPublicPeeringParams.PrimaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.SecondaryPeerSubnet, newPublicPeeringParams.SecondaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.VlanId, newPublicPeeringParams.VirtualLanId);
                Assert.Equal(getResponse.BgpPeering.State, BgpPeeringState.Enabled);

                BorderGatewayProtocolPeeringUpdateParameters updatePrivatePeeringParams = new BorderGatewayProtocolPeeringUpdateParameters
                    ()
                    {
                        PeerAutonomousSystemNumber = UpdatePrivatePeerAsn,
                        PrimaryPeerSubnet = UpdatePrivatePrimaryPeerSubnet,
                        SecondaryPeerSubnet = UpdatePrivateSecondaryPeerSubnet,
                        SharedKey = TestUtilities.GenerateName("SharedKey"),
                        VirtualLanId = UpdatePrivateVlanId
                    };

                var updateResponse = expressRouteClient.BorderGatewayProtocolPeerings.Update(serviceKey.ToString(),
                                                                                             BgpPeeringAccessType
                                                                                                 .Private,
                                                                                             updatePrivatePeeringParams);
                TestUtilities.ValidateOperationResponse(updateResponse);
                getResponse = expressRouteClient.BorderGatewayProtocolPeerings.Get(serviceKey.ToString(), BgpPeeringAccessType.Private);
                TestUtilities.ValidateOperationResponse(getResponse);
                Assert.Equal(getResponse.BgpPeering.PeerAsn, updatePrivatePeeringParams.PeerAutonomousSystemNumber);
                Assert.Equal(getResponse.BgpPeering.PrimaryPeerSubnet, updatePrivatePeeringParams.PrimaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.SecondaryPeerSubnet, updatePrivatePeeringParams.SecondaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.VlanId, updatePrivatePeeringParams.VirtualLanId);
                Assert.Equal(getResponse.BgpPeering.State, BgpPeeringState.Enabled);

                BorderGatewayProtocolPeeringUpdateParameters updatePublicPeeringParams = new BorderGatewayProtocolPeeringUpdateParameters
                    ()
                    {
                        PeerAutonomousSystemNumber = UpdatePublicPeerAsn,
                        PrimaryPeerSubnet = UpdatePublicPrimaryPeerSubnet,
                        SecondaryPeerSubnet = UpdatePublicSecondaryPeerSubnet,
                        SharedKey = TestUtilities.GenerateName("SharedKey"),
                        VirtualLanId = UpdatePublicVlanId
                    };

                updateResponse = expressRouteClient.BorderGatewayProtocolPeerings.Update(serviceKey.ToString(),
                                                                                             BgpPeeringAccessType
                                                                                                 .Public,
                                                                                             updatePublicPeeringParams);
                TestUtilities.ValidateOperationResponse(updateResponse);
                getResponse = expressRouteClient.BorderGatewayProtocolPeerings.Get(serviceKey.ToString(), BgpPeeringAccessType.Public);
                TestUtilities.ValidateOperationResponse(getResponse);
                Assert.Equal(getResponse.BgpPeering.PeerAsn, updatePublicPeeringParams.PeerAutonomousSystemNumber);
                Assert.Equal(getResponse.BgpPeering.PrimaryPeerSubnet, updatePublicPeeringParams.PrimaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.SecondaryPeerSubnet, updatePublicPeeringParams.SecondaryPeerSubnet);
                Assert.Equal(getResponse.BgpPeering.VlanId, updatePublicPeeringParams.VirtualLanId);
                Assert.Equal(getResponse.BgpPeering.State, BgpPeeringState.Enabled);

                var removeResponse = expressRouteClient.BorderGatewayProtocolPeerings.Remove(serviceKey.ToString(),
                                                                                             BgpPeeringAccessType
                                                                                                 .Private);
                TestUtilities.ValidateOperationResponse(removeResponse);
                removeResponse = expressRouteClient.BorderGatewayProtocolPeerings.Remove(serviceKey.ToString(),
                                                                                         BgpPeeringAccessType.Public);
                TestUtilities.ValidateOperationResponse(removeResponse);
            }
        }

        [Fact]
        public void CreateFailsIfDuplicateVlanIdUsedOrIfPeeringAlreadyExists()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider =
                    expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
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

                var randomGen = new Random();
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

                newPrivatePeeringParams.PeerAutonomousSystemNumber = PublicPeerAsn;
                newPrivatePeeringParams.PrimaryPeerSubnet = PublicPrimaryPeerSubnet;
                newPrivatePeeringParams.SecondaryPeerSubnet = PublicSecondaryPeerSubnet;
                newPrivatePeeringParams.SharedKey = TestUtilities.GenerateName("SharedKey");
                var exception = Assert.Throws<CloudException>(() => newResponse = expressRouteClient.BorderGatewayProtocolPeerings.New(serviceKey.ToString(),BgpPeeringAccessType.Public, newPrivatePeeringParams));
                Assert.Equal(exception.Error.Code,"ConflictError");
                Assert.True(exception.Error.Message.Contains("The vlanId specified is already in use"));

                newPrivatePeeringParams.VirtualLanId = PublicVlanId;
                exception = Assert.Throws<CloudException>(()
                                                          =>
                                                          newResponse =
                                                          expressRouteClient.BorderGatewayProtocolPeerings.New(
                                                              serviceKey.ToString(), BgpPeeringAccessType.Private,
                                                              newPrivatePeeringParams));
                Assert.Equal(exception.Error.Code, "ConflictError");
                Assert.True(exception.Error.Message.Contains("BGP peering could not be created as it already exists"));
            }
        }

        [Fact]
        public void CreateFailsIfInvalidPrimaryOrSecondaryPeerSubnetUsed()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider =
                    expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
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

                var randomGen = new Random();
                var newPrivatePeeringParams = new BorderGatewayProtocolPeeringNewParameters()
                    {
                        PeerAutonomousSystemNumber = PrivatePeerAsn,
                        PrimaryPeerSubnet = InvalidSubnet,
                        SecondaryPeerSubnet = PrivateSecondaryPeerSubnet,
                        SharedKey = TestUtilities.GenerateName("SharedKey"),
                        VirtualLanId = PrivateVlanId
                    };
                var exception = Assert.Throws<CloudException>(() => newResponse = expressRouteClient.BorderGatewayProtocolPeerings.New(serviceKey.ToString(),
                                                                                   BgpPeeringAccessType.Private,
                                                                                   newPrivatePeeringParams));
                Assert.Equal(exception.Error.Code, "BadRequest");
                Assert.True(exception.Message.Contains(newPrivatePeeringParams.PrimaryPeerSubnet) && exception.Message.Contains("is not valid"));

                newPrivatePeeringParams.PrimaryPeerSubnet = PrivatePrimaryPeerSubnet;
                newPrivatePeeringParams.SecondaryPeerSubnet = InvalidSubnet;
                exception = Assert.Throws<CloudException>(() => newResponse = expressRouteClient.BorderGatewayProtocolPeerings.New(serviceKey.ToString(),
                                                                                   BgpPeeringAccessType.Private,
                                                                                   newPrivatePeeringParams));
                Assert.Equal(exception.Error.Code, "BadRequest");
                Assert.True(exception.Message.Contains(newPrivatePeeringParams.SecondaryPeerSubnet) && exception.Message.Contains("is not valid"));
            }
        }
    }
}
