// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
    public class SecurityRuleTests : NetworkServiceClientTestBase
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

        [Test]
        [RecordedTest]
        public async Task SecurityRuleWithRulesApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            string securityRule1 = Recording.GenerateAssetName("azsmnet");
            string securityRule2 = Recording.GenerateAssetName("azsmnet");
            string destinationPortRange = "123-3500";

            NetworkSecurityGroupData networkSecurityGroup = new NetworkSecurityGroupData()
            {
                Location = location,
                SecurityRules = {
                    new SecurityRuleData()
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
            var networkSecurityGroupContainer = resourceGroup.GetNetworkSecurityGroups();
            var putNsgResponseOperation = await networkSecurityGroupContainer.CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroup> putNsgResponse = await putNsgResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putNsgResponse.Value.Data.ProvisioningState.ToString());

            // Get NSG
            Response<NetworkSecurityGroup> getNsgResponse = await networkSecurityGroupContainer.GetAsync(networkSecurityGroupName);
            Assert.AreEqual(networkSecurityGroupName, getNsgResponse.Value.Data.Name);

            // Get SecurityRule
            Response<SecurityRule> getSecurityRuleResponse = await getNsgResponse.Value.GetSecurityRules().GetAsync(securityRule1);
            Assert.AreEqual(securityRule1, getSecurityRuleResponse.Value.Data.Name);

            CompareSecurityRule(getNsgResponse.Value.Data.SecurityRules[0], getSecurityRuleResponse.Value.Data);

            // Add a new security rule
            var securityRule = new SecurityRuleData()
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

            var putSecurityRuleResponseOperation = await getNsgResponse.Value.GetSecurityRules().CreateOrUpdateAsync(securityRule2, securityRule);
            Response<SecurityRule> putSecurityRuleResponse = await putSecurityRuleResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putSecurityRuleResponse.Value.Data.ProvisioningState.ToString());

            // Get NSG
            getNsgResponse = await networkSecurityGroupContainer.GetAsync(networkSecurityGroupName);

            // Get the SecurityRule2
            Response<SecurityRule> getSecurityRule2Response = await getNsgResponse.Value.GetSecurityRules().GetAsync(securityRule2);
            Assert.AreEqual(securityRule2, getSecurityRule2Response.Value.Data.Name);

            // Verify the security rule
            Assert.AreEqual(SecurityRuleAccess.Deny, getSecurityRule2Response.Value.Data.Access);
            Assert.AreEqual("Test outbound security rule", getSecurityRule2Response.Value.Data.Description);
            Assert.AreEqual("*", getSecurityRule2Response.Value.Data.DestinationAddressPrefix);
            Assert.AreEqual(destinationPortRange, getSecurityRule2Response.Value.Data.DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Outbound, getSecurityRule2Response.Value.Data.Direction);
            Assert.AreEqual(501, getSecurityRule2Response.Value.Data.Priority);
            Assert.AreEqual(SecurityRuleProtocol.Udp, getSecurityRule2Response.Value.Data.Protocol);
            Assert.AreEqual("Succeeded", getSecurityRule2Response.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual("*", getSecurityRule2Response.Value.Data.SourceAddressPrefix);
            Assert.AreEqual("656", getSecurityRule2Response.Value.Data.SourcePortRange);

            CompareSecurityRule(getNsgResponse.Value.Data.SecurityRules[1], getSecurityRule2Response.Value.Data);

            // List all SecurityRules
            AsyncPageable<SecurityRule> getsecurityRulesAP = getNsgResponse.Value.GetSecurityRules().GetAllAsync();
            List<SecurityRule> getsecurityRules = await getsecurityRulesAP.ToEnumerableAsync();
            Assert.AreEqual(2, getsecurityRules.Count());
            CompareSecurityRule(getNsgResponse.Value.Data.SecurityRules[0], getsecurityRules.ElementAt(0).Data);
            CompareSecurityRule(getNsgResponse.Value.Data.SecurityRules[1], getsecurityRules.ElementAt(1).Data);

            // Delete a SecurityRule
            await getSecurityRule2Response.Value.DeleteAsync();

            getsecurityRulesAP = getNsgResponse.Value.GetSecurityRules().GetAllAsync();
            getsecurityRules = await getsecurityRulesAP.ToEnumerableAsync();
            Has.One.EqualTo(getsecurityRules);

            // Delete NSG
            await getNsgResponse.Value.DeleteAsync();

            // List NSG
            AsyncPageable<NetworkSecurityGroup> listNsgResponseAP = networkSecurityGroupContainer.GetAllAsync();
            List<NetworkSecurityGroup> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }

        private void CompareSecurityRule(SecurityRuleData rule1, SecurityRuleData rule2)
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
