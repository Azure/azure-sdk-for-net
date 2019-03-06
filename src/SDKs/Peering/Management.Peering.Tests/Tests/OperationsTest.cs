using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Peering;
using Microsoft.Azure.Test.HttpRecorder;
using ContactInfo = Microsoft.Azure.Management.Peering.Models.ContactInfo;
using PeerInfo = Microsoft.Azure.Management.Peering.Models.PeerInfo;
using PeeringLocation = Microsoft.Azure.Management.Peering.Models.PeeringLocation;
using DirectConnection = Microsoft.Azure.Management.Peering.Models.DirectConnection;
using PeeringSku = Microsoft.Azure.Management.Peering.Models.PeeringSku;
using Microsoft.Azure.Management.Peering.Models;

namespace Peering.Tests
{
    public class OperationsTest
    {
        private readonly Random random = new Random();
        public EdgeRpClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }

        [Fact]
        public void PeeringOperationsTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<EdgeRpClient>();
                var peeringLists = this.client.Operations.List();
                Assert.NotNull(peeringLists);
            }
        }

        [Fact]
        public void GetDirectLocations()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<EdgeRpClient>();
                var result = this.client.PeeringLocations.List("Direct");
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetExchangeLocations()
        {
           using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<EdgeRpClient>();
                var result = this.client.PeeringLocations.List("Exchange");
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void UpdatePeerInfoTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                string[] phone = { "9999999" };
                string[] email = { "noc@microsoft.com" };
                var contactInfo = new ContactInfo(email, phone);
                var peerInfo = new PeerInfo(9999, contactInfo);

                this.client = context.GetServiceClient<EdgeRpClient>();
                var result = this.client.Operations.UpdatePeerInfo(peerInfo);
                Assert.NotNull(peerInfo);
            }
        }

        [Fact]
        public void GetPeerInfoTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<EdgeRpClient>();
                var result = this.client.Operations.GetPeerInfo();
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void CreateDirectPeering()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<EdgeRpClient>();

                //Create a Resource Group
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                var rgname = TestUtilities.GenerateName("res");
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup
                    {
                        Location = "centralus"
                    });

                //Create Direct Peering
                var directConnection = new DirectConnection
                {
                    BandwidthInMbps = 10000,
                    PeeringDBFacilityId = 99,
                    BgpSession = new Microsoft.Azure.Management.Peering.Models.BgpSession()
                    {
                        SessionPrefixV4 = this.CreateIpv4Address(true),
                        MaxPrefixesAdvertisedV4 = 20000
                    }
                };
                var directPeeringProperties = new PeeringPropertiesDirect(new List<DirectConnection>(), false);
                directPeeringProperties.Connections.Add(directConnection);
                var peeringModel = new PeeringModel
                {
                    PeeringLocation = "Amsterdam",
                    Sku = new PeeringSku("Basic_Direct_Free"),
                    Kind = "Direct",
                    Location = "centralus",
                    Direct = directPeeringProperties
                };

                var result = this.client.Peerings.CreateOrUpdate(rgname, "xyz", peeringModel);
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void CreateExchangePeering()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<EdgeRpClient>();

                //Create a Resource Group
                this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
                var rgname = TestUtilities.GenerateName("res");
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup
                    {
                        Location = "centralus"
                    });

                //Create Exchange Peering
                var exchangeConnection = new ExchangeConnection
                {
                    PeeringDBFacilityId = 99,
                    BgpSession = new Microsoft.Azure.Management.Peering.Models.BgpSession()
                    {
                        PeerSessionIPv4Address = "80.249.208.2",
                        MaxPrefixesAdvertisedV4 = 20000
                    }
                };
                var exchangePeeringProperties = new PeeringPropertiesExchange(new List<ExchangeConnection>());
                exchangePeeringProperties.Connections.Add(exchangeConnection);
                var peeringModel = new PeeringModel
                {
                    PeeringLocation = "Amsterdam",
                    Sku = new PeeringSku("Basic_Exchange_Free"),
                    Kind = "Exchange",
                    Location = "centralus",
                    Exchange = exchangePeeringProperties
                };

                var result = this.client.Peerings.CreateOrUpdate(rgname, "xyz", peeringModel);
                Assert.NotNull(result);
            }
        }

        private string CreateIpv4Address(bool useMaxSubNet = true)
        {
            return useMaxSubNet
                ? $"{this.random.Next(1, 255)}.{this.random.Next(0, 255)}.{this.random.Next(0, 255)}.0/30"
                : $"{this.random.Next(1, 255)}.{this.random.Next(0, 255)}.{this.random.Next(0, 255)}.0/31";
        }
    }
}
