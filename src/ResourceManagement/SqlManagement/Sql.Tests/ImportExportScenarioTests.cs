// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Sql.Tests
{
    public class ImportExportScenarioTests
    {
        [Fact]
        public void TestImportExistingDatabaseGetOperation()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
            string dbName2 = SqlManagementTestUtilities.GenerateName(testPrefix);
            string storageAccountName = SqlManagementTestUtilities.GenerateName("sqlcrudstorage");
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestImportExistingDatabaseGetOperation", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                string serverNameV12 = SqlManagementTestUtilities.GenerateName(testPrefix);
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create server and set firewall rule
                var server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverNameV12, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = SqlManagementTestUtilities.DefaultLocation,
                });
                SqlManagementTestUtilities.ValidateServer(server, serverNameV12, login, version12, tags, SqlManagementTestUtilities.DefaultLocation);

                sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(testPrefix), new ServerFirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "255.255.255.255"
                });

                // Create 2 databases
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location
                });
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName2, new Database()
                {
                    Location = server.Location
                });

                // Get Storage container credentials
                string testMode = HttpMockServer.GetCurrentMode().ToString();
                string storageKey = "StorageKey";
                string storageKeyType = "StorageAccessKey";
                string exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "http://test.blob.core.windows.net/databases/{0}.bacpac", dbName);

                if (testMode == "Record")
                {
                    string importBacpacContainer = Environment.GetEnvironmentVariable("TEST_IMPORT_CONTAINER");
                    storageKey = Environment.GetEnvironmentVariable("TEST_STORAGE_KEY");
                    exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "{0}/{1}.bacpac", importBacpacContainer, dbName);

                    Assert.False(string.IsNullOrWhiteSpace(storageKey), "Environment variable TEST_STORAGE_KEY has not been set.  Set it to storage account key.");
                    Assert.False(string.IsNullOrWhiteSpace(importBacpacContainer), "Environment variable TEST_IMPORT_CONTAINER has not been set.  Set it to a valid storage container URL.");
                }

                // Export database to bacpac
                sqlClient.Databases.Export(resourceGroup.Name, server.Name, dbName, new ExportRequestParameters()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    AuthenticationType = AuthenticationType.SQL,
                    StorageKey = storageKey,
                    StorageKeyType = StorageKeyType.StorageAccessKey,
                    StorageUri = exportBacpacLink
                });

                // Import bacpac to existing database
                ImportExportOperationResponse importResponse = sqlClient.Databases.Import(resourceGroup.Name, server.Name, dbName2, new ImportExtensionRequestParameters()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    AuthenticationType = AuthenticationType.SQL,
                    StorageKey = storageKey,
                    StorageKeyType = StorageKeyType.StorageAccessKey,
                    StorageUri = exportBacpacLink
                });

                // Get Database import/export operation
                ImportExportOperationResponse importStatusResponse = sqlClient.ImportExportOperations.GetByDatabase(resourceGroup.Name, server.Name, dbName2, importResponse.RequestId.Value);
                
                // List Server import/export operations
                IEnumerable<ImportExportOperationResponse> listOperationResponse = sqlClient.ImportExportOperations.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(2, listOperationResponse.Count());
                Assert.Equal(1, listOperationResponse.Count(o => o.RequestType.Equals("Export") && o.DatabaseName.Equals(dbName)));
                Assert.Equal(1, listOperationResponse.Count(o => o.RequestType.Equals("Import") && o.DatabaseName.Equals(dbName2)));

                // Get Server import/export operation
                foreach(ImportExportOperationResponse operation in listOperationResponse)
                {
                    ImportExportOperationResponse getOperationResponse = sqlClient.ImportExportOperations.GetByServer(resourceGroup.Name, server.Name, operation.RequestId.Value);
                    Assert.NotNull(getOperationResponse);
                }
            });
        }

        [Fact]
        public void TestExportImportNewDatabaseGetOperation()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
            string dbName2 = SqlManagementTestUtilities.GenerateName(testPrefix);
            string storageAccountName = SqlManagementTestUtilities.GenerateName("sqlcrudstorage");
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestExportImportNewDatabase", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                string serverNameV12 = SqlManagementTestUtilities.GenerateName(testPrefix);
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create server and set firewall rule
                var server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverNameV12, new Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = SqlManagementTestUtilities.DefaultLocation,
                });
                SqlManagementTestUtilities.ValidateServer(server, serverNameV12, login, version12, tags, SqlManagementTestUtilities.DefaultLocation);

                sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(testPrefix), new ServerFirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "255.255.255.255"
                });

                // Create 2 databases
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location
                });
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName2, new Database()
                {
                    Location = server.Location
                });

                // Get Storage container credentials
                string testMode = HttpMockServer.GetCurrentMode().ToString();
                string storageKey = "StorageKey";
                string storageKeyType = "StorageAccessKey";
                string exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "http://test.blob.core.windows.net/databases/{0}.bacpac", dbName);

                if (testMode == "Record")
                {
                    string importBacpacContainer = Environment.GetEnvironmentVariable("TEST_IMPORT_CONTAINER");
                    storageKey = Environment.GetEnvironmentVariable("TEST_STORAGE_KEY");
                    exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "{0}/{1}.bacpac", importBacpacContainer, dbName);

                    Assert.False(string.IsNullOrWhiteSpace(storageKey), "Environment variable TEST_STORAGE_KEY has not been set.  Set it to storage account key.");
                    Assert.False(string.IsNullOrWhiteSpace(importBacpacContainer), "Environment variable TEST_IMPORT_CONTAINER has not been set.  Set it to a valid storage container URL.");
                }

                // Export database to bacpac
                sqlClient.Databases.Export(resourceGroup.Name, server.Name, dbName, new ExportRequestParameters()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    AuthenticationType = AuthenticationType.SQL,
                    StorageKey = storageKey,
                    StorageKeyType = StorageKeyType.StorageAccessKey,
                    StorageUri = exportBacpacLink
                });

                // Import bacpac to new database
                sqlClient.Servers.ImportDatabase(resourceGroup.Name, server.Name, new ImportRequestParameters()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    AuthenticationType = AuthenticationType.SQL,
                    StorageKey = storageKey,
                    StorageKeyType = StorageKeyType.StorageAccessKey,
                    StorageUri = exportBacpacLink,
                    DatabaseName = dbName2,
                    Edition = SqlTestConstants.DefaultDatabaseEdition,
                    ServiceObjectiveName = ServiceObjectiveName.Basic,
                    MaxSizeBytes = (2 * 1024L * 1024L * 1024L).ToString(),
                });

                // Verify existence of new database
                Assert.NotNull(sqlClient.Databases.Get(resourceGroup.Name, server.Name, dbName2));
                
                // List Server import/export operations
                IEnumerable<ImportExportOperationResponse> listOperationResponse = sqlClient.ImportExportOperations.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(2, listOperationResponse.Count());
                Assert.Equal(1, listOperationResponse.Count(o => o.RequestType.Equals("Export") && o.DatabaseName.Equals(dbName)));
                Assert.Equal(1, listOperationResponse.Count(o => o.RequestType.Equals("Import") && o.DatabaseName.Equals(dbName2)));

                // Get Server import/export operation
                foreach (ImportExportOperationResponse operation in listOperationResponse)
                {
                    ImportExportOperationResponse getOperationResponse = sqlClient.ImportExportOperations.GetByServer(resourceGroup.Name, server.Name, operation.RequestId.Value);
                    Assert.NotNull(getOperationResponse);
                }
            });
        }
    }
}