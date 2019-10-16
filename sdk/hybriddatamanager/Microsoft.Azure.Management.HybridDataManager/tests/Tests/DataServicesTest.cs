namespace HybridData.Tests.Tests
{
    using Microsoft.Azure.Management.HybridData;
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class DataServicesTest : HybridDataTestBase
    {
        public DataServicesTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        //DataServices_ListByDataManager
        [Fact]
        public void DataServices_ListByDataManager()
        {
            try
            {
                var dataServiceList = Client.DataServices.ListByDataManager(ResourceGroupName, DataManagerName);
                Assert.NotNull(dataServiceList);
                Assert.NotEmpty(dataServiceList);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
        //DataServices_Get
        [Fact]
        public void DataServices_Get()
        {
            try
            {
                var dataServiceList = Client.DataServices.ListByDataManager(ResourceGroupName, DataManagerName);
                Assert.NotNull(dataServiceList);
                Assert.NotEmpty(dataServiceList);
                foreach (var dataService in dataServiceList)
                {
                    var returnedDataService = Client.DataServices.Get(dataService.Name, ResourceGroupName,
                        DataManagerName);
                    Assert.NotNull(returnedDataService);
                }
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
    }
}

