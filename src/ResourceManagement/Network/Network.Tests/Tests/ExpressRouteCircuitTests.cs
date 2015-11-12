using System.Net;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Networks.Tests
{
    using System.Collections.Generic;

    using Microsoft.Azure.Management.Network;

    public class ExpressRouteCircuitTests
    {
        [Fact]
        public void ExpressRouteCircuitApiTest()
        {
             var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/expressRouteCircuits");

                var location = "brazilsouth";

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string circuitName = TestUtilities.GenerateName();

                var circuit = new ExpressRouteCircuit()
                                  {
                                      Location = location,
                                      Sku =
                                          new ExpressRouteCircuitSku()
                                              {
                                                  Name = "Standard_MeteredData",
                                                  Tier = ExpressRouteCircuitSkuTier.Standard,
                                                  Family = ExpressRouteCircuitSkuFamily.MeteredData
                                              },
                                      BillingType = ExpressRouteCircuitBillingType.ServiceProviderType,
                                      ServiceProviderProperties = 
                                          new ExpressRouteCircuitServiceProviderProperties()
                                              {
                                                  ServiceProviderName = "Equinix",
                                                  PeeringLocation = "Silicon Valley",
                                                  BandwidthInMbps = 1000
                                              }
                                  };
                // Create the circuit
                var putCircuit = networkResourceProviderClient.ExpressRouteCircuits.CreateOrUpdate(resourceGroupName, circuitName, circuit);
                Assert.Equal(HttpStatusCode.OK, putCircuit.StatusCode);

                var getCircuit = networkResourceProviderClient.ExpressRouteCircuits.Get(resourceGroupName, circuitName);

                // Verify properties
                Assert.Equal(HttpStatusCode.OK, getCircuit.StatusCode);

                Assert.NotNull(getCircuit.ExpressRouteCircuit);
                Assert.NotNull(getCircuit.ExpressRouteCircuit.Sku);
                Assert.NotNull(getCircuit.ExpressRouteCircuit.Etag);
                Assert.Equal("Standard_MeteredData", getCircuit.ExpressRouteCircuit.Sku.Name);
                Assert.Equal(ExpressRouteCircuitSkuTier.Standard, getCircuit.ExpressRouteCircuit.Sku.Tier);
                Assert.Equal(ExpressRouteCircuitSkuFamily.MeteredData, getCircuit.ExpressRouteCircuit.Sku.Family);
                //Assert.Equal(ExpressRouteCircuitBillingType.ServiceProviderType, getCircuit.ExpressRouteCircuit.BillingType);

                Assert.NotNull(getCircuit.ExpressRouteCircuit.ServiceProviderProperties);
                Assert.Equal("Equinix", getCircuit.ExpressRouteCircuit.ServiceProviderProperties.ServiceProviderName);
                Assert.Equal("Silicon Valley", getCircuit.ExpressRouteCircuit.ServiceProviderProperties.PeeringLocation);
                Assert.Equal(1000, getCircuit.ExpressRouteCircuit.ServiceProviderProperties.BandwidthInMbps);

                // Verify List
                var listCircuit = networkResourceProviderClient.ExpressRouteCircuits.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listCircuit.StatusCode);
                Assert.NotNull(listCircuit.ExpressRouteCircuits);
                Assert.Equal(1, listCircuit.ExpressRouteCircuits.Count);
                Assert.Equal(listCircuit.ExpressRouteCircuits[0].Etag, getCircuit.ExpressRouteCircuit.Etag);
                Assert.Equal(listCircuit.ExpressRouteCircuits[0].Sku.Name, getCircuit.ExpressRouteCircuit.Sku.Name);
                Assert.Equal(listCircuit.ExpressRouteCircuits[0].Sku.Tier, getCircuit.ExpressRouteCircuit.Sku.Tier);
                Assert.Equal(listCircuit.ExpressRouteCircuits[0].Sku.Family, getCircuit.ExpressRouteCircuit.Sku.Family);

                Assert.NotNull(getCircuit.ExpressRouteCircuit.ServiceProviderProperties);
                Assert.Equal(listCircuit.ExpressRouteCircuits[0].ServiceProviderProperties.ServiceProviderName, getCircuit.ExpressRouteCircuit.ServiceProviderProperties.ServiceProviderName);
                Assert.Equal(listCircuit.ExpressRouteCircuits[0].ServiceProviderProperties.PeeringLocation, getCircuit.ExpressRouteCircuit.ServiceProviderProperties.PeeringLocation);
                Assert.Equal(listCircuit.ExpressRouteCircuits[0].ServiceProviderProperties.BandwidthInMbps, getCircuit.ExpressRouteCircuit.ServiceProviderProperties.BandwidthInMbps);

                // Verify Delete
                var deleteCircuit = networkResourceProviderClient.ExpressRouteCircuits.Delete(resourceGroupName, circuitName);
                Assert.Equal(HttpStatusCode.OK, deleteCircuit.StatusCode);

                listCircuit = networkResourceProviderClient.ExpressRouteCircuits.List(resourceGroupName);
                Assert.Equal(0, listCircuit.ExpressRouteCircuits.Count);
            }
        }
    
        [Fact]
        public void ExpressRouteCircuitWithPeeringApiTest()
        {
             var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/expressRouteCircuits");

                var location = "brazilsouth";

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string circuitName = TestUtilities.GenerateName();

                var circuit = new ExpressRouteCircuit()
                                  {
                                      Location = location,
                                      Sku =
                                          new ExpressRouteCircuitSku()
                                              {
                                                  Name = "Standard_MeteredData",
                                                  Tier = ExpressRouteCircuitSkuTier.Standard,
                                                  Family = ExpressRouteCircuitSkuFamily.MeteredData
                                              },
                                      BillingType = ExpressRouteCircuitBillingType.ServiceProviderType,
                                      ServiceProviderProperties = 
                                          new ExpressRouteCircuitServiceProviderProperties()
                                              {
                                                  ServiceProviderName = "Equinix",
                                                  PeeringLocation = "Silicon Valley",
                                                  BandwidthInMbps = 1000
                                              },
                                        Peerings = new List<ExpressRouteCircuitPeering>()
                                                       {
                                                           new ExpressRouteCircuitPeering()
                                                               {
                                                                   Name = "AzurePrivatePeering",
                                                                   PeeringType = ExpressRouteCircuitPeeringType.AzurePrivatePeering,
                                                                   PeerASN = 100,
                                                                   PrimaryPeerAddressPrefix = "192.168.1.0/30",
                                                                   SecondaryPeerAddressPrefix = "192.168.2.0/30",
                                                                   VlanId = 200
                                                               }
                                                       }

                                  };
                
                // Create the circuit
                var putCircuit = networkResourceProviderClient.ExpressRouteCircuits.CreateOrUpdate(resourceGroupName, circuitName, circuit);
                Assert.Equal(HttpStatusCode.OK, putCircuit.StatusCode);

                var getCircuit = networkResourceProviderClient.ExpressRouteCircuits.Get(resourceGroupName, circuitName);

                // Verify properties
                Assert.Equal(HttpStatusCode.OK, getCircuit.StatusCode);

                Assert.NotNull(getCircuit.ExpressRouteCircuit);
                Assert.NotNull(getCircuit.ExpressRouteCircuit.Sku);
                Assert.Equal("Standard_MeteredData", getCircuit.ExpressRouteCircuit.Sku.Name);
                Assert.Equal(ExpressRouteCircuitSkuTier.Standard, getCircuit.ExpressRouteCircuit.Sku.Tier);
                Assert.Equal(ExpressRouteCircuitSkuFamily.MeteredData, getCircuit.ExpressRouteCircuit.Sku.Family);

                Assert.NotNull(getCircuit.ExpressRouteCircuit.ServiceProviderProperties);
                Assert.Equal("Equinix", getCircuit.ExpressRouteCircuit.ServiceProviderProperties.ServiceProviderName);
                Assert.Equal("Silicon Valley", getCircuit.ExpressRouteCircuit.ServiceProviderProperties.PeeringLocation);
                Assert.Equal(1000, getCircuit.ExpressRouteCircuit.ServiceProviderProperties.BandwidthInMbps);

                // Verify peering
                Assert.NotNull(getCircuit.ExpressRouteCircuit.Peerings);
                Assert.Equal(1, getCircuit.ExpressRouteCircuit.Peerings.Count);
                Assert.Equal("AzurePrivatePeering", getCircuit.ExpressRouteCircuit.Peerings[0].Name);
                Assert.Equal(ExpressRouteCircuitPeeringType.AzurePrivatePeering, getCircuit.ExpressRouteCircuit.Peerings[0].PeeringType);
                Assert.Equal(100, getCircuit.ExpressRouteCircuit.Peerings[0].PeerASN);
                Assert.Equal("192.168.1.0/30", getCircuit.ExpressRouteCircuit.Peerings[0].PrimaryPeerAddressPrefix);
                Assert.Equal("192.168.2.0/30", getCircuit.ExpressRouteCircuit.Peerings[0].SecondaryPeerAddressPrefix);
                Assert.Equal(200, getCircuit.ExpressRouteCircuit.Peerings[0].VlanId);

                // Get peering alone
                var getPeering = networkResourceProviderClient.ExpressRouteCircuitPeerings.Get(resourceGroupName, circuitName, "AzurePrivatePeering");
                Assert.Equal(HttpStatusCode.OK, getPeering.StatusCode);
                Assert.Equal("AzurePrivatePeering", getPeering.Peering.Name);
                Assert.Equal(ExpressRouteCircuitPeeringType.AzurePrivatePeering, getPeering.Peering.PeeringType);
                Assert.Equal(100, getPeering.Peering.PeerASN);
                Assert.Equal("192.168.1.0/30", getPeering.Peering.PrimaryPeerAddressPrefix);
                Assert.Equal("192.168.2.0/30", getPeering.Peering.SecondaryPeerAddressPrefix);
                Assert.Equal(200, getPeering.Peering.VlanId);
                Assert.Null(getPeering.Peering.MicrosoftPeeringConfig);

                // list all peerings
                var listPeering = networkResourceProviderClient.ExpressRouteCircuitPeerings.List(resourceGroupName, circuitName);
                Assert.Equal(HttpStatusCode.OK, listPeering.StatusCode);
                Assert.Equal(1, listPeering.Peerings.Count);
                Assert.Equal("AzurePrivatePeering", listPeering.Peerings[0].Name);
                Assert.Equal(ExpressRouteCircuitPeeringType.AzurePrivatePeering, listPeering.Peerings[0].PeeringType);
                Assert.Equal(100, listPeering.Peerings[0].PeerASN);
                Assert.Equal("192.168.1.0/30", listPeering.Peerings[0].PrimaryPeerAddressPrefix);
                Assert.Equal("192.168.2.0/30", listPeering.Peerings[0].SecondaryPeerAddressPrefix);
                Assert.Equal(200, listPeering.Peerings[0].VlanId);

                // Add a new peering
                var peering = new ExpressRouteCircuitPeering()
                                  {
                                      PeeringType = ExpressRouteCircuitPeeringType.MicrosoftPeering,
                                      PeerASN = 100,
                                      PrimaryPeerAddressPrefix = "192.168.1.0/30",
                                      SecondaryPeerAddressPrefix = "192.168.2.0/30",
                                      VlanId = 200,
                                      MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                                                                   {
                                                                       AdvertisedPublicPrefixes = new List<string>() { "11.2.3.4/30", "12.2.3.4/30"},
                                                                       CustomerASN = 1000,
                                                                       RoutingRegistryName = "AFRINIC"
                                                                   }
                                  };

                var putPeering = networkResourceProviderClient.ExpressRouteCircuitPeerings.CreateOrUpdate(resourceGroupName, circuitName, "MicrosoftPeering", peering);
                Assert.Equal(HttpStatusCode.OK, putPeering.StatusCode);

                getPeering = networkResourceProviderClient.ExpressRouteCircuitPeerings.Get(resourceGroupName, circuitName, "MicrosoftPeering");
                Assert.Equal(HttpStatusCode.OK, getPeering.StatusCode);

                Assert.Equal("MicrosoftPeering", getPeering.Peering.Name);
                Assert.Equal(ExpressRouteCircuitPeeringType.MicrosoftPeering, getPeering.Peering.PeeringType);
                Assert.Equal(100, getPeering.Peering.PeerASN);
                Assert.Equal("192.168.1.0/30", getPeering.Peering.PrimaryPeerAddressPrefix);
                Assert.Equal("192.168.2.0/30", getPeering.Peering.SecondaryPeerAddressPrefix);
                Assert.Equal(200, getPeering.Peering.VlanId);
                Assert.NotNull(getPeering.Peering.MicrosoftPeeringConfig);
                Assert.Equal(2, getPeering.Peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixes.Count);
                Assert.NotNull(getPeering.Peering.MicrosoftPeeringConfig.AdvertisedPublicPrefixesState);
                Assert.Equal(1000, getPeering.Peering.MicrosoftPeeringConfig.CustomerASN);
                Assert.Equal("AFRINIC", getPeering.Peering.MicrosoftPeeringConfig.RoutingRegistryName);

                listPeering = networkResourceProviderClient.ExpressRouteCircuitPeerings.List(resourceGroupName, circuitName);
                Assert.Equal(HttpStatusCode.OK, listPeering.StatusCode);
                Assert.Equal(2, listPeering.Peerings.Count);

                // Delete Peering
                var deletePeering = networkResourceProviderClient.ExpressRouteCircuitPeerings.Delete(resourceGroupName, circuitName, "MicrosoftPeering");
                Assert.Equal(HttpStatusCode.OK, deletePeering.StatusCode);

                listPeering = networkResourceProviderClient.ExpressRouteCircuitPeerings.List(resourceGroupName, circuitName);
                Assert.Equal(HttpStatusCode.OK, listPeering.StatusCode);
                Assert.Equal(1, listPeering.Peerings.Count);

                // Verify Delete circuit
                var deleteCircuit = networkResourceProviderClient.ExpressRouteCircuits.Delete(resourceGroupName, circuitName);
                Assert.Equal(HttpStatusCode.OK, deleteCircuit.StatusCode);

                var listCircuit = networkResourceProviderClient.ExpressRouteCircuits.List(resourceGroupName);
                Assert.Equal(0, listCircuit.ExpressRouteCircuits.Count);
            }
        }
    }
}

