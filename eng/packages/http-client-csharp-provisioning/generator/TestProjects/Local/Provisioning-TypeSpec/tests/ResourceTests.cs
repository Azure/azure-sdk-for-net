// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ProvisioningTypeSpec.Tests;

public class ResourceTests
{
    [Test]
    public async Task ResourceKinds()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ConfigurationStore store = new(nameof(store));
                KeyValue keyValue = new(nameof(keyValue), KeyValue.ResourceVersions.V2024_04_01)
                {
                    Parent = store,
                    Properties = new KeyValueProperties
                    {
                        Value = "value",
                        ContentType = "text/plain"
                    }
                };
                ExtensionAssignment extension = new(nameof(extension))
                {
                    Scope = store,
                    ExtensionAssignmentDisplayName = "store assignment"
                };
                Profile profile = new(nameof(profile))
                {
                    Parent = store,
                    Description = "current profile",
                    SkuName = "Standard"
                };
                ProfileRevision revision = new(nameof(revision))
                {
                    Parent = profile,
                    Description = "profile revision",
                    SkuName = "Standard"
                };
                SpecializedResourceProfile specialized = new(nameof(specialized))
                {
                    Parent = store,
                    DiscriminatedResourceDescription = "specialized profile"
                };

                infra.Add(store);
                infra.Add(keyValue);
                infra.Add(extension);
                infra.Add(profile);
                infra.Add(revision);
                infra.Add(specialized);
                return infra;
            });

        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource store 'ProvisioningTypeSpec/configurationStores@2024-05-01' = {
              name: take('store-${uniqueString(resourceGroup().id)}', 24)
              location: location
            }

            resource keyValue 'ProvisioningTypeSpec/configurationStores/keyValues@2024-04-01' = {
              name: take('keyValue-${uniqueString(resourceGroup().id)}', 24)
              parent: store
              properties: {
                contentType: 'text/plain'
                value: 'value'
              }
            }

            resource extension 'ProvisioningTypeSpec/extensionAssignments@2024-05-01' = {
              name: take('extension${uniqueString(resourceGroup().id)}', 24)
              scope: store
              properties: {
                displayName: 'store assignment'
              }
            }

            resource profile 'ProvisioningTypeSpec/configurationStores/profiles@2024-05-01' = {
              name: take('profile-${uniqueString(resourceGroup().id)}', 24)
              parent: store
              properties: {
                description: 'current profile'
                sku: {
                  name: 'Standard'
                }
              }
            }

            resource revision 'ProvisioningTypeSpec/configurationStores/profiles/revisions@2024-05-01' = {
              name: take('revision-${uniqueString(resourceGroup().id)}', 24)
              parent: profile
              properties: {
                description: 'profile revision'
                sku: {
                  name: 'Standard'
                }
              }
            }

            resource specialized 'ProvisioningTypeSpec/configurationStores/discriminatedResourceProfiles@2024-05-01' = {
              name: take('specialized-${uniqueString(resourceGroup().id)}', 24)
              parent: store
              kind: 'Specialized'
              properties: {
                description: 'specialized profile'
              }
            }
            """);
    }

    [Test]
    public async Task RoleAssignment()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                ConfigurationStore store = new(nameof(store));
                RoleAssignment assignment = store.CreateRoleAssignment(
                    ProvisioningTypeSpecBuiltInRole.ConfigStoreReader,
                    RoleManagementPrincipalType.ServicePrincipal,
                    Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    "test");
                infra.Add(store);
                infra.Add(assignment);
                return infra;
            });

        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource store 'ProvisioningTypeSpec/configurationStores@2024-05-01' = {
              name: take('store-${uniqueString(resourceGroup().id)}', 24)
              location: location
            }

            resource store_ConfigStoreReader_test 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
              name: guid(store.id, '11111111-1111-1111-1111-111111111111', subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '00000000-0000-0000-0000-000000000002'))
              scope: store
              properties: {
                principalId: '11111111-1111-1111-1111-111111111111'
                principalType: 'ServicePrincipal'
                roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '00000000-0000-0000-0000-000000000002')
              }
            }
            """);
    }
}
