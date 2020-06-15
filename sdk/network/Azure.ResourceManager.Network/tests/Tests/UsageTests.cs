// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class UsageTests : NetworkTestsManagementClientBase
    {
        public UsageTests(bool isAsync) : base(isAsync)
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
        public async Task UsageTest()
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

            Response<NetworkSecurityGroup> getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);

            // Query for usages
            AsyncPageable<Usage> usagesResponseAP = NetworkManagementClient.Usages.ListAsync(getNsgResponse.Value.Location.Replace(" ", string.Empty));
            List<Usage> usagesResponse = await usagesResponseAP.ToEnumerableAsync();
            // Verify that the strings are populated
            Assert.NotNull(usagesResponse);
            Assert.True(usagesResponse.Any());

            foreach (Usage usage in usagesResponse)
            {
                Assert.True(usage.Limit > 0);
                Assert.NotNull(usage.Name);
                Assert.True(!string.IsNullOrEmpty(usage.Name.LocalizedValue));
                Assert.True(!string.IsNullOrEmpty(usage.Name.Value));
            }
        }
    }
}
