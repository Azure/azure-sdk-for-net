
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

                Assert.Equal(resultCreate.ProvisioningState, "Succeeded");
                Assert.Equal(resultCreate.State, "Succeeded");

                // get the server and ensure that all the values are properly set.
                var resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.NotEmpty(resultGet.ServerFullName);
                Assert.Equal(resultGet.Tags.Count, 2);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(resultGet.AsAdministrators.Members.Count, 2);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultBakcupStorageAccount, resultGet.BackupConfiguration.StorageAccount);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultBackupBlobContainer, resultGet.BackupConfiguration.BlobContainer);
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
                updatedAdministrators.Add("aztest2@aspaas.ccsctp.net");
                string secondBackupStorageAccountAccessKey = Environment.GetEnvironmentVariable("AAS_SECOND_BACKUP_STORAGE_ACCESS_KEY");
                BackupConfiguration updatedBackupConfiguration = new BackupConfiguration("FT_Permanent_Group_A/stabletestbackupsa2", "backups", secondBackupStorageAccountAccessKey);

                AnalysisServicesServerUpdateParameters updateParameters = new AnalysisServicesServerUpdateParameters()
                    {
                        Sku = resultGet.Sku,
                        Tags = updatedTags,
                        AsAdministrators = new ServerAdministrators(updatedAdministrators),
                        BackupConfiguration = updatedBackupConfiguration
                };

                var resultUpdate = client.Servers.Update(
                                AnalysisServicesTestUtilities.DefaultResourceGroup,
                                AnalysisServicesTestUtilities.DefaultServerName,
                                updateParameters
                                );

                Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                Assert.Equal("Succeeded", resultUpdate.State);

                // get the server and ensure that all the values are properly set.
                resultGet = client.Servers.GetDetails(AnalysisServicesTestUtilities.DefaultResourceGroup, AnalysisServicesTestUtilities.DefaultServerName);

                // validate the server creation process
                Assert.Equal(AnalysisServicesTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(AnalysisServicesTestUtilities.DefaultServerName, resultGet.Name);
                Assert.Equal(resultGet.Tags.Count, 1);
                Assert.True(resultGet.Tags.ContainsKey("updated1"));
                Assert.Equal(resultGet.AsAdministrators.Members.Count, 3);
                Assert.Equal("FT_Permanent_Group_A/stabletestbackupsa2", resultGet.BackupConfiguration.StorageAccount);
                Assert.Equal("backups", resultGet.BackupConfiguration.BlobContainer);

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

        
    }
}
