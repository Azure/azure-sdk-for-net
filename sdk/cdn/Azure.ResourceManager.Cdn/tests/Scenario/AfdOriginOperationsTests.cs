// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdOriginOperationsTests : CdnManagementTestBase
    {
        public AfdOriginOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AfdOrigin afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            await afdOriginInstance.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdOriginInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AfdOrigin afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            AfdOriginUpdateOptions updateOptions = new AfdOriginUpdateOptions
            {
                Priority = 1,
                Weight = 150
            };
            var lro = await afdOriginInstance.UpdateAsync(updateOptions);
            AfdOrigin updatedAfdOriginInstance = lro.Value;
            ResourceDataHelper.AssertAfdOriginUpdate(updatedAfdOriginInstance, updateOptions);
        }
    }
}
