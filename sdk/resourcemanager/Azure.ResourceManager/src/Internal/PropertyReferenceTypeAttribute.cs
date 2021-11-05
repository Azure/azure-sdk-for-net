// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// An attribute class indicating a reference type for code generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class PropertyReferenceTypeAttribute : Attribute
    {
        /// <summary>
        /// Instatiate a new reference type attribute.
        /// </summary>
        /// <param name="skipTypes"> An array of types to skip for this reference type. </param>
        public PropertyReferenceTypeAttribute(Type[] skipTypes)
        {
            SkipTypes = skipTypes;
        }

        /// <summary>
        /// Instatiate a new reference type attribute.
        /// </summary>
        public PropertyReferenceTypeAttribute()
            : this(Array.Empty<Type>())
        {
        }

        /// <summary>
        /// Get an array of types to skip for this reference type.
        /// </summary>
        public Type[] SkipTypes { get; }
    }
}
