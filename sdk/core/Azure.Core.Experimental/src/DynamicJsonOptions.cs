// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Provides the ability for the user to define custom behavior when accessing JSON through a dynamic layer.
    /// </summary>
    public struct DynamicJsonOptions
    {
        /// <summary>
        /// Creates a new instance of DynamicJsonOptions.
        /// </summary>
        public DynamicJsonOptions() { }

        /// <summary>
        /// Specifies how properties on <see cref="DynamicJson"/> will get accessed in the underlying JSON buffer.
        /// </summary>
        public DynamicJsonPropertyCasing PropertyCasing { get; set; } = DynamicJsonPropertyCasing.Default;
    }

    /// <summary>
    /// Casing options for property access on DynamicJson.
    /// </summary>
    public struct DynamicJsonPropertyCasing
    {
        /// <summary>
        /// Default settings for property access casing in DynamicJson.
        /// </summary>
        public static readonly DynamicJsonPropertyCasing Default = new()
        {
            ExistingPropertyAccess = ExistingPropertyCasing.AllowPascalCase,
            NewPropertyAccess = NewPropertyCasing.WriteCamelCase
        };

        /// <summary>
        /// How DynamicJson property accessors will map to properties in the JSON buffer.
        /// </summary>
        public ExistingPropertyCasing ExistingPropertyAccess { get; set; }

        /// <summary>
        /// How DynamicJson property accessors will create new properties in the JSON buffer.
        /// </summary>
        public NewPropertyCasing NewPropertyAccess { get; set; }
    }

    /// <summary>
    /// Options for setting new DyanmicJson properties.
    /// </summary>
    public enum NewPropertyCasing
    {
        /// <summary>
        /// New properties are written with the same casing as the DynamicJson property.
        /// </summary>
        CaseSensitive = 0,

        /// <summary>
        /// A "PascalCase" DynamicJson property will be written as a "camelCase" property in the JSON buffer.
        /// "camelCase" DynamicJson properties will be written in the JSON buffer unchanged.
        /// </summary>
        WriteCamelCase = 1
    }

    /// <summary>
    /// Options for accessing existing DyanmicJson properties.
    /// </summary>
    public enum ExistingPropertyCasing
    {
        /// <summary>
        /// The DynamicJson property matches the casing in the JSON buffer exactly.
        /// </summary>
        CaseSensitive = 0,

        /// <summary>
        /// A "PascalCase" DynamicJson property can read a "camelCase" property from the JSON buffer.
        /// </summary>
        AllowPascalCase = 1
    }
}
