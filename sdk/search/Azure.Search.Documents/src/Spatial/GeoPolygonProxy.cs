// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a <see cref="Azure.Core.GeoJson.GeoPolygon"/> class.
    /// </summary>
    internal sealed class GeoPolygonProxy : GeoObjectProxy
    {
        private static PropertyInfo s_ringsProperty;
        private IReadOnlyList<GeoLinearRingProxy> _rings;

        /// <summary>
        /// Creates a new instance of the <see cref="GeoPolygonProxy"/> class.
        /// </summary>
        /// <param name="value">The <see cref="Azure.Core.GeoJson.GeoPolygon"/> object to proxy.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeoPolygonProxy(object value) : base(value)
        {
        }

        /// <summary>
        /// Gets the proxy for <see cref="Azure.Core.GeoJson.GeoPolygon.Rings"/> collection.
        /// </summary>
        public IReadOnlyList<GeoLinearRingProxy> Rings =>
            GetCollectionPropertyValue(
                ref s_ringsProperty,
                ref _rings,
                nameof(Rings),
                value => new GeoLinearRingProxy(value));

        /// <inheritdoc/>
        public override string ToString() => SpatialFormatter.EncodePolygon(this);
    }
}
