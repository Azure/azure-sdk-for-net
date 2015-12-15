//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Database and server auditing policy
    /// </summary>
    public class Sql2AuditScenarioTest
    {
        private const string c_DefualtEventTypesToAudit =
            "PlainSQL_Success,PlainSQL_Failure,ParameterizedSQL_Success,ParameterizedSQL_Failure,StoredProcedure_Success,StoredProcedure_Failure,Login_Success,Login_Failure,TransactionManagement_Success,TransactionManagement_Failure";
        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given database's auditing policy. It is meant to be called with a name of an already existing database (and therefore already existing 
        /// server and resource group). This test does not create these resources and does not remove them.
        /// </summary>
        private void TestDatabaseAuditingAPIs(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            DatabaseAuditingPolicyGetResponse getDefaultDatabasePolicyResponse = sqlClient.AuditingPolicy.GetDatabasePolicy(resourceGroupName, server.Name, database.Name);
            DatabaseAuditingPolicyProperties properties = getDefaultDatabasePolicyResponse.AuditingPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultDatabasePolicyResponse, HttpStatusCode.OK);
            VerifyDatabaseAuditingPolicyInformation(GetDefaultDatabaseAuditProperties(), properties);

            // Modify the policy properties, send and receive, see it its still ok
            ChangeDataBaseAuditPolicy(properties);
            DatabaseAuditingPolicyCreateOrUpdateParameters updateParams =
                new DatabaseAuditingPolicyCreateOrUpdateParameters {Properties = properties};

            var updateResponse = sqlClient.AuditingPolicy.CreateOrUpdateDatabasePolicy(resourceGroupName, server.Name, database.Name, updateParams);

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            DatabaseAuditingPolicyGetResponse getUpdatedPolicyResponse = sqlClient.AuditingPolicy.GetDatabasePolicy(resourceGroupName, server.Name, database.Name);
            DatabaseAuditingPolicyProperties updatedProperties = getUpdatedPolicyResponse.AuditingPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse, HttpStatusCode.OK); 
            VerifyDatabaseAuditingPolicyInformation(properties, updatedProperties);
        }
  
        /// <summary>
        /// Creates and returns a DatabaseAuditingPolicyProperties object that holds the default settings for a a database auditing policy
        /// </summary>
        /// <returns>A DatabaseAuditingPolicyProperties object with the default audit policy settings</returns>
        private DatabaseAuditingPolicyProperties GetDefaultDatabaseAuditProperties()
        {
            DatabaseAuditingPolicyProperties props = new DatabaseAuditingPolicyProperties
            {
                AuditingState = "New",
                EventTypesToAudit = c_DefualtEventTypesToAudit,
                StorageAccountName = null,
                StorageAccountKey = null,
                StorageAccountSecondaryKey = null,
                StorageAccountResourceGroupName = null,
                StorageAccountSubscriptionId = null,
                StorageTableEndpoint = null,
                RetentionDays = "0",
                UseServerDefault = "Disabled"
            };
            return props;
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private static void VerifyDatabaseAuditingPolicyInformation(DatabaseAuditingPolicyProperties expected , DatabaseAuditingPolicyProperties actual)
        {
            Assert.Equal(expected.AuditingState, actual.AuditingState);
            Assert.Equal(expected.EventTypesToAudit, actual.EventTypesToAudit);
            Assert.Equal(expected.StorageAccountName, actual.StorageAccountName);
            Assert.Equal(expected.StorageAccountKey, actual.StorageAccountKey);
            Assert.Equal(expected.StorageAccountSecondaryKey, actual.StorageAccountSecondaryKey);
            Assert.Equal(expected.StorageAccountResourceGroupName, actual.StorageAccountResourceGroupName);
            Assert.Equal(expected.StorageTableEndpoint, actual.StorageTableEndpoint);
            Assert.Equal(expected.StorageAccountSubscriptionId, actual.StorageAccountSubscriptionId);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
            Assert.Equal(expected.UseServerDefault, actual.UseServerDefault);
        }

        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given server's auditing policy. It is meant to be called with a name of an already existing server (and therefore already existing 
        /// resource group). This test does not create these resources and does not remove them.
        /// </summary>
        private void TestServerAuditingAPIs(SqlManagementClient sqlClient, string resourceGroupName, Server server)
        {
            ServerAuditingPolicyGetResponse getDefaultServerPolicyResponse = sqlClient.AuditingPolicy.GetServerPolicy(resourceGroupName, server.Name);
            ServerAuditingPolicyProperties properties = getDefaultServerPolicyResponse.AuditingPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultServerPolicyResponse, HttpStatusCode.OK);
            VerifyServerAuditingPolicyInformation(GetDefaultServerAuditProperties(), properties);

            // Modify the policy properties, send and receive, see it its still ok
            ChangeServerAuditPolicy(properties);
            ServerAuditingPolicyCreateOrUpdateParameters updateParams =
                new ServerAuditingPolicyCreateOrUpdateParameters {Properties = properties};

            var updateResponse = sqlClient.AuditingPolicy.CreateOrUpdateServerPolicy(resourceGroupName, server.Name, updateParams);

            // Verify that the initial Get request of contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            ServerAuditingPolicyGetResponse getUpdatedPolicyResponse = sqlClient.AuditingPolicy.GetServerPolicy(resourceGroupName, server.Name);
            ServerAuditingPolicyProperties updatedProperties = getUpdatedPolicyResponse.AuditingPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse, HttpStatusCode.OK);
            VerifyServerAuditingPolicyInformation(properties, updatedProperties);
        }

        /// <summary>
        /// Changes the server auditing policy with new values
        /// </summary>
        private void ChangeServerAuditPolicy(ServerAuditingPolicyProperties properties)
        {
            properties.AuditingState = "Disabled";
            properties.EventTypesToAudit = "PlainSQL_Success";
            properties.RetentionDays = "10";
            properties.AuditLogsTableName = "TempHyrdraTestAuditLogsTableName";
        }

        /// <summary>
        /// Changes the database auditing policy with new values
        /// </summary>
        private void ChangeDataBaseAuditPolicy(DatabaseAuditingPolicyProperties properties)
        {
            properties.AuditingState = "Disabled";
            properties.EventTypesToAudit = "PlainSQL_Success";
            properties.RetentionDays = "10";
            properties.AuditLogsTableName = "TempHyrdraTestAuditLogsTableName";
        }

        /// <summary>
        /// Creates and returns a ServerAuditingPolicyProperties object that holds the default settings for a server auditing policy
        /// </summary>
        /// <returns>A ServerAuditingPolicyProperties object with the default audit policy settings</returns>
        private ServerAuditingPolicyProperties GetDefaultServerAuditProperties()
        {
            ServerAuditingPolicyProperties props = new ServerAuditingPolicyProperties
            {
                AuditingState = "New",
                EventTypesToAudit = c_DefualtEventTypesToAudit,
                StorageAccountName = null,
                StorageAccountKey = null,
                StorageAccountSecondaryKey = null,
                StorageAccountResourceGroupName = null,
                StorageAccountSubscriptionId = null,
                StorageTableEndpoint = null,
                RetentionDays = "0"
            };
            return props;
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private static void VerifyServerAuditingPolicyInformation(ServerAuditingPolicyProperties expected , ServerAuditingPolicyProperties actual)
        {
            Assert.Equal(expected.AuditingState, actual.AuditingState);
            Assert.Equal(expected.EventTypesToAudit, actual.EventTypesToAudit);
            Assert.Equal(expected.StorageAccountName, actual.StorageAccountName);
            Assert.Equal(expected.StorageAccountKey, actual.StorageAccountKey);
            Assert.Equal(expected.StorageAccountSecondaryKey, actual.StorageAccountSecondaryKey);
            Assert.Equal(expected.StorageAccountResourceGroupName, actual.StorageAccountResourceGroupName);
            Assert.Equal(expected.StorageTableEndpoint, actual.StorageTableEndpoint);
            Assert.Equal(expected.StorageAccountSubscriptionId, actual.StorageAccountSubscriptionId);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
        }

        /// <summary>
        /// Test for the Auditing policy lifecycle
        /// </summary>
        [Fact]
        public void ServerAuditingPolicyLifecycleTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunServerTestInEnvironment(new BasicDelegatingHandler(), "2.0", TestServerAuditingAPIs);
            }
        }

        /// <summary>
        /// Test for the Auditing policy lifecycle
        /// </summary>
        [Fact]
        public void DatabaseAuditingPolicyLifecycleTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "2.0", TestDatabaseAuditingAPIs);
            }
        }
    }
}
