// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Roles;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class StorageBuiltInRoleTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task StorageFileDataSmbMIAdminRoleAssignment(bool explicitPrincipal)
    {
        StorageBuiltInRole role = StorageBuiltInRole.StorageFileDataSmbMIAdmin;
        Assert.That(role.ToString(), Is.EqualTo("a235d3ee-5935-4cfb-8cc5-a3303ad5995e"));
        Assert.That(StorageBuiltInRole.GetBuiltInRoleName(role), Is.EqualTo(nameof(StorageBuiltInRole.StorageFileDataSmbMIAdmin)));

        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                StorageAccount storage = new("storage", StorageAccount.ResourceVersions.V2023_01_01)
                {
                    Kind = StorageKind.StorageV2,
                    Sku = { Name = StorageSkuName.StandardLrs }
                };
                infra.Add(storage);

                UserAssignedIdentity identity = new("identity", UserAssignedIdentity.ResourceVersions.V2023_01_31);
                infra.Add(identity);
                infra.Add(explicitPrincipal
                    ? storage.CreateRoleAssignment(role, RoleManagementPrincipalType.ServicePrincipal, identity.PrincipalId)
                    : storage.CreateRoleAssignment(role, identity));
                return infra;
            });

        string roleIdentifier = explicitPrincipal
            ? "storage_StorageFileDataSmbMIAdmin"
            : "storage_identity_StorageFileDataSmbMIAdmin";
        test.Compare(
            $$"""
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource storage 'Microsoft.Storage/storageAccounts@2023-01-01' = {
              name: take('storage${uniqueString(resourceGroup().id)}', 24)
              location: location
              kind: 'StorageV2'
              sku: {
                name: 'Standard_LRS'
              }
            }

            resource identity 'Microsoft.ManagedIdentity/userAssignedIdentities@2023-01-31' = {
              name: take('identity-${uniqueString(resourceGroup().id)}', 128)
              location: location
            }

            resource {{roleIdentifier}} 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
              name: guid(storage.id, identity.properties.principalId, subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a235d3ee-5935-4cfb-8cc5-a3303ad5995e'))
              scope: storage
              properties: {
                principalId: identity.properties.principalId
                principalType: 'ServicePrincipal'
                roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', 'a235d3ee-5935-4cfb-8cc5-a3303ad5995e')
              }
            }
            """);
    }
}
