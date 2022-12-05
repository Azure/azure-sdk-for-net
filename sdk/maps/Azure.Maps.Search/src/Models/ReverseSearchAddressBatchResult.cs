// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> This object is returned from a successful Search Address Reverse Batch service call. </summary>
    public partial class ReverseSearchAddressBatchResult : BatchResult
    {
        /// <summary> Initializes a new instance of ReverseSearchAddressBatchResult. </summary>
        /// <param name="batchSummary"> Summary of the results for the batch request. </param>
        /// <param name="batchItems"> Array containing the batch results. </param>
        internal ReverseSearchAddressBatchResult(BatchResultSummary batchSummary, IReadOnlyList<ReverseSearchAddressBatchItem> batchItems) : base(batchSummary)
        {
            BatchItems = batchItems;
            var results = new List<ReverseSearchAddressBatchItemResponse>();
            foreach (var item in BatchItems)
            {
                results.Add(item.Response);
            }
            Results = results.AsReadOnly();
        }

        /// <summary> Array containing the batch results. </summary>
        [CodeGenMember("BatchItems")]
        internal IReadOnlyList<ReverseSearchAddressBatchItem> BatchItems { get; }

        /// <summary> Batch result of the query. The BatchItems in the response field. </summary>
        public IReadOnlyList<ReverseSearchAddressBatchItemResponse> Results { get; }
    }
}