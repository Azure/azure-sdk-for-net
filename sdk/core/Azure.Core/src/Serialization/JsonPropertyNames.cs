// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// The format of property names in dynamic and serialized JSON content.
    /// </summary>
    public enum JsonPropertyNames
    {
        /// <summary>
        /// Unspecified format for JSON property names.
        /// </summary>
        Strict = 0,

        /// <summary>
        /// Indicates that JSON content uses a camel-case format for property names.
        /// </summary>
        CamelCase = 1
    }
}
