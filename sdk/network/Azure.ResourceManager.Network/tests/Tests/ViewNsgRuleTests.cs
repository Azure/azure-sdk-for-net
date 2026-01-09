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
            Assert.Multiple(() =>
            {
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().Protocol, Is.EqualTo("Tcp"));
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().Priority, Is.EqualTo(501));
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().Access, Is.EqualTo("Deny"));
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().Direction, Is.EqualTo("Outbound"));
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().DestinationAddressPrefix, Is.EqualTo("0.0.0.0/0"));
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().DestinationPortRange, Is.EqualTo("80-80"));
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().SourceAddressPrefix, Is.EqualTo("0.0.0.0/0"));
                Assert.That(getEffectiveSecurityRule.FirstOrDefault().SourcePortRange, Is.EqualTo("0-65535"));
            });

            //Verify 6 default rules
            IEnumerable<SecurityRuleData> getDefaultSecurityRule1 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetInBound");
            Assert.Multiple(() =>
            {
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().Protocol, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().Priority, Is.EqualTo(65000));
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().Access, Is.EqualTo("Allow"));
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().Direction, Is.EqualTo("Inbound"));
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().DestinationAddressPrefix, Is.EqualTo("VirtualNetwork"));
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().DestinationPortRange, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().SourceAddressPrefix, Is.EqualTo("VirtualNetwork"));
                Assert.That(getDefaultSecurityRule1.FirstOrDefault().SourcePortRange, Is.EqualTo("*"));
            });

            IEnumerable<SecurityRuleData> getDefaultSecurityRule2 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowAzureLoadBalancerInBound");
            Assert.Multiple(() =>
            {
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().Protocol, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().Priority, Is.EqualTo(65001));
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().Access, Is.EqualTo("Allow"));
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().Direction, Is.EqualTo("Inbound"));
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().DestinationAddressPrefix, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().DestinationPortRange, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().SourceAddressPrefix, Is.EqualTo("AzureLoadBalancer"));
                Assert.That(getDefaultSecurityRule2.FirstOrDefault().SourcePortRange, Is.EqualTo("*"));
            });

            IEnumerable<SecurityRuleData> getDefaultSecurityRule3 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllInBound");
            Assert.Multiple(() =>
            {
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().Protocol, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().Priority, Is.EqualTo(65500));
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().Access, Is.EqualTo("Deny"));
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().Direction, Is.EqualTo("Inbound"));
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().DestinationAddressPrefix, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().DestinationPortRange, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().SourceAddressPrefix, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRule3.FirstOrDefault().SourcePortRange, Is.EqualTo("*"));
            });

            IEnumerable<SecurityRuleData> getDefaultSecurityRuleData4 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetOutBound");
            Assert.Multiple(() =>
            {
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().Protocol, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().Priority, Is.EqualTo(65000));
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().Access, Is.EqualTo("Allow"));
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().Direction, Is.EqualTo("Outbound"));
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().DestinationAddressPrefix, Is.EqualTo("VirtualNetwork"));
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().DestinationPortRange, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().SourceAddressPrefix, Is.EqualTo("VirtualNetwork"));
                Assert.That(getDefaultSecurityRuleData4.FirstOrDefault().SourcePortRange, Is.EqualTo("*"));
            });

            IEnumerable<SecurityRuleData> getDefaultSecurityRuleData5 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowInternetOutBound");
            Assert.Multiple(() =>
            {
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().Protocol, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().Priority, Is.EqualTo(65001));
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().Access, Is.EqualTo("Allow"));
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().Direction, Is.EqualTo("Outbound"));
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().DestinationAddressPrefix, Is.EqualTo("Internet"));
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().DestinationPortRange, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().SourceAddressPrefix, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData5.FirstOrDefault().SourcePortRange, Is.EqualTo("*"));
            });

            IEnumerable<SecurityRuleData> getDefaultSecurityRuleData6 = viewNSGRules.Value.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllOutBound");
            Assert.Multiple(() =>
            {
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().Protocol, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().Priority, Is.EqualTo(65500));
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().Access, Is.EqualTo("Deny"));
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().Direction, Is.EqualTo("Outbound"));
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().DestinationAddressPrefix, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().DestinationPortRange, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().SourceAddressPrefix, Is.EqualTo("*"));
                Assert.That(getDefaultSecurityRuleData6.FirstOrDefault().SourcePortRange, Is.EqualTo("*"));
            });
        }
    }
}
