// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Options for getting and setting DynamicData properties.
    /// </summary>
    public enum PropertyNameHandling
    {
        /// <summary>
        /// Properties are read from and written to the data content with the same casing as the DynamicData property name.
        /// </summary>
        Strict = 0,

        /// <summary>
        /// A "PascalCase" DynamicData property name can be used to get "camelCase" members in the data content.
        /// Values assigned to DynamicData properties are written to the data content with a "camelCase" name mapping
        /// applied to the property name.  This mapping is not applied when using indexer syntax.
        /// </summary>
        ToCamelCase = 1
    }
}
