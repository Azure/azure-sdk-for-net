// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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

                FabricCapacity capacity = FabricCapacity.FromExisting(nameof(capacity), FabricCapacity.ResourceVersions.V2026_09_01_PREVIEW);
                capacity.Name = "existingCapacity";
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
            resource capacity 'Microsoft.Fabric/capacities@2026-09-01-preview' existing = {
              name: 'existingCapacity'
            }
            """);
    }
}
