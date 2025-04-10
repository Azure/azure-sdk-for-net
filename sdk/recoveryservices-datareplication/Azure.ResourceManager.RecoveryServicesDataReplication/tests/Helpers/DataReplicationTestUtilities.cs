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
    public class DataReplicationTestUtilities
    {
        public const string DefaultSubscriptionId = "de3c4d5e-af08-451a-a873-438d86ab6f4b";
        public const string DefaultResourceGroupName = "sdkTest1-rg";

        public const string DefaultVaultName = "sdkTest1-prj9419replicationvault";
        public const string DefaultSourceFabricId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourcegroups/sdkTest1-rg/providers/Microsoft.DataReplication/replicationFabrics/src27003replicationfabric";
        public const string DefaultTargetFabricId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourcegroups/sdkTest1-rg/providers/Microsoft.DataReplication/replicationFabrics/tar141e7replicationfabric";
        public const string DefaultStorageAccountId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourcegroups/sdkTest1Target-rg/providers/microsoft.storage/storageaccounts/migratersa1623823399";
        public const string DefaultReplicationExtensionName = "src27003replicationfabric-tar141e7replicationfabric-MigReplicationExtn";
        public const string DefaultPolicyName = "sdkTest1-prj9419replicationvaultHyperVToAzStackHCIpolicy";
        public const string DefaultProtectedItemTargetResourceGroupId = "/subscriptions/8f1080e9-c622-4fe3-917f-92ac7a4d491a/resourceGroups/EDGECI-REGISTRATION-n42r2202-3rLQhpnS";
        public const string DeafultLocation = "centraluseuap";

        // Defaults for protected item
        public const string DefaultProtectedItemName = "fcc85954-7683-48e0-bebf-b4154bea302d";
        public const string DefaultProtectedItemFabricDiscoveryMachineId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/sdkTest1-rg/providers/Microsoft.OffAzure/HyperVSites/src21791site/machines/fcc85954-7683-48e0-bebf-b4154bea302d";
        public const string DefaultProtectedItemTargetVMName = "MigrateVMTest1";
        public const string DefaultProtectedItemHyperVGeneration = "2";
        public const int DefaultProtectedItemTargetCpuCore = 1;
        public const bool DefaultProtectedItemIsDynamicRam = false;
        public const int DefaultProtectedItemTargetMemoryInMegaByte = 16384;

        // Default disk
        public const string DefaultProtectedItemDiskId = "Microsoft:FCC85954-7683-48E0-BEBF-B4154BEA302D\\BA6B6516-7EC4-4A57-BD4F-74F80681E6AD\\0\\0\\L";
        public const long DefaultProtectedItemDiskSizeInGB = 40;
        public const string DefaultProtectedItemDiskFileFormat = "VHDX";

        // Default nic
        public const string DefaultProtectedItemNicId = "Microsoft:FCC85954-7683-48E0-BEBF-B4154BEA302D\\0EC25903-10D4-4507-BEB9-AA005108B414";
        public const string VMwareToAzStackHCI = "VMwareToAzStackHCI";
        public const string HyperVToAzStackHCI = "HyperVToAzStackHCI";

        // Appliance
        public const string DefaultProtectedItemRunAsAccountId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/sdkTest1-rg/providers/Microsoft.OffAzure/HyperVSites/src21791site/runasaccounts/721c6e78-1d06-5e73-be73-b141d03833e8";
        public const string DefaultProtectedItemSourceFabricAgentName = "src27003dra";
        public const string DefaultProtectedItemTargetFabricAgentName = "tar141e7dra";

        // Target cluster
        public const string DefaultProtectedItemCustomLocationRegion = "australiaeast";
        public const string DefaultProtectedItemTargetHciClusterId = "/subscriptions/8f1080e9-c622-4fe3-917f-92ac7a4d491a/resourceGroups/EDGECI-REGISTRATION-n42r2202-3rLQhpnS/providers/Microsoft.AzureStackHCI/clusters/n42r2202-cl";
        public const string DefaultProtectedItemStorageContainerId = "/subscriptions/8f1080e9-c622-4fe3-917f-92ac7a4d491a/resourceGroups/E2ETestTargetrgVMMig3/providers/Microsoft.AzureStackHCI/storageContainers/scontn42r2202-cl";
        public const string DefaultProtectedItemTargetNetworkId = "/subscriptions/8f1080e9-c622-4fe3-917f-92ac7a4d491a/resourceGroups/E2ETestTargetrgVMMig3/providers/Microsoft.AzureStackHCI/logicalNetworks/vnetn42r2202-cl";
        public const string DefaultProtectedItemTargetArcClusterCustomLocationId = "/subscriptions/8f1080e9-c622-4fe3-917f-92ac7a4d491a/resourceGroups/EDGECI-REGISTRATION-n42r2202-3rLQhpnS/providers/Microsoft.ExtendedLocation/customLocations/n42r2202-cl-customlocation";

        public const string DefaultJobName = "d8b8c35c-7323-4611-88a0-709cc7ddac33";

        // Policy
        public const int RecoveryPointHistoryInMinutes = 4320;
        public const int AppConsistentFrequencyInMinutes = 60;
        public const int CrashConsistentFrequencyInMinutes = 240;
        public const int RetryCount = 20;
        public const int ThreadSleepTime = 1000;

        // Fabric
        public const string DefaultFabricInstanceType = "HyperVMigrate";
        public const string DefaultFabricSourceSiteId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/sdkTest1-rg/providers/Microsoft.OffAzure/HyperVSites/src21791site";
        public const string DefaultFabricMigrationSolutionId = "/subscriptions/de3c4d5e-af08-451a-a873-438d86ab6f4b/resourceGroups/sdkTest1-rg/providers/Microsoft.Migrate/MigrateProjects/sdkTest1-prj/Solutions/Servers-Migration-ServerMigration_DataReplication";
    }
}
