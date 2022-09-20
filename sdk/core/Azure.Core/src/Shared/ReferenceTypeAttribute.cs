// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// An attribute class indicating to Autorest a reference type for code generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class ReferenceTypeAttribute : Attribute
    {
        /// <summary>
        /// Instantiate a new reference type attribute.
        /// </summary>
        /// <param name="optionalProperties"> An array of property names that are optional when comparing the type. </param>
        public ReferenceTypeAttribute(string[] optionalProperties)
        {
            OptionalProperties = optionalProperties;
        }

        /// <summary>
        /// Instantiate a new reference type attribute.
        /// </summary>
        public ReferenceTypeAttribute()
            : this(Array.Empty<string>())
        {
        }

        /// <summary>
        /// Get an array of property names that are optional when comparing the type.
        /// </summary>
        public string[] OptionalProperties { get; }
    }
}
