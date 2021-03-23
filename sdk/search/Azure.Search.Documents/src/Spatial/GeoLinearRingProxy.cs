// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a <see cref="Azure.Core.GeoJson.GeoLinearRing"/> class.
    /// </summary>
    internal sealed class GeoLinearRingProxy : GeoObjectProxy
    {
        private static PropertyInfo s_pointsProperty;
        private IReadOnlyList<GeoPositionProxy> _points;

        /// <summary>
        /// Creates a new instance of the <see cref="GeoLineStringProxy"/> class.
        /// </summary>
        /// <param name="value">The <see cref="Azure.Core.GeoJson.GeoLinearRing"/> object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeoLinearRingProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the proxy for <see cref="Azure.Core.GeoJson.GeoLinearRing.Coordinates"/> collection.
        /// </summary>
        public IReadOnlyList<GeoPositionProxy> Coordinates =>
            GetCollectionPropertyValue(
                ref s_pointsProperty,
                ref _points,
                nameof(Coordinates));

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePolygon(this);
    }
}
