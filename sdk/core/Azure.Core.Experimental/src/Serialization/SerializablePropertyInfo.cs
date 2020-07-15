// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// An abstraction of property information specifically for serialization.
    /// </summary>
    public abstract class SerializablePropertyInfo
    {
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
        /// Gets a value indicating whether the property should be ignored.
        /// TODO: Consider whether ignored properties should just not be returned.
        /// </summary>
        public bool ShouldIgnore { get; }

        /// <summary>
        /// Gets all attributes declared on the property or inherited from base classes.
        /// </summary>
        /// <param name="inherit">Whether to return all attributes inherited from any base classes.</param>
        public abstract IReadOnlyCollection<Attribute> GetAttributes(bool inherit);
    }
}
