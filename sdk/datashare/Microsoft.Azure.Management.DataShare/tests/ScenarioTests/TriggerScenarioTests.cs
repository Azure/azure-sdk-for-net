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

    public class TriggerScenarioTests : ScenarioTestBase<TriggerScenarioTests>
    {
        internal static async Task CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareSubscriptionName,
            string triggerName,
            Trigger expectedTrigger)
        {
            AzureOperationResponse<Trigger> createResponse =
                await client.Triggers.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareSubscriptionName,
                    triggerName,
                    expectedTrigger);
            TriggerScenarioTests.ValidateTrigger(
                createResponse.Body,
                triggerName);
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);
        }

        private static void ValidateTrigger(
            Trigger actualTrigger,
            string expectedTriggerName)
        {
            Assert.Equal(expectedTriggerName, actualTrigger.Name);
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

        internal static Trigger GetTrigger(string recurrenceInterval, DateTime synchronizationTime)
        {
            return new ScheduledTrigger(recurrenceInterval, synchronizationTime);
        }
    }
}
