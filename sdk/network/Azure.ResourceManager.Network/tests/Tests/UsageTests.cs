// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [ClientTestFixture(true, "2021-04-01", "2018-11-01")]
    public class UsageTests : NetworkServiceClientTestBase
    {
        public UsageTests(bool isAsync, string apiVersion)
        : base(isAsync, "Microsoft.Network/locations/usages", apiVersion)
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
        public async Task UsageTest()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);
            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            NetworkSecurityGroupData networkSecurityGroup = new NetworkSecurityGroupData() { Location = location, };

            // Put Nsg
            var networkSecurityGroupCollection = resourceGroup.GetNetworkSecurityGroups();
            var putNsgResponseOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroupResource> putNsgResponse = await putNsgResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putNsgResponse.Value.Data.ProvisioningState.ToString());

            Response<NetworkSecurityGroupResource> getNsgResponse = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);

            // Query for usages
            AsyncPageable<NetworkUsage> usagesResponseAP = subscription.GetUsagesAsync(getNsgResponse.Value.Data.Location.ToString().Replace(" ", string.Empty));
            List<NetworkUsage> usagesResponse = await usagesResponseAP.ToEnumerableAsync();
            // Verify that the strings are populated
            Assert.NotNull(usagesResponse);
            Assert.True(usagesResponse.Any());

            foreach (NetworkUsage usage in usagesResponse)
            {
                Assert.True(usage.Limit > 0);
                Assert.NotNull(usage.Name);
                Assert.True(!string.IsNullOrEmpty(usage.Name.LocalizedValue));
                Assert.True(!string.IsNullOrEmpty(usage.Name.Value));
            }
        }
    }
}
