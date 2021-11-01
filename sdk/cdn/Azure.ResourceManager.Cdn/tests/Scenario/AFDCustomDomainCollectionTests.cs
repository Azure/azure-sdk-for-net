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
    public class AFDCustomDomainCollectionTests : CdnManagementTestBase
    {
        public AFDCustomDomainCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string AFDHostName = "customdomain4afd-1.azuretest.net";
            AFDDomain AFDCustomDomain = await CreateAFDCustomDomain(AFDProfile, AFDCustomDomainName, AFDHostName);
            Assert.AreEqual(AFDCustomDomainName, AFDCustomDomain.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDDomains().CreateOrUpdateAsync(null, AFDCustomDomain.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDDomains().CreateOrUpdateAsync(AFDCustomDomainName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string AFDHostName = "customdomain4afd-2.azuretest.net";
            _ = await CreateAFDCustomDomain(AFDProfile, AFDCustomDomainName, AFDHostName);
            int count = 0;
            await foreach (var tempAFDCustomDomain in AFDProfile.GetAFDDomains().GetAllAsync())
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
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string AFDHostName = "customdomain4afd-3.azuretest.net";
            AFDDomain AFDCustomDomain = await CreateAFDCustomDomain(AFDProfile, AFDCustomDomainName, AFDHostName);
            AFDDomain getAFDCustomDomain = await AFDProfile.GetAFDDomains().GetAsync(AFDCustomDomainName);
            ResourceDataHelper.AssertValidAFDCustomDomain(AFDCustomDomain, getAFDCustomDomain);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetAFDDomains().GetAsync(null));
        }
    }
}
