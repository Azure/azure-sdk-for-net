// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Options for getting and setting properties of data content.
    /// </summary>
    public enum NameConverter
    {
        /// <summary>
        /// Properties are read from and written to the data content with the same casing as the property name used in C#.
        /// </summary>
        None = 0,

        /// <summary>
        /// Convert property names to "camelCase".
        /// For example, when used with DynamicData, a "PascalCase" DynamicData property name can be used to get "camelCase" members in the data content.
        /// Values assigned to DynamicData properties are written to the data content with a "camelCase" name mapping
        /// applied to the property name.  This mapping is not applied when using indexer syntax.
        /// </summary>
        CamelCase = 1
    }
}
