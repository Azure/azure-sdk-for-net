// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApplicationInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests.TestCase
{
    public class WebTests : ApplicationInsightsManagementTestBase
    {
        public WebTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<WebTestCollection> GetCredentialCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var webtestCollection = resourceGroup.GetWebTests();
            return webtestCollection;
        }

        [TestCase]
        public async Task WebTestApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetCredentialCollectionAsync();
            var name = Recording.GenerateAssetName("webtest");
            var name2 = Recording.GenerateAssetName("webtest");
            var name3 = Recording.GenerateAssetName("webtest");
            var input = ResourceDataHelpers.GetWebTestData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            WebTestResource webtst = lro.Value;
            Assert.AreEqual(name, webtst.Data.Name);
            //2.Get
            WebTestResource webtest2 = await webtst.GetAsync();
            ResourceDataHelpers.AssertWebTestData(webtst.Data, webtest2.Data);
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
            WebTestResource webtest3 = await webtst.GetAsync();
            ResourceDataHelpers.AssertWebTestData(webtst.Data, webtest3.Data);
            //6.Delete
            await webtst.DeleteAsync(WaitUntil.Completed);
        }
    }
}
