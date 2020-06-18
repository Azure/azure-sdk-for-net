// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class ViewNsgRuleTests : NetworkTestsManagementClientBase
    {
        public ViewNsgRuleTests(bool isAsync) : base(isAsync)
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
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task ViewNsgRuleApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with template
            await CreateVm(
                resourcesClient: ResourceManagementClient,
                resourceGroupName: resourceGroupName,
                location: location,
                virtualMachineName: virtualMachineName,
                storageAccountName: Recording.GenerateAssetName("azsmnet"),
                networkInterfaceName: networkInterfaceName,
                networkSecurityGroupName: networkSecurityGroupName,
                diagnosticsStorageAccountName: Recording.GenerateAssetName("azsmnet"),
                deploymentName: Recording.GenerateAssetName("azsmnet"),
                adminPassword: Recording.GenerateAlphaNumericId("AzureSDKNetworkTest#")
                );

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //Response<NetworkWatcher> createNetworkWatcher = await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync(resourceGroupName, networkWatcherName, properties);

            Response<VirtualMachine> getVm = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName);
            string localIPAddress = NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, networkInterfaceName).Result.Value.IpConfigurations.FirstOrDefault().PrivateIPAddress;

            string securityRule1 = Recording.GenerateAssetName("azsmnet");

            // Add a security rule
            SecurityRule SecurityRule = new SecurityRule()
            {
                Name = securityRule1,
                Access = SecurityRuleAccess.Deny,
                Description = "Test outbound security rule",
                DestinationAddressPrefix = "*",
                DestinationPortRange = "80",
                Direction = SecurityRuleDirection.Outbound,
                Priority = 501,
                Protocol = SecurityRuleProtocol.Tcp,
                SourceAddressPrefix = "*",
                SourcePortRange = "*",
            };

            Response<NetworkSecurityGroup> nsg = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);
            nsg.Value.SecurityRules.Add(SecurityRule);
            NetworkSecurityGroupsCreateOrUpdateOperation createOrUpdateOperation = await NetworkManagementClient.NetworkSecurityGroups.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, nsg);
            Response<NetworkSecurityGroup> networkSecurityGroup = await WaitForCompletionAsync(createOrUpdateOperation);

            //Get view security group rules
            SecurityGroupViewParameters sgvProperties = new SecurityGroupViewParameters(getVm.Value.Id);
            NetworkWatchersGetVMSecurityRulesOperation viewNSGRulesOperation = await NetworkManagementClient.NetworkWatchers.StartGetVMSecurityRulesAsync("NetworkWatcherRG", "NetworkWatcher_westus2", sgvProperties);
            Response<SecurityGroupViewResult> viewNSGRules = await WaitForCompletionAsync(viewNSGRulesOperation);

            //Verify effective security rule defined earlier
            IEnumerable<EffectiveNetworkSecurityRule> getEffectiveSecurityRule = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.EffectiveSecurityRules.Where(x => x.Name == "UserRule_" + securityRule1);
            Assert.AreEqual("Tcp", getEffectiveSecurityRule.FirstOrDefault().Protocol);
            Assert.AreEqual(501, getEffectiveSecurityRule.FirstOrDefault().Priority);
            Assert.AreEqual("Deny", getEffectiveSecurityRule.FirstOrDefault().Access);
            Assert.AreEqual("Outbound", getEffectiveSecurityRule.FirstOrDefault().Direction);
            Assert.AreEqual("0.0.0.0/0", getEffectiveSecurityRule.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("80-80", getEffectiveSecurityRule.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("0.0.0.0/0", getEffectiveSecurityRule.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("0-65535", getEffectiveSecurityRule.FirstOrDefault().SourcePortRange);

            //Verify 6 default rules
            IEnumerable<SecurityRule> getDefaultSecurityRule1 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetInBound");
            Assert.AreEqual("*", getDefaultSecurityRule1.FirstOrDefault().Protocol);
            Assert.AreEqual(65000, getDefaultSecurityRule1.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRule1.FirstOrDefault().Access);
            Assert.AreEqual("Inbound", getDefaultSecurityRule1.FirstOrDefault().Direction);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRule1.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule1.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRule1.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule1.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRule> getDefaultSecurityRule2 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowAzureLoadBalancerInBound");
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().Protocol);
            Assert.AreEqual(65001, getDefaultSecurityRule2.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRule2.FirstOrDefault().Access);
            Assert.AreEqual("Inbound", getDefaultSecurityRule2.FirstOrDefault().Direction);
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("AzureLoadBalancer", getDefaultSecurityRule2.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRule> getDefaultSecurityRule3 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllInBound");
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().Protocol);
            Assert.AreEqual(65500, getDefaultSecurityRule3.FirstOrDefault().Priority);
            Assert.AreEqual("Deny", getDefaultSecurityRule3.FirstOrDefault().Access);
            Assert.AreEqual("Inbound", getDefaultSecurityRule3.FirstOrDefault().Direction);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRule> getDefaultSecurityRule4 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetOutBound");
            Assert.AreEqual("*", getDefaultSecurityRule4.FirstOrDefault().Protocol);
            Assert.AreEqual(65000, getDefaultSecurityRule4.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRule4.FirstOrDefault().Access);
            Assert.AreEqual("Outbound", getDefaultSecurityRule4.FirstOrDefault().Direction);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRule4.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule4.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRule4.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule4.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRule> getDefaultSecurityRule5 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowInternetOutBound");
            Assert.AreEqual("*", getDefaultSecurityRule5.FirstOrDefault().Protocol);
            Assert.AreEqual(65001, getDefaultSecurityRule5.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRule5.FirstOrDefault().Access);
            Assert.AreEqual("Outbound", getDefaultSecurityRule5.FirstOrDefault().Direction);
            Assert.AreEqual("Internet", getDefaultSecurityRule5.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule5.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("*", getDefaultSecurityRule5.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule5.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRule> getDefaultSecurityRule6 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllOutBound");
            Assert.AreEqual("*", getDefaultSecurityRule6.FirstOrDefault().Protocol);
            Assert.AreEqual(65500, getDefaultSecurityRule6.FirstOrDefault().Priority);
            Assert.AreEqual("Deny", getDefaultSecurityRule6.FirstOrDefault().Access);
            Assert.AreEqual("Outbound", getDefaultSecurityRule6.FirstOrDefault().Direction);
            Assert.AreEqual("*", getDefaultSecurityRule6.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule6.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("*", getDefaultSecurityRule6.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule6.FirstOrDefault().SourcePortRange);
        }
    }
}
