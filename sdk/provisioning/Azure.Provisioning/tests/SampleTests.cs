// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Provisioning.AppContainers;
using Azure.Provisioning.Authorization;
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
        ProvisioningOutput? endpoint = null;

        await using Trycep test = CreateBicepTest();
#pragma warning disable SA1112 // Closing parenthesis should be on line of opening parenthesis
        await test.Define(
            ctx =>
            {
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
                blobs = new(nameof(blobs)) { Parent = storage };
                infra.Add(blobs);

                // Grab the endpoint
                endpoint = new ProvisioningOutput("blobs_endpoint", typeof(string)) { Value = storage.PrimaryEndpoints.BlobUri };
                infra.Add(endpoint);

                return infra;
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

            resource blobs 'Microsoft.Storage/storageAccounts/blobServices@2024-01-01' = {
              name: 'default'
              parent: storage
            }

            output blobs_endpoint string = storage.properties.primaryEndpoints.blob
            """)
        .Lint()
        .ValidateAndDeployAsync(
#if EXPERIMENTAL_PROVISIONING
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
            }
#endif
        );
#pragma warning restore SA1112 // Closing parenthesis should be on line of opening parenthesis
    }

    [Test]
    public async Task SimpleContainerApp()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter principalId = new(nameof(principalId), typeof(string)) { Value = "" };
                infra.Add(principalId);

                ProvisioningParameter tags = new(nameof(tags), typeof(object)) { Value = new BicepDictionary<string>() };
                infra.Add(tags);

                UserAssignedIdentity mi =
                    new(nameof(mi))
                    {
                        Tags = tags,
                    };
                infra.Add(mi);

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
                infra.Add(acr);

                RoleAssignment pullAssignment = acr.CreateRoleAssignment(ContainerRegistryBuiltInRole.AcrPull, mi);
                infra.Add(pullAssignment);

                OperationalInsightsWorkspace law =
                    new(nameof(law))
                    {
                        Sku = new OperationalInsightsWorkspaceSku() { Name = OperationalInsightsWorkspaceSkuName.PerGB2018 },
                        Tags = tags,
                    };
                infra.Add(law);

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

                return infra;
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
                // Create a new infra group scoped to our subscription and add
                // the resource group
                Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };

                ResourceGroup rg = new("rg_test", "2024-03-01");
                infra.Add(rg);

                return infra;
            })
        .Compare(
            """
            targetScope = 'subscription'

            @description('The location for the resource(s) to be deployed.')
            param location string = deployment().location

            resource rg_test 'Microsoft.Resources/resourceGroups@2024-03-01' = {
              name: take('rg_test-${uniqueString(deployment().id)}', 90)
              location: location
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }

    [Test]
    public void ValidNames()
    {
        // Check null is invalid
        Assert.IsFalse(Infrastructure.IsValidBicepIdentifier(null));
        Assert.Throws<ArgumentNullException>(() => Infrastructure.ValidateBicepIdentifier(null));
        Assert.Throws<ArgumentNullException>(() => new StorageAccount(null!));

        // Check invalid names
        List<string> invalid = ["", "my-storage", "my storage", "my:storage", "storage$", "1storage", "KforKelvin"];
        foreach (string name in invalid)
        {
            Assert.IsFalse(Infrastructure.IsValidBicepIdentifier(name));
            Assert.Throws<ArgumentException>(() => Infrastructure.ValidateBicepIdentifier(name));
            if (!string.IsNullOrEmpty(name))
            {
                Assert.AreNotEqual(name, Infrastructure.NormalizeBicepIdentifier(name));
            }
            Assert.Throws<ArgumentException>(() => new StorageAccount(name));
        }

        // Check valid names
        List<string> valid = ["foo", "FOO", "Foo", "f", "_foo", "_", "foo123", "ABCdef123_"];
        foreach (string name in valid)
        {
            Assert.IsTrue(Infrastructure.IsValidBicepIdentifier(name));
            Assert.DoesNotThrow(() => Infrastructure.ValidateBicepIdentifier(name));
            Assert.AreEqual(name, Infrastructure.NormalizeBicepIdentifier(name));
            Assert.DoesNotThrow(() => new StorageAccount(name));
        }
    }
}
