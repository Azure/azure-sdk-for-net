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
    /// Contains tests for the lifecycle of a Database SecureConnection policy
    /// </summary>
    public class Sql2SecureConnectionScenarioTest
    {
 
        /// <summary> 
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given database's secure connection policy. 
        /// It is meant to be called with a name of an already exisiting database (and therefore already existing server and resource group). 
        /// </summary> 
        private void TestSecureConnectionAPIs(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            DatabaseSecureConnectionPolicyGetResponse getDefaultSecureConnectionPolicyResponse = sqlClient.SecureConnection.GetDatabasePolicy(resourceGroupName, server.Name, database.Name);
            DatabaseSecureConnectionPolicyProperties properties = getDefaultSecureConnectionPolicyResponse.SecureConnectionPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultSecureConnectionPolicyResponse, HttpStatusCode.OK);
            VerifySecureConnectionPolicyInformation(getDefaultSecureConnectionPolicyProperties(server.Name), properties);

            // Modify the policy properties, send and receive, see it its still ok
            properties.SecurityEnabledAccess = "Required";
            DatabaseSecureConnectionPolicyCreateOrUpdateParameters updateParams = new DatabaseSecureConnectionPolicyCreateOrUpdateParameters();
            updateParams.Properties = ConvertToSecureConnectionPolicyCreateProperties(properties);

            var updateResponse = sqlClient.SecureConnection.CreateOrUpdateDatabasePolicy(resourceGroupName, server.Name, database.Name, updateParams);

            // Verify that the initial Get request of contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            DatabaseSecureConnectionPolicyGetResponse getUpdatedPolicyResponse = sqlClient.SecureConnection.GetDatabasePolicy(resourceGroupName, server.Name, database.Name);
            DatabaseSecureConnectionPolicyProperties updatedProperties = getUpdatedPolicyResponse.SecureConnectionPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse, HttpStatusCode.OK);
            VerifySecureConnectionPolicyInformation(properties, updatedProperties);
        }

        /// <summary>
        /// Converts the given SecureConnectionPolicyProperties to a SecureConnectionPolicyCreateOrUpdateProperties that has the same values for the properties
        /// </summary>
        /// <param name="properties">The properties to be used for creating the returned value</param>
        /// <returns>A SecureConnectionPolicyCreateOrUpdateProperties which reflected the given properties</returns>
        private DatabaseSecureConnectionPolicyCreateOrUpdateProperties ConvertToSecureConnectionPolicyCreateProperties(DatabaseSecureConnectionPolicyProperties properties)
        {
            DatabaseSecureConnectionPolicyCreateOrUpdateProperties createProps = new DatabaseSecureConnectionPolicyCreateOrUpdateProperties();
            createProps.SecurityEnabledAccess = properties.SecurityEnabledAccess;
            return createProps;
        }
    
        /// <summary>
        /// Creates and returns a DatabaseAuditingPolicyProperties object that holds the default settings for a a database auditing policy
        /// </summary>
        /// <returns>A DatabaseAuditingPolicyProperties object with the default audit policy settings</returns>
        private DatabaseSecureConnectionPolicyProperties getDefaultSecureConnectionPolicyProperties(string serverName)
        {
            DatabaseSecureConnectionPolicyProperties props = new DatabaseSecureConnectionPolicyProperties();
            props.SecurityEnabledAccess = "Optional";
            props.ProxyPort = "1433";
            props.ProxyDnsName = serverName+".database.secure.windows.net";
            return props;
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="actual">The properties object that needs to be checked</param>
        /// <param name="expected">The expected value of the properties object</param>
        private static void VerifySecureConnectionPolicyInformation(DatabaseSecureConnectionPolicyProperties actual, DatabaseSecureConnectionPolicyProperties expected)
        {
            Assert.Equal(expected.SecurityEnabledAccess, actual.SecurityEnabledAccess);
            Assert.Equal(expected.ProxyDnsName, actual.ProxyDnsName);
            Assert.Equal(expected.ProxyPort, actual.ProxyPort);
        }

        
        /// <summary>
        /// Test for the Auditing policy lifecycle
        /// </summary>
        [Fact]
        public void SecureConnectionPolicyLifecycleTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "2.0", TestSecureConnectionAPIs);
            }
        }
    }
}
