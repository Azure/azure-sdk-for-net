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
    public class AFDOriginOperationsTests : CdnManagementTestBase
    {
        public AFDOriginOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AFDOrigin AFDOriginInstance = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            await AFDOriginInstance.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await AFDOriginInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AFDOrigin AFDOriginInstance = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            AFDOriginUpdateParameters updateParameters = new AFDOriginUpdateParameters
            {
                Priority = 1,
                Weight = 150
            };
            var lro = await AFDOriginInstance.UpdateAsync(updateParameters);
            AFDOrigin updatedAFDOriginInstance = lro.Value;
            ResourceDataHelper.AssertAFDOriginUpdate(updatedAFDOriginInstance, updateParameters);
        }
    }
}
