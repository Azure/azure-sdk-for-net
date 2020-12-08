// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a geometry that is composed of multiple <see cref="GeoLineString"/>.
    /// </summary>
    public sealed class GeoLineStringCollection : GeoObject, IReadOnlyList<GeoLineString>
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLineStringCollection"/>.
        /// </summary>
        /// <param name="lines">The collection of inner lines.</param>
        public GeoLineStringCollection(IEnumerable<GeoLineString> lines): this(lines, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLineStringCollection"/>.
        /// </summary>
        /// <param name="lines">The collection of inner lines.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoLineStringCollection(IEnumerable<GeoLineString> lines, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Argument.AssertNotNull(lines, nameof(lines));

            Lines = lines.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        internal IReadOnlyList<GeoLineString> Lines { get; }

        /// <inheritdoc />
        public IEnumerator<GeoLineString> GetEnumerator()
        {
            return Lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public int Count => Lines.Count;

        /// <inheritdoc />
        public GeoLineString this[int index] => Lines[index];

        /// <summary>
        /// Returns a view over the coordinates array that forms this geometry.
        /// </summary>
        public GeoArray<GeoArray<GeoPosition>> Coordinates => new GeoArray<GeoArray<GeoPosition>>(this);

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.MultiLineString;
    }
}