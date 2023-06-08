// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Options for using a specified naming convention with dynamic and serialized content.
    /// </summary>
    public enum PropertyNamingConvention
    {
        /// <summary>
        /// Properties in the target content will use the same names as those used in the C# code.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that a camel-case naming convention will be used in the target content.
        ///
        /// With this option, names used in C# code will be converted to a camel-case format when working with the target content.
        /// See <see cref="System.Text.Json.JsonNamingPolicy.CamelCase"/> for details of the conversion.
        /// </summary>
        CamelCase = 1
    }
}
