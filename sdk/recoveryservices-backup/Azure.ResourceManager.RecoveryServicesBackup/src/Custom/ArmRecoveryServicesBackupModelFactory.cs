// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServicesBackup;

namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmRecoveryServicesBackupModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.BackupGenericProtectedItem"/>. </summary>
        /// <param name="protectedItemType"> backup item type. </param>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <returns> A new <see cref="Models.BackupGenericProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupGenericProtectedItem BackupGenericProtectedItem(string protectedItemType, BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays)
            => BackupGenericProtectedItem(protectedItemType, backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests , isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null);

        /// <summary> Initializes a new instance of <see cref="Models.BackupStatusResult"/>. </summary>
        /// <param name="protectionStatus"> Specifies whether the container is registered or not. </param>
        /// <param name="vaultId"> Specifies the arm resource id of the vault. </param>
        /// <param name="fabricName"> Specifies the fabric name - Azure or AD. </param>
        /// <param name="containerName"> Specifies the product specific container name. E.g. iaasvmcontainer;iaasvmcontainer;csname;vmname. </param>
        /// <param name="protectedItemName"> Specifies the product specific ds name. E.g. vm;iaasvmcontainer;csname;vmname. </param>
        /// <param name="errorCode"> ErrorCode in case of intent failed. </param>
        /// <param name="errorMessage"> ErrorMessage in case of intent failed. </param>
        /// <param name="policyName"> Specifies the policy name which is used for protection. </param>
        /// <param name="registrationStatus"> Container registration status. </param>
        /// <returns> A new <see cref="Models.BackupStatusResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BackupStatusResult BackupStatusResult(BackupProtectionStatus? protectionStatus, ResourceIdentifier vaultId, BackupFabricName? fabricName, string containerName, string protectedItemName, string errorCode, string errorMessage, string policyName, string registrationStatus)
            => BackupStatusResult(protectionStatus, vaultId, fabricName, containerName, protectedItemName, errorCode, errorMessage, policyName, registrationStatus, null, null);

        /// <summary> Initializes a new instance of <see cref="Models.DpmProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the managed item. </param>
        /// <param name="backupEngineName"> Backup Management server protecting this backup item. </param>
        /// <param name="protectionState"> Protection state of the backup engine. </param>
        /// <param name="extendedInfo"> Extended info of the backup item. </param>
        /// <returns> A new <see cref="Models.DpmProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DpmProtectedItem DpmProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string backupEngineName, ProtectedItemState? protectionState, DpmProtectedItemExtendedInfo extendedInfo)
            => DpmProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, backupEngineName, protectionState, extendedInfo);

        /// <summary> Initializes a new instance of <see cref="Models.FileshareProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the fileshare represented by this backup item. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. Possible values: Healthy, Unhealthy. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="extendedInfo"> Additional information with this backup item. </param>
        /// <returns> A new <see cref="Models.FileshareProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileshareProtectedItem FileshareProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string protectionStatus, BackupProtectionState? protectionState, string lastBackupStatus, DateTimeOffset? lastBackupOn, IDictionary<string, KpiResourceHealthDetails> kpisHealths, FileshareProtectedItemExtendedInfo extendedInfo)
            => FileshareProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, protectionStatus, protectionState, lastBackupStatus, lastBackupOn, kpisHealths, extendedInfo);

        /// <summary> Initializes a new instance of <see cref="Models.GenericProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the container. </param>
        /// <param name="policyState"> Indicates consistency of policy object and policy applied to this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="protectedItemId"> Data Plane Service ID of the protected item. </param>
        /// <param name="sourceAssociations"> Loosely coupled (type, value) associations (example - parent of a protected item). </param>
        /// <param name="fabricName"> Name of this backup item's fabric. </param>
        /// <returns> A new <see cref="Models.GenericProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static GenericProtectedItem GenericProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string policyState, BackupProtectionState? protectionState, long? protectedItemId, IDictionary<string, string> sourceAssociations, string fabricName)
            => GenericProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, policyState, protectionState, protectedItemId, sourceAssociations, fabricName);

        /// <summary> Initializes a new instance of <see cref="Models.IaasClassicComputeVmProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the VM represented by this backup item. </param>
        /// <param name="virtualMachineId"> Fully qualified ARM ID of the virtual machine represented by this item. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="healthStatus"> Health status of protected item. </param>
        /// <param name="healthDetails"> Health details on this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="protectedItemDataId"> Data ID of the protected item. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="extendedProperties"> Extended Properties for Azure IaasVM Backup. </param>
        /// <returns> A new <see cref="Models.IaasClassicComputeVmProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IaasClassicComputeVmProtectedItem IaasClassicComputeVmProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, ResourceIdentifier virtualMachineId, string protectionStatus, BackupProtectionState? protectionState, IaasVmProtectedItemHealthStatus? healthStatus, IEnumerable<IaasVmHealthDetails> healthDetails, IDictionary<string, KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, DateTimeOffset? lastBackupOn, string protectedItemDataId, IaasVmProtectedItemExtendedInfo extendedInfo, IaasVmBackupExtendedProperties extendedProperties)
            => IaasClassicComputeVmProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, virtualMachineId, protectionStatus, protectionState, healthStatus, healthDetails, kpisHealths, lastBackupStatus, lastBackupOn, protectedItemDataId, extendedInfo, extendedProperties);

        /// <summary> Initializes a new instance of <see cref="Models.IaasComputeVmProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the VM represented by this backup item. </param>
        /// <param name="virtualMachineId"> Fully qualified ARM ID of the virtual machine represented by this item. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="healthStatus"> Health status of protected item. </param>
        /// <param name="healthDetails"> Health details on this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="protectedItemDataId"> Data ID of the protected item. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="extendedProperties"> Extended Properties for Azure IaasVM Backup. </param>
        /// <returns> A new <see cref="Models.IaasComputeVmProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IaasComputeVmProtectedItem IaasComputeVmProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, ResourceIdentifier virtualMachineId, string protectionStatus, BackupProtectionState? protectionState, IaasVmProtectedItemHealthStatus? healthStatus, IEnumerable<IaasVmHealthDetails> healthDetails, IDictionary<string, KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, DateTimeOffset? lastBackupOn, string protectedItemDataId, IaasVmProtectedItemExtendedInfo extendedInfo, IaasVmBackupExtendedProperties extendedProperties)
            => IaasComputeVmProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, virtualMachineId, protectionStatus, protectionState, healthStatus, healthDetails, kpisHealths, lastBackupStatus, lastBackupOn, protectedItemDataId, extendedInfo, extendedProperties);

        /// <summary> Initializes a new instance of <see cref="Models.IaasVmProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the VM represented by this backup item. </param>
        /// <param name="virtualMachineId"> Fully qualified ARM ID of the virtual machine represented by this item. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="healthStatus"> Health status of protected item. </param>
        /// <param name="healthDetails"> Health details on this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="protectedItemDataId"> Data ID of the protected item. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="extendedProperties"> Extended Properties for Azure IaasVM Backup. </param>
        /// <returns> A new <see cref="Models.IaasVmProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IaasVmProtectedItem IaasVmProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, ResourceIdentifier virtualMachineId, string protectionStatus, BackupProtectionState? protectionState, IaasVmProtectedItemHealthStatus? healthStatus, IEnumerable<IaasVmHealthDetails> healthDetails, IDictionary<string, KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, DateTimeOffset? lastBackupOn, string protectedItemDataId, IaasVmProtectedItemExtendedInfo extendedInfo, IaasVmBackupExtendedProperties extendedProperties)
            => IaasVmProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, virtualMachineId, protectionStatus, protectionState, healthStatus, healthDetails, kpisHealths, lastBackupStatus, lastBackupOn, protectedItemDataId, extendedInfo, extendedProperties);

        /// <summary> Initializes a new instance of <see cref="Models.MabFileFolderProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of this backup item. </param>
        /// <param name="computerName"> Name of the computer associated with this backup item. </param>
        /// <param name="lastBackupStatus"> Status of last backup operation. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="protectionState"> Protected, ProtectionStopped, IRPending or ProtectionError. </param>
        /// <param name="deferredDeleteSyncTimeInUTC"> Sync time for deferred deletion in UTC. </param>
        /// <param name="extendedInfo"> Additional information with this backup item. </param>
        /// <returns> A new <see cref="Models.MabFileFolderProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MabFileFolderProtectedItem MabFileFolderProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string computerName, string lastBackupStatus, DateTimeOffset? lastBackupOn, string protectionState, long? deferredDeleteSyncTimeInUTC, MabFileFolderProtectedItemExtendedInfo extendedInfo)
            => MabFileFolderProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, computerName, lastBackupStatus, lastBackupOn, protectionState, deferredDeleteSyncTimeInUTC, extendedInfo);

        /// <summary> Initializes a new instance of <see cref="Models.SqlProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="protectedItemDataId"> Internal ID of a backup item. Used by Azure SQL Backup engine to contact Recovery Services. </param>
        /// <param name="protectionState"> Backup state of the backed up item. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <returns> A new <see cref="Models.SqlProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SqlProtectedItem SqlProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string protectedItemDataId, ProtectedItemState? protectionState, SqlProtectedItemExtendedInfo extendedInfo)
            => SqlProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, protectedItemDataId, protectionState, extendedInfo);

        /// <summary> Initializes a new instance of <see cref="Models.VmWorkloadProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the DB represented by this backup item. </param>
        /// <param name="serverName"> Host/Cluster Name for instance or AG. </param>
        /// <param name="parentName"> Parent name of the DB such as Instance or Availability Group. </param>
        /// <param name="parentType"> Parent type of protected item, example: for a DB, standalone server or distributed. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. Possible values: Healthy, Unhealthy. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="lastBackupErrorDetail"> Error details in last backup. </param>
        /// <param name="protectedItemDataSourceId"> Data ID of the protected item. </param>
        /// <param name="protectedItemHealthStatus"> Health status of the backup item, evaluated based on last heartbeat received. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="nodesList"> List of the nodes in case of distributed container. </param>
        /// <returns> A new <see cref="Models.VmWorkloadProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VmWorkloadProtectedItem VmWorkloadProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, BackupProtectionState? protectionState, LastBackupStatus? lastBackupStatus, DateTimeOffset? lastBackupOn, BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, VmWorkloadProtectedItemExtendedInfo extendedInfo, IDictionary<string, KpiResourceHealthDetails> kpisHealths, IEnumerable<DistributedNodesInfo> nodesList)
            => VmWorkloadProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, serverName, parentName, parentType, protectionStatus, protectionState, lastBackupStatus, lastBackupOn, lastBackupErrorDetail, protectedItemDataSourceId, protectedItemHealthStatus, extendedInfo, kpisHealths, nodesList);

        /// <summary> Initializes a new instance of <see cref="Models.VmWorkloadSapAseDatabaseProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the DB represented by this backup item. </param>
        /// <param name="serverName"> Host/Cluster Name for instance or AG. </param>
        /// <param name="parentName"> Parent name of the DB such as Instance or Availability Group. </param>
        /// <param name="parentType"> Parent type of protected item, example: for a DB, standalone server or distributed. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. Possible values: Healthy, Unhealthy. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="lastBackupErrorDetail"> Error details in last backup. </param>
        /// <param name="protectedItemDataSourceId"> Data ID of the protected item. </param>
        /// <param name="protectedItemHealthStatus"> Health status of the backup item, evaluated based on last heartbeat received. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="nodesList"> List of the nodes in case of distributed container. </param>
        /// <returns> A new <see cref="Models.VmWorkloadSapAseDatabaseProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VmWorkloadSapAseDatabaseProtectedItem VmWorkloadSapAseDatabaseProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, BackupProtectionState? protectionState, LastBackupStatus? lastBackupStatus, DateTimeOffset? lastBackupOn, BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, VmWorkloadProtectedItemExtendedInfo extendedInfo, IDictionary<string, KpiResourceHealthDetails> kpisHealths, IEnumerable<DistributedNodesInfo> nodesList)
            => VmWorkloadSapAseDatabaseProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, serverName, parentName, parentType, protectionStatus, protectionState, lastBackupStatus, lastBackupOn, lastBackupErrorDetail, protectedItemDataSourceId, protectedItemHealthStatus, extendedInfo, kpisHealths, nodesList);

        /// <summary> Initializes a new instance of <see cref="Models.VmWorkloadSapHanaDatabaseProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the DB represented by this backup item. </param>
        /// <param name="serverName"> Host/Cluster Name for instance or AG. </param>
        /// <param name="parentName"> Parent name of the DB such as Instance or Availability Group. </param>
        /// <param name="parentType"> Parent type of protected item, example: for a DB, standalone server or distributed. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. Possible values: Healthy, Unhealthy. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="lastBackupErrorDetail"> Error details in last backup. </param>
        /// <param name="protectedItemDataSourceId"> Data ID of the protected item. </param>
        /// <param name="protectedItemHealthStatus"> Health status of the backup item, evaluated based on last heartbeat received. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="nodesList"> List of the nodes in case of distributed container. </param>
        /// <returns> A new <see cref="Models.VmWorkloadSapHanaDatabaseProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VmWorkloadSapHanaDatabaseProtectedItem VmWorkloadSapHanaDatabaseProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, BackupProtectionState? protectionState, LastBackupStatus? lastBackupStatus, DateTimeOffset? lastBackupOn, BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, VmWorkloadProtectedItemExtendedInfo extendedInfo, IDictionary<string, KpiResourceHealthDetails> kpisHealths, IEnumerable<DistributedNodesInfo> nodesList)
            => VmWorkloadSapHanaDatabaseProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, serverName, parentName, parentType, protectionStatus, protectionState, lastBackupStatus, lastBackupOn, lastBackupErrorDetail, protectedItemDataSourceId, protectedItemHealthStatus, extendedInfo, kpisHealths, nodesList);

        /// <summary> Initializes a new instance of <see cref="Models.VmWorkloadSapHanaDBInstanceProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the DB represented by this backup item. </param>
        /// <param name="serverName"> Host/Cluster Name for instance or AG. </param>
        /// <param name="parentName"> Parent name of the DB such as Instance or Availability Group. </param>
        /// <param name="parentType"> Parent type of protected item, example: for a DB, standalone server or distributed. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. Possible values: Healthy, Unhealthy. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="lastBackupErrorDetail"> Error details in last backup. </param>
        /// <param name="protectedItemDataSourceId"> Data ID of the protected item. </param>
        /// <param name="protectedItemHealthStatus"> Health status of the backup item, evaluated based on last heartbeat received. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="nodesList"> List of the nodes in case of distributed container. </param>
        /// <returns> A new <see cref="Models.VmWorkloadSapHanaDBInstanceProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VmWorkloadSapHanaDBInstanceProtectedItem VmWorkloadSapHanaDBInstanceProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, BackupProtectionState? protectionState, LastBackupStatus? lastBackupStatus, DateTimeOffset? lastBackupOn, BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, VmWorkloadProtectedItemExtendedInfo extendedInfo, IDictionary<string, KpiResourceHealthDetails> kpisHealths, IEnumerable<DistributedNodesInfo> nodesList)
            => VmWorkloadSapHanaDBInstanceProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, serverName, parentName, parentType, protectionStatus, protectionState, lastBackupStatus, lastBackupOn, lastBackupErrorDetail, protectedItemDataSourceId, protectedItemHealthStatus, extendedInfo, kpisHealths, nodesList);

        /// <summary> Initializes a new instance of <see cref="Models.VmWorkloadSqlDatabaseProtectedItem"/>. </summary>
        /// <param name="backupManagementType"> Type of backup management for the backed up item. </param>
        /// <param name="workloadType"> Type of workload this item represents. </param>
        /// <param name="containerName"> Unique name of container. </param>
        /// <param name="sourceResourceId"> ARM ID of the resource to be backed up. </param>
        /// <param name="policyId"> ID of the backup policy with which this item is backed up. </param>
        /// <param name="lastRecoverOn"> Timestamp when the last (latest) backup copy was created for this backup item. </param>
        /// <param name="backupSetName"> Name of the backup set the backup item belongs to. </param>
        /// <param name="createMode"> Create mode to indicate recovery of existing soft deleted data source or creation of new data source. </param>
        /// <param name="deferredDeletedOn"> Time for deferred deletion in UTC. </param>
        /// <param name="isScheduledForDeferredDelete"> Flag to identify whether the DS is scheduled for deferred delete. </param>
        /// <param name="deferredDeleteTimeRemaining"> Time remaining before the DS marked for deferred delete is permanently deleted. </param>
        /// <param name="isDeferredDeleteScheduleUpcoming"> Flag to identify whether the deferred deleted DS is to be purged soon. </param>
        /// <param name="isRehydrate"> Flag to identify that deferred deleted DS is to be moved into Pause state. </param>
        /// <param name="resourceGuardOperationRequests"> ResourceGuardOperationRequests on which LAC check will be performed. </param>
        /// <param name="isArchiveEnabled"> Flag to identify whether datasource is protected in archive. </param>
        /// <param name="policyName"> Name of the policy used for protection. </param>
        /// <param name="softDeleteRetentionPeriodInDays"> Soft delete retention period in days. </param>
        /// <param name="friendlyName"> Friendly name of the DB represented by this backup item. </param>
        /// <param name="serverName"> Host/Cluster Name for instance or AG. </param>
        /// <param name="parentName"> Parent name of the DB such as Instance or Availability Group. </param>
        /// <param name="parentType"> Parent type of protected item, example: for a DB, standalone server or distributed. </param>
        /// <param name="protectionStatus"> Backup status of this backup item. </param>
        /// <param name="protectionState"> Backup state of this backup item. </param>
        /// <param name="lastBackupStatus"> Last backup operation status. Possible values: Healthy, Unhealthy. </param>
        /// <param name="lastBackupOn"> Timestamp of the last backup operation on this backup item. </param>
        /// <param name="lastBackupErrorDetail"> Error details in last backup. </param>
        /// <param name="protectedItemDataSourceId"> Data ID of the protected item. </param>
        /// <param name="protectedItemHealthStatus"> Health status of the backup item, evaluated based on last heartbeat received. </param>
        /// <param name="extendedInfo"> Additional information for this backup item. </param>
        /// <param name="kpisHealths"> Health details of different KPIs. </param>
        /// <param name="nodesList"> List of the nodes in case of distributed container. </param>
        /// <returns> A new <see cref="Models.VmWorkloadSqlDatabaseProtectedItem"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VmWorkloadSqlDatabaseProtectedItem VmWorkloadSqlDatabaseProtectedItem(BackupManagementType? backupManagementType, BackupDataSourceType? workloadType, string containerName, ResourceIdentifier sourceResourceId, ResourceIdentifier policyId, DateTimeOffset? lastRecoverOn, string backupSetName, BackupCreateMode? createMode, DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, BackupProtectionState? protectionState, LastBackupStatus? lastBackupStatus, DateTimeOffset? lastBackupOn, BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, VmWorkloadProtectedItemExtendedInfo extendedInfo, IDictionary<string, KpiResourceHealthDetails> kpisHealths, IEnumerable<DistributedNodesInfo> nodesList)
            => VmWorkloadSqlDatabaseProtectedItem(backupManagementType, workloadType, containerName, sourceResourceId, policyId, lastRecoverOn, backupSetName, createMode, deferredDeletedOn, isScheduledForDeferredDelete, deferredDeleteTimeRemaining, isDeferredDeleteScheduleUpcoming, isRehydrate, resourceGuardOperationRequests, isArchiveEnabled, policyName, softDeleteRetentionPeriodInDays, null, friendlyName, serverName, parentName, parentType, protectionStatus, protectionState, lastBackupStatus, lastBackupOn, lastBackupErrorDetail, protectedItemDataSourceId, protectedItemHealthStatus, extendedInfo, kpisHealths, nodesList);
    }
}