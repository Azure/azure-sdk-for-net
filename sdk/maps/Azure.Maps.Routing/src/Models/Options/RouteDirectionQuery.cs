// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Routing
{
    /// <summary> Options for rendering static images. </summary>
    public class RouteDirectionQuery
    {
        /// <summary> Constructor of RouteDirectionOptions. </summary>
        protected RouteDirectionQuery()
        {
        }

        /// <summary> Constructor of RouteDirectionOptions. </summary>
        /// <param name="routePoints"> A list of routing points for route direction. </param>
        /// <param name="options"> Route direction options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="routePoints"/> is null. </exception>
        public RouteDirectionQuery(IList<GeoPosition> routePoints, RouteDirectionOptions options = null)
        {
            Argument.AssertNotNull(routePoints, nameof(routePoints));

            RoutePoints = routePoints;
            if (options != null)
            {
                RouteDirectionOptions = options;
            }
        }

        /// <summary> A list of geo points for the route. A minimum of two coordinates is required. The first one is the origin and the last is the destination of the route. </summary>
        public IList<GeoPosition> RoutePoints { get; }

        /// <summary> The route direction options. </summary>
        public RouteDirectionOptions RouteDirectionOptions { get; set; }
    }
}
