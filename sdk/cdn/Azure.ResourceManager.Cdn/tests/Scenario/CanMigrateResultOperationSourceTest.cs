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
    public class CanMigrateResultOperationSourceTest : CdnManagementTestBase
    {
        public CanMigrateResultOperationSourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        public async Task CanMigrateResultTest()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await subscription.GetResourceGroupAsync("cdn-sdk-test");
            var content = new CanMigrateContent(new WritableSubResource()
            {
                Id = new ResourceIdentifier("/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cdn-sdk-test/providers/Microsoft.Network/frontdoors/cdn-sdk-test"),
            });
            await rg.CanMigrateProfileAsync(WaitUntil.Completed, content);
        }
    }
}
