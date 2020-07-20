// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Threading;
using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class FirewallRuleOperationTests : SynapseManagementTestBase
    {
        [Fact]
        public void TestFirewallRule()
        {
            TestInitialize();

            // create workspace
            string workspaceName = TestUtilities.GenerateName("synapsesdkworkspace");
            var createWorkspaceParams = CommonData.PrepareWorkspaceCreateParams();
            var workspaceCreate = SynapseClient.Workspaces.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, createWorkspaceParams);
            Assert.Equal(CommonTestFixture.WorkspaceType, workspaceCreate.Type);
            Assert.Equal(workspaceName, workspaceCreate.Name);
            Assert.Equal(CommonData.Location, workspaceCreate.Location);

            // get workspace
            for (int i = 0; i < 60; i++)
            {
                var workspaceGet = SynapseClient.Workspaces.Get(CommonData.ResourceGroupName, workspaceName);
                if (workspaceGet.ProvisioningState.Equals("Succeeded"))
                {
                    Assert.Equal(CommonTestFixture.WorkspaceType, workspaceGet.Type);
                    Assert.Equal(workspaceName, workspaceGet.Name);
                    Assert.Equal(CommonData.Location, workspaceGet.Location);
                    break;
                }

                Thread.Sleep(30000);
                Assert.True(i < 60, "Synapse Workspace is not in succeeded state even after 30 min.");
            }

            // create firewall rule
            string firewallRuleName = TestUtilities.GenerateName("firewallrulesdk");
            var firewallRuleCreateParams = CommonData.PrepareFirewallRuleParams(CommonData.StartIpAddress, CommonData.EndIpAddress);
            var firewallRuleCreate = SynapseClient.IpFirewallRules.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, firewallRuleName, firewallRuleCreateParams);
            Assert.Equal(CommonData.StartIpAddress, firewallRuleCreate.StartIpAddress);
            Assert.Equal(CommonData.EndIpAddress, firewallRuleCreate.EndIpAddress);

            // get firewall
            var firewallRuleGet = SynapseClient.IpFirewallRules.Get(CommonData.ResourceGroupName, workspaceName, firewallRuleName);
            Assert.Equal("Succeeded", firewallRuleGet.ProvisioningState);
            Assert.Equal(CommonData.StartIpAddress, firewallRuleCreate.StartIpAddress);
            Assert.Equal(CommonData.EndIpAddress, firewallRuleCreate.EndIpAddress);

            // update firewall
            var firewallRuleUpdateParams = CommonData.PrepareFirewallRuleParams(CommonData.UpdatedStartIpAddress, CommonData.UpdatedEndIpAddress);
            var firewallRuleUpdate = SynapseClient.IpFirewallRules.CreateOrUpdate(CommonData.ResourceGroupName, workspaceName, firewallRuleName, firewallRuleUpdateParams);
            Assert.Equal(CommonData.UpdatedStartIpAddress, firewallRuleUpdate.StartIpAddress);
            Assert.Equal(CommonData.UpdatedEndIpAddress, firewallRuleUpdate.EndIpAddress);

            // delete firewall
            SynapseClient.IpFirewallRules.Delete(CommonData.ResourceGroupName, workspaceName, firewallRuleName);
            var ex = Assert.Throws<ErrorContractException>(() => SynapseClient.IpFirewallRules.Get(CommonData.ResourceGroupName, workspaceName, firewallRuleName));
            Assert.Equal("Operation returned an invalid status code 'NotFound'", ex.Message);
        }
    }
}
