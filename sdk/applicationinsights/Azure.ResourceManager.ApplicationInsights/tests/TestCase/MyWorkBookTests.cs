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
    public class MyWorkBookTests : ApplicationInsightsManagementTestBase
    {
        public MyWorkBookTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<MyWorkbookCollection> GetMyWorkBookCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetMyWorkbooks();
            return collection;
        }

        [TestCase]
        public async Task MyWorkbookApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetMyWorkBookCollectionAsync();
            var name = "deadb33f-8bee-4d3b-a059-9be8dac93960";
            var input = ResourceDataHelpers.GetMyWorkbookData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            MyWorkbookResource myworkbook = lro.Value;
            Assert.AreEqual(name, myworkbook.Data.Name);
            //2.Get
            MyWorkbookResource myworkbook2 = await myworkbook.GetAsync();
            ResourceDataHelpers.AssertWorkBookData(myworkbook.Data, myworkbook2.Data);
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
            MyWorkbookResource myworkbook3 = await myworkbook.GetAsync();
            ResourceDataHelpers.AssertWorkBookData(myworkbook.Data, myworkbook3.Data);
            //6.Delete
            await myworkbook.DeleteAsync(WaitUntil.Completed);
        }
    }
}
