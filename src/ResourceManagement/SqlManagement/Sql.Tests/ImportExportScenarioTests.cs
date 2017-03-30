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
        public void TestImportExistingDatabase()
        {
            string testPrefix = "sqlcrudtest-";
            TestImportExport(true, testPrefix, "TestImportExistingDatabase");
        }

        [Fact]
        public void TestImportNewDatabase()
        {
            string testPrefix = "sqlcrudtest-";
            TestImportExport(false, testPrefix, "TestImportNewDatabase");
        }
        
        public void TestImportExport(bool preexistingDatabase, string testPrefix, string testName)
        {
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, testName, testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                string serverNameV12 = SqlManagementTestUtilities.GenerateName(testPrefix);
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                string dbName2 = SqlManagementTestUtilities.GenerateName(testPrefix);
                string storageAccountName = SqlManagementTestUtilities.GenerateName("sqlcrudstorage");
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // set server firewall rule
                sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(testPrefix), new FirewallRule()
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
                HttpRecorderMode testMode = HttpMockServer.GetCurrentMode();
                string storageKey = "StorageKey";
                string storageKeyType = "StorageAccessKey";
                string exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "http://test.blob.core.windows.net/databases/{0}.bacpac", dbName);

                if (testMode == HttpRecorderMode.Record)
                {
                    string importBacpacContainer = Environment.GetEnvironmentVariable("TEST_IMPORT_CONTAINER");
                    storageKey = Environment.GetEnvironmentVariable("TEST_STORAGE_KEY");
                    exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "{0}/{1}.bacpac", importBacpacContainer, dbName);

                    Assert.False(string.IsNullOrWhiteSpace(storageKey), "Environment variable TEST_STORAGE_KEY has not been set.  Set it to storage account key.");
                    Assert.False(string.IsNullOrWhiteSpace(importBacpacContainer), "Environment variable TEST_IMPORT_CONTAINER has not been set.  Set it to a valid storage container URL.");
                }

                // Export database to bacpac
                sqlClient.Databases.Export(resourceGroup.Name, server.Name, dbName, new ExportRequest()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    AuthenticationType = AuthenticationType.SQL,
                    StorageKey = storageKey,
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
                        StorageKey = storageKey,
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
                        StorageKey = storageKey,
                        StorageKeyType = StorageKeyType.StorageAccessKey,
                        StorageUri = exportBacpacLink,
                        DatabaseName = dbName2,
                        Edition = SqlTestConstants.DefaultDatabaseEdition,
                        ServiceObjectiveName = ServiceObjectiveName.Basic,
                        MaxSizeBytes = (2 * 1024L * 1024L * 1024L).ToString(),
                    });
                }
            });
        }
    }
}