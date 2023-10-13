// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Dns.Tests.Scenario
{
    internal class DnssecTest : DnsServiceClientTestBase
    {
        private DnsZoneResource _dnsZone;

        public DnssecTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _dnsZone = await CreateDnsZone($"2022{Recording.GenerateAssetName("dnszone")}.com", resourceGroup);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dnsZone.DeleteAsync(WaitUntil.Completed);
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var dnssecConfigId = DnssecConfigResource.CreateResourceIdentifier(_dnsZone.Id.SubscriptionId, _dnsZone.Id.ResourceGroupName, _dnsZone.Id.Name);
            var dnssecConfig = await Client.GetDnssecConfigResource(dnssecConfigId).CreateOrUpdateAsync(WaitUntil.Completed);
            Assert.NotNull(dnssecConfig);
            Assert.AreEqual("default", dnssecConfig.Value.Data.Name);
            Assert.AreEqual("Succeeded", dnssecConfig.Value.Data.ProvisioningState);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var dnssecConfigId = DnssecConfigResource.CreateResourceIdentifier(_dnsZone.Id.SubscriptionId, _dnsZone.Id.ResourceGroupName, _dnsZone.Id.Name);
            var dnssecConfig = await Client.GetDnssecConfigResource(dnssecConfigId).CreateOrUpdateAsync(WaitUntil.Completed);
            Assert.NotNull(dnssecConfig);
            Assert.AreEqual("default", dnssecConfig.Value.Data.Name);
            Assert.AreEqual("Succeeded", dnssecConfig.Value.Data.ProvisioningState);

            await Client.GetDnssecConfigResource(dnssecConfigId).DeleteAsync(WaitUntil.Completed);
            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await Client.GetDnssecConfigResource(dnssecConfigId).GetAsync());
        }

        [RecordedTest]
        public async Task Get()
        {
            var dnssecConfigId = DnssecConfigResource.CreateResourceIdentifier(_dnsZone.Id.SubscriptionId, _dnsZone.Id.ResourceGroupName, _dnsZone.Id.Name);
            var dnssecConfig = await Client.GetDnssecConfigResource(dnssecConfigId).CreateOrUpdateAsync(WaitUntil.Completed);
            Assert.NotNull(dnssecConfig);
            Assert.AreEqual("default", dnssecConfig.Value.Data.Name);
            Assert.AreEqual("Succeeded", dnssecConfig.Value.Data.ProvisioningState);

            var dnssecConfigGet = await Client.GetDnssecConfigResource(dnssecConfigId).GetAsync();
            Assert.NotNull(dnssecConfigGet);
            Assert.AreEqual("default", dnssecConfigGet.Value.Data.Name);
            Assert.AreEqual("Succeeded", dnssecConfigGet.Value.Data.ProvisioningState);
        }
    }
}
