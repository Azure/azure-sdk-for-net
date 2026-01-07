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
            Assert.That(dnssecConfig, Is.Not.Null);
            Assert.That(dnssecConfig.Value.Data.Name, Is.EqualTo("default"));
            Assert.That(dnssecConfig.Value.Data.ProvisioningState, Is.EqualTo("Succeeded"));
        }

        [RecordedTest]
        public async Task Delete()
        {
            var dnssecConfigId = DnssecConfigResource.CreateResourceIdentifier(_dnsZone.Id.SubscriptionId, _dnsZone.Id.ResourceGroupName, _dnsZone.Id.Name);
            var dnssecConfig = await Client.GetDnssecConfigResource(dnssecConfigId).CreateOrUpdateAsync(WaitUntil.Completed);
            Assert.That(dnssecConfig, Is.Not.Null);
            Assert.That(dnssecConfig.Value.Data.Name, Is.EqualTo("default"));
            Assert.That(dnssecConfig.Value.Data.ProvisioningState, Is.EqualTo("Succeeded"));

            await Client.GetDnssecConfigResource(dnssecConfigId).DeleteAsync(WaitUntil.Completed);
            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await Client.GetDnssecConfigResource(dnssecConfigId).GetAsync());
        }

        [RecordedTest]
        public async Task Get()
        {
            var dnssecConfigId = DnssecConfigResource.CreateResourceIdentifier(_dnsZone.Id.SubscriptionId, _dnsZone.Id.ResourceGroupName, _dnsZone.Id.Name);
            var dnssecConfig = await Client.GetDnssecConfigResource(dnssecConfigId).CreateOrUpdateAsync(WaitUntil.Completed);
            Assert.That(dnssecConfig, Is.Not.Null);
            Assert.That(dnssecConfig.Value.Data.Name, Is.EqualTo("default"));
            Assert.That(dnssecConfig.Value.Data.ProvisioningState, Is.EqualTo("Succeeded"));

            var dnssecConfigGet = await Client.GetDnssecConfigResource(dnssecConfigId).GetAsync();
            Assert.That(dnssecConfigGet, Is.Not.Null);
            Assert.That(dnssecConfigGet.Value.Data.Name, Is.EqualTo("default"));
            Assert.That(dnssecConfigGet.Value.Data.ProvisioningState, Is.EqualTo("Succeeded"));
        }
    }
}
