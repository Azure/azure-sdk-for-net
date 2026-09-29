// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.RecoveryServices.Tests;

public class BasicRecoveryServicesTests
{
    internal static Trycep CreateVaultTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:RecoveryServicesBasic
                Infrastructure infra = new();

                RecoveryServicesVault vault =
                    new(nameof(vault), RecoveryServicesVault.ResourceVersions.V2026_05_01)
                    {
                        Properties = new RecoveryServicesVaultProperties
                        {
                            PublicNetworkAccess = VaultPublicNetworkAccess.Enabled,
                        },
                        Sku = new RecoveryServicesSku
                        {
                            Name = RecoveryServicesSkuName.Standard,
                        },
                    };
                infra.Add(vault);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.recoveryservices/2026-05-01/vaults")]
    public async Task CreateVault()
    {
        await using Trycep test = CreateVaultTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource vault 'Microsoft.RecoveryServices/vaults@2026-05-01' = {
              name: take('vault${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                publicNetworkAccess: 'Enabled'
              }
              sku: {
                name: 'Standard'
              }
            }
            """);
    }
}
