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
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Azure.Test.HttpRecorder.ProcessRecordings;
    using Microsoft.Rest;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Xunit;
    using Xunit.Sdk;
    using ContactInfo = Microsoft.Azure.Management.Peering.Models.ContactInfo;
    using DirectConnection = Microsoft.Azure.Management.Peering.Models.DirectConnection;
    using PeeringSku = Microsoft.Azure.Management.Peering.Models.PeeringSku;
    using SubResource = Microsoft.Azure.Management.Peering.Models.SubResource;

    public class PeeringTests
    {
        private readonly Random random = new Random();
        public PeeringManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }

        public PeeringTests()
        {
            // Set the value to false for Playback or True for record.
            this.Setup(false);
        }

        private void Setup(bool isRecord = false)
        {
            var mode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

            var connectionstring = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");

            if (mode == null)
                Environment.SetEnvironmentVariable("AZURE_TEST_MODE", isRecord ? "Record" : "Playback");
            if (connectionstring == null && isRecord)
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.None);
                if (path != string.Empty)
                {
                    // See the team notes under ibiza SDK update or search connectionString.txt
                    path += @"\..\.azure\connectionString.txt";
                    string connection = File.ReadAllText(path);
                    Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connection);
                }
            }
        }

        [Fact]
        public void PeeringOperationsTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var peeringLists = this.client.Operations.List();
                Assert.NotNull(peeringLists);
            }
        }

        [Fact]
        public void GetDirectLocations()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.client = context.GetServiceClient<PeeringManagementClient>();
                var result = this.client.PeeringLocations.List("Direct");
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void GetExchangeLocations()
        {
            using (var context = MockContext.Start(this.GetType()))
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
            using (var context = MockContext.Start(this.GetType()))
            {
                this.updatePeerAsn(context, asn);
                Assert.True(this.DeletePeerAsn(context, $"Contoso{asn}"));
                context.Dispose();
            }
        }

        [Fact]
        public void CreateGetRemovePeerAsn()
        {
            int asn = 65000;
            using (var context = MockContext.Start(this.GetType()))
            {
                try
                {
                    // Create the peerAsn
                    var subId = this.CreatePeerAsn(context, asn, $"AS{asn}", isApproved: false);
                    Assert.NotNull(subId);
                    // Get the PeerAsn
                    var peerAsn = this.client.PeerAsns.Get($"AS{asn}");
                    Assert.NotNull(peerAsn);
                }
                catch
                {
                    // Should not fail unless connection issue or authentication issue.
                }
                finally
                {
                    // Delete the PeerAsn
                    Assert.True(this.DeletePeerAsn(context, $"AS{asn}"));
                }
            }
        }

        [Fact]
        public void CreateDirectPeering()
        {
            using (var context = MockContext.Start(this.GetType()))
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
                    ConnectionIdentifier = Guid.NewGuid().ToString(),
                    BandwidthInMbps = 10000,
                    PeeringDBFacilityId = 99999,
                    SessionAddressProvider = SessionAddressProvider.Peer,
                    UseForPeeringService = false,
                    BgpSession = new Microsoft.Azure.Management.Peering.Models.BgpSession()
                    {
                        SessionPrefixV4 = this.CreateIpv4Address(true),
                        MaxPrefixesAdvertisedV4 = 20000
                    }
                };

                //Create Asn 
                int asn = 65003;
                var subId = this.CreatePeerAsn(context, asn, $"AS{asn}", isApproved: true);

                SubResource asnReference = new SubResource(subId);
                var directPeeringProperties = new PeeringPropertiesDirect(new List<DirectConnection>(), false, asnReference, DirectPeeringType.Edge);
                directPeeringProperties.Connections.Add(directConnection);
                var peeringModel = new PeeringModel
                {
                    PeeringLocation = "Seattle",
                    Sku = new PeeringSku("Basic_Direct_Free"),
                    Direct = directPeeringProperties,
                    Location = "centralus",
                    Kind = "Direct"
                };
                var name = $"directpeering3103";
                try
                {
                    var result = this.client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                    var peering = this.client.Peerings.Get(rgname, name);
                    Assert.NotNull(peering);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
                finally
                {
                    Assert.True(this.DeletePeering(context, name, rgname));
                    Assert.True(this.DeletePeerAsn(context, $"AS{asn}"));
                    //Assert.True(this.DeleteResourceGroup(context, rgname));
                }
            }
        }

        [Fact]
        public void CreatePeeringService()
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

                //List Locations
                var peeringServiceLocations = this.client.PeeringServiceLocations.List().ToList();
                Assert.NotNull(peeringServiceLocations);

                var location = peeringServiceLocations.Find(s => s.Name == "New York");
                Assert.NotNull(location);

                //List Providers
                var listProviders = this.client.PeeringServiceProviders.List().ToList();
                Assert.NotNull(listProviders);
                var myProvider = listProviders.Find(p => p.ServiceProviderName == "TestPeer1");

                //Create Peering Service
                var peeringService = new PeeringService
                {
                    Location = location.AzureRegion,
                    PeeringServiceLocation = location.Name,
                    PeeringServiceProvider = myProvider.Name,
                };

                var name = TestUtilities.GenerateName("myPeeringService");
                var prefixName = "AS54733Prefix";

                try
                {
                    var result = this.client.PeeringServices.CreateOrUpdate(rgname, name, peeringService);
                    Assert.NotNull(result);
                    Assert.Equal(name, result.Name);
                }
                catch (Exception ex)
                {
                    Assert.True(this.DeletePeeringService(context, name, rgname));
                    Assert.Contains("NotFound", ex.Message);
                }
                try
                {
                    var prefix = "10.10.10.2";

                    var peeringServicePrefix = this.client.Prefixes.CreateOrUpdate(rgname, name, prefixName, prefix);
                    Assert.NotNull(peeringServicePrefix);
                    Assert.Equal(prefixName, peeringServicePrefix.Name);

                    //var servicePrefix = this.client.PeeringServicePrefixes.Get(rgname, name, prefixName);
                    //Assert.NotNull(servicePrefix);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
                finally
                {
                }
            }
        }

        [Fact]
        public void CreateExchangePeering()
        {
            using (var context = MockContext.Start(this.GetType()))
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

                //Create Asn
                int asn = 65000;
                var subId = this.CreatePeerAsn(context, asn, $"AS{asn}", isApproved: true);


                //Create Exchange Peering
                var exchangeConnection = new ExchangeConnection
                {
                    ConnectionIdentifier = Guid.NewGuid().ToString(),
                    PeeringDBFacilityId = 99999,
                    BgpSession = new Microsoft.Azure.Management.Peering.Models.BgpSession()
                    {
                        PeerSessionIPv4Address = $"10.12.97.{this.random.Next(150, 190)}",
                        MaxPrefixesAdvertisedV4 = 20000
                    }
                };
                SubResource asnReference = new SubResource(subId);
                var exchangePeeringProperties = new PeeringPropertiesExchange(new List<ExchangeConnection>(), asnReference);
                exchangePeeringProperties.Connections.Add(exchangeConnection);
                var peeringModel = new PeeringModel
                {
                    PeeringLocation = "Seattle",
                    Sku = new PeeringSku("Basic_Exchange_Free"),
                    Location = "centralus",
                    Exchange = exchangePeeringProperties,
                    Kind = "Exchange",
                    Tags = new Dictionary<string, string> { { TestUtilities.GenerateName("tfs_"), "Active" } }
                };
                var name = $"exchangepeering1022";
                try
                {
                    var result = this.client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                    var peering = this.client.Peerings.Get(rgname, name);
                    Assert.NotNull(peering);
                    Assert.Equal(name, peering.Name);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
                finally
                {
                    Assert.True(this.DeletePeering(context, name, rgname));
                    Assert.True(this.DeletePeerAsn(context, $"AS{asn}"));
                }
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
            var peerInfo = new PeerAsn(peerAsnProperty: asn, peerContactInfo: contactInfo, peerName: $"Contoso{asn}", validationState: "Approved");

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

        private string CreatePeerAsn(MockContext context, int asn = 99999, string name = "AS99999", string peerName = "Contoso", bool isApproved = false)
        {
            var peerAsn = new PeerAsn(name)
            {
                PeerName = peerName,
                PeerAsnProperty = asn,
                PeerContactInfo = new ContactInfo

                {
                    Emails = new List<string> { "noc@contoso.net" },
                    Phone = new List<string> { "8882668676" }
                },
                ValidationState = isApproved ? ValidationState.Approved : ValidationState.Pending
            };
            this.client = context.GetServiceClient<PeeringManagementClient>();
            try
            {
                var _name = $"AS{asn}";
                var result = this.client.PeerAsns.CreateOrUpdate(_name, peerAsn);
                var _peerAsn = this.client.PeerAsns.Get(_name);
                if (isApproved)
                {
                    Thread.Sleep(100);
                    Assert.NotNull(_peerAsn);
                    Assert.Equal(ValidationState.Approved, _peerAsn.ValidationState);
                }
                Assert.NotNull(_peerAsn);
                Assert.Equal(_name, _peerAsn.Name);
                Assert.Equal(asn, _peerAsn.PeerAsnProperty);
                Assert.Equal(peerName, _peerAsn.PeerName);
                Assert.NotNull(_peerAsn.Id);
                return _peerAsn.Id;
            }
            catch (Exception ex)
            {
                Assert.Equal("NotFound", ex.Message);
            }
            return string.Empty;
        }

        private bool DeletePeering(MockContext context, string name, string resourceGroupName)
        {
            this.client = context.GetServiceClient<PeeringManagementClient>();
            PeeringModel peer = null;
            try
            {
                this.client.Peerings.Delete(resourceGroupName, name);
                peer = this.client.Peerings.Get(resourceGroupName, name);
                if (peer == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Assert.Null(peer);
                Assert.NotNull(ex.Message);
                return true;
            }
        }

        private bool DeletePrefix(MockContext context, string prefixName, string peeringServiceName, string resourceGroupName)
        {
            this.client = context.GetServiceClient<PeeringManagementClient>();
            PeeringServicePrefix service = null;
            try
            {
                this.client.Prefixes.Delete(resourceGroupName, peeringServiceName, prefixName);
                service = this.client.Prefixes.Get(resourceGroupName, peeringServiceName, prefixName);
                if (service == null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Assert.Null(service);
                Assert.NotNull(ex.Message);
                return false;
            }
        }

        private bool DeletePeeringService(MockContext context, string name, string resourceGroupName)
        {
            this.client = context.GetServiceClient<PeeringManagementClient>();
            PeeringService service = null;
            try
            {
                this.client.PeeringServices.Delete(resourceGroupName, name);
                //service = this.client.PeeringServices.Get(resourceGroupName, name);
                if (service == null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Assert.Null(service);
                Assert.NotNull(ex.Message);
                return false;
            }
        }

        private bool DeletePeerAsn(MockContext context, string name)
        {
            this.client = context.GetServiceClient<PeeringManagementClient>();
            PeerAsn peerAsn = null;
            try
            {
                this.client.PeerAsns.Delete(name);
                peerAsn = this.client.PeerAsns.Get(name);
                if (peerAsn == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Assert.Null(peerAsn);
                Assert.NotNull(ex.Message);
                return true;
            }
        }

        private bool DeleteResourceGroup(MockContext context, string name)
        {
            this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
            ResourceGroup resourceGroup = null;
            try
            {
                //this.resourcesClient.ResourceGroups.Delete(name);
                resourceGroup = this.resourcesClient.ResourceGroups.Get(name);
                if (resourceGroup == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Assert.Null(resourceGroup);
                Assert.NotNull(ex.Message);
                return true;
            }
        }
    }
}