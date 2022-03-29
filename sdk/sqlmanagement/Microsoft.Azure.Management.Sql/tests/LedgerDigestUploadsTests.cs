// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    public class LedgerDigestUploadTests
    {
        [Fact]
        public void TestUpdateLedgerDigestUploadConfiguration()
        {
            string testPrefix = "ledger-digest-upload-test-";
            string aclEndpoint = "https://test.confidential-ledger.azure.com";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);

                // Create database
                Database database = SqlManagementTestUtilities.CreateDatabasesAsync(
                    sqlClient, resourceGroup.Name, server, testPrefix, 1).Result[0];

                LedgerDigestUploads defaultResponse = sqlClient.LedgerDigestUploads.Get(resourceGroup.Name, server.Name, database.Name);

                // Verify the initial GET request contains the default settings (disabled)
                Assert.Equal(LedgerDigestUploadsState.Disabled, defaultResponse.State);

                // Create new configuration with ACL endpoint
                LedgerDigestUploads aclUploadConfiguration = new LedgerDigestUploads
                {
                    DigestStorageEndpoint = aclEndpoint,
                };

                // Set ledger digest upload configuration for database
                sqlClient.LedgerDigestUploads.CreateOrUpdate(resourceGroup.Name, server.Name, database.Name, aclUploadConfiguration);

                // Get the updated ledger digest upload properties
                LedgerDigestUploads aclResponse = sqlClient.LedgerDigestUploads.Get(resourceGroup.Name, server.Name, database.Name);

                // Verify that the GET request contains the updated settings
                Assert.Equal(LedgerDigestUploadsState.Enabled, aclResponse.State);
                Assert.Equal(aclEndpoint, aclResponse.DigestStorageEndpoint);

                // Disable digest uploading on database
                sqlClient.LedgerDigestUploads.Disable(resourceGroup.Name, server.Name, database.Name);

                // Get the updated ledger digest upload properties
                LedgerDigestUploads disabledResponse = sqlClient.LedgerDigestUploads.Get(resourceGroup.Name, server.Name, database.Name);

                // Verify that the GET request contains the disabled settings
                Assert.Equal(LedgerDigestUploadsState.Disabled, disabledResponse.State);
            }
        }

        [Fact]
        public void TestCreateLedgerDatabase()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);

                // Create database with IsLedgerOn 
                string databaseName = SqlManagementTestUtilities.GenerateName();
                Database ledgerDb = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name,
                    server.Name,
                    databaseName,
                    new Database()
                    {
                        Location = server.Location,
                        IsLedgerOn = true
                    });

                // Get the created database and validate IsLedgerOn parameter is set
                Database databaseResponse = sqlClient.Databases.Get(resourceGroup.Name, server.Name, databaseName);
                Assert.True(databaseResponse.IsLedgerOn);
            }
        }
    }
}