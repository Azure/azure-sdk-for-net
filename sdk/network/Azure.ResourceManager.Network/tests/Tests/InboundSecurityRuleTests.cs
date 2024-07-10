// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;
using System.Collections.Generic;

namespace Azure.ResourceManager.Network.Tests
{
    public class InboundSecurityRuleTests : NetworkServiceClientTestBase
    {
        private string _resourceGroupName;
        private string _nvaName;
        private string _ruleCollectionName;
        private string _slbipName;
        private ResourceIdentifier _resourceGroupIdentifier;
        private NetworkVirtualApplianceResource _networkVirtualApplianceResource;
        private InboundSecurityRuleData _ruleCollection;
        public InboundSecurityRuleTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            // The setup requires to have an existing Managed NVA, to be able to configure nva Inbound Security Rules.
            ArmClient = GetArmClient();

            // Name of the Resource Group of the existing NVA
            _resourceGroupName = "inbound_sec_rule_nva";

            // Name of NVA already deployed and in succeeded provisioning state
            _nvaName = "inboundnva";

            // Name of the Frontend IP of the SLB to deploy the Inbound Rules
            _slbipName = "slb-2";

            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().GetAsync(_resourceGroupName);
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            var networkVirtualApplianceResponse = await rg.GetNetworkVirtualApplianceAsync(_nvaName);
            _networkVirtualApplianceResource = networkVirtualApplianceResponse.Value;

            // Rule Collection Name
            _ruleCollectionName = "RulePermanent";

            // Inbound Security Rule body
            string ruleName = "inbound";
            string sourceAddressPrefix = "0.0.0.0/0";
            string protocol = "TCP";

            var rule = new InboundSecurityRules()
            {
                Name = ruleName,
                Protocol = protocol,
                SourceAddressPrefix = sourceAddressPrefix
            };
            rule.DestinationPortRanges.Add("8080");
            rule.AppliesOn.Add(_slbipName);

            // Inbound Security Rule Collection Body
            _ruleCollection = new InboundSecurityRuleData();
            _ruleCollection.RuleType = "Permanent";
            _ruleCollection.Rules.Add(rule);
        }

        public async Task<InboundSecurityRuleResource> CreateInboundSecurityRuleAsync()
        {
            var inboundRuleUpdate = await _networkVirtualApplianceResource.GetInboundSecurityRules().CreateOrUpdateAsync(WaitUntil.Completed, _ruleCollectionName, _ruleCollection);
            return inboundRuleUpdate.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdateTest()
        {
            var inboundSecurityRuleCreate = await CreateInboundSecurityRuleAsync();

            Assert.IsNotNull(inboundSecurityRuleCreate);
            Assert.IsNotNull(inboundSecurityRuleCreate.Data);
            Assert.AreEqual(inboundSecurityRuleCreate.Data.Name, _ruleCollectionName);
        }

        [Test]
        [RecordedTest]
        public async Task GetInboundSecurityRuleTest()
        {
            var inboundSecurityRuleCreate = await CreateInboundSecurityRuleAsync();

            var inboundSecurityRule = await _networkVirtualApplianceResource.GetInboundSecurityRuleAsync(_ruleCollectionName);

            Assert.IsNotNull(inboundSecurityRule.Value);
            Assert.AreEqual(inboundSecurityRule.Value.Data.Name, _ruleCollectionName);
        }
    }
}
