namespace HybridData.Tests.Tests
{
    using Microsoft.Azure.Management.HybridData;
    using Microsoft.Azure.Management.HybridData.Models;
    using Microsoft.Rest.Azure;
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class DataStoresTest : HybridDataTestBase
    {
        public DataStoresTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        //DataStores_ListByDataManager
        [Fact]
        public void DataStores_ListByDataManager()
        {
            try
            {
                var dataStoreList = Client.DataStores.ListByDataManager(ResourceGroupName, DataManagerName);
                Assert.NotNull(dataStoreList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataStores_Get
        [Fact]
        public void DataStores_Get()
        {
            try
            {
                string dataStoreName = TestConstants.DefaultDataSourceName;
                var dataStore = Client.DataStores.Get(dataStoreName: dataStoreName,
                    resourceGroupName: ResourceGroupName, dataManagerName: DataManagerName);
                Assert.NotNull(dataStore);
                Assert.Equal(dataStore.Name, dataStoreName);

                string dataStoreName2 = TestConstants.DefaultDataSinkName;
                var dataStore2 = Client.DataStores.Get(dataStoreName: dataStoreName2,
                    resourceGroupName: ResourceGroupName, dataManagerName: DataManagerName);
                Assert.NotNull(dataStore2);
                Assert.Equal(dataStore2.Name, dataStoreName2);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataStores_CreateOrUpdate
        [Fact]
        public void DataStores_CreateOrUpdate_DataSource()
        {
            try
            {
                string dataStoreName = TestConstants.DefaultDataSourceName;
                DataStore dataStore = Client.DataStores.CreateStorSimpleDataStore(subscriptionIdOfDataManager: SubscriptionId,
                    subscriptionIdOfStorSimpleDevice: TestConstants.DefaultStorSimpleResourceSubscriptionId,
                    resourceGroupOfDataManager: ResourceGroupName,
                    resourceGroupOfStorSimpleDevice: TestConstants.DefaultStorSimpleDeviceResourceGroup,
                    dataManagerName: DataManagerName,
                    serviceEncryptionKey: StorSimpleDeviceServiceEncryptionKey,
                    storSimpleResourceName: TestConstants.DefaultStorSimpleResourceName,
                    client: Client);
                var returnedDataStore = Client.DataStores.CreateOrUpdate(dataStoreName, dataStore, ResourceGroupName, DataManagerName);
                Assert.NotNull(returnedDataStore);
                //do a get and confirm
                var dataStoreFromGet = Client.DataStores.Get(dataStoreName: dataStoreName,
                    resourceGroupName: ResourceGroupName, dataManagerName: DataManagerName);
                Assert.NotNull(dataStoreFromGet);
                Assert.Equal(dataStoreFromGet.Name, dataStoreName);
                Assert.Equal(returnedDataStore.Name, dataStoreName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }


        //DataStores_CreateOrUpdate
        [Fact]
        public void DataStores_CreateOrUpdate_DataSink()
        {
            try
            {
                string dataStoreName = TestConstants.DefaultDataSinkName;
                DataStore dataStore = Client.DataStores.CreateAzureStorageDataStore(
                    subscriptionIdOfDataManager: SubscriptionId,
                    subscriptionIdOfStorageAccount: SubscriptionId,
                    resourceGroupOfDataManager: ResourceGroupName,
                    resourceGroupOfStorageAccount: ResourceGroupName,
                    dataManagerName: DataManagerName,
                    storageAccountKey: AzureStorageAccountAccessKey,
                    azureStorageName: TestConstants.DefaultStorageAccountName,
                    client: Client);
                var returnedDataStore = Client.DataStores.CreateOrUpdate(dataStoreName, dataStore, ResourceGroupName,
                    DataManagerName);
                Assert.NotNull(returnedDataStore);
                //do a get and confirm
                var dataStoreFromGet = Client.DataStores.Get(dataStoreName, ResourceGroupName, DataManagerName);
                Assert.NotNull(dataStoreFromGet);
                Assert.Equal(dataStoreFromGet.Name, dataStoreName);
                Assert.Equal(returnedDataStore.Name, dataStoreName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataStores_Delete
        [Fact]
        public void DataStores_Delete_DataSource()
        {
            try
            {
                string dataStoreName = TestConstants.DefaultDataSourceName;
                Client.DataStores.Delete(dataStoreName: dataStoreName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                //do a get and confirm
                var dataStoreFromGet = Client.DataStores.Get(dataStoreName: dataStoreName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.Null(dataStoreFromGet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Body.Code.Equals(TestConstants.ResourceNotFoundErrorCode) ||
                    ex.Body.Code.Equals(TestConstants.DmsUserErrorEntityNotFoundErrorCode));
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataStores_Delete
        [Fact]
        public void DataStores_Delete_DataSink()
        {
            try
            {
                string dataStoreName = TestConstants.DefaultDataSinkName;
                Client.DataStores.Delete(dataStoreName: dataStoreName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                //do a get and confirm
                var dataStoreFromGet = Client.DataStores.Get(dataStoreName: dataStoreName,
                    resourceGroupName: ResourceGroupName,
                    dataManagerName: DataManagerName);
                Assert.Null(dataStoreFromGet);
            }
            catch (CloudException ex)
            {
                Assert.True(ex.Body.Code.Equals(TestConstants.ResourceNotFoundErrorCode) ||
                    ex.Body.Code.Equals(TestConstants.DmsUserErrorEntityNotFoundErrorCode));
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
    }
}

