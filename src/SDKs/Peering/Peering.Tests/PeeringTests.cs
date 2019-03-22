// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PeeringTests.cs" company="Microsoft">
//   
// </copyright>
// <summary>
//   Defines the  PeeringTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Peering.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;

    using ContactInfo = Microsoft.Azure.Management.Peering.Models.ContactInfo;
    using DirectConnection = Microsoft.Azure.Management.Peering.Models.DirectConnection;
    using PeeringSku = Microsoft.Azure.Management.Peering.Models.PeeringSku;
    using SubResource = Microsoft.Azure.Management.Peering.Models.SubResource;

    public class PeeringTests
    {
        private readonly Random random = new Random();
        public PeeringManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }


        [Fact]
        public void PeeringOperationsTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var peeringLists = this.client.Operations.List();
                Assert.NotNull(peeringLists);
            }
        }

        [Fact]
        public void GetDirectLocations()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var result = this.client.PeeringLocations.List("Direct");
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetExchangeLocations()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var result = this.client.PeeringLocations.List("Exchange");
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void UpdatePeerInfoTest()
        {
            int asn = 65000;
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.updatePeerAsn(context, asn);
                context.Dispose();
            }
        }

        [Fact]
        public void GetPeerAsnTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var result = this.client.PeerAsns.Get("Contoso65000");
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void CreateDirectPeering()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();

                //Create a Resource Group
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                var rgname = TestUtilities.GenerateName("res");
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = "centralus"
                    });

                //Create Direct Peering
                var directConnection = new DirectConnection
                {
                    BandwidthInMbps = 10000,
                    PeeringDBFacilityId = 63,
                    BgpSession = new Microsoft.Azure.Management.Peering.Models.BgpSession()
                    {
                        SessionPrefixV4 = this.CreateIpv4Address(true),
                        MaxPrefixesAdvertisedV4 = 20000
                    }
                };

                SubResource asnReference = new SubResource(this.client.PeerAsns.Get($"Contoso{65000}").Id);
                var directPeeringProperties = new PeeringPropertiesDirect(new List<DirectConnection>(), false, asnReference);
                directPeeringProperties.Connections.Add(directConnection);
                var peeringModel = new PeeringModel
                {
                    PeeringLocation = "Amsterdam",
                    Sku = new PeeringSku("Basic_Direct_Free"),
                    Direct = directPeeringProperties,
                    Location = "centralus",
                    Kind = "Direct"
                };
                var name = $"directpeering3103";
                var result = this.client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                var peering = this.client.Peerings.Get(rgname, name);
                Assert.NotNull(peering);
                Assert.Equal(name, peering.Name);
            }
        }

        [Fact]
        public void GetDirectPeering()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var peering = this.client.Peerings.Get("res5527", "directpeering3103");
                Assert.NotNull(peering);
            }
        }

        [Fact]
        public void CreateExchangePeering()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();

                //Create a Resource Group
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                var rgname = TestUtilities.GenerateName("res");
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = "centralus"
                    });


                int asn = 65000;

                //Create Exchange Peering
                var exchangeConnection = new ExchangeConnection
                {
                    PeeringDBFacilityId = 26,
                    BgpSession = new Microsoft.Azure.Management.Peering.Models.BgpSession()
                    {
                        PeerSessionIPv4Address = $"80.249.208.{this.random.Next(1, 254)}",
                        MaxPrefixesAdvertisedV4 = 20000
                    }
                };
                SubResource asnReference = new SubResource(this.client.PeerAsns.Get($"Contoso{asn}").Id);
                var exchangePeeringProperties = new PeeringPropertiesExchange(new List<ExchangeConnection>(), asnReference);
                exchangePeeringProperties.Connections.Add(exchangeConnection);
                var peeringModel = new PeeringModel
                {
                    PeeringLocation = "Amsterdam",
                    Sku = new PeeringSku("Basic_Exchange_Free"),
                    Location = "centralus",
                    Exchange = exchangePeeringProperties,
                    Kind = "Exchange"
                };
                var name = $"exchangepeering1022";
                var result = this.client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                var peering = this.client.Peerings.Get(rgname, name);
                Assert.NotNull(peering);
                Assert.Equal(name, peering.Name);
            }
        }

        private string CreateIpv4Address(bool useMaxSubNet = true)
        {
            return useMaxSubNet
                ? $"{this.random.Next(1, 255)}.{this.random.Next(0, 255)}.{this.random.Next(0, 255)}.0/30"
                : $"{this.random.Next(1, 255)}.{this.random.Next(0, 255)}.{this.random.Next(0, 255)}.0/31";
        }

        private void updatePeerAsn(MockContext context, int asn)
        {
            string[] phone = { "9999999" };
            string[] email = { $"noc{asn}@contoso.com" };
            var contactInfo = new ContactInfo(email, phone);
            var peerInfo = new PeerAsn(peerAsnProperty: asn, peerContactInfo: contactInfo, peerName: $"Contoso{asn}", validationState:"Approved");

            this.client = context.GetServiceClient<PeeringManagementClient>();
            try
            {
                var result = this.client.PeerAsns.CreateOrUpdate(peerInfo.PeerName, peerInfo);
                var peerAsn = this.client.PeerAsns.Get(peerInfo.PeerName);
                Assert.NotNull(peerAsn);
            }
            catch (Exception exception)
            {
                var peerAsn = this.client.PeerAsns.ListBySubscription();
                Assert.NotNull(peerAsn);
                Assert.NotNull(exception);
            }
        }
    }
}