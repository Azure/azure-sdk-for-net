// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class VerifyIpFlowTests : NetworkServiceClientTestBase
    {
        public VerifyIpFlowTests(bool isAsync) : base(isAsync)
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
        public async Task VerifyIpFlowApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);

            string virtualMachineName1 = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName1 = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName1 + "-nsg";

            //Deploy VM with a template
            var vm = await CreateWindowsVM(virtualMachineName1, networkInterfaceName1, location, resourceGroup);

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcherResource properties = new NetworkWatcherResource { Location = location };
            //await networkWatcherCollection.CreateOrUpdateAsync(true, resourceGroupName, networkWatcherName, properties);

            string localIPAddress = GetNetworkInterfaceCollection(resourceGroupName).GetAsync(networkInterfaceName1).Result.Value.Data.IPConfigurations.FirstOrDefault().PrivateIPAddress;

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
            Response<NetworkSecurityGroupResource> nsg = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);
            nsg.Value.Data.SecurityRules.Add(securityRule);
            var createOrUpdateOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, nsg.Value.Data);
            await createOrUpdateOperation.WaitForCompletionAsync();;

            VerificationIPFlowContent ipFlowProperties = new VerificationIPFlowContent(vm.Id, "Outbound", "TCP", "80", "80", localIPAddress, "12.11.12.14");

            //Verify IP flow from a VM to a location given the configured  rule
            var verifyIpFlowOperation = await GetNetworkWatcherCollection("NetworkWatcherRG").Get("NetworkWatcher_westus2").Value.VerifyIPFlowAsync(WaitUntil.Completed, ipFlowProperties);
            Response<VerificationIPFlowResult> verifyIpFlow = await verifyIpFlowOperation.WaitForCompletionAsync();;
            //Verify validity of the result
            Assert.AreEqual("Deny", verifyIpFlow.Value.Access.ToString());
            Assert.AreEqual("securityRules/" + securityRule1, verifyIpFlow.Value.RuleName);
        }
    }
}
