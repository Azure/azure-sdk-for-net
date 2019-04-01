
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DedicatedServices.Tests.Helpers;
using Microsoft.Azure;
using Microsoft.Azure.Management.PowerBIDedicated;
using Microsoft.Azure.Management.PowerBIDedicated.Models;
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

namespace PowerBIDedicated.Tests.ScenarioTests
{
    public class CapacityOperationsTests : TestBase
    {
        [Fact]
        public void CreateGetUpdateDeleteTest()
        {
            string executingAssemblyPath = typeof(PowerBIDedicated.Tests.ScenarioTests.CapacityOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetDedicatedServicesClient(context);

                DedicatedCapacity testCapacity = PowerBIDedicatedTestUtilities.GetDefaultDedicatedResource();
                DedicatedCapacity resultCreate = null;
                try
                {
                    // Create a test capacity
                    resultCreate =
                        client.Capacities.Create(
                            PowerBIDedicatedTestUtilities.DefaultResourceGroup,
                            PowerBIDedicatedTestUtilities.DefaultCapacityName,
                            testCapacity);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Assert.Equal("Succeeded", resultCreate.ProvisioningState);
                Assert.Equal("Succeeded", resultCreate.State);

                // get the capacity and ensure that all the values are properly set.
                var resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);

                // validate the capacity creation process
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultCapacityName, resultGet.Name);
                Assert.Equal(2, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(2, resultGet.Administration.Members.Count);
                Assert.Equal("Microsoft.PowerBIDedicated/capacities", resultGet.Type);

                // Confirm that the capacity creation did succeed
                Assert.True(resultGet.ProvisioningState == "Succeeded");
                Assert.True(resultGet.State == "Succeeded");

                // Update the capacity and confirm the updates make it in.
                Dictionary<string, string> updatedTags = new Dictionary<string, string>
                    {
                        {"updated1","value1"}
                    };

                var updatedAdministrators = PowerBIDedicatedTestUtilities.DefaultAdministrators;
                updatedAdministrators.Add("aztest2@stabletest.ccsctp.net");

                DedicatedCapacityUpdateParameters updateParameters = new DedicatedCapacityUpdateParameters()
                {
                    Sku = resultGet.Sku,
                    Tags = updatedTags,
                    Administration = new DedicatedCapacityAdministrators(updatedAdministrators),
                };

                DedicatedCapacity resultUpdate = null;
                try
                {
                    resultUpdate =
                        client.Capacities.Update(
                                PowerBIDedicatedTestUtilities.DefaultResourceGroup,
                                PowerBIDedicatedTestUtilities.DefaultCapacityName,
                                updateParameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                Assert.Equal("Succeeded", resultUpdate.State);

                // get the capacity and ensure that all the values are properly set.
                resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);

                // validate the capacity creation process
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultCapacityName, resultGet.Name);
                Assert.Equal(1, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("updated1"));
                Assert.Equal(3, resultGet.Administration.Members.Count);

                // Create another capacity and ensure that list account returns both
                var secondCapacity = PowerBIDedicatedTestUtilities.DefaultCapacityName + '2';
                resultCreate = client.Capacities.Create(
                                    PowerBIDedicatedTestUtilities.DefaultResourceGroup,
                                    secondCapacity,
                                    testCapacity);

                resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, secondCapacity);

                var listResponse = client.Capacities.List();

                // Assert that there are at least two capacities in the list
                Assert.True(listResponse.Count() >= 2);

                // now list by resource group:
                listResponse = client.Capacities.ListByResourceGroup(PowerBIDedicatedTestUtilities.DefaultResourceGroup);

                // Assert that there are at least two capacities in the list
                Assert.True(listResponse.Count() >= 2);

                // Suspend the capacity and confirm that it is deleted.
                client.Capacities.Suspend(PowerBIDedicatedTestUtilities.DefaultResourceGroup, secondCapacity);

                // get the capacity and ensure that all the values are properly set.
                resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, secondCapacity);

                Assert.Equal("Paused", resultGet.ProvisioningState);
                Assert.Equal("Paused", resultGet.State);

                // Suspend the capacity and confirm that it is deleted.
                client.Capacities.Resume(PowerBIDedicatedTestUtilities.DefaultResourceGroup, secondCapacity);

                // get the capacity and ensure that all the values are properly set.
                resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, secondCapacity);

                Assert.Equal("Succeeded", resultGet.ProvisioningState);
                Assert.Equal("Succeeded", resultGet.State);

                // Delete the servcapacityer and confirm that it is deleted.
                client.Capacities.Delete(PowerBIDedicatedTestUtilities.DefaultResourceGroup, secondCapacity);

                // delete the capacity again and make sure it continues to result in a succesful code.
                client.Capacities.Delete(PowerBIDedicatedTestUtilities.DefaultResourceGroup, secondCapacity);

                // delete the capacity with its old name, which should also succeed.
                client.Capacities.Delete(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);

