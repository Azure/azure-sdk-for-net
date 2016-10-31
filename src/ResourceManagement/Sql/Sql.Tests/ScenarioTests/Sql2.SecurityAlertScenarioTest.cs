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

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Database SecurityAlert policy
    /// </summary>
    public class Sql2SecurityAlertScenarioTests
    {     
        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given database's security alert policy. It is meant to be called with a name of an already existing database (and therefore already existing 
        /// server and resource group). This test does not create these resources and does not remove them.
        /// </summary>
        private static void TestDatabaseSecurityAlertApis(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            var getDefaultDatabaseSecurityAlertPolicyResponse = sqlClient.SecurityAlertPolicy.GetDatabaseSecurityAlertPolicy(resourceGroupName, server.Name, database.Name);
            var properties = getDefaultDatabaseSecurityAlertPolicyResponse.SecurityAlertPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultDatabaseSecurityAlertPolicyResponse);
            VerifySecurityAlertPolicyInformation(GetDefaultDatabaseSecurityAlertProperties(), properties);

            // Modify the policy properties, send and receive, see it its still ok
            ChangeSecurityAlertPolicy(properties);
            var updateParams = new DatabaseSecurityAlertPolicyCreateOrUpdateParameters { Properties = properties };

            var updateResponse = sqlClient.SecurityAlertPolicy.CreateOrUpdateDatabaseSecurityAlertPolicy(resourceGroupName, server.Name, database.Name, updateParams);

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse);

            var getUpdatedPolicyResponse = sqlClient.SecurityAlertPolicy.GetDatabaseSecurityAlertPolicy(resourceGroupName, server.Name, database.Name);
            var updatedProperties = getUpdatedPolicyResponse.SecurityAlertPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse);
            VerifySecurityAlertPolicyInformation(properties, updatedProperties);
        }

        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given database's security alert policy. It is meant to be called with a name of an already existing database (and therefore already existing 
        /// server and resource group). This test does not create these resources and does not remove them.
        /// </summary>
        private static void TestServerSecurityAlertApis(SqlManagementClient sqlClient, string resourceGroupName, Server server)
        {
            var getDefaultDatabaseSecurityAlertPolicyResponse = sqlClient.SecurityAlertPolicy.GetServerSecurityAlertPolicy(resourceGroupName, server.Name);
            var properties = getDefaultDatabaseSecurityAlertPolicyResponse.SecurityAlertPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultDatabaseSecurityAlertPolicyResponse);
            VerifySecurityAlertPolicyInformation(GetDefaultServerSecurityAlertProperties(), properties);

            // Modify the policy properties, send and receive, see it its still ok
            ChangeSecurityAlertPolicy(properties);
            var updateParams = new ServerSecurityAlertPolicyCreateOrUpdateParameters { Properties = properties };

            /*var updateResponse = */sqlClient.SecurityAlertPolicy.CreateOrUpdateServerSecurityAlertPolicy(resourceGroupName, server.Name, updateParams);

            // Verify that the initial Get request contains the default policy.
          //  TestUtilities.ValidateOperationResponse(updateResponse);

            var getUpdatedPolicyResponse = sqlClient.SecurityAlertPolicy.GetServerSecurityAlertPolicy(resourceGroupName, server.Name);
            var updatedProperties = getUpdatedPolicyResponse.SecurityAlertPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse);
            VerifySecurityAlertPolicyInformation(properties, updatedProperties);
        }

        /// <summary>
        /// Creates and returns a DatabaseSecurityAlertPolicyProperties object that holds the default settings for a database security alert policy
        /// </summary>
        /// <returns>A DatabaseSecurityAlertPolicyProperties object with the default security alert policy settings</returns>
        private static DatabaseSecurityAlertPolicyProperties GetDefaultDatabaseSecurityAlertProperties()
        {
            var props = new DatabaseSecurityAlertPolicyProperties
            {
                State = "New",
                DisabledAlerts = "Preview",
                EmailAddresses = string.Empty,
                EmailAccountAdmins = "Enabled"
            };
            return props;
        }

        /// <summary>
        /// Creates and returns a DatabaseSecurityAlertPolicyProperties object that holds the default settings for a server security alert policy
        /// </summary>
        /// <returns>A DatabaseSecurityAlertPolicyProperties object with the default security alert policy settings</returns>
        private static ServerSecurityAlertPolicyProperties GetDefaultServerSecurityAlertProperties()
        {
            var props = new ServerSecurityAlertPolicyProperties
            {
                State = "New",
                DisabledAlerts = "Preview",
                EmailAddresses = string.Empty,
                EmailAccountAdmins = "Enabled"
            };
            return props;
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private static void VerifySecurityAlertPolicyInformation(BaseSecurityAlertPolicyProperties expected, BaseSecurityAlertPolicyProperties actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.DisabledAlerts, actual.DisabledAlerts);
            Assert.Equal(expected.EmailAddresses, actual.EmailAddresses);
            Assert.Equal(expected.EmailAccountAdmins, actual.EmailAccountAdmins);
        }

        /// <summary>
        /// Changes the database security alert policy with new values
        /// </summary>
        private static void ChangeSecurityAlertPolicy(BaseSecurityAlertPolicyProperties properties)
        {
            properties.State = "Disabled";
            properties.DisabledAlerts = "DisableAlert1";
            properties.EmailAddresses = "email1@email.com;email2@email.com";
            properties.EmailAccountAdmins = "Disabled";
        }

        /// <summary>
        /// Test for the Security alert policy lifecycle
        /// </summary>
        [Fact]
        public void DatabaseSecurityAlertPolicyLifecycleTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "12.0", TestDatabaseSecurityAlertApis);
            }
        }

        /// <summary>
        /// Test for the Security alert policy lifecycle
        /// </summary>
        [Fact]
        public void ServerSecurityAlertPolicyLifecycleTest()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunServerTestInEnvironment(new BasicDelegatingHandler(), "12.0", TestServerSecurityAlertApis);
            }
        }
    }
}
