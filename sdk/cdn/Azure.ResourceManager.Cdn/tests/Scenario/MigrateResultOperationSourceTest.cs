// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class MigrateResultOperationSourceTest : CdnManagementTestBase
    {
        public MigrateResultOperationSourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task MigrateResultTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            var classic = new Resources.Models.WritableSubResource();
            var sku = new CdnSku { Name = CdnSkuName.StandardMicrosoft };
            MigrationContent migrationContent = new(sku, classic, "test");
            var output = await rg.MigrateProfileAsync(WaitUntil.Completed, migrationContent);
            Assert.IsNotNull(output);
        }
    }
}
