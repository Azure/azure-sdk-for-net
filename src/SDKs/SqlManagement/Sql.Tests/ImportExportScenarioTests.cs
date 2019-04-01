// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    public class ImportExportScenarioTests
    {
        [Fact]
        public void TestImportExistingDatabase()
        {
            TestImportExport(true, "TestImportExistingDatabase");
        }

        [Fact]
        public void TestImportNewDatabase()
        {
            TestImportExport(false, "TestImportNewDatabase");
        }

        public void TestImportExport(bool preexistingDatabase, string testName)
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this, testName))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Begin creating storage account and container
                Task<StorageContainerInfo> storageContainerTask = CreateStorageContainer(context, resourceGroup);

                string login = SqlManagementTestUtilities.DefaultLogin;
                string password = SqlManagementTestUtilities.DefaultPassword;
                string dbName = SqlManagementTestUtilities.GenerateName();
                string dbName2 = SqlManagementTestUtilities.GenerateName();
                string storageAccountName = SqlManagementTestUtilities.GenerateName("sqlcrudstorage");
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // set server firewall rule
                sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(), new FirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "255.255.255.255"
                });

                // Create 1 or 2 databases
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location
                });

                if (preexistingDatabase)
                {
                    sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName2, new Database()
                    {
                        Location = server.Location
                    });

                    // Verify existence of new database
                    Assert.NotNull(sqlClient.Databases.Get(resourceGroup.Name, server.Name, dbName2));
                }

                // Get Storage container credentials
                StorageContainerInfo storageContainerInfo = storageContainerTask.Result;
                string exportBacpacLink = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}/{1}.bacpac",
                    storageContainerInfo.StorageContainerUri, dbName);

                // Export database to bacpac
                sqlClient.Databases.Export(resourceGroup.Name, server.Name, dbName, new ExportRequest()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    AuthenticationType = AuthenticationType.SQL,
                    StorageKey = storageContainerInfo.StorageAccountKey,
                    StorageKeyType = StorageKeyType.StorageAccessKey,
                    StorageUri = exportBacpacLink
                });

                // Import bacpac to new/existing database
                if (preexistingDatabase)
                {
                    // Import bacpac to existing database
                    sqlClient.Databases.CreateImportOperation(resourceGroup.Name, server.Name, dbName2, new ImportExtensionRequest()
                    {
                        AdministratorLogin = login,
                        AdministratorLoginPassword = password,
                        AuthenticationType = AuthenticationType.SQL,
                        StorageKey = storageContainerInfo.StorageAccountKey,
                        StorageKeyType = StorageKeyType.StorageAccessKey,
                        StorageUri = exportBacpacLink
                    });
                }
                else
                {
                    sqlClient.Databases.Import(resourceGroup.Name, server.Name, new ImportRequest()
                    {
                        AdministratorLogin = login,
                        AdministratorLoginPassword = password,
                        AuthenticationType = AuthenticationType.SQL,
                        StorageKey = storageContainerInfo.StorageAccountKey,
                        StorageKeyType = StorageKeyType.StorageAccessKey,
                        StorageUri = exportBacpacLink,
                        DatabaseName = dbName2,
                        Edition = SqlTestConstants.DefaultDatabaseEdition,
                        ServiceObjectiveName = ServiceObjectiveName.Basic,
                        MaxSizeBytes = (2 * 1024L * 1024L * 1024L).ToString(),
                    });
                }
            }
        }

        private struct StorageContainerInfo
        {
            public string StorageAccountKey;
            public Uri StorageContainerUri;
        }

        private async Task<StorageContainerInfo> CreateStorageContainer(SqlManagementTestContext context, ResourceGroup resourceGroup)
        {
            StorageManagementClient storageClient = context.GetClient<StorageManagementClient>();
            StorageAccount storageAccount = await storageClient.StorageAccounts.CreateAsync(
                resourceGroup.Name,
                accountName: SqlManagementTestUtilities.GenerateName(prefix: "sqlcrudtest"), // '-' is not allowed
                parameters: new StorageAccountCreateParameters(
                    new Microsoft.Azure.Management.Storage.Models.Sku(SkuName.StandardLRS, SkuTier.Standard),
                    Kind.BlobStorage,
                    resourceGroup.Location,
                    accessTier: AccessTier.Cool));

            StorageAccountListKeysResult keys =
                storageClient.StorageAccounts.ListKeys(resourceGroup.Name, storageAccount.Name);
            string key = keys.Keys.First().Value;

            string containerName = "container";

            // Create container
            // Since this is a data-plane client and not an ARM client it's harder to inject
            // HttpMockServer into it to record/playback, but that's fine because we don't need
            // any of the response data to continue with the test.
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                CloudStorageAccount storageAccountClient = new CloudStorageAccount(
                    new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                        storageAccount.Name,
                        key),
                    useHttps: true);
                CloudBlobClient blobClient = storageAccountClient.CreateCloudBlobClient();
                CloudBlobContainer containerReference = blobClient.GetContainerReference(containerName);
                await containerReference.CreateIfNotExistsAsync();
            }

            return new StorageContainerInfo
            {
                StorageAccountKey = key,
                StorageContainerUri = new Uri(storageAccount.PrimaryEndpoints.Blob + containerName)
            };
        }
    }
}