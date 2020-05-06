namespace HybridData.Tests.Tests
{
    using Microsoft.Azure.Management.HybridData;
    using Microsoft.Azure.Management.HybridData.Models;
    using Microsoft.Rest.Azure;
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Abstractions;

    public class DataManagersTest : HybridDataTestBase
    {
        public DataManagersTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        //DataManagers_List
        [Fact]
        public void DataManagers_List()
        {
            try
            {
                var dataManagersList = Client.DataManagers.List() as IPage<DataManager>;
                Assert.NotNull(dataManagersList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataManagers_ListByResourceGroup
        [Fact]
        public void DataManagers_ListByResourceGroup()
        {
            try
            {
                var dataManagersList = Client.DataManagers.ListByResourceGroup(ResourceGroupName) as IPage<DataManager>;
                Assert.NotNull(dataManagersList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataManagers_Get
        [Fact]
        public void DataManagers_Get()
        {
            try
            {
                var dataManager = Client.DataManagers.Get(ResourceGroupName, DataManagerName);
                Assert.NotNull(dataManager);
                Assert.Equal(dataManager.Name, DataManagerName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataManagers_Create
        [Fact]
        public void DataManagers_Create()
        {
            try
            {
                var dataManager = Client.DataManagers.Create(ResourceGroupName,
                    DataManagerName, new DataManager(location: TestConstants.DefaultLocation, name: DataManagerName));
                Assert.NotNull(dataManager);
                var getDataManagerResult = Client.DataManagers.Get(ResourceGroupName, DataManagerName);
                Assert.NotNull(getDataManagerResult);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataManagers_Delete
        [Fact]
        public void DataManagers_Delete()
        {
            try
            {
                Client.DataManagers.Delete(ResourceGroupName,
                    DataManagerName);
                var dataManager = Client.DataManagers.Get(ResourceGroupName, DataManagerName);
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

        //DataManagers_Update
        [Fact]
        public void DataManagers_Update()
        {
            try
            {
                var dataManager = Client.DataManagers.Get(ResourceGroupName, DataManagerName);
                var dataManagerUpdateParameter = new DataManagerUpdateParameter
                {
                    Tags = dataManager.Tags,
                    Sku = dataManager.Sku
                };
                dataManagerUpdateParameter.Tags.Add("UpdateDateTime", DateTime.Now.ToString());
                var dataManagerNew = Client.DataManagers.Update(ResourceGroupName, DataManagerName,
                    dataManagerUpdateParameter);
                Assert.NotNull(dataManagerNew);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
    }
}

