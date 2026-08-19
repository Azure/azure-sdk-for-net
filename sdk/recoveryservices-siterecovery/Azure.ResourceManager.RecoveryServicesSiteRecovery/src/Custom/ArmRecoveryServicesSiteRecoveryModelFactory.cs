// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// NOTE: The following customization is intentionally retained for backward compatibility.
// The v1.x AutoRest-generated SDK exposed a model-factory method for
// SiteRecoveryClusterRecoveryPointData. The new TypeSpec specification no longer models
// the cluster recovery point sub-resource as an ARM resource (it does not appear in the
// ARM templates index), so the MPG emitter does not generate a ResourceData type for it and
// therefore no factory method. Removing the factory method would be a binary-breaking
// change for consumers, so we keep the signature here, mark it obsolete, and have it throw
// NotSupportedException.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.RecoveryServicesSiteRecovery;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    // TODO: Remove these four suppressions and their corresponding factory methods when https://github.com/microsoft/typespec/issues/11667 is fixed.
    [CodeGenSuppress("CurrentScenarioDetails", typeof(string), typeof(ResourceIdentifier), typeof(DateTimeOffset?))]
    [CodeGenSuppress("A2AUnprotectedDiskDetails", typeof(int?), typeof(AutoProtectionOfDataDisk?))]
    [CodeGenSuppress("SiteRecoveryHealthError", typeof(IEnumerable<SiteRecoveryInnerHealthError>), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(string), typeof(string), typeof(string), typeof(HealthErrorCustomerResolvability?))]
    [CodeGenSuppress("SiteRecoveryInnerHealthError", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(string), typeof(string), typeof(string), typeof(HealthErrorCustomerResolvability?))]
    public static partial class ArmRecoveryServicesSiteRecoveryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="RecoveryServicesSiteRecovery.SiteRecoveryClusterRecoveryPointData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and will be removed in a future version. The cluster recovery point sub-resource is no longer modeled as an ARM resource.")]
        public static SiteRecoveryClusterRecoveryPointData SiteRecoveryClusterRecoveryPointData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string clusterRecoveryPointType = default, SiteRecoveryClusterRecoveryPointProperties properties = default)
            => throw new NotSupportedException("This API is deprecated and no longer supported.");

        /// <summary> Initializes a new instance of <see cref="Models.CurrentScenarioDetails"/>. </summary>
        public static CurrentScenarioDetails CurrentScenarioDetails(string scenarioName, ResourceIdentifier jobId, DateTimeOffset? startOn)
            => new CurrentScenarioDetails(scenarioName, jobId, startOn, default);

        /// <summary> Initializes a new instance of <see cref="Models.A2AUnprotectedDiskDetails"/>. </summary>
        public static A2AUnprotectedDiskDetails A2AUnprotectedDiskDetails(int? diskLunId, AutoProtectionOfDataDisk? diskAutoProtectionStatus)
            => new A2AUnprotectedDiskDetails(diskLunId, diskAutoProtectionStatus, default);

        /// <summary> Initializes a new instance of <see cref="Models.SiteRecoveryHealthError"/>. </summary>
        public static SiteRecoveryHealthError SiteRecoveryHealthError(
            IEnumerable<SiteRecoveryInnerHealthError> innerHealthErrors,
            string errorSource,
            string errorType,
            string errorLevel,
            string errorCategory,
            string errorCode,
            string summaryMessage,
            string errorMessage,
            string possibleCauses,
            string recommendedAction,
            DateTimeOffset? creationTimeUtc,
            string recoveryProviderErrorMessage,
            string entityId,
            string errorId,
            HealthErrorCustomerResolvability? customerResolvability)
            => new SiteRecoveryHealthError(
                (innerHealthErrors ?? new ChangeTrackingList<SiteRecoveryInnerHealthError>()).ToList(),
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
                default);

        /// <summary> Initializes a new instance of <see cref="Models.SiteRecoveryInnerHealthError"/>. </summary>
        public static SiteRecoveryInnerHealthError SiteRecoveryInnerHealthError(
            string errorSource,
            string errorType,
            string errorLevel,
            string errorCategory,
            string errorCode,
            string summaryMessage,
            string errorMessage,
            string possibleCauses,
            string recommendedAction,
            DateTimeOffset? createdOn,
            string recoveryProviderErrorMessage,
            string entityId,
            string errorId,
            HealthErrorCustomerResolvability? customerResolvability)
            => new SiteRecoveryInnerHealthError(
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
                default);
    }
}
