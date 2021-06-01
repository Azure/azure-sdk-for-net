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
        [Fact]
        public void TestShortTermRetentionPolicyOnBasic()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for Basic DB is 1 to 7 days. 
                int defaultRetentionDays = 7;

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

                // Attempt to set retention period to 8 days (invalid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 8);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy1 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy1.RetentionDays);

                // Attempt to set retention period to 6 days (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 6);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
            }
        }

        [Fact]
        public void TestShortTermRetentionPolicyOnPremium()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Valid Retention Days for Basic DB is 1 to 35 days. 
                int defaultRetentionDays = 7;

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

                // Attempt to set retention period to 36 days (invalid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 36);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);

                // Increase retention period to 35 days (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 35);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
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

                // Attempt to set retention period to 36 days (invalid); Verify the operation fails on updating the policy.
                BackupShortTermRetentionPolicy parameters1 = new BackupShortTermRetentionPolicy(retentionDays: 36);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters1);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(defaultRetentionDays, policy.RetentionDays);

                // Increase retention period to 35 days (valid); Verify the operation success.
                BackupShortTermRetentionPolicy parameters3 = new BackupShortTermRetentionPolicy(retentionDays: 35);
                sqlClient.BackupShortTermRetentionPolicies.CreateOrUpdateWithHttpMessagesAsync(resourceGroup.Name, server.Name, database.Name, parameters3);
                Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(3));
                BackupShortTermRetentionPolicy policy3 = sqlClient.BackupShortTermRetentionPolicies.Get(resourceGroup.Name, server.Name, database.Name);
                Assert.Equal(parameters3.RetentionDays, policy3.RetentionDays);
            }
        }

        [Fact]
        public async void TestShortTermRetentionPolicyOnGeneralPurposeScriptUse()
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

                // Test Update operation through GET operation.
                var strPolicy = await sqlClient.BackupShortTermRetentionPolicies.GetAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString());
                strPolicy.RetentionDays = 28;        
                await sqlClient.BackupShortTermRetentionPolicies.BeginCreateOrUpdateAsync(resourceGroup.Name.ToString(), server.Name.ToString(), database.Name.ToString(), strPolicy);
                Assert.Equal(28, strPolicy.RetentionDays);
            }
        }
    }
}