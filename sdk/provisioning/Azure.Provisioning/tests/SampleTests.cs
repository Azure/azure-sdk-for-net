// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Provisioning.AppContainers;
using Azure.Provisioning.ContainerRegistry;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.OperationalInsights;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Roles;
using Azure.Provisioning.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Provisioning.Tests;

internal class SampleTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    public async Task SimpleDeploy()
    {
        BlobService? blobs = null;
        BicepOutput? endpoint = null;

        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                // Create a storage account and blob resources
                StorageAccount storage = StorageResources.CreateAccount(nameof(storage));
                blobs = new(nameof(blobs)) { Parent = storage };

                // Grab the endpoint
                endpoint = new BicepOutput("blobs_endpoint", typeof(string)) { Value = storage.PrimaryEndpoints.Value!.BlobUri };
            })
        .Compare(
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

            resource blobs 'Microsoft.Storage/storageAccounts/blobServices@2023-01-01' = {
              name: 'default'
              parent: storage
            }

            output blobs_endpoint string = storage.properties.primaryEndpoints.blob
            """)
        .Lint()
        .ValidateAndDeployAsync(
            async deployment =>
            {
                // Create a client
                BlobServiceClient storage = InstrumentClient(
                    deployment.CreateClient(
                        blobs!,
                        TestEnvironment.Credential,
                        InstrumentClientOptions(new BlobClientOptions())));

                // Make sure the output matched correctly
                Assert.AreEqual(storage.Uri.AbsoluteUri, endpoint!.Value.Value);

                // Make a service call and verify it doesn't throw
                Response<BlobServiceProperties> result = await storage.GetPropertiesAsync();
                Assert.AreEqual(200, result.GetRawResponse().Status);
            });
    }

    [Test]
    public async Task SimpleContainerApp()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter principalId = new(nameof(principalId), typeof(string)) { Value = "" };
                BicepParameter tags = new(nameof(tags), typeof(object)) { Value = new BicepDictionary<string>() };

                UserAssignedIdentity mi =
                    new(nameof(mi))
                    {
                        Tags = tags,
                    };
                ContainerRegistryService acr =
                    new(nameof(acr))
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
                acr.AssignRole(ContainerRegistryBuiltInRole.AcrPull, mi);
                OperationalInsightsWorkspace law =
                    new(nameof(law))
                    {
                        Sku = new OperationalInsightsWorkspaceSku() { Name = OperationalInsightsWorkspaceSkuName.PerGB2018 },
                        Tags = tags,
                    };
                ContainerAppManagedEnvironment cae =
                    new(nameof(cae))
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
                cae.AssignRole(AppContainersBuiltInRole.Contributor, mi);

                // Hack in the Aspire Dashboard as a literal since there's no
                // management plane library support for dotNetComponents yet
                BicepLiteral aspireDashboard =
                    new("aspireDashboard",
                        new ResourceStatement(
                            "aspireDashboard",
                            new StringLiteral("Microsoft.App/managedEnvironments/dotNetComponents@2024-02-02-preview"),
                            new ObjectExpression(
                                new PropertyExpression("name", "aspire-dashboard"),
                                new PropertyExpression("parent", new IdentifierExpression(cae.ResourceName)),
                                new PropertyExpression("properties",
                                    new ObjectExpression(
                                        new PropertyExpression("componentType", new StringLiteral("AspireDashboard")))))));

                _ = new BicepOutput("MANAGED_IDENTITY_CLIENT_ID", typeof(string)) { Value = mi.ClientId };
                _ = new BicepOutput("MANAGED_IDENTITY_NAME", typeof(string)) { Value = mi.Name };
                _ = new BicepOutput("MANAGED_IDENTITY_PRINCIPAL_ID", typeof(string)) { Value = mi.PrincipalId };
                _ = new BicepOutput("LOG_ANALYTICS_WORKSPACE_NAME", typeof(string)) { Value = law.Name };
                _ = new BicepOutput("LOG_ANALYTICS_WORKSPACE_ID", typeof(string)) { Value = law.Id };
                _ = new BicepOutput("AZURE_CONTAINER_REGISTRY_ENDPOINT", typeof(string)) { Value = acr.LoginServer };
                _ = new BicepOutput("AZURE_CONTAINER_REGISTRY_MANAGED_IDENTITY_ID", typeof(string)) { Value = mi.Id };
                _ = new BicepOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_NAME", typeof(string)) { Value = cae.Name };
                _ = new BicepOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_ID", typeof(string)) { Value = cae.Id };
                _ = new BicepOutput("AZURE_CONTAINER_APPS_ENVIRONMENT_DEFAULT_DOMAIN", typeof(string)) { Value = cae.DefaultDomain };
            })
        .Compare(
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

            resource law 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
              name: take('law-${uniqueString(resourceGroup().id)}', 63)
              location: location
              properties: {
                sku: {
                  name: 'PerGB2018'
                }
              }
              tags: tags
            }

            resource cae 'Microsoft.App/managedEnvironments@2023-05-01' = {
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
            """)
        .Lint(ignore: ["no-unused-params", "BCP029"])
        .ValidateAndDeployAsync();
    }

    [Test]
    public async Task SimpleResourceGroup()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                // Create a new resource group
                ResourceGroup rg = new("rg-test", "2024-03-01");

                // Create a new infra group scoped to our subscription and add
                // the resource group
                Infrastructure group = new("main") { TargetScope = "subscription" };
                group.Add(rg);

                return group;
            })
        .Compare(
            """
            targetScope = 'subscription'

            @description('The location for the resource(s) to be deployed.')
            param location string = deployment().location

            resource rg-test 'Microsoft.Resources/resourceGroups@2024-03-01' = {
              name: take('rg-test-${uniqueString(deployment().id)}', 90)
              location: location
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
