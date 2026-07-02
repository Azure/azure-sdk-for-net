// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ComputeSchedule;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ComputeSchedule.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmComputeScheduleModelFactory
    {
        /// <summary> The details of a response from an operation on a resource. </summary>
        /// <param name="operationId"> Operation identifier for the unique operation. </param>
        /// <param name="resourceId"> Unique identifier for the resource involved in the operation, eg ArmId. </param>
        /// <param name="opType"> Type of operation performed on the resources. </param>
        /// <param name="subscriptionId"> Subscription id attached to the request. </param>
        /// <param name="deadline"> Deadline for the operation. </param>
        /// <param name="deadlineType"> Type of deadline of the operation. </param>
        /// <param name="state"> Current state of the operation. </param>
        /// <param name="timezone"> Timezone for the operation. </param>
        /// <param name="operationTimezone"> Timezone for the operation. </param>
        /// <param name="resourceOperationError"> Operation level errors if they exist. </param>
        /// <param name="completedOn"> Time the operation was complete if errors are null. </param>
        /// <param name="retryPolicy"> Retry policy the user can pass. </param>
        /// <returns> A new <see cref="Models.ResourceOperationDetails"/> instance for mocking. </returns>
        public static ResourceOperationDetails ResourceOperationDetails(string operationId, ResourceIdentifier resourceId, ResourceOperationType? opType, string subscriptionId, DateTimeOffset? deadline, ScheduledActionDeadlineType? deadlineType, ScheduledActionOperationState? state, string timezone, string operationTimezone, ResourceOperationError resourceOperationError, DateTimeOffset? completedOn, UserRequestRetryPolicy retryPolicy = default)
        {
            return ResourceOperationDetails(
                operationId, resourceId, opType, subscriptionId, deadline, deadlineType, state, timezone, operationTimezone, resourceOperationError, null, completedOn, retryPolicy);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ResourceProvisionFlexPayload"/>. </summary>
        /// <param name="baseProfile"> JSON object that contains VM properties that are common across all VMs in this batch. </param>
        /// <param name="resourceOverrides"> JSON array that contains VM properties that should be overridden for each VM in the batch. </param>
        /// <param name="resourceCount"> Number of VMs to be created. </param>
        /// <param name="resourcePrefix"> If resourceOverrides doesn't contain name, service will create name based on prefix and resourceCount. </param>
        /// <param name="flexProperties"> The flex properties for flexible VM creation. </param>
        /// <returns> A new <see cref="Models.ResourceProvisionFlexPayload"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceProvisionFlexPayload ResourceProvisionFlexPayload(IDictionary<string, BinaryData> baseProfile, IEnumerable<IDictionary<string, BinaryData>> resourceOverrides, int resourceCount, string resourcePrefix, ComputeScheduleFlexProperties flexProperties)
        {
            baseProfile ??= new ChangeTrackingDictionary<string, BinaryData>();
            resourceOverrides ??= new ChangeTrackingList<IDictionary<string, BinaryData>>();

            return new ResourceProvisionFlexPayload(default, default, resourceCount, resourcePrefix, flexProperties, additionalBinaryDataProperties: null);
        }
    }
}
