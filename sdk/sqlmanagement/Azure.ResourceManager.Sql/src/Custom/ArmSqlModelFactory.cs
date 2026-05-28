// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql.Models
{
    public static partial class ArmSqlModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Sql.RecommendedActionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kind"> Resource kind. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="recommendationReason"> Gets the reason for recommending this action. e.g., DuplicateIndex. </param>
        /// <param name="validSince"> Gets the time since when this recommended action is valid. </param>
        /// <param name="lastRefresh"> Gets time when this recommended action was last refreshed. </param>
        /// <param name="state"> Gets the info of the current state the recommended action is in. </param>
        /// <param name="isExecutableAction"> Gets if this recommended action is actionable by user. </param>
        /// <param name="isRevertableAction"> Gets if changes applied by this recommended action can be reverted by user. </param>
        /// <param name="isArchivedAction"> Gets if this recommended action was suggested some time ago but user chose to ignore this and system added a new recommended action again. </param>
        /// <param name="executeActionStartOn"> Gets the time when system started applying this recommended action on the user resource. e.g., index creation start time. </param>
        /// <param name="executeActionDuration"> Gets the time taken for applying this recommended action on user resource. e.g., time taken for index creation. </param>
        /// <param name="revertActionStartOn"> Gets the time when system started reverting changes of this recommended action on user resource. e.g., time when index drop is executed. </param>
        /// <param name="revertActionDuration"> Gets the time taken for reverting changes of this recommended action on user resource. e.g., time taken for dropping the created index. </param>
        /// <param name="executeActionInitiatedBy"> Gets if approval for applying this recommended action was given by user/system. </param>
        /// <param name="executeActionInitiatedOn"> Gets the time when this recommended action was approved for execution. </param>
        /// <param name="revertActionInitiatedBy"> Gets if approval for reverting this recommended action was given by user/system. </param>
        /// <param name="revertActionInitiatedOn"> Gets the time when this recommended action was approved for revert. </param>
        /// <param name="score"> Gets the impact of this recommended action. Possible values are 1 - Low impact, 2 - Medium Impact and 3 - High Impact. </param>
        /// <param name="implementationDetails"> Gets the implementation details of this recommended action for user to apply it manually. </param>
        /// <param name="errorDetails"> Gets the error details if and why this recommended action is put to error state. </param>
        /// <param name="estimatedImpact"> Gets the estimated impact info for this recommended action e.g., Estimated CPU gain, Estimated Disk Space change. </param>
        /// <param name="observedImpact"> Gets the observed/actual impact info for this recommended action e.g., Actual CPU gain, Actual Disk Space change. </param>
        /// <param name="timeSeries"> Gets the time series info of metrics for this recommended action e.g., CPU consumption time series. </param>
        /// <param name="linkedObjects"> Gets the linked objects, if any. </param>
        /// <param name="additionalDetails"> Gets additional details specific to this recommended action. </param>
        /// <returns> A new <see cref="Sql.RecommendedActionData"/> instance for mocking. </returns>
        public static RecommendedActionData RecommendedActionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string kind = null, AzureLocation? location = null, string recommendationReason = null, DateTimeOffset? validSince = null, DateTimeOffset? lastRefresh = null, RecommendedActionStateInfo state = null, bool? isExecutableAction = null, bool? isRevertableAction = null, bool? isArchivedAction = null, DateTimeOffset? executeActionStartOn = null, TimeSpan? executeActionDuration = null, DateTimeOffset? revertActionStartOn = null, TimeSpan? revertActionDuration = null, RecommendedActionInitiatedBy? executeActionInitiatedBy = null, DateTimeOffset? executeActionInitiatedOn = null, RecommendedActionInitiatedBy? revertActionInitiatedBy = null, DateTimeOffset? revertActionInitiatedOn = null, int? score = null, RecommendedActionImplementationInfo implementationDetails = null, RecommendedActionErrorInfo errorDetails = null, IEnumerable<RecommendedActionImpactRecord> estimatedImpact = null, IEnumerable<RecommendedActionImpactRecord> observedImpact = null, IEnumerable<RecommendedActionMetricInfo> timeSeries = null, IEnumerable<string> linkedObjects = null, IReadOnlyDictionary<string, string> additionalDetails = null)
        {
            estimatedImpact ??= new List<RecommendedActionImpactRecord>();
            observedImpact ??= new List<RecommendedActionImpactRecord>();
            timeSeries ??= new List<RecommendedActionMetricInfo>();
            linkedObjects ??= new List<string>();
            additionalDetails ??= new Dictionary<string, string>();

            return new RecommendedActionData(
                id,
                name,
                resourceType,
                systemData,
                kind,
                location,
                recommendationReason,
                validSince,
                lastRefresh,
                state,
                isExecutableAction,
                isRevertableAction,
                isArchivedAction,
                executeActionStartOn,
                executeActionDuration,
                revertActionStartOn,
                revertActionDuration,
                executeActionInitiatedBy,
                executeActionInitiatedOn,
                revertActionInitiatedBy,
                revertActionInitiatedOn,
                score,
                implementationDetails,
                errorDetails,
                estimatedImpact?.ToList(),
                observedImpact?.ToList(),
                timeSeries?.ToList(),
                linkedObjects?.ToList(),
                additionalDetails,
                serializedAdditionalRawData: null);
        }
    }
}
