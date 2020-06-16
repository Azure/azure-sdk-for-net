// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class VerifyIpFlowTests : NetworkTestsManagementClientBase
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("Track2: The NetworkWathcer is involved, so disable the test")]
        public async Task VerifyIpFlowApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "westus2";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            string virtualMachineName1 = Recording.GenerateAssetName("azsmnet");
            string networkInterfaceName1 = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = virtualMachineName1 + "-nsg";

            //Deploy VM with a template
            await CreateVm(
                resourcesClient: ResourceManagementClient,
                resourceGroupName: resourceGroupName,
                location: location,
                virtualMachineName: virtualMachineName1,
                storageAccountName: Recording.GenerateAssetName("azsmnet"),
                networkInterfaceName: networkInterfaceName1,
                networkSecurityGroupName: networkSecurityGroupName,
                diagnosticsStorageAccountName: Recording.GenerateAssetName("azsmnet"),
                deploymentName: Recording.GenerateAssetName("azsmnet"),
                adminPassword: Recording.GenerateAlphaNumericId("AzureSDKNetworkTest#")
                );

            //TODO:There is no need to perform a separate create NetworkWatchers operation
            //Create network Watcher
            //string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            //NetworkWatcher properties = new NetworkWatcher { Location = location };
            //await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync(resourceGroupName, networkWatcherName, properties);

            Response<VirtualMachine> getVm1 = await ComputeManagementClient.VirtualMachines.GetAsync(resourceGroupName, virtualMachineName1);
            string localIPAddress = NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, networkInterfaceName1).Result.Value.IpConfigurations.FirstOrDefault().PrivateIPAddress;

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
            await WaitForCompletionAsync(createOrUpdateOperation);

            VerificationIPFlowParameters ipFlowProperties = new VerificationIPFlowParameters(getVm1.Value.Id, "Outbound", "TCP", "80", "80", localIPAddress, "12.11.12.14");

            //Verify IP flow from a VM to a location given the configured  rule
            NetworkWatchersVerifyIPFlowOperation verifyIpFlowOperation = await NetworkManagementClient.NetworkWatchers.StartVerifyIPFlowAsync("NetworkWatcherRG", "NetworkWatcher_westus2", ipFlowProperties);
            Response<VerificationIPFlowResult> verifyIpFlow = await WaitForCompletionAsync(verifyIpFlowOperation);
            //Verify validity of the result
            Assert.AreEqual("Deny", verifyIpFlow.Value.Access.ToString());
            Assert.AreEqual("securityRules/" + securityRule1, verifyIpFlow.Value.RuleName);
        }
    }
}
