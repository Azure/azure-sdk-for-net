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
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
    public class NetworkSecurityGroupTests : NetworkServiceClientTestBase
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

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityGroupApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            var networkSecurityGroup = new NetworkSecurityGroupData() { Location = location, };

            // Put Nsg
            var networkSecurityGroupContainer = resourceGroup.GetNetworkSecurityGroups();
            var putNsgResponseOperation = await networkSecurityGroupContainer.CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroup> putNsgResponse = await putNsgResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putNsgResponse.Value.Data.ProvisioningState.ToString());

            // Get NSG
            Response<NetworkSecurityGroup> getNsgResponse = await networkSecurityGroupContainer.GetAsync(networkSecurityGroupName);
            Assert.AreEqual(networkSecurityGroupName, getNsgResponse.Value.Data.Name);
            Assert.NotNull(getNsgResponse.Value.Data.ResourceGuid);
            Assert.AreEqual(6, getNsgResponse.Value.Data.DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", getNsgResponse.Value.Data.DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", getNsgResponse.Value.Data.DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", getNsgResponse.Value.Data.DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", getNsgResponse.Value.Data.DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", getNsgResponse.Value.Data.DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", getNsgResponse.Value.Data.DefaultSecurityRules[5].Name);

            // Verify a default security rule
            Assert.AreEqual(SecurityRuleAccess.Allow, getNsgResponse.Value.Data.DefaultSecurityRules[0].Access);
            Assert.AreEqual("Allow inbound traffic from all VMs in VNET", getNsgResponse.Value.Data.DefaultSecurityRules[0].Description);
            Assert.AreEqual("VirtualNetwork", getNsgResponse.Value.Data.DefaultSecurityRules[0].DestinationAddressPrefix);
            Assert.AreEqual("*", getNsgResponse.Value.Data.DefaultSecurityRules[0].DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Inbound, getNsgResponse.Value.Data.DefaultSecurityRules[0].Direction);
            Assert.AreEqual(65000, getNsgResponse.Value.Data.DefaultSecurityRules[0].Priority);
            Assert.AreEqual(SecurityRuleProtocol.Asterisk, getNsgResponse.Value.Data.DefaultSecurityRules[0].Protocol);
            Assert.AreEqual("Succeeded", getNsgResponse.Value.Data.DefaultSecurityRules[0].ProvisioningState.ToString());
            Assert.AreEqual("VirtualNetwork", getNsgResponse.Value.Data.DefaultSecurityRules[0].SourceAddressPrefix);
            Assert.AreEqual("*", getNsgResponse.Value.Data.DefaultSecurityRules[0].SourcePortRange);

            // List NSG
            AsyncPageable<NetworkSecurityGroup> listNsgResponseAP = networkSecurityGroupContainer.GetAllAsync();
            List<NetworkSecurityGroup> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.AreEqual(networkSecurityGroupName, listNsgResponse.First().Data.Name);
            Assert.AreEqual(6, listNsgResponse.First().Data.DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", listNsgResponse.First().Data.DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", listNsgResponse.First().Data.DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", listNsgResponse.First().Data.DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", listNsgResponse.First().Data.DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", listNsgResponse.First().Data.DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", listNsgResponse.First().Data.DefaultSecurityRules[5].Name);
            Assert.AreEqual(getNsgResponse.Value.Data.Etag, listNsgResponse.First().Data.Etag);

            // List NSG in a subscription
            AsyncPageable<NetworkSecurityGroup> listNsgSubsciptionResponseAP = ArmClient.DefaultSubscription.GetNetworkSecurityGroupsAsync();
            List<NetworkSecurityGroup> listNsgSubsciptionResponse = await listNsgSubsciptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNsgSubsciptionResponse);

            // Delete NSG
            await putNsgResponse.Value.DeleteAsync();

            // List NSG
            listNsgResponseAP = networkSecurityGroupContainer.GetAllAsync();
            listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityGroupWithRulesApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            string securityRule1 = Recording.GenerateAssetName("azsmnet");
            string securityRule2 = Recording.GenerateAssetName("azsmnet");

            string destinationPortRange = "123-3500";

            var networkSecurityGroup = new NetworkSecurityGroupData()
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
            Assert.AreEqual(6, getNsgResponse.Value.Data.DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", getNsgResponse.Value.Data.DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", getNsgResponse.Value.Data.DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", getNsgResponse.Value.Data.DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", getNsgResponse.Value.Data.DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", getNsgResponse.Value.Data.DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", getNsgResponse.Value.Data.DefaultSecurityRules[5].Name);

            // Verify the security rule
            Assert.AreEqual(SecurityRuleAccess.Allow, getNsgResponse.Value.Data.SecurityRules[0].Access);
            Assert.AreEqual("Test security rule", getNsgResponse.Value.Data.SecurityRules[0].Description);
            Assert.AreEqual("*", getNsgResponse.Value.Data.SecurityRules[0].DestinationAddressPrefix);
            Assert.AreEqual(destinationPortRange, getNsgResponse.Value.Data.SecurityRules[0].DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Inbound, getNsgResponse.Value.Data.SecurityRules[0].Direction);
            Assert.AreEqual(500, getNsgResponse.Value.Data.SecurityRules[0].Priority);
            Assert.AreEqual(SecurityRuleProtocol.Tcp, getNsgResponse.Value.Data.SecurityRules[0].Protocol);
            Assert.AreEqual("Succeeded", getNsgResponse.Value.Data.SecurityRules[0].ProvisioningState.ToString());
            Assert.AreEqual("*", getNsgResponse.Value.Data.SecurityRules[0].SourceAddressPrefix);
            Assert.AreEqual("655", getNsgResponse.Value.Data.SecurityRules[0].SourcePortRange);

            // List NSG
            AsyncPageable<NetworkSecurityGroup> listNsgResponseAP = networkSecurityGroupContainer.GetAllAsync();
            List<NetworkSecurityGroup> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listNsgResponse);
            Assert.AreEqual(networkSecurityGroupName, listNsgResponse.First().Data.Name);
            Assert.AreEqual(6, listNsgResponse.First().Data.DefaultSecurityRules.Count);
            Assert.AreEqual("AllowVnetInBound", listNsgResponse.First().Data.DefaultSecurityRules[0].Name);
            Assert.AreEqual("AllowAzureLoadBalancerInBound", listNsgResponse.First().Data.DefaultSecurityRules[1].Name);
            Assert.AreEqual("DenyAllInBound", listNsgResponse.First().Data.DefaultSecurityRules[2].Name);
            Assert.AreEqual("AllowVnetOutBound", listNsgResponse.First().Data.DefaultSecurityRules[3].Name);
            Assert.AreEqual("AllowInternetOutBound", listNsgResponse.First().Data.DefaultSecurityRules[4].Name);
            Assert.AreEqual("DenyAllOutBound", listNsgResponse.First().Data.DefaultSecurityRules[5].Name);
            Assert.AreEqual(getNsgResponse.Value.Data.Etag, listNsgResponse.First().Data.Etag);

            // List NSG in a subscription
            AsyncPageable<NetworkSecurityGroup> listNsgSubsciptionResponseAP = ArmClient.DefaultSubscription.GetNetworkSecurityGroupsAsync();
            List<NetworkSecurityGroup> listNsgSubsciptionResponse = await listNsgSubsciptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNsgSubsciptionResponse);

            // Add a new security rule
            var SecurityRule = new SecurityRuleData()
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

            putNsgResponseOperation = await networkSecurityGroupContainer.CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroup);
            await putNsgResponseOperation.WaitForCompletionAsync();;
            // Get NSG
            getNsgResponse = await networkSecurityGroupContainer.GetAsync(networkSecurityGroupName);

            // Verify the security rule
            Assert.AreEqual(SecurityRuleAccess.Deny, getNsgResponse.Value.Data.SecurityRules[1].Access);
            Assert.AreEqual("Test outbound security rule", getNsgResponse.Value.Data.SecurityRules[1].Description);
            Assert.AreEqual("*", getNsgResponse.Value.Data.SecurityRules[1].DestinationAddressPrefix);
            Assert.AreEqual(destinationPortRange, getNsgResponse.Value.Data.SecurityRules[1].DestinationPortRange);
            Assert.AreEqual(SecurityRuleDirection.Outbound, getNsgResponse.Value.Data.SecurityRules[1].Direction);
            Assert.AreEqual(501, getNsgResponse.Value.Data.SecurityRules[1].Priority);
            Assert.AreEqual(SecurityRuleProtocol.Udp, getNsgResponse.Value.Data.SecurityRules[1].Protocol);
            Assert.AreEqual("Succeeded", getNsgResponse.Value.Data.SecurityRules[1].ProvisioningState.ToString());
            Assert.AreEqual("*", getNsgResponse.Value.Data.SecurityRules[1].SourceAddressPrefix);
            Assert.AreEqual("656", getNsgResponse.Value.Data.SecurityRules[1].SourcePortRange);

            // List Default Security Groups
            AsyncPageable<SecurityRuleData> listDefaultSecurityGroupsAP = getNsgResponse.Value.GetDefaultSecurityRulesAsync();
            List<SecurityRuleData> listDefaultSecurityGroups = await listDefaultSecurityGroupsAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listDefaultSecurityGroups);

            // Get Defaul Security Group
            // TODO: ADO 5975
            //Response<SecurityRuleData> getDefaultSecurityGroups = await getNsgResponse.Value.GetDefaultSecurityRuleAsync();
            //Assert.AreEqual(listDefaultSecurityGroups.First().Name, getDefaultSecurityGroups.Value.Name);

            // Delete NSG
            await putNsgResponse.Value.DeleteAsync();

            // List NSG
            listNsgResponseAP = networkSecurityGroupContainer.GetAllAsync();
            listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }
    }
}
