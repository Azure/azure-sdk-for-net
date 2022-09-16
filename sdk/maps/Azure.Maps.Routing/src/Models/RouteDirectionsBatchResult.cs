// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> This object is returned from a successful Route Directions Batch service call. </summary>
    public partial class RouteDirectionsBatchResult : BatchResult
    {
        /// <summary> Initializes a new instance of RouteDirectionsBatchResult. </summary>
        /// <param name="batchSummary"> Summary of the results for the batch request. </param>
        /// <param name="batchItems"> Array containing the batch results. </param>
        internal RouteDirectionsBatchResult(BatchResultSummary batchSummary, IReadOnlyList<RouteDirectionsBatchItem> batchItems) : base(batchSummary)
        {
            BatchItems = batchItems;
            var results = new List<RouteDirectionsBatchItemResponse>();
            foreach (var item in BatchItems)
            {
                results.Add(item.Response);
            }
            Results = results.AsReadOnly();
        }

        /// <summary> Array containing the batch results. </summary>
        [CodeGenMember("BatchItems")]

        internal IReadOnlyList<RouteDirectionsBatchItem> BatchItems { get; }

        /// <summary> Batch result of the query. The BatchItems in the response field. </summary>
        public IReadOnlyList<RouteDirectionsBatchItemResponse> Results { get; }
    }
}
