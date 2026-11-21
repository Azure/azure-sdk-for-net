// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Compute.Batch.Tests.Infrastructure
{
    internal static class Batch2026FeatureTestData
    {
        public static VirtualMachineConfiguration Configuration() => new VirtualMachineConfiguration(
            new BatchVmImageReference
            {
                Publisher = "MicrosoftWindowsServer",
                Offer = "windowsserver2022",
                Sku = "2022-datacenter-smalldisk",
                Version = "latest"
            }, "batch.node.windows amd64");

        public static VirtualMachineSkuProfile MixProfile() => new VirtualMachineSkuProfile
        {
            AllocationStrategy = VirtualMachineSkuAllocationStrategy.Prioritized,
            VmSizes =
            {
                new VirtualMachineSkuProfileVmSize("Standard_D2_v2") { Rank = 1 },
                new VirtualMachineSkuProfileVmSize("Standard_D2s_v3") { Rank = 2 }
            }
        };

        public static ZonePlacement Placement() => new ZonePlacement
        {
            ZonePlacementPolicy = ZonePlacementPolicyType.Auto
        };

        public static ResiliencyPolicy Resiliency() => new ResiliencyPolicy
        {
            ZoneAllocationPolicy = new ZoneAllocationPolicy
            {
                MaxZoneCount = 2,
                MaxInstancePercentPerZonePolicy = new MaxInstancePercentPerZonePolicy
                {
                    Enabled = true,
                    Value = 75
                }
            }
        };

        public static HardwareProfile Hardware() => new HardwareProfile
        {
            VmSizeProperties = new VMSizeProperties { VCPUsAvailable = 2, VCPUsPerCore = 1 }
        };
    }
}
