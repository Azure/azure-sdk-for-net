namespace Purview.Tests.ScenarioTests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Purview;
    using Microsoft.Azure.Management.Purview.Models;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class AccountScenarioTests : ScenarioTestBase<AccountScenarioTests>
    {
        public Account ExpectedAccount = new Account(
            identity: new Identity(type: "SystemAssigned"),
            location: ScenarioTestBase<AccountScenarioTests>.AccountLocation,
            sku: new AccountSku(4, "Standard"));

        [Fact]
        public async Task AccountCrud()
        {
            async Task Action(PurviewManagementClient client)
            {
                await AccountScenarioTests.CreateAsync(client, this.ResourceGroupName, this.AccountName, this.ExpectedAccount);
            }

            async Task FinallyAction(PurviewManagementClient client)
            {
                await AccountScenarioTests.Delete(client, this.ResourceGroupName, this.AccountName);
            }

            await this.RunTest(Action, FinallyAction);
        }

        internal static async Task CreateAsync(
            PurviewManagementClient client,
            string resourceGroupName,
            string accountName,
            Account expectedAccount)
        {
            AzureOperationResponse<Account> createResponse =
                await client.Accounts.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, accountName, expectedAccount);
            AccountScenarioTests.ValidateAccount(createResponse.Body, accountName);
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);
        }

        private static void ValidateAccount(Account actualAccount, string expectedAccountName)
        {
            Assert.Equal(expectedAccountName, actualAccount.Name);
            Assert.Equal(ScenarioTestBase<AccountScenarioTests>.AccountLocation, actualAccount.Location);
            Assert.Equal("Succeeded", actualAccount.ProvisioningState);
        }

        internal static async Task Delete(PurviewManagementClient client, string resourceGroupName, string accountName)
        {
            AzureOperationResponse deleteResponse = await client.Accounts.DeleteWithHttpMessagesAsync(resourceGroupName, accountName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.Accounts.DeleteWithHttpMessagesAsync(resourceGroupName, accountName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }
    }
}
