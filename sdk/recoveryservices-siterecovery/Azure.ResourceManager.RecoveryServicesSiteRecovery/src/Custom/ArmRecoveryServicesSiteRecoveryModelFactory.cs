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

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmRecoveryServicesSiteRecoveryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.SiteRecoveryInnerHealthError"/>. </summary>
        /// <param name="errorSource"> Source of error. </param>
        /// <param name="errorType"> Type of error. </param>
        /// <param name="errorLevel"> Level of error. </param>
        /// <param name="errorCategory"> Category of error. </param>
        /// <param name="errorCode"> Error code. </param>
        /// <param name="summaryMessage"> Summary message of the entity. </param>
        /// <param name="errorMessage"> Error message. </param>
        /// <param name="possibleCauses"> Possible causes of error. </param>
        /// <param name="recommendedAction"> Recommended action to resolve error. </param>
        /// <param name="createdOn"> Error creation time (UTC). </param>
        /// <param name="recoveryProviderErrorMessage"> DRA error message. </param>
        /// <param name="entityId"> ID of the entity. </param>
        /// <param name="errorId"> The health error unique id. </param>
        /// <param name="customerResolvability"> Value indicating whether the health error is customer resolvable. </param>
        /// <returns> A new <see cref="Models.SiteRecoveryInnerHealthError"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteRecoveryInnerHealthError SiteRecoveryInnerHealthError(string errorSource, string errorType, string errorLevel, string errorCategory, string errorCode, string summaryMessage, string errorMessage, string possibleCauses, string recommendedAction, DateTimeOffset? createdOn, string recoveryProviderErrorMessage, string entityId, string errorId, HealthErrorCustomerResolvability? customerResolvability)
        {
            return new SiteRecoveryInnerHealthError(
                errorSource,
                errorType,
                errorLevel,
                errorCategory,
                errorCode,
                summaryMessage,
                errorMessage,
                possibleCauses,
                recommendedAction,
                createdOn,
                recoveryProviderErrorMessage,
                entityId,
                errorId,
                customerResolvability,
                null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.A2AProtectedManagedDiskDetails"/>. </summary>
        /// <param name="diskId"> The managed disk Arm id. </param>
        /// <param name="recoveryResourceGroupId"> The recovery disk resource group Arm Id. </param>
        /// <param name="recoveryTargetDiskId"> Recovery target disk Arm Id. </param>
        /// <param name="recoveryReplicaDiskId"> Recovery replica disk Arm Id. </param>
        /// <param name="recoveryOrignalTargetDiskId"> Recovery original target disk Arm Id. </param>
        /// <param name="recoveryReplicaDiskAccountType"> The replica disk type. Its an optional value and will be same as source disk type if not user provided. </param>
        /// <param name="recoveryTargetDiskAccountType"> The target disk type after failover. Its an optional value and will be same as source disk type if not user provided. </param>
        /// <param name="recoveryDiskEncryptionSetId"> The recovery disk encryption set Id. </param>
        /// <param name="primaryDiskEncryptionSetId"> The primary disk encryption set Id. </param>
        /// <param name="diskName"> The disk name. </param>
        /// <param name="diskCapacityInBytes"> The disk capacity in bytes. </param>
        /// <param name="primaryStagingAzureStorageAccountId"> The primary staging storage account. </param>
        /// <param name="diskType"> The type of disk. </param>
        /// <param name="isResyncRequired"> A value indicating whether resync is required for this disk. </param>
        /// <param name="monitoringPercentageCompletion"> The percentage of the monitoring job. The type of the monitoring job is defined by MonitoringJobType property. </param>
        /// <param name="monitoringJobType"> The type of the monitoring job. The progress is contained in MonitoringPercentageCompletion property. </param>
        /// <param name="dataPendingInStagingStorageAccountInMB"> The data pending for replication in MB at staging account. </param>
        /// <param name="dataPendingAtSourceAgentInMB"> The data pending at source virtual machine in MB. </param>
        /// <param name="diskState"> The disk state. </param>
        /// <param name="allowedDiskLevelOperation"> The disk level operations list. </param>
        /// <param name="isDiskEncrypted"> A value indicating whether vm has encrypted os disk or not. </param>
        /// <param name="secretIdentifier"> The secret URL / identifier (BEK). </param>
        /// <param name="dekKeyVaultArmId"> The KeyVault resource id for secret (BEK). </param>
        /// <param name="isDiskKeyEncrypted"> A value indicating whether disk key got encrypted or not. </param>
        /// <param name="keyIdentifier"> The key URL / identifier (KEK). </param>
        /// <param name="kekKeyVaultArmId"> The KeyVault resource id for key (KEK). </param>
        /// <param name="failoverDiskName"> The failover name for the managed disk. </param>
        /// <param name="tfoDiskName"> The test failover name for the managed disk. </param>
        /// <returns> A new <see cref="Models.A2AProtectedManagedDiskDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static A2AProtectedManagedDiskDetails A2AProtectedManagedDiskDetails(String diskId, ResourceIdentifier recoveryResourceGroupId, ResourceIdentifier recoveryTargetDiskId, ResourceIdentifier recoveryReplicaDiskId, ResourceIdentifier recoveryOrignalTargetDiskId, string recoveryReplicaDiskAccountType, string recoveryTargetDiskAccountType, ResourceIdentifier recoveryDiskEncryptionSetId, ResourceIdentifier primaryDiskEncryptionSetId, string diskName, long? diskCapacityInBytes, ResourceIdentifier primaryStagingAzureStorageAccountId, string diskType, bool? isResyncRequired, int? monitoringPercentageCompletion, string monitoringJobType, double? dataPendingInStagingStorageAccountInMB, double? dataPendingAtSourceAgentInMB, string diskState, IEnumerable<string> allowedDiskLevelOperation, bool? isDiskEncrypted, string secretIdentifier, ResourceIdentifier dekKeyVaultArmId, bool? isDiskKeyEncrypted, string keyIdentifier, ResourceIdentifier kekKeyVaultArmId, string failoverDiskName, string tfoDiskName)
        {
            allowedDiskLevelOperation ??= new List<string>();

            return new A2AProtectedManagedDiskDetails(
                diskId,
                recoveryResourceGroupId,
                recoveryTargetDiskId,
                recoveryReplicaDiskId,
                recoveryOrignalTargetDiskId,
                recoveryReplicaDiskAccountType,
                recoveryTargetDiskAccountType,
                recoveryDiskEncryptionSetId,
                primaryDiskEncryptionSetId,
                diskName,
                diskCapacityInBytes,
                primaryStagingAzureStorageAccountId,
                diskType,
                isResyncRequired,
                monitoringPercentageCompletion,
                monitoringJobType,
                dataPendingInStagingStorageAccountInMB,
                dataPendingAtSourceAgentInMB,
                diskState,
                allowedDiskLevelOperation?.ToList(),
                isDiskEncrypted,
                secretIdentifier,
                dekKeyVaultArmId,
                isDiskKeyEncrypted,
                keyIdentifier,
                kekKeyVaultArmId,
                failoverDiskName,
                tfoDiskName,
                null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.A2AUnprotectedDiskDetails"/>. </summary>
        /// <param name="diskLunId"> The source lun Id for the data disk. </param>
        /// <param name="diskAutoProtectionStatus"> A value indicating whether the disk auto protection is enabled. </param>
        /// <returns> A new <see cref="Models.A2AUnprotectedDiskDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static A2AUnprotectedDiskDetails A2AUnprotectedDiskDetails(int? diskLunId, AutoProtectionOfDataDisk? diskAutoProtectionStatus)
        {
            return new A2AUnprotectedDiskDetails(diskLunId, diskAutoProtectionStatus, null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.CurrentScenarioDetails"/>. </summary>
        /// <param name="scenarioName"> Scenario name. </param>
        /// <param name="jobId"> ARM Id of the job being executed. </param>
        /// <param name="startOn"> Start time of the workflow. </param>
        /// <returns> A new <see cref="Models.CurrentScenarioDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CurrentScenarioDetails CurrentScenarioDetails(string scenarioName, ResourceIdentifier jobId, DateTimeOffset? startOn)
        {
            return new CurrentScenarioDetails(scenarioName, jobId, startOn, null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SiteRecoveryHealthError"/>. </summary>
        /// <param name="innerHealthErrors"> The inner health errors. HealthError having a list of HealthError as child errors is problematic. InnerHealthError is used because this will prevent an infinite loop of structures when Hydra tries to auto-generate the contract. We are exposing the related health errors as inner health errors and all API consumers can utilize this in the same fashion as Exception -&gt; InnerException. </param>
        /// <param name="errorSource"> Source of error. </param>
        /// <param name="errorType"> Type of error. </param>
        /// <param name="errorLevel"> Level of error. </param>
        /// <param name="errorCategory"> Category of error. </param>
        /// <param name="errorCode"> Error code. </param>
        /// <param name="summaryMessage"> Summary message of the entity. </param>
        /// <param name="errorMessage"> Error message. </param>
        /// <param name="possibleCauses"> Possible causes of error. </param>
        /// <param name="recommendedAction"> Recommended action to resolve error. </param>
        /// <param name="creationTimeUtc"> Error creation time (UTC). </param>
        /// <param name="recoveryProviderErrorMessage"> DRA error message. </param>
        /// <param name="entityId"> ID of the entity. </param>
        /// <param name="errorId"> The health error unique id. </param>
        /// <param name="customerResolvability"> Value indicating whether the health error is customer resolvable. </param>
        /// <returns> A new <see cref="Models.SiteRecoveryHealthError"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteRecoveryHealthError SiteRecoveryHealthError(IEnumerable<SiteRecoveryInnerHealthError> innerHealthErrors, string errorSource, string errorType, string errorLevel, string errorCategory, string errorCode, string summaryMessage, string errorMessage, string possibleCauses, string recommendedAction, DateTimeOffset? creationTimeUtc, string recoveryProviderErrorMessage, string entityId, string errorId, HealthErrorCustomerResolvability? customerResolvability)
        {
            innerHealthErrors ??= new List<SiteRecoveryInnerHealthError>();

            return new SiteRecoveryHealthError(
                innerHealthErrors?.ToList(),
                errorSource,
                errorType,
                errorLevel,
                errorCategory,
                errorCode,
                summaryMessage,
                errorMessage,
                possibleCauses,
                recommendedAction,
                creationTimeUtc,
                recoveryProviderErrorMessage,
                entityId,
                errorId,
                customerResolvability,
                null);
        }
    }
}
