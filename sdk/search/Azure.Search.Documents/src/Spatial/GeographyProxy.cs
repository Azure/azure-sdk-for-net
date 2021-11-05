// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Proxy for a Microsoft.Spatial.Geography class.
    /// </summary>
    internal abstract class GeographyProxy
    {
        private readonly Type _type;

        /// <summary>
        /// Creates a new instance of the <see cref="GeographyProxy"/> class.
        /// </summary>
        /// <param name="value">The Microsoft.Spatial.Geography object to proxy. This is assumed to derive from a Microsoft.Spatial.Geography class.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public GeographyProxy(object value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            _type = value.GetType();
        }

        /// <summary>
        /// Gets the original value passed into the proxy.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Returns an OData filter representation of the underlying Microsoft.Spatial.Geography object.
        /// </summary>
        /// <returns></returns>
        public abstract override string ToString();

        /// <summary>
        /// Gets the value of the named property.
        /// </summary>
        /// <typeparam name="T">The type of property to get.</typeparam>
        /// <param name="property">A reference to a statically cached <see cref="PropertyInfo"/>.</param>
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

        /// <summary>
        /// Gets the proxied collection value of the named property.
        /// </summary>
        /// <typeparam name="T">The type of the proxy to get.</typeparam>
        /// <param name="property">A reference to a statically cached <see cref="PropertyInfo"/>.</param>
        /// <param name="proxies">A reference to an cached collection of proxies.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="factory">The factory method to create an instance of the <typeparamref name="T"/> proxy class.</param>
        /// <returns>A proxied collection of the named property.</returns>
        protected IReadOnlyList<T> GetCollectionPropertyValue<T>(
            ref PropertyInfo property,
            ref IReadOnlyList<T> proxies,
            string name,
            Func<object, T> factory)
            where T : GeographyProxy
        {
            if (proxies is null)
            {
                IReadOnlyList<object> list = GetPropertyValue<IReadOnlyList<object>>(ref property, name);

                List<T> _proxies = new List<T>(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    T proxy = factory(list[i]);
                    _proxies.Add(proxy);
                }

                proxies = _proxies;
            }

            return proxies;
        }
    }
}
