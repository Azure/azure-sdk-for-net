// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Automation.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Automation.Tests.TestCase
{
    public class ScheduleTests : AutomationManagementTestBase
    {
        public ScheduleTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationScheduleCollection> GetScheduleCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var accountCollection = resourceGroup.GetAutomationAccounts();
            var accountName = Recording.GenerateAssetName("account");
            var input = ResourceDataHelpers.GetAccountData();
            var accountResource = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, input);
            return accountResource.Value.GetAutomationSchedules();
        }

        [TestCase]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/36058")]
        public async Task ScheduleApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetScheduleCollectionAsync();
            var name = Recording.GenerateAssetName("schedule");
            var name2 = Recording.GenerateAssetName("schedule");
            var name3 = Recording.GenerateAssetName("schedule");
            var input = ResourceDataHelpers.GetScheduleData(name, Recording.UtcNow.AddDays(1));
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationScheduleResource schedule = lro.Value;
            Assert.AreEqual(name, schedule.Data.Name);
            //2.Get
            AutomationScheduleResource schedule2 = await schedule.GetAsync();
            ResourceDataHelpers.AssertSchedule(schedule.Data, schedule2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            AutomationScheduleResource schedule3 = await schedule.GetAsync();
            ResourceDataHelpers.AssertSchedule(schedule.Data, schedule3.Data);
            //6.Delete
            await schedule.DeleteAsync(WaitUntil.Completed);
        }
    }
}
