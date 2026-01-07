// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Synapse.Models;
using Azure.ResourceManager.Synapse.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Synapse.Tests
{
    public class FirewallRuleOperationTests : SynapseManagementTestBase
    {
        public FirewallRuleOperationTests(bool async): base(async)
        {
        }

        [SetUp]
        public async Task Initialize()
        {
            await TestInitialize();

            await CreateWorkspace();
        }

        [Test]
        [RecordedTest]
        public async Task TestFirewallRule()
        {
            var workspaceName = WorkspaceResource.Data.Name;

            // create firewall rule
            string firewallRuleName = Recording.GenerateAssetName("firewallrulesdk");
            var firewallRuleCreateParams = CommonData.PrepareFirewallRuleParams(CommonData.StartIpAddress, CommonData.EndIpAddress);
            SynapseIPFirewallRuleInfoCollection firewallRuleCollection = WorkspaceResource.GetSynapseIPFirewallRuleInfos();
            var firewallRuleCreate = (await firewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, firewallRuleCreateParams)).Value;
            Assert.That(firewallRuleCreate.Data.StartIPAddress, Is.EqualTo(CommonData.StartIpAddress));
            Assert.That(firewallRuleCreate.Data.EndIPAddress, Is.EqualTo(CommonData.EndIpAddress));

            // get firewall rule
            var firewallRuleGet = (await firewallRuleCollection.GetAsync(firewallRuleName)).Value;
            Assert.That(firewallRuleGet.Data.ProvisioningState, Is.EqualTo(SynapseProvisioningState.Succeeded));
            Assert.That(firewallRuleCreate.Data.StartIPAddress, Is.EqualTo(CommonData.StartIpAddress));
            Assert.That(firewallRuleCreate.Data.EndIPAddress, Is.EqualTo(CommonData.EndIpAddress));

            // update firewall rule
            var firewallRuleUpdateParams = CommonData.PrepareFirewallRuleParams(CommonData.UpdatedStartIpAddress, CommonData.UpdatedEndIpAddress);
            var firewallRuleUpdate = (await firewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, firewallRuleUpdateParams)).Value;
            Assert.That(firewallRuleUpdate.Data.StartIPAddress, Is.EqualTo(CommonData.UpdatedStartIpAddress));
            Assert.That(firewallRuleUpdate.Data.EndIPAddress, Is.EqualTo(CommonData.UpdatedEndIpAddress));

            // list firewall rules from workspace
            var firewallRuleFromWorkspace = firewallRuleCollection.GetAllAsync();
            var firewallRuleList = await firewallRuleFromWorkspace.ToEnumerableAsync();
            var firewallRuleCount = firewallRuleList.Count;
            var firewallRule = firewallRuleList.Single(rule => rule.Id.Name == firewallRuleName);

            Assert.That(firewallRule, Is.Not.EqualTo(null), string.Format("firewall Rule created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete firewall rule
            await firewallRule.DeleteAsync(WaitUntil.Completed);
            firewallRuleList = await firewallRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(firewallRuleList.Count, Is.EqualTo(firewallRuleCount - 1));
        }
    }
}
