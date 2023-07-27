// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("BatchResult")]
    public partial class BatchResult
    {
        [CodeGenMember("BatchSummary")]
        internal BatchResultSummary BatchSummary { get; }

        /// <summary> Number of successful requests in the batch. </summary>
        public int? SuccessfulRequests => BatchSummary.SuccessfulRequests;
        /// <summary> Total number of requests in the batch. </summary>
        public int? TotalRequests => BatchSummary.TotalRequests;
    }
}
