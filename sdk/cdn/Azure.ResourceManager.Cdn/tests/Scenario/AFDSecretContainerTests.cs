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
    public class AFDSecretContainerTests : CdnManagementTestBase
    {
        public AFDSecretContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            //string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            //Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            //string secretName = Recording.GenerateAssetName("AFDSecret-");
            //Secret secret = await CreateSecret(AFDProfile, secretName);
            //Assert.AreEqual(secretName, secret.Data.Name);
            //Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecrets().CreateOrUpdateAsync(null, secret.Data));
            //Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecrets().CreateOrUpdateAsync(secretName, null));
        }

        //[TestCase]
        //[RecordedTest]
        //public async Task List()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //    string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
        //    Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.PremiumAzureFrontDoor);
        //    string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
        //    AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
        //    string securityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
        //    _ = await CreateSecurityPolicy(AFDProfile, AFDEndpointInstance, securityPolicyName);
        //    int count = 0;
        //    await foreach (var tempSecurityPolicy in AFDProfile.GetSecurityPolicies().GetAllAsync())
        //    {
        //        count++;
        //    }
        //    Assert.AreEqual(count, 1);
        //}

        //[TestCase]
        //[RecordedTest]
        //public async Task Get()
        //{
        //    ResourceGroup rg = await CreateResourceGroup("testRg-");
        //    string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
        //    Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.PremiumAzureFrontDoor);
        //    string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
        //    AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
        //    string securityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
        //    SecurityPolicy securityPolicy = await CreateSecurityPolicy(AFDProfile, AFDEndpointInstance, securityPolicyName);
        //    SecurityPolicy getSecurityPolicy = await AFDProfile.GetSecurityPolicies().GetAsync(securityPolicyName);
        //    ResourceDataHelper.AssertValidSecurityPolicy(securityPolicy, getSecurityPolicy);
        //    Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecurityPolicies().GetAsync(null));
        //}
    }
}
