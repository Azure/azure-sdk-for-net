using System;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Database security alert policy
    /// </summary>
    public class DatabaseSecurityAlertTest
    {
        [Fact]
        public void TestDatabaseSecurityAlertApis()
        {
            string testPrefix = "database-security-alert-test-";
            string testName = this.GetType().FullName;

            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestDatabaseSecurityAlert", testPrefix,
                (resClient, sqlClient, resourceGroup, server) =>
                {
                    // Create database
                    string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                    Database db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });

                    DatabaseSecurityAlertPolicyResource defaultDatabasePolicyResponse = sqlClient.DatabaseThreatDetectionPolicies.Get(resourceGroup.Name, server.Name, dbName, SecurityConstants.c_DefaultPolicyName);

                    // Verify that the initial Get request contains the default policy.
                    VerifyDatabaseSecurityAlertPolicyInformation(GetDefaultSecurityAlertProperties(), defaultDatabasePolicyResponse.Properties);

                    // Modify the policy properties, send and receive and see it its still ok
                    DatabaseSecurityAlertPolicyResource updatedDatabasePolicy = new DatabaseSecurityAlertPolicyResource
                    {
                        Properties = new DatabaseSecurityAlertPolicyProperties
                        {
                            State = SecurityConstants.c_DisabledValue,
                            EmailAccountAdmins = SecurityConstants.c_EnabledValue,
                            EmailAddresses = "testSecurityAlert@microsoft.com",
                            DisabledAlerts = "Access_Anomaly; Usage_Anomaly",
                            RetentionDays = 5,
                            StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                            StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                            UseServerDefault = SecurityConstants.c_DisabledValue,
                        }
                    };
                    sqlClient.DatabaseThreatDetectionPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, SecurityConstants.c_DefaultPolicyName, updatedDatabasePolicy);

                    var getUpdatedPolicyResponse = sqlClient.DatabaseThreatDetectionPolicies.Get(resourceGroup.Name, server.Name, dbName, SecurityConstants.c_DefaultPolicyName);

                    // Verify that the Get request contains the updated policy.
                    VerifyDatabaseSecurityAlertPolicyInformation(updatedDatabasePolicy.Properties, getUpdatedPolicyResponse.Properties);
                });

        }


        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyDatabaseSecurityAlertPolicyInformation(DatabaseSecurityAlertPolicyProperties expected, DatabaseSecurityAlertPolicyProperties actual)
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
        /// <returns>A DatabaseSecurityAlertPolicyProperties object with the default database security alert policy settings</returns>
        private DatabaseSecurityAlertPolicyProperties GetDefaultSecurityAlertProperties()
        {
            DatabaseSecurityAlertPolicyProperties properties = new DatabaseSecurityAlertPolicyProperties
            {
                State = SecurityConstants.c_NewValue,
                EmailAccountAdmins = SecurityConstants.c_EnabledValue,
                DisabledAlerts = SecurityConstants.c_DisabledAlertsDefault,
                EmailAddresses = string.Empty,
                UseServerDefault = SecurityConstants.c_EnabledValue,
                StorageEndpoint = string.Empty,
                StorageAccountAccessKey = string.Empty,
                RetentionDays = 0,
            };

            return properties;
        }
    }
}