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
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for FailoverGroups
    /// </summary>
    public class Sql2FailoverGroupScenarioTests : TestBase
    {
        [Fact]
        public void FailoverGroupCrud()
        {
            var handler = new BasicDelegatingHandler();
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string failoverGroupName = TestUtilities.GenerateName("csm-sql-fgcrud1");
                string failoverGroup2Name = TestUtilities.GenerateName("csm-sql-fgcrud2");
                string serverName = TestUtilities.GenerateName("csm-sql-fgcrud-server");
                string partnerServerName = TestUtilities.GenerateName("csm-sql-fgcrud-server");

                // Create the resource group.

                //resClient.ResourceGroups.CreateOrUpdate(resGroupName, new ResourceGroup()

                //{
                //    Location = serverLocation,
                //});

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    "North Europe",
                    (sqlClient, resGroupName, server) =>
                    {
                            // Variables for partner server create

                            string serverLocation = "North Europe";
                            string adminLogin = "testlogin";
                            string adminPass = "Testp@ss";
                            string version = "12.0";

                            // Create partner server for test.
                            var createServerResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, partnerServerName, new ServerCreateOrUpdateParameters()
                            {
                                Location = serverLocation,
                                Properties = new ServerCreateOrUpdateProperties()
                                {
                                    AdministratorLogin = adminLogin,
                                    AdministratorLoginPassword = adminPass,
                                    Version = version,
                                }
                            });


                            // Create Failover Group Test with all values specified (Default values)
                            ReadOnlyEndpoint readOnlyEndpoint = new ReadOnlyEndpoint();
                            readOnlyEndpoint.FailoverPolicy = "Disabled";
                            ReadWriteEndpoint readWriteEndpoint = new ReadWriteEndpoint();
                            readWriteEndpoint.FailoverPolicy = "Automatic";
                            readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = 5;

                            FailoverGroupPartnerServer partnerServer = new FailoverGroupPartnerServer();
                            partnerServer.ReplicationRole = "Secondary";
                            partnerServer.Id = createServerResponse.Server.Id;
                            partnerServer.Location = "North Europe";

                            List<FailoverGroupPartnerServer> partnerServers = new List<FailoverGroupPartnerServer>();
                            partnerServers.Add(partnerServer);

                            var failoverGroup1Properties = new FailoverGroupCreateOrUpdateProperties()
                            {
                                ReadOnlyEndpoint = readOnlyEndpoint,
                                ReadWriteEndpoint = readWriteEndpoint,
                                PartnerServers = partnerServers,
                            };

                            var failoverGroup1 = sqlClient.FailoverGroups.CreateOrUpdate(resGroupName, server.Name, failoverGroupName, new FailoverGroupCreateOrUpdateParameters()
                            {
                                Location = server.Location,
                                Properties = failoverGroup1Properties
                            });

                            TestUtilities.ValidateOperationResponse(failoverGroup1, HttpStatusCode.Created);

                            var failoverGroup2 = sqlClient.FailoverGroups.CreateOrUpdate(resGroupName, server.Name, failoverGroup2Name, new FailoverGroupCreateOrUpdateParameters()
                            {
                                Location = server.Location,
                                Properties = failoverGroup1Properties
                            });

                            TestUtilities.ValidateOperationResponse(failoverGroup2, HttpStatusCode.Created);
                            ValidateFailoverGroup(
                                failoverGroup2.FailoverGroup,
                                failoverGroup2Name,
                                readOnlyEndpoint.FailoverPolicy,
                                readWriteEndpoint.FailoverPolicy,
                                readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes,
                                partnerServer.ReplicationRole,
                                partnerServer.Id);

                            //////////////////////////////////////////////////////////////////////
                            // Update Failover Group Test
                            failoverGroup1Properties.ReadOnlyEndpoint.FailoverPolicy = "Enabled";
                            failoverGroup1Properties.ReadWriteEndpoint.FailoverPolicy = "Manual";
                            failoverGroup1Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = null;

                            var failoverGroup3 = sqlClient.FailoverGroups.CreateOrUpdate(resGroupName, server.Name, failoverGroupName, new FailoverGroupCreateOrUpdateParameters()
                            {
                                Location = server.Location,
                                Properties = failoverGroup1Properties
                            });


                            TestUtilities.ValidateOperationResponse(failoverGroup3, HttpStatusCode.Created);
                            ValidateFailoverGroup(
                                failoverGroup3.FailoverGroup,
                                failoverGroupName,
                                failoverGroup1Properties.ReadOnlyEndpoint.FailoverPolicy,
                                failoverGroup1Properties.ReadWriteEndpoint.FailoverPolicy,
                                failoverGroup1Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes,
                                failoverGroup1Properties.PartnerServers.First().ReplicationRole,
                                failoverGroup1Properties.PartnerServers.First().Id);

                            //////////////////////////////////////////////////////////////////////
                            // Get Failover group.
                            var failoverGroup4 = sqlClient.FailoverGroups.Get(resGroupName, server.Name, failoverGroupName);


                            TestUtilities.ValidateOperationResponse(failoverGroup4, HttpStatusCode.Created);
                            ValidateFailoverGroup(
                                failoverGroup3.FailoverGroup,
                                failoverGroupName,
                                failoverGroup1Properties.ReadOnlyEndpoint.FailoverPolicy,
                                failoverGroup1Properties.ReadWriteEndpoint.FailoverPolicy,
                                failoverGroup1Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes,
                                failoverGroup1Properties.PartnerServers.First().ReplicationRole,
                                failoverGroup1Properties.PartnerServers.First().Id);

                            //////////////////////////////////////////////////////////////////////
                            // Get Failover Groups Test.
                            var failoverGroups = sqlClient.FailoverGroups.List(resGroupName, server.Name);

                            TestUtilities.ValidateOperationResponse(failoverGroups, HttpStatusCode.OK);
                            Assert.Equal(2, failoverGroups.FailoverGroups.Count);

                            //////////////////////////////////////////////////////////////////////
                            // Delete Failover Group Test.
                            //var resp = sqlClient.FailoverGroups.Delete(resGroupName, server.Name, failoverGroupName);
                            //TestUtilities.ValidateOperationResponse(resp, HttpStatusCode.OK);

                            //var resp2 = sqlClient.FailoverGroups.Delete(resGroupName, server.Name, failoverGroup2Name);
                            //TestUtilities.ValidateOperationResponse(resp2, HttpStatusCode.OK);
                        });
            }
        }

        [Fact]
        public void FailoverGroupDatabaseOperations()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string failoverGroupName = TestUtilities.GenerateName("csm-sql-fgdb");
                string serverName = TestUtilities.GenerateName("csm-sql-fgdb-server");
                var databaseName = TestUtilities.GenerateName("csm-sql-fgdb-db");
                var database2Name = TestUtilities.GenerateName("csm-sql-fgdb-db");

                Sql2ScenarioHelper.RunServerTestInEnvironment(
                    handler,
                    "12.0",
                    "North Europe",
                    (sqlClient, resGroupName, server) =>
                    {
                        // Variables for partner server create
                        string serverLocation = "North Europe";
                        string adminLogin = "testlogin";
                        string adminPass = "Testp@ss";
                        string version = "12.0";

                        //////////////////////////////////////////////////////////////////////
                        // Create server for test.
                        var createServerResponse = sqlClient.Servers.CreateOrUpdate(resGroupName, serverName, new ServerCreateOrUpdateParameters()
                        {
                            Location = serverLocation,
                            Properties = new ServerCreateOrUpdateProperties()
                            {
                                AdministratorLogin = adminLogin,
                                AdministratorLoginPassword = adminPass,
                                Version = version,
                            }
                        });

                        //////////////////////////////////////////////////////////////////////
                        // Create Failover Group with all values specified (Default values)

                        ReadOnlyEndpoint readOnlyEndpoint = new ReadOnlyEndpoint();
                        readOnlyEndpoint.FailoverPolicy = "Disabled";
                        ReadWriteEndpoint readWriteEndpoint = new ReadWriteEndpoint();
                        readWriteEndpoint.FailoverPolicy = "Automatic";
                        readWriteEndpoint.FailoverWithDataLossGracePeriodMinutes = 5;

                        FailoverGroupPartnerServer partnerServer = new FailoverGroupPartnerServer();
                        partnerServer.ReplicationRole = "Secondary";
                        partnerServer.Id = createServerResponse.Server.Id;
                        partnerServer.Location = "North Europe";

                        List<FailoverGroupPartnerServer> partnerServers = new List<FailoverGroupPartnerServer>();
                        partnerServers.Add(partnerServer);


                        var failoverGroup1Properties = new FailoverGroupCreateOrUpdateProperties()
                        {
                            ReadOnlyEndpoint = readOnlyEndpoint,
                            ReadWriteEndpoint = readWriteEndpoint,
                            PartnerServers = partnerServers,
                        };

                        var failoverGroup1 = sqlClient.FailoverGroups.CreateOrUpdate(resGroupName, server.Name, failoverGroupName, new FailoverGroupCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = failoverGroup1Properties
                        });
                        TestUtilities.ValidateOperationResponse(failoverGroup1, HttpStatusCode.Created);

                        ////////////////////////////////////////////////////////////////////
                        // Create database
                        var db1 = sqlClient.Databases.CreateOrUpdate(resGroupName, server.Name, databaseName, new DatabaseCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = new DatabaseCreateOrUpdateProperties()
                            {
                                Edition = "Premium"
                            }
                        });

                        TestUtilities.ValidateOperationResponse(db1, HttpStatusCode.Created);

                        var db2 = sqlClient.Databases.CreateOrUpdate(resGroupName, server.Name, database2Name, new DatabaseCreateOrUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = new DatabaseCreateOrUpdateProperties()
                            {
                                Edition = "Basic"
                            }
                        });

                        TestUtilities.ValidateOperationResponse(db2, HttpStatusCode.Created);

                        //Add database ids into a list 
                        List<string> dbs = new List<string>();
                        dbs.Add(db1.Database.Id);
                        dbs.Add(db2.Database.Id);

                        //////////////////////////////////////////////////////////////////////
                        // Move database into failover group

                        var moveResult = sqlClient.FailoverGroups.PatchUpdate(resGroupName, server.Name, failoverGroupName, new FailoverGroupPatchUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = new FailoverGroupPatchUpdateProperties
                            {
                                Databases = dbs,
                            }
                        });

                        TestUtilities.ValidateOperationResponse(moveResult, HttpStatusCode.OK);
                        Assert.True(VerifyDbsEqual(moveResult.FailoverGroup.Properties.Databases, dbs));

                        //////////////////////////////////////////////////////////////////////
                        // Delete databases from failover group

                        dbs.RemoveAt(1);
                        var removeResult = sqlClient.FailoverGroups.PatchUpdate(resGroupName, server.Name, failoverGroupName, new FailoverGroupPatchUpdateParameters()
                        {
                            Location = server.Location,
                            Properties = new FailoverGroupPatchUpdateProperties
                            {
                                Databases = dbs,
                            }
                        });

                        TestUtilities.ValidateOperationResponse(moveResult, HttpStatusCode.OK);
                        Assert.True(VerifyDbsEqual(removeResult.FailoverGroup.Properties.Databases, dbs));

                        //////////////////////////////////////////////////////////////////////
                        // Failover Test.
                        //var failoverResult = sqlClient.FailoverGroups.Failover(resGroupName, server.Name, failoverGroupName);
                        //TestUtilities.ValidateOperationResponse(failoverResult, HttpStatusCode.OK);

                        //var failoverWithDatalossResult = sqlClient.FailoverGroups.ForceFailoverAllowDataLoss(resGroupName, server.Name, failoverGroupName);
                        //TestUtilities.ValidateOperationResponse(failoverWithDatalossResult, HttpStatusCode.OK);

                    });
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="fg">The failover group to validate</param>
        /// <param name="failoverGroupName">The expected name of the failover group</param>
        /// <param name="readOnlyFailoverPolicy">The expected readonly failover policy of the failover group</param>
        /// <param name="readWriteFailoverPolicy">The expected readwrite failover policy of the failover group</param>
        /// <param name="gracePeriodWithDataLoss">The expected grace period with data loss in minuts of the failover group</param>
        /// <param name="replicationRole">The expected replication role for the partner server</param>
        /// <param name="id">The expected id for the partner server</param>
        private void ValidateFailoverGroup(FailoverGroup fg, string failoverGroupName, string readOnlyFailoverPolicy, string readWriteFailoverPolicy,  int? gracePeriodWithDataLoss, string replicationRole, string id)
        {
            Assert.Equal(fg.Name, failoverGroupName);

            Assert.Equal(readOnlyFailoverPolicy, fg.Properties.ReadOnlyEndpoint.FailoverPolicy);
            Assert.Equal(readWriteFailoverPolicy, fg.Properties.ReadWriteEndpoint.FailoverPolicy);
            Assert.Equal(gracePeriodWithDataLoss, fg.Properties.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes);
            //Assert.Equal(replicationRole, fg.Properties.PartnerServers.First().ReplicationRole);
            Assert.Equal(id, fg.Properties.PartnerServers.First().Id);
        }

        private Boolean VerifyDbsEqual(IList<string> list1, IList<string> list2) 
        {
            var firstNotSecond = list1.Except(list2).ToList();
            var secondNotFirst = list2.Except(list1).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}
