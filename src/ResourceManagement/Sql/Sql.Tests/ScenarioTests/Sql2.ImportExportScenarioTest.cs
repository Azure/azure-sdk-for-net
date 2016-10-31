//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Globalization;
using System.Net;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Sql.Tests;
using Sql2.Tests;
using Sql2.Tests.ScenarioTests;
using Xunit;
using Xunit.Sdk;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for Import/Export Operations
    /// </summary>
    public class Sql2ImportExportScenarioTests : TestBase
    {
        private const string ExportOperationName = "Export";
        private const string ImportOperationName = "Import";
        private const string ImportExistingDbOperationName = "ImportExistingDb";

        [Fact]
        public void ExportDatabaseTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport();
            }
        }

        [Fact]
        public void ImportBacpacTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport(createDatabase: false, operationName: ImportOperationName);
            }
        }

        [Fact]
        public void ImportBacpacToExistingDatabaseTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport(createDatabase: true, operationName: ImportExistingDbOperationName);
            }
        }

        [Fact]
        public void ImportBacpacToExistingDatabaseWhenDatagaseDoesNotExistTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport(createDatabase: false, operationName: ImportExistingDbOperationName, expectedStatueCode: HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public void ExportDatabaseWhenDatabaseDoesNotExistTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport(createDatabase: false, operationName: ExportOperationName, expectedStatueCode: HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public void ExportDatabaseWhenFirewallRuleDoesNotExistTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport(createDatabase: false, createFirewallRule: false, operationName: ExportOperationName, expectedStatueCode: HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public void ExportDatabaseWithMissingFieldsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport(operationName: ExportOperationName, missingFields: true, expectedStatueCode: HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public void ImportWithMissingFieldsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                ValidateImportExport(createDatabase: false, operationName: ImportOperationName, missingFields: true, expectedStatueCode: HttpStatusCode.BadRequest);
            }
        }

        private void ValidateImportExport(bool createServer = true, bool createDatabase = true, bool createFirewallRule = true, 
            string operationName = "Export", bool missingFields = false, HttpStatusCode expectedStatueCode = HttpStatusCode.Accepted)
        {
            var handler = new BasicDelegatingHandler();

            // Management Clients
            var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
            var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

            // Variables for server create
            string serverName = TestUtilities.GenerateName("csm-sql-ie");
            string resGroupName = TestUtilities.GenerateName("csm-rg-servercrud");
            string serverLocation = "North Europe";
            string adminLogin = "testlogin";
            string adminPass = "Testp@ssw0rd";
            string version = "12.0";

            // Variables for database create
            string databaseName = TestUtilities.GenerateName("csm-sql-db_ie");
            string databaseEdition = "Standard";
            long databaseMaxSize = 5L*1024L*1024L*1024L; // 5 GB
            string serviceObjectiveName = "S1";

            // Create firewall test.
            string firewallRuleName = TestUtilities.GenerateName("sql-fwrule");
            string startIp1 = "0.0.0.0";
            string endIp1 = "255.255.255.255";

            string storageKey = "StorageKey";
            string storageKeyType = "StorageAccessKey";
            string exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "http://test.blob.core.windows.net/databases/{0}.bacpac", databaseName);
            string importBacpacLink = "http://test.blob.core.windows.net/databases/test.bacpac";
             
            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            if(testMode == "Record")
            {
                string importBacpacBaseUrl = Environment.GetEnvironmentVariable("TEST_EXPORT_BACPAC");
                storageKey = Environment.GetEnvironmentVariable("TEST_STORAGE_KEY");
                exportBacpacLink = string.Format(CultureInfo.InvariantCulture, "{0}/{1}.bacpac", importBacpacBaseUrl, databaseName);
                importBacpacLink = Environment.GetEnvironmentVariable("TEST_IMPORT_BACPAC");

                Assert.False(string.IsNullOrWhiteSpace(storageKey), "Environment variable TEST_EXPORT_BACPAC has not been set");
                Assert.False(string.IsNullOrWhiteSpace(importBacpacBaseUrl), "Environment variable TEST_EXPORT_BACPAC has not been set");
                Assert.False(string.IsNullOrWhiteSpace(importBacpacLink), "Environment variable TEST_IMPORT_BACPAC has not been set");
            }

            // Create the resource group.
            resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
            {
                Location = serverLocation,
            });

            try
            {
                //////////////////////////////////////////////////////////////////////
                // Create server
                if (createServer)
                {
                    var createResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    });
                    TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);
                }
                //////////////////////////////////////////////////////////////////////
                // Create database
                if (createServer && createDatabase)
                {
                    var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = SqlConstants.DbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);
                }
                //////////////////////////////////////////////////////////////////////
                // Create firewall rule
                if (createServer && createFirewallRule)
                {
                    var firewallCreate = sqlClient.FirewallRules.CreateOrUpdate(resGroupName, serverName, firewallRuleName, new FirewallRuleCreateOrUpdateParameters()
                    {
                        Properties = new FirewallRuleCreateOrUpdateProperties()
                        {
                            StartIpAddress = startIp1,
                            EndIpAddress = endIp1,
                        }
                    });
                    TestUtilities.ValidateOperationResponse(firewallCreate, HttpStatusCode.Created);
                }
                //////////////////////////////////////////////////////////////////////
                //Import Export
                try
                {
                    ImportExportResponse importExportResponse = null;
                    if (operationName == ExportOperationName)
                    {
                        ExportRequestParameters parameters = new ExportRequestParameters()
                        {                            
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass
                        };
                        if (!missingFields)
                        {
                            parameters.StorageKey = storageKey;
                            parameters.StorageKeyType = storageKeyType;
                            parameters.StorageUri = new Uri(exportBacpacLink);
                        }

                        importExportResponse = sqlClient.ImportExport.Export(resGroupName, serverName, databaseName, parameters);
                    }
                    else if (operationName == ImportOperationName)
                    {
                        
                        ImportRequestParameters parameters = new ImportRequestParameters()
                        {                           
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            StorageKey = storageKey,
                            StorageKeyType = storageKeyType,
                            StorageUri = new Uri(importBacpacLink),
                            DatabaseName = databaseName
                        };

                        if (!missingFields)
                        {
                            parameters.DatabaseMaxSize = databaseMaxSize;
                            parameters.Edition = databaseEdition;
                            parameters.ServiceObjectiveName = serviceObjectiveName;
                        }

                        importExportResponse = sqlClient.ImportExport.Import(resGroupName, serverName, parameters);
                    }
                    else if (operationName == ImportExistingDbOperationName)
                    {

                        ImportExtensionRequestParameteres parameters = new ImportExtensionRequestParameteres()
                        {
                            Properties = new ImportExtensionProperties
                            {
                                AdministratorLogin = adminLogin,
                                AdministratorLoginPassword = adminPass,
                                StorageKey = storageKey,
                                StorageKeyType = storageKeyType,
                                StorageUri = new Uri(importBacpacLink)
                            }
                        };

                        importExportResponse = sqlClient.ImportExport.ImportToExistingDatabase(resGroupName, serverName, databaseName, parameters);
                    }

                    if(expectedStatueCode == HttpStatusCode.Accepted)
                    {
                        Assert.Equal(importExportResponse.Status, OperationStatus.InProgress);
                        ImportExportOperationStatusResponse statusResponse = sqlClient.ImportExport.GetImportExportOperationStatus(importExportResponse.OperationStatusLink);
                        while(statusResponse.Status == Microsoft.Azure.OperationStatus.InProgress)
                        {                            
                            statusResponse = sqlClient.ImportExport.GetImportExportOperationStatus(importExportResponse.OperationStatusLink);
                            if (statusResponse.Status == Microsoft.Azure.OperationStatus.InProgress)
                            {
                                ValidateImportExportOperationStatusResponseProperties(statusResponse);
                            }
                        }

                        Assert.Equal(statusResponse.Status, OperationStatus.Succeeded);
                        ValidateImportExportOperationStatusResponseProperties(statusResponse.Properties);
                    }

                    TestUtilities.ValidateOperationResponse(importExportResponse, expectedStatueCode);

                }
                catch (CloudException exception)
                {
                    Assert.Equal(exception.Response.StatusCode, expectedStatueCode);
                }
                if (operationName == ImportOperationName && !createDatabase && !missingFields)
                {
                    DatabaseGetResponse databaseGetResponse = sqlClient.Databases.Get(resGroupName, serverName, databaseName);
                    TestUtilities.ValidateOperationResponse(databaseGetResponse);
                }
            }
            finally
            {
                // Clean up the resource group.
                resClient.ResourceGroups.Delete(resGroupName);
            }
        }

        private void ValidateImportExportOperationStatusResponseProperties(ImportExportOperationStatusResponseProperties properties)
        {
            Assert.False(string.IsNullOrEmpty(properties.BlobUri));
            Assert.False(string.IsNullOrEmpty(properties.DatabaseName));
            Assert.False(string.IsNullOrEmpty(properties.ServerName));
            Assert.False(string.IsNullOrEmpty(properties.StatusMessage));
            Assert.False(string.IsNullOrEmpty(properties.LastModifiedTime));
            Assert.False(string.IsNullOrEmpty(properties.QueuedTime));
        }
    }
}
