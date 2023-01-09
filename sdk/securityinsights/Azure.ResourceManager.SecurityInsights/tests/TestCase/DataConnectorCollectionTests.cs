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

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        private SecurityInsightsDataConnectorCollection GetDataConnectorCollectionAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights)
        {
            return operationalInsights.GetSecurityInsightsDataConnectors();
        }

        [TestCase]
        public async Task DataConnectorCollectionApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            //1.CreateOrUpdate
            var collection = GetDataConnectorCollectionAsync(operationalInsights);
            var name = Recording.GenerateAssetName("DataConnectors-");
            var name2 = Recording.GenerateAssetName("DataConnectors-");
            var name3 = Recording.GenerateAssetName("DataConnectors-");
            var input = ResourceDataHelpers.GetDataConnectorData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            SecurityInsightsDataConnectorResource dataConnector1 = lro.Value;
            Assert.AreEqual(name, dataConnector1.Data.Name);
            //2.Get
            SecurityInsightsDataConnectorResource dataConnector2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertDataConnectorData(dataConnector1.Data, dataConnector2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            //_ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
