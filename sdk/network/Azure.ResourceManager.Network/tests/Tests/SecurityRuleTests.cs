// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [ClientTestFixture(true, "2021-04-01", "2018-11-01")]
    public class SecurityRuleTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public SecurityRuleTests(bool isAsync, string apiVersion)
        : base(isAsync, SecurityRuleResource.ResourceType, apiVersion)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
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
            var networkSecurityGroupCollection = resourceGroup.GetNetworkSecurityGroups();
            var putNsgResponseOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroupResource> putNsgResponse = await putNsgResponseOperation.WaitForCompletionAsync();;
            Assert.That(putNsgResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get NSG
            Response<NetworkSecurityGroupResource> getNsgResponse = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);
            Assert.That(getNsgResponse.Value.Data.Name, Is.EqualTo(networkSecurityGroupName));

            // Get SecurityRule
            Response<SecurityRuleResource> getSecurityRuleResponse = await getNsgResponse.Value.GetSecurityRules().GetAsync(securityRule1);
            Assert.That(getSecurityRuleResponse.Value.Data.Name, Is.EqualTo(securityRule1));

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

            var putSecurityRuleResponseOperation = await getNsgResponse.Value.GetSecurityRules().CreateOrUpdateAsync(WaitUntil.Completed, securityRule2, securityRule);
            Response<SecurityRuleResource> putSecurityRuleResponse = await putSecurityRuleResponseOperation.WaitForCompletionAsync();;
            Assert.That(putSecurityRuleResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get NSG
            getNsgResponse = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);

            // Get the SecurityRule2
            Response<SecurityRuleResource> getSecurityRule2Response = await getNsgResponse.Value.GetSecurityRules().GetAsync(securityRule2);
            Assert.That(getSecurityRule2Response.Value.Data.Name, Is.EqualTo(securityRule2));

            // Verify the security rule
            Assert.That(getSecurityRule2Response.Value.Data.Access, Is.EqualTo(SecurityRuleAccess.Deny));
            Assert.That(getSecurityRule2Response.Value.Data.Description, Is.EqualTo("Test outbound security rule"));
            Assert.That(getSecurityRule2Response.Value.Data.DestinationAddressPrefix, Is.EqualTo("*"));
            Assert.That(getSecurityRule2Response.Value.Data.DestinationPortRange, Is.EqualTo(destinationPortRange));
            Assert.That(getSecurityRule2Response.Value.Data.Direction, Is.EqualTo(SecurityRuleDirection.Outbound));
            Assert.That(getSecurityRule2Response.Value.Data.Priority, Is.EqualTo(501));
            Assert.That(getSecurityRule2Response.Value.Data.Protocol, Is.EqualTo(SecurityRuleProtocol.Udp));
            Assert.That(getSecurityRule2Response.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(getSecurityRule2Response.Value.Data.SourceAddressPrefix, Is.EqualTo("*"));
            Assert.That(getSecurityRule2Response.Value.Data.SourcePortRange, Is.EqualTo("656"));

            CompareSecurityRule(getNsgResponse.Value.Data.SecurityRules[1], getSecurityRule2Response.Value.Data);

            // List all SecurityRules
            AsyncPageable<SecurityRuleResource> getsecurityRulesAP = getNsgResponse.Value.GetSecurityRules().GetAllAsync();
            List<SecurityRuleResource> getsecurityRules = await getsecurityRulesAP.ToEnumerableAsync();
            Assert.That(getsecurityRules.Count(), Is.EqualTo(2));
            CompareSecurityRule(getNsgResponse.Value.Data.SecurityRules[0], getsecurityRules.ElementAt(0).Data);
            CompareSecurityRule(getNsgResponse.Value.Data.SecurityRules[1], getsecurityRules.ElementAt(1).Data);

            // Delete a SecurityRule
            await getSecurityRule2Response.Value.DeleteAsync(WaitUntil.Completed);

            getsecurityRulesAP = getNsgResponse.Value.GetSecurityRules().GetAllAsync();
            getsecurityRules = await getsecurityRulesAP.ToEnumerableAsync();
            Has.One.EqualTo(getsecurityRules);

            // Delete NSG
            await getNsgResponse.Value.DeleteAsync(WaitUntil.Completed);

            // List NSG
            AsyncPageable<NetworkSecurityGroupResource> listNsgResponseAP = networkSecurityGroupCollection.GetAllAsync();
            List<NetworkSecurityGroupResource> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.That(listNsgResponse, Is.Empty);
        }

        private void CompareSecurityRule(SecurityRuleData rule1, SecurityRuleData rule2)
        {
            Assert.That(rule2.Name, Is.EqualTo(rule1.Name));
            Assert.That(rule2.ETag, Is.EqualTo(rule1.ETag));
            Assert.That(rule2.Access, Is.EqualTo(rule1.Access));
            Assert.That(rule2.Description, Is.EqualTo(rule1.Description));
            Assert.That(rule2.DestinationAddressPrefix, Is.EqualTo(rule1.DestinationAddressPrefix));
            Assert.That(rule2.DestinationPortRange, Is.EqualTo(rule1.DestinationPortRange));
            Assert.That(rule2.Direction, Is.EqualTo(rule1.Direction));
            Assert.That(rule2.Protocol, Is.EqualTo(rule1.Protocol));
            Assert.That(rule2.ProvisioningState, Is.EqualTo(rule1.ProvisioningState));
            Assert.That(rule2.SourceAddressPrefix, Is.EqualTo(rule1.SourceAddressPrefix));
            Assert.That(rule2.SourcePortRange, Is.EqualTo(rule1.SourcePortRange));
        }
    }
}
