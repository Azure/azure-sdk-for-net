// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.Geometry class.
    /// </summary>
    internal abstract class GeometryProxy
    {
        private readonly Type _type;

        /// <summary>
        /// Creates a new instance of the <see cref="GeometryProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.Geometry object to proxy. This is assumed to derive from a Microsoft.Spatial.Geometry class.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeometryProxy(object value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            _type = value.GetType();
        }

        /// <summary>
        /// Gets the original value passed into the proxy.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Gets the value of the named property.
        /// </summary>
        /// <typeparam name="T">The type of property to get.</typeparam>
        /// <param name="property">A reference to a cached <see cref="PropertyInfo"/>.</param>
        /// <param name="name">The name of the property.</param>
        /// <returns>The value of the named property.</returns>
        protected T GetPropertyValue<T>(ref PropertyInfo property, string name)
        {
            if (property is null)
            {
                // The information retrieved is invariant so no reason to synchronize.
                property = _type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            }

            return (T)property.GetValue(Value);
        }
    }
}
