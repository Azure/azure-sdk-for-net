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
            // Remove this flag once API is available in Prod
            bool isProd = true;

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient client = context.GetClient<SqlManagementClient>();
                StorageAccountInformation storageAccountInformation;
                string resourceGroupName;
                string serverName;

                if (isProd)
                {
                    ResourceGroup resourceGroup = context.CreateResourceGroup();
                    Server server = context.CreateServer(resourceGroup);
                    storageAccountInformation = await CreateStorageAccountAsync(context, resourceGroup);

                    resourceGroupName = resourceGroup.Name;
                    serverName = server.Name;
                }
                else
                {
                    resourceGroupName = "Default-SQL-SoutheastAsia";
                    serverName = "lubaseaserver";

                    storageAccountInformation = new StorageAccountInformation
                    {
                        Name = "olsternbstorageaccount",
                        Endpoint = "https://olsternbstorageaccount.blob.core.windows.net/",
                        PrimaryKey = "RDyxx3ORhww2iA6todWBYfNQor15ScEC4mF1VDrbwHz0q/smzD1GVMEBpODRz0yvaV1T8wi2CfG1cQYyEiPx3w=="
                    };
                }

                ServerDevOpsAuditingSettings devOpsSettings = new ServerDevOpsAuditingSettings
                {
                    State = BlobAuditingPolicyState.Enabled,
                    StorageEndpoint = storageAccountInformation.Endpoint,
                    StorageAccountAccessKey = storageAccountInformation.PrimaryKey,
                    IsAzureMonitorTargetEnabled = true
                };

                ServerDevOpsAuditingSettings resultDevOpsSettings = await client.ServerDevOpsAuditSettings.CreateOrUpdateAsync(resourceGroupName, serverName, PolicyName, devOpsSettings);
                VerifyPolicy(devOpsSettings, resultDevOpsSettings);

                resultDevOpsSettings = await client.ServerDevOpsAuditSettings.GetAsync(resourceGroupName, serverName, PolicyName);
                VerifyPolicy(devOpsSettings, resultDevOpsSettings);

                IPage<ServerDevOpsAuditingSettings> resultItems = await client.ServerDevOpsAuditSettings.ListByServerAsync(resourceGroupName, serverName);

                foreach (ServerDevOpsAuditingSettings resultItem in resultItems)
                {
                    VerifyPolicy(devOpsSettings, resultItem);
                }

                Assert.Null(resultItems.NextPageLink);

                if (isProd)
                {
                    await client.Servers.DeleteAsync(resourceGroupName, serverName);
                    await DeleteStorageAccountAsync(context, resourceGroupName, storageAccountInformation.Name);
                }
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