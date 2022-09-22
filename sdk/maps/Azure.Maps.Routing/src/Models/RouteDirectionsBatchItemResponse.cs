// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> The result of the query. RouteDirections if the query completed successfully, ErrorResponse otherwise. </summary>
    public partial class RouteDirectionsBatchItemResponse : RouteDirections
    {
        /// <summary> Initializes a new instance of RouteDirectionsBatchItemResponse. </summary>
        /// <param name="formatVersion"> Format Version property. </param>
        /// <param name="routes"> Routes array. </param>
        /// <param name="optimizedWaypoints">
        /// Optimized sequence of waypoints. It shows the index from the user provided waypoint sequence for the original and optimized list. For instance, a response:
        ///
        /// ```
        /// &lt;optimizedWaypoints&gt;
        /// &lt;waypoint providedIndex=&quot;0&quot; optimizedIndex=&quot;1&quot;/&gt;
        /// &lt;waypoint providedIndex=&quot;1&quot; optimizedIndex=&quot;2&quot;/&gt;
        /// &lt;waypoint providedIndex=&quot;2&quot; optimizedIndex=&quot;0&quot;/&gt;
        /// &lt;/optimizedWaypoints&gt;
        /// ```
        ///
        /// means that the original sequence is [0, 1, 2] and optimized sequence is [1, 2, 0]. Since the index starts by 0 the original is &quot;first, second, third&quot; while the optimized is &quot;second, third, first&quot;.
        /// </param>
        /// <param name="report"> Reports the effective settings used in the current call. </param>
        /// <param name="error"> The error object. </param>
        internal RouteDirectionsBatchItemResponse(string formatVersion, IReadOnlyList<RouteData> routes, IReadOnlyList<RouteOptimizedWaypoint> optimizedWaypoints, RouteReport report, ErrorDetail error) : base(formatVersion, routes, optimizedWaypoints, report)
        {
            ErrorDetail = error;
            ResponseError = new ResponseError(error?.Code, error?.Message);
        }

        /// <summary> The error object. </summary>
        [CodeGenMember("Error")]
        internal ErrorDetail ErrorDetail { get; }

        /// <summary> The response error. </summary>
        public ResponseError ResponseError { get; }
    }
}
