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

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for ServerCommunicationLink
    /// </summary>
    public class Sql2ServerCommunicationLinkScenarioTests : TestBase
    {
        public void ServerCommunicationLinkCrud()
        {
            var handler = new BasicDelegatingHandler();

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string commLinkName = TestUtilities.GenerateName("csm-sql-commlinkcrud-");

                Sql2ScenarioHelper.RunTwoServersTestInEnvironment(
                    handler,
                    "12.0",
                    false,
                    (sqlClient, resGroupName, server1, server2) =>
                    {
                        //////////////////////////////////////////////////////////////////////
                        // Create Test
                        var linkProperties = new ServerCommunicationLinkCreateOrUpdateProperties()
                        {
                            PartnerServer = server2.Name
                        };

                        var link1 = sqlClient.CommunicationLinks.CreateOrUpdate(resGroupName, server1.Name, commLinkName, new ServerCommunicationLinkCreateOrUpdateParameters()
                        {
                            Location = server1.Location,
                            Properties = linkProperties
                        });

                        TestUtilities.ValidateOperationResponse(link1, HttpStatusCode.Created);
                        ValidateServerCommunicationLink(
                            link1.ServerCommunicationLink,
                            commLinkName,
                            linkProperties.PartnerServer);

                        //////////////////////////////////////////////////////////////////////
                        // Get Test.
                        var link2 = sqlClient.CommunicationLinks.Get(resGroupName, server1.Name, commLinkName);

                        TestUtilities.ValidateOperationResponse(link2, HttpStatusCode.OK);
                        ValidateServerCommunicationLink(
                            link2.ServerCommunicationLink,
                            commLinkName,
                            linkProperties.PartnerServer);

                        //////////////////////////////////////////////////////////////////////
                        // List Test.
                        var links = sqlClient.CommunicationLinks.List(resGroupName, server1.Name);

                        TestUtilities.ValidateOperationResponse(links, HttpStatusCode.OK);
                        Assert.Equal(1, links.ServerCommunicationLinks.Count);

                        //////////////////////////////////////////////////////////////////////
                        // Delete Test.
                        var resp = sqlClient.CommunicationLinks.Delete(resGroupName, server1.Name, link1.ServerCommunicationLink.Name);
                        TestUtilities.ValidateOperationResponse(resp, HttpStatusCode.OK);
                    });
            }
        }

        /// <summary>
        /// Validates the Server communication link properties
        /// </summary>
        /// <param name="link">The Server communication link to validate</param>
        /// <param name="linkName">The expected name</param>
        /// <param name="partnerServer">The expected name of the partner server</param>
        private void ValidateServerCommunicationLink(ServerCommunicationLink link, string linkName, string partnerServer)
        {
            Assert.Equal(link.Name, linkName);

            Assert.Equal(partnerServer, link.Properties.PartnerServer);
        }
    }
}
