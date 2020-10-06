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
    public class ShortTermRetentionTests
    {
        // NOTE: We plan to config defaultDiffBackupIntervalHours value from 12 to 24 for new database. Then below tests will failed. 
        // Please modify three defaultDiffBackupIntervalHours from 12 to 24 to be re-success if necessary. - 10/5/2020

        [Fact]
        public void TestShortTermRetentionPolicyOnBasic()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for Basic DB is 1 to 7 days. 
                int defaultRetentionDays = 7;

                // Valid Differential Backup Interval Hours is 12 or 24. 
                int defaultDiffBackupIntervalHours = 12;

                // Create a DTU - Basic DB.
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

                // Test GET operation can get default retention days and diffbackupinterval value. 
                BackupShortTermRetentionPolicy policyDefault = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policyDefault.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policyDefault.DiffBackupIntervalInHours);

                // Attempt to set retention period to 8 days (invalid); Attemp to set the differential backup interval to 12 hours (valid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 8, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy1 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy1.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy1.DiffBackupIntervalInHours);

                // Attempt to set retention period to 6 days (valid); Attemp to set the differential backup interval to 6 hours (invalid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters2 = new BackupShortTermRetentionPolicy(retentionDays: 6, diffBackupIntervalInHours: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy2 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy2.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy2.DiffBackupIntervalInHours);

                // Attempt to set retention period to 6 days (valid); Attemp to set the differential backup interval to 12 hours (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 6, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
                Assert.Equal(parameters3.DiffBackupIntervalInHours, policy3.DiffBackupIntervalInHours);

                // Attempt to set retention period to 7 days (valid); Attemp to set the differential backup interval to 12 hours (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters4 = new BackupShortTermRetentionPolicy(retentionDays: 6, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters4);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy4 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy4.RetentionDays);
                Assert.Equal(parameters3.DiffBackupIntervalInHours, policy4.DiffBackupIntervalInHours);
            }
        }

        [Fact]
        public void TestShortTermRetentionPolicyOnPremium()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for Basic DB is 1 to 35 days. 
                int defaultRetentionDays = 7;

                // Valid Differential Backup Interval Hours is 12 or 24. 
                int defaultDiffBackupIntervalHours = 12;

                // Create a DTU - Premium DB.
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

                // Test GET operation can get default retention days and diffbackupinterval value. 
                BackupShortTermRetentionPolicy policyDefault = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policyDefault.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policyDefault.DiffBackupIntervalInHours);

                // Attempt to set retention period to 36 days (invalid); Attemp to set the differential backup interval to 24 hours (valid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 36, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);

                // Attempt to set retention period to 35 days (valid); Attemp to set the differential backup interval to 20 hours (invalid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters2 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 20);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy2 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy2.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy2.DiffBackupIntervalInHours);

                // Increase retention period to 35 days (valid); Increase differential backup interval to 24 hours (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
                Assert.Equal(parameters3.DiffBackupIntervalInHours, policy3.DiffBackupIntervalInHours);

                // Decrease retention period to 7 days again; Decrease differential backup interval to 12 hours again (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters4 = new BackupShortTermRetentionPolicy(retentionDays: 7, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters4);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy4 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters4.RetentionDays, policy4.RetentionDays);
                Assert.Equal(parameters4.DiffBackupIntervalInHours, policy4.DiffBackupIntervalInHours);
            }
        }

        [Fact]
        public void TestShortTermRetentionPolicyOnGeneralPurpose()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for GeneralPurpose DB is 1 to 35 days. 
                int defaultRetentionDays = 7;

                // Valid Differential Backup Interval Hours is 12 or 24. 
                int defaultDiffBackupIntervalHours = 12;

                // Create a vCore - GeneralPurpose DB.
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

                // Test GET operation can get default retention days and diffbackupinterval value. 
                BackupShortTermRetentionPolicy policyDefault = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policyDefault.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policyDefault.DiffBackupIntervalInHours);

                // Attempt to set retention period to 36 days (invalid); Attemp to set the differential backup interval to 24 hours (valid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 36, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy.DiffBackupIntervalInHours);

                // Attempt to set retention period to 35 days (valid); Attemp to set the differential backup interval to 25 hours (invalid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters2 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 25);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy2 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy2.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy2.DiffBackupIntervalInHours);

                // Increase retention period to 35 days (valid); Increase differential backup interval to 24 hours (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
                Assert.Equal(parameters3.DiffBackupIntervalInHours, policy3.DiffBackupIntervalInHours);

                // Decrease retention period to 7 days again; Decrease differential backup interval to 12 hours again (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters4 = new BackupShortTermRetentionPolicy(retentionDays: 7, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters4);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy4 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters4.RetentionDays, policy4.RetentionDays);
                Assert.Equal(parameters4.DiffBackupIntervalInHours, policy4.DiffBackupIntervalInHours);
            }
        }

    }
}