                // test that the capacity is gone
                // now list by resource group:
                listResponse = client.Capacities.ListByResourceGroup(PowerBIDedicatedTestUtilities.DefaultResourceGroup);

                // Assert that there are at least two accounts in the list
                Assert.True(listResponse.Count() >= 0);
            }
        }

        [Fact]
        public void ScaleUpTest()
        {
            string executingAssemblyPath = typeof(PowerBIDedicated.Tests.ScenarioTests.CapacityOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetDedicatedServicesClient(context);

                DedicatedCapacity testCapacity = PowerBIDedicatedTestUtilities.GetDefaultDedicatedResource();

                SkuEnumerationForNewResourceResult skusListForNew = client.Capacities.ListSkus();
                testCapacity.Sku = skusListForNew.Value.Where(val => val.Name == "A1").First() ;
                if (testCapacity.Sku == null) skusListForNew.Value.First();

                DedicatedCapacity resultCreate = null;
                try
                {
                    // Create a test capacity
                    resultCreate =
                        client.Capacities.Create(
                            PowerBIDedicatedTestUtilities.DefaultResourceGroup,
                            PowerBIDedicatedTestUtilities.DefaultCapacityName,
                            testCapacity);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Assert.Equal("Succeeded", resultCreate.ProvisioningState);
                Assert.Equal("Succeeded", resultCreate.State);

                // get the capacity and ensure that all the values are properly set.
                var resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);

                // validate the capacity creation process
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultCapacityName, resultGet.Name);
                Assert.Equal(testCapacity.Sku.Name, resultGet.Sku.Name);
                Assert.Equal(2, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(2, resultGet.Administration.Members.Count);

                // Confirm that the capacity creation did succeed
                Assert.True(resultGet.ProvisioningState == "Succeeded");
                Assert.True(resultGet.State == "Succeeded");

                // Scale up the capacity and verify
                SkuEnumerationForExistingResourceResult skusListForExisting = client.Capacities.ListSkusForCapacity(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);
                ResourceSku newSku = skusListForExisting.Value.Where(detail => detail.Sku.Name != testCapacity.Sku.Name && detail.Sku.Name.StartsWith("A")).First().Sku;

                DedicatedCapacityUpdateParameters updateParameters = new DedicatedCapacityUpdateParameters()
                {
                    Sku = newSku
                };

                var resultUpdate = client.Capacities.Update(
                    PowerBIDedicatedTestUtilities.DefaultResourceGroup,
                    PowerBIDedicatedTestUtilities.DefaultCapacityName,
                    updateParameters);

                Assert.Equal("Succeeded", resultUpdate.ProvisioningState);
                Assert.Equal("Succeeded", resultUpdate.State);

                // Suspend the capacity
                client.Capacities.Suspend(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);

                // get the capacity and ensure that all the values are properly set.
                resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);

                Assert.Equal("Paused", resultGet.ProvisioningState);
                Assert.Equal("Paused", resultGet.State);

                updateParameters = new DedicatedCapacityUpdateParameters()
                {
                    Sku = testCapacity.Sku
                };

                resultUpdate = client.Capacities.Update(
                    PowerBIDedicatedTestUtilities.DefaultResourceGroup,
                    PowerBIDedicatedTestUtilities.DefaultCapacityName,
                    updateParameters);

                Assert.Equal("Paused", resultUpdate.ProvisioningState);
                Assert.Equal("Paused", resultUpdate.State);

                // get the capacity and ensure that all the values are properly set.
                resultGet = client.Capacities.GetDetails(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);

                // validate the capacity creation process
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultLocation, resultGet.Location);
                Assert.Equal(PowerBIDedicatedTestUtilities.DefaultCapacityName, resultGet.Name);
                Assert.Equal(testCapacity.Sku.Name, resultGet.Sku.Name);
                Assert.Equal(2, resultGet.Tags.Count);
                Assert.True(resultGet.Tags.ContainsKey("key1"));
                Assert.Equal(2, resultGet.Administration.Members.Count);

                // delete the capacity with its old name, which should also succeed.
                client.Capacities.Delete(PowerBIDedicatedTestUtilities.DefaultResourceGroup, PowerBIDedicatedTestUtilities.DefaultCapacityName);
            }
        }

        [Fact]
        public void OperationsTest()
        {
            string executingAssemblyPath = typeof(PowerBIDedicated.Tests.ScenarioTests.CapacityOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetDedicatedServicesClient(context);

                DedicatedCapacity testCapacity = PowerBIDedicatedTestUtilities.GetDefaultDedicatedResource();

                try
                {
                    // Create a test capacity
                    var resultOperationsList = client.Operations.List();

                    // validate the opertaions result
                    Assert.Equal(16, resultOperationsList.Count());

                    var opertationsPageLink = "https://api-dogfood.resources.windows-int.net/providers/Microsoft.PowerBIDedicated/operations?api-version=2017-10-01";
                    var resultOperationsNextPage = client.Operations.ListNext(opertationsPageLink);

                    // validate the opertaions result
                    Assert.Equal(16, resultOperationsNextPage.Count());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
