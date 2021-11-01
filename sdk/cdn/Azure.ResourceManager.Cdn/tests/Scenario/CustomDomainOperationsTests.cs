// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CustomDomainOperationsTests : CdnManagementTestBase
    {
        public CustomDomainOperationsTests(bool isAsync)
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
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = "customDomain-811";
            var lro = await endpoint.GetCustomDomains().GetAsync(customDomainName);
            CustomDomain customDomain = lro.Value;
            await customDomain.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await customDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task EnableAndDisable()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-5.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest-5.azuretest.net";
            CustomDomain customDomain = await CreateCustomDomain(endpoint, customDomainName, hostName);
            Assert.ThrowsAsync<RequestFailedException>(async () => await customDomain.DisableCustomHttpsAsync());
            CdnManagedHttpsParameters customDomainHttpsParameters = new CdnManagedHttpsParameters(ProtocolType.ServerNameIndication, new CdnCertificateSourceParameters(CdnCertificateSourceParametersOdataType.MicrosoftAzureCdnModelsCdnCertificateSourceParameters, CertificateType.Dedicated));
            Assert.DoesNotThrowAsync(async () => await customDomain.EnableCustomHttpsAsync(customDomainHttpsParameters));
            Assert.DoesNotThrowAsync(async () => await customDomain.DisableCustomHttpsAsync());
        }
    }
}
