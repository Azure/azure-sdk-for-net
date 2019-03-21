// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsTests.cs" company="Microsoft">
//   
// </copyright>
// <summary>
//   Defines the OperationsTests type.
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
            this.Init();
            int asn = random.Next(64512, 65535);
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.updatePeerAsn(context, asn);
                context.Dispose();
            }
        }

        [Fact]
        public void GetPeerAsnTest()
        {
            this.Init();
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var result = this.client.PeerAsns.Get("Contoso");
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void CreateDirectPeering()
        {
            this.Init();
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

                // Create random PeerAsn
                int asn = random.Next(64512, 65535);
                this.updatePeerAsn(context, asn);

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

                SubResource asnReference = new SubResource(this.client.PeerAsns.Get($"Contoso{asn}").Id);
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
                var name = $"directpeering{this.random.Next(1, 9999)}";
                var result = this.client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                var peering = this.client.Peerings.Get(rgname, name);
                Assert.NotNull(peering);
                Assert.Equal(name, peering.Name);
            }
        }

        [Fact]
        public void CreateExchangePeering()
        {
            this.Init();
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


                int asn = random.Next(64512, 65535);
                this.updatePeerAsn(context, asn);
                string asnString = asn.ToString();
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
                SubResource asnReference = new SubResource(this.client.PeerAsns.Get($"Contoso{asnString}").Id);
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
                var name = $"exchangepeering{this.random.Next(1, 9999)}";
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

        private void Init()
        {
            var mode = System.Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            var connectionstring = System.Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            if (mode == null)
                Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
            if (connectionstring == null)
                Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=4445bf11-61c4-436f-a940-60194f8aca57;ServicePrincipal=a66ad4b3-4c1b-43bf-a0bd-91c8c2c9a6d8;ServicePrincipalSecret=EO84mEYKj9hbJfn/GfkgFCsZmEjDpUqm4ys7CEQpAuY=;AADTenant=f686d426-8d16-42db-81b7-ab578e110ccd;Environment=Dogfood;HttpRecorderMode=Record;");
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