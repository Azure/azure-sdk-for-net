// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a geometry that is composed of multiple geometries.
    /// </summary>
    public sealed class GeoCollection : Geometry, IReadOnlyList<Geometry>
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoCollection"/>.
        /// </summary>
        /// <param name="geometries">The collection of inner geometries.</param>
        public GeoCollection(IEnumerable<Geometry> geometries): this(geometries, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoCollection"/>.
        /// </summary>
        /// <param name="geometries">The collection of inner geometries.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public GeoCollection(IEnumerable<Geometry> geometries, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Argument.AssertNotNull(geometries, nameof(geometries));

            Geometries = geometries.ToArray();
        }

        /// <summary>
        /// Gets the list of <see cref="Geometry"/> geometry is composed of.
        /// </summary>
        internal IReadOnlyList<Geometry> Geometries { get; }

        /// <inheritdoc />
        public IEnumerator<Geometry> GetEnumerator()
        {
            return Geometries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public int Count => Geometries.Count;

        /// <inheritdoc />
        public Geometry this[int index] => Geometries[index];
    }
}