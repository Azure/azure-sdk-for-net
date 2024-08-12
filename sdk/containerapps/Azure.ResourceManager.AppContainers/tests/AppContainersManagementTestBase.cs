// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Castle.Core.Resource;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppContainers.Tests
{
    public class AppContainersManagementTestBase : ManagementRecordedTestBase<AppContainersManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected AppContainersManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected AppContainersManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }

        protected async Task<ContainerAppManagedEnvironmentResource> CreateContainerAppManagedEnvironment(ResourceGroupResource resourceGroup, string envName)
        {
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
            var containerAppManagedEnvironmentCollection = resourceGroup.GetContainerAppManagedEnvironments();
            var envResource = await containerAppManagedEnvironmentCollection.CreateOrUpdateAsync(WaitUntil.Completed, envName, data);
            return envResource.Value;
        }

        protected async Task<ContainerAppResource> CreateContainerApp(ResourceGroupResource resourceGroup, ContainerAppManagedEnvironmentResource env,string containerAppName)
        {
            ContainerAppData appData = new ContainerAppData(AzureLocation.WestUS)
            {
                WorkloadProfileName = "gp1",
                ManagedEnvironmentId = new ResourceIdentifier(env.Data.Id),
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

            var ContainerAppCollection = resourceGroup.GetContainerApps();
            var containerApp = await ContainerAppCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerAppName, appData);
            return containerApp.Value;
        }
    }
}
