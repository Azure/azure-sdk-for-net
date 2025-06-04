// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.GeoJson;

namespace Azure.Maps.Weather.Models
{
    /// <summary> Forecast window for the storm. </summary>
    public partial class WeatherWindow
    {
        /// <summary> Initializes a new instance of <see cref="WeatherWindow"/>. </summary>
        /// <param name="topLeft"> Location of the point on the left side of the window at the time of the timeframe. </param>
        /// <param name="bottomRight"> Location of the point on the right side of the window at the end of the timeframe. </param>
        /// <param name="beginTimestamp"> DateTime of the beginning of the window of movement, displayed in ISO8601 format. </param>
        /// <param name="endTimestamp"> DateTime of the end of the window of movement, displayed in ISO8601 format. </param>
        /// <param name="beginStatus"> Storm status at the beginning of the window. </param>
        /// <param name="endStatus"> Storm status at the end of the window. </param>
        /// <param name="geometry">
        /// Displayed when windowGeometry=true in request. GeoJSON object containing coordinates describing the window of movement during the specified timeframe.
        /// Please note <see cref="GeoObject"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="GeoCollection"/>, <see cref="GeoLineString"/>, <see cref="GeoLineStringCollection"/>, <see cref="GeoPoint"/>, <see cref="GeoPointCollection"/>, <see cref="GeoPolygon"/> and <see cref="GeoPolygonCollection"/>.
        /// </param>
        internal WeatherWindow(LatLongPair topLeft, LatLongPair bottomRight, DateTimeOffset? beginTimestamp, DateTimeOffset? endTimestamp, string beginStatus, string endStatus, GeoObject geometry)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
            BeginTimestamp = beginTimestamp;
            EndTimestamp = endTimestamp;
            BeginStatus = beginStatus;
            EndStatus = endStatus;
            Geometry = geometry;
        }

        /// <summary>
        /// Displayed when windowGeometry=true in request. GeoJSON object containing coordinates describing the window of movement during the specified timeframe.
        /// Please note <see cref="GeoJsonGeometry"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="GeoJsonGeometryCollection"/>, <see cref="GeoJsonLineString"/>, <see cref="GeoJsonMultiLineString"/>, <see cref="GeoJsonMultiPoint"/>, <see cref="GeoJsonMultiPolygon"/>, <see cref="GeoJsonPoint"/> and <see cref="GeoJsonPolygon"/>.
        /// </summary>
        public GeoObject Geometry { get; }
    }
}
