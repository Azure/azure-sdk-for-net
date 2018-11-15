using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Network.Models;
using Sku = Microsoft.Azure.Management.Sql.Models.Sku;
using System;
using System.Collections.Generic;
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
    }
}

