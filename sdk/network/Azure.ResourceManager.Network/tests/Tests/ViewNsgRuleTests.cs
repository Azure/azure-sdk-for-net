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
    public class ViewNsgRuleTests : NetworkServiceClientTestBase
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

        [Test]
        [RecordedTest]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task ViewNsgRuleApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);

            string virtualMachineName = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName + "-nsg";

            //Deploy VM with template
            var vm = await CreateLinuxVM(virtualMachineName, networkInterfaceName, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //Response<NetworkWatcherResource> createNetworkWatcher = await networkWatcherCollection.CreateOrUpdateAsync(true, resourceGroupName, networkWatcherName, properties);

            string localIPAddress = GetNetworkInterfaceCollection(resourceGroupName).GetAsync(networkInterfaceName).Result.Value.Data.IPConfigurations.FirstOrDefault().PrivateIPAddress;

            string securityRule1 = Recording.GenerateAssetName("azsmnet");

            // Add a security rule
            var securityRule = new SecurityRuleData()
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

            var networkSecurityGroupCollection = GetNetworkSecurityGroupCollection(resourceGroupName);
            Response<NetworkSecurityGroupResource> nsg = await networkSecurityGroupCollection.GetAsync(resourceGroupName, networkSecurityGroupName);
            nsg.Value.Data.SecurityRules.Add(securityRule);
            var createOrUpdateOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, nsg.Value.Data);
            Response<NetworkSecurityGroupResource> networkSecurityGroup = await createOrUpdateOperation.WaitForCompletionAsync();;

            //Get view security group rules
            var viewNSGRulesOperation = await GetNetworkWatcherCollection("NetworkWatcherRG").Get("NetworkWatcher_westus2").Value.GetVmSecurityRulesAsync(WaitUntil.Completed, new SecurityGroupViewContent(vm.Id));
            Response<SecurityGroupViewResult> viewNSGRules = await viewNSGRulesOperation.WaitForCompletionAsync();;

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
            IEnumerable<SecurityRuleData> getDefaultSecurityRule1 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetInBound");
            Assert.AreEqual("*", getDefaultSecurityRule1.FirstOrDefault().Protocol);
            Assert.AreEqual(65000, getDefaultSecurityRule1.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRule1.FirstOrDefault().Access);
            Assert.AreEqual("Inbound", getDefaultSecurityRule1.FirstOrDefault().Direction);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRule1.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule1.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRule1.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule1.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRuleData> getDefaultSecurityRule2 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowAzureLoadBalancerInBound");
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().Protocol);
            Assert.AreEqual(65001, getDefaultSecurityRule2.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRule2.FirstOrDefault().Access);
            Assert.AreEqual("Inbound", getDefaultSecurityRule2.FirstOrDefault().Direction);
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("AzureLoadBalancer", getDefaultSecurityRule2.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule2.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRuleData> getDefaultSecurityRule3 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllInBound");
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().Protocol);
            Assert.AreEqual(65500, getDefaultSecurityRule3.FirstOrDefault().Priority);
            Assert.AreEqual("Deny", getDefaultSecurityRule3.FirstOrDefault().Access);
            Assert.AreEqual("Inbound", getDefaultSecurityRule3.FirstOrDefault().Direction);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRule3.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRuleData> getDefaultSecurityRuleData4 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetOutBound");
            Assert.AreEqual("*", getDefaultSecurityRuleData4.FirstOrDefault().Protocol);
            Assert.AreEqual(65000, getDefaultSecurityRuleData4.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRuleData4.FirstOrDefault().Access);
            Assert.AreEqual("Outbound", getDefaultSecurityRuleData4.FirstOrDefault().Direction);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRuleData4.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRuleData4.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("VirtualNetwork", getDefaultSecurityRuleData4.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRuleData4.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRuleData> getDefaultSecurityRuleData5 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowInternetOutBound");
            Assert.AreEqual("*", getDefaultSecurityRuleData5.FirstOrDefault().Protocol);
            Assert.AreEqual(65001, getDefaultSecurityRuleData5.FirstOrDefault().Priority);
            Assert.AreEqual("Allow", getDefaultSecurityRuleData5.FirstOrDefault().Access);
            Assert.AreEqual("Outbound", getDefaultSecurityRuleData5.FirstOrDefault().Direction);
            Assert.AreEqual("Internet", getDefaultSecurityRuleData5.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRuleData5.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("*", getDefaultSecurityRuleData5.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRuleData5.FirstOrDefault().SourcePortRange);

            IEnumerable<SecurityRuleData> getDefaultSecurityRuleData6 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllOutBound");
            Assert.AreEqual("*", getDefaultSecurityRuleData6.FirstOrDefault().Protocol);
            Assert.AreEqual(65500, getDefaultSecurityRuleData6.FirstOrDefault().Priority);
            Assert.AreEqual("Deny", getDefaultSecurityRuleData6.FirstOrDefault().Access);
            Assert.AreEqual("Outbound", getDefaultSecurityRuleData6.FirstOrDefault().Direction);
            Assert.AreEqual("*", getDefaultSecurityRuleData6.FirstOrDefault().DestinationAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRuleData6.FirstOrDefault().DestinationPortRange);
            Assert.AreEqual("*", getDefaultSecurityRuleData6.FirstOrDefault().SourceAddressPrefix);
            Assert.AreEqual("*", getDefaultSecurityRuleData6.FirstOrDefault().SourcePortRange);
        }
    }
}
