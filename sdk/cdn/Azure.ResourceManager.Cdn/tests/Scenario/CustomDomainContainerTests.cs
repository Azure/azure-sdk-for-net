// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CustomDomainContainerTests : CdnManagementTestBase
    {
        public CustomDomainContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-1.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = Recording.GenerateAssetName("customDomain-");
            CustomDomainParameters customDomainParameters = CreateCustomDomainParameters("customdomaintest-1.azuretest.net");
            var lro = await endpoint.GetCustomDomains().CreateOrUpdateAsync(customDomainName, customDomainParameters);
            CustomDomain customDomain = lro.Value;
            Assert.AreEqual(customDomainName, customDomain.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetCustomDomains().CreateOrUpdateAsync(null, customDomainParameters));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetCustomDomains().CreateOrUpdateAsync(customDomainName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            //In this test, the CName mapping from custom domain "customdomaintest-2.azuretest.net" to endpoint "testEndpoint4dotnetsdk.azureedge.net" is created in advance.
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = Recording.GenerateAssetName("customDomain-");
            CustomDomainParameters customDomainParameters = CreateCustomDomainParameters("customdomaintest-2.azuretest.net");
            var lro = await endpoint.GetCustomDomains().CreateOrUpdateAsync(customDomainName, customDomainParameters);
            _ = lro.Value;
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
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().GetAsync("CdnTest");
            Profile profile = await rg.GetProfiles().GetAsync("testProfile");
            Endpoint endpoint = await profile.GetEndpoints().GetAsync("testEndpoint4dotnetsdk");
            string customDomainName = Recording.GenerateAssetName("customDomain-");
            CustomDomainParameters customDomainParameters = CreateCustomDomainParameters("customdomaintest-3.azuretest.net");
            var lro = await endpoint.GetCustomDomains().CreateOrUpdateAsync(customDomainName, customDomainParameters);
            CustomDomain customDomain = lro.Value;
            CustomDomain getCustomDomain = await endpoint.GetCustomDomains().GetAsync(customDomainName);
            AssertValidCustomDomain(customDomain, getCustomDomain);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await endpoint.GetCustomDomains().GetAsync(null));
        }

        private static void AssertValidCustomDomain(CustomDomain model, CustomDomain getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.CustomHttpsProvisioningState, getResult.Data.CustomHttpsProvisioningState);
            Assert.AreEqual(model.Data.CustomHttpsProvisioningSubstate, getResult.Data.CustomHttpsProvisioningSubstate);
            Assert.AreEqual(model.Data.ValidationData, getResult.Data.ValidationData);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
        }
    }
}
