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
    public class AFDCustomDomainOperationsTests : CdnManagementTestBase
    {
        public AFDCustomDomainOperationsTests(bool isAsync)
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
            string AFDCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string AFDHostName = "customdomain4afd-4.azuretest.net";
            AFDDomain AFDCustomDomain = await CreateAFDCustomDomain(AFDProfile, AFDCustomDomainName, AFDHostName);
            await AFDCustomDomain.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await AFDCustomDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            //This test doesn't create a new afd custom domain bucause the update actoin needs to manualy add dns txt record and validate.
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync("CdnTest");
            Profile AFDProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            AFDDomain AFDCustomDomain = await AFDProfile.GetAFDDomains().GetAsync("customdomain4afd-azuretest-net");
            AFDDomainUpdateParameters updateParameters = new AFDDomainUpdateParameters
            {
                TlsSettings = new AFDDomainHttpsParameters(AfdCertificateType.ManagedCertificate)
                {
                    MinimumTlsVersion = AfdMinimumTlsVersion.TLS12
                },
            };
            var lro = await AFDCustomDomain.UpdateAsync(updateParameters);
            AFDDomain updatedAFDCustomDomain = lro.Value;
            ResourceDataHelper.AssertAFDDomainUpdate(updatedAFDCustomDomain, updateParameters);
        }

        [TestCase]
        [RecordedTest]
        public async Task RefreshVlidationToken()
        {
            //This test doesn't create a new afd custom domain bucause the refresh validation token actoin needs to manualy add dns txt record and validate.
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync("CdnTest");
            Profile AFDProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            AFDDomain AFDCustomDomain = await AFDProfile.GetAFDDomains().GetAsync("customdomain4afd-azuretest-net");
            Assert.ThrowsAsync<RequestFailedException>(async () => await AFDCustomDomain.RefreshValidationTokenAsync());
        }
    }
}
