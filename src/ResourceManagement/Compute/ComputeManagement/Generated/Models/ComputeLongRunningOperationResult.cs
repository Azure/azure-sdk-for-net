namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The Compute service response for long-running operations.
    /// </summary>
    public partial class ComputeLongRunningOperationResult
    {
        /// <summary>
        /// Gets the operation identifier.
        /// </summary>
        [JsonProperty(PropertyName = "operationId")]
        public string OperationId { get; set; }

        /// <summary>
        /// Gets the operation status. Possible values for this property
        /// include: 'InProgress', 'Failed', 'Succeeded', 'Preempted'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public ComputeOperationStatus? Status { get; set; }

        /// <summary>
        /// Gets the operation start time
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets the operation end time
        /// </summary>
        [JsonProperty(PropertyName = "endTime")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public ComputeLongRunningOperationProperties Properties { get; set; }

        /// <summary>
        /// Gets the operation error, if any occurred.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public ApiError Error { get; set; }

    }
}
