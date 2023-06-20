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
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<(WebTestCollection WebtestCollection, ApplicationInsightsComponentCollection ComponentCollection)> GetCredentialCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var webtestCollection = resourceGroup.GetWebTests();
            var coponentCollection = resourceGroup.GetApplicationInsightsComponents();
            return (webtestCollection, coponentCollection);
        }

        [TestCase]
        public async Task WebTestApiTests()
        {
            //0.Prepare
            (WebTestCollection WebtestCollection, ApplicationInsightsComponentCollection ComponentCollection) = await GetCredentialCollectionAsync();
            var componentName = Recording.GenerateAssetName("component");
            var componentInput = ResourceDataHelpers.GetComponentData(DefaultLocation);
            var lroc = await ComponentCollection.CreateOrUpdateAsync(WaitUntil.Completed, componentName, componentInput);
            ApplicationInsightsComponentResource component = lroc.Value;
            //1.CreateOrUpdate
            var name = Recording.GenerateAssetName("webtest");
            var name2 = Recording.GenerateAssetName("webtest");
            var name3 = Recording.GenerateAssetName("webtest");
            var input = ResourceDataHelpers.GetWebTestData(DefaultLocation, ResourceGroupName, componentName, name);
            var lro = await WebtestCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            WebTestResource webtst = lro.Value;
            Assert.AreEqual(name, webtst.Data.Name);
            //2.Get
            WebTestResource webtest2 = await webtst.GetAsync();
            ResourceDataHelpers.AssertWebTestData(webtst.Data, webtest2.Data);
            //3.GetAll
            _ = await WebtestCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await WebtestCollection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await WebtestCollection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in WebtestCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4.Exists
            Assert.IsTrue(await WebtestCollection.ExistsAsync(name));
            Assert.IsFalse(await WebtestCollection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await WebtestCollection.ExistsAsync(null));
            //Resource
            //5.Get
            WebTestResource webtest3 = await webtst.GetAsync();
            ResourceDataHelpers.AssertWebTestData(webtst.Data, webtest3.Data);
            //6.Delete
            await webtst.DeleteAsync(WaitUntil.Completed);
        }
    }
}
