// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// An attribute class indicating to Autorest a reference type for code generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class PropertyReferenceTypeAttribute : Attribute
    {
        /// <summary>
        /// Instantiate a new reference type attribute.
        /// </summary>
        /// <param name="optionalProperties"> An array of property names that are optional when comparing the type. </param>
        public PropertyReferenceTypeAttribute(string[] optionalProperties)
            : this(optionalProperties, Array.Empty<string>())
        {
        }

        /// <summary>
        /// Instantiate a new reference type attribute.
        /// </summary>
        /// <param name="optionalProperties"> An array of property names that are optional when comparing the type. </param>
        /// <param name="internalPropertiesToInclude">An array of internal properties to include for the reference type when evaluating whether type
        /// replacement should occur. When evaluating a type for replacement with a reference type, all internal properties are considered on the
        /// type to be replaced. Thus this parameter can be used to specify internal properties to allow replacement to occur on a type with internal
        /// properties.</param>
        public PropertyReferenceTypeAttribute(string[] optionalProperties, string[] internalPropertiesToInclude)
        {
            OptionalProperties = optionalProperties;
            InternalPropertiesToInclude = internalPropertiesToInclude;
        }

        public string[] InternalPropertiesToInclude { get; }

        /// <summary>
        /// Instantiate a new reference type attribute.
        /// </summary>
        public PropertyReferenceTypeAttribute()
            : this(Array.Empty<string>(), Array.Empty<string>())
        {
        }

        /// <summary>
        /// Get an array of property names that are optional when comparing the type.
        /// </summary>
        public string[] OptionalProperties { get; }
    }
}
