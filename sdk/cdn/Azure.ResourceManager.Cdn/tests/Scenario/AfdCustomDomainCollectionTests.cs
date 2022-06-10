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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-1.azuretest.net";
            FrontDoorCustomDomainResource afdCustomDomain = await CreateAfdCustomDomain(afdProfileResource, afdCustomDomainName, afdHostName);
            Assert.AreEqual(afdCustomDomainName, afdCustomDomain.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorCustomDomains().CreateOrUpdateAsync(WaitUntil.Completed, null, afdCustomDomain.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorCustomDomains().CreateOrUpdateAsync(WaitUntil.Completed, afdCustomDomainName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-2.azuretest.net";
            _ = await CreateAfdCustomDomain(afdProfileResource, afdCustomDomainName, afdHostName);
            int count = 0;
            await foreach (var tempAfdCustomDomain in afdProfileResource.GetFrontDoorCustomDomains().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdCustomDomainName = Recording.GenerateAssetName("AFDCustomDomain-");
            string afdHostName = "customdomain4afd-3.azuretest.net";
            FrontDoorCustomDomainResource AfdCustomDomain = await CreateAfdCustomDomain(afdProfileResource, afdCustomDomainName, afdHostName);
            FrontDoorCustomDomainResource getAfdCustomDomain = await afdProfileResource.GetFrontDoorCustomDomains().GetAsync(afdCustomDomainName);
            ResourceDataHelper.AssertValidAfdCustomDomain(AfdCustomDomain, getAfdCustomDomain);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfileResource.GetFrontDoorCustomDomains().GetAsync(null));
        }
    }
}
