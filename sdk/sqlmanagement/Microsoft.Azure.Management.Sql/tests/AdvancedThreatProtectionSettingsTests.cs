// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of server and database Advanced Threat Protection settings
    /// </summary>
    public class AdvancedThreatProtectionTests
    {
        [Fact]
        public void TestThreatProtectionOnServerAndDatabase()
        {
            string testPrefix = "server-threat-protection-test-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create some databases in the server.
                Database[] databases = SqlManagementTestUtilities.CreateDatabasesAsync(
                        sqlClient, resourceGroup.Name, server, testPrefix, 2).Result;

                // Server Advanced Threat Protection settings
                ServerAdvancedThreatProtection defaultServerSettingsResponse = sqlClient.ServerAdvancedThreatProtectionSettings.Get(resourceGroup.Name, server.Name);

                // Verify that the initial Get request contains the default settings.
                Assert.Equal(AdvancedThreatProtectionState.Disabled, defaultServerSettingsResponse.State);

                // Modify the settings. Then send, receive and see if its still ok.
                ServerAdvancedThreatProtection updatedServerSettings = new ServerAdvancedThreatProtection
                {
                    State = AdvancedThreatProtectionState.Enabled
                };

                // Set Advanced Threat Protection settings for server.
                sqlClient.ServerAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroup.Name, server.Name, updatedServerSettings);

                // Get Advanced Threat Protection settings from the server.
                var getUpdatedServerSettingsResponse = sqlClient.ServerAdvancedThreatProtectionSettings.Get(resourceGroup.Name, server.Name);

                // Verify that the Get request contains the updated settings.
                Assert.Equal(updatedServerSettings.State, getUpdatedServerSettingsResponse.State);

                // Modify the settings again. Then send, receive and see if its still ok.
                updatedServerSettings = new ServerAdvancedThreatProtection
                {
                    State = AdvancedThreatProtectionState.Disabled
                };

                // Set Advanced Threat Protection settings for server.
                sqlClient.ServerAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroup.Name, server.Name, updatedServerSettings);

                // Get Advanced Threat Protection settings from the server.
                getUpdatedServerSettingsResponse = sqlClient.ServerAdvancedThreatProtectionSettings.Get(resourceGroup.Name, server.Name);

                // Verify that the Get request contains the updated settings.
                Assert.Equal(updatedServerSettings.State, getUpdatedServerSettingsResponse.State);

                // Database Advanced Threat Protection settings.
                string dbName = databases[0].Name;
                DatabaseAdvancedThreatProtection defaultDatabaseSettingsResponse = sqlClient.DatabaseAdvancedThreatProtectionSettings.Get(resourceGroup.Name, server.Name, dbName);

                // Verify that the initial Get request contains the default settings.
                Assert.Equal(AdvancedThreatProtectionState.Disabled, defaultDatabaseSettingsResponse.State);

                // Modify the policy properties. Then send, receive and see if its still ok.
                DatabaseAdvancedThreatProtection updatedDatabaseSettings = new DatabaseAdvancedThreatProtection
                {
                    State = AdvancedThreatProtectionState.Disabled
                };

                sqlClient.DatabaseAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updatedDatabaseSettings);

                var getUpdatedDatabaseSettingsResponse = sqlClient.DatabaseAdvancedThreatProtectionSettings.Get(resourceGroup.Name, server.Name, dbName);

                // Verify that the Get request contains the updated settings.
                Assert.Equal(updatedDatabaseSettings.State, getUpdatedDatabaseSettingsResponse.State);
            }
        }

        [Fact]
        public void TestThreatProtectionOnManagedInstance()
        {
            string testPrefix = "mi-threat-protection-test-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                ManagedInstance managedInstance = context.CreateManagedInstance(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create some small databases in the Managed Instance
                ManagedDatabase[] databases = SqlManagementTestUtilities.CreateManagedDatabasesAsync(
                    sqlClient, resourceGroup.Name, managedInstance, testPrefix, 2).Result;

                // ManagedInstance Advanced Threat Protection settings
                ManagedInstanceAdvancedThreatProtection defaultInstanceSettingsResponse = sqlClient.ManagedInstanceAdvancedThreatProtectionSettings.Get(resourceGroup.Name, managedInstance.Name);

                // Verify that the initial Get request contains the default settings.
                Assert.Equal(AdvancedThreatProtectionState.Disabled, defaultInstanceSettingsResponse.State);

                // Modify the settings. Then send, receive and see if its still ok.
                ManagedInstanceAdvancedThreatProtection updatedInstanceSettings = new ManagedInstanceAdvancedThreatProtection
                {
                    State = AdvancedThreatProtectionState.Enabled
                };

                // Set Advanced Threat Protection settings for server.
                sqlClient.ManagedInstanceAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, updatedInstanceSettings);

                // Get Advanced Threat Protection settings from the managed instance.
                var getUpdatedInstanceSettingsResponse = sqlClient.ManagedInstanceAdvancedThreatProtectionSettings.Get(resourceGroup.Name, managedInstance.Name);

                // Verify that the Get request contains the updated settings.
                Assert.Equal(updatedInstanceSettings.State, getUpdatedInstanceSettingsResponse.State);

                // Modify the settings again. Then send, receive and see if its still ok.
                updatedInstanceSettings = new ManagedInstanceAdvancedThreatProtection
                {
                    State = AdvancedThreatProtectionState.Disabled
                };

                // Set Advanced Threat Protection settings for managed instance.
                sqlClient.ManagedInstanceAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, updatedInstanceSettings);

                // Get Advanced Threat Protection settings from the managed instance.
                getUpdatedInstanceSettingsResponse = sqlClient.ManagedInstanceAdvancedThreatProtectionSettings.Get(resourceGroup.Name, managedInstance.Name);

                // Verify that the Get request contains the updated settings.
                Assert.Equal(updatedInstanceSettings.State, getUpdatedInstanceSettingsResponse.State);

                // ManagedDatabase Advanced Threat Protection settings.
                string dbName = databases[0].Name;
                ManagedDatabaseAdvancedThreatProtection defaultDatabaseSettingsResponse = sqlClient.ManagedDatabaseAdvancedThreatProtectionSettings.Get(resourceGroup.Name, managedInstance.Name, dbName);

                // Verify that the initial Get request contains the default settings.
                Assert.Equal(AdvancedThreatProtectionState.Disabled, defaultDatabaseSettingsResponse.State);

                // Modify the policy properties. Then send, receive and see if its still ok.
                ManagedDatabaseAdvancedThreatProtection updatedDatabaseSettings = new ManagedDatabaseAdvancedThreatProtection
                {
                    State = AdvancedThreatProtectionState.Disabled
                };

                sqlClient.ManagedDatabaseAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, dbName, updatedDatabaseSettings);

                var getUpdatedDatabaseSettingsResponse = sqlClient.ManagedDatabaseAdvancedThreatProtectionSettings.Get(resourceGroup.Name, managedInstance.Name, dbName);

                // Verify that the Get request contains the updated settings.
                Assert.Equal(updatedDatabaseSettings.State, getUpdatedDatabaseSettingsResponse.State);
            }
        }
    }
}
