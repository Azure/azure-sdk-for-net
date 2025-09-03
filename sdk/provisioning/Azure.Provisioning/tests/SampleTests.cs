// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.AppContainers;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.ContainerRegistry;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.OperationalInsights;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Roles;
using Azure.Provisioning.Storage;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Provisioning.Tests;

internal class SampleTests
{
    internal static Trycep CreateSimpleDeployTest()
    {
        return new Trycep()
            .Define(
                ctx =>
                {
                    #region Snippet:ProvisioningBasic
                    Infrastructure infra = new();

                    // Create a storage account and blob resources
                    StorageAccount storage =
                        new(nameof(storage), StorageAccount.ResourceVersions.V2023_01_01)
                        {
                            Kind = StorageKind.StorageV2,
                            Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
                            IsHnsEnabled = true,
                            AllowBlobPublicAccess = false
                        };
                    infra.Add(storage);
                    BlobService blobs = new(nameof(blobs)) { Parent = storage };
                    infra.Add(blobs);

                    // Grab the endpoint
                    ProvisioningOutput endpoint = new ProvisioningOutput("blobs_endpoint", typeof(string)) { Value = storage.PrimaryEndpoints.BlobUri };
                    infra.Add(endpoint);
                    #endregion

                    return infra;
                });
    }

    [Test]
    public async Task SimpleDeploy()
    {
        await using Trycep test = CreateSimpleDeployTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
              name: take('storage${uniqueString(resourceGroup().id)}', 24)
              kind: 'StorageV2'
              location: location
              sku: {
                name: 'Standard_LRS'
              }
              properties: {
                allowBlobPublicAccess: false
                isHnsEnabled: true
              }
            }

            resource blobs 'Microsoft.Storage/storageAccounts/blobServices@2024-01-01' = {
              name: 'default'
              parent: storage
            }

            output blobs_endpoint string = storage.properties.primaryEndpoints.blob
            """);
    }

    internal static Trycep CreateSimpleContainerAppTest()
    {
        return new Trycep()
            .Define(
                ctx =>
                {
                    #region Snippet:ProvisioningContainerApp
                    Infrastructure infra = new();

                    ProvisioningParameter principalId = new(nameof(principalId), typeof(string)) { Value = "" };
                    infra.Add(principalId);

                    ProvisioningParameter tags = new(nameof(tags), typeof(object)) { Value = new BicepDictionary<string>() };
                    infra.Add(tags);

                    UserAssignedIdentity mi =
                        new(nameof(mi), UserAssignedIdentity.ResourceVersions.V2023_01_31)
                        {
                            Tags = tags,
                        };
                    infra.Add(mi);

                    ContainerRegistryService acr =
                        new(nameof(acr), ContainerRegistryService.ResourceVersions.V2023_07_01)
                        {
                            Sku = new ContainerRegistrySku() { Name = ContainerRegistrySkuName.Basic },
                            Tags = tags,
                            Identity =
                                new ManagedServiceIdentity
                                {
                                    ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssignedUserAssigned,
                                    UserAssignedIdentities =
                                    {
                                        // TODO: Decide if we want to invest in a less janky way to use expressions as keys
                                        { BicepFunction.Interpolate($"{mi.Id}").Compile().ToString(), new UserAssignedIdentityDetails() }
                                    }
                                }
                        };
                    infra.Add(acr);

                    RoleAssignment pullAssignment = acr.CreateRoleAssignment(ContainerRegistryBuiltInRole.AcrPull, mi);
                    infra.Add(pullAssignment);

                    OperationalInsightsWorkspace law =
                        new(nameof(law), OperationalInsightsWorkspace.ResourceVersions.V2023_09_01)
                        {
                            Sku = new OperationalInsightsWorkspaceSku() { Name = OperationalInsightsWorkspaceSkuName.PerGB2018 },
                            Tags = tags,
                        };
                    infra.Add(law);

                    ContainerAppManagedEnvironment cae =
                        new(nameof(cae), ContainerAppManagedEnvironment.ResourceVersions.V2024_03_01)
                        {
                            WorkloadProfiles =
                            {
                                new ContainerAppWorkloadProfile()
                                {
                                    Name = "consumption",
                                    WorkloadProfileType = "Consumption"
                                }
                            },
                            AppLogsConfiguration =
                                new ContainerAppLogsConfiguration()
                                {
                                    Destination = "log-analytics",
                                    LogAnalyticsConfiguration = new ContainerAppLogAnalyticsConfiguration()
                                    {
                                        CustomerId = law.CustomerId,
                                        SharedKey = law.GetKeys().PrimarySharedKey,
                                    }
                                },
                            Tags = tags,
                        };
                    infra.Add(cae);

                    RoleAssignment contribAssignment = cae.CreateRoleAssignment(AppContainersBuiltInRole.Contributor, mi);
                    infra.Add(contribAssignment);

                    // Hack in the Aspire Dashboard as a literal since there's no
                    // management plane library support for dotNetComponents yet
                    BicepLiteral aspireDashboard =
                        new(
                            new ResourceStatement(
                                "aspireDashboard",
                                new StringLiteralExpression("Microsoft.App/managedEnvironments/dotNetComponents@2024-02-02-preview"),
                                new ObjectExpression(
                                    new PropertyExpression("name", "aspire-dashboard"),
                                    new PropertyExpression("parent", new IdentifierExpression(cae.BicepIdentifier)),
                                    new PropertyExpression("properties",
                                        new ObjectExpression(
                                            new PropertyExpression("componentType", new StringLiteralExpression("AspireDashboard")))))));
                    infra.Add(aspireDashboard);

                    infra.Add(new ProvisioningOutput("MANAGED_IDENTITY_CLIENT_ID", typeof(string)) { Value = mi.ClientId });
                    infra.Add(new ProvisioningOutput("MANAGED_IDENTITY_NAME", typeof(string)) { Value = mi.Name });
                    infra.Add(new ProvisioningOutput("MANAGED_IDENTITY_PRINCIPAL_ID", typeof(string)) { Value = mi.PrincipalId });
                    infra.Add(new ProvisioningOutput("LOG_ANALYTICS_WORKSPACE_NAME", typeof(string)) { Value = law.Name });
                    infra.Add(new ProvisioningOutput("LOG_ANALYTICS_WORKSPACE_ID", typeof(string)) { Value = law.Id });
                    infra.Add(new ProvisioningOutput("AZURE_CONTAINER_REGISTRY_ENDPOINT", typeof(string)) { Value = acr.LoginServer });
                    infra.Add(new ProvisioningOutput("AZURE_CONTAINER_REGISTRY_MANAGED_IDENTITY_ID", typeof(string)) { Value = mi.Id });
                    infra.Add(new ProvisioningOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_NAME", typeof(string)) { Value = cae.Name });
                    infra.Add(new ProvisioningOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_ID", typeof(string)) { Value = cae.Id });
                    infra.Add(new ProvisioningOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_DEFAULT_DOMAIN", typeof(string)) { Value = cae.DefaultDomain });
                    #endregion

                    return infra;
                });
    }

    [Test]
    public async Task SimpleContainerApp()
    {
        await using Trycep test = CreateSimpleContainerAppTest();
        test.Compare(
            """
            param principalId string = ''

