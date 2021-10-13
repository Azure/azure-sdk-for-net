// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AFDSecretOperationsTests : CdnManagementTestBase
    {
        public AFDSecretOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string secretName = Recording.GenerateAssetName("AFDSecret-");
            Secret secret = await CreateSecret(AFDProfile, secretName);
            await secret.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await secret.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Not Ready")]
        public async Task Update()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string secretName = Recording.GenerateAssetName("AFDSecret-");
            Secret secret = await CreateSecret(AFDProfile, secretName);
            SecretProperties updateParameters = new SecretProperties
            {
                Parameters = new CustomerCertificateParameters(new WritableSubResource
                {
                    Id = "/subscriptions/87082bb7-c39f-42d2-83b6-4980444c7397/resourceGroups/CdnTest/providers/Microsoft.KeyVault/vaults/testKV4AFD/certificates/testCert"
                })
                {
                    UseLatestVersion = false,
                    SecretVersion = "242fe9960a044ca1ab28e79cbcf75d29"
                }
            };
            var lro = await secret.UpdateAsync(updateParameters);
            Secret updatedSecret = lro.Value;
            ResourceDataHelper.AssertSecretUpdate(updatedSecret, updateParameters);
        }
    }
}
