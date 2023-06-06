// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Options for getting and setting DynamicData properties.
    /// </summary>
    public enum PropertyNameConversion
    {
        /// <summary>
        /// Properties are read from and written to the data content with the same casing as the DynamicData property name.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that property names will be converted to camel-casing format.
        /// See <see cref="System.Text.Json.JsonNamingPolicy.CamelCase"/> for details of the conversion.
        /// </summary>
        CamelCase = 1
    }
}
