// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// Provides the ability for the user to define custom behavior when accessing JSON through a dynamic layer.
    /// </summary>
    public struct DynamicJsonOptions
    {
        /// <summary>
        /// Gets the default <see cref="DynamicJsonOptions"/> for Azure services.
        /// </summary>
        public static readonly DynamicJsonOptions AzureDefault = new()
        {
            PropertyNameCasing = DynamicDataNameMapping.PascalCaseGettersCamelCaseSetters
        };

        /// <summary>
        /// Creates a new instance of DynamicDataOptions.
        /// </summary>
        public DynamicJsonOptions() { }

        /// <summary>
        /// Specifies how properties on <see cref="DynamicData"/> will be accessed in the underlying data buffer.
        /// </summary>
        public DynamicDataNameMapping PropertyNameCasing { get; set; }
    }
}
