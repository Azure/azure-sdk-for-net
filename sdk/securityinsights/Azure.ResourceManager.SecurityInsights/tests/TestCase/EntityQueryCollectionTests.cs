// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class EntityQueryCollectionTests : SecurityInsightsManagementTestBase
    {
        public EntityQueryCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<EntityQueryCollection> GetEntityQueryCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetEntityQueries(workspaceName);
        }

        [TestCase]
        public async Task EntityQueryCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetEntityQueryCollectionAsync();
            var name = Recording.GenerateAssetName("EntityQuery-");
            var name2 = Recording.GenerateAssetName("EntityQuery-");
            var name3 = Recording.GenerateAssetName("EntityQuery-");
            var input = ResourceDataHelpers.GetEntityQueryData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            EntityQueryResource entityQuery1 = lro.Value;
            Assert.AreEqual(name, entityQuery1.Data.Name);
            //2.Get
            EntityQueryResource entityQuery2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertEntityQueryData(entityQuery1.Data, entityQuery2.Data);
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
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
