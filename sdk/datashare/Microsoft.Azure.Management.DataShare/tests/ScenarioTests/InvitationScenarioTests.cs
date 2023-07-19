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

    public class InvitationScenarioTests : ScenarioTestBase<InvitationScenarioTests>
    {
        internal static async Task<Invitation> CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName,
            string invitationName,
            Invitation expectedInvitation)
        {
            AzureOperationResponse<Invitation> createResponse =
                await client.Invitations.CreateWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareName,
                    invitationName,
                    expectedInvitation);
            InvitationScenarioTests.ValidateInvitation(createResponse.Body, invitationName);
            Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);

            return createResponse.Body;
        }

        private static void ValidateInvitation(Invitation actualInvitation, string expectedInvitationName)
        {
            Assert.Equal(expectedInvitationName, actualInvitation.Name);
        }

        internal static async Task Delete(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            string shareName,
            string invitationName)
        {
            AzureOperationResponse deleteResponse =
                await client.Invitations.DeleteWithHttpMessagesAsync(
                    resourceGroupName,
                    accountName,
                    shareName,
                    invitationName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.Invitations.DeleteWithHttpMessagesAsync(
                resourceGroupName,
                accountName,
                shareName,
                invitationName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }

        internal static Invitation GetExpectedInvitation()
        {
            string servPrincipal = "9c1d7b62-8746-48cf-b7d8-f1bda6d9efd0";

            return new Invitation(targetActiveDirectoryId: tenantId, targetObjectId: servPrincipal);
        }
    }
}
