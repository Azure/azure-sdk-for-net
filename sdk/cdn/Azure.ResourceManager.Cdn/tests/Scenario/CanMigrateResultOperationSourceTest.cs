// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CanMigrateResultOperationSourceTest : CdnManagementTestBase
    {
        public CanMigrateResultOperationSourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CanMigrateResultTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            var classic = new Resources.Models.WritableSubResource();
            CanMigrateContent canMigrateContent = new(classic);
            var output = await rg.CanMigrateProfileAsync(WaitUntil.Completed, canMigrateContent);
            Assert.IsNotNull(output);
        }
    }
}
