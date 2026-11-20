// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SecretsStoreExtension.Tests;

public class BasicSecretsStoreExtensionTests
{
    internal static Trycep CreateSecretSyncTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SecretsStoreExtensionBasic
                Infrastructure infra = new();

                ProvisioningParameter keyVaultName = new(nameof(keyVaultName), typeof(string));
                ProvisioningParameter clientId = new(nameof(clientId), typeof(Guid));
                ProvisioningParameter tenantId = new(nameof(tenantId), typeof(Guid));
                ProvisioningParameter customLocationId = new(nameof(customLocationId), typeof(string));
                infra.Add(keyVaultName);
                infra.Add(clientId);
                infra.Add(tenantId);
                infra.Add(customLocationId);

                KeyVaultSecretProviderClass provider = new(nameof(provider))
                {
                    Name = "key-vault-provider",
                    ExtendedLocation = new ExtendedAzureLocation
                    {
                        Name = customLocationId,
                        // The shared enum does not yet include CustomLocation.
                        ExtendedLocationType = new StringLiteralExpression("CustomLocation"),
                    },
                    Properties = new KeyVaultSecretProviderClassProperties
                    {
                        KeyvaultName = keyVaultName,
                        ClientId = clientId,
                        TenantId = tenantId,
                        CloudName = AzureCloudName.AzurePublicCloud,
                        Objects = "array:\n  - |\n    objectName: application-secret\n    objectType: secret",
                    },
                };
                infra.Add(provider);

                SecretSync sync = new(nameof(sync))
                {
                    Name = "secret-sync",
                    ExtendedLocation = new ExtendedAzureLocation
                    {
                        Name = customLocationId,
                        ExtendedLocationType = new StringLiteralExpression("CustomLocation"),
                    },
                    Properties = new SecretSyncProperties
                    {
                        SecretProviderClassName = provider.Name,
                        ServiceAccountName = "secret-sync-account",
                        KubernetesSecretType = KubernetesSecretType.Opaque,
                        ObjectSecretMapping =
                        {
                            new KubernetesSecretObjectMapping
                            {
                                SourcePath = "application-secret",
                                TargetKey = "password",
                            },
                        },
                    },
                };
                sync.DependsOn.Add(provider);
                infra.Add(sync);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateSecretSync()
    {
        await using Trycep test = CreateSecretSyncTest();
        test.Compare(
            """
            param keyVaultName string

            param clientId string

            param tenantId string

            param customLocationId string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource provider 'Microsoft.SecretSyncController/azureKeyVaultSecretProviderClasses@2026-09-25-preview' = {
              name: 'key-vault-provider'
              location: location
              extendedLocation: {
                name: customLocationId
                type: 'CustomLocation'
              }
              properties: {
                clientId: clientId
                cloudName: 'AzurePublicCloud'
                keyvaultName: keyVaultName
                objects: 'array:\n  - |\n    objectName: application-secret\n    objectType: secret'
                tenantId: tenantId
              }
            }

            resource sync 'Microsoft.SecretSyncController/secretSyncs@2026-09-25-preview' = {
              name: 'secret-sync'
              location: location
              extendedLocation: {
                name: customLocationId
                type: 'CustomLocation'
              }
              properties: {
                kubernetesSecretType: 'Opaque'
                objectSecretMapping: [
                  {
                    sourcePath: 'application-secret'
                    targetKey: 'password'
                  }
                ]
                secretProviderClassName: 'key-vault-provider'
                serviceAccountName: 'secret-sync-account'
              }
              dependsOn: [
                provider
              ]
            }
            """);
    }
}
