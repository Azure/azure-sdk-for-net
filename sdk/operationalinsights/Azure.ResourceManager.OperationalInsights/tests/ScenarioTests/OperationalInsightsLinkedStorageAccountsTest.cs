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
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsLinkedStorageAccountsTest : OperationalInsightsManagementTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private readonly AzureLocation _location = AzureLocation.EastUS;
        public OperationalInsightsLinkedStorageAccountsTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        { }

        [Test]
        public async Task OperationalInsightsLinkedStorageAccountsTestCase()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(_subscription, "OperationalInsightsLinkedStorageAccounts-test", _location);

            var workSpaceName = Recording.GenerateAssetName("InWorkspace");
            var workSpaceData = new OperationalInsightsWorkspaceData(_location);
            var workSpace = (await _resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workSpaceName, workSpaceData)).Value;
            var storageAccount = await CreateStorageAccount();
            var _collection = workSpace.GetAllOperationalInsightsLinkedStorageAccounts();

            //OperationalInsightsLinkedStorageAccountsCollection_Create
            string linkedStName = Recording.GenerateAssetName("OpLinkedSt");
            var linkedStData = new OperationalInsightsLinkedStorageAccountsData()
            {
                StorageAccountIds =
                {
                    storageAccount.Data.Id
                }
            };
            var linkedSt = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, OperationalInsightsDataSourceType.CustomLogs, linkedStData)).Value;
            Assert.IsNotNull(linkedSt);
            //Assert.AreEqual(linkedStName, linkedSt.Data.Name);

            //OperationalInsightsLinkedStorageAccountsCollection_Exist
            var exist = await _collection.ExistsAsync(OperationalInsightsDataSourceType.CustomLogs);
            Assert.IsTrue(exist);

            //OperationalInsightsLinkedStorageAccountsCollection_Get
            var getResult = await _collection.GetAsync(OperationalInsightsDataSourceType.CustomLogs);
            Assert.IsNotEmpty(getResult.Value.Data.Id);
            Assert.AreEqual(getResult.Value.Data.Name, linkedSt.Data.Name);

            //OperationalInsightsLinkedStorageAccountsCollection_GetAll
            var linkedStData2 = new OperationalInsightsLinkedStorageAccountsData()
            {
                StorageAccountIds =
                {
                    storageAccount.Data.Id
                }
            };
            var linkedSt2 = (await _collection.CreateOrUpdateAsync(WaitUntil.Completed, OperationalInsightsDataSourceType.Query, linkedStData2)).Value;
            var list = await _collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Count > 1);
            Assert.IsTrue(list.Exists(item => item.Data.DataSourceType == linkedSt.Data.DataSourceType));
            Assert.IsTrue(list.Exists(item => item.Data.DataSourceType == linkedSt2.Data.DataSourceType));
            await linkedSt2.DeleteAsync(WaitUntil.Completed);

            //OperationalInsightsLinkedStorageAccountsCollection_GetIfExists
            var getIfExists = (await _collection.GetIfExistsAsync(OperationalInsightsDataSourceType.CustomLogs)).Value;
            Assert.IsNotNull(getIfExists);
            Assert.AreEqual(linkedSt.Data.DataSourceType, getIfExists.Data.DataSourceType);
            Assert.AreEqual(linkedSt.Data.Id, getIfExists.Data.Id);

            //OperationalInsightsLinkedStorageAccountsResource_CreateResourceIdentifier and Get
            var resourceId = OperationalInsightsLinkedStorageAccountsResource.CreateResourceIdentifier(_subscription.Data.SubscriptionId, _resourceGroup.Data.Name, workSpace.Data.Name, OperationalInsightsDataSourceType.CustomLogs);
            var identifierResource = Client.GetOperationalInsightsLinkedStorageAccountsResource(resourceId);
            Assert.IsNotNull(identifierResource);
            Assert.AreEqual(identifierResource.Id, linkedSt.Id);
            var verify = (await identifierResource.GetAsync()).Value; //Get
            Assert.IsNotNull(verify);
            Assert.AreEqual(linkedSt.Data.Id, verify.Data.Id);
            Assert.AreEqual(linkedSt.Data.DataSourceType, verify.Data.DataSourceType);

            //OperationalInsightsLinkedStorageAccountsResource_Update
            var updateSt = await CreateStorageAccount();
            var updateData = new OperationalInsightsLinkedStorageAccountsData()
            {
                StorageAccountIds =
                {
                    updateSt.Data.Id
                }
            };
            var update = (await linkedSt.UpdateAsync(WaitUntil.Completed, updateData)).Value;
            Assert.IsNotNull(update);
            Assert.IsTrue(update.Data.StorageAccountIds.Contains(updateSt.Data.Id));

            //OperationalInsightsLinkedStorageAccountsResource_Delete
            var delete = await linkedSt.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(delete.HasCompleted);
            Assert.IsFalse(await _collection.ExistsAsync(OperationalInsightsDataSourceType.CustomLogs));
            await workSpace.DeleteAsync(WaitUntil.Completed);
            await storageAccount.DeleteAsync(WaitUntil.Completed);
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        public async Task<StorageAccountResource> CreateStorageAccount()
        {
            var stName = Recording.GenerateAssetName("linkedst");
            var stData = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardGrs), StorageKind.Storage, _location);
            return (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, stName, stData)).Value;
        }
    }
}