            param tags object = { }

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource mi 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
              name: take('mi-${uniqueString(resourceGroup().id)}', 128)
              location: location
              tags: tags
            }

            resource acr 'Microsoft.ContainerRegistry/registries@2023-07-01' = {
              name: take('acr${uniqueString(resourceGroup().id)}', 50)
              location: location
              sku: {
                name: 'Basic'
              }
              identity: {
                type: 'SystemAssigned, UserAssigned'
                userAssignedIdentities: {
                  '${mi.id}': { }
                }
              }
              tags: tags
            }

            resource acr_mi_AcrPull 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
              name: guid(acr.id, mi.properties.principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d'))
              properties: {
                principalId: mi.properties.principalId
                roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d')
                principalType: 'ServicePrincipal'
              }
              scope: acr
            }

            resource law 'Microsoft.OperationalInsights/workspaces@2023-09-01' = {
              name: take('law-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                sku: {
                  name: 'PerGB2018'
                }
              }
              tags: tags
            }

            resource cae 'Microsoft.App/managedEnvironments@2024-03-01' = {
              name: take('cae${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                appLogsConfiguration: {
                  destination: 'log-analytics'
                  logAnalyticsConfiguration: {
                    customerId: law.properties.customerId
                    sharedKey: law.listKeys().primarySharedKey
                  }
                }
                workloadProfiles: [
                  {
                    name: 'consumption'
                    workloadProfileType: 'Consumption'
                  }
                ]
              }
              tags: tags
            }

            resource cae_mi_Contributor 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
              name: guid(cae.id, mi.properties.principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'b24988ac-6180-42a0-ab88-20f7382dd24c'))
              properties: {
                principalId: mi.properties.principalId
                roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'b24988ac-6180-42a0-ab88-20f7382dd24c')
                principalType: 'ServicePrincipal'
              }
              scope: cae
            }

            resource aspireDashboard 'Microsoft.App/managedEnvironments/dotNetComponents@2024-02-02-preview' = {
              name: 'aspire-dashboard'
              parent: cae
              properties: {
                componentType: 'AspireDashboard'
              }
            }

            output MANAGED_IDENTITY_CLIENT_ID string = mi.properties.clientId

            output MANAGED_IDENTITY_NAME string = mi.name

            output MANAGED_IDENTITY_PRINCIPAL_ID string = mi.properties.principalId

            output LOG_ANALYTICS_WORKSPACE_NAME string = law.name

            output LOG_ANALYTICS_WORKSPACE_ID string = law.id

            output AZURE_CONTAINER_REGISTRY_ENDPOINT string = acr.properties.loginServer

            output AZURE_CONTAINER_REGISTRY_MANAGED_IDENTITY_ID string = mi.id

            output AZURE_CONTAINER_APPS_ENVIRONMENT_NAME string = cae.name

            output AZURE_CONTAINER_APPS_ENVIRONMENT_ID string = cae.id

            output AZURE_CONTAINER_APPS_ENVIRONMENT_DEFAULT_DOMAIN string = cae.properties.defaultDomain
            """);
    }

    internal static Trycep CreateSimpleResourceGroupTest()
    {
        return new Trycep()
            .Define(
                ctx =>
                {
                    #region Snippet:ProvisioningResourceGroup
                    // Create a new infra group scoped to our subscription and add
                    // the resource group
                    Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };
                    ResourceGroup rg = new("rg_test", "2024-03-01");
                    infra.Add(rg);
                    #endregion
                    return infra;
                });
    }

    [Test]
    public async Task SimpleResourceGroup()
    {
        await using Trycep test = CreateSimpleResourceGroupTest();
        test.Compare(
            """
            targetScope = 'subscription'

            @description('The location for the resource(s) to be deployed.')
            param location string = deployment().location

            resource rg_test 'Microsoft.Resources/resourceGroups@2024-03-01' = {
              name: take('rg_test-${uniqueString(deployment().id)}', 90)
              location: location
            }
            """);
    }
}
