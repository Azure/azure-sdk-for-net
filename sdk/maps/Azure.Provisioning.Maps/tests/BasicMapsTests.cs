// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Maps.Tests;

public class BasicMapsTests
{
    internal static Trycep CreateMapsAccountTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:MapsAccountBasic
                Infrastructure infra = new();

                MapsAccount account =
                    new(nameof(account), MapsAccount.ResourceVersions.V2025_10_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                        Properties = new MapsAccountProperties { DisableLocalAuth = true },
                        Sku = new MapsSku { Name = MapsSkuName.G2 },
                        Kind = MapsAccountKind.Gen2,
                    };
                infra.Add(account);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.maps/2025-10-01-preview/accounts")]
    public async Task CreateMapsAccount()
    {
        await using Trycep test = CreateMapsAccountTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource account 'Microsoft.Maps/accounts@2025-10-01-preview' = {
              name: take('account-${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                disableLocalAuth: true
              }
              sku: {
                name: 'G2'
              }
              kind: 'Gen2'
            }
            """);
    }
}
