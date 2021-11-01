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
    public class CustomDomainCollectionTests : CdnManagementTestBase
    {
        public CustomDomainCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-1.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest-1.azuretest.net";
            CustomDomain customDomain = await CreateCustomDomain(endpoint, customDomainName, hostName);
            Assert.AreEqual(customDomainName, customDomain.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetCustomDomains().CreateOrUpdateAsync(customDomainName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-2.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest-2.azuretest.net";
            _ = await CreateCustomDomain(endpoint, customDomainName, hostName);
            int count = 0;
            await foreach (var tempCustomDomain in endpoint.GetCustomDomains().GetAllAsync())
            {
                if (tempCustomDomain.Data.HostName.Equals("customdomaintest-2.azuretest.net"))
                    count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-3.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await subscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = Recording.GenerateAssetName("customDomain-");
            string hostName = "customdomaintest-3.azuretest.net";
            CustomDomain customDomain = await CreateCustomDomain(endpoint, customDomainName, hostName);
            CustomDomain getCustomDomain = await endpoint.GetCustomDomains().GetAsync(customDomainName);
            ResourceDataHelper.AssertValidCustomDomain(customDomain, getCustomDomain);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetCustomDomains().GetAsync(null));
        }
    }
}
