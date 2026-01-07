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
    public class NetworkSecurityGroupTests : NetworkServiceClientTestBase
    {
        public NetworkSecurityGroupTests(bool isAsync, string apiVersion)
        : base(isAsync, NetworkSecurityGroupResource.ResourceType, apiVersion)
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
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            var networkSecurityGroup = new NetworkSecurityGroupData() { Location = location, };

            // Put Nsg
            var networkSecurityGroupCollection = resourceGroup.GetNetworkSecurityGroups();
            var putNsgResponseOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroupResource> putNsgResponse = await putNsgResponseOperation.WaitForCompletionAsync();;
            Assert.That(putNsgResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get NSG
            Response<NetworkSecurityGroupResource> getNsgResponse = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);
            Assert.That(getNsgResponse.Value.Data.Name, Is.EqualTo(networkSecurityGroupName));
            Assert.That(getNsgResponse.Value.Data.ResourceGuid, Is.Not.Null);
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules.Count, Is.EqualTo(6));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].Name, Is.EqualTo("AllowVnetInBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[1].Name, Is.EqualTo("AllowAzureLoadBalancerInBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[2].Name, Is.EqualTo("DenyAllInBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[3].Name, Is.EqualTo("AllowVnetOutBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[4].Name, Is.EqualTo("AllowInternetOutBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[5].Name, Is.EqualTo("DenyAllOutBound"));

            // Verify a default security rule
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].Access, Is.EqualTo(SecurityRuleAccess.Allow));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].Description, Is.EqualTo("Allow inbound traffic from all VMs in VNET"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].DestinationAddressPrefix, Is.EqualTo("VirtualNetwork"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].DestinationPortRange, Is.EqualTo("*"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].Direction, Is.EqualTo(SecurityRuleDirection.Inbound));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].Priority, Is.EqualTo(65000));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].Protocol, Is.EqualTo(SecurityRuleProtocol.Asterisk));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].SourceAddressPrefix, Is.EqualTo("VirtualNetwork"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].SourcePortRange, Is.EqualTo("*"));

            // List NSG
            AsyncPageable<NetworkSecurityGroupResource> listNsgResponseAP = networkSecurityGroupCollection.GetAllAsync();
            List<NetworkSecurityGroupResource> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.That(listNsgResponse.First().Data.Name, Is.EqualTo(networkSecurityGroupName));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules.Count, Is.EqualTo(6));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[0].Name, Is.EqualTo("AllowVnetInBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[1].Name, Is.EqualTo("AllowAzureLoadBalancerInBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[2].Name, Is.EqualTo("DenyAllInBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[3].Name, Is.EqualTo("AllowVnetOutBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[4].Name, Is.EqualTo("AllowInternetOutBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[5].Name, Is.EqualTo("DenyAllOutBound"));
            Assert.That(listNsgResponse.First().Data.ETag, Is.EqualTo(getNsgResponse.Value.Data.ETag));

            // List NSG in a subscription
            AsyncPageable<NetworkSecurityGroupResource> listNsgSubsciptionResponseAP = subscription.GetNetworkSecurityGroupsAsync();
            List<NetworkSecurityGroupResource> listNsgSubsciptionResponse = await listNsgSubsciptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNsgSubsciptionResponse);

            // Delete NSG
            await putNsgResponse.Value.DeleteAsync(WaitUntil.Completed);

            // List NSG
            listNsgResponseAP = networkSecurityGroupCollection.GetAllAsync();
            listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }

        [Test]
        [RecordedTest]
        public async Task NetworkSecurityGroupWithRulesApiTest()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
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
            var networkSecurityGroupCollection = resourceGroup.GetNetworkSecurityGroups();
            var putNsgResponseOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroupResource> putNsgResponse = await putNsgResponseOperation.WaitForCompletionAsync();;
            Assert.That(putNsgResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get NSG
            Response<NetworkSecurityGroupResource> getNsgResponse = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);
            Assert.That(getNsgResponse.Value.Data.Name, Is.EqualTo(networkSecurityGroupName));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules.Count, Is.EqualTo(6));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[0].Name, Is.EqualTo("AllowVnetInBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[1].Name, Is.EqualTo("AllowAzureLoadBalancerInBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[2].Name, Is.EqualTo("DenyAllInBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[3].Name, Is.EqualTo("AllowVnetOutBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[4].Name, Is.EqualTo("AllowInternetOutBound"));
            Assert.That(getNsgResponse.Value.Data.DefaultSecurityRules[5].Name, Is.EqualTo("DenyAllOutBound"));

            // Verify the security rule
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].Access, Is.EqualTo(SecurityRuleAccess.Allow));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].Description, Is.EqualTo("Test security rule"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].DestinationAddressPrefix, Is.EqualTo("*"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].DestinationPortRange, Is.EqualTo(destinationPortRange));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].Direction, Is.EqualTo(SecurityRuleDirection.Inbound));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].Priority, Is.EqualTo(500));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].Protocol, Is.EqualTo(SecurityRuleProtocol.Tcp));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].SourceAddressPrefix, Is.EqualTo("*"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[0].SourcePortRange, Is.EqualTo("655"));

            // List NSG
            AsyncPageable<NetworkSecurityGroupResource> listNsgResponseAP = networkSecurityGroupCollection.GetAllAsync();
            List<NetworkSecurityGroupResource> listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listNsgResponse);
            Assert.That(listNsgResponse.First().Data.Name, Is.EqualTo(networkSecurityGroupName));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules.Count, Is.EqualTo(6));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[0].Name, Is.EqualTo("AllowVnetInBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[1].Name, Is.EqualTo("AllowAzureLoadBalancerInBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[2].Name, Is.EqualTo("DenyAllInBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[3].Name, Is.EqualTo("AllowVnetOutBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[4].Name, Is.EqualTo("AllowInternetOutBound"));
            Assert.That(listNsgResponse.First().Data.DefaultSecurityRules[5].Name, Is.EqualTo("DenyAllOutBound"));
            Assert.That(listNsgResponse.First().Data.ETag, Is.EqualTo(getNsgResponse.Value.Data.ETag));

            // List NSG in a subscription
            AsyncPageable<NetworkSecurityGroupResource> listNsgSubsciptionResponseAP = subscription.GetNetworkSecurityGroupsAsync();
            List<NetworkSecurityGroupResource> listNsgSubsciptionResponse = await listNsgSubsciptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNsgSubsciptionResponse);

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

            networkSecurityGroup.SecurityRules.Add(securityRule);

            putNsgResponseOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroup);
            await putNsgResponseOperation.WaitForCompletionAsync();;
            // Get NSG
            getNsgResponse = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);

            // Verify the security rule
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].Access, Is.EqualTo(SecurityRuleAccess.Deny));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].Description, Is.EqualTo("Test outbound security rule"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].DestinationAddressPrefix, Is.EqualTo("*"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].DestinationPortRange, Is.EqualTo(destinationPortRange));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].Direction, Is.EqualTo(SecurityRuleDirection.Outbound));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].Priority, Is.EqualTo(501));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].Protocol, Is.EqualTo(SecurityRuleProtocol.Udp));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].SourceAddressPrefix, Is.EqualTo("*"));
            Assert.That(getNsgResponse.Value.Data.SecurityRules[1].SourcePortRange, Is.EqualTo("656"));

            // List Default Security Groups
            AsyncPageable<DefaultSecurityRuleResource> listDefaultSecurityGroupsAP = getNsgResponse.Value.GetDefaultSecurityRules().GetAllAsync();
            List<DefaultSecurityRuleResource> listDefaultSecurityGroups = await listDefaultSecurityGroupsAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listDefaultSecurityGroups);

            // Get Defaul Security Group
            // TODO: ADO 5975
            //Response<SecurityRuleData> getDefaultSecurityGroups = await getNsgResponse.Value.GetDefaultSecurityRuleAsync();
            //Assert.AreEqual(listDefaultSecurityGroups.First().Name, getDefaultSecurityGroups.Value.Name);

            // Delete NSG
            await putNsgResponse.Value.DeleteAsync(WaitUntil.Completed);

            // List NSG
            listNsgResponseAP = networkSecurityGroupCollection.GetAllAsync();
            listNsgResponse = await listNsgResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(listNsgResponse);
        }
    }
}
