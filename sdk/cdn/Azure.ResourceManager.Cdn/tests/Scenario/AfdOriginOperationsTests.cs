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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            FrontDoorOriginResource afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            await afdOriginInstance.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdOriginInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            FrontDoorOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            FrontDoorOriginResource afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            FrontDoorOriginPatch updateOptions = new FrontDoorOriginPatch
            {
                Priority = 1,
                Weight = 150
            };
            var lro = await afdOriginInstance.UpdateAsync(WaitUntil.Completed, updateOptions);
            FrontDoorOriginResource updatedAfdOriginInstance = lro.Value;
            ResourceDataHelper.AssertAfdOriginUpdate(updatedAfdOriginInstance, updateOptions);
        }
    }
}
