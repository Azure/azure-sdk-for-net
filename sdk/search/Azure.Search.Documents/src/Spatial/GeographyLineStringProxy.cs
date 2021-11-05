// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.GeographyLineString class.
    /// </summary>
    internal class GeographyLineStringProxy : GeographyProxy
    {
        private static PropertyInfo s_pointsProperty;
        private IReadOnlyList<GeographyPointProxy> _points;

        /// <summary>
        /// Creates a new instance of the <see cref="GeographyLineStringProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.GeographyLineString object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeographyLineStringProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the point collection.
        /// </summary>
        public IReadOnlyList<GeographyPointProxy> Points =>
            GetCollectionPropertyValue(
                ref s_pointsProperty,
                ref _points,
                nameof(Points),
                value => new GeographyPointProxy(value));

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePolygon(this);
    }
}
