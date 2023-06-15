// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// The format of property names in dynamic and serialized content.
    /// </summary>
    public enum PropertyNameFormat
    {
        /// <summary>
        /// No specified format for property names.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that content uses a camel-case format for property names.
        /// </summary>
        CamelCase = 1
    }
}
