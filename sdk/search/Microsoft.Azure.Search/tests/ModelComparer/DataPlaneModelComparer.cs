// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using Microsoft.Azure.Search.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Compares instances of a type for structural equality, including special rules specific to the data plane SDK (comparing OData collections and ETags).
    /// </summary>
    /// <typeparam name="T">Type of objects to compare.</typeparam>
    public sealed class DataPlaneModelComparer<T> : IEqualityComparer<T>
    {
        private readonly IEqualityComparer<T> _comparer = new ModelComparer<T>(areBothNull: CompareNull, shouldIgnoreProperty: IsETagProperty);

        public bool Equals(T x, T y) => _comparer.Equals(x, y);

        public int GetHashCode(T obj) => obj?.GetHashCode() ?? 0;

        private static bool CompareNull(object x, object y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            object notNull = x ?? y;
            Type type = notNull.GetType();

            // DataPlaneModelComparer is used to compare model classes that map to OData JSON payloads. In OData, the default value of
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

        private static bool IsETagProperty(PropertyInfo property)
        {
            Type type = property.DeclaringType;

            Type GetIResourceWithETag()
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                Type resourceWithETagType = typeof(IResourceWithETag);
                return type == resourceWithETagType ? type : typeInfo.ImplementedInterfaces.FirstOrDefault(t => t == resourceWithETagType);
            }

            Type resourceWithETag = GetIResourceWithETag();
            if (resourceWithETag != null)
            {
                PropertyInfo[] resourceProperties = resourceWithETag.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                return resourceProperties.Any(p => p.Name == property.Name && p.PropertyType == property.PropertyType);
            }

            return false;
        }
    }
}
