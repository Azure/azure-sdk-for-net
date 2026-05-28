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
            //In this test, the CName mapping from custom domain "sdktest4.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            //The CName mapping needs to be deleted before deleting the custom domain.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk1");
            string cdnCustomDomainName = "sdktest4-clitest-azfdtest-xyz";
            var lro = await cdnEndpoint.GetCdnCustomDomains().GetAsync(cdnCustomDomainName);
            CdnCustomDomainResource cdnCustomDomain = lro.Value;
            await cdnCustomDomain.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnCustomDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Enable()
        {
            //In this test, the CName mapping from custom domain "sdktest5.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk1");
            string cdnCustomDomainName = "sdktest5-clitest-azfdtest-xyz";
            CdnCustomDomainResource cdnCustomDomain = await cdnEndpoint.GetCdnCustomDomains().GetAsync(cdnCustomDomainName);
            CdnManagedHttpsContent customDomainHttpsContent = new CdnManagedHttpsContent(SecureDeliveryProtocolType.ServerNameIndication, new CdnCertificateSource(CdnCertificateSourceType.CdnCertificateSource, CdnManagedCertificateType.Dedicated));
            var lro = await cdnCustomDomain.EnableCustomHttpsAsync(WaitUntil.Completed, customDomainHttpsContent);
            CdnCustomDomainResource enabledCdnCustomDomain = lro.Value;
            Assert.AreEqual(enabledCdnCustomDomain.Data.CustomHttpsProvisioningState, CustomHttpsProvisioningState.Enabled);
        }

        [TestCase]
        [RecordedTest]
        public async Task Disable()
        {
            //In this test, the CName mapping from custom domain "sdktest5.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("azure_cli_test");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk1");
            string cdnCustomDomainName = "sdktest5-clitest-azfdtest-xyz";
            CdnCustomDomainResource cdnCustomDomain = await cdnEndpoint.GetCdnCustomDomains().GetAsync(cdnCustomDomainName);
            var lro = await cdnCustomDomain.DisableCustomHttpsAsync(WaitUntil.Completed);
            CdnCustomDomainResource disabledCdnCustomDomain = lro.Value;
            Assert.AreEqual(disabledCdnCustomDomain.Data.CustomHttpsProvisioningState, CustomHttpsProvisioningState.Disabled);
        }
    }
}
