using Microsoft.Azure.Management.HybridData.Models;
using Microsoft.Azure.Management.HybridData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace HybridData.Tests.Tests
{
    public class DataStoreTypesTest : HybridDataTestBase
    {
        #region Constructor
        public DataStoreTypesTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        #endregion

        #region Test Methods
        //DataStoreTypes_ListByDataManager
        [Fact]
        public void DataStoreTypes_ListByDataManager()
        {
            try
            {
                var dataStoreTypeList = Client.DataStoreTypes.ListByDataManager(ResourceGroupName, DataManagerName);
                Assert.NotNull(dataStoreTypeList);
                Assert.NotEmpty(dataStoreTypeList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        //DataStoreTypes_Get
        [Fact]
        public void DataStoreTypes_Get()
        {
            try
            {
                var dataStoreTypeList = Client.DataStoreTypes.ListByDataManager(ResourceGroupName, DataManagerName);
                Assert.NotNull(dataStoreTypeList);
                Assert.NotEmpty(dataStoreTypeList);
                foreach (var dataStoreType in dataStoreTypeList)
                {
                    var returnedDataStoreType = Client.DataStoreTypes.Get(dataStoreType.Name, ResourceGroupName, DataManagerName);
                    Assert.NotNull(returnedDataStoreType);
                }
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion
    }
}

