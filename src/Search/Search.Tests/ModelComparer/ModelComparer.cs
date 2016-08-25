// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Compares instances of a type for structural equality, taking into account public properties, collections, and dictionaries.
    /// </summary>
    /// <typeparam name="T">Type of objects to compare.</typeparam>
    /// <remarks>
    /// <para>
    /// Supported types include enums, primitives, nullables, List, Dictionary, and DTOs having public properties
    /// composed of the supported types (including other nested DTOs). The rules are different for different types.
    /// </para>
    /// <para>
    /// Any type implementing IEnumerable, including dictionaries, are compared element by element and compose with the other mapping
    /// rules on element type.
    /// </para>
    /// <para>
    /// DTOs are compared by the values of their public properties. Note that comparisons are performed according to the actual most-derived
    /// type of the objects (which must match), not the apparent static type of the references.
    /// </para>
    /// <para>
    /// Enums, primitive types, and any other type not falling into the other categories are compared using Object.Equals().
    /// </para>
    /// </remarks>
    public class ModelComparer<T> : IEqualityComparer<T>
    {
        private readonly IEqualityComparer _comparer = new DynamicModelComparer(typeof(T));

        public bool Equals(T x, T y) => _comparer.Equals(x, y);

        public int GetHashCode(T obj) => obj?.GetHashCode() ?? 0;

        private class DynamicModelComparer : IEqualityComparer
        {
            private readonly Type _type;

            public DynamicModelComparer(Type type)
            {
                _type = type;
            }

            int IEqualityComparer.GetHashCode(object obj) => obj?.GetHashCode() ?? 0;

            bool IEqualityComparer.Equals(object x, object y)
            {
                if (_type.CanBeNull() && (x == null || y == null))
                {
                    return CompareNull(x, y);
                }

                // At this point x and y are guaranteed to be non-null (possibly because they are boxed value types).

                if (_type.ImplementsGenericEquatable())
                {
                    return CompareEquatables(x, y);
                }

                Type enumerable = _type.GetIEnumerable();
                if (enumerable != null)
                {
                    return CompareEnumerables(enumerable, x, y);
                }

                Type actualType = x.GetType();
                if (y.GetType() != actualType)
                {
                    // The only case where x and y can have different types and still be equal is integer comparison.
                    return ComparePossibleIntegers(x, y);
                }

                // At this point x and y are guaranteed to be of the same dynamic type.

                if (_type != actualType)
                {
                    return ComparePolymorphicObjects(actualType, x, y);
                }

                // At this point, the dynamic type of x and y are guaranteed to match the given type.

                PropertyInfo[] properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (properties.Any())
                {
                    return CompareProperties(properties, x, y);
                }
                else if (_type.IsReferenceType())
                {
                    // We have two instances of the same reference type with no public properties. With no other way to distinguish them, we have
                    // to assume they're equal.
                    return true;
                }

                return x.Equals(y);
            }

            private static bool CompareRecursive(Type type, object x, object y)
            {
                IEqualityComparer comparer = new DynamicModelComparer(type);
                return comparer.Equals(x, y);
            }

            private static bool CompareNull(object x, object y)
            {
                if (x == null && y == null)
                {
                    return true;
                }

                object notNull = (x != null) ? x : y;
                Type type = notNull.GetType();

                // ASSUMPTION: ModelComparer is used to compare model classes that map to OData JSON payloads. In OData, the default value of
                // a collection is an empty collection, not null. However, in .NET, missing JSON properties are modeled as null. To compensate
                // for this semantic gap, we will consider null and empty enumerables to be equivalent.
                if (type.IsIEnumerable())
                {
                    IEnumerator enumerator = ((IEnumerable)notNull).GetEnumerator();
                    enumerator.Reset();
                    bool isEmpty = !enumerator.MoveNext();
                    return isEmpty;
                }

                // For value types, we go by the rule that null is equal to default(T). This works for cases where a client omits a property in
                // a request, and the property comes back with its default value in the response.
                if (type.GetTypeInfo().IsValueType)
                {
                    object defaultInstance = Activator.CreateInstance(type);
                    return notNull.Equals(defaultInstance);
                }

                return false;
            }

            private static bool CompareEnumerables(Type enumerable, object x, object y)
            {
                Type elementType = enumerable.GenericTypeArguments.First();
                IEnumerator xs = ((IEnumerable)x).GetEnumerator();
                IEnumerator ys = ((IEnumerable)y).GetEnumerator();

                IEqualityComparer elementComparer = new DynamicModelComparer(elementType);

                xs.Reset();
                ys.Reset();

                while (xs.MoveNext())
                {
                    if (!ys.MoveNext())
                    {
                        return false;
                    }

                    if (!elementComparer.Equals(xs.Current, ys.Current))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool ComparePolymorphicObjects(Type derivedType, object x, object y) => CompareRecursive(derivedType, x, y);

            private static bool CompareProperty(PropertyInfo property, object x, object y) =>
                CompareRecursive(property.PropertyType, property.GetValue(x), property.GetValue(y));

            private bool CompareProperties(PropertyInfo[] properties, object x, object y)
            {
                IEnumerable<PropertyInfo> selectedProperties = properties;

                Type resourceWithETag = _type.GetIResourceWithETag();
                if (resourceWithETag != null)
                {
                    PropertyInfo[] resourceProperties = resourceWithETag.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    selectedProperties = properties.Except(resourceProperties, new PropertyInfoComparer());
                }

                return selectedProperties.All(p => CompareProperty(p, x, y));
            }

            private bool ComparePossibleIntegers(object x, object y)
            {
                if (!x.GetType().IsInteger() && !x.GetType().IsInteger())
                {
                    return false;
                }

                long xLong = Convert.ToInt64(x);
                long yLong = Convert.ToInt64(y);

                return xLong == yLong;
            }

            private bool CompareEquatables(object x, object y)
            {
                Type boundEquatable = typeof(IEquatable<>).MakeGenericType(_type);
                MethodInfo equals = boundEquatable.GetMethod("Equals");
                return (bool)equals.Invoke(x, new[] { y });
            }

            private class PropertyInfoComparer : IEqualityComparer<PropertyInfo>
            {
                public bool Equals(PropertyInfo x, PropertyInfo y)
                {
                    if (x == null)
                    {
                        return y == null;
                    }
                    else if (y == null)
                    {
                        return false;
                    }

                    return x.Name == y.Name;
                }

                public int GetHashCode(PropertyInfo obj) => obj?.Name?.GetHashCode() ?? 0;
            }
        }
    }
}
