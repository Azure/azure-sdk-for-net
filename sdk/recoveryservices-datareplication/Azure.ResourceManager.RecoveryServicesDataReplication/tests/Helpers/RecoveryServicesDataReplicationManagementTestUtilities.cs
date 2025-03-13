// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.RecoveryServicesDataReplication.Tests.Helpers
{
    public class RecoveryServicesDataReplicationManagementTestUtilities
    {
        public const string DefaultResourceGroupName = "aszmige2etestscratchKPIvmw011cb3";
        public const string DefaultVaultName = "aszmigtest1d6ebbareplicationvault";
        public const string DefaultSourceApplianceId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/aszmige2etestscratchKPIvmw011cb3/providers/Microsoft.DataReplication/replicationFabrics/VMware-1d6ebba3306replicationfabric";
        public const string DefaultTargetApplianceId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/aszmige2etestscratchKPIvmw011cb3/providers/Microsoft.DataReplication/replicationFabrics/asz-1d6ebba08a0replicationfabric";
        public const string DefaultStorageAccountId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/aszmige2etestscratchKPIvmw011cb3/providers/Microsoft.Storage/storageAccounts/migratersa1032711035";
        public const string DefaultReplicationExtensionName = "VMware-1d6ebba3306replicationfabric-asz-1d6ebba08a0replicationfabric-MigReplicationExtn";
        public const string DefaultPolicyName = "aszmigtest1d6ebbareplicationvaultVMwareToAzStackHCIpolicy";
        public const string DefaultProtectedItemTargetResourceGroupId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/aszmige2etestscratchKPIvmw011cb3-target";

        // Defaults for protected item
        public const string DefaultProtectedItemName = "100-69-177-104-31be0ff4-c932-4cb3-8efc-efa411d23480_50238fae-8286-3153-78db-9613d575e73f";
        public const string DefaultProtectedItemFabricDiscoveryMachineId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/aszmige2etestscratchKPIvmw011cb3/providers/Microsoft.OffAzure/VMwareSites/VMware-1d6ebbasite/machines/100-69-177-104-31be0ff4-c932-4cb3-8efc-efa411d23480_50238fae-8286-3153-78db-9613d575e73f";
        public const string DefaultProtectedItemTargetVMName = "MigrateVMTest1";
        public const string DefaultProtectedItemHyperVGeneration = "2";
        public const int DefaultProtectedItemTargetCpuCore = 4;
        public const bool DefaultProtectedItemIsDynamicRam = false;
        public const int DefaultProtectedItemTargetMemoryInMegaByte = 4096;

        // Default disk
        public const string DefaultProtectedItemDiskId = "6000C290-a4d0-e5ea-bad5-4e993df22e3b";
        public const long DefaultProtectedItemDiskSizeInGB = 40;
        public const string DefaultProtectedItemDiskFileFormat = "VHDX";

        // Default nic
        public const string DefaultProtectedItemNicId = "4000";

        // Appliance
        public const string DefaultProtectedItemRunAsAccountId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/aszmige2etestscratchKPIvmw011cb3/providers/Microsoft.OffAzure/VMwareSites/VMware-1d6ebbasite/runasaccounts/e6176dcd-08e9-54d8-9514-92128b1162c0";
        public const string DefaultProtectedItemSourceFabricAgentName = "VMware-1d6ebba3306dra";
        public const string DefaultProtectedItemTargetFabricAgentName = "asz-1d6ebba08a0dra";

        // Target cluster
        public const string DefaultProtectedItemCustomLocationRegion = "canadacentral";
        public const string DefaultProtectedItemTargetHciClusterId = "/Subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/EDGECI-REGISTRATION-n22r1004-vBTa6UOS/providers/Microsoft.AzureStackHCI/clusters/n22r1004-cl";
        public const string DefaultProtectedItemStorageContainerId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/E2ETestTargetrgVMMig6/providers/Microsoft.AzureStackHCI/storageContainers/scontn22r1004-cl";
        public const string DefaultProtectedItemTargetNetworkId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/E2ETestTargetrgVMMig6/providers/Microsoft.AzureStackHCI/logicalNetworks/vnetn22r1004-cl";
        public const string DefaultProtectedItemTargetArcClusterCustomLocationId = "/SUBSCRIPTIONS/DE3C4D5E-AF08-451A-A873-438D86AB6F4B/RESOURCEGROUPS/EDGECI-REGISTRATION-N22R1004-VBTA6UOS/PROVIDERS/MICROSOFT.EXTENDEDLOCATION/CUSTOMLOCATIONS/N22R1004-CL-CUSTOMLOCATION";

        public const string DefaultJobName = "c095be86-9c61-4ffe-9dff-afbbe6ff18cb";

        // Policy
        public const int RecoveryPointHistoryInMinutes = 4320;
        public const int AppConsistentFrequencyInMinutes = 60;
        public const int CrashConsistentFrequencyInMinutes = 240;
        public const int RetryCount = 20;
        public const int ThreadSleepTime = 15000;
    }
}
