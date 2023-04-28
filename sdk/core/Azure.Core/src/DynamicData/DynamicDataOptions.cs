// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure
{
    /// <summary>
    /// Provides the ability for the user to define custom behavior when accessing JSON through a dynamic layer.
    /// </summary>
    public struct DynamicDataOptions
    {
        /// <summary>
        /// Gets the default <see cref="DynamicDataOptions"/> for Azure services.
        /// </summary>
        public static readonly DynamicDataOptions Default = new()
        {
            NameMapping = DynamicDataNameMapping.PascalCaseGettersCamelCaseSetters
        };

        /// <summary>
        /// Creates a new instance of DynamicDataOptions.
        /// </summary>
        public DynamicDataOptions() { }

        /// <summary>
        /// Specifies how properties on <see cref="DynamicData"/> will be accessed in the underlying data buffer.
        /// </summary>
        public DynamicDataNameMapping NameMapping { get; set; }
    }
}
