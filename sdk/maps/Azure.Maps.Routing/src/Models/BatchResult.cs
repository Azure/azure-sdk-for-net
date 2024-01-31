// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> This object is returned from a successful Batch service call. Extend with <c>batchItems</c> property. </summary>
    public partial class BatchResult
    {
        /// <summary> Summary of the results for the batch request. </summary>
        [CodeGenMember("BatchSummary")]
        internal BatchResultSummary BatchSummary { get; }

        /// <summary> Number of successful requests in the batch. </summary>
        public int? SuccessfulRequests => BatchSummary.SuccessfulRequests;

        /// <summary> Total number of requests in the batch. </summary>
        public int? TotalRequests => BatchSummary.TotalRequests;
    }
}
