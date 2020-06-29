// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class NetworkSecurityGroupTests : NetworkTestsManagementClientBase
    {
        public NetworkSecurityGroupTests(bool isAsync) : base(isAsync)
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
        public async Task NetworkSecurityGroupApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkSecurityGroups");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            NetworkSecurityGroup networkSecurityGroup = new NetworkSecurityGroup() { Location = location, };

            // Put Nsg
            NetworkSecurityGroupsCreateOrUpdateOperation putNsgResponseOperation = await NetworkManagementClient.NetworkSecurityGroups.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroup> putNsgResponse = await WaitForCompletionAsync(putNsgResponseOperation);
            Assert.AreEqual("Succeeded", putNsgResponse.Value.ProvisioningState.ToString());

            // Get NSG
            Response<NetworkSecurityGroup> getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);
            Assert.AreEqual(networkSecurityGroupName, getNsgResponse.Value.Name);
            Assert.NotNull(getNsgResponse.Value.ResourceGuid);
            Assert.AreEqual(6, getNsgResponse.Value.DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", getNsgResponse.Value.DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", getNsgResponse.Value.DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", getNsgResponse.Value.DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", getNsgResponse.Value.DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", getNsgResponse.Value.DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", getNsgResponse.Value.DefaultSecurityRules[5].Name);

            // Verify a default security rule
            Assert.AreEqual(SecurityRuleAccess.Allow, getNsgResponse.Value.DefaultSecurityRules[0].Access);
            Assert.AreEqual("Allow inbound traffic from all VMs in VNET", getNsgResponse.Value.DefaultSecurityRules[0].Description);
            Assert.AreEqual("VirtualNetwork", getNsgResponse.Value.DefaultSecurityRules[0].DestinationAddressPrefix);
            Assert.AreEqual("*", getNsgResponse.Value.DefaultSecurityRules[0].DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Inbound, getNsgResponse.Value.DefaultSecurityRules[0].Direction);
            Assert.AreEqual(65000, getNsgResponse.Value.DefaultSecurityRules[0].Priority);
            Assert.AreEqual(SecurityRuleProtocol.Asterisk, getNsgResponse.Value.DefaultSecurityRules[0].Protocol);
            Assert.AreEqual("Succeeded", getNsgResponse.Value.DefaultSecurityRules[0].ProvisioningState.ToString());
            Assert.AreEqual("VirtualNetwork", getNsgResponse.Value.DefaultSecurityRules[0].SourceAddressPrefix);
            Assert.AreEqual("*", getNsgResponse.Value.DefaultSecurityRules[0].SourcePortRange);

            // List NSG
            AsyncPageable<NetworkSecurityGroup> listNsgResponseAP = NetworkManagementClient.NetworkSecurityGroups.ListAsync(resourceGroupName);
            List<NetworkSecurityGroup> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.AreEqual(networkSecurityGroupName, listNsgResponse.First().Name);
            Assert.AreEqual(6, listNsgResponse.First().DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", listNsgResponse.First().DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", listNsgResponse.First().DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", listNsgResponse.First().DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", listNsgResponse.First().DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", listNsgResponse.First().DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", listNsgResponse.First().DefaultSecurityRules[5].Name);
            Assert.AreEqual(getNsgResponse.Value.Etag, listNsgResponse.First().Etag);

            // List NSG in a subscription
            AsyncPageable<NetworkSecurityGroup> listNsgSubsciptionResponseAP = NetworkManagementClient.NetworkSecurityGroups.ListAllAsync();
            List<NetworkSecurityGroup> listNsgSubsciptionResponse = await listNsgSubsciptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNsgSubsciptionResponse);

            // Delete NSG
            await NetworkManagementClient.NetworkSecurityGroups.StartDeleteAsync(resourceGroupName, networkSecurityGroupName);

            // List NSG
            listNsgResponseAP = NetworkManagementClient.NetworkSecurityGroups.ListAsync(resourceGroupName);
            listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }

        [Test]
        public async Task NetworkSecurityGroupWithRulesApiTest()
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
            Assert.AreEqual(6, getNsgResponse.Value.DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", getNsgResponse.Value.DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", getNsgResponse.Value.DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", getNsgResponse.Value.DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", getNsgResponse.Value.DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", getNsgResponse.Value.DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", getNsgResponse.Value.DefaultSecurityRules[5].Name);

            // Verify the security rule
            Assert.AreEqual(SecurityRuleAccess.Allow, getNsgResponse.Value.SecurityRules[0].Access);
            Assert.AreEqual("Test security rule", getNsgResponse.Value.SecurityRules[0].Description);
            Assert.AreEqual("*", getNsgResponse.Value.SecurityRules[0].DestinationAddressPrefix);
            Assert.AreEqual(destinationPortRange, getNsgResponse.Value.SecurityRules[0].DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Inbound, getNsgResponse.Value.SecurityRules[0].Direction);
            Assert.AreEqual(500, getNsgResponse.Value.SecurityRules[0].Priority);
            Assert.AreEqual(SecurityRuleProtocol.Tcp, getNsgResponse.Value.SecurityRules[0].Protocol);
            Assert.AreEqual("Succeeded", getNsgResponse.Value.SecurityRules[0].ProvisioningState.ToString());
            Assert.AreEqual("*", getNsgResponse.Value.SecurityRules[0].SourceAddressPrefix);
            Assert.AreEqual("655", getNsgResponse.Value.SecurityRules[0].SourcePortRange);

            // List NSG
            AsyncPageable<NetworkSecurityGroup> listNsgResponseAP = NetworkManagementClient.NetworkSecurityGroups.ListAsync(resourceGroupName);
            List<NetworkSecurityGroup> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listNsgResponse);
            Assert.AreEqual(networkSecurityGroupName, listNsgResponse.First().Name);
            Assert.AreEqual(6, listNsgResponse.First().DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", listNsgResponse.First().DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", listNsgResponse.First().DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", listNsgResponse.First().DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", listNsgResponse.First().DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", listNsgResponse.First().DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", listNsgResponse.First().DefaultSecurityRules[5].Name);
            Assert.AreEqual(getNsgResponse.Value.Etag, listNsgResponse.First().Etag);

            // List NSG in a subscription
            AsyncPageable<NetworkSecurityGroup> listNsgSubsciptionResponseAP = NetworkManagementClient.NetworkSecurityGroups.ListAllAsync();
            List<NetworkSecurityGroup> listNsgSubsciptionResponse = await listNsgSubsciptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNsgSubsciptionResponse);

            // Add a new security rule
            var SecurityRule = new SecurityRule()
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

            networkSecurityGroup.SecurityRules.Add(SecurityRule);

            putNsgResponseOperation = await NetworkManagementClient.NetworkSecurityGroups.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
            await WaitForCompletionAsync(putNsgResponseOperation);
            // Get NSG
            getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);

            // Verify the security rule
            Assert.AreEqual(SecurityRuleAccess.Deny, getNsgResponse.Value.SecurityRules[1].Access);
            Assert.AreEqual("Test outbound security rule", getNsgResponse.Value.SecurityRules[1].Description);
            Assert.AreEqual("*", getNsgResponse.Value.SecurityRules[1].DestinationAddressPrefix);
            Assert.AreEqual(destinationPortRange, getNsgResponse.Value.SecurityRules[1].DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Outbound, getNsgResponse.Value.SecurityRules[1].Direction);
            Assert.AreEqual(501, getNsgResponse.Value.SecurityRules[1].Priority);
            Assert.AreEqual(SecurityRuleProtocol.Udp, getNsgResponse.Value.SecurityRules[1].Protocol);
            Assert.AreEqual("Succeeded", getNsgResponse.Value.SecurityRules[1].ProvisioningState.ToString());
            Assert.AreEqual("*", getNsgResponse.Value.SecurityRules[1].SourceAddressPrefix);
            Assert.AreEqual("656", getNsgResponse.Value.SecurityRules[1].SourcePortRange);

            // List Default Security Groups
            AsyncPageable<SecurityRule> listDefaultSecurityGroupsAP = NetworkManagementClient.DefaultSecurityRules.ListAsync(resourceGroupName, networkSecurityGroupName);
            List<SecurityRule> listDefaultSecurityGroups = await listDefaultSecurityGroupsAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listDefaultSecurityGroups);

            // Get Defaul Security Group
            Response<SecurityRule> getDefaultSecurityGroups = await NetworkManagementClient.DefaultSecurityRules.GetAsync(resourceGroupName, networkSecurityGroupName, listDefaultSecurityGroups.First().Name);
            Assert.AreEqual(listDefaultSecurityGroups.First().Name, getDefaultSecurityGroups.Value.Name);

            // Delete NSG
            await NetworkManagementClient.NetworkSecurityGroups.StartDeleteAsync(resourceGroupName, networkSecurityGroupName);

            // List NSG
            listNsgResponseAP = NetworkManagementClient.NetworkSecurityGroups.ListAsync(resourceGroupName);
            listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }
    }
}
