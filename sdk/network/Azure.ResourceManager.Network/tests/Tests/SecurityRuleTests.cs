// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class SecurityRuleTests : NetworkTestsManagementClientBase
    {
        public SecurityRuleTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task SecurityRuleWithRulesApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkSecurityGroups");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            string securityRule1 = Recording.GenerateAssetName("azsmnet");
            string securityRule2 = Recording.GenerateAssetName("azsmnet");
            string destinationPortRange = "123-3500";

            NetworkSecurityGroup networkSecurityGroup = new NetworkSecurityGroup()
            {
                Location = location,
                SecurityRules = new List<SecurityRule>()
                {
                    new SecurityRule()
                    {
                        Name = securityRule1,
                        Access = SecurityRuleAccess.Allow,
                        Description = "Test security rule",
                        DestinationAddressPrefix = "*",
                        DestinationPortRange = destinationPortRange,
                        Direction = SecurityRuleDirection.Inbound,
                        Priority = 500,
                        Protocol = SecurityRuleProtocol.Tcp,
                        SourceAddressPrefix = "*",
                        SourcePortRange = "655"
                    }
                }
            };

            // Put Nsg
            NetworkSecurityGroupsCreateOrUpdateOperation putNsgResponseOperation = await NetworkManagementClient.NetworkSecurityGroups.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroup> putNsgResponse = await WaitForCompletionAsync(putNsgResponseOperation);
            Assert.AreEqual("Succeeded", putNsgResponse.Value.ProvisioningState.ToString());

            // Get NSG
            Response<NetworkSecurityGroup> getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);
            Assert.AreEqual(networkSecurityGroupName, getNsgResponse.Value.Name);

            // Get SecurityRule
            Response<SecurityRule> getSecurityRuleResponse = await NetworkManagementClient.SecurityRules.GetAsync(resourceGroupName, networkSecurityGroupName, securityRule1);
            Assert.AreEqual(securityRule1, getSecurityRuleResponse.Value.Name);

            CompareSecurityRule(getNsgResponse.Value.SecurityRules[0], getSecurityRuleResponse);

            // Add a new security rule
            SecurityRule SecurityRule = new SecurityRule()
            {
                Name = securityRule2,
                Access = SecurityRuleAccess.Deny,
                Description = "Test outbound security rule",
                DestinationAddressPrefix = "*",
                DestinationPortRange = destinationPortRange,
                Direction = SecurityRuleDirection.Outbound,
                Priority = 501,
                Protocol = SecurityRuleProtocol.Udp,
                SourceAddressPrefix = "*",
                SourcePortRange = "656",
            };

            SecurityRulesCreateOrUpdateOperation putSecurityRuleResponseOperation = await NetworkManagementClient.SecurityRules.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, securityRule2, SecurityRule);
            Response<SecurityRule> putSecurityRuleResponse = await WaitForCompletionAsync(putSecurityRuleResponseOperation);
            Assert.AreEqual("Succeeded", putSecurityRuleResponse.Value.ProvisioningState.ToString());

            // Get NSG
            getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);

            // Get the SecurityRule2
            Response<SecurityRule> getSecurityRule2Response = await NetworkManagementClient.SecurityRules.GetAsync(resourceGroupName, networkSecurityGroupName, securityRule2);
            Assert.AreEqual(securityRule2, getSecurityRule2Response.Value.Name);

            // Verify the security rule
            Assert.AreEqual(SecurityRuleAccess.Deny, getSecurityRule2Response.Value.Access);
            Assert.AreEqual("Test outbound security rule", getSecurityRule2Response.Value.Description);
            Assert.AreEqual("*", getSecurityRule2Response.Value.DestinationAddressPrefix);
            Assert.AreEqual(destinationPortRange, getSecurityRule2Response.Value.DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Outbound, getSecurityRule2Response.Value.Direction);
            Assert.AreEqual(501, getSecurityRule2Response.Value.Priority);
            Assert.AreEqual(SecurityRuleProtocol.Udp, getSecurityRule2Response.Value.Protocol);
            Assert.AreEqual("Succeeded", getSecurityRule2Response.Value.ProvisioningState.ToString());
            Assert.AreEqual("*", getSecurityRule2Response.Value.SourceAddressPrefix);
            Assert.AreEqual("656", getSecurityRule2Response.Value.SourcePortRange);

            CompareSecurityRule(getNsgResponse.Value.SecurityRules[1], getSecurityRule2Response);

            // List all SecurityRules
            AsyncPageable<SecurityRule> getsecurityRulesAP = NetworkManagementClient.SecurityRules.ListAsync(resourceGroupName, networkSecurityGroupName);
            List<SecurityRule> getsecurityRules = await getsecurityRulesAP.ToEnumerableAsync();
            Assert.AreEqual(2, getsecurityRules.Count());
            CompareSecurityRule(getNsgResponse.Value.SecurityRules[0], getsecurityRules.ElementAt(0));
            CompareSecurityRule(getNsgResponse.Value.SecurityRules[1], getsecurityRules.ElementAt(1));

            // Delete a SecurityRule
            await NetworkManagementClient.SecurityRules.StartDeleteAsync(resourceGroupName, networkSecurityGroupName, securityRule2);

            getsecurityRulesAP = NetworkManagementClient.SecurityRules.ListAsync(resourceGroupName, networkSecurityGroupName);
            getsecurityRules = await getsecurityRulesAP.ToEnumerableAsync();
            Has.One.EqualTo(getsecurityRules);

            // Delete NSG
            await NetworkManagementClient.NetworkSecurityGroups.StartDeleteAsync(resourceGroupName, networkSecurityGroupName);

            // List NSG
            AsyncPageable<NetworkSecurityGroup> listNsgResponseAP = NetworkManagementClient.NetworkSecurityGroups.ListAsync(resourceGroupName);
            List<NetworkSecurityGroup> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }

        private void CompareSecurityRule(SecurityRule rule1, SecurityRule rule2)
        {
            Assert.AreEqual(rule1.Name, rule2.Name);
            Assert.AreEqual(rule1.Etag, rule2.Etag);
            Assert.AreEqual(rule1.Access, rule2.Access);
            Assert.AreEqual(rule1.Description, rule2.Description);
            Assert.AreEqual(rule1.DestinationAddressPrefix, rule2.DestinationAddressPrefix);
            Assert.AreEqual(rule1.DestinationPortRange, rule2.DestinationPortRange);
            Assert.AreEqual(rule1.Direction, rule2.Direction);
            Assert.AreEqual(rule1.Protocol, rule2.Protocol);
            Assert.AreEqual(rule1.ProvisioningState, rule2.ProvisioningState);
            Assert.AreEqual(rule1.SourceAddressPrefix, rule2.SourceAddressPrefix);
            Assert.AreEqual(rule1.SourcePortRange, rule2.SourcePortRange);
        }
    }
}
