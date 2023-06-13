// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.SelfHelp.Tests
{
    using Azure.Core.TestFramework;
    using Azure.Core;
    using System.Threading.Tasks;
    using Azure.ResourceManager.SelfHelp.Tests;
    using NUnit.Framework;
    using System;
    using Azure.ResourceManager.SelfHelp.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class DiscoverySolutionsTests : SelfHelpManagementTestBase
    {
        public DiscoverySolutionsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [Test]
        public async Task ListDisocverySolutionsTest()
        {
            var subId = "6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba";
            var resourceGroupName = "DiagnosticsRp-Gateway-Public-Dev-Global";
            var resourceName = "DiagRpGwPubDev";
            var insightsResourceName = Recording.GenerateAssetName("testResource");
            ResourceIdentifier scope = new ResourceIdentifier($"/subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{resourceName}");

            var listDisocverySolutionsData = Client.GetSelfHelpDiscoverySolutionsAsync(scope);
            var response = await listDisocverySolutionsData.ToEnumerableAsync();
            Assert.NotNull(response.First());
        }
    }
}
