// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.GeoJson;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Creates <see cref="GeoObjectProxy"/> instances from unknown objects.
    /// </summary>
    internal static class SpatialProxyFactory
    {
        private const string Name = "Azure.Core";
        private const string GeoPointTypeName = "Azure.Core.GeoJson.GeoPoint";
        private const string GeoLineStringTypeName = "Azure.Core.GeoJson.GeoLineString";
        private const string GeoPolygonTypeName = "Azure.Core.GeoJson.GeoPolygon";

        // TODO: When GeoJson is built into Azure.Core, change these proxies to adapter for GeoJson types.
        // https://github.com/Azure/azure-sdk-for-net/issues/13319

        private static readonly IReadOnlyDictionary<string, Func<object, GeoObjectProxy>> s_types =
            new Dictionary<string, Func<object, GeoObjectProxy>>(StringComparer.Ordinal)
            {
                [GeoPointTypeName] = value => new GeoPointProxy(value),
                [GeoLineStringTypeName] = value => new GeoLineStringProxy(value),
                [GeoPolygonTypeName] = value => new GeoPolygonProxy(value),
            };

        /// <summary>
        /// Gets a value indicating whether the given <paramref name="type"/> can be created by this factory.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>A value indicating whether <paramref name="type"/> can be created by this factory.</returns>
        public static bool CanCreate(Type type)
        {
            if (type == null)
            {
                return false;
            }

            return TryGetFactory(type, out _);
        }

        /// <summary>
        /// Attempts to creates a <see cref="GeoObjectProxy"/> from the given <paramref name="value"/> if supported.
        /// <seealso cref="CanCreate(Type)"/>
        /// </summary>
        /// <param name="value">The value to proxy.</param>
        /// <param name="proxy">The proxied value if supported.</param>
        /// <returns>True if the <paramref name="value"/> could be proxied; otherwise, false.</returns>
        public static bool TryCreate(object value, out GeoObjectProxy proxy)
        {
            if (value is { })
            {
                Type type = value.GetType();
                if (TryGetFactory(type, out Func<object, GeoObjectProxy> factory))
                {
                    proxy = factory(value);
                    return true;
                }
            }

            proxy = null;
            return false;
        }

        /// <summary>
        /// Gets a value indicating whether the given <paramref name="type"/> represents a supported spatial point.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>A value indicating whether the given <paramref name="type"/> represents a supported spatial point.</returns>
        public static bool IsSupportedPoint(Type type) =>
            type != null && IsSupportedAssembly(type) && GeoPointTypeName.Equals(type.FullName, StringComparison.Ordinal);

        private static bool IsSupportedAssembly(Type type)
        {
            AssemblyName assemblyName = type.Assembly.GetName();

            // We use StartsWith() to allow both `Azure.Core` and `Azure.Core.Experimental`.
            return assemblyName.Name.StartsWith(Name, StringComparison.OrdinalIgnoreCase);
        }

        private static bool TryGetFactory(Type type, out Func<object, GeoObjectProxy> factory)
        {
            if (IsSupportedAssembly(type))
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
