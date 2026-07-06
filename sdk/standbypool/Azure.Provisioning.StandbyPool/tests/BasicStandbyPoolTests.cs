// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.StandbyPool.Tests;

public class BasicStandbyPoolTests
{
    internal static Trycep CreateStandbyVirtualMachinePoolTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:StandbyPoolBasic
                Infrastructure infra = new();

                StandbyVirtualMachinePool pool =
                    new(nameof(pool), StandbyVirtualMachinePool.ResourceVersions.V2025_10_01)
                    {
                        Tags = { ["environment"] = "test" },
                        Properties = new StandbyVirtualMachinePoolProperties
                        {
                            ElasticityProfile = new StandbyVirtualMachinePoolElasticityProfile
                            {
                                MaxReadyCapacity = 2,
                                MinReadyCapacity = 1,
                            },
                            VirtualMachineState = StandbyVirtualMachineState.Running,
                            AttachedVirtualMachineScaleSetId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.Compute/virtualMachineScaleSets/sample-vmss"),
                        },
                    };
                infra.Add(pool);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateStandbyVirtualMachinePool()
    {
        await using Trycep test = CreateStandbyVirtualMachinePoolTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource pool 'Microsoft.StandbyPool/standbyVirtualMachinePools@2025-10-01' = {
              name: take('pool-${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                elasticityProfile: {
                  maxReadyCapacity: 2
                  minReadyCapacity: 1
                }
                virtualMachineState: 'Running'
                attachedVirtualMachineScaleSetId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.Compute/virtualMachineScaleSets/sample-vmss'
              }
            }
            """);
    }
}
