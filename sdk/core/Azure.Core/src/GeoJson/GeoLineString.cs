// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a line geometry that consists of multiple coordinates.
    /// </summary>
    /// <example>
    /// Creating a line:
    /// <code snippet="Snippet:CreateLineString" language="csharp">
    /// var line = new GeoLineString(new[]
    /// {
    ///     new GeoPosition(-122.108727, 47.649383),
    ///     new GeoPosition(-122.081538, 47.640846),
    ///     new GeoPosition(-122.078634, 47.576066),
    ///     new GeoPosition(-122.112686, 47.578559),
    /// });
    /// </code>
    /// </example>
    [JsonConverter(typeof(GeoJsonConverter))]
    public sealed class GeoLineString : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLineString"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoPosition"/> that make up the line.</param>
        public GeoLineString(IEnumerable<GeoPosition> coordinates): this(coordinates, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLineString"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoPosition"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoLineString(IEnumerable<GeoPosition> coordinates, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Coordinates = new GeoArray<GeoPosition>(coordinates.ToArray());
        }

        /// <summary>
        /// Returns a view over the coordinates array that forms this geometry.
        /// </summary>
        public GeoArray<GeoPosition> Coordinates { get; }

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.LineString;
    }
}