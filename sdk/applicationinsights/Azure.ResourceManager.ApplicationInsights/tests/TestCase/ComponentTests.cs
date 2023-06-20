// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApplicationInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests.TestCase
{
    public class ComponentTests : ApplicationInsightsManagementTestBase
    {
        public ComponentTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ApplicationInsightsComponentCollection> GetComponentCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetApplicationInsightsComponents();
            return collection;
        }

        [TestCase]
        public async Task CredentialApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetComponentCollectionAsync();
            var name = Recording.GenerateAssetName("component");
            var name2 = Recording.GenerateAssetName("component");
            var name3 = Recording.GenerateAssetName("component");
            var input = ResourceDataHelpers.GetComponentData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            ApplicationInsightsComponentResource component = lro.Value;
            Assert.AreEqual(name, component.Data.Name);
            //2.Get
            ApplicationInsightsComponentResource component2 = await component.GetAsync();
            ResourceDataHelpers.AssertComponment(component.Data, component2.Data);
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
            ApplicationInsightsComponentResource component3 = await component.GetAsync();
            ResourceDataHelpers.AssertComponment(component.Data, component3.Data);
            //6.Delete
            await component.DeleteAsync(WaitUntil.Completed);
        }
    }
}
