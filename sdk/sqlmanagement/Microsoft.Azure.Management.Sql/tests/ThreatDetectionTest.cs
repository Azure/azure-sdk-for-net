// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Server and database security alert policy
    /// </summary>
    public class ThreatDetectionTest
    {
        [Fact]
        public void TestThreatDetection()
        {
            string testPrefix = "server-security-alert-test-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // create some databases in server
                Database[] databases = SqlManagementTestUtilities.CreateDatabasesAsync(
                        sqlClient, resourceGroup.Name, server, testPrefix, 2).Result;

                // ******* Server threat detection *******
                ServerSecurityAlertPolicy defaultServerPolicyResponse = sqlClient.ServerSecurityAlertPolicies.Get(resourceGroup.Name, server.Name);

                // Verify that the initial Get request contains the default policy.
                VerifyServerSecurityAlertPolicyInformation(GetDefaultServerSecurityAlertProperties(), defaultServerPolicyResponse);

                // Modify the policy properties, send and receive and see it its still ok
                ServerSecurityAlertPolicy updatedServerPolicy = new ServerSecurityAlertPolicy
                {
                    State = SecurityAlertPolicyState.Enabled,
                    EmailAccountAdmins = true
                };

                //Set security alert policy for server
                sqlClient.ServerSecurityAlertPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, updatedServerPolicy);

                //Get security alert server policy
                var getUpdatedServerPolicyResponse = sqlClient.ServerSecurityAlertPolicies.Get(resourceGroup.Name, server.Name);

                // Verify that the Get request contains the updated policy.
                Assert.Equal(updatedServerPolicy.State, getUpdatedServerPolicyResponse.State);
                Assert.Equal(updatedServerPolicy.EmailAccountAdmins, getUpdatedServerPolicyResponse.EmailAccountAdmins);

                // Modify the policy properties again, send and receive and see it its still ok
                updatedServerPolicy = new ServerSecurityAlertPolicy
                {
                    State = SecurityAlertPolicyState.Disabled,
                    EmailAccountAdmins = true,
                    EmailAddresses = new List<string>() { "testSecurityAlert@microsoft.com", "testServerPolicy@microsoft.com" },
                    DisabledAlerts = new List<string>() { "Sql_Injection" },
                    RetentionDays = 3,
                    StorageAccountAccessKey = "fake_key_sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                    StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                };

                //Set security alert policy for server
                sqlClient.ServerSecurityAlertPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, updatedServerPolicy);

                //Get security alert server policy
                getUpdatedServerPolicyResponse = sqlClient.ServerSecurityAlertPolicies.Get(resourceGroup.Name, server.Name);

                // Verify that the Get request contains the updated policy.
                VerifyServerSecurityAlertPolicyInformation(updatedServerPolicy, getUpdatedServerPolicyResponse);


                // ******* Database threat detection *******

                string dbName = databases[0].Name;
                DatabaseSecurityAlertPolicy defaultDatabasePolicyResponse = sqlClient.DatabaseThreatDetectionPolicies.Get(resourceGroup.Name, server.Name, dbName);

                // Verify that the initial Get request contains the default policy.
                VerifyDatabaseSecurityAlertPolicyInformation(GetDefaultDatabaseSecurityAlertProperties(), defaultDatabasePolicyResponse);

                // Modify the policy properties, send and receive and see it its still ok
                DatabaseSecurityAlertPolicy updatedDatabasePolicy = new DatabaseSecurityAlertPolicy
                {
                    State = SecurityAlertPolicyState.Disabled,
                    EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled,
                    EmailAddresses = "testSecurityAlert@microsoft.com",
                    DisabledAlerts = "Access_Anomaly; Usage_Anomaly",
                    RetentionDays = 5,
                    StorageAccountAccessKey = "fake_key_sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                    StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                    UseServerDefault = SecurityAlertPolicyUseServerDefault.Disabled,
                };
                sqlClient.DatabaseThreatDetectionPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updatedDatabasePolicy);

                var getUpdatedDatabasePolicyResponse = sqlClient.DatabaseThreatDetectionPolicies.Get(resourceGroup.Name, server.Name, dbName);

                // Verify that the Get request contains the updated policy.
                VerifyDatabaseSecurityAlertPolicyInformation(updatedDatabasePolicy, getUpdatedDatabasePolicyResponse);
            }
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyServerSecurityAlertPolicyInformation(ServerSecurityAlertPolicy expected, ServerSecurityAlertPolicy actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.EmailAccountAdmins, actual.EmailAccountAdmins);
            Assert.Equal(expected.DisabledAlerts, actual.DisabledAlerts);
            Assert.Equal(expected.EmailAddresses, actual.EmailAddresses);
            Assert.Equal(expected.StorageEndpoint, actual.StorageEndpoint);
            Assert.Equal(string.Empty, actual.StorageAccountAccessKey);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
        }

        /// <summary>
        /// Returns a ServerSecurityAlertPolicy object that holds the default settings for a server security alert policy
        /// </summary>
        /// <returns>A ServerSecurityAlertPolicy object with the default server security alert policy settings</returns>
        private ServerSecurityAlertPolicy GetDefaultServerSecurityAlertProperties()
        {
            ServerSecurityAlertPolicy properties = new ServerSecurityAlertPolicy
            {
                State = SecurityAlertPolicyState.Disabled,
                EmailAccountAdmins = false,
                DisabledAlerts = new List<string>() { string.Empty },
                EmailAddresses = new List<string>() { string.Empty },
                StorageEndpoint = string.Empty,
                StorageAccountAccessKey = string.Empty,
                RetentionDays = 0,
            };

            return properties;
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyDatabaseSecurityAlertPolicyInformation(DatabaseSecurityAlertPolicy expected, DatabaseSecurityAlertPolicy actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.EmailAccountAdmins, actual.EmailAccountAdmins);
            Assert.Equal(expected.DisabledAlerts, actual.DisabledAlerts);
            Assert.Equal(expected.EmailAddresses, actual.EmailAddresses);
            Assert.Equal(expected.StorageEndpoint, actual.StorageEndpoint);
            Assert.Equal(string.Empty, actual.StorageAccountAccessKey);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
            Assert.Equal(expected.UseServerDefault, actual.UseServerDefault);
        }

        /// <summary>
        /// Returns a SecurityAlertProperties object that holds the default settings for a database security alert policy
        /// </summary>
        /// <returns>A DatabaseSecurityAlertPolicy object with the default database security alert policy settings</returns>
        private DatabaseSecurityAlertPolicy GetDefaultDatabaseSecurityAlertProperties()
        {
            DatabaseSecurityAlertPolicy properties = new DatabaseSecurityAlertPolicy
            {
                State = SecurityAlertPolicyState.Disabled,
                EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Disabled,
                DisabledAlerts = string.Empty,
                EmailAddresses = string.Empty,
                UseServerDefault = SecurityAlertPolicyUseServerDefault.Disabled,
                StorageEndpoint = string.Empty,
                StorageAccountAccessKey = string.Empty,
                RetentionDays = 0,
            };

            return properties;
        }
    }
}
