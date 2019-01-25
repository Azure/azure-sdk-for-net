using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Sku = Microsoft.Azure.Management.Sql.Models.Sku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;


namespace Sql.Tests
{
    // More tests will be added here once we start working on RestorableDroppedDatabase clients
    //
    public class ManagedDatabaseRestoreScenarioTests
    {
        [Fact]
        public void ShortTermRetentionOnLiveDatabase()
        {
            string testPrefix = "manageddatabaserestorescenariotest-";

            using (SqlManagementTestContext Context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = Context.GetClient<SqlManagementClient>();
                ResourceGroup resourceGroup = Context.CreateResourceGroup();

                // Create vnet and get the subnet id
                VirtualNetwork vnet = ManagedInstanceTestFixture.CreateVirtualNetwork(Context, resourceGroup, TestEnvironmentUtilities.DefaultLocationId);

                Sku sku = new Sku();
                sku.Name = "MIGP8G4";
                sku.Tier = "GeneralPurpose";
                ManagedInstance managedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name,
                    testPrefix + SqlManagementTestUtilities.GenerateName(), new ManagedInstance()
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Sku = sku,
                        SubnetId = vnet.Subnets[0].Id,
                        Tags = new Dictionary<string, string>(),
                        Location = TestEnvironmentUtilities.DefaultLocationId,
                    });

                // Create managed database
                //
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, dbName, new ManagedDatabase()
                {
                    Location = managedInstance.Location,
                });
                Assert.NotNull(db1);

                int basicRetention = 7;
                int invalidValue = 3;
                int validValue = 20;

