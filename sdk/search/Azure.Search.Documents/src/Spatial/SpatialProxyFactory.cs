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
        private const string GeographyPointTypeName = "Microsoft.Spatial.GeographyPoint";

        // TODO: When GeoJson is built into Azure.Core, change these proxies to adapter for GeoJson types.
        // https://github.com/Azure/azure-sdk-for-net/issues/13319

        private static readonly IReadOnlyDictionary<string, Func<object, GeographyProxy>> s_types =
            new Dictionary<string, Func<object, GeographyProxy>>(StringComparer.Ordinal)
            {
                [GeographyPointTypeName] = value => new GeographyPointProxy(value),
                ["Microsoft.Spatial.GeographyLineString"] = value => new GeographyLineStringProxy(value),
                ["Microsoft.Spatial.GeographyPolygon"] = value => new GeographyPolygonProxy(value),
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
        /// Attempts to creates a <see cref="GeographyProxy"/> from the given <paramref name="value"/> if supported.
        /// <seealso cref="CanCreate(Type)"/>
        /// </summary>
        /// <param name="value">The value to proxy.</param>
        /// <param name="proxy">The proxied value if supported.</param>
        /// <returns>True if the <paramref name="value"/> could be proxied; otherwise, false.</returns>
        public static bool TryCreate(object value, out GeographyProxy proxy)
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

        /// <summary>
        /// Gets a value indicating whether the given <paramref name="type"/> represents a supported spatial point.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>A value indicating whether the given <paramref name="type"/> represents a supported spatial point.</returns>
        public static bool IsSupportedPoint(Type type) =>
            type != null && IsSupportedAssembly(type) && GeographyPointTypeName.Equals(type.FullName, StringComparison.Ordinal);

        private static bool IsSupportedAssembly(Type type)
        {
            AssemblyName assemblyName = type.Assembly.GetName();
            return string.Equals(assemblyName.Name, Name, StringComparison.OrdinalIgnoreCase);
        }

        private static bool TryGetFactory(Type type, out Func<object, GeographyProxy> factory)
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
