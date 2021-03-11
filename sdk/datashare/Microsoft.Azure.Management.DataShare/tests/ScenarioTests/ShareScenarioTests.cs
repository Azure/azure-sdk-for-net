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

    public class ShareScenarioTests : ScenarioTestBase<ShareScenarioTests>
    {
        internal static async Task CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName,
            Share expectedShare)
        {
            AzureOperationResponse<Share> createResponse =
                await client.Shares.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareName,
                    expectedShare);
            ShareScenarioTests.ValidateShare(createResponse.Body, shareName);
            Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);
        }

        private static void ValidateShare(Share actualShare, string expectedShareName)
        {
            Assert.Equal(expectedShareName, actualShare.Name);
            Assert.Equal("Succeeded", actualShare.ProvisioningState);
        }

        internal static async Task Delete(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName)
        {
            AzureOperationResponse<OperationResponse> deleteResponse =
                await client.Shares.DeleteWithHttpMessagesAsync(resourceGroupName, accountName, shareName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.Shares.DeleteWithHttpMessagesAsync(resourceGroupName, accountName, shareName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }

        internal static Share GetShare()
        {
            return new Share( shareKind: "CopyBased");
        }
    }
}
