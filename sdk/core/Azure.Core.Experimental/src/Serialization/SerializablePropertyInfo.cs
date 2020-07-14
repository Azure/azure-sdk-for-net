// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Azure.Core
{
    /// <summary>
    /// An abstraction of property information specifically for serialization.
    /// </summary>
    public abstract class SerializablePropertyInfo
    {
        private bool _detectedCollectionElementType;
        private Type? _collectionElementType;

        /// <summary>
        /// Gets the underlying type of the property.
        /// </summary>
        public abstract Type PropertyType { get; }

        /// <summary>
        /// Gets the name of the property as defined by the declaring type.
        /// </summary>
        public abstract string PropertyName { get; }

        /// <summary>
        /// Gets the name of the property to serialize.
        /// </summary>
        public abstract string SerializedName { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="PropertyType"/> represents a collection.
        /// </summary>
        public virtual bool IsCollection => typeof(IEnumerable).IsAssignableFrom(PropertyType);

        /// <summary>
        /// Gets the <see cref="Type"/> of the elements within a collection, or null if the <see cref="PropertyType"/> is not a collection.
        /// </summary>
        public virtual Type? CollectionElementType
        {
            get
            {
                if (IsCollection && !_detectedCollectionElementType)
                {
                    _detectedCollectionElementType = TryGetElementType(out _collectionElementType);
                    Debug.Assert(_detectedCollectionElementType, "expected collection");
                }

                return _collectionElementType;
            }
        }

        private bool TryGetElementType(out Type? collectionElementType)
        {
            static Type? GetElementType(Type t) =>
                t.IsConstructedGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>) ?
                t.GetGenericArguments()[0] :
                null;

            collectionElementType = GetElementType(PropertyType);
            if (collectionElementType != null)
            {
                return true;
            }

            Type?[] enumerableTypes = PropertyType.GetTypeInfo()
                .ImplementedInterfaces
                .Select(t => GetElementType(t))
                .Where(t => t != null)
                .ToArray();

            if (enumerableTypes.Length == 1)
            {
                collectionElementType = enumerableTypes[0];
                return true;
            }

            if (typeof(IEnumerable).IsAssignableFrom(PropertyType))
            {
                // Fall back to a collection of object if no specific element type discovered.
                collectionElementType = typeof(object);
                return true;
            }

            collectionElementType = null;
            return false;
        }
    }
}
