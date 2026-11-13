// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.Maps.Routing.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class MapsRoutingModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="RouteDirectionsBatchResult"/> for mocking. </summary>
        /// <param name="successfulRequests"> Number of successful requests in the batch. </param>
        /// <param name="totalRequests"> Total number of requests in the batch. </param>
        /// <param name="results"> Batch result of the query. </param>
        /// <returns> A new <see cref="RouteDirectionsBatchResult"/> instance for mocking. </returns>
        public static RouteDirectionsBatchResult RouteDirectionsBatchResult(int? successfulRequests = null, int? totalRequests = null, IEnumerable<RouteDirectionsBatchItemResponse> results = null)
        {
            results ??= new List<RouteDirectionsBatchItemResponse>();
            return new RouteDirectionsBatchResult(new BatchResultSummary(successfulRequests, totalRequests), results.ToList());
        }
    }
}
