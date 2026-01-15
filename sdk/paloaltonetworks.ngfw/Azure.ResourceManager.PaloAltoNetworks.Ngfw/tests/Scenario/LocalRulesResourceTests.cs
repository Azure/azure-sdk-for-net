// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using System.Xml.Linq;
using Azure.Core.TestFramework;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using NUnit.Framework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw.Tests.Scenario
{
    internal class LocalRulesResourceTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource ResGroup { get; set; }
        protected LocalRulestackRuleResource LocalRulesResource { get; set; }
        protected LocalRulestackResource LocalRulestackResource { get; set; }
        protected LocalRulesResourceTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public LocalRulesResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestackResource = await ResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-2-lrs");
                LocalRulesResource = await LocalRulestackResource.GetLocalRulestackRuleAsync("1000000");
            }
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Due to issue: https://github.com/Azure/azure-sdk-for-net/issues/53815")]
        public void CreateResourceIdentifier()
        {
            string priority = "100";
            ResourceIdentifier localRulestackResourceIdentifier = LocalRulestackRuleResource.CreateResourceIdentifier(DefaultSubscription.Data.SubscriptionId, ResGroup.Data.Name, LocalRulestackResource.Data.Name, priority);
            LocalRulestackRuleResource.ValidateResourceId(localRulestackResourceIdentifier);

            Assert.That(localRulestackResourceIdentifier.ResourceType.Equals(LocalRulestackRuleResource.ResourceType), Is.True);
            Assert.That(localRulestackResourceIdentifier.Equals($"{ResGroup.Id}/providers/{LocalRulestackResource.ResourceType}/{LocalRulestackResource.Data.Name}/localrules/{priority}"), Is.True);
            Assert.Throws<ArgumentException>(() => LocalRulestackRuleResource.ValidateResourceId(ResGroup.Data.Id));
        }

        [TestCase]
        [RecordedTest]
        public void Data()
        {
            Assert.That(LocalRulesResource.HasData, Is.True);
            Assert.NotNull(LocalRulesResource.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            LocalRulestackRuleData updatedData = LocalRulesResource.Data;
            updatedData.Description = "Updated description for local rules test";
            LocalRulestackRuleResource updatedResource = (await LocalRulesResource.UpdateAsync(WaitUntil.Completed, updatedData)).Value;

            Assert.That(updatedResource.Data.Description, Is.EqualTo("Updated description for local rules test"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await LocalRulesResource.UpdateAsync(WaitUntil.Completed, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetCounters()
        {
            FirewallRuleCounter counter = (await LocalRulesResource.GetCountersAsync()).Value;
            Assert.IsNotNull(counter);
            Assert.That(LocalRulesResource.Data.RuleName, Is.EqualTo(counter.RuleName));
            Assert.That(LocalRulestackResource.Data.Name, Is.EqualTo(counter.RuleStackName));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackRuleResource resource = await LocalRulestackResource.GetLocalRulestackRuleAsync("1000000");
            Assert.NotNull(resource);
            Assert.That(LocalRulesResource.Data.RuleName, Is.EqualTo(resource.Data.RuleName));
        }
    }
}
