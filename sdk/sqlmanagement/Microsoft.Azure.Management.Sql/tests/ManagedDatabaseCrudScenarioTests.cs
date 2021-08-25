// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ManagedDatabaseCrudScenarioTests
    {
        [Fact]
        public void TestCreateDropManagedDatabase()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Update with values from a current MI on the region
                //
                string resourceGroup = "testclrg";
                string managedInstanceName = "tdstage-haimb-dont-delete-3";

                //Get MI
                var managedInstance = sqlClient.ManagedInstances.Get(resourceGroup, managedInstanceName);

                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create database only required parameters
                //
                string mdbName = SqlManagementTestUtilities.GenerateName();
                var mdb1 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup, managedInstance.Name, mdbName, new ManagedDatabase()
                {
                    Location = managedInstance.Location,
                });
                Assert.NotNull(mdb1);

                // Create a database with all parameters specified
                //
                mdbName = SqlManagementTestUtilities.GenerateName();
                var mdb2Input = new ManagedDatabase()
                {
                    Location = managedInstance.Location,
                    Collation = SqlTestConstants.DefaultCollation,
                    Tags = tags,
                    CreateMode = "Default"
                };
                var mdb2 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup, managedInstance.Name, mdbName, mdb2Input);
                Assert.NotNull(mdb2);
                SqlManagementTestUtilities.ValidateManagedDatabase(mdb2Input, mdb2, mdbName);

                sqlClient.ManagedDatabases.Delete(resourceGroup, managedInstance.Name, mdb1.Name);
                sqlClient.ManagedDatabases.Delete(resourceGroup, managedInstance.Name, mdb2.Name);
            }
        }

        [Fact]
        public void TestGetAndListManagedDatabase()
        {
            string testPrefix = "sqlcrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Update with values from a current MI on the region
                //
                string resourceGroup = "testclrg";
                string managedInstanceName = "tdstage-haimb-dont-delete-3";

                // Get MI
                var managedInstance = sqlClient.ManagedInstances.Get(resourceGroup, managedInstanceName);

                // Create some small databases to run the get/List tests on.
                ManagedDatabase[] mngdDatabases = SqlManagementTestUtilities.CreateManagedDatabasesAsync(
                    sqlClient, resourceGroup, managedInstance, testPrefix, 4).Result;

                // Organize into a dictionary for better lookup later
                IDictionary<string, ManagedDatabase> inputs = mngdDatabases.ToDictionary(
                            keySelector: d => d.Name,
                            elementSelector: d => d);

                // Get each database and compare to the results of create database
                //
                foreach (var db in inputs)
                {
                    var response = sqlClient.ManagedDatabases.Get(resourceGroup, managedInstance.Name, db.Key);
                    SqlManagementTestUtilities.ValidateManagedDatabaseEx(db.Value, response);
                }

                // List all databases
                //
                var listResponse = sqlClient.ManagedDatabases.ListByInstance(resourceGroup, managedInstance.Name);

                // Check that all created Managed Databases are created
                foreach (var db in inputs.Keys)
                {
                    var actualDbList = listResponse.Where(d => d.Name.Equals(db));
                    Assert.True(actualDbList.Count() == 1);
                    ManagedDatabase actualDb = actualDbList.FirstOrDefault();
                    SqlManagementTestUtilities.ValidateManagedDatabase(inputs[db], actualDb, db);
                }

                foreach (var db in inputs.Keys)
                {
                    sqlClient.ManagedDatabases.Delete(resourceGroup, managedInstance.Name, db);
                }

            }
        }
    }
}
