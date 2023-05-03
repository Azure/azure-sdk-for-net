// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Options for getting and setting DynamicData properties.
    /// </summary>
    public enum DynamicDataNameMapping
    {
        /// <summary>
        /// Properties are accessed and written in the data buffer with the same casing as the DynamicData property.
        /// </summary>
        None = 0,

        /// <summary>
        /// A "PascalCase" DynamicData property can be used to read and set "camelCase" properties that exist in the data buffer.
        /// New properties are written to the data buffer with the same casing as the DynamicData property.
        /// </summary>
        PascalCaseGetters = 1,

        /// <summary>
        /// Default settings for Azure services.
        /// A "PascalCase" DynamicData property can be used to read and set "camelCase" properties that exist in the data buffer.
        /// New properties are written to the data buffer using "camelCase" property names.
        /// </summary>
        PascalCaseGettersCamelCaseSetters = 2
    }
}
