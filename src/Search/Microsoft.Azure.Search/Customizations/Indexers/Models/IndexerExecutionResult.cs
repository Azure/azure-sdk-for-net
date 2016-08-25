// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the result of an individual indexer execution.
    /// </summary>
    public class IndexerExecutionResult
    {
        /// <summary>
        /// Initializes a new instance of the IndexerExecutionResult class.
        /// </summary>
        public IndexerExecutionResult() { }

        /// <summary>
        /// Initializes a new instance of the IndexerExecutionResult class.
        /// </summary>
        public IndexerExecutionResult(IndexerExecutionStatus status = default(IndexerExecutionStatus), string errorMessage = default(string), DateTimeOffset? startTime = default(DateTimeOffset?), DateTimeOffset? endTime = default(DateTimeOffset?), IList<ItemError> errors = default(IList<ItemError>), int itemCount = default(int), int failedItemCount = default(int), string initialTrackingState = default(string), string finalTrackingState = default(string))
        {
            Status = status;
            ErrorMessage = errorMessage;
            StartTime = startTime;
            EndTime = endTime;
            Errors = errors;
            ItemCount = itemCount;
            FailedItemCount = failedItemCount;
            InitialTrackingState = initialTrackingState;
            FinalTrackingState = finalTrackingState;
        }

        /// <summary>
        /// Gets the outcome of this indexer execution. Possible values for
        /// this property include: 'transientFailure', 'success',
        /// 'inProgress', 'reset'.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public IndexerExecutionStatus Status { get; private set; }  // TODO: Note in the Swagger spec that it's non-nullable

        /// <summary>
        /// Gets the error message indicating the top-level error, if any.
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Gets the start time of this indexer execution.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public DateTimeOffset? StartTime { get; private set; }

        /// <summary>
        /// Gets the end time of this indexer execution, if the execution has
        /// already completed.
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public DateTimeOffset? EndTime { get; private set; }

        /// <summary>
        /// Gets the item-level indexing errors
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public IList<ItemError> Errors { get; private set; }

        /// <summary>
        /// Gets the number of items that were processed during this indexer
        /// execution. This includes both successfully processed items and
        /// items where indexing was attempted but failed.
        /// </summary>
        [JsonProperty(PropertyName = "itemsProcessed")]
        public int ItemCount { get; private set; }  // TODO: Note in the Swagger spec that it's non-nullable

        /// <summary>
        /// Gets the number of items that failed to be indexed during this
        /// indexer execution.
        /// </summary>
        [JsonProperty(PropertyName = "itemsFailed")]
        public int FailedItemCount { get; private set; }  // TODO: Note in the Swagger spec that it's non-nullable

        /// <summary>
        /// Change tracking state with which an indexer execution started.
        /// </summary>
        [JsonProperty(PropertyName = "initialTrackingState")]
        public string InitialTrackingState { get; private set; }

        /// <summary>
        /// Change tracking state with which an indexer execution finished.
        /// </summary>
        [JsonProperty(PropertyName = "finalTrackingState")]
        public string FinalTrackingState { get; private set; }
    }
}
