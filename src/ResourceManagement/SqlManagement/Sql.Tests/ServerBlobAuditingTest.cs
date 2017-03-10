using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a server blob auditing policy
    /// </summary>
    public class ServerBlobAuditingTest
    {
        [Fact]
        public void TestServerBlobAuditingApis()
        {
            string testPrefix = "server-blob-auditing-test-";
            string testName = this.GetType().FullName;
            const int retriesCount = 5;
            const int databasesCount = 12;

            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestServerBlobAuditing", testPrefix,
                 (resClient, sqlClient, resourceGroup, server) =>
                {
                    //create server with a lot of databases
                    for (int i = 0; i < databasesCount; i++)
                    {
                        string dbName = string.Format("db{0}", i);
                        sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                        {
                            Location = server.Location,
                        });
                    }

                    ServerBlobAuditingPolicyResource defaultServerPolicyResponse = sqlClient.ServerBlobAuditingPolicies.Get(resourceGroup.Name, server.Name, SecurityConstants.c_DefaultPolicyName);

                    // Verify that the initial Get request contains the default policy.
                    VerifyAuditingPolicyInformation(GetDefaultBlobAuditgProperties(), defaultServerPolicyResponse.Properties);

                    // Modify the policy properties, send and receive and see it its still ok
                    IList<string> auditActionsAndGroups = new List<string> { "SCHEMA_OBJECT_ACCESS_GROUP", "UPDATE on database::testdb by public" };
                    ServerBlobAuditingPolicyResource updatedServerPolicy = new ServerBlobAuditingPolicyResource
                    {
                        Properties = new ServerBlobAuditingPolicyResourceProperties
                        {
                            State = SecurityConstants.c_DisabledValue,
                            RetentionDays = 8,
                            StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                            StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                            AuditActionsAndGroups = auditActionsAndGroups,
                            StorageAccountSubscriptionId = "00000000-1234-0000-5678-000000000000",
                            IsStorageSecondaryKeyInUse = false
                        }
                    };
                    
                    //Set blob auditing policy for server
                    sqlClient.ServerBlobAuditingPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, SecurityConstants.c_DefaultPolicyName, updatedServerPolicy);
                    //Waiting for the operation to start
                    Task.Delay(TimeSpan.FromSeconds(2));

                    BlobAuditingOperationListResult operationResults = sqlClient.ServerBlobAuditingOperationResultsList.Get(resourceGroup.Name, server.Name, SecurityConstants.c_DefaultPolicyName);
                    if (operationResults != null && operationResults.Value.Any())
                    {
                        //The set policy operation has not finished yet
                        BlobAuditingOperationResultResource operationStatusResponse = operationResults.Value.First();
                        string operationId = operationStatusResponse.Properties.OperationId;
                        for (int i = 0; i < retriesCount; i++)
                        {
                            operationStatusResponse = sqlClient.ServerBlobAuditingOperationResult.Get(
                                    resourceGroup.Name, server.Name, SecurityConstants.c_DefaultPolicyName, operationId);
                            if (operationStatusResponse != null && operationStatusResponse.Properties.State == SecurityConstants.c_SucceededOperationStatus)
                            {
                                break;
                            }
                            Task.Delay(TimeSpan.FromSeconds(5));
                        }
                    }

                    //Get blob auditing server policy
                    var getUpdatedPolicyResponse = sqlClient.ServerBlobAuditingPolicies.Get(resourceGroup.Name, server.Name, SecurityConstants.c_DefaultPolicyName);
                    // Verify that the Get request contains the updated policy.
                    VerifyAuditingPolicyInformation(updatedServerPolicy.Properties, getUpdatedPolicyResponse.Properties);
                });
        }


        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifyAuditingPolicyInformation(ServerBlobAuditingPolicyResourceProperties expected, ServerBlobAuditingPolicyResourceProperties actual)
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
        /// Returns a ServerBlobAuditingPolicyResourceProperties object that holds the default settings for a server blob auditing policy
        /// </summary>
        /// <returns>A ServerBlobAuditingPolicyResourceProperties object with the default server audit policy settings</returns>
        private ServerBlobAuditingPolicyResourceProperties GetDefaultBlobAuditgProperties()
        {
            ServerBlobAuditingPolicyResourceProperties properties = new ServerBlobAuditingPolicyResourceProperties
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
