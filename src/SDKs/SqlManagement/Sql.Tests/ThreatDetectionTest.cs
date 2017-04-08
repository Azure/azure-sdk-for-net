// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Server security alert policy
    /// </summary>
    public class ThreatDetectionTest
    {
        [Fact]
        public void TestThreatDetectionApis()
        {
            string testPrefix = "server-security-alert-test-";
            string testName = this.GetType().FullName;

            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestThreatDetection", testPrefix,
                 (resClient, sqlClient, resourceGroup, server) =>
                 {
                     // create some databases in server
                     Database[] databases = SqlManagementTestUtilities.CreateDatabasesAsync(
                        sqlClient, resourceGroup.Name, server, testPrefix, 2).Result;

#if false // Commented out due to issues with async operation response

                     // ******* Server threat detection *******
                     ServerSecurityAlertPolicy defaultServerPolicyResponse = sqlClient.Servers.GetThreatDetectionPolicy(resourceGroup.Name, server.Name);

                     // Verify that the initial Get request contains the default policy.
                     VerifyServerSecurityAlertPolicyInformation(GetDefaultServerSecurityAlertProperties(), defaultServerPolicyResponse);

                     // Modify the policy properties, send and receive and see it its still ok
                     ServerSecurityAlertPolicy updatedServerPolicy = new ServerSecurityAlertPolicy
                     {
                         State = SecurityAlertPolicyState.Enabled,
                         EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled,
                         EmailAddresses = "testSecurityAlert@microsoft.com;testServerPolicy@microsoft.com",
                         DisabledAlerts = "Sql_Injection",
                         RetentionDays = 3,
                         StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                         StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                     };

                     //Set security alert policy for server
                     sqlClient.Servers.CreateOrUpdateThreatDetectionPolicy(resourceGroup.Name, server.Name, updatedServerPolicy);

                     //Get security alert server policy
                     var getUpdatedServerPolicyResponse = sqlClient.Servers.GetThreatDetectionPolicy(resourceGroup.Name, server.Name);
                     // Verify that the Get request contains the updated policy.
                     VerifyServerSecurityAlertPolicyInformation(updatedServerPolicy, getUpdatedServerPolicyResponse);

#endif

                     // ******* Database threat detection *******

                     string dbName = databases[0].Name;
                     DatabaseSecurityAlertPolicy defaultDatabasePolicyResponse = sqlClient.Databases.GetThreatDetectionPolicy(resourceGroup.Name, server.Name, dbName);

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
                         StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                         StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                         UseServerDefault = SecurityAlertPolicyUseServerDefault.Disabled,
                     };
                     sqlClient.Databases.CreateOrUpdateThreatDetectionPolicy(resourceGroup.Name, server.Name, dbName, updatedDatabasePolicy);

                     var getUpdatedDatabasePolicyResponse = sqlClient.Databases.GetThreatDetectionPolicy(resourceGroup.Name, server.Name, dbName);

                     // Verify that the Get request contains the updated policy.
                     VerifyDatabaseSecurityAlertPolicyInformation(updatedDatabasePolicy, getUpdatedDatabasePolicyResponse);
                 });
        }

#if false // Commented out due to issues with async operation response

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
                State = SecurityAlertPolicyState.New,
                EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled,
                DisabledAlerts = SecurityAlert.Preview,
                EmailAddresses = string.Empty,
                StorageEndpoint = string.Empty,
                StorageAccountAccessKey = string.Empty,
                RetentionDays = 0,
            };

            return properties;
        }

#endif

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
                State = SecurityAlertPolicyState.New,
                EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled,
                DisabledAlerts = "Preview",
                EmailAddresses = string.Empty,
                UseServerDefault = SecurityAlertPolicyUseServerDefault.Enabled,
                StorageEndpoint = string.Empty,
                StorageAccountAccessKey = string.Empty,
                RetentionDays = 0,
            };

            return properties;
        }
    }
}
