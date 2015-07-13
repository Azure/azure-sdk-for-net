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

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for server CRUD, database CRUD, and firewall CRUD
    /// </summary>
    public class Sql2ScenarioTest : TestBase
    {
        /// <summary>
        /// Test for the server CRUD operations
        /// </summary>
        [Fact]
        public void ServerCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-servercrud");
                string resGroupName = TestUtilities.GenerateName("csm-rg-servercrud");
                string serverLocation = "West US";
                string adminLogin = "testlogin";
                string adminPass = "Testp@ssw0rd";
                string adminPass2 = "S3c0ndP455";
                string version = "12.0";

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server Test.
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

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, adminPass, version, createResponse.Server);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Get Server Test

                    // Get single server
                    var getResponse = sqlClient.Servers.Get(resGroupName, serverName);

                    // Verify that the Get request contains the right information.
                    TestUtilities.ValidateOperationResponse(getResponse, HttpStatusCode.OK);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, null, version, getResponse.Server);

                    // List all servers
                    var listResponse = sqlClient.Servers.List(resGroupName);

                    TestUtilities.ValidateOperationResponse(listResponse);
                    Assert.Equal(1, listResponse.Servers.Count);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, null, version, listResponse.Servers[0]);
                    ///////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////////////////////////////////////////
                    // Update Server Test
                    var updateResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLoginPassword = adminPass2,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, adminPass2, version, updateResponse.Server);
                    ///////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////////////////////////////////////////
                    // Delete Server Test
                    var deleteResponse = sqlClient.Servers.Delete(resGroupName, serverName);

                    // Verify that the delete operation works.
                    TestUtilities.ValidateOperationResponse(deleteResponse, HttpStatusCode.NoContent);
                    /////////////////////////////////////////////////////////////////////
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Tests for the database CRUD operations
        /// </summary>
        [Fact]
        public void DatabaseCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-dbcrud-server");
                string resGroupName = TestUtilities.GenerateName("csm-rg-dbcrud");
                string serverLocation = "Japan East";
                string adminLogin = "testlogin";
                string adminPass = "Testp@ss";
                string version = "12.0";

                // Default values
                var defaultCollation = "SQL_Latin1_General_CP1_CI_AS";
                var defaultEdition = "Standard";
                var defaultDatabaseSize = 1L * 1024L * 1024L * 1024L; // 1 GB
                var defaultGuid = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c");

                // Variables for database create
                string databaseName = TestUtilities.GenerateName("csm-sql-dbcrud-db");
                string databaseCollation = "Japanese_Bushu_Kakusu_100_CS_AS_KS_WS";
                string databaseEdition = "Standard";
                long databaseMaxSize = 5L * 1024L * 1024L * 1024L; // 5 GB
                Guid dbSloShared = new Guid("910b4fcb-8a29-4c3e-958f-f7ba794388b2"); // Web / Business
                Guid dbSloBasic = new Guid("dd6d99bb-f193-4ec1-86f2-43d3bccbc49c"); // Basic
                Guid dbSloS0 = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b "); // S0
                Guid dbSloS1 = new Guid("1b1ebd4d-d903-4baa-97f9-4ea675f5e928"); // S1
                Guid dbSloS2 = new Guid("455330e1-00cd-488b-b5fa-177c226f28b7"); // S2

                var databaseName2 = TestUtilities.GenerateName("csm-sql-dbcrud-db");
                var databaseMaxSize2 = defaultDatabaseSize / 2L;
                var dbEditionBasic = "Basic";

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test.
                    var createServerResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    });

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createServerResponse, HttpStatusCode.Created);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, adminPass, version, createServerResponse.Server);
                    //////////////////////////////////////////////////////////////////////

                    // Get Service objectives
                    // var serviceObjectivesResponse = sqlClient.ServiceObjectives.List(resGroupName, serverName);
                    // TestUtilities.ValidateOperationResponse(serviceObjectivesResponse, HttpStatusCode.OK);

                    //////////////////////////////////////////////////////////////////////
                    // Create database test.

                    // Create all options.
                    var createDbResponse1 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Collation = databaseCollation,
                            Edition = databaseEdition,
                            MaxSizeBytes = databaseMaxSize,
                            RequestedServiceObjectiveId = dbSloS1
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse1, HttpStatusCode.Created);
                    VerifyDatabaseInformation(createDbResponse1.Database, serverLocation, databaseCollation, databaseEdition, databaseMaxSize, dbSloS1, dbSloS1);

                    // Create only required
                    var createDbResponse2 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName2, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            MaxSizeBytes = defaultDatabaseSize,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse2, HttpStatusCode.Created);
                    VerifyDatabaseInformation(createDbResponse2.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dbSloS0, dbSloS0);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Get database test.
                    
                    // Get first database
                    var getDatabase1 = sqlClient.Databases.Get(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(getDatabase1);
                    VerifyDatabaseInformation(getDatabase1.Database, serverLocation, databaseCollation, databaseEdition, databaseMaxSize, dbSloS1, dbSloS1);

                    // Get second database
                    var getDatabase2 = sqlClient.Databases.Get(resGroupName, serverName, databaseName2);

                    TestUtilities.ValidateOperationResponse(getDatabase2);
                    VerifyDatabaseInformation(getDatabase2.Database, serverLocation, defaultCollation, defaultEdition, defaultDatabaseSize, dbSloS0, dbSloS0);

                    // Get all databases
                    var listDatabase1 = sqlClient.Databases.List(resGroupName, serverName);
                    TestUtilities.ValidateOperationResponse(listDatabase1);
                    Assert.Equal(3, listDatabase1.Databases.Count);

                    //Get database by ID
                    var getById = sqlClient.Databases.GetById(resGroupName, serverName, getDatabase1.Database.Properties.DatabaseId);

                    TestUtilities.ValidateOperationResponse(getById);
                    Assert.Equal(1, getById.Databases.Count);
                    VerifyDatabaseInformation(getById.Databases[0], serverLocation, databaseCollation, databaseEdition, databaseMaxSize, dbSloS1, dbSloS1);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Update database test.

                    // Update SLO
                    var updateDb1 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            RequestedServiceObjectiveId = dbSloS2
                        },
                    });

                    TestUtilities.ValidateOperationResponse(updateDb1);
                    VerifyDatabaseInformation(updateDb1.Database, serverLocation, databaseCollation, databaseEdition, databaseMaxSize, dbSloS2, dbSloS2);

                    //Update Size
                    var updateDb2 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            MaxSizeBytes = defaultDatabaseSize,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(updateDb2);
                    VerifyDatabaseInformation(updateDb2.Database, serverLocation, databaseCollation, databaseEdition, defaultDatabaseSize, dbSloS2, dbSloS2);

                    //Update Edition + SLO
                    var updateDb3 = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName2, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            Edition = dbEditionBasic,
                            RequestedServiceObjectiveId = dbSloBasic,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(updateDb3);
                    VerifyDatabaseInformation(updateDb3.Database, serverLocation, defaultCollation, "Basic", defaultDatabaseSize, dbSloBasic, dbSloBasic);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Delete database test.
                    var deleteDb1 = sqlClient.Databases.Delete(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(deleteDb1, HttpStatusCode.OK);

                    var deleteDb2 = sqlClient.Databases.Delete(resGroupName, serverName, databaseName2);

                    TestUtilities.ValidateOperationResponse(deleteDb2, HttpStatusCode.OK);
                    //////////////////////////////////////////////////////////////////////
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Test for Azure SQL Data Warehouse database pause and resume operations.
        /// </summary>
        [Fact]
        public void DatabaseActivationTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server creation.
                string serverName = TestUtilities.GenerateName("csm-sql-activation");
                string resGroupName = TestUtilities.GenerateName("csm-rg-activation");
                
                string serverLocation = "Southeast Asia";
                string adminLogin = "testlogin";
                string adminPass = "NotYukon!9";
                string version = "12.0";
                 

                // Constants for database creation.
                var defaultDatabaseSize = 250L * 1024L * 1024L * 1024L; // 250 GB
                Guid dwSlo = new Guid("4E63CB0E-91B9-46FD-B05C-51FDD2367618 "); // DW100
                var defaultCollation = "SQL_Latin1_General_CP1_CI_AS";
                var databaseName = TestUtilities.GenerateName("csm-sql-activation-db");
                string databaseEdition = "DataWarehouse";
                 
                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test.
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

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, adminPass, version, createResponse.Server);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Create database test.

                    // Create only required
                    var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            MaxSizeBytes = defaultDatabaseSize,
                            Edition = databaseEdition,
                            RequestedServiceObjectiveId = dwSlo,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);
                    VerifyDatabaseInformation(createDbResponse.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dwSlo, dwSlo);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Pause database.
                    
                    var pauseResponse = sqlClient.DatabaseActivation.Pause(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(pauseResponse, HttpStatusCode.OK);
                    VerifyDatabaseInformation(pauseResponse.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dwSlo, dwSlo, "Paused");
                    ///////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////////////////////////////////////////
                    // Resume database.

                    var resumeResponse = sqlClient.DatabaseActivation.Resume(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(resumeResponse, HttpStatusCode.OK);
                    VerifyDatabaseInformation(resumeResponse.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dwSlo, dwSlo, "Online");
                    ///////////////////////////////////////////////////////////////////////
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Tests for firewall CRUD operations
        /// </summary>
        [Fact]
        public void FirewallCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-firewallcrud");
                string resGroupName = TestUtilities.GenerateName("csm-rg-firewallcrud");
                string serverLocation = "West US";
                string adminLogin = "testlogin";
                string adminPass = "Testp@ssw0rd";
                string version = "12.0";

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test.
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

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, adminPass, version, createResponse.Server);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Create firewall test.
                    string firewallRuleName = TestUtilities.GenerateName("sql-fwrule");
                    string startIp1 = "1.2.3.4";
                    string endIp1 = "2.3.4.5";
                    string startIp2 = "10.20.30.40";
                    string endIp2 = "20.30.40.50";

                    // Create standard firewall rule.
                    var firewallCreate = sqlClient.FirewallRules.CreateOrUpdate(resGroupName, serverName, firewallRuleName, new FirewallRuleCreateOrUpdateParameters()
                    {
                        Properties = new FirewallRuleCreateOrUpdateProperties()
                        {
                            StartIpAddress = startIp1,
                            EndIpAddress = endIp1,
                        }
                    });

                    TestUtilities.ValidateOperationResponse(firewallCreate, HttpStatusCode.Created);
                    FirewallRule rule = firewallCreate.FirewallRule;
                    VerifyFirewallRuleInformation(firewallRuleName, startIp1, endIp1, rule);
                    //////////////////////////////////////////////////////////////////////                    

                    //////////////////////////////////////////////////////////////////////
                    // Get firewall Test

                    // Get single firewall rule
                    var getFirewall = sqlClient.FirewallRules.Get(resGroupName, serverName, firewallRuleName);

                    // Verify that the Get request contains the right information.
                    TestUtilities.ValidateOperationResponse(getFirewall, HttpStatusCode.OK);
                    VerifyFirewallRuleInformation(firewallRuleName, startIp1, endIp1, getFirewall.FirewallRule);

                    // List all firewall rules
                    var listResponse = sqlClient.FirewallRules.List(resGroupName, serverName);

                    TestUtilities.ValidateOperationResponse(listResponse);
                    Assert.Equal(1, listResponse.FirewallRules.Count);
                    VerifyFirewallRuleInformation(firewallRuleName, startIp1, endIp1, listResponse.FirewallRules[0]);
                    ///////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////////////////////////////////////////
                    // Update firewall Test
                    var updateResponse = sqlClient.FirewallRules.CreateOrUpdate(resGroupName, serverName, firewallRuleName, new FirewallRuleCreateOrUpdateParameters()
                    {
                        Properties = new FirewallRuleCreateOrUpdateProperties()
                        {
                            StartIpAddress = startIp2,
                            EndIpAddress = endIp2,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);
                    VerifyFirewallRuleInformation(firewallRuleName, startIp2, endIp2, updateResponse.FirewallRule);
                    ///////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////////////////////////////////////////
                    // Delete firewall Test
                    var deleteResponse = sqlClient.FirewallRules.Delete(resGroupName, serverName, firewallRuleName);

                    // Verify that the delete operation works.
                    TestUtilities.ValidateOperationResponse(deleteResponse, HttpStatusCode.OK);
                    /////////////////////////////////////////////////////////////////////
                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Tests for transparent data encryption CRUD operations
        /// </summary>
        [Fact]
        public void TransparentDataEncryptionCRUDTest()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                // Management Clients
                var sqlClient = Sql2ScenarioHelper.GetSqlClient(handler);
                var resClient = Sql2ScenarioHelper.GetResourceClient(handler);

                // Variables for server create
                string serverName = TestUtilities.GenerateName("csm-sql-transparentdataencryptioncrud");
                string resGroupName = TestUtilities.GenerateName("csm-rg-transparentdataencryptioncrud");
                string serverLocation = "Japan East";
                string adminLogin = "testlogin";
                string adminPass = "NotYukon!9";
                string version = "12.0";
                var defaultDatabaseSize = 1L * 1024L * 1024L * 1024L; // 1 GB
                Guid dbSloS0 = new Guid("f1173c43-91bd-4aaa-973c-54e79e15235b "); // S0
                var defaultCollation = "SQL_Latin1_General_CP1_CI_AS";
                var databaseName = TestUtilities.GenerateName("csm-sql-tde-db");
                string databaseEdition = "Standard";

                // Create the resource group.
                resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
                {
                    Location = serverLocation,
                });

                try
                {
                    //////////////////////////////////////////////////////////////////////
                    // Create server for test.
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

                    // Verify the the response from the service contains the right information
                    TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);
                    VerifyServerInformation(serverName, serverLocation, adminLogin, adminPass, version, createResponse.Server);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Create database test.

                    // Create only required
                    var createDbResponse = sqlClient.Databases.CreateOrUpdate(resGroupName, serverName, databaseName, new DatabaseCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new DatabaseCreateOrUpdateProperties()
                        {
                            MaxSizeBytes = defaultDatabaseSize,
                        },
                    });

                    TestUtilities.ValidateOperationResponse(createDbResponse, HttpStatusCode.Created);
                    VerifyDatabaseInformation(createDbResponse.Database, serverLocation, defaultCollation, databaseEdition, defaultDatabaseSize, dbSloS0, dbSloS0);
                    //////////////////////////////////////////////////////////////////////

                    //////////////////////////////////////////////////////////////////////
                    // Get transparent data encryption Test

                    // Get single transparent data encryption 
                    var getTde = sqlClient.TransparentDataEncryption.Get(resGroupName, serverName, databaseName);

                    // Verify that the Get request contains the right information.
                    TestUtilities.ValidateOperationResponse(getTde, HttpStatusCode.OK);
                    VerifyTransparentDataEncryptionInformation(TransparentDataEncryptionStates.Disabled, getTde.TransparentDataEncryption);
                    ///////////////////////////////////////////////////////////////////////

                    ///////////////////////////////////////////////////////////////////////
                    // Update Transparent Data Encryption Test
                    var updateResponse = sqlClient.TransparentDataEncryption.CreateOrUpdate(resGroupName, serverName, databaseName, new TransparentDataEncryptionCreateOrUpdateParameters
                    {
                        Properties = new TransparentDataEncryptionCreateOrUpdateProperties()
                        {
                            State = TransparentDataEncryptionStates.Enabled,
                        },
                    });

                    ///////////////////////////////////////////////////////////////////////
                    // Get Transparent Data Encryption Activity Test
                    var activities = sqlClient.TransparentDataEncryption.ListActivity(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(activities, HttpStatusCode.OK);
                    Assert.True(activities.TransparentDataEncryptionActivities.Count > 0);
                    var transparentDataEncryptionActivity = activities.TransparentDataEncryptionActivities[0];
                    VerifyTransparentDataEncryptionActivityInformation(TransparentDataEncryptionActivityStates.Encrypting, transparentDataEncryptionActivity);

                    // Get single transparent data encryption 
                    getTde = sqlClient.TransparentDataEncryption.Get(resGroupName, serverName, databaseName);

                    TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);
                    VerifyTransparentDataEncryptionInformation(TransparentDataEncryptionStates.Enabled, getTde.TransparentDataEncryption);
                    ///////////////////////////////////////////////////////////////////////

                }
                finally
                {
                    // Clean up the resource group.
                    resClient.ResourceGroups.Delete(resGroupName);
                }
            }
        }

        /// <summary>
        /// Verifies that the Transparent Data Encryption values match the expected values
        /// </summary>
        /// <param name="state">The expected rule name</param>
        /// <param name="tde">The expected start IP address</param>
        private static void VerifyTransparentDataEncryptionInformation(string state, TransparentDataEncryption tde)
        {
            Assert.Equal(state, tde.Properties.State);
        }

        /// <summary>
        /// Verifies that the Transparent Data Encryption Activity values match the expected values
        /// </summary>
        /// <param name="state">The expected rule name</param>
        /// <param name="tdeActivity">The expected start IP address</param>
        private static void VerifyTransparentDataEncryptionActivityInformation(string state, TransparentDataEncryptionActivity tdeActivity)
        {
            Assert.Equal(state, tdeActivity.Properties.Status);
            Assert.InRange(tdeActivity.Properties.PercentComplete, 0.00001f, 100f);
        }

        /// <summary>
        /// Verifies that the FirewallRule values match the expected values
        /// </summary>
        /// <param name="firewallRuleName">The expected rule name</param>
        /// <param name="startIp1">The expected start IP address</param>
        /// <param name="endIp1">The expected end IP address</param>
        /// <param name="rule">The actual rule information</param>
        private static void VerifyFirewallRuleInformation(string firewallRuleName, string startIp1, string endIp1, FirewallRule rule)
        {
            Assert.Equal(firewallRuleName, rule.Name);
            Assert.Equal(startIp1, rule.Properties.StartIpAddress);
            Assert.Equal(endIp1, rule.Properties.EndIpAddress);
        }

        /// <summary>
        /// Verify that the Database object matches the provided values
        /// </summary>
        /// <param name="serverLocation">The expected server location</param>
        /// <param name="databaseCollation">The expected database collation</param>
        /// <param name="databaseEdition">The expected database edition</param>
        /// <param name="databaseMaxSize">The expected database max size</param>
        /// <param name="currentSlo">The expected database service objective</param>
        /// <param name="db">The actual database object</param>
        private static void VerifyDatabaseInformation(Database db, string serverLocation, string databaseCollation, string databaseEdition, long databaseMaxSize, Guid requestedSlo, Guid currentSlo, string status = null)
        {
            Assert.Equal(serverLocation, db.Location);
            Assert.Equal(databaseCollation, db.Properties.Collation);
            Assert.Equal(databaseEdition, db.Properties.Edition);
            Assert.Equal(databaseMaxSize, db.Properties.MaxSizeBytes);
            Assert.Equal(requestedSlo.ToString(), db.Properties.RequestedServiceObjectiveId);
            Assert.Equal(currentSlo.ToString(), db.Properties.CurrentServiceObjectiveId);
            if(status != null)
            {
                Assert.Equal(status, db.Properties.Status);
            }
        }

        /// <summary>
        /// Verify that the Server object matches the provided values
        /// </summary>
        /// <param name="serverName">The expected server name</param>
        /// <param name="serverLocation">The expected server location</param>
        /// <param name="adminLogin">The expected admin login</param>
        /// <param name="adminPassword">The expected password</param>
        /// <param name="version">The expected version</param>
        /// <param name="server">The actual server object</param>
        private static void VerifyServerInformation(string serverName, string serverLocation, string adminLogin, string adminPassword, string version, Server server)
        {
            Assert.Equal(serverName, server.Name);
            Assert.Equal(serverLocation, server.Location);
            Assert.NotEmpty(server.Id);
            Assert.Equal(adminLogin, server.Properties.AdministratorLogin);
            Assert.Equal(adminPassword, server.Properties.AdministratorLoginPassword);
            Assert.Equal(version, server.Properties.Version);
        }
    }
}
