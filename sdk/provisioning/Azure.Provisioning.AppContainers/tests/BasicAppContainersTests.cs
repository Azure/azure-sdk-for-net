// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.OperationalInsights;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AppContainers.Tests;

public class BasicAppContainersTests
{
    internal static Trycep CreateContainerAppTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AppContainerBasic
                Infrastructure infra = new();

                ProvisioningParameter containerImage =
                    new(nameof(containerImage), typeof(string))
                    {
                        Value = "mcr.microsoft.com/azuredocs/containerapps-helloworld:latest",
                        Description = "Specifies the docker container image to deploy."
                    };
                infra.Add(containerImage);

                OperationalInsightsWorkspace logAnalytics =
                    new(nameof(logAnalytics), OperationalInsightsWorkspace.ResourceVersions.V2023_09_01)
                    {
                        Sku = new OperationalInsightsWorkspaceSku { Name = OperationalInsightsWorkspaceSkuName.PerGB2018 }
                    };
                infra.Add(logAnalytics);

                ContainerAppManagedEnvironment env =
                    new(nameof(env), ContainerAppManagedEnvironment.ResourceVersions.V2024_03_01)
                    {
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
                infra.Add(env);

                ContainerApp app =
                    new(nameof(app), ContainerApp.ResourceVersions.V2024_03_01)
                    {
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
                                                Cpu = (BicepExpression?)BicepFunction.ParseJson("0.5"),
                                                Memory = "1Gi"
                                            }
                                    }
                                }
                            }
                    };
                infra.Add(app);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.app/container-app-create/main.bicep")]
    public async Task CreateContainerApp()
    {
        await using Trycep test = CreateContainerAppTest();
        test.Compare(
            """
            @description('Specifies the docker container image to deploy.')
            param containerImage string = 'mcr.microsoft.com/azuredocs/containerapps-helloworld:latest'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2023-09-01' = {
              name: take('logAnalytics-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                sku: {
                  name: 'PerGB2018'
                }
              }
            }

            resource env 'Microsoft.App/managedEnvironments@2024-03-01' = {
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

            resource app 'Microsoft.App/containerApps@2024-03-01' = {
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
            """);
    }
}
