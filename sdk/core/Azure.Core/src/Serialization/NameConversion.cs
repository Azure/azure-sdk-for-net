// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Dynamic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// The member name converter to use when converting property names in data content.
    /// </summary>
    public enum NameConversion
    {
        /// <summary>
        /// Properties are read from and written to the data content with the same casing as the property name used in C#.
        /// </summary>
        None = 0,

        /// <summary>
        /// Convert property names used in C# to "camelCase" when reading from and writing to the data content.
        ///
        /// For example, when used with <see cref="DynamicData"/>, a "PascalCase" DynamicData property name can be used to get "camelCase" members in the data content.
        /// Values assigned to DynamicData properties are written to the data content with a "camelCase" name mapping
        /// applied to the property name.  This mapping is not applied when using DynamicData's indexer syntax.
        /// </summary>
        CamelCase = 1
    }
}
