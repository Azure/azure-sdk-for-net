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

    public class DataSetMappingScenarioTests : ScenarioTestBase<DataSetMappingScenarioTests>
    {
        internal static async Task CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareSubscriptionName,
            string dataSetMappingName,
            DataSetMapping expectedDataSetMapping)
        {
            var createResponse =
                await client.DataSetMappings.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareSubscriptionName,
                    dataSetMappingName,
                    expectedDataSetMapping);
            DataSetMappingScenarioTests.ValidateDataSetMapping(
                createResponse.Body,
                dataSetMappingName);
            Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);
        }

        private static void ValidateDataSetMapping(
            DataSetMapping actualDataSetMapping,
            string expectedDataSetMappingName)
        {
            Assert.Equal(expectedDataSetMappingName, actualDataSetMapping.Name);
        }

        internal static async Task Delete(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareSubscriptionName,
            string triggerName)
        {
            AzureOperationResponse<OperationResponse> deleteResponse =
                await client.Triggers.DeleteWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareSubscriptionName,
                    triggerName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.SynchronizationSettings.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                accountName,
                shareSubscriptionName,
                triggerName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }

        internal static DataSetMapping GetDataSetMapping(string containerName, string dataSetId, string filePath, string resourceGroup, string storageAccountName, string subscriptionId)
        {
            return new BlobDataSetMapping( containerName, dataSetId, filePath,  resourceGroup,  storageAccountName,  subscriptionId);
        }
    }
}
