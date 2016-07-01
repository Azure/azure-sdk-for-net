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

using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for ServerDisasterRecoveryConfiguration
    /// </summary>
    public class Sql2ServerDisasterRecoveryConfigurationScenarioTests : TestBase
    {
        [Fact(Skip = "This test fails with NoContent exception because NoContent was removed from the hydra spec as a success return code but the test was not updated.")]
        public void ServerDisasterRecoveryConfigurationCrud()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string failoverAliasName = TestUtilities.GenerateName("csm-sql-drc-alias-");

                Sql2ScenarioHelper.RunTwoServersTestInEnvironment(
                    handler,
                    "12.0",
                    true,
                    (sqlClient, resGroupName, server1, server2) =>
                    {
                        validateDrcNotExist(sqlClient, resGroupName, server1.Name, failoverAliasName);
                        validateDrcNotExist(sqlClient, resGroupName, server2.Name, failoverAliasName);

                        // Create and verify
                        //
                        ServerDisasterRecoveryConfigurationCreateOrUpdateResponse createResponse = CreateDrc(sqlClient, resGroupName, server1, server2, failoverAliasName);
                        TestUtilities.ValidateOperationResponse(createResponse, HttpStatusCode.Created);

                        GetAndValidateDrc(sqlClient, resGroupName, server1.Name, failoverAliasName, server2.Name, true);
                        GetAndValidateDrc(sqlClient, resGroupName, server2.Name, failoverAliasName, server1.Name, false);

                        // Invalid failover, then valid failover and verify
                        // 
                        Assert.Throws<Hyak.Common.CloudException>(() => sqlClient.ServerDisasterRecoveryConfigurations.Failover(resGroupName, server1.Name, failoverAliasName));
                        AzureOperationResponse failoverResponse = sqlClient.ServerDisasterRecoveryConfigurations.Failover(resGroupName, server2.Name, failoverAliasName);
                        TestUtilities.ValidateOperationResponse(failoverResponse);

                        GetAndValidateDrc(sqlClient, resGroupName, server1.Name, failoverAliasName, server2.Name, false);
                        GetAndValidateDrc(sqlClient, resGroupName, server2.Name, failoverAliasName, server1.Name, true);

                        // Delete and verify
                        //
                        AzureOperationResponse deleteResponse = sqlClient.ServerDisasterRecoveryConfigurations.Delete(resGroupName, server1.Name, failoverAliasName);
                        TestUtilities.ValidateOperationResponse(deleteResponse);

                        validateDrcNotExist(sqlClient, resGroupName, server1.Name, failoverAliasName);
                        validateDrcNotExist(sqlClient, resGroupName, server2.Name, failoverAliasName);
                    });
            }
        }

        private ServerDisasterRecoveryConfigurationCreateOrUpdateResponse CreateDrc(SqlManagementClient sqlClient, string resGroupName, Server server1, Server server2, string failoverAliasName)
        {
            ServerDisasterRecoveryConfigurationCreateOrUpdateParameters p = new ServerDisasterRecoveryConfigurationCreateOrUpdateParameters();
            p.Properties = new ServerDisasterRecoveryConfigurationCreateOrUpdateProperties
            {
                AutoFailover = "Off",
                FailoverPolicy = "Off",
                PartnerServerId = string.Format(CultureInfo.InvariantCulture,
                        "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}",
                        sqlClient.Credentials.SubscriptionId, resGroupName, server2.Name)
            };
            p.Location = server1.Location;

            return sqlClient.ServerDisasterRecoveryConfigurations.CreateOrUpdate(resGroupName, server1.Name, failoverAliasName, p);
        }

        /// <summary>
        /// GETs and validates the server disaster recovery configuration
        /// </summary>
        /// <param name="sqlClient">The Sql client used to GET the server disaster recovery configuration</param>
        /// <param name="resGroupName">The resource group of the server with the server disaster recovery configuration</param>
        /// <param name="serverName">The server with the server disaster recovery configuration</param>
        /// <param name="virtualEndpointName">The virtual endpoint name of the server disaster recovery configuration</param>
        /// <param name="partnerServerName">The expected partner server in the server disaster recovery configuration</param>
        /// <param name="primary">Whether the server disaster recovery configuration notes its server as having primary role</param>
        private void GetAndValidateDrc(SqlManagementClient sqlClient, string resGroupName, string serverName, string virtualEndpointName, string partnerServerName, bool primary)
        {
            ServerDisasterRecoveryConfigurationGetResponse getResponse = sqlClient.ServerDisasterRecoveryConfigurations.Get(resGroupName, serverName, virtualEndpointName);
            ServerDisasterRecoveryConfiguration drc = getResponse.ServerDisasterRecoveryConfiguration;

            Assert.Equal(virtualEndpointName, drc.Name);
            Assert.Equal(partnerServerName, drc.Properties.PartnerLogicalServerName);
            Assert.Equal("Off", drc.Properties.AutoFailover);
            Assert.Equal("Off", drc.Properties.FailoverPolicy);
            Assert.Equal(primary ? "Primary" : "Secondary", drc.Properties.Role);

            // Check the response from list call
            ServerDisasterRecoveryConfigurationListResponse listResponse = sqlClient.ServerDisasterRecoveryConfigurations.List(resGroupName, serverName);
            drc = listResponse.ServerDisasterRecoveryConfigurations.First();

            Assert.Equal(virtualEndpointName, drc.Name);
            Assert.Equal(partnerServerName, drc.Properties.PartnerLogicalServerName);
            Assert.Equal("Off", drc.Properties.AutoFailover);
            Assert.Equal("Off", drc.Properties.FailoverPolicy);
            Assert.Equal(primary ? "Primary" : "Secondary", drc.Properties.Role);
        }

        private void validateDrcNotExist(SqlManagementClient sqlClient, string resGroupName, string serverName, string failoverAliasName)
        {
            Assert.Throws<Hyak.Common.CloudException>(() => sqlClient.ServerDisasterRecoveryConfigurations.Get(resGroupName,
                            serverName, failoverAliasName));
        }
    }
}
