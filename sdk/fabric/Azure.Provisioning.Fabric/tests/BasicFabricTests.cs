// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Fabric.Tests;

public class BasicFabricTests
{
    internal static Trycep CreateCapacityTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:FabricBasic
                Infrastructure infra = new();

                FabricCapacity capacity = new(nameof(capacity), FabricCapacity.ResourceVersions.V2026_09_01_PREVIEW)
                {
                    Location = new AzureLocation("westus"),
                    Sku = new()
                    {
                        Name = "F2",
                        Tier = FabricSkuTier.Fabric
                    },
                    Properties = new()
                    {
                        AdministrationMembers = new() { "admin@contoso.com" },
                        Overage = new()
                        {
                            State = CapacityOverageState.Enabled,
                            ThresholdCapacityUnitHours = 100
                        }
                    }
                };
                infra.Add(capacity);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateCapacity()
    {
        await using Trycep test = CreateCapacityTest();

        test.Compare(
            """
            resource capacity 'Microsoft.Fabric/capacities@2026-09-01-preview' = {
              name: take('capacity${uniqueString(resourceGroup().id)}', 63)
              location: 'westus'
              properties: {
                administration: {
                  members: [
                    'admin@contoso.com'
                  ]
                }
                overage: {
                  state: 'Enabled'
                  thresholdCapacityUnitHours: 100
                }
              }
              sku: {
                name: 'F2'
                tier: 'Fabric'
              }
            }
            """);
    }
}
