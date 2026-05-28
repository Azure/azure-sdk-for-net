// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.ContainerRegistry;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.ResourceManager.AppContainers.Models;

namespace Azure.ResourceManager.AppContainers.Tests
{
    internal class ContainerAppJobTests : AppContainersManagementTestBase
    {
        public ContainerAppJobTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroupAsync();

            // Create ContainerApp
            var envResource = await CreateContainerAppManagedEnvironment(resourceGroup, Recording.GenerateAssetName("env"));
            var containerApp = await CreateContainerApp(resourceGroup, envResource, Recording.GenerateAssetName("container"));

            // Create Container Registry
            string acrName = Recording.GenerateAssetName("acr");
            var registryData = new ContainerRegistryData(AzureLocation.WestUS, new ContainerRegistrySku(ContainerRegistrySkuName.Premium))
            {
                IsAdminUserEnabled = true,
                Sku = new ContainerRegistrySku(ContainerRegistrySkuName.Basic),
            };
            var lro = await resourceGroup.GetContainerRegistries().CreateOrUpdateAsync(WaitUntil.Completed, acrName, registryData);
            ContainerRegistryResource containerRegistry = lro.Value;

            // Craete ContainerAppJob
            string jobName = Recording.GenerateAssetName("job");
            ContainerAppJobData data = new ContainerAppJobData(AzureLocation.WestUS)
            {
                EnvironmentId = envResource.Id,
                Configuration = new Models.ContainerAppJobConfiguration(ContainerAppJobTriggerType.Manual,1800)
                {
                    Registries =
                    {
                        new ContainerAppRegistryCredentials()
                        {
                            Server = containerRegistry.Data.LoginServer,
                            Username = containerRegistry.Data.Name,
                            PasswordSecretRef = "reg-pswd-83dfdda0-b313"
                        }
                    },
                    Secrets =
                    {
                        new ContainerAppWritableSecret()
                        {
                            Name = "reg-pswd-83dfdda0-b313",
                            Value = "reg-pswd-83dfdda0-b313",
                        }
                    }
                },
                Template = new Models.ContainerAppJobTemplate()
                {
                    Containers =
                    {
                        new Models.ContainerAppContainer()
                        {
                            Image = $"{containerRegistry.Data.LoginServer}/image:tag",
                            Name = jobName,
                            Resources = new Models.AppContainerResources()
                            {
                                Cpu = 0.5,
                                Memory = "1Gi"
                            }
                        }
                    }
                }
            };
            var job = await resourceGroup.GetContainerAppJobs().CreateOrUpdateAsync(WaitUntil.Completed, jobName, data);
            await job.Value.StartAsync(WaitUntil.Completed);
            var executions = await job.Value.GetContainerAppJobExecutions().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(executions.FirstOrDefault().Data.StartOn);
            Assert.AreEqual(1, executions.FirstOrDefault().Data.Template.Containers.Count);
        }
    }
}
