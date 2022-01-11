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
    public class UsageTests : NetworkServiceClientTestBase
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
            var putNsgResponseOperation = await networkSecurityGroupCollection.CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroup> putNsgResponse = await putNsgResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putNsgResponse.Value.Data.ProvisioningState.ToString());

            Response<NetworkSecurityGroup> getNsgResponse = await networkSecurityGroupCollection.GetAsync(networkSecurityGroupName);

            // Query for usages
            AsyncPageable<Usage> usagesResponseAP = subscription.GetUsagesAsync(getNsgResponse.Value.Data.Location.Replace(" ", string.Empty));
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
