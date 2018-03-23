
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
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                ManagedInstance managedInstance = context.CreateManagedInstance(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                // Create database only required parameters
                //
                string mdbName = SqlManagementTestUtilities.GenerateName();
                var mdb1 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, mdbName, new ManagedDatabase()
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
                var mdb2 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, mdbName, mdb2Input);
                Assert.NotNull(mdb2);
                SqlManagementTestUtilities.ValidateManagedDatabase(mdb2Input, mdb2, mdbName);

                sqlClient.ManagedDatabases.DeleteAsync(resourceGroup.Name, managedInstance.Name, mdb1.Name);
                sqlClient.ManagedDatabases.DeleteAsync(resourceGroup.Name, managedInstance.Name, mdb2.Name);
            }
        }

        [Fact]
        public void TestGetAndListManagedDatabase()
        {
            string testPrefix = "sqlcrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                ManagedInstance managedInstance = context.CreateManagedInstance(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create some small databases to run the get/List tests on.
                ManagedDatabase[] mngdDatabases = SqlManagementTestUtilities.CreateManagedDatabasesAsync(
                    sqlClient, resourceGroup.Name, managedInstance, testPrefix, 4).Result;

                // Organize into a dictionary for better lookup later
                IDictionary<string, ManagedDatabase> inputs = mngdDatabases.ToDictionary(
                            keySelector: d => d.Name,
                            elementSelector: d => d);

                // Get each database and compare to the results of create database
                //
                foreach (var db in inputs)
                {
                    var response = sqlClient.ManagedDatabases.Get(resourceGroup.Name, managedInstance.Name, db.Key);
                    SqlManagementTestUtilities.ValidateManagedDatabaseEx(db.Value, response);
                }

                // List all databases
                //
                var listResponse = sqlClient.ManagedDatabases.ListByInstance(resourceGroup.Name, managedInstance.Name);

                // Remove master database from the list
                Assert.Equal(inputs.Count(), listResponse.Count());
                foreach(var db in listResponse)
                {
                    SqlManagementTestUtilities.ValidateManagedDatabase(inputs[db.Name], db, db.Name);
                }

                foreach (var db in listResponse)
                {
                    sqlClient.ManagedDatabases.DeleteAsync(resourceGroup.Name, managedInstance.Name, db.Name);
                }

            }
        }    
    }
}
