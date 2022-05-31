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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-4.azuretest.net";
            AfdCustomDomainResource afdCustomDomain = await CreateAfdCustomDomain(afdProfile, afdCustomDomainName, afdHostName);
            await afdCustomDomain.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdCustomDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            //This test doesn't create a new afd custom domain bucause the update actoin needs to manualy add dns txt record and validate.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            AfdCustomDomainResource afdCustomDomain = await afdProfile.GetAfdCustomDomains().GetAsync("customdomain4afd-azuretest-net");
            AfdCustomDomainPatch updateOptions = new AfdCustomDomainPatch
            {
                TlsSettings = new AfdCustomDomainHttpsContent(AfdCertificateType.ManagedCertificate)
                {
                    MinimumTlsVersion = AfdMinimumTlsVersion.Tls1_0
                },
            };
            var lro = await afdCustomDomain.UpdateAsync(WaitUntil.Completed, updateOptions);
            ;
            AfdCustomDomainResource updatedAfdCustomDomain = lro.Value;
            ResourceDataHelper.AssertAfdDomainUpdate(updatedAfdCustomDomain, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task RefreshVlidationToken()
        {
            //This test doesn't create a new afd custom domain bucause the refresh validation token actoin needs to manualy add dns txt record and validate.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            ProfileResource afdProfile = await rg.GetProfiles().GetAsync("testAFDProfile");
            AfdCustomDomainResource afdCustomDomain = await afdProfile.GetAfdCustomDomains().GetAsync("customdomain4afd-azuretest-net");
            Assert.DoesNotThrowAsync(async () => await afdCustomDomain.RefreshValidationTokenAsync(WaitUntil.Completed));
        }
    }
}
