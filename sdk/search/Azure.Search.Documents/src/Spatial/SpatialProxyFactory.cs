// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Creates <see cref="GeographyProxy"/> instances from unknown objects.
    /// </summary>
    internal static class SpatialProxyFactory
    {
        private const string Name = "Microsoft.Spatial";

        // TODO: When GeoJson is built into Azure.Core, change these proxies to adapter for GeoJson types.
        // https://github.com/Azure/azure-sdk-for-net/issues/13319

        private static readonly IReadOnlyDictionary<string, Func<object, GeographyProxy>> s_types =
            new Dictionary<string, Func<object, GeographyProxy>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Microsoft.Spatial.GeographyLineString"] = value => new GeographyLineStringProxy(value),
                ["Microsoft.Spatial.GeographyPoint"] = value => new GeographyPointProxy(value),
                ["Microsoft.Spatial.GeographyPolygon"] = value => new GeographyPolygonProxy(value),
            };

        /// <summary>
        /// Gets a value indicating whether the given <paramref name="type"/> can be created by this factory.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>A value indicating whether <paramref name="type"/> can be created by this factory.</returns>
        public static bool CanCreate(Type type)
        {
            if (type is null)
            {
                return false;
            }

            return TryGetFactory(type, out _);
        }

        /// <summary>
        /// Creates a <see cref="GeographyProxy"/> from the given <paramref name="value"/> if supported.
        /// <seealso cref="CanCreate(Type)"/>
        /// </summary>
        /// <param name="value">The value to proxy.</param>
        /// <returns>A <see cref="GeographyProxy"/> from the given <paramref name="value"/> if supported, or null if <paramref name="value"/> is null.</returns>
        /// <exception cref="NotSupportedException">The <paramref name="value"/> type is not supported.</exception>
        public static GeographyProxy Create(object value)
        {
            if (value is null)
            {
                return null;
            }

            if (TryCreate(value, out GeographyProxy proxy))
            {
                return proxy;
            }

            throw new NotSupportedException($"Type {value.GetType()} is not supported");
        }

        /// <summary>
        /// Attempts to creates a <see cref="GeographyProxy"/> from the given <paramref name="value"/> if supported.
        /// <seealso cref="CanCreate(Type)"/>
        /// </summary>
        /// <param name="value">The value to proxy.</param>
        /// <param name="proxy">The proxied value if supported.</param>
        /// <returns>True if the <paramref name="value"/> could be proxied; otherwise, false.</returns>
        internal static bool TryCreate(object value, out GeographyProxy proxy)
        {
            if (value is { })
            {
                Type type = value.GetType();
                if (TryGetFactory(type, out Func<object, GeographyProxy> factory))
                {
                    proxy = factory(value);
                    return true;
                }
            }

            proxy = null;
            return false;
        }

        private static bool TryGetFactory(Type type, out Func<object, GeographyProxy> factory)
        {
            // TODO: Should we compare the public key token as well, or is that too restrictive or unnecessarily slow?
            AssemblyName assemblyName = type.Assembly.GetName();
            if (string.Equals(assemblyName.Name, Name, StringComparison.OrdinalIgnoreCase))
            {
                while (type != typeof(object))
                {
                    if (s_types.TryGetValue(type.FullName, out factory))
                    {
                        return true;
                    }

                    type = type.BaseType;
                }
            }

            factory = null;
            return false;
        }
    }
}
