// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
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
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                //Create two servers
                var server = context.CreateServer(resourceGroup);
                var server2 = context.CreateServer(resourceGroup);

                // Create a database with all parameters specified
                // 
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location,
                    Collation = SqlTestConstants.DefaultCollation,
                    Sku = SqlTestConstants.DefaultDatabaseSku(),

                    // Make max size bytes less than default, to ensure that copy follows this parameter
                    MaxSizeBytes = 500 * 1024L * 1024L,
                    CreateMode = "Default"
                };
                var db = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                Assert.NotNull(db);

                // Create a database as copy of the first database
                //
                dbName = SqlManagementTestUtilities.GenerateName();
                var dbInputCopy = new Database()
                {
                    Location = server2.Location,
                    CreateMode = CreateMode.Copy,
                    SourceDatabaseId = db.Id
                };
                var dbCopy = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server2.Name, dbName, dbInputCopy);
                SqlManagementTestUtilities.ValidateDatabase(db, dbCopy, dbCopy.Name);
            }
        }
    }
}
