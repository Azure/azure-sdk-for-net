// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class CodeGenMemberAttribute : Attribute
    {
        public string? OriginalName { get; }

        /// <summary>
        /// For collection properties. When set to true empty collection would be treated as undefined and not serialized.
        /// </summary>
        public bool EmptyAsUndefined { get; set; }

        /// <summary>
        /// For collection and model properties. Whether the property would always be initialized on creation/deserialization.
        /// Requires a parameterless constructor for implementation type.
        /// </summary>
        public bool Initialize { get; set; }

        public CodeGenMemberAttribute()
        {
        }

        public CodeGenMemberAttribute(string originalName)
        {
            OriginalName = originalName;
        }
    }
}