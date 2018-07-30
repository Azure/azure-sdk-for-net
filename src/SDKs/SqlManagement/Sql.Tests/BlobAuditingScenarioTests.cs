using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    public class BlobAuditingScenarioTests
    {
        [Fact]
        public async void TestServerBlobAuditingPolicy()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient client = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);

                StorageAccountInformation storageAccountInformation = await CreateStorageAccountAsync(context, resourceGroup);

                ServerBlobAuditingPolicy serverPolicy = new ServerBlobAuditingPolicy
                {
                    State = BlobAuditingPolicyState.Enabled,
                    StorageEndpoint = storageAccountInformation.Endpoint,
                    StorageAccountAccessKey = storageAccountInformation.PrimaryKey,
                    RetentionDays = RetentionDays,
                    IsStorageSecondaryKeyInUse = IsStorageSecondaryKeyInUse
                };

                ExtendedServerBlobAuditingPolicy extendedServerPolicy = new ExtendedServerBlobAuditingPolicy
                {
                    State = BlobAuditingPolicyState.Enabled,
                    StorageEndpoint = storageAccountInformation.Endpoint,
                    StorageAccountAccessKey = storageAccountInformation.PrimaryKey,
                    RetentionDays = RetentionDays,
                    IsStorageSecondaryKeyInUse = IsStorageSecondaryKeyInUse,
                    PredicateExpression = PredicateExpression
                };

                ServerBlobAuditingPolicy serverResultPolicy = await client.ServerBlobAuditingPolicies.CreateOrUpdateAsync(resourceGroup.Name, server.Name, serverPolicy);
                VerifyServerBlobAuditingPolicy(serverPolicy, serverResultPolicy);
                serverResultPolicy = await client.ServerBlobAuditingPolicies.GetAsync(resourceGroup.Name, server.Name);
                VerifyServerBlobAuditingPolicy(serverPolicy, serverResultPolicy);
                
                ExtendedServerBlobAuditingPolicy extendedServerResultPolicy = await client.ExtendedServerBlobAuditingPolicies.CreateOrUpdateAsync(resourceGroup.Name, server.Name, extendedServerPolicy);
                VerifyExtendedServerBlobAuditingPolicy(extendedServerPolicy, extendedServerResultPolicy);
                extendedServerResultPolicy = await client.ExtendedServerBlobAuditingPolicies.GetAsync(resourceGroup.Name, server.Name);
                VerifyExtendedServerBlobAuditingPolicy(extendedServerPolicy, extendedServerResultPolicy);

                await client.Servers.DeleteAsync(resourceGroup.Name, server.Name);
                await DeleteStorageAccountAsync(context, resourceGroup.Name, storageAccountInformation.Name);
            }
        }

        [Fact]
        public async void TestDatabaseBlobAuditingPolicy()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient client = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);

                Database database = client.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(DatabaseNamePrefix), new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(database);

                StorageAccountInformation storageAccountInformation = await CreateStorageAccountAsync(context, resourceGroup);

                DatabaseBlobAuditingPolicy databasePolicy = new DatabaseBlobAuditingPolicy
                {
                    State = BlobAuditingPolicyState.Enabled,
                    StorageEndpoint = storageAccountInformation.Endpoint,
                    StorageAccountAccessKey = storageAccountInformation.PrimaryKey,
                    RetentionDays = RetentionDays,
                    IsStorageSecondaryKeyInUse = IsStorageSecondaryKeyInUse
                };

                ExtendedDatabaseBlobAuditingPolicy extendedDatabasePolicy = new ExtendedDatabaseBlobAuditingPolicy
                {
                    State = BlobAuditingPolicyState.Enabled,
                    StorageEndpoint = storageAccountInformation.Endpoint,
                    StorageAccountAccessKey = storageAccountInformation.PrimaryKey,
                    RetentionDays = RetentionDays,
                    IsStorageSecondaryKeyInUse = IsStorageSecondaryKeyInUse,
                    PredicateExpression = PredicateExpression
                };

                DatabaseBlobAuditingPolicy databaseResultPolicy = await client.DatabaseBlobAuditingPolicies.CreateOrUpdateAsync(resourceGroup.Name, server.Name, database.Name, databasePolicy);
                VerifyDatabaseBlobAuditingPolicy(databasePolicy, databaseResultPolicy);
                databaseResultPolicy = await client.DatabaseBlobAuditingPolicies.GetAsync(resourceGroup.Name, server.Name, database.Name);
                VerifyDatabaseBlobAuditingPolicy(databasePolicy, databaseResultPolicy);

                ExtendedDatabaseBlobAuditingPolicy extendedDatabaseResultPolicy = await client.ExtendedDatabaseBlobAuditingPolicies.CreateOrUpdateAsync(resourceGroup.Name, server.Name, database.Name, extendedDatabasePolicy);
                VerifyExtendedDatabaseBlobAuditingPolicy(extendedDatabasePolicy, extendedDatabaseResultPolicy);
                extendedDatabaseResultPolicy = await client.ExtendedDatabaseBlobAuditingPolicies.GetAsync(resourceGroup.Name, server.Name, database.Name);
                VerifyExtendedDatabaseBlobAuditingPolicy(extendedDatabasePolicy, extendedDatabaseResultPolicy);

                await client.Databases.DeleteAsync(resourceGroup.Name, server.Name, database.Name);
                await client.Servers.DeleteAsync(resourceGroup.Name, server.Name);
                await DeleteStorageAccountAsync(context, resourceGroup.Name, storageAccountInformation.Name);
            }
        }

        private void VerifyExtendedDatabaseBlobAuditingPolicy(ExtendedDatabaseBlobAuditingPolicy extendedDatabasePolicy, ExtendedDatabaseBlobAuditingPolicy extendedDatabaseResultPolicy)
        {
            Assert.Equal(extendedDatabaseResultPolicy.State, extendedDatabasePolicy.State);
            Assert.Equal(extendedDatabaseResultPolicy.StorageEndpoint, extendedDatabasePolicy.StorageEndpoint);
            Assert.Null(extendedDatabaseResultPolicy.StorageAccountAccessKey);
            Assert.Equal(extendedDatabaseResultPolicy.RetentionDays, extendedDatabasePolicy.RetentionDays);
            Assert.Equal(extendedDatabaseResultPolicy.IsStorageSecondaryKeyInUse, extendedDatabasePolicy.IsStorageSecondaryKeyInUse);
            Assert.Equal(extendedDatabaseResultPolicy.PredicateExpression, extendedDatabasePolicy.PredicateExpression);
        }

        private static void VerifyExtendedServerBlobAuditingPolicy(ExtendedServerBlobAuditingPolicy extendedServerPolicy, ExtendedServerBlobAuditingPolicy extendedServerResultPolicy)
        {
            Assert.Equal(extendedServerResultPolicy.State, extendedServerPolicy.State);
            Assert.Equal(extendedServerResultPolicy.StorageEndpoint, extendedServerPolicy.StorageEndpoint);
            Assert.Null(extendedServerResultPolicy.StorageAccountAccessKey);
            Assert.Equal(extendedServerResultPolicy.RetentionDays, extendedServerPolicy.RetentionDays);
            Assert.Equal(extendedServerResultPolicy.IsStorageSecondaryKeyInUse, extendedServerPolicy.IsStorageSecondaryKeyInUse);
            Assert.Equal(extendedServerResultPolicy.PredicateExpression, extendedServerPolicy.PredicateExpression);
        }

        private static void VerifyServerBlobAuditingPolicy(ServerBlobAuditingPolicy serverPolicy, ServerBlobAuditingPolicy serverResultPolicy)
        {
            Assert.Equal(serverResultPolicy.State, serverPolicy.State);
            Assert.Equal(serverResultPolicy.StorageEndpoint, serverPolicy.StorageEndpoint);
            Assert.Null(serverResultPolicy.StorageAccountAccessKey);
            Assert.Equal(serverResultPolicy.RetentionDays, serverPolicy.RetentionDays);
            Assert.Equal(serverResultPolicy.IsStorageSecondaryKeyInUse, serverPolicy.IsStorageSecondaryKeyInUse);
        }

        private static void VerifyDatabaseBlobAuditingPolicy(DatabaseBlobAuditingPolicy databasePolicy, DatabaseBlobAuditingPolicy databaseResultPolicy)
        {
            Assert.Equal(databaseResultPolicy.State, databasePolicy.State);
            Assert.Equal(databaseResultPolicy.StorageEndpoint, databasePolicy.StorageEndpoint);
            Assert.Equal(databaseResultPolicy.StorageAccountAccessKey, string.Empty);
            Assert.Equal(databaseResultPolicy.RetentionDays, databasePolicy.RetentionDays);
            Assert.Equal(databaseResultPolicy.IsStorageSecondaryKeyInUse, databasePolicy.IsStorageSecondaryKeyInUse);
        }

        private async Task<StorageAccountInformation> CreateStorageAccountAsync(SqlManagementTestContext context, ResourceGroup resourceGroup)
        {
            string accountName = SqlManagementTestUtilities.GenerateName(prefix: StorageNamePrefix);
            StorageManagementClient client = context.GetClient<StorageManagementClient>();
            StorageAccount storageAccount = await client.StorageAccounts.CreateAsync(
                resourceGroup.Name,
                accountName: accountName,
                parameters: new StorageAccountCreateParameters(
                    new Microsoft.Azure.Management.Storage.Models.Sku(SkuName.StandardLRS, SkuTier.Standard),
                    Kind.BlobStorage,
                    resourceGroup.Location,
                    accessTier: AccessTier.Cool));

            StorageAccountListKeysResult keys =
                client.StorageAccounts.ListKeys(resourceGroup.Name, storageAccount.Name);

            return new StorageAccountInformation
            {
                Name = accountName,
                Endpoint = storageAccount.PrimaryEndpoints.Blob,
                PrimaryKey = keys.Keys.First().Value
            };
        }

        private async Task DeleteStorageAccountAsync(SqlManagementTestContext context, string resourceGroupName, string accountName)
        {
            StorageManagementClient storageClient = context.GetClient<StorageManagementClient>();
            await storageClient.StorageAccounts.DeleteAsync(resourceGroupName, accountName);
        }

        private struct StorageAccountInformation
        {
            public string Name;
            public string Endpoint;
            public string PrimaryKey;
        }

        private const bool IsStorageSecondaryKeyInUse = false;
        private const int RetentionDays = 1;
        private const string PredicateExpression = "statement = 'select 1'";
        private const string DatabaseNamePrefix = "sqldatabaseblobauditingcrudtest-";
        private const string StorageNamePrefix = "sqlblobauditingtest";
    }
}
