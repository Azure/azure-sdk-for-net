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
    public class DataConnectorCollectionTests : SecurityInsightsManagementTestBase
    {
        public DataConnectorCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<DataConnectorCollection> GetDataConnectorCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDataConnectors(workspaceName);
        }

        [TestCase]
        public async Task DataConnectorCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetDataConnectorCollectionAsync();
            var name = Recording.GenerateAssetName("DataConnectors-");
            var name2 = Recording.GenerateAssetName("DataConnectors-");
            var name3 = Recording.GenerateAssetName("DataConnectors-");
            var input = ResourceDataHelpers.GetDataConnectorData(workspaceName);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataConnectorResource dataConnector1 = lro.Value;
            Assert.AreEqual(name, dataConnector1.Data.Name);
            //2.Get
            DataConnectorResource dataConnector2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertDataConnectorData(dataConnector1.Data, dataConnector2.Data);
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
