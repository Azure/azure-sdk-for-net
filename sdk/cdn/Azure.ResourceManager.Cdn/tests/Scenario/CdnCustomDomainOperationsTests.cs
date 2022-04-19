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
            //In this test, the CName mapping from custom domain "customdomaintest4.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            //The CName mapping needs to be deleted before deleting the custom domain.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string cdnCustomDomainName = "customdomaintest4-azuretest-net";
            var lro = await cdnEndpoint.GetCdnCustomDomains().GetAsync(cdnCustomDomainName);
            CdnCustomDomainResource cdnCustomDomain = lro.Value;
            await cdnCustomDomain.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await cdnCustomDomain.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task EnableAndDisable()
        {
            //In this test, the CName mapping from custom domain "customdomaintest5.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string cdnCustomDomainName = "customdomaintest5-azuretest-net";
            var lro = await cdnEndpoint.GetCdnCustomDomains().GetAsync(cdnCustomDomainName);
            CdnCustomDomainResource cdnCustomDomain = lro.Value;
            Assert.ThrowsAsync<RequestFailedException>(async () => await cdnCustomDomain.DisableCustomHttpsAsync());
            CdnManagedHttpsOptions customDomainHttpsOptions = new CdnManagedHttpsOptions(ProtocolType.ServerNameIndication, new CdnCertificateSourceParameters(CdnCertificateSourceParametersTypeName.CdnCertificateSourceParameters, CertificateType.Dedicated));
            CdnCustomDomainResource enabledCdnCustomDomain = await cdnCustomDomain.EnableCustomHttpsAsync(customDomainHttpsOptions);
            Assert.AreEqual(enabledCdnCustomDomain.Data.CustomHttpsProvisioningState, CustomHttpsProvisioningState.Enabling);
        }
    }
}
