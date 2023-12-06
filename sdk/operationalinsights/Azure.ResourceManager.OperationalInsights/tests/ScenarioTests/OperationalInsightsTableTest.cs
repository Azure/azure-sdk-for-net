// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsTableTest: OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public OperationalInsightsTableTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task OperationalInsightsTableTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsTable-test", _location);

            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var _collection = workSpace.GetOperationalInsightsTables();

            //OperationalInsightsTableCollection_Create
            var tablelist = workSpace.GetOperationalInsightsTables().ToList();
            foreach (var item in tablelist)
            {
                Console.WriteLine(item.Data.Name);
            }
            var tableName = Recording.GenerateAssetName("OpTable");
            var tableData = new OperationalInsightsTableData();
            var opTable = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, tableName, tableData)).Value;
            Assert.IsNotNull(opTable);
            Assert.AreEqual(tableName, opTable.Data.Name);

            //OperationalInsightsTableCollection_Exist
            var exist = await _collection.ExistsAsync(tableName);
            Assert.IsTrue(exist);

            //OperationalInsightsTableCollection_Get
            var getResult = await _collection.GetAsync(tableName);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, opTable.Data.Name);

            //OperationalInsightsTableCollection_GetAll
            var tableName2 = Recording.GenerateAssetName("OpTable2nd");
            var tableData2 = new OperationalInsightsTableData();
            var opTable2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, tableName2, tableData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.Name == opTable.Data.Name));
            Assert.IsTrue(list.Exists(item => item.Data.Name == opTable2.Data.Name));
            await opTable2.DeleteAsync(WaitUntil.Completed);

            //OperationalInsightsTableCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(tableName)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(opTable.Data.Name, getIfExists.Data.Name);
            Assert.AreEqual(opTable.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsTableResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsTableResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, workSpace.Data.Name, opTable.Data.Name);
            var identifierResource = Client.GetOperationalInsightsTableResource(resourceId);
            Assert.IsNotNull(identifierResource);
            Assert.AreEqual(identifierResource.Data.Name, opTable.Data.Name);
            Assert.AreEqual(identifierResource.Data.Id, opTable.Data.Id);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(opTable.Data.Id, verify.Data.Id);
            Assert.AreEqual(opTable.Data.Name, verify.Data.Name);

            //OperationalInsightsTableResource_Migrate
            var migrate = await opTable.MigrateAsync();

            //OperationalInsightsTableResource_CancelSearch
            var cancel = await opTable.CancelSearchAsync();

            //OperationalInsightsTableResource_Update
            var updateData = new OperationalInsightsTableData();
            var update = (await opTable.UpdateAsync(WaitUntil.Completed, updateData)).Value;
            Assert.IsNotNull(update);

            //OperationalInsightsTableResource_Delete
            var delete = await opTable.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(tableName));
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }
    }
}
