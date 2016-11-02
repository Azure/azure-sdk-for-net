
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

using AnalysisServices.Tests.Helpers;
using Microsoft.Azure;
using Microsoft.Azure.Management.Analysis;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace AnalysisServices.Tests.ScenarioTests
{
    public class ServerOperationsTests : TestBase
    {
        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetAnalysisServicesClient(context);

                AnalysisServicesServer analysisServicesServer = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();
                AnalysisServicesServer resultCreate = null;
                try
                {
                    // Create a test server
                    resultCreate =
                        client.Servers.Create(
                            AnalysisServicesTestUtilities.DefaultResourceGroup,
                            AnalysisServicesTestUtilities.DefaultServerName,
                            analysisServicesServer);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Assert.Equal(resultCreate.ProvisioningState, "Succeeded");

                // get the server and ensure that all the values are properly set.
                var resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.NotEmpty(resultGet.ServerFullName);
                Assert.Equal(resultGet.Tags.Count, 2);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(resultGet.AsAdministrators.Members.Count, 2);
                Assert.Equal("Microsoft.AnalysisServices/servers", resultGet.Type);

                // Confirm that the server creation did succeed
                Assert.True(resultGet.ProvisioningState == "Succeeded");

                // Update the server and confirm the updates make it in.
                Dictionary<string, string> updatedTags = new Dictionary<string, string>
                    {
                        {"updated1","value1"}
                    };

                var updatedAdministrators = AnalysisServicesTestUtilities.DefaultAdministrators;
                updatedAdministrators.Add("aztest2@aspaastestloop1.ccsctp.net");
                AnalysisServicesServerUpdateParameters updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        Sku = resultGet.Sku,
                        Tags = updatedTags,
                        AsAdministrators = new ServerAdministrators(updatedAdministrators)
                    };

                var resultUpdate = client.Servers.Update(
                                AnalysisServicesTestUtilities.DefaultResourceGroup,
                                AnalysisServicesTestUtilities.DefaultServerName,
                                updateParameters
                                );

                Assert.Equal("Succeeded", resultUpdate.ProvisioningState);

                // get the server and ensure that all the values are properly set.
                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.Equal(resultGet.Tags.Count, 1);
                Assert.True(resultGet.Tags.ContainsKey("updated1"));
                Assert.Equal(resultGet.AsAdministrators.Members.Count, 3);

                // Create another server and ensure that list account returns both
                var secondServer = AnalysisServicesTestUtilities.DefaultServerName + '2';
                resultCreate =  client.Servers.Create(
                                    AnalysisServicesTestUtilities.DefaultResourceGroup,
                                    secondServer,
                                    analysisServicesServer);

                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                var listResponse = client.Servers.List();

                // Assert that there are at least two servers in the list
                Assert.True(listResponse.Count() >= 2);

                // now list by resource group:
                listResponse = client.Servers.ListByResourceGroup(AnalysisServicesTestUtilities.DefaultResourceGroup);

                // Assert that there are at least two servers in the list
                Assert.True(listResponse.Count() >= 2);

                // Suspend the server and confirm that it is deleted.
                client.Servers.Suspend(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                // Suspend the server and confirm that it is deleted.
                client.Servers.Resume(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                // Delete the server and confirm that it is deleted.
                client.Servers.Delete(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                // delete the server again and make sure it continues to result in a succesful code.
                client.Servers.Delete(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                // delete the server with its old name, which should also succeed.
                client.Servers.Delete(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // test that the server is gone
                // now list by resource group:
                listResponse = client.Servers.ListByResourceGroup(AnalysisServicesTestUtilities.DefaultResourceGroup);

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() > 0);
            }
        }
    }
}
