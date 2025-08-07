// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Weather.Models
{
    /// <summary> Displayed when details=true or radiiGeometry=true in the request. </summary>
    public partial class StormWindRadiiSummary
    {
        /// <summary> Initializes a new instance of <see cref="StormWindRadiiSummary"/>. </summary>
        /// <param name="timestamp"> DateTime for which the wind radii summary data is valid, displayed in ISO8601 format. </param>
        /// <param name="windSpeed"> Wind speed associated with the radiusSectorData. </param>
        /// <param name="radiusSectorData"> Contains the information needed to plot wind radius quadrants. Bearing 0–90 = NE quadrant; 90–180 = SE quadrant; 180–270 = SW quadrant; 270–360 = NW quadrant. </param>
        /// <param name="radiiGeometry">
        /// GeoJSON object. Displayed when radiiGeometry=true in request. Describes the outline of the wind radius quadrants.
        /// Please note <see cref="GeoObject"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="GeoCollection"/>, <see cref="GeoLineString"/>, <see cref="GeoLineStringCollection"/>, <see cref="GeoPoint"/>, <see cref="GeoPointCollection"/>, <see cref="GeoPolygon"/> and <see cref="GeoPolygonCollection"/>.
        /// </param>
        internal StormWindRadiiSummary(string timestamp, WeatherValue windSpeed, IReadOnlyList<RadiusSector> radiusSectorData, GeoObject radiiGeometry)
        {
            Timestamp = timestamp;
            WindSpeed = windSpeed;
            RadiusSectorData = radiusSectorData;
            RadiiGeometry = radiiGeometry;
        }
        /// <summary>
        /// GeoJSON object. Displayed when radiiGeometry=true in request. Describes the outline of the wind radius quadrants.
        /// Please note <see cref="GeoJsonGeometry"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="GeoJsonGeometryCollection"/>, <see cref="GeoJsonLineString"/>, <see cref="GeoJsonMultiLineString"/>, <see cref="GeoJsonMultiPoint"/>, <see cref="GeoJsonMultiPolygon"/>, <see cref="GeoJsonPoint"/> and <see cref="GeoJsonPolygon"/>.
        /// </summary>
        public GeoObject RadiiGeometry { get; }
    }
}
