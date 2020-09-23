// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Creates <see cref="GeometryProxy"/> instances from unknown objects.
    /// </summary>
    internal static class SpatialProxyFactory
    {
        private const string Name = "Microsoft.Spatial";

        private static readonly IReadOnlyDictionary<string, Func<object, GeometryProxy>> s_types =
            new Dictionary<string, Func<object, GeometryProxy>>(StringComparer.OrdinalIgnoreCase)
            {
                ["Microsoft.Spatial.GeometryLineString"] = value => new GeometryLineStringProxy(value),
                ["Microsoft.Spatial.GeometryPoint"] = value => new GeometryPointProxy(value),
                ["Microsoft.Spatial.GeometryPolygon"] = value => new GeometryPolygonProxy(value),
                ["Microsoft.Spatial.GeometryPosition"] = value => new GeometryPositionProxy(value),
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
        /// Creates a <see cref="GeometryProxy"/> from the given <paramref name="value"/> if supported.
        /// <seealso cref="CanCreate(Type)"/>
        /// </summary>
        /// <param name="value">The value to proxy.</param>
        /// <returns>A <see cref="GeometryProxy"/> from the given <paramref name="value"/> if supported, or null if <paramref name="value"/> is null.</returns>
        /// <exception cref="NotSupportedException">The <paramref name="value"/> type is not supported.</exception>
        public static GeometryProxy Create(object value)
        {
            if (value is null)
            {
                return null;
            }

            Type type = value.GetType();
            if (TryGetFactory(type, out Func<object, GeometryProxy> factory))
            {
                return factory(value);
            }

            throw new NotSupportedException($"Type {value.GetType()} is not supported");
        }

        private static bool TryGetFactory(Type type, out Func<object, GeometryProxy> factory)
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
