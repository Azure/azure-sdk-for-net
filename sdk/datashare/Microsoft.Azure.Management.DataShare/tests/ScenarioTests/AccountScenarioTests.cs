namespace DataShare.Tests.ScenarioTests
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class AccountScenarioTests : ScenarioTestBase<AccountScenarioTests>
    {
        private const string shareName = "sdktestingshare";
        public Account ExpectedAccount = new Account(identity, "DataShareId", shareName, default(SystemData), "Microsoft.DataShare", ScenarioTestBase<DataShareE2EScenarioTests>.AccountLocation);

        [Fact]
        public async Task AccountCrud()
        {
            async Task Action(DataShareManagementClient client)
            {
                 await AccountScenarioTests.CreateAsync(client, this.ResourceGroupName, this.AccountName, this.ExpectedAccount);
            }

            async Task FinallyAction(DataShareManagementClient client)
            {
                await AccountScenarioTests.Delete(client, this.ResourceGroupName, this.AccountName);
            }

            await this.RunTest(Action, FinallyAction);
        }

        internal static async Task CreateAsync(
            DataShareManagementClient client,
            string resourceGroupName,
            string accountName,
            Account expectedAccount)
        {
            AzureOperationResponse<Account> createResponse =
                await client.Accounts.CreateWithHttpMessagesAsync(resourceGroupName, accountName, expectedAccount);
            AccountScenarioTests.ValidateAccount(createResponse.Body, accountName);
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);
        }

        private static void ValidateAccount(Account actualAccount, string expectedAccountName)
        {
            Assert.Equal(expectedAccountName, actualAccount.Name);
            Assert.Equal(ScenarioTestBase<AccountScenarioTests>.AccountLocation, actualAccount.Location);
            Assert.Equal("Succeeded", actualAccount.ProvisioningState);
        }

        internal static async Task Delete(DataShareManagementClient client, string resourceGroupName, string accountName)
        {
            AzureOperationResponse<OperationResponse> deleteResponse = await client.Accounts.DeleteWithHttpMessagesAsync(resourceGroupName, accountName);
            Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);

            deleteResponse = await client.Accounts.DeleteWithHttpMessagesAsync(resourceGroupName, accountName);
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
        }
    }
}
