// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    public class ServerDevOpsAuditingScenarioTests
    {
        [Fact]
        public async void TestServerDevOpsAuditingSettings()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient client = context.GetClient<SqlManagementClient>();

                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                StorageAccountInformation storageAccountInformation = await CreateStorageAccountAsync(context, resourceGroup);

                ServerDevOpsAuditingSettings devOpsSettings = new ServerDevOpsAuditingSettings
                {
                    State = BlobAuditingPolicyState.Enabled,
                    StorageEndpoint = storageAccountInformation.Endpoint,
                    StorageAccountAccessKey = storageAccountInformation.PrimaryKey,
                    IsAzureMonitorTargetEnabled = true
                };

                ServerDevOpsAuditingSettings resultDevOpsSettings = await client.ServerDevOpsAuditSettings.CreateOrUpdateAsync(resourceGroup.Name, server.Name, PolicyName, devOpsSettings);
                VerifyPolicy(devOpsSettings, resultDevOpsSettings);

                resultDevOpsSettings = await client.ServerDevOpsAuditSettings.GetAsync(resourceGroup.Name, server.Name, PolicyName);
                VerifyPolicy(devOpsSettings, resultDevOpsSettings);

                IPage<ServerDevOpsAuditingSettings> resultItems = await client.ServerDevOpsAuditSettings.ListByServerAsync(resourceGroup.Name, server.Name);

                foreach (ServerDevOpsAuditingSettings resultItem in resultItems)
                {
                    VerifyPolicy(devOpsSettings, resultItem);
                }

                Assert.Null(resultItems.NextPageLink);

                await client.Servers.DeleteAsync(resourceGroup.Name, server.Name);
                await DeleteStorageAccountAsync(context, resourceGroup.Name, storageAccountInformation.Name);
            }
        }

        private static void VerifyPolicy(ServerDevOpsAuditingSettings devOpsSettings, ServerDevOpsAuditingSettings resultDevOpsSettings)
        {
            Assert.Equal(resultDevOpsSettings.State, devOpsSettings.State);
            Assert.Equal(resultDevOpsSettings.StorageEndpoint, devOpsSettings.StorageEndpoint);
            Assert.Null(resultDevOpsSettings.StorageAccountAccessKey);
            Assert.Equal(resultDevOpsSettings.IsAzureMonitorTargetEnabled, devOpsSettings.IsAzureMonitorTargetEnabled);
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

        private const string PolicyName = "default";
        private const string StorageNamePrefix = "sqldevopsaudittest";
    }
}