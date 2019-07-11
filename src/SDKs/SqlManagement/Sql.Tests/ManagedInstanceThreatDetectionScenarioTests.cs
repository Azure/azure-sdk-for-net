// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a sanaged instance and managed database security alert policy
    /// </summary>
    public class ManagedInstanceThreatDetectionScenarioTests : IClassFixture<ManagedInstanceThreatDetectionTestFixture>
    {
        private readonly ManagedInstanceThreatDetectionTestFixture m_testFixture;

        public ManagedInstanceThreatDetectionScenarioTests(ManagedInstanceThreatDetectionTestFixture testFixture)
        {
            m_testFixture = testFixture;
        }

        [Fact]
        public void TestManagedInstanceThreatDetection()
        {
            ResourceGroup resourceGroup = m_testFixture.ResourceGroup;
            ManagedInstance managedInstance = m_testFixture.ManagedInstance;
            SqlManagementClient sqlClient = m_testFixture.Context.GetClient<SqlManagementClient>();

            // create some databases in server
            var db1 = sqlClient.ManagedDatabases.CreateOrUpdate(m_testFixture.ResourceGroup.Name, m_testFixture.ManagedInstance.Name, "mi-security-alert-test-1", new ManagedDatabase()
            {
                Location = m_testFixture.ManagedInstance.Location,
            });
            Assert.NotNull(db1);
            var db2 = sqlClient.ManagedDatabases.CreateOrUpdate(m_testFixture.ResourceGroup.Name, m_testFixture.ManagedInstance.Name, "mi-security-alert-test-2", new ManagedDatabase()
            {
                Location = m_testFixture.ManagedInstance.Location,
            });
            Assert.NotNull(db2);

            ManagedDatabase[] databases = {db1, db2};

            // ******* Server threat detection *******
            ManagedServerSecurityAlertPolicy defaultManagedInstancePolicyResponse = sqlClient.ManagedServerSecurityAlertPolicies.Get(resourceGroup.Name, managedInstance.Name);

            // Verify that the initial Get request contains the default policy.
            VerifyManagedInstanceSecurityAlertPolicyInformation(GetDefaultManagedInstanceSecurityAlertProperties(), defaultManagedInstancePolicyResponse);

            // Modify the policy properties, send and receive and see it its still ok
            ManagedServerSecurityAlertPolicy updatedManagedServerPolicy = new ManagedServerSecurityAlertPolicy
            {
                State = SecurityAlertPolicyState.Enabled,
                EmailAccountAdmins = true
            };

            //Set security alert policy for server
            sqlClient.ManagedServerSecurityAlertPolicies.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, updatedManagedServerPolicy);

            //Get security alert server policy
            var getUpdatedManagedServerPolicyResponse = sqlClient.ManagedServerSecurityAlertPolicies.Get(resourceGroup.Name, managedInstance.Name);

            // Verify that the Get request contains the updated policy.
            Assert.Equal(updatedManagedServerPolicy.State, getUpdatedManagedServerPolicyResponse.State);
            Assert.Equal(updatedManagedServerPolicy.EmailAccountAdmins, getUpdatedManagedServerPolicyResponse.EmailAccountAdmins);

            // Modify the policy properties again, send and receive and see it its still ok
            updatedManagedServerPolicy = new ManagedServerSecurityAlertPolicy
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
            sqlClient.ManagedServerSecurityAlertPolicies.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, updatedManagedServerPolicy);

            //Get security alert server policy
            getUpdatedManagedServerPolicyResponse = sqlClient.ManagedServerSecurityAlertPolicies.Get(resourceGroup.Name, managedInstance.Name);

            // Verify that the Get request contains the updated policy.
            VerifyManagedInstanceSecurityAlertPolicyInformation(updatedManagedServerPolicy, getUpdatedManagedServerPolicyResponse);


            // ******* Database threat detection *******

            string dbName = databases[0].Name;
            ManagedDatabaseSecurityAlertPolicy defaultManagedDatabasePolicyResponse = sqlClient.ManagedDatabaseSecurityAlertPolicies.Get(resourceGroup.Name, managedInstance.Name, dbName);

            // Verify that the initial Get request contains the default policy.
            VerifyManagedDatabaseSecurityAlertPolicyInformation(GetDefaultManagedDatabaseSecurityAlertProperties(), defaultManagedDatabasePolicyResponse);

            // Modify the policy properties, send and receive and see it its still ok
            ManagedDatabaseSecurityAlertPolicy updatedManagedDatabasePolicy = new ManagedDatabaseSecurityAlertPolicy
            {
                State = SecurityAlertPolicyState.Disabled,
                EmailAccountAdmins = true,
                EmailAddresses = new List<string>() { "testSecurityAlert@microsoft.com" },
                DisabledAlerts = new List<string>() { "Access_Anomaly", "Usage_Anomaly" },
                RetentionDays = 5,
                StorageAccountAccessKey = "fake_key_sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                StorageEndpoint = "https://MyAccount.blob.core.windows.net/"
            };
            sqlClient.ManagedDatabaseSecurityAlertPolicies.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, dbName, updatedManagedDatabasePolicy);

            var getUpdatedManagedDatabasePolicyResponse = sqlClient.ManagedDatabaseSecurityAlertPolicies.Get(resourceGroup.Name, managedInstance.Name, dbName);

            // Verify that the Get request contains the updated policy.
            VerifyManagedDatabaseSecurityAlertPolicyInformation(updatedManagedDatabasePolicy, getUpdatedManagedDatabasePolicyResponse);
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyManagedInstanceSecurityAlertPolicyInformation(ManagedServerSecurityAlertPolicy expected, ManagedServerSecurityAlertPolicy actual)
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
        /// Returns a ManagedServerSecurityAlertPolicy object that holds the default settings for a managed instance security alert policy
        /// </summary>
        /// <returns>A ManagedServerSecurityAlertPolicy object with the default managed instance security alert policy settings</returns>
        private ManagedServerSecurityAlertPolicy GetDefaultManagedInstanceSecurityAlertProperties()
        {
            ManagedServerSecurityAlertPolicy properties = new ManagedServerSecurityAlertPolicy
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
        private void VerifyManagedDatabaseSecurityAlertPolicyInformation(ManagedDatabaseSecurityAlertPolicy expected, ManagedDatabaseSecurityAlertPolicy actual)
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
        /// Returns a ManagedDatabaseSecurityAlertPolicy object that holds the default settings for a managed database security alert policy
        /// </summary>
        /// <returns>A ManagedDatabaseSecurityAlertPolicy object with the default managed database security alert policy settings</returns>
        private ManagedDatabaseSecurityAlertPolicy GetDefaultManagedDatabaseSecurityAlertProperties()
        {
            ManagedDatabaseSecurityAlertPolicy properties = new ManagedDatabaseSecurityAlertPolicy
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
    }
}
