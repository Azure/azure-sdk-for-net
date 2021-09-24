// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class ResourceUsageOperationsTests : CdnManagementTestBase
    {
        public ResourceUsageOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceUsage()
        {
            ResourceGroup rg = await CreateResourceGroup("testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            _ = await CreateProfile(rg, profileName, SkuName.StandardAkamai);
            int count = 0;
            await foreach (var tempResourceUsage in Client.DefaultSubscription.GetResourceUsagesAsync())
            {
                count++;
                if (tempResourceUsage.ResourceType.Equals("profile"))
                {
                    Assert.Greater(tempResourceUsage.CurrentValue, 0);
                    Assert.AreEqual(tempResourceUsage.Limit, 25);
                }
            }
            Assert.AreEqual(count, 1);
        }
    }
}
