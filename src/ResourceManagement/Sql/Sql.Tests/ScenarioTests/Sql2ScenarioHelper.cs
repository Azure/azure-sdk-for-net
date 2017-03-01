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

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Net.Http;
using Sql.Tests;
using Sql.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;

namespace Sql2.Tests.ScenarioTests
{
    class Sql2ScenarioHelper
    {

        /// <summary>
        /// The region in which the tests will create their needed resources
        /// </summary>
        private static string TestEnvironmentRegion = "Japan East";

        private static string TestEnvironmentSecondaryRegion = "Southeast Asia";
        
        /// <summary>
        /// Generate a SQL Client from the test base to use.
        /// </summary>
        /// <returns>SQL Client</returns>
        public static SqlManagementClient GetSqlClient(HyakMockContext context, DelegatingHandler handler)
        {
            return context.GetServiceClient<SqlManagementClient>().WithHandler(handler);
        }

        /// <summary>
        /// Generate a Resource Management client from the test base to use for managing resource groups.
        /// </summary>
        /// <returns>Resource Management client</returns>
        public static ResourceManagementClient GetResourceClient(HyakMockContext context, DelegatingHandler handler)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment(), false, new DelegatingHandler[] { handler });
        }

        /// <summary>
        /// Responsible for creating a resource group, and within it a SQL database server, as well as creating a SqlClient for the given handler. 
        /// Once these are created, this method calls the given test with the created sql client, the names of the resource group and server.
        /// This method does not removes the created resources !!! it should be run in an undo context that wraps the call to this method.
        /// </summary>
        /// <param name="handler">A delegation handler to create a Sql client based on it</param>
        /// <param name="serverVersion">The version of the server being created</param>
        /// <param name="test">A function that receives a sql client, names of a created resource group and server</param>
        public static void RunServerTestInEnvironment(HyakMockContext context, BasicDelegatingHandler handler, string serverVersion, Action<SqlManagementClient, string, Server> test)
        {
            RunServerTestInEnvironment(context, handler, serverVersion, TestEnvironmentRegion, test);
        }

        /// <summary>
        /// Responsible for creating a resource group, and within it a SQL database server, as well as creating a SqlClient for the given handler. 
        /// Once these are created, this method calls the given test with the created sql client, the names of the resource group and server.
        /// This method does not removes the created resources !!! it should be run in an undo context that wraps the call to this method.
        /// </summary>
        /// <param name="handler">A delegation handler to create a Sql client based on it</param>
        /// <param name="serverVersion">The version of the server being created</param>
        /// <param name="serverLocation">The location of the server being created</param>
        /// <param name="test">A function that receives a sql client, names of a created resource group and server</param>
        public static void RunServerTestInEnvironment(HyakMockContext context, BasicDelegatingHandler handler, string serverVersion, string serverLocation, Action<SqlManagementClient, string, Server> test)
        {
            // If a test customizes the record matcher, use the cutomized version otherwise use the default
            // permissive record matcher.
            if (HttpMockServer.Matcher == null || HttpMockServer.Matcher.GetType() == typeof(SimpleRecordMatcher))
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("Microsoft.Resources", null);
                d.Add("Microsoft.Features", null);
                d.Add("Microsoft.Authorization", null);
                d.Add("Microsoft.Compute", null);
                var providersToIgnore = new Dictionary<string, string>();
                providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
                HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            }

            // Management Clients
            var sqlClient = Sql2ScenarioHelper.GetSqlClient(context, handler);
            var resClient = Sql2ScenarioHelper.GetResourceClient(context, handler);

            // Variables for server create
            string serverName = TestUtilities.GenerateName("csm-sql-server-");
            string resGroupName = TestUtilities.GenerateName("csm-sql-rg-");

            string adminLogin = "testlogin";
            string adminPass = "testp@ssMakingIt1007Longer";
            string version = serverVersion;

            // Create the resource group.
            resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
            {
                Location = serverLocation,
            });

            try
            {
                //////////////////////////////////////////////////////////////////////
                // Create server for test.
                var server = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                {
                    Location = serverLocation,
                    Properties = new ServerCreateOrUpdateProperties()
                    {
                        AdministratorLogin = adminLogin,
                        AdministratorLoginPassword = adminPass,
                        Version = version,
                    }
                }).Server;

                test(sqlClient, resGroupName, server);
            }
            finally
            {
                // Clean up the resource group.
                resClient.ResourceGroups.Delete(resGroupName);
            }
        }

        /// <summary>
        /// Responsible for creating a resource group, and within it two SQL database servers, as well as creating a SqlClient for the given handler. 
        /// Once these are created, this method calls the given test with the created sql client, the names of the resource group and servers.
        /// This method does not removes the created resources !!! it should be run in an undo context that wraps the call to this method.
        /// </summary>
        /// <param name="handler">A delegation handler to create a Sql client based on it</param>
        /// <param name="serverVersion">The version of the server being created</param>
        /// <param name="test">A function that receives a sql client, names of a created resource group and server</param>
        public static void RunTwoServersTestInEnvironment(HyakMockContext context, BasicDelegatingHandler handler, string serverVersion, bool useDifferentEnvironments, Action<SqlManagementClient, string, Server, Server> test)
        {
            RunTwoServersTestInEnvironment(context, handler, serverVersion, TestEnvironmentRegion, useDifferentEnvironments ? TestEnvironmentSecondaryRegion: TestEnvironmentRegion, test);
        }

        /// <summary>
        /// Responsible for creating a resource group, and within it two SQL database servers, as well as creating a SqlClient for the given handler. 
        /// Once these are created, this method calls the given test with the created sql client, the names of the resource group and servers.
        /// This method does not removes the created resources !!! it should be run in an undo context that wraps the call to this method.
        /// </summary>
        /// <param name="handler">A delegation handler to create a Sql client based on it</param>
        /// <param name="serverVersion">The version of the server being created</param>
        /// <param name="serverLocation">The location of the server being created</param>
        /// <param name="secondaryServerLocation">The location of the second server being created</param>
        /// <param name="test">A function that receives a sql client, names of a created resource group and server</param>
        public static void RunTwoServersTestInEnvironment(HyakMockContext context, BasicDelegatingHandler handler, string serverVersion, string serverLocation, string secondaryServerLocation, Action<SqlManagementClient, string, Server, Server> test)
        {
            // If a test customizes the record matcher, use the cutomized version otherwise use the default
            // permissive record matcher.
            if (HttpMockServer.Matcher == null || HttpMockServer.Matcher.GetType() == typeof(SimpleRecordMatcher))
            {
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("Microsoft.Resources", null);
                d.Add("Microsoft.Features", null);
                d.Add("Microsoft.Authorization", null);
                d.Add("Microsoft.Compute", null);
                var providersToIgnore = new Dictionary<string, string>();
                providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
                HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            }

            // Management Clients
            var sqlClient = Sql2ScenarioHelper.GetSqlClient(context, handler);
            var resClient = Sql2ScenarioHelper.GetResourceClient(context, handler);

            // Variables for server create.
            string resGroupName = TestUtilities.GenerateName("csm-sql-rg-");
            string server1Name = TestUtilities.GenerateName("csm-sql-server-");
            string server2Name = TestUtilities.GenerateName("csm-sql-server-");

            string adminLogin = "testlogin";
            string adminPass = "testp@ssMakingIt1007Longer";
            string version = serverVersion;

            // Create the resource group(s)
            resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()
            {
                Location = serverLocation,
            });

            try
            {
                //////////////////////////////////////////////////////////////////////
                // Create servers for test.
                var server1 =
                    sqlClient.Servers.CreateOrUpdate(resGroupName, server1Name, new ServerCreateOrUpdateParameters()
                    {
                        Location = serverLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    }).Server;

                var server2 =
                    sqlClient.Servers.CreateOrUpdate(resGroupName, server2Name, new ServerCreateOrUpdateParameters()
                    {
                        Location = secondaryServerLocation,
                        Properties = new ServerCreateOrUpdateProperties()
                        {
                            AdministratorLogin = adminLogin,
                            AdministratorLoginPassword = adminPass,
                            Version = version,
                        }
                    }).Server;

                test(sqlClient, resGroupName, server1, server2);
            }
            finally
            {
                // Clean up the resource group(s)
                resClient.ResourceGroups.DeleteAsync(resGroupName);
            }
        }

        /// <summary>
        /// Responsible for creating a resource group, within it a SQL database server and a database, as well as creating a SqlClient for
        /// the given handler. 
        /// Once these are created, this method calls the given test with the created sql client, the names of the resource group, server and
        /// database.
        /// This method does not removes the created resources !!! it should be run in an undo context that wraps the call to this method.
        /// </summary>
        /// <param name="handler">A delegation handler to create a Sql client based on it</param>
        /// <param name="serverVersion">The version of the server being created</param>
        /// <param name="test">A function that receives a sql client, names of a created resource group, server and database</param>
        public static void RunDatabaseTestInEnvironment(HyakMockContext context, BasicDelegatingHandler handler, string serverVersion, Action<SqlManagementClient, string, Server, Database> test)
        {
            var testAdapter = new Action<SqlManagementClient, string, Server>((sqlClient, rgName, server) => RunDbTest(sqlClient, rgName, server, test));
            RunServerTestInEnvironment(context, handler, serverVersion, testAdapter);
        }

        /// <summary>
        /// Responsible for creating a resource group, within it a SQL database server and a database, as well as creating a SqlClient for
        /// the given handler. 
        /// Once these are created, this method calls the given test with the created sql client, the names of the resource group, server and
        /// database.
        /// This method does not removes the created resources !!! it should be run in an undo context that wraps the call to this method.
        /// </summary>
        /// <param name="handler">A delegation handler to create a Sql client based on it</param>
        /// <param name="serverVersion">The version of the server being created</param>
        /// <param name="serverLocation">The location of the server being created</param>
        /// <param name="test">A function that receives a sql client, names of a created resource group, server and database</param>
        public static void RunDatabaseTestInEnvironment(HyakMockContext context, BasicDelegatingHandler handler, string serverVersion, string serverLocation, Action<SqlManagementClient, string, Server, Database> test)
        {
            var testAdapter = new Action<SqlManagementClient, string, Server>((sqlClient, rgName, server) => RunDbTest(sqlClient, rgName, server, test));
            RunServerTestInEnvironment(context, handler, serverVersion, serverLocation, testAdapter);
        }

        /// <summary>
        /// A helper method that creates only a database within the given resource group and server. Once it is created this method calls the
        /// given test with the sql client and the names of the resource group, server and database.
        /// </summary>
        private static void RunDbTest(SqlManagementClient sqlClient, string resGroupName, Server server, Action<SqlManagementClient, string, Server, Database> test)
        {
            // Variables for database create
            string databaseName = TestUtilities.GenerateName("csm-auditing-db");
            string databaseCollation = "Japanese_Bushu_Kakusu_100_CS_AS_KS_WS";
            string databaseEdition = "Basic";
            long databaseMaxSize = 1L * 1024L * 1024L * 1024L; // 1 GB

            //////////////////////////////////////////////////////////////////////
            // Create database for test.

            var database = sqlClient.Databases.CreateOrUpdate(resGroupName, server.Name, databaseName, new DatabaseCreateOrUpdateParameters()
            {
                Location = server.Location,
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    Collation = databaseCollation,
                    Edition = databaseEdition,
                    MaxSizeBytes = databaseMaxSize,
                    RequestedServiceObjectiveId = SqlConstants.DbSloBasic,
                },
            }).Database;
            test(sqlClient, resGroupName, server, database);
        }
    }
}
