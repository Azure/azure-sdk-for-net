// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PrivateDns.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PrivateDns.Tests
{
    internal class PrivateDnsTests : PrivateDnsManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PrivateDnsZoneCollection _privateZoneResource;

        public PrivateDnsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _privateZoneResource = _resourceGroup.GetPrivateDnsZones();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _privateZoneResource.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                var vnetLinks = await item.GetVirtualNetworkLinks().GetAllAsync().ToEnumerableAsync();
                foreach (var vnetLink in vnetLinks)
                {
                    await vnetLink.DeleteAsync(WaitUntil.Completed);
                }

                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);
            ValidatePrivateZone(privateZone, privateZoneName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreatePrivateZone(_resourceGroup, privateZoneName);
            bool flag = await _privateZoneResource.ExistsAsync(privateZoneName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreatePrivateZone(_resourceGroup, privateZoneName);
            var privateZone = await _privateZoneResource.GetAsync(privateZoneName);
            ValidatePrivateZone(privateZone, privateZoneName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreatePrivateZone(_resourceGroup, privateZoneName);
            var list = await _privateZoneResource.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePrivateZone(list.First(item => item.Data.Name == privateZoneName), privateZoneName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);
            bool flag = await _privateZoneResource.ExistsAsync(privateZoneName);
            Assert.IsTrue(flag);

            await privateZone.DeleteAsync(WaitUntil.Completed);
            flag = await _privateZoneResource.ExistsAsync(privateZoneName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task GetRecordsAsync()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);
            // Add some aaaaRecord
            var aaaaRecord1 = await privateZone.GetPrivateDnsAaaaRecords().CreateOrUpdateAsync(WaitUntil.Completed, "aaaa100", new PrivateDnsAaaaRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsAaaaRecords =
                {
                    new PrivateDnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d55")
                    },
                    new PrivateDnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d56")
                    },
                }
            });
            var aaaaRecord2 = await privateZone.GetPrivateDnsAaaaRecords().CreateOrUpdateAsync(WaitUntil.Completed, "aaaa200", new PrivateDnsAaaaRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsAaaaRecords =
                {
                    new PrivateDnsAaaaRecordInfo()
                    {
                        IPv6Address = IPAddress.Parse("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d57")
                    }
                }
            });

            // Add some MXRecord
            var mxRecord = await privateZone.GetPrivateDnsMXRecords().CreateOrUpdateAsync(WaitUntil.Completed, "mx100", new PrivateDnsMXRecordData()
            {
                TtlInSeconds = 3600,
                PrivateDnsMXRecords =
                {
                    new PrivateDnsMXRecordInfo()
                    {
                        Preference = 10,
                        Exchange = "mymail1.contoso.com"
                    }
                }
            });
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(10000);
            }

            var recordSets = await privateZone.GetRecordsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(recordSets);
            Assert.IsNotNull(recordSets[0].PrivateDnsSoaRecordInfo);

            Assert.AreEqual(2, recordSets[1].AaaaRecords.Count);
            Assert.AreEqual("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d55", recordSets[1].AaaaRecords.First().IPv6Address.ToString());
            Assert.AreEqual(1, recordSets[2].AaaaRecords.Count);
            Assert.AreEqual("3f0d:8079:32a1:9c1d:dd7c:afc6:fc15:d57", recordSets[2].AaaaRecords.First().IPv6Address.ToString());

            Assert.AreEqual("mymail1.contoso.com", recordSets[3].MXRecords.First().Exchange.ToString());
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);

            // AddTag
            await privateZone.AddTagAsync("addtagkey", "addtagvalue");
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(30000);
            }
            privateZone = await _privateZoneResource.GetAsync(privateZoneName);
            Assert.AreEqual(1, privateZone.Data.Tags.Count);
            KeyValuePair<string, string> tag = privateZone.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await privateZone.RemoveTagAsync("addtagkey");
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(30000);
            }
            privateZone = await _privateZoneResource.GetAsync(privateZoneName);
            Assert.AreEqual(0, privateZone.Data.Tags.Count);
        }

        [RecordedTest]
        public async Task AddVnetLinkWithResolutionPolicy()
        {
            string privateZoneName = "privatelink.sql.azuresynapse.net";
            string vnetName = "samplevnet";
            string vnetLinkName = $"{Recording.GenerateAssetName("samplelink")}";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);
            var vnet = await CreateVirtualNetwork(_resourceGroup, vnetName);

            // Add NxDomainRedirect resolutionPolicy
            var virtualNetworkLinkData = new VirtualNetworkLinkData("global")
            {
                VirtualNetwork = new WritableSubResource { Id = vnet.Id },
                RegistrationEnabled = false,
                PrivateDnsResolutionPolicy = PrivateDnsResolutionPolicy.NxDomainRedirect,
            };

            await CreateOrUpdateVirtualNetworkLink(privateZone, vnetLinkName, virtualNetworkLinkData);

            var virtualNetworkLinkResource = await privateZone.GetVirtualNetworkLinks().GetAsync(vnetLinkName);
            var vnetLinkData = virtualNetworkLinkResource.Value.Data;
            Assert.AreEqual(vnetLinkData.PrivateDnsResolutionPolicy, virtualNetworkLinkData.PrivateDnsResolutionPolicy);

            // Update resolutionPolicy to default
            virtualNetworkLinkData.PrivateDnsResolutionPolicy = PrivateDnsResolutionPolicy.Default;
            await CreateOrUpdateVirtualNetworkLink(privateZone, vnetLinkName, virtualNetworkLinkData);

            virtualNetworkLinkResource = await privateZone.GetVirtualNetworkLinks().GetAsync(vnetLinkName);
            vnetLinkData = virtualNetworkLinkResource.Value.Data;
            Assert.AreEqual(vnetLinkData.PrivateDnsResolutionPolicy, virtualNetworkLinkData.PrivateDnsResolutionPolicy);
        }

        private void ValidatePrivateZone(PrivateDnsZoneResource privateZone, string privateZoneName)
        {
            Assert.IsNotNull(privateZone);
            Assert.IsNotNull(privateZone.Data.Id);
            Assert.AreEqual(privateZoneName, privateZone.Data.Name);
        }
    }
}
