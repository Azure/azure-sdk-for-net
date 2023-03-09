// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Options for setting new DynamicJson properties.
    /// </summary>
    public enum DynamicDataNameMapping
    {
        /// <summary>
        /// Properties are accessed and written in the JSON buffer with the same casing as the DynamicJson property.
        /// </summary>
        None = 0,

        /// <summary>
        /// A "PascalCase" DynamicJson property can be used to read and set "camelCase" properties that exist in the JSON buffer.
        /// New properties are written to the JSON buffer with the same casing as the DynamicJson property.
        /// </summary>
        PascalCaseGetters = 1,

        /// <summary>
        /// Default settings for Azure services.
        /// A "PascalCase" DynamicJson property can be used to read and set "camelCase" properties that exist in the JSON buffer.
        /// New properties are written to the JSON buffer using "camelCase" property names.
        /// </summary>
        PascalCaseGettersCamelCaseSetters = 2
    }
}