                // Attempt to increase retention period to 7 days and verfiy that the operation succeeded.
                ManagedBackupShortTermRetentionPolicy parameters0 = new ManagedBackupShortTermRetentionPolicy(retentionDays: basicRetention);
                sqlClient.ManagedBackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, managedInstance.Name, dbName, parameters0);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                ManagedBackupShortTermRetentionPolicy policy = sqlClient.ManagedBackupShortTermRetentionPolicies.Get(resourceGroup.Name, managedInstance.Name, dbName);
                Assert.Equal(basicRetention, policy.RetentionDays);

                // Attempt to increase retention period to 3 days and verfiy that the operation fails.
                ManagedBackupShortTermRetentionPolicy parameters1 = new ManagedBackupShortTermRetentionPolicy(retentionDays: invalidValue);
                sqlClient.ManagedBackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, managedInstance.Name, dbName, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.ManagedBackupShortTermRetentionPolicies.Get(resourceGroup.Name, managedInstance.Name, dbName);
                Assert.Equal(basicRetention, policy.RetentionDays);

                // Attempt to increase retention period to 20 days and verfiy that the operation succeeded .
                ManagedBackupShortTermRetentionPolicy parameters2 = new ManagedBackupShortTermRetentionPolicy(retentionDays: validValue);
                sqlClient.ManagedBackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, managedInstance.Name, dbName, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.ManagedBackupShortTermRetentionPolicies.Get(resourceGroup.Name, managedInstance.Name, dbName);
                Assert.Equal(validValue, policy.RetentionDays);
            }
        }

        [Fact]
        public void ShortTermRetentionOnDroppedDatabase()
        {
            string testPrefix = "manageddatabaserestorescenariotest-";

            using (SqlManagementTestContext Context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = Context.GetClient<SqlManagementClient>();
                ResourceGroup resourceGroup = Context.CreateResourceGroup();

                // Create vnet and get the subnet id
                VirtualNetwork vnet = ManagedInstanceTestFixture.CreateVirtualNetwork(Context, resourceGroup, TestEnvironmentUtilities.DefaultLocationId);

                Sku sku = new Sku();
                sku.Name = "MIGP8G4";
                sku.Tier = "GeneralPurpose";
                ManagedInstance managedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name,
                    testPrefix + SqlManagementTestUtilities.GenerateName(), new ManagedInstance()
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Sku = sku,
                        SubnetId = vnet.Subnets[0].Id,
                        Tags = new Dictionary<string, string>(),
                        Location = TestEnvironmentUtilities.DefaultLocationId,
                    });

                // Create managed database
                //
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, dbName, new ManagedDatabase()
                {
                    Location = managedInstance.Location,
                });
                Assert.NotNull(db1);

                int startingRetention = 25;
                int invalidValue = 35;
                int validValue = 20;

                // Attempt to increase retention period to 25 days and verfiy that the operation succeeded. Since increasing of retention days for dropped database is disabled,
                // we need to increase retention beforehand, and test reducing it once database is dropped.
                ManagedBackupShortTermRetentionPolicy parameters0 = new ManagedBackupShortTermRetentionPolicy(retentionDays: startingRetention);
                sqlClient.ManagedBackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, managedInstance.Name, dbName, parameters0);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                ManagedBackupShortTermRetentionPolicy policy = sqlClient.ManagedBackupShortTermRetentionPolicies.Get(resourceGroup.Name, managedInstance.Name, dbName);
                Assert.Equal(startingRetention, policy.RetentionDays);

                // We need to wait for database to create its first backup. Currently if database drops too quickly it won't be restorable. 
                // This will be changed in couple of weeks, howerver since building up Managed Instance takes over 60mins, this wait isn't not be a problem.
                // No need to sleep if we are playing back the recording.
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(10));
                }

                // Delete the original database
                sqlClient.ManagedDatabases.Delete(resourceGroup.Name, managedInstance.Name, db1.Name);

                // Wait until the final backup is created and the restorable dropped database exists.
                // This could be up to 10 minutes after the database is deleted, and the database must already
                // have a backup (which was accomplished by the previous wait period). Let's wait up to 15
                // just to give it a little more room.
                IEnumerable<RestorableDroppedManagedDatabase> droppedDatabases;
                DateTime startTime = DateTime.UtcNow;
                TimeSpan timeout = TimeSpan.FromMinutes(15);
                do
                {
                    droppedDatabases = sqlClient.RestorableDroppedManagedDatabases.ListByInstance(resourceGroup.Name, managedInstance.Name);

                    if (droppedDatabases.Any())
                    {
                        // Dropped database now exists. Exit polling loop.
                        break;
                    }

                    // Sleep if we are running live to avoid hammering the server.
                    // No need to sleep if we are playing back the recording.
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                    }
                } while (DateTime.UtcNow < startTime + timeout);

                // Assert that we found a restorable db before timeout ended.
                Assert.True(droppedDatabases.Any(), "No dropped databases were found after waiting for " + timeout);

                var rdmd = droppedDatabases.Single();

                // Attempt to increase retention period to 3 days and verfiy that the operation fails.
                ManagedBackupShortTermRetentionPolicy parameters1 = new ManagedBackupShortTermRetentionPolicy(retentionDays: invalidValue);
                sqlClient.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, managedInstance.Name, rdmd.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.Get(resourceGroup.Name, managedInstance.Name, rdmd.Name);
                Assert.Equal(startingRetention, policy.RetentionDays);

                // Attempt to increase retention period to 20 days and verfiy that the operation succeeded .
                ManagedBackupShortTermRetentionPolicy parameters2 = new ManagedBackupShortTermRetentionPolicy(retentionDays: validValue);
                sqlClient.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, managedInstance.Name, rdmd.Name, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.Get(resourceGroup.Name, managedInstance.Name, rdmd.Name);
                Assert.Equal(validValue, policy.RetentionDays);
            }
        }

        [Fact]
        public void RestorableDroppedManagedDatabasesTests()
        {
            string testPrefix = "manageddatabaserestorescenariotest-";

            using (SqlManagementTestContext Context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = Context.GetClient<SqlManagementClient>();
                ResourceGroup resourceGroup = Context.CreateResourceGroup();

                // Create vnet and get the subnet id
                VirtualNetwork vnet = ManagedInstanceTestFixture.CreateVirtualNetwork(Context, resourceGroup, TestEnvironmentUtilities.DefaultLocationId);

                Sku sku = new Sku();
                sku.Name = "MIGP8G4";
                sku.Tier = "GeneralPurpose";
                ManagedInstance managedInstance = sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name,
                    testPrefix + SqlManagementTestUtilities.GenerateName(), new ManagedInstance()
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Sku = sku,
                        SubnetId = vnet.Subnets[0].Id,
                        Tags = new Dictionary<string, string>(),
                        Location = TestEnvironmentUtilities.DefaultLocationId,
                    });

                // Create managed database
                //
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, dbName, new ManagedDatabase()
                {
                    Location = managedInstance.Location,
                });
                Assert.NotNull(db1);

                // We need to wait for database to create its first backup. Currently if database drops too quickly it won't be restorable. 
                // This will be changed in couple of weeks, howerver since building up Managed Instance takes over 60mins, this wait isn't not be a problem.
                // No need to sleep if we are playing back the recording.
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(10));
                }

                // Delete the original database
                sqlClient.ManagedDatabases.Delete(resourceGroup.Name, managedInstance.Name, db1.Name);

                // Wait until the final backup is created and the restorable dropped database exists.
                // This could be up to 10 minutes after the database is deleted, and the database must already
                // have a backup (which was accomplished by the previous wait period). Let's wait up to 15
                // just to give it a little more room.
                IEnumerable<RestorableDroppedManagedDatabase> droppedDatabases;
                DateTime startTime = DateTime.UtcNow;
                TimeSpan timeout = TimeSpan.FromMinutes(15);
                do
                {
                    droppedDatabases = sqlClient.RestorableDroppedManagedDatabases.ListByInstance(resourceGroup.Name, managedInstance.Name);

                    if (droppedDatabases.Any())
                    {
                        // Dropped database now exists. Exit polling loop.
                        break;
                    }

                    // Sleep if we are running live to avoid hammering the server.
                    // No need to sleep if we are playing back the recording.
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                    }
                } while (DateTime.UtcNow < startTime + timeout);

                // Assert that we found a restorable db before timeout ended.
                Assert.True(droppedDatabases.Any(), "No dropped databases were found after waiting for " + timeout);

                // The original database should now exist as a restorable dropped database
                var droppedDatabase = droppedDatabases.Single();
                Assert.StartsWith(db1.Name, droppedDatabase.Name);
                Assert.True(droppedDatabases.Count() == 1);

                // Test single get
                var getDroppedDatabase = sqlClient.RestorableDroppedManagedDatabases.Get(resourceGroup.Name, managedInstance.Name, droppedDatabase.Name);
                Assert.StartsWith(getDroppedDatabase.Name, droppedDatabase.Name);

                // Create another managed database
                //
                dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db2 = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, dbName, new ManagedDatabase()
                {
                    Location = managedInstance.Location,
                });
                Assert.NotNull(db2);

                // We need to wait for database to create its first backup. Currently if database drops too quickly it won't be restorable. 
                // This will be changed in couple of weeks, howerver since building up Managed Instance takes over 60mins, this wait isn't not be a problem.
                // No need to sleep if we are playing back the recording.
                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(10));
                }

                // Delete the original database
                sqlClient.ManagedDatabases.Delete(resourceGroup.Name, managedInstance.Name, db2.Name);

                // Wait until the final backup is created and the restorable dropped database exists.
                // This could be up to 10 minutes after the database is deleted, and the database must already
                // have a backup (which was accomplished by the previous wait period). Let's wait up to 15
                // just to give it a little more room.
                do
                {
                    droppedDatabases = sqlClient.RestorableDroppedManagedDatabases.ListByInstance(resourceGroup.Name, managedInstance.Name);

                    if (droppedDatabases.Any())
                    {
                        // Dropped database now exists. Exit polling loop.
                        break;
                    }

                    // Sleep if we are running live to avoid hammering the server.
                    // No need to sleep if we are playing back the recording.
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(30));
                    }
                } while (DateTime.UtcNow < startTime + timeout);

                // There should be 2 dropped databases now
                Assert.True(droppedDatabases.Count() == 2);
            }
        }
    }
}

