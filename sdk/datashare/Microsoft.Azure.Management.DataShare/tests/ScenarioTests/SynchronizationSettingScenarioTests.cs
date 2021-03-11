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

    public class SynchronizationSettingScenarioTests : ScenarioTestBase<SynchronizationSettingScenarioTests>
    {
        internal static async Task<SynchronizationSetting> CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName,
            string synchronizationSettingName,
            SynchronizationSetting expectedSynchronizationSetting)
        {
            AzureOperationResponse<SynchronizationSetting> createResponse =
                await client.SynchronizationSettings.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareName,
                    synchronizationSettingName,
                    expectedSynchronizationSetting);
            SynchronizationSettingScenarioTests.ValidateSynchronizationSetting(
                createResponse.Body,
                synchronizationSettingName);
            Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);

            return createResponse.Body;
        }

        private static void ValidateSynchronizationSetting(
            SynchronizationSetting actualSynchronizationSetting,
            string expectedSynchronizationSettingName)
        {
            Assert.Equal(expectedSynchronizationSettingName, actualSynchronizationSetting.Name);
        }

        internal static async Task Delete(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName,
            string synchronizationSettingName)
        {
            AzureOperationResponse<OperationResponse> deleteResponse =
                await client.SynchronizationSettings.DeleteWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareName,
                    synchronizationSettingName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.SynchronizationSettings.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                accountName,
                shareName,
                synchronizationSettingName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }

        internal static SynchronizationSetting GetSynchronizationSetting()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            return new ScheduledSynchronizationSetting(RecurrenceInterval.Day, tomorrow);
        }
    }
}
