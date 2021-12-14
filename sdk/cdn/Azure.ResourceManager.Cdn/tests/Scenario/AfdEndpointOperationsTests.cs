// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdEndpointOperationsTests : CdnManagementTestBase
    {
        public AfdEndpointOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            await afdEndpointInstance.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdEndpointInstance.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            AfdEndpointUpdateOptions updateOptions = new AfdEndpointUpdateOptions
            {
                OriginResponseTimeoutSeconds = 30
            };
            updateOptions.Tags.Add("newTag", "newValue");
            var lro = await afdEndpointInstance.UpdateAsync(updateOptions);
            AfdEndpoint updatedAfdEndpointInstance = lro.Value;
            ResourceDataHelper.AssertAfdEndpointUpdate(updatedAfdEndpointInstance, updateOptions);
        }

        [TestCase]
        [RecordedTest]
        public async Task Purge()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            AfdPurgeOptions purgeParameters = new AfdPurgeOptions(new List<string>
            {
                "/*"
            });
            Assert.DoesNotThrowAsync(async () => await afdEndpointInstance.PurgeContentAsync(purgeParameters));
        }

        [TestCase]
        [RecordedTest]
        public async Task Usages()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            int count = 0;
            await foreach (var tempUsage in afdEndpointInstance.GetResourceUsageAsync())
            {
                count++;
                Assert.AreEqual(tempUsage.CurrentValue, 0);
                Assert.AreEqual(tempUsage.Unit, UsageUnit.Count);
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateCustomDomain()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            ValidateCustomDomainInput validateCustomDomainInput = new ValidateCustomDomainInput("customdomain4afd.azuretest.net");
            ValidateCustomDomainOutput validateCustomDomainOutput  = await afdEndpointInstance.ValidateCustomDomainAsync(validateCustomDomainInput);
            Assert.False(validateCustomDomainOutput.CustomDomainValidated);
        }
    }
}
