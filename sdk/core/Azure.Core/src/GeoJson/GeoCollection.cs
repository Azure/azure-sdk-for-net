// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a geometry that is composed of multiple geometries.
    /// </summary>
    public sealed class GeoCollection : GeoObject, IReadOnlyList<GeoObject>
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoCollection"/>.
        /// </summary>
        /// <param name="geometries">The collection of inner geometries.</param>
        public GeoCollection(IEnumerable<GeoObject> geometries): this(geometries, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoCollection"/>.
        /// </summary>
        /// <param name="geometries">The collection of inner geometries.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoCollection(IEnumerable<GeoObject> geometries, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Argument.AssertNotNull(geometries, nameof(geometries));

            Geometries = geometries.ToArray();
        }

        /// <summary>
        /// Gets the list of <see cref="GeoObject"/> geometry is composed of.
        /// </summary>
        internal IReadOnlyList<GeoObject> Geometries { get; }

        /// <inheritdoc />
        public IEnumerator<GeoObject> GetEnumerator()
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
        public GeoObject this[int index] => Geometries[index];

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.GeometryCollection;
    }
}