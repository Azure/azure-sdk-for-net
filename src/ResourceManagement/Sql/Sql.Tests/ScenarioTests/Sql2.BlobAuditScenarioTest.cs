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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Database and server auditing policy
    /// </summary>
    public class Sql2BlobAuditScenarioTest
    {

        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given database's blob auditing policy. It is meant to be called with a name of an already existing database (and therefore already existing 
        /// server and resource group). This test does not create these resources and does not remove them.
        /// </summary>
        private void TestDatabaseAuditingApis(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            BlobAuditingGetResponse getDefaultDatabasePolicyResponse = sqlClient.BlobAuditing.GetDatabaseBlobAuditingPolicy(resourceGroupName, server.Name, database.Name);
            var properties = getDefaultDatabasePolicyResponse.AuditingPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultDatabasePolicyResponse);
            VerifyAuditingPolicyInformation(GetDefaultBlobAuditProperties(), properties);
            // Modify the policy properties, send and receive, see it its still ok
            var updateParams = new BlobAuditingCreateOrUpdateParameters { Properties = properties };

            var updateResponse = sqlClient.BlobAuditing.CreateOrUpdateDatabasePolicy(resourceGroupName, server.Name, database.Name, updateParams);

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse);

            var getUpdatedPolicyResponse = sqlClient.BlobAuditing.GetDatabaseBlobAuditingPolicy(resourceGroupName, server.Name, database.Name);
            var updatedProperties = getUpdatedPolicyResponse.AuditingPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse);
            VerifyAuditingPolicyInformation(properties, updatedProperties);
        }
  
        /// <summary>
        /// Creates and returns a BlobAuditingProperties object that holds the default settings for a database blob auditing policy
        /// </summary>
        /// <returns>A BlobAuditingProperties object with the default audit policy settings</returns>
        private BlobAuditingProperties GetDefaultBlobAuditProperties()
        {
            BlobAuditingProperties props = new BlobAuditingProperties
            {
                State = "Disabled",
                RetentionDays = 0,
                StorageAccountAccessKey = "",
                StorageEndpoint = ""
            };
            return props;
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private static void VerifyAuditingPolicyInformation(BlobAuditingProperties expected, BlobAuditingProperties actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
            Assert.Equal(expected.StorageEndpoint, actual.StorageEndpoint);
            Assert.Equal(expected.StorageAccountAccessKey, actual.StorageAccountAccessKey);
            if (expected.AuditActionsAndGroups == null)
            {
                Assert.Equal(actual.AuditActionsAndGroups, null);
            }
            else
            {
                Assert.Equal(expected.AuditActionsAndGroups.Count, actual.AuditActionsAndGroups.Count);
                actual.AuditActionsAndGroups.ForEach(s => Assert.True(expected.AuditActionsAndGroups.Any(es => es.Equals(s))));
            }
        }

        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given server's blob auditing policy. It is meant to be called with a name of an already existing server (and therefore already existing 
        /// resource group). This test does not create these resources and does not remove them.
        /// </summary>
        private async void TestServerAuditingApis(SqlManagementClient sqlClient, string resourceGroupName, Server server)
        {
            var getDefaultServerPolicyResponse = sqlClient.BlobAuditing.GetServerPolicy(resourceGroupName, server.Name);
            var properties = getDefaultServerPolicyResponse.AuditingPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultServerPolicyResponse);
            VerifyAuditingPolicyInformation(GetDefaultBlobAuditProperties(), properties);

            // Modify the policy properties, send and receive, see it its still ok
            ChangeBlobAuditPolicy(properties);
            var updateParams = new BlobAuditingCreateOrUpdateParameters { Properties = properties };

            var updateResponse = sqlClient.BlobAuditing.CreateOrUpdateServerPolicy(resourceGroupName, server.Name, updateParams);
            var succeededInUpated = false;
            // Verify that the initial Get request of contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.Accepted);
            for (var iterationCount = 0; iterationCount < 10; iterationCount++) // at most 10 iterations, each means wait of 30 seconds
            {
                var blobAuditStatusResponse = sqlClient.BlobAuditing.GetOperationStatus(updateResponse.OperationStatusLink);
                var blobAuditingOperationResult = blobAuditStatusResponse.OperationResult.Properties;
                if (blobAuditingOperationResult.State == OperationStatus.Succeeded)
                {
                    succeededInUpated = true;
                    break;
                }
                if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                {
                    await Task.Delay(30000);    
                }                                  
            }

            Assert.True(succeededInUpated, "Failed in updating the server's policy");

            var getUpdatedPolicyResponse = sqlClient.BlobAuditing.GetServerPolicy(resourceGroupName, server.Name);
            var updatedProperties = getUpdatedPolicyResponse.AuditingPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse);
            VerifyAuditingPolicyInformation(properties, updatedProperties);
        }

        /// <summary>
        /// Changes the server auditing policy with new values
        /// </summary>
        private void ChangeBlobAuditPolicy(BlobAuditingProperties properties)
        {
            properties.RetentionDays = 10;
            properties.AuditActionsAndGroups = new List<string>{ "SUCCESSFUL_DATABASE_AUTHENTICATION_GROUP" };
        }

        /// <summary>
        /// Test for the Auditing policy lifecycle
        /// </summary>
        [Fact]
        public void ServerBlobAuditingPolicyLifecycleTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunServerTestInEnvironment(new BasicDelegatingHandler(), "12.0", TestServerAuditingApis);
            }
        }

        /// <summary>
        /// Test for the Auditing policy lifecycle
        /// </summary>
        [Fact]
        public void DatabaseBlobAuditingPolicyLifecycleTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "12.0", TestDatabaseAuditingApis);
            }
        }
    }
}
