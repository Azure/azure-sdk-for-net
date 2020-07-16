// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// An abstraction of type information specifically for serialization.
    /// </summary>
    public abstract class SerializableTypeInfo
    {
        /// <summary>
        /// Gets the underlying <see cref="System.Type"/> being serialized.
        /// </summary>
        public abstract Type Type { get; }

        /// <summary>
        /// Gets the collection of properties to be serialized.
        /// </summary>
        public abstract IReadOnlyCollection<SerializablePropertyInfo> Properties { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> represents a serialization primitive.
        /// </summary>
        public virtual bool IsPrimitive => Type.IsPrimitive;

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> represents a serializable collection.
        /// </summary>
        public virtual bool IsCollection => typeof(IEnumerable).IsAssignableFrom(Type);

        /// <summary>
        /// Gets the collection element <see cref="Type"/> if <see cref="IsCollection"/> returns true.
        /// </summary>
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public virtual Type? CollectionElementType => throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

        /// <summary>
        /// Gets all attributes declared on the type or inherited from base classes.
        /// </summary>
        /// <param name="inherit">Whether to return all attributes inherited from any base classes.</param>
        public virtual IReadOnlyCollection<object> GetAttributes(bool inherit) => Type.GetCustomAttributes(inherit);
    }
}
