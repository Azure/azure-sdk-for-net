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
    public class LocalRulesResourceCollectionTests : PaloAltoNetworksNgfwManagementTestBase
    {
        protected ResourceGroupResource DefaultResGroup { get; set; }
        protected LocalRulestackRuleListResource DefaultResource1 { get; set; }
        protected LocalRulestackResource LocalRulestack { get; set; }
        public LocalRulesResourceCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public LocalRulesResourceCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                DefaultResGroup = await DefaultSubscription.GetResourceGroupAsync("dotnetSdkTest-infra-rg");
                LocalRulestack = (await DefaultResGroup.GetLocalRulestacks().GetAsync("dotnetSdkTest-default-1-lrs")).Value;
                DefaultResource1 = await LocalRulestack.GetLocalRulestackRuleListAsync("1000000");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string priority = IsAsync ? "1" : "2";
            LocalRulestackRuleListData data = getLocalRulestackRuleListData(priority);
            var response = await LocalRulestack.GetLocalRulestackRuleLists().CreateOrUpdateAsync(WaitUntil.Completed, priority, data);
            LocalRulestackRuleListResource rule = response.Value;
            Assert.IsTrue((data.RuleName).Equals(rule.Data.RuleName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = (await LocalRulestack.GetLocalRulestackRuleLists().CreateOrUpdateAsync(WaitUntil.Completed, "3", null)).Value);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            LocalRulestackRuleListCollection collection = LocalRulestack.GetLocalRulestackRuleLists();
            LocalRulestackRuleListResource rulesResource = await collection.GetAsync(DefaultResource1.Data.Priority.ToString());
            Assert.IsNotNull(rulesResource);
            Assert.AreEqual(rulesResource.Data.RuleName, DefaultResource1.Data.RuleName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            LocalRulestackRuleListCollection collection = LocalRulestack.GetLocalRulestackRuleLists();
            Assert.IsTrue(await collection.ExistsAsync(DefaultResource1.Data.Priority.ToString()));
            Assert.IsFalse(await collection.ExistsAsync("999"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            LocalRulestackRuleListCollection collection = LocalRulestack.GetLocalRulestackRuleLists();
            int count = 0;
            await foreach (LocalRulestackRuleListResource lrs in collection.GetAllAsync())
            {
                count++;
            }

            Assert.AreEqual(count, 3);
        }

        private LocalRulestackRuleListData getLocalRulestackRuleListData(string priority)
        {
            LocalRulestackRuleListData data = new LocalRulestackRuleListData($"dotnetSdkTest-rule-{priority}")
            {
                ETag = new ETag("c18e6eef-ba3e-49ee-8a85-2b36c863a9d0"),
                Description = "description of local rule",
                RuleState = RulestackStateType.Disabled,
                Source = new SourceAddressInfo()
                {
                    Cidrs =
{
"any"
},
                    Countries =
{
},
                    Feeds =
{
},
                    PrefixLists =
{
},
                },
                NegateSource = FirewallBooleanType.False,
                Destination = new DestinationAddressInfo()
                {
                    Cidrs =
{
"any"
},
                    Countries =
{
},
                    Feeds =
{
},
                    PrefixLists =
{
},
                    FqdnLists =
{
},
                },
                NegateDestination = FirewallBooleanType.False,
                Applications =
{
"any"
},
                Protocol = "any",
                ActionType = RulestackActionType.Allow,
                EnableLogging = RulestackStateType.Enabled,
                DecryptionRuleType = DecryptionRuleType.None
                };
            return data;
        }
    }
}
