// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Models;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class ContainerAppCollectionTests: AppContainersManagementTestBase
    {
        public ContainerAppCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg", AzureLocation.WestUS);
            string envName = Recording.GenerateAssetName("env");
            ContainerAppManagedEnvironmentData data = new ContainerAppManagedEnvironmentData(AzureLocation.WestUS)
            {
                WorkloadProfiles =
                {
                    new ContainerAppWorkloadProfile("Consumption", "Consumption"),
                    new ContainerAppWorkloadProfile("gp1", "D4")
                    {
                        MinimumCount = 1,
                        MaximumCount = 3
                    }
                }
            };

            var containerAppManagedEnvironmentCollection = rg.GetContainerAppManagedEnvironments();
            var envResource = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, data);
            Assert.AreEqual(envName, envResource.Value.Data.Name);

            string resourceName = Recording.GenerateAssetName("resource");
            ContainerAppData appData = new ContainerAppData(AzureLocation.WestUS)
            {
                WorkloadProfileName = "gp1",
                ManagedEnvironmentId = new ResourceIdentifier(envResource.Value.Data.Id),
                Configuration = new ContainerAppConfiguration
                {
                    Ingress = new ContainerAppIngressConfiguration
                    {
                        External = true,
                        TargetPort = 3000
                    },
                },
                Template = new ContainerAppTemplate
                {
                    Containers =
                        {
                            new ContainerAppContainer
                            {
                                Image = $"mcr.microsoft.com/k8se/quickstart-jobs:latest",
                                Name = "appcontainer",
                                Resources = new AppContainerResources
                                {
                                    Cpu = 0.25,
                                    Memory = "0.5Gi"
                                }
                            }
                        },
                    Scale = new ContainerAppScale
                    {
                        MinReplicas = 1,
                        MaxReplicas = 5,
                        Rules =
                            {
                                new ContainerAppScaleRule
                                {
                                    Name = "httpscale",
                                    Custom = new ContainerAppCustomScaleRule
                                    {
                                        CustomScaleRuleType = "http",
                                        Metadata =
                                        {
                                            { "concurrentRequests", "50" }
                                        }
                                    }
                                }
                            }
                    },
                }
            };

            // Create
            var ContainerAppCollection = rg.GetContainerApps();
            var resource = await ContainerAppCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, appData);
            Assert.AreEqual(resourceName, resource.Value.Data.Name);

            // Exists
            var result = await ContainerAppCollection.ExistsAsync(resourceName);
            Assert.IsTrue(result);

            // Get
            var getResult = await ContainerAppCollection.GetAsync(resourceName);
            Assert.AreEqual(resourceName, getResult.Value.Data.Name);

            // List
            var listResult = await ContainerAppCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(listResult);
            Assert.AreEqual(listResult[0].Data.Name, resourceName);

            // Delete
            await resource.Value.DeleteAsync(WaitUntil.Completed);
            result = await ContainerAppCollection.ExistsAsync(resourceName);
            Assert.IsFalse(result);
        }
    }
}
