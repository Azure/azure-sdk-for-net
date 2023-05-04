// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Options for mapping DynamicData property names to names of members in the wrapped data buffer.
    /// </summary>
    public enum DynamicDataNameMapping
    {
        /// <summary>
        /// Properties are accessed and written in the data buffer with the same casing as the DynamicData property.
        /// </summary>
        None = 0,

        /// <summary>
        /// A "PascalCase" DynamicData property can be used to get and set "camelCase" members in the data buffer.
        /// New value member names are written to the data buffer with the same casing as the DynamicData property.
        /// </summary>
        PascalCaseDynamic = 1,

        /// <summary>
        /// Default settings for Azure services.
        /// A "PascalCase" DynamicData property can be used to get and set "camelCase" members in the data buffer.
        /// New value member names are written to the data buffer using "camelCase" property names.
        /// </summary>
        PascalCaseDynamicCamelCaseData = 2
    }
}
