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
        /// <param name="results"> Batch result of the query. </param>
        /// <returns> A new <see cref="RouteDirectionsBatchResult"/> instance for mocking. </returns>
        public static RouteDirectionsBatchResult RouteDirectionsBatchResult(IEnumerable<RouteDirectionsBatchItemResponse> results = null)
        {
            return new RouteDirectionsBatchResult(results?.ToList());
        }
    }
}
