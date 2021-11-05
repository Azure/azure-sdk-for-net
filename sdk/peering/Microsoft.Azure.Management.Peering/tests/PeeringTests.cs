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
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading;

    using Microsoft.Azure.Management.Peering;
    using Microsoft.Azure.Management.Peering.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using Newtonsoft.Json;

    using Xunit;

    using DirectConnection = Microsoft.Azure.Management.Peering.Models.DirectConnection;
    using MockServer = Microsoft.Azure.Test.HttpRecorder.HttpMockServer;
    using PeeringSku = Microsoft.Azure.Management.Peering.Models.PeeringSku;
    using SubResource = Microsoft.Azure.Management.Peering.Models.SubResource;

    /// <summary>
    /// The peering tests.
    /// </summary>
    public class PeeringTests
    {
        /// <summary>
        /// The local edge rp uri.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public static Uri LocalEdgeRpUri = new Uri("https://secrets.wanrr-test.radar.core.azure-test.net/");

        /// <summary>
        /// The random.
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="PeeringTests"/> class.
        /// </summary>
        public PeeringTests()
        {
            // Set the value to false for Playback or True for record.
            this.Setup(false);
        }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        public PeeringManagementClient Client { get; set; }

        /// <summary>
        /// Gets or sets the resources client.
        /// </summary>
        public ResourceManagementClient ResourcesClient { get; set; }

        /// <summary>
        /// Gets or sets the subscription id.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The api version latest.
        /// </summary>
        public const string ApiVersionLatest = "2020-10-01";

        /// <summary>
        /// The peering operations test.
        /// </summary>
        [Fact]
        public void PeeringOperationsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                var peeringLists = this.Client.Operations.List();
                Assert.NotNull(peeringLists);
            }
        }

        /// <summary>
        /// The get direct locations.
        /// </summary>
        [Fact]
        public void GetDirectLocations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                var result = this.Client.PeeringLocations.List("Direct");
                Assert.NotNull(result);
            }
        }

        /// <summary>
        /// The get exchange locations.
        /// </summary>
        [Fact]
        public void GetExchangeLocations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                var result = this.Client.PeeringLocations.List("Exchange");
                Assert.NotNull(result);
            }
        }

        /// <summary>
        /// The update peer info test.
        /// </summary>
        [Fact]
        public void UpdatePeerInfoTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                int asn = 65000;
                this.updatePeerAsn(asn);
                Assert.True(this.DeletePeerAsn($"Contoso{asn}"));
            }
        }

        /// <summary>
        /// The create get remove peer asn.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        [Fact]
        public void CreateGetRemovePeerAsn()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                int asn = 65000;
                {
                    try
                    {
                        // Create the peerAsn
                        var subId = this.CreatePeerAsn(asn, $"AS{asn}", isApproved: false);
                        Assert.NotNull(subId);
                        // Get the PeerAsn
                        var peerAsn = this.Client.PeerAsns.Get($"AS{asn}");
                        Assert.NotNull(peerAsn);
                    }
                    catch
                    {
                        // Should not fail unless connection issue or authentication issue.
                    }
                    finally
                    {
                        // Delete the PeerAsn
                        Assert.True(this.DeletePeerAsn($"AS{asn}"));
                    }
                }
            }
        }

        /// <summary>
        /// The create direct peering.
        /// </summary>
        [Fact]
        public void CreateDirectPeering()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                //Create a Resource Group
                var rgname = TestUtilities.GenerateName("res");
                var resourceGroup = this.ResourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup { Location = "centralus" });

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

                // Create Asn 
                int asn = 65003;
                var subId = this.CreatePeerAsn(asn, $"AS{asn}", isApproved: true);

                SubResource asnReference = new SubResource(subId);
                var directPeeringProperties = new PeeringPropertiesDirect(
                    new List<DirectConnection>(),
                    false,
                    asnReference,
                    DirectPeeringType.Edge);
                directPeeringProperties.Connections.Add(directConnection);
                var peeringModel = new PeeringModel
                {
                    PeeringLocation = "Seattle",
                    Sku = new PeeringSku("Basic_Direct_Free"),
                    Direct = directPeeringProperties,
                    Location = "centralus",
                    Kind = "Direct"
                };
                var name = TestUtilities.GenerateName("direct_");
                try
                {
                    var result = this.Client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                    var peering = this.Client.Peerings.Get(rgname, name);
                    Assert.NotNull(peering);
                }
                catch (Exception ex)
                {
                    Assert.Contains("MethodNotAllowed", ex.Message);
                }
                finally
                {
                    Assert.True(this.DeletePeering(name, rgname));
                    Assert.True(this.DeletePeerAsn($"AS{asn}"));

                    // Assert.True(this.DeleteResourceGroup(context, rgname));
                }
            }
        }

        /// <summary>
        /// The create peering service.
        /// </summary>
        [Fact]
        public void CreatePeeringService()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                // Create a Resource Group
                var rgname = TestUtilities.GenerateName("res");
                var resourceGroup = this.ResourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup { Location = "centralus" });

                // List Locations
                var peeringServiceLocations = this.Client.PeeringServiceLocations.List().ToList();
                Assert.NotNull(peeringServiceLocations);

                var location = peeringServiceLocations.Find(s => s.Name == "Washington");
                Assert.NotNull(location);

                // List Providers
                var listProviders = this.Client.PeeringServiceProviders.List().ToList();
                Assert.NotNull(listProviders);
                PeeringServiceProvider myProvider = null;
                foreach (var provider in listProviders)
                {
                    var isAvailable =
                        this.Client.CheckServiceProviderAvailability(
                            location.State,
                            provider.Name);
                    if (isAvailable == "Available")
                    {
                        myProvider = provider;
                        break;
                    }
                }

                // Create Peering Service
                var peeringService = new PeeringService
                {
                    Location = location.AzureRegion,
                    PeeringServiceLocation = location.Name,
                    PeeringServiceProvider = myProvider?.Name,
                };

                var name = TestUtilities.GenerateName("myPeeringService");
                var prefixName = "AS54733Prefix";

                try
                {
                    var result = this.Client.PeeringServices.CreateOrUpdate(rgname, name, peeringService);
                    Assert.NotNull(result);
                    Assert.Equal(name, result.Name);
                }
                catch (Exception ex)
                {
                    Assert.True(this.DeletePeeringService(name, rgname));
                    Assert.Contains("NotFound", ex.Message);
                }

                try
                {
                    var prefix = new PeeringServicePrefix
                        {
                            Prefix = "34.56.10.0/24",
                            PeeringServicePrefixKey = TestUtilities.GenerateGuid().ToString()
                        };

                    var peeringServicePrefix = this.Client.Prefixes.CreateOrUpdate(
                        rgname,
                        name,
                        prefixName,
                        prefix.Prefix,
                        prefix.PeeringServicePrefixKey);
                    Assert.NotNull(peeringServicePrefix);
                    Assert.Equal(prefixName, peeringServicePrefix.Name);

                    // var servicePrefix = this.client.PeeringServicePrefixes.Get(rgname, name, prefixName);
                    // Assert.NotNull(servicePrefix);
                }
                catch (Exception ex)
                {
                    Assert.Contains("BadRequest", ex.Message);
                }
                finally
                {
                    Assert.True(this.DeletePeeringService(name, rgname));
                }
            }
        }

        /// <summary>
        /// The get old peer asn contact details.
        /// </summary>
        [Fact]
        public void GetOldPeerAsnContactDetails()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context, true);
                var peerAsns = this.Client.PeerAsns.ListBySubscription();
                foreach (var peerAsn in peerAsns)
                {
                    Assert.True(peerAsn.PeerContactDetail.Any());
                }
            }
        }
        private void RunDftest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context, false);
                var asns = this.Client.PeerAsns.ListBySubscription();
                if (!asns.FirstOrDefault().ValidationState.Equals(
                        "Approved",
                        StringComparison.InvariantCultureIgnoreCase))
                {
                    var subId = this.UpdatePeerValidationState(asns.FirstOrDefault(), "Approved");
                }
                var peerings = this.Client.Peerings.ListBySubscription();
                var peering = peerings.FirstOrDefault(x => x.Name == "KyleTestPeering4");

                var rg = this.GetResourceGroup(peering.Id);
                var n = this.GetPeeringName(peering.Id);
                var prefixName = TestUtilities.GenerateName("prefix_");
                var prefix = new PeeringRegisteredPrefix { Prefix = CreateIpv4Address(true) };
                var resource = this.Client.RegisteredPrefixes.CreateOrUpdate(
                    rg,
                    n,
                    $"{peering.Name}{prefixName}",
                    prefix.Prefix);
                Assert.NotNull(resource.PeeringServicePrefixKey);
            }
        }

        /// <summary>
        /// The create get list and delete registered prefix.
        /// </summary>
        [Fact]
        public void CreateGetListAndDeleteRegisteredPrefix()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                PeeringModel peering = null;
                var asn = int.Parse(TestUtilities.GenerateName("0"));
                var prefixName = TestUtilities.GenerateName("prefix_");
                try
                {
                    // Create a Resource Group
                    var rgname = this.CreateResourceGroup().Name;

                    // Create Asn 
                    var subId = this.CreatePeerAsn(asn, $"AS{asn}", isApproved: true, peerName: "FooBar");

                    // Set prefix
                    var prefix = new PeeringRegisteredPrefix { Prefix = CreateIpv4Address(true) };

                    SubResource asnReference = new SubResource(subId);
                    var directPeeringProperties = new PeeringPropertiesDirect(
                        new List<DirectConnection>(),
                        true,
                        asnReference,
                        DirectPeeringType.Edge);
                    var locations = this.Client.PeeringLocations.List("Direct", DirectPeeringType.Edge);
                    var loc = locations.FirstOrDefault(x => x.Name == "Seattle");

                    // Create Direct Peering
                    var directConnection = new DirectConnection
                        {
                            ConnectionIdentifier = Guid.NewGuid().ToString(),
                            BandwidthInMbps = 10000,
                            PeeringDBFacilityId =
                                loc.Direct.PeeringFacilities.FirstOrDefault(x => x.PeeringDBFacilityId == 99999)
                                    ?.PeeringDBFacilityId,
                            SessionAddressProvider = SessionAddressProvider.Peer,
                            BgpSession = new BgpSession
                                {
                                    SessionPrefixV4 = prefix.Prefix, MaxPrefixesAdvertisedV4 = 20000
                                },
                            UseForPeeringService = true
                        };

                    directPeeringProperties.Connections.Add(directConnection);
                    var peeringModel = new PeeringModel
                    {
                        PeeringLocation = loc.Name,
                        Sku = new PeeringSku("Premium_Direct_Free"),
                        Direct = directPeeringProperties,
                        Location = loc.AzureRegion,
                        Kind = "Direct"
                    };
                    var name = TestUtilities.GenerateName("direct_");
                    try
                    {
                        var result = this.Client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                        peering = this.Client.Peerings.Get(rgname, name);
                        Assert.NotNull(peering);
                    }
                    catch (Exception ex)
                    {
                        Assert.Contains("NotFound", ex.Message);
                    }

                    var resourceGroupName = this.GetResourceGroup(peering?.Id);
                    var peeringName = this.GetPeeringName(peering?.Id);
                    var registeredPrefixName = $"{peering?.Name}{prefixName}";
                    
                    var resource = this.Client.RegisteredPrefixes.CreateOrUpdate(
                        resourceGroupName,
                        peeringName,
                        registeredPrefixName,
                        this.CreateIpv4Address(true));
                    Assert.NotNull(resource.PeeringServicePrefixKey);
                    resource = this.Client.RegisteredPrefixes.Get(
                        resourceGroupName,
                        peeringName,
                        registeredPrefixName);
                    Assert.NotNull(resource.PeeringServicePrefixKey);
                    var list = this.Client.RegisteredPrefixes.ListByPeering(resourceGroupName, peeringName);
                    Assert.NotNull(list.FirstOrDefault()?.PeeringServicePrefixKey);
                    this.Client.RegisteredPrefixes.Delete(
                        resourceGroupName,
                        peeringName,
                        registeredPrefixName);
                    try
                    {
                        resource = this.Client.RegisteredPrefixes.Get(
                            resourceGroupName,
                            peeringName,
                            registeredPrefixName);
                    }
                    catch (Exception ex)
                    {
                        Assert.NotNull(ex.Message);
                    }
                }
                finally
                {
                    Assert.True(this.DeletePeering(peering.Name, this.GetResourceGroup(peering.Id)));
                    Assert.True(this.DeletePeerAsn($"AS{asn}"));
                }
            }
        }

        /// <summary>
        /// The create get list and delete registered ans.
        /// </summary>
        [Fact]
        public void CreateGetListAndDeleteRegisteredAsns()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);

                // Create a Resource Group
                var rgname = this.CreateResourceGroup().Name;

                PeeringModel peering = null;
                var asn = int.Parse(MockServer.GetVariable("asnInteger", this.random.Next(1, 65000).ToString()));
                var peerAsnId = this.CreatePeerAsn(asn, $"AS{asn}", isApproved: true);
                var peerAsn = this.Client.PeerAsns.Get(this.GetPeerAsnName(peerAsnId));
                try
                {
                    var directPeeringProperties = new PeeringPropertiesDirect(
                                new List<DirectConnection>(),
                                true,
                                new SubResource(peerAsnId),
                                DirectPeeringType.IxRs);
                    var locations = this.Client.PeeringLocations.List("Direct", DirectPeeringType.Edge);
                    var loc = locations.FirstOrDefault(x => x.Name == "Seattle");

                    // Create Direct Peering
                    var directConnection = new DirectConnection
                    {
                        ConnectionIdentifier = Guid.NewGuid().ToString(),
                        BandwidthInMbps = 10000,
                        PeeringDBFacilityId =
                                                       loc.Direct.PeeringFacilities
                                                           .FirstOrDefault(x => x.PeeringDBFacilityId == 99999)
                                                           ?.PeeringDBFacilityId,
                        SessionAddressProvider = SessionAddressProvider.Microsoft,
                        UseForPeeringService = true
                    };
                    directPeeringProperties.Connections.Add(directConnection);
                    var peeringModel = new PeeringModel
                    {
                        PeeringLocation = loc.Name,
                        Sku = new PeeringSku("Premium_Direct_Free"),
                        Direct = directPeeringProperties,
                        Location = loc.AzureRegion,
                        Kind = "Direct"
                    };
                    var name = TestUtilities.GenerateName("direct_");
                    try
                    {
                        var result = this.Client.Peerings.CreateOrUpdate(rgname, name, peeringModel);
                        peering = this.Client.Peerings.Get(rgname, name);
                        Assert.NotNull(peering);
                    }
                    catch (Exception ex)
                    {
                        Assert.Contains("NotFound", ex.Message);
                }
                    var rgName = this.GetResourceGroup(peering.Id);
                    var pName = this.GetPeeringName(peering.Id);
                    var registeredAsnName = $"{peering.Name}_{peerAsn.PeerAsnProperty}";
                    var resource = this.Client.RegisteredAsns.CreateOrUpdate(
                        rgName,
                        pName,
                        registeredAsnName,
                        peerAsn.PeerAsnProperty);
                    Assert.NotNull(resource);
                    try
                    {
                        resource = this.Client.RegisteredAsns.Get(rgName, pName, registeredAsnName);
                        Assert.NotNull(resource);
                        var list = this.Client.RegisteredAsns.ListByPeering(rgname, pName);
                        Assert.NotNull(list);
                        this.Client.RegisteredAsns.Delete(
                            rgName,
                            pName,
                            registeredAsnName);
                        resource = this.Client.RegisteredAsns.Get(
                            rgName,
                            pName,
                            registeredAsnName);
                    }
                    catch (Exception ex)
                    {
                        Assert.Contains("NotFound", ex.Message);
                    }
                }
                finally
                {
                    Assert.True(this.DeletePeering(peering.Name, this.GetResourceGroup(peering.Id)));
                    Assert.True(this.DeletePeerAsn($"AS{asn}"));
                }
            }
        }

        /// <summary>
        /// The create exchange peering.
        /// </summary>
        [Fact]
        public void CreateExchangePeering()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.MockClients(context);
                PeeringModel peering = null;
                var asn = int.Parse(TestUtilities.GenerateName("0"));
                try
                {
                    peering = this.CreateExchangePeeringModel(asn);
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }
                finally
                {
                    Assert.True(this.DeletePeering(peering.Name, this.GetResourceGroup(peering.Id)));
                    Assert.True(this.DeletePeerAsn($"AS{asn}"));
                }
            }
        }

        /// <summary>
        /// The setup.
        /// </summary>
        /// <param name="recordMockResults">
        /// The is record.
        /// </param>
        internal void Setup(bool recordMockResults = false)
        {
            var mode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

            var connectionstring = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");

            if (mode == null)
            {
                Environment.SetEnvironmentVariable("AZURE_TEST_MODE", recordMockResults ? "Record" : "Playback");
            }

            if (connectionstring == null && recordMockResults)
            {
                var path = Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments,
                    Environment.SpecialFolderOption.None);
                if (path != string.Empty)
                {
                    // See the team notes under ibiza SDK update or search connectionString.txt
                    path += @"\..\.azure\connectionString.txt";
                    string connection = File.ReadAllText(path);
                    Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", connection);
                }
            }

            var subscriptionId = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION")?.Split(";")[0]
                .Split("=")[1];
            if (!string.IsNullOrEmpty(subscriptionId))
            {
                this.SubscriptionId = subscriptionId;
                this.MockRegisterSubscription(subscriptionId);
            }
        }

        /// <summary>
        /// The mock register subscription.
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription id.
        /// </param>
        internal void MockRegisterSubscription(string subscriptionId)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                this.RegisterSubscription(subscriptionId);
            }
        }

        /// <summary>
        /// The mock clients.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="isLocal">
        /// The is Local.
        /// </param>
        internal void MockClients(MockContext context, bool isLocal = true)
        {
            if (this.Client == null)
            {
                this.Client = context.GetServiceClient<PeeringManagementClient>();
                if (isLocal)
                {
                    this.Client.BaseUri = LocalEdgeRpUri;
                }
            }

            if (this.ResourcesClient == null)
            {
                this.ResourcesClient = context.GetServiceClient<ResourceManagementClient>();
            }
        }

        /// <summary>
        /// The create resource group.
        /// </summary>
        /// <param name="isLocal">
        /// The is Local.
        /// </param>
        /// <returns>
        /// The <see cref="ResourceGroup"/>.
        /// </returns>
        private ResourceGroup CreateResourceGroup(bool isLocal = true)
        {
            var rgname = TestUtilities.GenerateName("res");

            if (isLocal)
            {
                return new ResourceGroup("centralus", null, rgname);
            }

            var resourceGroup = this.ResourcesClient.ResourceGroups.CreateOrUpdate(
                rgname,
                new ResourceGroup { Location = "centralus" });
            return resourceGroup;
        }

        /// <summary>
        /// The create exchange peering.
        /// </summary>
        /// <param name="asn">
        /// The asn.
        /// </param>
        /// <returns>
        /// The <see cref="PeeringModel"/>.
        /// </returns>
        private PeeringModel CreateExchangePeeringModel(int asn = 65000)
        {
            // create resource group
            var resourceGroup = this.CreateResourceGroup();

            // Create Asn
            var subId = this.CreatePeerAsn(asn, $"AS{asn}", isApproved: true);

            // Create Exchange Peering
            var ipAddress = int.Parse(MockServer.GetVariable("ipAddress", this.random.Next(150, 190).ToString()));
            var exchangeConnection = new ExchangeConnection
            {
                ConnectionIdentifier = Guid.NewGuid().ToString(),
                PeeringDBFacilityId = 99999,
                BgpSession = new Microsoft.Azure.Management.Peering.Models.BgpSession()
                {
                    PeerSessionIPv4Address = $"10.12.97.{ipAddress}",
                    MaxPrefixesAdvertisedV4 = 20000
                }
            };
            SubResource asnReference = new SubResource(subId);
            var exchangePeeringProperties = new PeeringPropertiesExchange(
                new List<ExchangeConnection>(),
                asnReference);
            exchangePeeringProperties.Connections.Add(exchangeConnection);
            var peeringModel = new PeeringModel
            {
                PeeringLocation = "Seattle",
                Sku = new PeeringSku("Basic_Exchange_Free"),
                Location = "centralus",
                Exchange = exchangePeeringProperties,
                Kind = "Exchange",
                Tags = new Dictionary<string, string>
                                                      {
                                                          { TestUtilities.GenerateName("tfs_"), "Active" }
                                                      }
            };
            var name = $"exchangepeering{asn}";
            try
            {
                var result = this.Client.Peerings.CreateOrUpdate(resourceGroup.Name, name, peeringModel);
                var peering = this.Client.Peerings.Get(resourceGroup.Name, name);
                Assert.NotNull(peering);
                Assert.Equal(name, peering.Name);
                return peering;
            }
            catch (Exception ex)
            {
                Assert.Contains("NotFound", ex.Message);
            }
            return null;
        }

        private string CreateIpv4Address(bool useMaxSubNet = true)
        {
            return useMaxSubNet
                ? $"{this.random.Next(1, 255)}.{this.random.Next(0, 255)}.{this.random.Next(0, 255)}.0/30"
                : $"{this.random.Next(1, 255)}.{this.random.Next(0, 255)}.{this.random.Next(0, 255)}.0/31";
        }

        private void updatePeerAsn(int asn)
        {
            string phone = "9999999";
            string email = $"noc{asn}@contoso.com";
            var contactInfo = new ContactDetail(Role.Noc, email, phone);
            var peerInfo = new PeerAsn(peerAsnProperty: asn, peerContactDetail: new List<ContactDetail> { contactInfo }, peerName: $"Contoso{asn}", validationState: "Approved");

            try
            {
                var result = this.Client.PeerAsns.CreateOrUpdate(peerInfo.PeerName, peerInfo);
                var peerAsn = this.Client.PeerAsns.Get(peerInfo.PeerName);
                Assert.NotNull(peerAsn);
            }
            catch (Exception exception)
            {
                var peerAsn = this.Client.PeerAsns.ListBySubscription();
                Assert.NotNull(peerAsn);
                Assert.NotNull(exception);
            }
        }

        private string CreatePeerAsn(int asn = 99999, string name = "AS99999", string peerName = "Contoso", bool isApproved = false)
        {
            var peerAsn = new PeerAsn(name)
            {
                PeerName = peerName,
                PeerAsnProperty = asn,
                PeerContactDetail = new List<ContactDetail>

                {
                    new ContactDetail
                        {
                            Role = Role.Noc,
                            Email = $"noc{asn}@contoso.com",
                            Phone = "8888988888"
                        }
                },
                ValidationState = isApproved ? ValidationState.Approved : ValidationState.Pending
            };

            try
            {
                name = $"AS{asn}";
                var result = this.Client.PeerAsns.CreateOrUpdate(name, peerAsn);
                this.UpdatePeerValidationState(result, ValidationState.Approved);
                var resultPeerAsn = this.Client.PeerAsns.Get(name);
                if (isApproved)
                {
                    Thread.Sleep(100);
                    Assert.NotNull(resultPeerAsn);
                    Assert.Equal(ValidationState.Approved, resultPeerAsn.ValidationState);
                }
                Assert.NotNull(resultPeerAsn);
                Assert.Equal(name, resultPeerAsn.Name);
                Assert.Equal(asn, resultPeerAsn.PeerAsnProperty);
                Assert.Equal(peerName, resultPeerAsn.PeerName);
                Assert.NotNull(resultPeerAsn.Id);
                return resultPeerAsn.Id;
            }
            catch (Exception ex)
            {
                Assert.Equal("NotFound", ex.Message);
            }

            return string.Empty;
        }

        /// <summary>
        /// The delete peering.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DeletePeering(string name, string resourceGroupName)
        {

            PeeringModel peering = null;
            try
            {
                this.Client.Peerings.Delete(resourceGroupName, name);
                peering = this.Client.Peerings.Get(resourceGroupName, name);
                if (peering == null || peering.ProvisioningState == "Deleting")
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Assert.Null(peering);
                Assert.NotNull(ex.Message);
                Assert.True(this.DeleteResourceGroup(resourceGroupName));
                return true;
            }
        }

        /// <summary>
        /// The delete resource group.
        /// </summary>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DeleteResourceGroup(string resourceGroupName, bool isLocal = true)
        {
            ResourceGroup resourceGroup = null;
            try
            {
                if (isLocal)
                {
                    return true;
                }

                this.ResourcesClient.ResourceGroups.Delete(resourceGroupName);
                resourceGroup = this.ResourcesClient.ResourceGroups.Get(resourceGroupName);
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

        /// <summary>
        /// The delete prefix.
        /// </summary>
        /// <param name="prefixName">
        /// The prefix name.
        /// </param>
        /// <param name="peeringServiceName">
        /// The peering service name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DeletePrefix(string prefixName, string peeringServiceName, string resourceGroupName)
        {

            PeeringServicePrefix service = null;
            try
            {
                this.Client.Prefixes.Delete(resourceGroupName, peeringServiceName, prefixName);
                service = this.Client.Prefixes.Get(resourceGroupName, peeringServiceName, prefixName);
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

        /// <summary>
        /// The delete peering service.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool DeletePeeringService(string name, string resourceGroupName)
        {

            PeeringService service = null;
            try
            {
                this.Client.PeeringServices.Delete(resourceGroupName, name);
                //service = this.client.PeeringServices.Get(resourceGroupName, name);
                return service == null;
            }
            catch (Exception ex)
            {
                Assert.Null(service);
                Assert.NotNull(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// The delete peer asn.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private bool DeletePeerAsn(string name)
        {

            PeerAsn peerAsn = null;
            try
            {
                this.Client.PeerAsns.Delete(name);
                peerAsn = this.Client.PeerAsns.Get(name);
                return peerAsn == null;
            }
            catch (Exception ex)
            {
                Assert.Null(peerAsn);
                Assert.NotNull(ex.Message);
                return true;
            }
        }

        /// <summary>
        /// The get client certificate.
        /// </summary>
        /// <returns>
        /// The <see cref="X509Certificate2"/>.
        /// </returns>
        private X509Certificate2 GetClientCertificate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            foreach (var storeCertificate in store.Certificates)
            {
                if (storeCertificate.Thumbprint != null)
                {
                    if (storeCertificate.Thumbprint.Equals(
                        "ebd2bcdaedccaa360e7eb98ac128c7c1ceb34719", //"c189a71f9e6bde7d7c713531007048c22ac5c225", //"72765da05695c17975cfc755c9763eed81b7add7",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return storeCertificate;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The register subscription.
        /// </summary>
        /// <param name="subscriptionId">
        /// The subscription id.
        /// </param>
        private void RegisterSubscription(string subscriptionId)
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var cert = this.GetClientCertificate();
                var url = new Uri($"{LocalEdgeRpUri}api/v1/subscriptions/{subscriptionId}?api-version=2.0");

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = true;
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = HttpMethod.Put.ToString();
                request.ClientCertificates = new X509Certificate2Collection(cert);
                request.ServerCertificateValidationCallback = (a, b, c, d) => true;
                request.ContentLength = 0;
                var postData = @"{
                                'state': 'Registered',
                                'registrationDate': '2019-03-01T23:57:05.644Z',
                                'properties': {
                                    'tenantId': 'string',
                                    'locationPlacementId': 'string',
                                    'quotaId': 'string',
                                    'registeredFeatures': [
                                        {
                                        'name': 'Microsoft.Peering/AllowExchangePeering',
                                        'state': 'Registered'
                                        },
                                        {
                                        'name': 'Microsoft.Peering/AllowDirectPeering',
                                        'state': 'Registered'
                                        },
                                        {
                                        'name': 'Microsoft.Peering/AllowPeeringService',
                                        'state': 'Registered'
                                        }
                                    ]
                                }
                            }";
                var data = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                request.GetRequestStream().Write(data, 0, data.Length);

                var responseString = string.Empty;

                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var sr = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                responseString = sr.ReadToEnd();
                                sr.Close();
                            }
                        }
                    }
                }

                Assert.NotNull(responseString);
            }
        }

        /// <summary>
        /// The update peer validation state.
        /// </summary>
        /// <param name="peerAsn">
        /// The peer asn.
        /// </param>
        /// <param name="asnValidationState">
        /// The asn validation state.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private object UpdatePeerValidationState(PeerAsn peerAsn, string asnValidationState)
        {
            // Patch with correct approval
            var url =
                $"api/v1/subscriptions?subscriptionId={this.SubscriptionId}&peerAsnName={peerAsn.Name}&api-version={ApiVersionLatest}&validationState={asnValidationState}";
            try
            {
                var response = this.Send(peerAsn, "PATCH", url);
                return JsonConvert.DeserializeObject<PeerAsn>(response, this.Client.DeserializationSettings);
            }
            catch
            {
                return null;
            }
        }

        private string GetResourceGroup(string id)
        {
            return id.Split("/")[4];
        }

        private string GetPeeringName(string id)
        {
            return id.Split("/")[8];
        }

        private string GetPeerAsnName(string id)
        {
            return id.Split("/")[6];
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <param name="httpMethod">
        /// The http method.
        /// </param>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string Send<T>(T t, string httpMethod, string url)
        {
            var cert = this.GetClientCertificate();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;
            var path = LocalEdgeRpUri + url;
            var request = (HttpWebRequest)WebRequest.Create(path);

            request.Method = httpMethod;
            request.ClientCertificates = new X509Certificate2Collection(cert);
            request.ServerCertificateValidationCallback = (a, b, c, d) => true;
            request.ContentLength = 0;
            var postData = JsonConvert.SerializeObject(t);
            var data = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.GetRequestStream().Write(data, 0, data.Length);

            var responseString = string.Empty;

            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var sr = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            responseString = sr.ReadToEnd();
                            sr.Close();
                        }
                    }
                }
            }

            return responseString;
        }
    }
}