// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class MigrateResultOperationSourceTest : CdnManagementTestBase
    {
        public MigrateResultOperationSourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task MigrateResultTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync("cdn-sdk-test");

            var content = new MigrationContent(new CdnSku()
            {
                Name = CdnSkuName.StandardAzureFrontDoor,
            }, new WritableSubResource()
            {
                Id = new ResourceIdentifier("/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cdn-sdk-test/providers/Microsoft.Network/frontdoors/cdn-sdk-test"),
            }, "cdn-sdk-test");
            if (IsAsync)
            {
                content = new MigrationContent(new CdnSku()
                {
                    Name = CdnSkuName.StandardAzureFrontDoor,
                }, new WritableSubResource()
                {
                    Id = new ResourceIdentifier("/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cdn-sdk-test/providers/Microsoft.Network/frontdoors/cdn-sdk-test1"),
                }, "cdn-sdk-test1");
            }
            await rg.MigrateProfileAsync(WaitUntil.Completed, content);
        }
    }
}
