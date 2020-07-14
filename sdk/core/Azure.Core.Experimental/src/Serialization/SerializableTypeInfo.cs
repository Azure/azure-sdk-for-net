// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public IReadOnlyCollection<SerializablePropertyInfo> Properties { get; } = new List<SerializablePropertyInfo>();
    }
}
