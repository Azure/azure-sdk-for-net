// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// An attribute class indicating a reference type for code generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ReferenceTypeAttribute : Attribute
    {
        /// <summary>
        /// Instatiate a new reference type attribute.
        /// </summary>
        /// <param name="genericType"> The generic type for this reference type. </param>
        public ReferenceTypeAttribute(Type genericType)
        {
            GenericType = genericType;
        }

        /// <summary>
        /// Instatiate a new reference type attribute.
        /// </summary>
        public ReferenceTypeAttribute() : this(null)
        {
        }

        /// <summary>
        /// Get the generic type for this reference type.
        /// </summary>
        public Type GenericType { get; }
    }
}
