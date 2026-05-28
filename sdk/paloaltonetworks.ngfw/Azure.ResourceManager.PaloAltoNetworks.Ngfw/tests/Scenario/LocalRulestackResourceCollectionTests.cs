// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Models;
using Azure.Core;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Tests.Scenario
{
    public class LocalRulestackResourceCollectionTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected ResourceGroupResource DefaultResGroup { get; set; }
        protected LocalRulestackResource DefaultResource1 { get; set; }
        public LocalRulestackResourceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public LocalRulestackResourceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await CreateResourceGroup(DefaultSubscription, ResourceGroupPrefix, Location);
                DefaultResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                DefaultResource1 = await DefaultResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-1-lrs");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string resourceName = Recording.GenerateAssetName("dotnetSdkTest-lrs-");
            var response = await ResGroup.GetLocalRulestacks().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, getLocalRulestackData());
            LocalRulestackResource lrs = response.Value;
            Assert.IsTrue(resourceName.Equals(lrs.Data.Name));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await ResGroup.GetLocalRulestacks().CreateOrUpdateAsync(WaitUntil.Completed, resourceName, null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackCollection collection = DefaultResGroup.GetLocalRulestacks();
            LocalRulestackResource firewallResource = await collection.GetAsync(DefaultResource1.Data.Name);
            Assert.IsNotNull(firewallResource);
            AssertTrackedResource(DefaultResource1.Data, firewallResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            LocalRulestackCollection collection = DefaultResGroup.GetLocalRulestacks();
            Assert.IsTrue(await collection.ExistsAsync(DefaultResource1.Data.Name));
            Assert.IsFalse(await collection.ExistsAsync("invalidResourceName"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            LocalRulestackCollection collection = DefaultResGroup.GetLocalRulestacks();
            int count = 0;
            await foreach (LocalRulestackResource lrs in collection.GetAllAsync())
            {
                count++;
            }

            Assert.AreEqual(count, 4);
        }

        private void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        private LocalRulestackData getLocalRulestackData()
        {
            LocalRulestackData data = new LocalRulestackData(AzureLocation.EastUS2)
            {
                Scope = RulestackScopeType.Local,
                Description = "local rulestacks",
                DefaultMode = RuleCreationDefaultMode.IPS,
                SecurityServices = new RulestackSecurityServices()
                {
                    VulnerabilityProfile = "BestPractice",
                    AntiSpywareProfile = "BestPractice",
                    AntiVirusProfile = "BestPractice",
                    UrlFilteringProfile = "BestPractice",
                    FileBlockingProfile = "BestPractice",
                    DnsSubscription = "BestPractice"
                }
            };
            return data;
        }
    }
}
