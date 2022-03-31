// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnCustomDomainCollectionTests : CdnManagementTestBase
    {
        public CdnCustomDomainCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            //In this test, the CName mapping from custom domain "customdomaintest1.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string cdnCustomDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest1.azuretest.net";
            CdnCustomDomainResource cdnCustomDomain = await CreateCdnCustomDomain(cdnEndpoint, cdnCustomDomainName, hostName);
            Assert.AreEqual(cdnCustomDomainName, cdnCustomDomain.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnCustomDomains().CreateOrUpdateAsync(WaitUntil.Completed, cdnCustomDomainName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            //In this test, the CName mapping from custom domain "customdomaintest2.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string cdnCustomDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest2.azuretest.net";
            _ = await CreateCdnCustomDomain(cdnEndpoint, cdnCustomDomainName, hostName);
            int count = 0;
            await foreach (var tempCustomDomain in cdnEndpoint.GetCdnCustomDomains().GetAllAsync())
            {
                if (tempCustomDomain.Data.HostName.Equals("customdomaintest2.azuretest.net"))
                    count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            //In this test, the CName mapping from custom domain "customdomaintest3.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            ProfileResource cdnProfile = await rg.GetProfiles().GetAsync("testProfile");
            CdnEndpointResource cdnEndpoint = await cdnProfile.GetCdnEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string cdnCustomDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest3.azuretest.net";
            CdnCustomDomainResource cdnCustomDomain = await CreateCdnCustomDomain(cdnEndpoint, cdnCustomDomainName, hostName);
            CdnCustomDomainResource getCdnCustomDomain = await cdnEndpoint.GetCdnCustomDomains().GetAsync(cdnCustomDomainName);
            ResourceDataHelper.AssertValidCustomDomain(cdnCustomDomain, getCdnCustomDomain);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await cdnEndpoint.GetCdnCustomDomains().GetAsync(null));
        }
    }
}
