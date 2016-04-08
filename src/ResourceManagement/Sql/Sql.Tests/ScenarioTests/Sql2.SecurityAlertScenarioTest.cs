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

using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private void TestDatabaseSecurityAlertAPIs(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            DatabaseSecurityAlertPolicyGetResponse getDefaultDatabaseSecurityAlertPolicyResponse = sqlClient.SecurityAlertPolicy.GetDatabaseSecurityAlertPolicy(resourceGroupName, server.Name, database.Name);
            DatabaseSecurityAlertPolicyProperties properties = getDefaultDatabaseSecurityAlertPolicyResponse.SecurityAlertPolicy.Properties;

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultDatabaseSecurityAlertPolicyResponse, HttpStatusCode.OK);
            VerifyDatabaseSecurityAlertPolicyInformation(GetDefaultDatabaseSecurityAlertProperties(), properties);

            // Modify the policy properties, send and receive, see it its still ok
            ChangeDataBaseSecurityAlertPolicy(properties);
            DatabaseSecurityAlertPolicyCreateOrUpdateParameters updateParams =
                new DatabaseSecurityAlertPolicyCreateOrUpdateParameters { Properties = properties };

            var updateResponse = sqlClient.SecurityAlertPolicy.CreateOrUpdateDatabaseSecurityAlertPolicy(resourceGroupName, server.Name, database.Name, updateParams);

            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            DatabaseSecurityAlertPolicyGetResponse getUpdatedPolicyResponse = sqlClient.SecurityAlertPolicy.GetDatabaseSecurityAlertPolicy(resourceGroupName, server.Name, database.Name);
            DatabaseSecurityAlertPolicyProperties updatedProperties = getUpdatedPolicyResponse.SecurityAlertPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse, HttpStatusCode.OK);
            VerifyDatabaseSecurityAlertPolicyInformation(properties, updatedProperties);
        }

        /// <summary>
        /// Creates and returns a DatabaseSecurityAlertPolicyProperties object that holds the default settings for a database security alert policy
        /// </summary>
        /// <returns>A DatabaseSecurityAlertPolicyProperties object with the default security alert policy settings</returns>
        private DatabaseSecurityAlertPolicyProperties GetDefaultDatabaseSecurityAlertProperties()
        {
            DatabaseSecurityAlertPolicyProperties props = new DatabaseSecurityAlertPolicyProperties
            {
                State = "New",
                DisabledAlerts = string.Empty,
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
        private static void VerifyDatabaseSecurityAlertPolicyInformation(DatabaseSecurityAlertPolicyProperties expected, DatabaseSecurityAlertPolicyProperties actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.DisabledAlerts, actual.DisabledAlerts);
            Assert.Equal(expected.EmailAddresses, actual.EmailAddresses);
            Assert.Equal(expected.EmailAccountAdmins, actual.EmailAccountAdmins);
        }

        /// <summary>
        /// Changes the database security alert policy with new values
        /// </summary>
        private void ChangeDataBaseSecurityAlertPolicy(DatabaseSecurityAlertPolicyProperties properties)
        {
            properties.State = "Enabled";
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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "12.0", TestDatabaseSecurityAlertAPIs);
            }
        }
    }
}
