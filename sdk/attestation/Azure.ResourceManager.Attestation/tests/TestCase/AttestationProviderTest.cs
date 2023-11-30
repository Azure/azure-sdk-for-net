// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Attestation.Models;
using Azure.ResourceManager.Attestation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Attestation.Tests
{
    public class AttestationProviderTest : AttestationManagementTestBase
    {
        public AttestationProviderTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ProviderApiTest()
        {
            //1.Create
            var providerName = Recording.GenerateAssetName("testprovider");
            var providerName2 = Recording.GenerateAssetName("testprovider");
            var providerName3 = Recording.GenerateAssetName("testprovider");
            var resourceGroup = await CreateResourceGroupAsync();
            var providrerCollection = resourceGroup.GetAttestationProviders();
            var input = ResourceDataHelper.GetProviderData(DefaultLocation);
            var providerResource = (await providrerCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName, input)).Value;
            Assert.AreEqual(providerName, providerResource.Data.Name);
            //2.Get
            var providerResource2 =(await providerResource.GetAsync()).Value;
            ResourceDataHelper.AssertProvider(providerResource.Data, providerResource2.Data);
            //3.GetAll
            _ = await providrerCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName2, input);
            _ = await providrerCollection.CreateOrUpdateAsync(WaitUntil.Completed, providerName3, input);
            int count = 0;
            await foreach (var availabilitySet in providrerCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
            //4.Exist
            Assert.IsTrue(await providrerCollection.ExistsAsync(providerName));
            Assert.IsFalse(await providrerCollection.ExistsAsync(providerName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await providrerCollection.ExistsAsync(null));
            //Resouece operation
            //1.Get
            var providerResource3 =(await providerResource.GetAsync()).Value;
            ResourceDataHelper.AssertProvider(providerResource.Data, providerResource3.Data);
            //2.Update
            var patch = new AttestationProviderPatch()
            {
                Tags =
                {
                    ["UpdateKey1"] = "UpdateValue1",
                    ["UpdateKey1"] = "UpdateValue1",
                    ["UpdateKey1"] = "UpdateValue1"
                },
                AttestationServicePatchSpecificParamsPublicNetworkAccess = PublicNetworkAccessType.Disabled
            };
            var providerResource4 =(await providerResource3.UpdateAsync(patch)).Value;
            Assert.AreEqual(patch.Tags.Count, providerResource4.Data.Tags.Count);
            //3. Delete
            await providerResource4.DeleteAsync(WaitUntil.Completed);
        }
    }
}
