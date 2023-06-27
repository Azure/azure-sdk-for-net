// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.ApplicationInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests.TestCase
{
    public class WorkBookTests : ApplicationInsightsManagementTestBase
    {
        public WorkBookTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<WorkbookCollection> GetWorkBookCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetWorkbooks();
            return collection;
        }

        [TestCase]
        public async Task WorkbookApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetWorkBookCollectionAsync();
            var name = "deadb33f-5e0d-4064-8ebb-1a4ed0313eb2";
            string sourceId = $"/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/{ResourceGroupName}";
            //var name2 = Recording.GenerateAssetName("workbook");
            //var name3 = Recording.GenerateAssetName("workbook");
            var input = ResourceDataHelpers.GetWorkbookData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input, sourceId);
            WorkbookResource workbook = lro.Value;
            Assert.AreEqual(name, workbook.Data.Name);
            //2.Get
            WorkbookResource workbook2 = await workbook.GetAsync();
            ResourceDataHelpers.AssertWorkBook(workbook.Data, workbook2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync(CategoryType.Workbook))
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4.Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //Resource
            //5.Get
            WorkbookResource workbook3 = await workbook.GetAsync();
            ResourceDataHelpers.AssertWorkBook(workbook.Data, workbook3.Data);
            //6.Delete
            await workbook.DeleteAsync(WaitUntil.Completed);
        }
    }
}
