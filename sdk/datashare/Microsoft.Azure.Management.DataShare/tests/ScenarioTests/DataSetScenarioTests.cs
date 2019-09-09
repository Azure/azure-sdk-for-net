namespace DataShare.Tests.ScenarioTests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class DataSetScenarioTests : ScenarioTestBase<SynchronizationSettingScenarioTests>
    {
        internal static async Task<DataSet> CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName,
            string dataSetName,
            DataSet expectedDataSet)
        {
            AzureOperationResponse<DataSet> createResponse =
                await client.DataSets.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareName,
                    dataSetName,
                    expectedDataSet);
            DataSetScenarioTests.ValidateDataSet(
                createResponse.Body,
                dataSetName);
            Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);

            return createResponse.Body;
        }

        private static void ValidateDataSet(
            DataSet actualDataSet,
            string expectedDataSetName)
        {
            Assert.Equal(expectedDataSetName, actualDataSet.Name);
        }

        internal static async Task Delete(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName,
            string dataSetName)
        {
            var deleteResponse =
                await client.DataSets.DeleteWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareName,
                    dataSetName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.DataSets.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                accountName,
                shareName,
                dataSetName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }

        internal static DataSet GetDataSet()
        {
            return new BlobDataSet();
        }
    }
}
