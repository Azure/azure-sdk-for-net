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

    public class ShareSubscriptionScenarioTests : ScenarioTestBase<ShareSubscriptionScenarioTests>
    {
        internal static void Synchronize(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareSubscriptionName)
        {
            client.ShareSubscriptions.SynchronizeMethod(
                    resourceGroupName,
                    accountName,
                    shareSubscriptionName,
                    new Synchronize(synchronizationMode: "FullSync"));
        }

        internal static async Task CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareSubscriptionName,
            ShareSubscription expectedShareSubscription)
        {
            AzureOperationResponse<ShareSubscription> createResponse =
                await client.ShareSubscriptions.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareSubscriptionName,
                    expectedShareSubscription);
            ShareSubscriptionScenarioTests.ValidateShare(createResponse.Body, shareSubscriptionName);
            Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);
        }

        private static void ValidateShare(
            ShareSubscription actualShareSubscription,
            string expectedShareSubscriptionName)
        {
            Assert.Equal(expectedShareSubscriptionName, actualShareSubscription.Name);
        }

        internal static async Task Delete(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareSubscriptionName)
        {
            AzureOperationResponse<OperationResponse> deleteResponse =
                await client.ShareSubscriptions.DeleteWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareSubscriptionName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.ShareSubscriptions.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                accountName,
                shareSubscriptionName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }

        internal static ShareSubscription GetShareSubscription(string invitationId, string sourceShareLocation)
        {
            return new ShareSubscription(invitationId, sourceShareLocation);
        }
    }
}
