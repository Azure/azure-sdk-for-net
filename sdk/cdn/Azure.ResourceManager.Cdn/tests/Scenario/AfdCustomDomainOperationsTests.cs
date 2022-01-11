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
    public class AfdCustomDomainOperationsTests : CdnManagementTestBase
    {
        public AfdCustomDomainOperationsTests(bool isAsync)
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
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-4.azuretest.net";
            AfdCustomDomain afdCustomDomain = await CreateAfdCustomDomain(afdProfile, afdCustomDomainName, afdHostName);
            await afdCustomDomain.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdCustomDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            //This test doesn't create a new afd custom domain bucause the update actoin needs to manualy add dns txt record and validate.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            AfdCustomDomain afdCustomDomain = await afdProfile.GetAfdCustomDomains().GetAsync("customdomain4afd-azuretest-net");
            AfdCustomDomainUpdateOptions updateOptions = new AfdCustomDomainUpdateOptions
            {
                TlsSettings = new AfdCustomDomainHttpsParameters(AfdCertificateType.ManagedCertificate)
                {
                    MinimumTlsVersion = AfdMinimumTlsVersion.TLS12
                },
            };
            var lro = await afdCustomDomain.UpdateAsync(updateOptions);
            AfdCustomDomain updatedAfdCustomDomain = lro.Value;
            ResourceDataHelper.AssertAfdDomainUpdate(updatedAfdCustomDomain, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task RefreshVlidationToken()
        {
            //This test doesn't create a new afd custom domain bucause the refresh validation token actoin needs to manualy add dns txt record and validate.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            AfdCustomDomain afdCustomDomain = await afdProfile.GetAfdCustomDomains().GetAsync("customdomain4afd-azuretest-net");
            Assert.ThrowsAsync<RequestFailedException>(async () => await afdCustomDomain.RefreshValidationTokenAsync());
        }
    }
}
