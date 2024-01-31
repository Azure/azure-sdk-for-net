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
            Assert.AreEqual(CommonData.StartIpAddress, firewallRuleCreate.Data.StartIPAddress);
            Assert.AreEqual(CommonData.EndIpAddress, firewallRuleCreate.Data.EndIPAddress);

            // get firewall rule
            var firewallRuleGet = (await firewallRuleCollection.GetAsync(firewallRuleName)).Value;
            Assert.AreEqual(SynapseProvisioningState.Succeeded, firewallRuleGet.Data.ProvisioningState);
            Assert.AreEqual(CommonData.StartIpAddress, firewallRuleCreate.Data.StartIPAddress);
            Assert.AreEqual(CommonData.EndIpAddress, firewallRuleCreate.Data.EndIPAddress);

            // update firewall rule
            var firewallRuleUpdateParams = CommonData.PrepareFirewallRuleParams(CommonData.UpdatedStartIpAddress, CommonData.UpdatedEndIpAddress);
            var firewallRuleUpdate = (await firewallRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, firewallRuleName, firewallRuleUpdateParams)).Value;
            Assert.AreEqual(CommonData.UpdatedStartIpAddress, firewallRuleUpdate.Data.StartIPAddress);
            Assert.AreEqual(CommonData.UpdatedEndIpAddress, firewallRuleUpdate.Data.EndIPAddress);

            // list firewall rules from workspace
            var firewallRuleFromWorkspace = firewallRuleCollection.GetAllAsync();
            var firewallRuleList = await firewallRuleFromWorkspace.ToEnumerableAsync();
            var firewallRuleCount = firewallRuleList.Count;
            var firewallRule = firewallRuleList.Single(rule => rule.Id.Name == firewallRuleName);

            Assert.True(firewallRule != null, string.Format("firewall Rule created earlier is not found when listing all in workspace {0}", workspaceName));

            // delete firewall rule
            await firewallRule.DeleteAsync(WaitUntil.Completed);
            firewallRuleList = await firewallRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(firewallRuleCount - 1, firewallRuleList.Count);
        }
    }
}
