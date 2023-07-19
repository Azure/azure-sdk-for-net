// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a server blob auditing policy
    /// </summary>
    public class BlobAuditingTest
    {
        [Fact]
        public void TestBlobAuditing()
        {
            string testPrefix = "server-blob-auditing-test-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // create some databases in server
                Database[] databases = SqlManagementTestUtilities.CreateDatabasesAsync(
                    sqlClient, resourceGroup.Name, server, testPrefix, 2).Result;

                IList<string> auditActionsAndGroups = new List<string> { "SCHEMA_OBJECT_ACCESS_GROUP", "UPDATE on database::testdb by public" };

#if false // Commented out due to issues with async operation response

                // ******* Server blob auditing *******                    
                ServerBlobAuditingPolicy defaultServerPolicyResponse = sqlClient.Servers.GetBlobAuditingProperties(resourceGroup.Name, server.Name);

                // Verify that the initial Get request contains the default policy.
                VerifyServerAuditingPolicyInformation(GetDefaultServerBlobAuditingProperties(), defaultServerPolicyResponse);

                // Modify the policy properties, send and receive and see it its still ok
                IList<string> auditActionsAndGroups = new List<string> { "SCHEMA_OBJECT_ACCESS_GROUP", "UPDATE on database::testdb by public" };
                ServerBlobAuditingPolicy updatedServerPolicy = new ServerBlobAuditingPolicy
                {
                    State = BlobAuditingPolicyState.Disabled,
                    RetentionDays = 8,
                    StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                    StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                    AuditActionsAndGroups = auditActionsAndGroups,
                    StorageAccountSubscriptionId = "00000000-1234-0000-5678-000000000000",
                    IsStorageSecondaryKeyInUse = false
                };

                //Set blob auditing policy for server
                sqlClient.Servers.CreateOrUpdateBlobAuditingProperties(resourceGroup.Name, server.Name, updatedServerPolicy);

                //Get blob auditing server policy
                var getUpdatedServerPolicyResponse = sqlClient.Servers.GetBlobAuditingProperties(resourceGroup.Name, server.Name);

                // Verify that the Get request contains the updated policy.
                VerifyServerAuditingPolicyInformation(updatedServerPolicy, getUpdatedServerPolicyResponse);
#endif

                // ******* Database blob auditing *******

                string dbName = databases[0].Name;
                DatabaseBlobAuditingPolicy defaultDatabasePolicyResponse = sqlClient.DatabaseBlobAuditingPolicies.Get(resourceGroup.Name, server.Name, dbName);

                // Verify that the initial Get request contains the default policy.
                VerifyDatabaseAuditingPolicyInformation(GetDefaultDatabaseBlobAuditingProperties(), defaultDatabasePolicyResponse);

                // Modify the policy properties, send and receive and see it its still ok
                DatabaseBlobAuditingPolicy updatedDatabasePolicy = new DatabaseBlobAuditingPolicy
                {
                    State = BlobAuditingPolicyState.Disabled,
                    RetentionDays = 5,
                    StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                    StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                    AuditActionsAndGroups = auditActionsAndGroups,
                    StorageAccountSubscriptionId = new Guid("00000000-1234-0000-5678-000000000000"),
                    IsStorageSecondaryKeyInUse = false
                };
                sqlClient.DatabaseBlobAuditingPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, updatedDatabasePolicy);

                var getUpdatedDatabasePolicyResponse = sqlClient.DatabaseBlobAuditingPolicies.Get(resourceGroup.Name, server.Name, dbName);
                // Verify that the Get request contains the updated policy.
                VerifyDatabaseAuditingPolicyInformation(updatedDatabasePolicy, getUpdatedDatabasePolicyResponse);
            }
        }

#if false // Commented out due to issues with async operation response

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyServerAuditingPolicyInformation(ServerBlobAuditingPolicy expected, ServerBlobAuditingPolicy actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
            Assert.Equal(expected.StorageEndpoint, actual.StorageEndpoint);
            Assert.Equal(string.Empty, actual.StorageAccountAccessKey);
            if (expected.AuditActionsAndGroups == null)
            {
                Assert.Equal(null, actual.AuditActionsAndGroups);
            }
            else
            {
                Assert.Equal(expected.AuditActionsAndGroups.Count, actual.AuditActionsAndGroups.Count);
                actual.AuditActionsAndGroups.ForEach(s => Assert.True(expected.AuditActionsAndGroups.Any(es => es.Equals(s))));
            }
            Assert.Equal(expected.StorageAccountSubscriptionId, actual.StorageAccountSubscriptionId);
            Assert.Equal(expected.IsStorageSecondaryKeyInUse, actual.IsStorageSecondaryKeyInUse);
        }

        /// <summary>
        /// Returns a ServerBlobAuditingPolicy object that holds the default settings for a server blob auditing policy
        /// </summary>
        /// <returns>A ServerBlobAuditingPolicy object with the default server audit policy settings</returns>
        private ServerBlobAuditingPolicy GetDefaultServerBlobAuditingProperties()
        {
            ServerBlobAuditingPolicy properties = new ServerBlobAuditingPolicy
            {
                State = BlobAuditingPolicyState.Disabled,
                RetentionDays = 0,
                StorageAccountAccessKey = string.Empty,
                StorageEndpoint = string.Empty,
                AuditActionsAndGroups = new List<string>(),
                StorageAccountSubscriptionId = "00000000-0000-0000-0000-000000000000",
                IsStorageSecondaryKeyInUse = false,
            };

            return properties;
        }

#endif

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyDatabaseAuditingPolicyInformation(DatabaseBlobAuditingPolicy expected, DatabaseBlobAuditingPolicy actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
            Assert.Equal(expected.StorageEndpoint, actual.StorageEndpoint);
            Assert.Equal(string.Empty, actual.StorageAccountAccessKey);
            if (expected.AuditActionsAndGroups == null || actual.AuditActionsAndGroups == null)
            {
                Assert.Null(expected.AuditActionsAndGroups);
                Assert.Null(actual.AuditActionsAndGroups);
            }
            else
            {
                Assert.Equal(expected.AuditActionsAndGroups.Count, actual.AuditActionsAndGroups.Count);
                actual.AuditActionsAndGroups.ForEach(s => Assert.True(expected.AuditActionsAndGroups.Any(es => es.Equals(s))));
            }
            Assert.Equal(expected.StorageAccountSubscriptionId, actual.StorageAccountSubscriptionId);
            Assert.Equal(expected.IsStorageSecondaryKeyInUse, actual.IsStorageSecondaryKeyInUse);
        }

        /// <summary>
        /// Returns a BlobAuditingProperties object that holds the default settings for a database blob auditing policy
        /// </summary>
        /// <returns>A BlobAuditingProperties object with the default database audit policy settings</returns>
        private DatabaseBlobAuditingPolicy GetDefaultDatabaseBlobAuditingProperties()
        {
            DatabaseBlobAuditingPolicy properties = new DatabaseBlobAuditingPolicy
            {
                State = BlobAuditingPolicyState.Disabled,
                RetentionDays = 0,
                StorageAccountAccessKey = string.Empty,
                StorageEndpoint = null,
                AuditActionsAndGroups = null,
                StorageAccountSubscriptionId = new Guid("00000000-0000-0000-0000-000000000000"),
                IsStorageSecondaryKeyInUse = false,
            };

            return properties;
        }
    }
}
