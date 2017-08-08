
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AnalysisServices.Tests.Helpers;
using Microsoft.Azure;
using Microsoft.Azure.Management.Analysis;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;

namespace AnalysisServices.Tests.ScenarioTests
{
    public class ServerOperationsTests : TestBase
    {
        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
            string executingAssemblyPath = typeof(AnalysisServices.Tests.ScenarioTests.ServerOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

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

                Assert.Equal("Succeeded", resultCreate.ProvisioningState);
                Assert.Equal("Succeeded", resultCreate.State);

                // get the server and ensure that all the values are properly set.
                var resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.Equal(1, resultGet.Sku.Capacity);
                Assert.NotEmpty(resultGet.ServerFullName);
                Assert.Equal(2, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(2, resultGet.AsAdministrators.Members.Count);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultBackupBlobContainerUri.Split('?')[0], resultGet.BackupBlobContainerUri);
                Assert.Equal(ConnectionMode.All, resultGet.QuerypoolConnectionMode);
                Assert.Equal("Microsoft.AnalysisServices/servers", resultGet.Type);

                // Confirm that the server creation did succeed
                Assert.True(resultGet.ProvisioningState == "Succeeded");
                Assert.True(resultGet.State == "Succeeded");

                // Update the server and confirm the updates make it in.
                Dictionary<string, string> updatedTags = new Dictionary<string, string>
                    {
                        {"updated1","value1"}
                    };

                var updatedAdministrators = AnalysisServicesTestUtilities.DefaultAdministrators;
                updatedAdministrators.Add("aztest2@stabletest.ccsctp.net");

                var newSku = resultGet.Sku;
                AnalysisServicesServerUpdateParameters updateParameters = new AnalysisServicesServerUpdateParameters()
                {
                    Sku = newSku,
                    Tags = updatedTags,
                    AsAdministrators = new ServerAdministrators(updatedAdministrators),
                    BackupBlobContainerUri = AnalysisServicesTestUtilities.UpdatedBackupBlobContainerUri,
                    QuerypoolConnectionMode= ConnectionMode.ReadOnly
                };

                AnalysisServicesServer resultUpdate = null;
                try
                {
                    resultUpdate =
                        client.Servers.Update(
                                AnalysisServicesTestUtilities.DefaultResourceGroup,
                                AnalysisServicesTestUtilities.DefaultServerName,
                                updateParameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                Assert.Equal("Succeeded", resultUpdate.State);

                // get the server and ensure that all the values are properly set.
                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.Equal(1, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("updated1"));
                Assert.Equal(3, resultGet.AsAdministrators.Members.Count);
                Assert.Equal(AnalysisServicesTestUtilities.UpdatedBackupBlobContainerUri.Split('?')[0], resultGet.BackupBlobContainerUri);
                Assert.Equal(ConnectionMode.ReadOnly, resultGet.QuerypoolConnectionMode);

                // Create another server and ensure that list account returns both
                var secondServer = AnalysisServicesTestUtilities.DefaultServerName + '2';
                resultCreate =  client.Servers.Create(
                                    AnalysisServicesTestUtilities.DefaultResourceGroup,
                                    secondServer,
                                    analysisServicesServer);

                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                var listResponse = client.Servers.List();

                // Assert that there are at least two servers in the list
                Assert.True(listResponse.Count() >= 2);

                // now list by resource group:
                listResponse = client.Servers.ListByResourceGroup(AnalysisServicesTestUtilities.DefaultResourceGroup);

                // Assert that there are at least two servers in the list
                Assert.True(listResponse.Count() >= 2);

                // Suspend the server and confirm that it is deleted.
                client.Servers.Suspend(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                // get the server and ensure that all the values are properly set.
                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                Assert.Equal("Paused", resultGet.ProvisioningState);
                Assert.Equal("Paused", resultGet.State);

                // Suspend the server and confirm that it is deleted.
                client.Servers.Resume(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                // get the server and ensure that all the values are properly set.
                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, secondServer);

                Assert.Equal("Succeeded", resultGet.ProvisioningState);
                Assert.Equal("Succeeded", resultGet.State);

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
                Assert.True(listResponse.Count() >= 0);
            }
        }

        [Fact]
        public void ScaleUpTest()
        {
            string executingAssemblyPath = typeof(AnalysisServices.Tests.ScenarioTests.ServerOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetAnalysisServicesClient(context);

                AnalysisServicesServer analysisServicesServer = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();

                SkuEnumerationForNewResourceResult skusListForNew = client.Servers.ListSkusForNew();
                analysisServicesServer.Sku = skusListForNew.Value.First();

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Assert.Equal(resultCreate.ProvisioningState, "Succeeded");
                Assert.Equal(resultCreate.State, "Succeeded");

                // get the server and ensure that all the values are properly set.
                var resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.NotEmpty(resultGet.ServerFullName);
                Assert.Equal(analysisServicesServer.Sku.Name, resultGet.Sku.Name);
                Assert.Equal(1, resultGet.Sku.Capacity);
                Assert.Equal(2, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(2, resultGet.AsAdministrators.Members.Count);
                Assert.Equal("Microsoft.AnalysisServices/servers", resultGet.Type);
                Assert.Equal(ConnectionMode.All, resultGet.QuerypoolConnectionMode);

                // Confirm that the server creation did succeed
                Assert.True(resultGet.ProvisioningState == "Succeeded");
                Assert.True(resultGet.State == "Succeeded");

                // Scale up the server and verify
                SkuEnumerationForExistingResourceResult skusListForExisting = client.Servers.ListSkusForExisting(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);
                ResourceSku newSku = skusListForExisting.Value.Where(detail => detail.Sku.Name != analysisServicesServer.Sku.Name).First().Sku;
                
                AnalysisServicesServerUpdateParameters updateParameters = new AnalysisServicesServerUpdateParameters()
                {
                    Sku = newSku,
                };

                var resultUpdate = client.Servers.Update(
                    AnalysisServicesTestUtilities.DefaultResourceGroup,
                    AnalysisServicesTestUtilities.DefaultServerName,
                    updateParameters);

                Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                Assert.Equal("Succeeded", resultUpdate.State);

                // get the server and ensure that all the values are properly set.
                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.NotEmpty(resultGet.ServerFullName);
                Assert.Equal(newSku.Name, resultGet.Sku.Name);
                Assert.Equal(newSku.Tier, resultGet.Sku.Tier);
                Assert.Equal(2, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(2, resultGet.AsAdministrators.Members.Count);
                Assert.Equal("Microsoft.AnalysisServices/servers", resultGet.Type);
                
                // delete the server with its old name, which should also succeed.
                client.Servers.Delete(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);
            }
        }

        [Fact]
        public void ScaleOutTest()
        {
            string executingAssemblyPath = typeof(AnalysisServices.Tests.ScenarioTests.ServerOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetAnalysisServicesClient(context);

                try
                {
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    Assert.Equal(resultCreate.ProvisioningState, "Succeeded");
                    Assert.Equal(resultCreate.State, "Succeeded");

                    // get the server and ensure that all the values are properly set.
                    var resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                    // validate the server creation process
                    Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                    Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                    Assert.NotEmpty(resultGet.ServerFullName);
                    Assert.Equal(analysisServicesServer.Sku.Name, resultGet.Sku.Name);
                    Assert.Equal(1, resultGet.Sku.Capacity);
                    Assert.Equal(2, resultGet.Tags.Count);
                    Assert.True(resultGet.Tags.ContainsKey("key1"));
                    Assert.Equal(2, resultGet.AsAdministrators.Members.Count);
                    Assert.Equal("Microsoft.AnalysisServices/servers", resultGet.Type);
                    Assert.Equal(ConnectionMode.All, resultGet.QuerypoolConnectionMode);

                    // Confirm that the server creation did succeed
                    Assert.True(resultGet.ProvisioningState == "Succeeded");
                    Assert.True(resultGet.State == "Succeeded");

                    // Scale out from 1 to 2
                    ResourceSku newSku = resultGet.Sku;
                    newSku.Capacity = 2;

                    AnalysisServicesServerUpdateParameters updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        Sku = newSku
                    };

                    var resultUpdate = client.Servers.Update(
                        AnalysisServicesTestUtilities.DefaultResourceGroup,
                        AnalysisServicesTestUtilities.DefaultServerName,
                        updateParameters);

                    Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                    Assert.Equal("Succeeded", resultUpdate.State);

                    resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                    Assert.Equal(2, resultGet.Sku.Capacity);
                    Assert.Equal(ConnectionMode.All, resultGet.QuerypoolConnectionMode);

                    // Change connectionMode from All to ReadOnly
                    updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        QuerypoolConnectionMode = ConnectionMode.ReadOnly
                    };

                    resultUpdate = client.Servers.Update(
                        AnalysisServicesTestUtilities.DefaultResourceGroup,
                        AnalysisServicesTestUtilities.DefaultServerName,
                        updateParameters);

                    Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                    Assert.Equal("Succeeded", resultUpdate.State);

                    resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                    Assert.Equal(2, resultGet.Sku.Capacity);
                    Assert.Equal(ConnectionMode.ReadOnly, resultGet.QuerypoolConnectionMode);

                    // Scale in from 2 to 1
                    newSku = resultGet.Sku;
                    newSku.Capacity = 1;
                    updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        Sku = newSku,
                        QuerypoolConnectionMode = ConnectionMode.ReadOnly
                    };

                    resultUpdate = client.Servers.Update(
                        AnalysisServicesTestUtilities.DefaultResourceGroup,
                        AnalysisServicesTestUtilities.DefaultServerName,
                        updateParameters);

                    Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                    Assert.Equal("Succeeded", resultUpdate.State);

                    resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                    Assert.Equal(1, resultGet.Sku.Capacity);
                    Assert.Equal(ConnectionMode.ReadOnly, resultGet.QuerypoolConnectionMode);

                    // Change connectionMode from ReadOnly to all
                    updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        QuerypoolConnectionMode = ConnectionMode.All
                    };

                    resultUpdate = client.Servers.Update(
                        AnalysisServicesTestUtilities.DefaultResourceGroup,
                        AnalysisServicesTestUtilities.DefaultServerName,
                        updateParameters);

                    Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                    Assert.Equal("Succeeded", resultUpdate.State);

                    resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                    Assert.Equal(1, resultGet.Sku.Capacity);
                    Assert.Equal(ConnectionMode.All, resultGet.QuerypoolConnectionMode);

                    // Change scale out properties to non-default (capacity != 1, querypoolConnectionMode = ReadOnly)
                    newSku = resultGet.Sku;
                    newSku.Capacity = 2;
                    updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        Sku = newSku,
                        QuerypoolConnectionMode = ConnectionMode.ReadOnly
                    };

                    resultUpdate = client.Servers.Update(
                        AnalysisServicesTestUtilities.DefaultResourceGroup,
                        AnalysisServicesTestUtilities.DefaultServerName,
                        updateParameters);

                    Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                    Assert.Equal("Succeeded", resultUpdate.State);

                    resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                    Assert.Equal(2, resultGet.Sku.Capacity);
                    Assert.Equal(ConnectionMode.ReadOnly, resultGet.QuerypoolConnectionMode);

                    // Scale from S1 to S0 to verify that scale out properties are preserved
                    newSku = resultGet.Sku;
                    newSku.Name = "S0";
                    updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        Sku = newSku,
                        QuerypoolConnectionMode = ConnectionMode.ReadOnly
                    };

                    resultUpdate = client.Servers.Update(
                        AnalysisServicesTestUtilities.DefaultResourceGroup,
                        AnalysisServicesTestUtilities.DefaultServerName,
                        updateParameters);

                    Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                    Assert.Equal("Succeeded", resultUpdate.State);

                    resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                    Assert.Equal("S0", resultGet.Sku.Name);
                    Assert.Equal(2, resultGet.Sku.Capacity);
                    Assert.Equal(ConnectionMode.ReadOnly, resultGet.QuerypoolConnectionMode);
                }
                finally
                {
                    // delete the server with its old name, which should also succeed.
                    client.Servers.Delete(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);
                }
            }
        }

        [Fact]
        public void ScaleOutThrowsExceptionForNonStandardSkuTest()
        {
            string executingAssemblyPath = typeof(AnalysisServices.Tests.ScenarioTests.ServerOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetAnalysisServicesClient(context);

                SkuEnumerationForExistingResourceResult skusListForExisting = client.Servers.ListSkusForExisting(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);
                ResourceSku newSku = skusListForExisting.Value.First(detail => detail.Sku.Tier != "Standard").Sku;
                newSku.Capacity = 2;

                var parameters = AnalysisServicesTestUtilities.GetDefaultAnalysisServicesResource();
                parameters.Sku = newSku;

                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => client.Servers.Create(
                    AnalysisServicesTestUtilities.DefaultResourceGroup,
                    AnalysisServicesTestUtilities.DefaultServerName,
                    parameters));
            }
        }
    }
}
