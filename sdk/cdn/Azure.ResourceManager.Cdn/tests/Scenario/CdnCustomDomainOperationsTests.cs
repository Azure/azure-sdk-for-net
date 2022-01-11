// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnCustomDomainOperationsTests : CdnManagementTestBase
    {
        public CdnCustomDomainOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-4.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            //The CName mapping needs to be deleted before deleting the custom domain.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpoint cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string cdnCustomDomainName = "customDomain-811";
            var lro = await cdnEndpoint.GetCdnCustomDomains().GetAsync(cdnCustomDomainName);
            CdnCustomDomain cdnCustomDomain = lro.Value;
            await cdnCustomDomain.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnCustomDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task EnableAndDisable()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-5.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpoint cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string cdnCustomDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest-5.azuretest.net";
            CdnCustomDomain cdnCustomDomain = await CreateCdnCustomDomain(cdnEndpoint, cdnCustomDomainName, hostName);
            Assert.ThrowsAsync<RequestFailedException>(async () => await cdnCustomDomain.DisableCustomHttpsAsync());
            CdnManagedHttpsOptions customDomainHttpsOptions = new CdnManagedHttpsOptions(ProtocolType.ServerNameIndication, new CdnCertificateSourceParameters(CdnCertificateSourceParametersOdataType.MicrosoftAzureCdnModelsCdnCertificateSourceParameters, CertificateType.Dedicated));
            Assert.DoesNotThrowAsync(async () => await cdnCustomDomain.EnableCustomHttpsAsync(customDomainHttpsOptions));
            Assert.DoesNotThrowAsync(async () => await cdnCustomDomain.DisableCustomHttpsAsync());
        }
    }
}
