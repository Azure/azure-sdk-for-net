// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseCopyScenarioTests
    {
        [Fact]
        public void TestCopyDatabase()
        {
            string login = "dummylogin";
            string password = "Un53cuRE!";
            string version12 = "12.0";
            string databaseName = "testdb";
            string testPrefix = "sqlcrudtest-";
            Dictionary<string, string> tags = new Dictionary<string, string>();
            string testName = this.GetType().FullName;

            SqlManagementTestUtilities.RunTestInNewResourceGroup(testName, "TestCopyDatabase", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                //Create two servers
                string serverName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverName, new Microsoft.Azure.Management.Sql.Models.Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Location = SqlManagementTestUtilities.DefaultLocation,
                    Tags = tags,
                });
                SqlManagementTestUtilities.ValidateServer(server, serverName, login, version12, tags, SqlManagementTestUtilities.DefaultLocation);

                string serverName2 = SqlManagementTestUtilities.GenerateName(testPrefix);
                var server2 = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverName2, new Microsoft.Azure.Management.Sql.Models.Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Location = SqlManagementTestUtilities.DefaultLocation,
                    Tags = tags,
                });
                SqlManagementTestUtilities.ValidateServer(server2, serverName2, login, version12, tags, SqlManagementTestUtilities.DefaultLocation);

                // Create a database with all parameters specified
                // 
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var dbInput = new Microsoft.Azure.Management.Sql.Models.Database()
                {
                    Location = server.Location,
                    Collation = SqlTestConstants.DefaultCollation,
                    Edition = SqlTestConstants.DefaultDatabaseEdition,

                    // Make max size bytes less than default, to ensure that copy follows this parameter
                    MaxSizeBytes = (500 * 1024L * 1024L).ToString(),
                    RequestedServiceObjectiveName = SqlTestConstants.DefaultDatabaseEdition,
                    RequestedServiceObjectiveId = ServiceObjectiveId.Basic,
                    CreateMode = "Default"
                };
                var db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                Assert.NotNull(db);

                // Create a database as copy of the first database
                //
                dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var dbInputCopy = new Microsoft.Azure.Management.Sql.Models.Database()
                {
                    Location = server2.Location,
                    CreateMode = CreateMode.Copy,
                    SourceDatabaseId = db.Id
                };
                var dbCopy = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server2.Name, dbName, dbInputCopy);
                SqlManagementTestUtilities.ValidateDatabase(db, dbCopy, dbCopy.Name);
            });
        }
    }
}
