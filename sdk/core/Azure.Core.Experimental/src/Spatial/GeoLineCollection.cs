// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a geometry that is composed of multiple <see cref="GeoLine"/>.
    /// </summary>
    public sealed class GeoLineCollection : GeoObject, IReadOnlyList<GeoLine>
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLineCollection"/>.
        /// </summary>
        /// <param name="lines">The collection of inner lines.</param>
        public GeoLineCollection(IEnumerable<GeoLine> lines): this(lines, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLineCollection"/>.
        /// </summary>
        /// <param name="lines">The collection of inner lines.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoLineCollection(IEnumerable<GeoLine> lines, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Argument.AssertNotNull(lines, nameof(lines));

            Lines = lines.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        internal IReadOnlyList<GeoLine> Lines { get; }

        /// <inheritdoc />
        public IEnumerator<GeoLine> GetEnumerator()
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
        public GeoLine this[int index] => Lines[index];
    }
}