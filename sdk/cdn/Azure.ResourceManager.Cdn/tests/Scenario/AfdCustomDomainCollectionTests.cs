// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdCustomDomainCollectionTests : CdnManagementTestBase
    {
        public AfdCustomDomainCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-1.azuretest.net";
            AfdCustomDomain afdCustomDomain = await CreateAfdCustomDomain(afdProfile, afdCustomDomainName, afdHostName);
            Assert.AreEqual(afdCustomDomainName, afdCustomDomain.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdCustomDomains().CreateOrUpdateAsync(null, afdCustomDomain.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdCustomDomains().CreateOrUpdateAsync(afdCustomDomainName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-2.azuretest.net";
            _ = await CreateAfdCustomDomain(afdProfile, afdCustomDomainName, afdHostName);
            int count = 0;
            await foreach (var tempAfdCustomDomain in afdProfile.GetAfdCustomDomains().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-3.azuretest.net";
            AfdCustomDomain AfdCustomDomain = await CreateAfdCustomDomain(afdProfile, afdCustomDomainName, afdHostName);
            AfdCustomDomain getAfdCustomDomain = await afdProfile.GetAfdCustomDomains().GetAsync(afdCustomDomainName);
            ResourceDataHelper.AssertValidAfdCustomDomain(AfdCustomDomain, getAfdCustomDomain);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdCustomDomains().GetAsync(null));
        }
    }
}
