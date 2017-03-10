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

                    DatabaseSecurityAlertPolicy defaultDatabasePolicyResponse = sqlClient.DatabaseThreatDetectionPolicies.Get(resourceGroup.Name, server.Name, dbName);

                    // Verify that the initial Get request contains the default policy.
                    VerifyDatabaseSecurityAlertPolicyInformation(GetDefaultSecurityAlertProperties(), defaultDatabasePolicyResponse);

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
                        UseServerDefault = SecurityAlertPolicyUseServerDefault.Enabled,
                    };
                    sqlClient.DatabaseThreatDetectionPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updatedDatabasePolicy);

                    var getUpdatedPolicyResponse = sqlClient.DatabaseThreatDetectionPolicies.Get(resourceGroup.Name, server.Name, dbName);

                    // Verify that the Get request contains the updated policy.
                    VerifyDatabaseSecurityAlertPolicyInformation(updatedDatabasePolicy, getUpdatedPolicyResponse);
                });

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
        private DatabaseSecurityAlertPolicy GetDefaultSecurityAlertProperties()
        {
            DatabaseSecurityAlertPolicy properties = new DatabaseSecurityAlertPolicy
            {
                State = SecurityAlertPolicyState.New,
                EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled,
                DisabledAlerts = SecurityAlert.Preview,
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