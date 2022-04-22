// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a polygon consisting of outer ring and optional inner rings.
    /// </summary>
    /// <example>
    /// Creating a polygon:
    /// <code snippet="Snippet:CreatePolygon" language="csharp">
    /// var polygon = new GeoPolygon(new[]
    /// {
    ///     new GeoPosition(-122.108727, 47.649383),
    ///     new GeoPosition(-122.081538, 47.640846),
    ///     new GeoPosition(-122.078634, 47.576066),
    ///     new GeoPosition(-122.112686, 47.578559),
    ///     new GeoPosition(-122.108727, 47.649383),
    /// });
    /// </code>
    /// Creating a polygon with holes:
    /// <code snippet="Snippet:CreatePolygonWithHoles" language="csharp">
    /// var polygon = new GeoPolygon(new[]
    /// {
    ///     // Outer ring
    ///     new GeoLinearRing(new[]
    ///     {
    ///         new GeoPosition(-122.108727, 47.649383),
    ///         new GeoPosition(-122.081538, 47.640846),
    ///         new GeoPosition(-122.078634, 47.576066),
    ///         new GeoPosition(-122.112686, 47.578559),
    ///         // Last position same as first
    ///         new GeoPosition(-122.108727, 47.649383),
    ///     }),
    ///     // Inner ring
    ///     new GeoLinearRing(new[]
    ///     {
    ///         new GeoPosition(-122.102370, 47.607370),
    ///         new GeoPosition(-122.083488, 47.608007),
    ///         new GeoPosition(-122.085419, 47.597879),
    ///         new GeoPosition(-122.107005, 47.596895),
    ///         // Last position same as first
    ///         new GeoPosition(-122.102370, 47.607370),
    ///     })
    /// });
    /// </code>
    /// </example>
    [JsonConverter(typeof(GeoJsonConverter))]
    public sealed class GeoPolygon : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygon"/>.
        /// </summary>
        /// <param name="positions">The positions that make up the outer ring of the polygon.</param>
        public GeoPolygon(IEnumerable<GeoPosition> positions): this(new[] { new GeoLinearRing(positions) }, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygon"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        public GeoPolygon(IEnumerable<GeoLinearRing> rings): this(rings, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygon"/>.
        /// </summary>
        /// <param name="rings">The collection of rings that make up the polygon, first ring is the outer ring others are inner rings.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPolygon(IEnumerable<GeoLinearRing> rings, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Argument.AssertNotNull(rings, nameof(rings));

            Rings = rings.ToArray();
        }

        /// <summary>
        /// Gets a set of rings that form the polygon.
        /// </summary>
        public IReadOnlyList<GeoLinearRing> Rings { get; }

        /// <summary>
        /// Returns the outer ring of the polygon.
        /// </summary>
        public GeoLinearRing OuterRing => Rings[0];

        /// <summary>
        /// Returns a view over the coordinates array that forms this geometry.
        /// </summary>
        public GeoArray<GeoArray<GeoPosition>> Coordinates => new GeoArray<GeoArray<GeoPosition>>(this);

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.Polygon;
    }
}