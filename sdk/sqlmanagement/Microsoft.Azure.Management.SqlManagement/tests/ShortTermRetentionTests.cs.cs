// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseRestoreScenarioTests
    {

        [Fact]
        public void TestShortTermRetentionPolicyOnBasic()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for Basic DB is 1 to 7 days. 
                int defaultRetentionDays = 7;
				
				// Valid Differential Backup Interval Hours is 12 or 24. 
				int defaultDiffBackupIntervalHours = 24; 

                // Create a DTU - Basic DB so it defaults to 7 days retention and 24 hours differential backup interval.
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(),
                    new Database
                    {
                        Location = server.Location,
                        Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.Basic)
                    });

                // Attempt to set retention period to 8 days (invalid); Attemp to set the differential backup interval to 12 hours (valid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 8, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
				Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);
				
				// Attempt to set retention period to 6 days (valid); Attemp to set the differential backup interval to 6 hours (invalid); Verify the operation fails on updating the policy.
				BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 6, diffBackupIntervalInHours: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
				Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);

				// Attempt to set retention period to 6 days (valid); Attemp to set the differential backup interval to 12 hours (valid); Verify the operation success. 
				BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 6, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.RetentionDays, policy.RetentionDays);
                Assert.Equal(parameters.DiffBackupIntervalInHours, policy.DiffBackupIntervalInHours);
            }
        }
		
        [Fact]
        public void TestShortTermRetentionPolicyOnPremium()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for Basic DB is 1 to 35 days. 
                int defaultRetentionDays = 35;
				
				// Valid Differential Backup Interval Hours is 12 or 24. 
				int defaultDiffBackupIntervalHours = 24; 
                
				// Create a DTU - Premium DB so it defaults to 35 days retention and 24 hours differential backup interval.
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(),
                    new Database
                    {
                        Location = server.Location,
                        Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P1)
                    });

                // Attempt to set retention period to 36 days (invalid); Attemp to set the differential backup interval to 12 hours (valid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 36, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
				Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);
				
				// Attempt to set retention period to 8 days (valid); Attemp to set the differential backup interval to 6 hours (invalid); Verify the operation fails on updating the policy.
				BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 8, diffBackupIntervalInHours: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
				Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);

                // Decrease retention period to 8 days; Decrease differential backup interval to 12 hours; Verfiy that it was updated.
                BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 8, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.RetentionDays, policy.RetentionDays);
                Assert.Equal(parameters.DiffBackupIntervalInHours, policy.DiffBackupIntervalInHours);

                // Increase retention period to 35 days again; Increase differential backup interval to 24 hours again; Verfiy that it was updated.
                parameters = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.RetentionDays, policy.RetentionDays);
                Assert.Equal(parameters.DiffBackupIntervalInHours, policy.DiffBackupIntervalInHours);
            }
        }

        [Fact]
        public void TestShortTermRetentionPolicyOnGeneralPurpose()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for GeneralPurpose DB is 1 to 35 days. 
                int defaultRetentionDays = 35;
				
				// Valid Differential Backup Interval Hours is 12 or 24. 
				int defaultDiffBackupIntervalHours = 24; 
                
				// Create a vCore - GeneralPurpose DB so it defaults to 35 days retention and 24 hours differential backup interval.
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Database database = sqlClient.Databases.CreateOrUpdate(
                    resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(),
                    new Database
                    {
                        Location = server.Location,
                        Sku = new Microsoft.Azure.Management.Sql.Models.Sku(ServiceObjectiveName.P1)
                    });

                // Attempt to set retention period to 36 days (invalid); Attemp to set the differential backup interval to 12 hours (valid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 36, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
				Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);
				
				// Attempt to set retention period to 8 days (valid); Attemp to set the differential backup interval to 6 hours (invalid); Verify the operation fails on updating the policy.
				BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 8, diffBackupIntervalInHours: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
				Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);

                // Decrease retention period to 8 days; Decrease differential backup interval to 12 hours; Verfiy that it was updated.
                BackupShortTermRetentionPolicy parameters = new BackupShortTermRetentionPolicy(retentionDays: 8, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.RetentionDays, policy.RetentionDays);
                Assert.Equal(parameters.DiffBackupIntervalInHours, policy.DiffBackupIntervalInHours);

                // Increase retention period to 35 days again; Increase differential backup interval to 24 hours again; Verfiy that it was updated.
                parameters = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters.RetentionDays, policy.RetentionDays);
                Assert.Equal(parameters.DiffBackupIntervalInHours, policy.DiffBackupIntervalInHours);
            }
        }

    }
}
