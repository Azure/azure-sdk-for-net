using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Database auditing policy
    /// </summary>
    public class DatabaseBlobAuditingTest
    {
        [Fact]
        public void TestDatabaseBlobAuditingApis()
        {
            string testPrefix = "database-blob-auditing-test-";
            string testName = this.GetType().FullName;

            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestDatabaseBlobAuditing", testPrefix,
                (resClient, sqlClient, resourceGroup, server) =>
                {
                    // Create database
                    string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                    Database db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                    {
                        Location = server.Location,
                    });

                    DatabaseBlobAuditingPolicyResource defaultDatabasePolicyResponse = sqlClient.DatabaseBlobAuditingPolicies.Get(resourceGroup.Name, server.Name, dbName, SecurityConstants.c_DefaultPolicyName);
                    
                    // Verify that the initial Get request contains the default policy.
                    VerifyAuditingPolicyInformation(GetDefaultBlobAuditgProperties(), defaultDatabasePolicyResponse.Properties);

                    // Modify the policy properties, send and receive and see it its still ok
                    IList<string> auditActionsAndGroups = new List<string> { "SCHEMA_OBJECT_ACCESS_GROUP", "UPDATE on database::testdb by public" };
                    DatabaseBlobAuditingPolicyResource updatedDatabasePolicy = new DatabaseBlobAuditingPolicyResource
                    {
                        Properties = new DatabaseBlobAuditingPolicyResourceProperties
                        {
                            State = SecurityConstants.c_DisabledValue,
                            RetentionDays = 5,
                            StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                            StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                            AuditActionsAndGroups = auditActionsAndGroups,
                            StorageAccountSubscriptionId = "00000000-1234-0000-5678-000000000000",
                            IsStorageSecondaryKeyInUse = false
                        }
                    };
                    sqlClient.DatabaseBlobAuditingPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, SecurityConstants.c_DefaultPolicyName, updatedDatabasePolicy);

                    var getUpdatedPolicyResponse = sqlClient.DatabaseBlobAuditingPolicies.Get(resourceGroup.Name, server.Name, dbName, SecurityConstants.c_DefaultPolicyName); 
                    // Verify that the Get request contains the updated policy.
                    VerifyAuditingPolicyInformation(updatedDatabasePolicy.Properties, getUpdatedPolicyResponse.Properties);
                });

        }


        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyAuditingPolicyInformation(DatabaseBlobAuditingPolicyResourceProperties expected, DatabaseBlobAuditingPolicyResourceProperties actual)
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
        /// Returns a BlobAuditingProperties object that holds the default settings for a database blob auditing policy
        /// </summary>
        /// <returns>A BlobAuditingProperties object with the default database audit policy settings</returns>
        private DatabaseBlobAuditingPolicyResourceProperties GetDefaultBlobAuditgProperties()
        {
            DatabaseBlobAuditingPolicyResourceProperties properties = new DatabaseBlobAuditingPolicyResourceProperties
            {
                State = SecurityConstants.c_DisabledValue,
                RetentionDays = 0,
                StorageAccountAccessKey = string.Empty,
                StorageEndpoint = string.Empty,
                AuditActionsAndGroups = new List<string>(),
                StorageAccountSubscriptionId = "00000000-0000-0000-0000-000000000000",
                IsStorageSecondaryKeyInUse = false,
            };

            return properties;
        }
    }
}