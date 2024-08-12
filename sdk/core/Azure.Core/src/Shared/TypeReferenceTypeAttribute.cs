// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// An attribute class indicating to Autorest a reference type which can replace a type in target SDKs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class TypeReferenceTypeAttribute : Attribute
    {
        /// <summary>
        /// Constructs a new instance of <see cref="TypeReferenceTypeAttribute"/>.
        /// </summary>
        public TypeReferenceTypeAttribute()
           : this(false, Array.Empty<string>())
        {
        }

        /// <summary>
        /// Constructs a new instance of <see cref="TypeReferenceTypeAttribute"/>.
        /// </summary>
        /// <param name="ignoreExtraProperties">Whether to allow replacement to occur when the type to be replaced
        /// contains extra properties as compared to the reference type attributed with <see cref="TypeReferenceTypeAttribute"/> that it will
        /// be replaced with. Defaults to false.</param>
        /// <param name="internalPropertiesToInclude">An array of internal properties to include for the reference type when evaluating whether type
        /// replacement should occur. When evaluating a type for replacement with a reference type, all internal properties are considered on the
        /// type to be replaced. Thus this parameter can be used to specify internal properties to allow replacement to occur on a type with internal
        /// properties.</param>
        public TypeReferenceTypeAttribute(bool ignoreExtraProperties, string[] internalPropertiesToInclude)
        {
            IgnoreExtraProperties = ignoreExtraProperties;
            InternalPropertiesToInclude = internalPropertiesToInclude;
        }

        public bool IgnoreExtraProperties { get; }
        public string[] InternalPropertiesToInclude { get; }
    }
}
