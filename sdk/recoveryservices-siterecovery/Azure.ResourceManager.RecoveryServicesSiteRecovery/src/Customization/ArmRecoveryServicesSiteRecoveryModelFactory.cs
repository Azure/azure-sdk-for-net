// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServicesSiteRecovery;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmRecoveryServicesSiteRecoveryModelFactory
    {
        /// <summary> Initializes a new instance of A2AReplicationDetails. </summary>
        /// <param name="fabricObjectId"> The fabric specific object Id of the virtual machine. </param>
        /// <param name="initialPrimaryZone"> The initial primary availability zone. </param>
        /// <param name="initialPrimaryFabricLocation"> The initial primary fabric location. </param>
        /// <param name="initialRecoveryZone"> The initial recovery availability zone. </param>
        /// <param name="initialPrimaryExtendedLocation"> The initial primary extended location. </param>
        /// <param name="initialRecoveryExtendedLocation"> The initial recovery extended location. </param>
        /// <param name="initialRecoveryFabricLocation"> The initial recovery fabric location. </param>
        /// <param name="multiVmGroupId"> The multi vm group Id. </param>
        /// <param name="multiVmGroupName"> The multi vm group name. </param>
        /// <param name="multiVmGroupCreateOption"> Whether Multi VM group is auto created or specified by user. </param>
        /// <param name="managementId"> The management Id. </param>
        /// <param name="protectedDisks"> The list of protected disks. </param>
        /// <param name="unprotectedDisks"> The list of unprotected disks. </param>
        /// <param name="protectedManagedDisks"> The list of protected managed disks. </param>
        /// <param name="recoveryBootDiagStorageAccountId"> The recovery boot diagnostic storage account Arm Id. </param>
        /// <param name="primaryFabricLocation"> Primary fabric location. </param>
        /// <param name="recoveryFabricLocation"> The recovery fabric location. </param>
        /// <param name="osType"> The type of operating system. </param>
        /// <param name="recoveryAzureVmSize"> The size of recovery virtual machine. </param>
        /// <param name="recoveryAzureVmName"> The name of recovery virtual machine. </param>
        /// <param name="recoveryAzureResourceGroupId"> The recovery resource group. </param>
        /// <param name="recoveryCloudService"> The recovery cloud service. </param>
        /// <param name="recoveryAvailabilitySet"> The recovery availability set. </param>
        /// <param name="selectedRecoveryAzureNetworkId"> The recovery virtual network. </param>
        /// <param name="selectedTfoAzureNetworkId"> The test failover virtual network. </param>
        /// <param name="vmNics"> The virtual machine nic details. </param>
        /// <param name="vmSyncedConfigDetails"> The synced configuration details. </param>
        /// <param name="monitoringPercentageCompletion"> The percentage of the monitoring job. The type of the monitoring job is defined by MonitoringJobType property. </param>
        /// <param name="monitoringJobType"> The type of the monitoring job. The progress is contained in MonitoringPercentageCompletion property. </param>
        /// <param name="lastHeartbeat"> The last heartbeat received from the source server. </param>
        /// <param name="agentVersion"> The agent version. </param>
        /// <param name="agentExpireOn"> Agent expiry date. </param>
        /// <param name="isReplicationAgentUpdateRequired"> A value indicating whether replication agent update is required. </param>
        /// <param name="agentCertificateExpireOn"> Agent certificate expiry date. </param>
        /// <param name="isReplicationAgentCertificateUpdateRequired"> A value indicating whether agent certificate update is required. </param>
        /// <param name="recoveryFabricObjectId"> The recovery fabric object Id. </param>
        /// <param name="vmProtectionState"> The protection state for the vm. </param>
        /// <param name="vmProtectionStateDescription"> The protection state description for the vm. </param>
        /// <param name="lifecycleId"> An id associated with the PE that survives actions like switch protection which change the backing PE/CPE objects internally.The lifecycle id gets carried forward to have a link/continuity in being able to have an Id that denotes the "same" protected item even though other internal Ids/ARM Id might be changing. </param>
        /// <param name="testFailoverRecoveryFabricObjectId"> The test failover fabric object Id. </param>
        /// <param name="rpoInSeconds"> The last RPO value in seconds. </param>
        /// <param name="lastRpoCalculatedOn"> The time (in UTC) when the last RPO value was calculated by Protection Service. </param>
        /// <param name="primaryAvailabilityZone"> The primary availability zone. </param>
        /// <param name="recoveryAvailabilityZone"> The recovery availability zone. </param>
        /// <param name="primaryExtendedLocation"> The primary Extended Location. </param>
        /// <param name="recoveryExtendedLocation"> The recovery Extended Location. </param>
        /// <param name="vmEncryptionType"> The encryption type of the VM. </param>
        /// <param name="tfoAzureVmName"> The test failover vm name. </param>
        /// <param name="recoveryAzureGeneration"> The recovery azure generation. </param>
        /// <param name="recoveryProximityPlacementGroupId"> The recovery proximity placement group Id. </param>
        /// <param name="autoProtectionOfDataDisk"> A value indicating whether the auto protection is enabled. </param>
        /// <param name="recoveryVirtualMachineScaleSetId"> The recovery virtual machine scale set id. </param>
        /// <param name="recoveryCapacityReservationGroupId"> The recovery capacity reservation group Id. </param>
        /// <returns> A new <see cref="Models.A2AReplicationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static A2AReplicationDetails A2AReplicationDetails(ResourceIdentifier fabricObjectId, string initialPrimaryZone, AzureLocation? initialPrimaryFabricLocation, string initialRecoveryZone, SiteRecoveryExtendedLocation initialPrimaryExtendedLocation, SiteRecoveryExtendedLocation initialRecoveryExtendedLocation, AzureLocation? initialRecoveryFabricLocation, string multiVmGroupId, string multiVmGroupName, MultiVmGroupCreateOption? multiVmGroupCreateOption, string managementId, IEnumerable<A2AProtectedDiskDetails> protectedDisks, IEnumerable<A2AUnprotectedDiskDetails> unprotectedDisks, IEnumerable<A2AProtectedManagedDiskDetails> protectedManagedDisks, ResourceIdentifier recoveryBootDiagStorageAccountId, AzureLocation? primaryFabricLocation, AzureLocation? recoveryFabricLocation, string osType, string recoveryAzureVmSize, string recoveryAzureVmName, ResourceIdentifier recoveryAzureResourceGroupId, string recoveryCloudService, string recoveryAvailabilitySet, ResourceIdentifier selectedRecoveryAzureNetworkId, ResourceIdentifier selectedTfoAzureNetworkId, IEnumerable<VmNicDetails> vmNics, A2AVmSyncedConfigDetails vmSyncedConfigDetails, int? monitoringPercentageCompletion, string monitoringJobType, DateTimeOffset? lastHeartbeat, string agentVersion, DateTimeOffset? agentExpireOn, bool? isReplicationAgentUpdateRequired, DateTimeOffset? agentCertificateExpireOn, bool? isReplicationAgentCertificateUpdateRequired, ResourceIdentifier recoveryFabricObjectId, string vmProtectionState, string vmProtectionStateDescription, string lifecycleId, ResourceIdentifier testFailoverRecoveryFabricObjectId, long? rpoInSeconds, DateTimeOffset? lastRpoCalculatedOn, string primaryAvailabilityZone, string recoveryAvailabilityZone, SiteRecoveryExtendedLocation primaryExtendedLocation, SiteRecoveryExtendedLocation recoveryExtendedLocation, SiteRecoveryVmEncryptionType? vmEncryptionType, string tfoAzureVmName, string recoveryAzureGeneration, ResourceIdentifier recoveryProximityPlacementGroupId, AutoProtectionOfDataDisk? autoProtectionOfDataDisk, ResourceIdentifier recoveryVirtualMachineScaleSetId, ResourceIdentifier recoveryCapacityReservationGroupId)
            => A2AReplicationDetails(fabricObjectId, initialPrimaryZone, initialPrimaryFabricLocation, initialRecoveryZone, initialPrimaryExtendedLocation, initialRecoveryExtendedLocation, initialRecoveryFabricLocation, multiVmGroupId, multiVmGroupName, multiVmGroupCreateOption, managementId, protectedDisks, unprotectedDisks, protectedManagedDisks, recoveryBootDiagStorageAccountId, primaryFabricLocation, recoveryFabricLocation, osType, recoveryAzureVmSize, recoveryAzureVmName, recoveryAzureResourceGroupId, recoveryCloudService, recoveryAvailabilitySet, selectedRecoveryAzureNetworkId, selectedTfoAzureNetworkId, vmNics, vmSyncedConfigDetails, monitoringPercentageCompletion, monitoringJobType, lastHeartbeat, agentVersion, agentExpireOn, isReplicationAgentUpdateRequired, agentCertificateExpireOn, isReplicationAgentCertificateUpdateRequired, recoveryFabricObjectId, vmProtectionState, vmProtectionStateDescription, lifecycleId, testFailoverRecoveryFabricObjectId, rpoInSeconds, lastRpoCalculatedOn, primaryAvailabilityZone, recoveryAvailabilityZone, primaryExtendedLocation, recoveryExtendedLocation, vmEncryptionType, tfoAzureVmName, recoveryAzureGeneration, recoveryProximityPlacementGroupId, autoProtectionOfDataDisk, recoveryVirtualMachineScaleSetId, recoveryCapacityReservationGroupId, null);

        /// <summary> Initializes a new instance of HyperVReplicaAzureReplicationDetails. </summary>
        /// <param name="azureVmDiskDetails"> Azure VM Disk details. </param>
        /// <param name="recoveryAzureVmName"> Recovery Azure given name. </param>
        /// <param name="recoveryAzureVmSize"> The Recovery Azure VM size. </param>
        /// <param name="recoveryAzureStorageAccount"> The recovery Azure storage account. </param>
        /// <param name="recoveryAzureLogStorageAccountId"> The ARM id of the log storage account used for replication. This will be set to null if no log storage account was provided during enable protection. </param>
        /// <param name="lastReplicatedOn"> The Last replication time. </param>
        /// <param name="rpoInSeconds"> Last RPO value. </param>
        /// <param name="lastRpoCalculatedOn"> The last RPO calculated time. </param>
        /// <param name="vmId"> The virtual machine Id. </param>
        /// <param name="vmProtectionState"> The protection state for the vm. </param>
        /// <param name="vmProtectionStateDescription"> The protection state description for the vm. </param>
        /// <param name="initialReplicationDetails"> Initial replication details. </param>
        /// <param name="vmNics"> The PE Network details. </param>
        /// <param name="selectedRecoveryAzureNetworkId"> The selected recovery azure network Id. </param>
        /// <param name="selectedSourceNicId"> The selected source nic Id which will be used as the primary nic during failover. </param>
        /// <param name="encryption"> The encryption info. </param>
        /// <param name="osDetails"> The operating system info. </param>
        /// <param name="sourceVmRamSizeInMB"> The RAM size of the VM on the primary side. </param>
        /// <param name="sourceVmCpuCount"> The CPU count of the VM on the primary side. </param>
        /// <param name="enableRdpOnTargetOption"> The selected option to enable RDP\SSH on target vm after failover. String value of SrsDataContract.EnableRDPOnTargetOption enum. </param>
        /// <param name="recoveryAzureResourceGroupId"> The target resource group Id. </param>
        /// <param name="recoveryAvailabilitySetId"> The recovery availability set Id. </param>
        /// <param name="targetAvailabilityZone"> The target availability zone. </param>
        /// <param name="targetProximityPlacementGroupId"> The target proximity placement group Id. </param>
        /// <param name="useManagedDisks"> A value indicating whether managed disks should be used during failover. </param>
        /// <param name="licenseType"> License Type of the VM to be used. </param>
        /// <param name="sqlServerLicenseType"> The SQL Server license type. </param>
        /// <param name="lastRecoveryPointReceived"> The last recovery point received time. </param>
        /// <param name="targetVmTags"> The target VM tags. </param>
        /// <param name="seedManagedDiskTags"> The tags for the seed managed disks. </param>
        /// <param name="targetManagedDiskTags"> The tags for the target managed disks. </param>
        /// <param name="targetNicTags"> The tags for the target NICs. </param>
        /// <param name="protectedManagedDisks"> The list of protected managed disks. </param>
        /// <returns> A new <see cref="Models.HyperVReplicaAzureReplicationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HyperVReplicaAzureReplicationDetails HyperVReplicaAzureReplicationDetails(IEnumerable<SiteRecoveryVmDiskDetails> azureVmDiskDetails, string recoveryAzureVmName, string recoveryAzureVmSize, string recoveryAzureStorageAccount, ResourceIdentifier recoveryAzureLogStorageAccountId, DateTimeOffset? lastReplicatedOn, long? rpoInSeconds, DateTimeOffset? lastRpoCalculatedOn, string vmId, string vmProtectionState, string vmProtectionStateDescription, InitialReplicationDetails initialReplicationDetails, IEnumerable<VmNicDetails> vmNics, ResourceIdentifier selectedRecoveryAzureNetworkId, string selectedSourceNicId, string encryption, SiteRecoveryOSDetails osDetails, int? sourceVmRamSizeInMB, int? sourceVmCpuCount, string enableRdpOnTargetOption, ResourceIdentifier recoveryAzureResourceGroupId, ResourceIdentifier recoveryAvailabilitySetId, string targetAvailabilityZone, ResourceIdentifier targetProximityPlacementGroupId, string useManagedDisks, string licenseType, string sqlServerLicenseType, DateTimeOffset? lastRecoveryPointReceived, IReadOnlyDictionary<string, string> targetVmTags, IReadOnlyDictionary<string, string> seedManagedDiskTags, IReadOnlyDictionary<string, string> targetManagedDiskTags, IReadOnlyDictionary<string, string> targetNicTags, IEnumerable<HyperVReplicaAzureManagedDiskDetails> protectedManagedDisks)
            => HyperVReplicaAzureReplicationDetails(azureVmDiskDetails, recoveryAzureVmName, recoveryAzureVmSize, recoveryAzureStorageAccount, recoveryAzureLogStorageAccountId, lastReplicatedOn, rpoInSeconds, lastRpoCalculatedOn, vmId, vmProtectionState, vmProtectionStateDescription, initialReplicationDetails, vmNics, selectedRecoveryAzureNetworkId, selectedSourceNicId, encryption, osDetails, sourceVmRamSizeInMB, sourceVmCpuCount, enableRdpOnTargetOption, recoveryAzureResourceGroupId, recoveryAvailabilitySetId, targetAvailabilityZone, targetProximityPlacementGroupId, useManagedDisks, licenseType, sqlServerLicenseType, lastRecoveryPointReceived, targetVmTags, seedManagedDiskTags, targetManagedDiskTags, targetNicTags, protectedManagedDisks, null);

        /// <summary> Initializes a new instance of InMageAzureV2ReplicationDetails. </summary>
        /// <param name="infrastructureVmId"> The infrastructure VM Id. </param>
        /// <param name="vCenterInfrastructureId"> The vCenter infrastructure Id. </param>
        /// <param name="protectionStage"> The protection stage. </param>
        /// <param name="vmId"> The virtual machine Id. </param>
        /// <param name="vmProtectionState"> The protection state for the vm. </param>
        /// <param name="vmProtectionStateDescription"> The protection state description for the vm. </param>
        /// <param name="resyncProgressPercentage"> The resync progress percentage. </param>
        /// <param name="rpoInSeconds"> The RPO in seconds. </param>
        /// <param name="compressedDataRateInMB"> The compressed data change rate in MB. </param>
        /// <param name="uncompressedDataRateInMB"> The uncompressed data change rate in MB. </param>
        /// <param name="ipAddress"> The source IP address. </param>
        /// <param name="agentVersion"> The agent version. </param>
        /// <param name="agentExpireOn"> Agent expiry date. </param>
        /// <param name="isAgentUpdateRequired"> A value indicating whether installed agent needs to be updated. </param>
        /// <param name="isRebootAfterUpdateRequired"> A value indicating whether the source server requires a restart after update. </param>
        /// <param name="lastHeartbeat"> The last heartbeat received from the source server. </param>
        /// <param name="processServerId"> The process server Id. </param>
        /// <param name="processServerName"> The process server name. </param>
        /// <param name="multiVmGroupId"> The multi vm group Id. </param>
        /// <param name="multiVmGroupName"> The multi vm group name. </param>
        /// <param name="multiVmSyncStatus"> A value indicating whether multi vm sync is enabled or disabled. </param>
        /// <param name="protectedDisks"> The list of protected disks. </param>
        /// <param name="diskResized"> A value indicating whether any disk is resized for this VM. </param>
        /// <param name="masterTargetId"> The master target Id. </param>
        /// <param name="sourceVmCpuCount"> The CPU count of the VM on the primary side. </param>
        /// <param name="sourceVmRamSizeInMB"> The RAM size of the VM on the primary side. </param>
        /// <param name="osType"> The type of the OS on the VM. </param>
        /// <param name="vhdName"> The OS disk VHD name. </param>
        /// <param name="osDiskId"> The id of the disk containing the OS. </param>
        /// <param name="azureVmDiskDetails"> Azure VM Disk details. </param>
        /// <param name="recoveryAzureVmName"> Recovery Azure given name. </param>
        /// <param name="recoveryAzureVmSize"> The Recovery Azure VM size. </param>
        /// <param name="recoveryAzureStorageAccount"> The recovery Azure storage account. </param>
        /// <param name="recoveryAzureLogStorageAccountId"> The ARM id of the log storage account used for replication. This will be set to null if no log storage account was provided during enable protection. </param>
        /// <param name="vmNics"> The PE Network details. </param>
        /// <param name="selectedRecoveryAzureNetworkId"> The selected recovery azure network Id. </param>
        /// <param name="selectedTfoAzureNetworkId"> The test failover virtual network. </param>
        /// <param name="selectedSourceNicId"> The selected source nic Id which will be used as the primary nic during failover. </param>
        /// <param name="discoveryType"> A value indicating the discovery type of the machine. Value can be vCenter or physical. </param>
        /// <param name="enableRdpOnTargetOption"> The selected option to enable RDP\SSH on target vm after failover. String value of SrsDataContract.EnableRDPOnTargetOption enum. </param>
        /// <param name="datastores"> The datastores of the on-premise machine. Value can be list of strings that contain datastore names. </param>
        /// <param name="targetVmId"> The ARM Id of the target Azure VM. This value will be null until the VM is failed over. Only after failure it will be populated with the ARM Id of the Azure VM. </param>
        /// <param name="recoveryAzureResourceGroupId"> The target resource group Id. </param>
        /// <param name="recoveryAvailabilitySetId"> The recovery availability set Id. </param>
        /// <param name="targetAvailabilityZone"> The target availability zone. </param>
        /// <param name="targetProximityPlacementGroupId"> The target proximity placement group Id. </param>
        /// <param name="useManagedDisks"> A value indicating whether managed disks should be used during failover. </param>
        /// <param name="licenseType"> License Type of the VM to be used. </param>
        /// <param name="sqlServerLicenseType"> The SQL Server license type. </param>
        /// <param name="validationErrors"> The validation errors of the on-premise machine Value can be list of validation errors. </param>
        /// <param name="lastRpoCalculatedOn"> The last RPO calculated time. </param>
        /// <param name="lastUpdateReceivedOn"> The last update time received from on-prem components. </param>
        /// <param name="replicaId"> The replica id of the protected item. </param>
        /// <param name="osVersion"> The OS Version of the protected item. </param>
        /// <param name="protectedManagedDisks"> The list of protected managed disks. </param>
        /// <param name="lastRecoveryPointReceived"> The last recovery point received time. </param>
        /// <param name="firmwareType"> The firmware type of this protected item. </param>
        /// <param name="azureVmGeneration"> The target generation for this protected item. </param>
        /// <param name="isAdditionalStatsAvailable"> A value indicating whether additional IR stats are available or not. </param>
        /// <param name="totalDataTransferred"> The total transferred data in bytes. </param>
        /// <param name="totalProgressHealth"> The progress health. </param>
        /// <param name="targetVmTags"> The target VM tags. </param>
        /// <param name="seedManagedDiskTags"> The tags for the seed managed disks. </param>
        /// <param name="targetManagedDiskTags"> The tags for the target managed disks. </param>
        /// <param name="targetNicTags"> The tags for the target NICs. </param>
        /// <param name="switchProviderBlockingErrorDetails"> The switch provider blocking error information. </param>
        /// <param name="switchProviderDetails"> The switch provider blocking error information. </param>
        /// <returns> A new <see cref="Models.InMageAzureV2ReplicationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static InMageAzureV2ReplicationDetails InMageAzureV2ReplicationDetails(string infrastructureVmId, string vCenterInfrastructureId, string protectionStage, string vmId, string vmProtectionState, string vmProtectionStateDescription, int? resyncProgressPercentage, long? rpoInSeconds, double? compressedDataRateInMB, double? uncompressedDataRateInMB, IPAddress ipAddress, string agentVersion, DateTimeOffset? agentExpireOn, string isAgentUpdateRequired, string isRebootAfterUpdateRequired, DateTimeOffset? lastHeartbeat, Guid? processServerId, string processServerName, string multiVmGroupId, string multiVmGroupName, string multiVmSyncStatus, IEnumerable<InMageAzureV2ProtectedDiskDetails> protectedDisks, string diskResized, string masterTargetId, int? sourceVmCpuCount, int? sourceVmRamSizeInMB, string osType, string vhdName, string osDiskId, IEnumerable<SiteRecoveryVmDiskDetails> azureVmDiskDetails, string recoveryAzureVmName, string recoveryAzureVmSize, string recoveryAzureStorageAccount, ResourceIdentifier recoveryAzureLogStorageAccountId, IEnumerable<VmNicDetails> vmNics, ResourceIdentifier selectedRecoveryAzureNetworkId, ResourceIdentifier selectedTfoAzureNetworkId, string selectedSourceNicId, string discoveryType, string enableRdpOnTargetOption, IEnumerable<string> datastores, string targetVmId, ResourceIdentifier recoveryAzureResourceGroupId, ResourceIdentifier recoveryAvailabilitySetId, string targetAvailabilityZone, ResourceIdentifier targetProximityPlacementGroupId, string useManagedDisks, string licenseType, string sqlServerLicenseType, IEnumerable<SiteRecoveryHealthError> validationErrors, DateTimeOffset? lastRpoCalculatedOn, DateTimeOffset? lastUpdateReceivedOn, string replicaId, string osVersion, IEnumerable<InMageAzureV2ManagedDiskDetails> protectedManagedDisks, DateTimeOffset? lastRecoveryPointReceived, string firmwareType, string azureVmGeneration, bool? isAdditionalStatsAvailable, long? totalDataTransferred, string totalProgressHealth, IReadOnlyDictionary<string, string> targetVmTags, IReadOnlyDictionary<string, string> seedManagedDiskTags, IReadOnlyDictionary<string, string> targetManagedDiskTags, IReadOnlyDictionary<string, string> targetNicTags, IEnumerable<InMageAzureV2SwitchProviderBlockingErrorDetails> switchProviderBlockingErrorDetails, InMageAzureV2SwitchProviderDetails switchProviderDetails)
            => InMageAzureV2ReplicationDetails(infrastructureVmId, vCenterInfrastructureId, protectionStage, vmId, vmProtectionState, vmProtectionStateDescription, resyncProgressPercentage, rpoInSeconds, compressedDataRateInMB, uncompressedDataRateInMB, ipAddress, agentVersion, agentExpireOn, isAgentUpdateRequired, isRebootAfterUpdateRequired, lastHeartbeat, processServerId, processServerName, multiVmGroupId, multiVmGroupName, multiVmSyncStatus, protectedDisks, diskResized, masterTargetId, sourceVmCpuCount, sourceVmRamSizeInMB, osType, vhdName, osDiskId, azureVmDiskDetails, recoveryAzureVmName, recoveryAzureVmSize, recoveryAzureStorageAccount, recoveryAzureLogStorageAccountId, vmNics, selectedRecoveryAzureNetworkId, selectedTfoAzureNetworkId, selectedSourceNicId, discoveryType, enableRdpOnTargetOption, datastores, targetVmId, recoveryAzureResourceGroupId, recoveryAvailabilitySetId, targetAvailabilityZone, targetProximityPlacementGroupId, useManagedDisks, licenseType, sqlServerLicenseType, validationErrors, lastRpoCalculatedOn, lastUpdateReceivedOn, replicaId, osVersion, protectedManagedDisks, lastRecoveryPointReceived, firmwareType, azureVmGeneration, isAdditionalStatsAvailable, totalDataTransferred, totalProgressHealth, targetVmTags, seedManagedDiskTags, targetManagedDiskTags, targetNicTags, switchProviderBlockingErrorDetails, switchProviderDetails, null, null, null);

        /// <summary> Initializes a new instance of VMwareCbtMigrationDetails. </summary>
        /// <param name="vmwareMachineId"> The ARM Id of the VM discovered in VMware. </param>
        /// <param name="osType"> The type of the OS on the VM. </param>
        /// <param name="osName"> The name of the OS on the VM. </param>
        /// <param name="firmwareType"> The firmware type. </param>
        /// <param name="targetGeneration"> The target generation. </param>
        /// <param name="licenseType"> License Type of the VM to be used. </param>
        /// <param name="sqlServerLicenseType"> The SQL Server license type. </param>
        /// <param name="dataMoverRunAsAccountId"> The data mover run as account Id. </param>
        /// <param name="snapshotRunAsAccountId"> The snapshot run as account Id. </param>
        /// <param name="storageAccountId"> The replication storage account ARM Id. This is applicable only for the blob based replication test hook. </param>
        /// <param name="targetVmName"> Target VM name. </param>
        /// <param name="targetVmSize"> The target VM size. </param>
        /// <param name="targetLocation"> The target location. </param>
        /// <param name="targetResourceGroupId"> The target resource group Id. </param>
        /// <param name="targetAvailabilitySetId"> The target availability set Id. </param>
        /// <param name="targetAvailabilityZone"> The target availability zone. </param>
        /// <param name="targetProximityPlacementGroupId"> The target proximity placement group Id. </param>
        /// <param name="confidentialVmKeyVaultId"> The confidential VM key vault Id for ADE installation. </param>
        /// <param name="targetVmSecurityProfile"> The target VM security profile. </param>
        /// <param name="targetBootDiagnosticsStorageAccountId"> The target boot diagnostics storage account ARM Id. </param>
        /// <param name="targetVmTags"> The target VM tags. </param>
        /// <param name="protectedDisks"> The list of protected disks. </param>
        /// <param name="targetNetworkId"> The target network Id. </param>
        /// <param name="testNetworkId"> The test network Id. </param>
        /// <param name="vmNics"> The network details. </param>
        /// <param name="targetNicTags"> The tags for the target NICs. </param>
        /// <param name="migrationRecoveryPointId"> The recovery point Id to which the VM was migrated. </param>
        /// <param name="lastRecoveryPointReceived"> The last recovery point received time. </param>
        /// <param name="lastRecoveryPointId"> The last recovery point Id. </param>
        /// <param name="initialSeedingProgressPercentage"> The initial seeding progress percentage. </param>
        /// <param name="migrationProgressPercentage"> The migration progress percentage. </param>
        /// <param name="resyncProgressPercentage"> The resync progress percentage. </param>
        /// <param name="resumeProgressPercentage"> The resume progress percentage. </param>
        /// <param name="initialSeedingRetryCount"> The initial seeding retry count. </param>
        /// <param name="resyncRetryCount"> The resync retry count. </param>
        /// <param name="resumeRetryCount"> The resume retry count. </param>
        /// <param name="resyncRequired"> A value indicating whether resync is required. </param>
        /// <param name="resyncState"> The resync state. </param>
        /// <param name="performAutoResync"> A value indicating whether auto resync is to be done. </param>
        /// <param name="seedDiskTags"> The tags for the seed disks. </param>
        /// <param name="targetDiskTags"> The tags for the target disks. </param>
        /// <param name="supportedOSVersions"> List of supported inplace OS Upgrade versions. </param>
        /// <returns> A new <see cref="Models.VMwareCbtMigrationDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VMwareCbtMigrationDetails VMwareCbtMigrationDetails(ResourceIdentifier vmwareMachineId, string osType, string osName, string firmwareType, string targetGeneration, string licenseType, string sqlServerLicenseType, ResourceIdentifier dataMoverRunAsAccountId, ResourceIdentifier snapshotRunAsAccountId, ResourceIdentifier storageAccountId, string targetVmName, string targetVmSize, string targetLocation, ResourceIdentifier targetResourceGroupId, ResourceIdentifier targetAvailabilitySetId, string targetAvailabilityZone, ResourceIdentifier targetProximityPlacementGroupId, ResourceIdentifier confidentialVmKeyVaultId, VMwareCbtSecurityProfileProperties targetVmSecurityProfile, ResourceIdentifier targetBootDiagnosticsStorageAccountId, IReadOnlyDictionary<string, string> targetVmTags, IEnumerable<VMwareCbtProtectedDiskDetails> protectedDisks, ResourceIdentifier targetNetworkId, ResourceIdentifier testNetworkId, IEnumerable<VMwareCbtNicDetails> vmNics, IReadOnlyDictionary<string, string> targetNicTags, ResourceIdentifier migrationRecoveryPointId, DateTimeOffset? lastRecoveryPointReceived, ResourceIdentifier lastRecoveryPointId, int? initialSeedingProgressPercentage, int? migrationProgressPercentage, int? resyncProgressPercentage, int? resumeProgressPercentage, long? initialSeedingRetryCount, long? resyncRetryCount, long? resumeRetryCount, string resyncRequired, SiteRecoveryResyncState? resyncState, string performAutoResync, IReadOnlyDictionary<string, string> seedDiskTags, IReadOnlyDictionary<string, string> targetDiskTags, IEnumerable<string> supportedOSVersions)
            => VMwareCbtMigrationDetails(vmwareMachineId, osType, osName, firmwareType, targetGeneration, licenseType, sqlServerLicenseType, dataMoverRunAsAccountId, snapshotRunAsAccountId, storageAccountId, targetVmName, targetVmSize, targetLocation, targetResourceGroupId, targetAvailabilitySetId, targetAvailabilityZone, targetProximityPlacementGroupId, confidentialVmKeyVaultId, targetVmSecurityProfile, targetBootDiagnosticsStorageAccountId, targetVmTags, protectedDisks, targetNetworkId, testNetworkId, vmNics, targetNicTags, migrationRecoveryPointId, lastRecoveryPointReceived, lastRecoveryPointId, initialSeedingProgressPercentage, migrationProgressPercentage, resyncProgressPercentage, resumeProgressPercentage, null, null, initialSeedingRetryCount, resyncRetryCount, resumeRetryCount, null, resyncRequired, resyncState, performAutoResync, seedDiskTags, targetDiskTags, supportedOSVersions, null, null, null);

        /// <summary> Initializes a new instance of VMwareCbtProtectedDiskDetails. </summary>
        /// <param name="diskId"> The disk id. </param>
        /// <param name="diskName"> The disk name. </param>
        /// <param name="diskType"> The disk type. </param>
        /// <param name="diskPath"> The disk path. </param>
        /// <param name="isOSDisk"> A value indicating whether the disk is the OS disk. </param>
        /// <param name="capacityInBytes"> The disk capacity in bytes. </param>
        /// <param name="logStorageAccountId"> The log storage account ARM Id. </param>
        /// <param name="logStorageAccountSasSecretName"> The key vault secret name of the log storage account. </param>
        /// <param name="diskEncryptionSetId"> The DiskEncryptionSet ARM Id. </param>
        /// <param name="seedManagedDiskId"> The ARM Id of the seed managed disk. </param>
        /// <param name="seedBlobUri"> The uri of the seed blob. </param>
        /// <param name="targetManagedDiskId"> The ARM Id of the target managed disk. </param>
        /// <param name="targetBlobUri"> The uri of the target blob. </param>
        /// <param name="targetDiskName"> The name for the target managed disk. </param>
        /// <returns> A new <see cref="Models.VMwareCbtProtectedDiskDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VMwareCbtProtectedDiskDetails VMwareCbtProtectedDiskDetails(string diskId, string diskName, SiteRecoveryDiskAccountType? diskType, string diskPath, string isOSDisk, long? capacityInBytes, ResourceIdentifier logStorageAccountId, string logStorageAccountSasSecretName, ResourceIdentifier diskEncryptionSetId, string seedManagedDiskId, Uri seedBlobUri, string targetManagedDiskId, Uri targetBlobUri, string targetDiskName)
            => VMwareCbtProtectedDiskDetails(diskId, diskName, diskType, diskPath, isOSDisk, capacityInBytes, logStorageAccountId, logStorageAccountSasSecretName, diskEncryptionSetId, seedManagedDiskId, seedBlobUri, targetManagedDiskId, targetBlobUri, targetDiskName, null);
    }
}