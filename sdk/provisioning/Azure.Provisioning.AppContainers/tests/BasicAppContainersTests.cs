// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.OperationalInsights;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppContainers.Tests;

public class BasicAppContainersTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.app/container-app-create/main.bicep")]
    public async Task CreateContainerApp()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "Service location.";

                BicepParameter containerImage = BicepParameter.Create<string>(nameof(containerImage), "mcr.microsoft.com/azuredocs/containerapps-helloworld:latest");
                containerImage.Description = "Specifies the docker container image to deploy.";

                OperationalInsightsWorkspace logAnalytics =
                    new(nameof(logAnalytics))
                    {
                        Location = location,
                        Sku = new OperationalInsightsWorkspaceSku { Name = OperationalInsightsWorkspaceSkuName.PerGB2018 }
                    };

                ContainerAppManagedEnvironment env =
                    new(nameof(env))
                    {
                        Location = location,
                        AppLogsConfiguration =
                            new ContainerAppLogsConfiguration
                            {
                                Destination = "log-analytics",
                                LogAnalyticsConfiguration = new ContainerAppLogAnalyticsConfiguration
                                {
                                    CustomerId = logAnalytics.CustomerId,
                                    SharedKey = logAnalytics.GetKeys().PrimarySharedKey,
                                }
                            },
                    };

                ContainerApp app =
                    new(nameof(app))
                    {
                        Location = location,
                        ManagedEnvironmentId = env.Id,
                        Configuration =
                            new ContainerAppConfiguration
                            {
                                Ingress =
                                    new ContainerAppIngressConfiguration
                                    {
                                        External = true,
                                        TargetPort = 80,
                                        AllowInsecure = false,
                                        Traffic =
                                        {
                                            new ContainerAppRevisionTrafficWeight
                                            {
                                                IsLatestRevision = true,
                                                Weight = 100
                                            }
                                        }
                                    },
                            },
                        Template =
                            new ContainerAppTemplate
                            {
                                RevisionSuffix = "firstrevision",
                                Scale = new ContainerAppScale { MinReplicas = 1, MaxReplicas = 3 },
                                Containers =
                                {
                                    new ContainerAppContainer
                                    {
                                        Name = "test",
                                        Image = containerImage,
                                        Resources =
                                            new AppContainerResources
                                            {
                                                Cpu = new BicepValue<double>(BicepFunction.ParseJson("0.5").Expression!),
                                                Memory = "1Gi"
                                            }
                                    }
                                }
                            }
                    };
            })
        .Compare(
            """
            @description('Service location.')
            param location string = resourceGroup().location

            @description('Specifies the docker container image to deploy.')
            param containerImage string = 'mcr.microsoft.com/azuredocs/containerapps-helloworld:latest'

            resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
                name: take('logAnalytics-${uniqueString(resourceGroup().id)}', 63)
                location: location
                properties: {
                    sku: {
                        name: 'PerGB2018'
                    }
                }
            }

            resource env 'Microsoft.App/managedEnvironments@2023-05-01' = {
                name: take('env${uniqueString(resourceGroup().id)}', 24)
                location: location
                properties: {
                    appLogsConfiguration: {
                        destination: 'log-analytics'
                        logAnalyticsConfiguration: {
                            customerId: logAnalytics.properties.customerId
                            sharedKey: logAnalytics.listKeys().primarySharedKey
                        }
                    }
                }
            }

            resource app 'Microsoft.App/containerApps@2023-05-01' = {
                name: take('app-${uniqueString(resourceGroup().id)}', 32)
                location: location
                properties: {
                    configuration: {
                        ingress: {
                            external: true
                            targetPort: 80
                            traffic: [
                                {
                                    weight: 100
                                    latestRevision: true
                                }
                            ]
                            allowInsecure: false
                        }
                    }
                    managedEnvironmentId: env.id
                    template: {
                        revisionSuffix: 'firstrevision'
                        containers: [
                            {
                                image: containerImage
                                name: 'test'
                                resources: {
                                    cpu: json('0.5')
                                    memory: '1Gi'
                                }
                            }
                        ]
                        scale: {
                            minReplicas: 1
                            maxReplicas: 3
                        }
                    }
                }
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
