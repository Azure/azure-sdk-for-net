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
        // The new created database's defaultDiffBackupIntervalHours could be null if you re-record this test after 06/20/2021.

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

                // Failure Scenario 1: Attempt to set retention period to 8 days (invalid); Attemp to set the differential backup interval to 12 hours (valid);
                // Verify the operation fails on updating the policy. So policy value equals to default value.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 8, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy1 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy1.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy1.DiffBackupIntervalInHours);

                // Failure Scenario 2: Attempt to set retention period to 6 days (valid); Attemp to set the differential backup interval to 6 hours (invalid);
                // Verify the operation fails on updating the policy.So policy value equals to default value.
                BackupShortTermRetentionPolicy parameters2 = new BackupShortTermRetentionPolicy(retentionDays: 6, diffBackupIntervalInHours: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy2 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy2.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy2.DiffBackupIntervalInHours);

                // Success Scenario 1: Attempt to set retention period to 5 days (valid); Attemp to set the differential backup interval to 24 (valid);
                // Verify the operation success. So policy value equals to the configure value. 
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 5, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
                Assert.Equal(parameters3.DiffBackupIntervalInHours, policy3.DiffBackupIntervalInHours);

                // Success Scenario 2: Attempt to set retention period to 7 days (valid); Attemp to set the differential backup interval to null (valid);
                // Verify the operation success. So policy value equals to the configure value.So policy value equals to the configure value.
                BackupShortTermRetentionPolicy parameters4 = new BackupShortTermRetentionPolicy(retentionDays: 7, diffBackupIntervalInHours: null);
                BackupShortTermRetentionPolicy originalPolicy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters4);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy4 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters4.RetentionDays, policy4.RetentionDays);
                Assert.Equal(originalPolicy.DiffBackupIntervalInHours, policy4.DiffBackupIntervalInHours);
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

                // Test GET operation can get default retention days
                BackupShortTermRetentionPolicy policyDefault = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policyDefault.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policyDefault.DiffBackupIntervalInHours);

                // Failure Scenario 1: Attempt to set retention period to 40 days (invalid); Attemp to set the differential backup interval to 12 hours (valid);
                // Verify the operation fails on updating the policy. So policy value equals to default value.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 40, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy1 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy1.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy1.DiffBackupIntervalInHours);

                // Failure Scenario 2: Attempt to set retention period to 35 days (valid); Attemp to set the differential backup interval to 6 hours (invalid);
                // Verify the operation fails on updating the policy.So policy value equals to default value.
                BackupShortTermRetentionPolicy parameters2 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy2 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy2.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy2.DiffBackupIntervalInHours);

                // Success Scenario 1: Attempt to set retention period to 35 days (valid); Attemp to set the differential backup interval to 24 (valid);
                // Verify the operation success. So policy value equals to the configure value. 
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
                Assert.Equal(parameters3.DiffBackupIntervalInHours, policy3.DiffBackupIntervalInHours);

                // Success Scenario 2: Attempt to set retention period to 34 days (valid); Attemp to set the differential backup interval to null (valid);
                // Verify the operation success. So policy value equals to the configure value.So policy value equals to the configure value.
                BackupShortTermRetentionPolicy parameters4 = new BackupShortTermRetentionPolicy(retentionDays: 34, diffBackupIntervalInHours: null);
                BackupShortTermRetentionPolicy originalPolicy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters4);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy4 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters4.RetentionDays, policy4.RetentionDays);
                Assert.Equal(originalPolicy.DiffBackupIntervalInHours, policy4.DiffBackupIntervalInHours);
            }
        }

        [Fact]
        public void TestShortTermRetentionPolicyOnGeneralPurpose()
        {
            // Currently the tier 'GeneralPurpose' does not support the sku 'SQLDB_GP_Gen5'. 
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

                // Failure Scenario 1: Attempt to set retention period to 40 days (invalid); Attemp to set the differential backup interval to 12 hours (valid);
                // Verify the operation fails on updating the policy. So policy value equals to default value.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 40, diffBackupIntervalInHours: 12);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy1 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy1.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy1.DiffBackupIntervalInHours);

                // Failure Scenario 2: Attempt to set retention period to 35 days (valid); Attemp to set the differential backup interval to 6 hours (invalid);
                // Verify the operation fails on updating the policy.So policy value equals to default value.
                BackupShortTermRetentionPolicy parameters2 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters2);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy2 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy2.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, policy2.DiffBackupIntervalInHours);

                // Success Scenario 1: Attempt to set retention period to 35 days (valid); Attemp to set the differential backup interval to 24 (valid);
                // Verify the operation success. So policy value equals to the configure value. 
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 35, diffBackupIntervalInHours: 24);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
                Assert.Equal(parameters3.DiffBackupIntervalInHours, policy3.DiffBackupIntervalInHours);

                // Success Scenario 2: Attempt to set retention period to 34 days (valid); Attemp to set the differential backup interval to null (valid);
                // Verify the operation success. So policy value equals to the configure value.So policy value equals to the configure value.
                BackupShortTermRetentionPolicy parameters4 = new BackupShortTermRetentionPolicy(retentionDays: 34, diffBackupIntervalInHours: null);
                BackupShortTermRetentionPolicy originalPolicy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters4);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy4 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters4.RetentionDays, policy4.RetentionDays);
                Assert.Equal(originalPolicy.DiffBackupIntervalInHours, policy4.DiffBackupIntervalInHours);
            }
        }

        // Test when Feature Configurable Differential Backup (CDB) is ON.
        [Fact]
        public async void TestShortTermRetentionPolicyOnGeneralPurposeScriptUse()
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

                // Senario 1: Test Update operation through GET operation without provide DiffBackupIntervalInHours.
                var strPolicy1 = await sqlClient.BackupShortTermRetentionPolicies.GetAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString());
                strPolicy1.RetentionDays = 28;
                await sqlClient.BackupShortTermRetentionPolicies.BeginCreateOrUpdateAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString(), strPolicy1);
                Assert.Equal(28, strPolicy1.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, strPolicy1.DiffBackupIntervalInHours);

                // Scenario 2: Test Update operation through GET operation without provide RetentionDays.
                strPolicy1.DiffBackupIntervalInHours = 24;
                await sqlClient.BackupShortTermRetentionPolicies.BeginCreateOrUpdateAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString(), strPolicy1);
                Assert.Equal(28, strPolicy1.RetentionDays);
                Assert.Equal(24, strPolicy1.DiffBackupIntervalInHours);

                // Scenario 3: Test Update operation through GET operation.
                var strPolicy3 = await sqlClient.BackupShortTermRetentionPolicies.GetAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString());
                Assert.Equal(defaultRetentionDays, strPolicy3.RetentionDays);
                Assert.Equal(defaultDiffBackupIntervalHours, strPolicy3.DiffBackupIntervalInHours);
                strPolicy3.RetentionDays = 15;
                strPolicy3.DiffBackupIntervalInHours = 12;
                await sqlClient.BackupShortTermRetentionPolicies.BeginCreateOrUpdateAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString(), strPolicy3);
                Assert.Equal(15, strPolicy3.RetentionDays);
                Assert.Equal(12, strPolicy3.DiffBackupIntervalInHours);
            }
        }

        // Test when Feature Configurable Differential Backup (CDB) is OFF.
        [Fact]
        public async void TestShortTermRetentionPolicyScriptUseWhenFeatureIsDisabled()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for GeneralPurpose DB is 1 to 35 days. 
                int defaultRetentionDays = 7;

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

                // Senario 1: Test Update operation through GET operation when feature CDB is OFF.
                var strPolicy1 = await sqlClient.BackupShortTermRetentionPolicies.GetAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString());
                Assert.Equal(defaultRetentionDays, strPolicy1.RetentionDays);
                strPolicy1.RetentionDays = 28;
                await sqlClient.BackupShortTermRetentionPolicies.BeginCreateOrUpdateAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString(), strPolicy1);
                Assert.Equal(28, strPolicy1.RetentionDays);
            }
        }
    }
}