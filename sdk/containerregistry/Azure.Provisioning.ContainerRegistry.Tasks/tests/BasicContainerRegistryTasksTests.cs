// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ContainerRegistry;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;
using AsyncTask = System.Threading.Tasks.Task;

namespace Azure.Provisioning.ContainerRegistry.Tasks.Tests;

public class BasicContainerRegistryTasksTests
{
    internal static Trycep CreateTaskTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ContainerRegistryTaskBasic
                Infrastructure infra = new();

                ContainerRegistryService registry =
                    new(nameof(registry), ContainerRegistryService.ResourceVersions.V2023_07_01)
                    {
                        Name = BicepFunction.Take(BicepFunction.Interpolate($"registry{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}"), 50),
                        Sku = new ContainerRegistrySku { Name = ContainerRegistrySkuName.Standard },
                    };
                infra.Add(registry);

                ContainerRegistryTask task =
                    new(nameof(task), ContainerRegistryTask.ResourceVersions.V2025_03_01_PREVIEW)
                    {
                        Name = BicepFunction.Interpolate($"{registry.Name}/build"),
                        Status = ContainerRegistryTaskStatus.Enabled,
                        Platform = new ContainerRegistryTaskPlatformProperties
                        {
                            OS = ContainerRegistryTaskOS.Linux,
                        },
                        Step = new DockerBuildStep
                        {
                            ContextPath = "https://github.com/Azure-Samples/acr-tasks.git",
                            DockerFilePath = "Dockerfile",
                            ImageNames = { "sample:{{.Run.ID}}" },
                            IsPushEnabled = true,
                        },
                    };
                infra.Add(task);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.resources/deployment-script-azcli-acr-build/main.bicep")]
    public async AsyncTask CreateTask()
    {
        await using Trycep test = CreateTaskTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource registry 'Microsoft.ContainerRegistry/registries@2023-07-01' = {
              name: take('registry${uniqueString(resourceGroup().id)}', 50)
              location: location
              sku: {
                name: 'Standard'
              }
            }

            resource task 'Microsoft.ContainerRegistry/registries/tasks@2025-03-01-preview' = {
              name: '${take('registry${uniqueString(resourceGroup().id)}', 50)}/build'
              location: location
              properties: {
                status: 'Enabled'
                platform: {
                  os: 'Linux'
                }
                step: {
                  contextPath: 'https://github.com/Azure-Samples/acr-tasks.git'
                  type: 'Docker'
                  imageNames: [
                    'sample:{{.Run.ID}}'
                  ]
                  isPushEnabled: true
                  dockerFilePath: 'Dockerfile'
                }
              }
            }
            """);
    }
}
