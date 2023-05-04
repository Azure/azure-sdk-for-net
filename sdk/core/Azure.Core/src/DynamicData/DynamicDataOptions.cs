// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Dynamic;

namespace Azure
{
    /// <summary>
    /// Provides the ability for the user to define custom behavior when accessing JSON through a dynamic layer.
    /// </summary>
    public class DynamicDataOptions
    {
        /// <summary>
        /// Creates a new DynamicDataOptions.
        /// </summary>
        public DynamicDataOptions() { }

        /// <summary>
        /// Creates a new DynamicDataOptions with a predefined set of options determined by the specified <see cref="DynamicDataDefaults"/>.
        /// </summary>
        public DynamicDataOptions(DynamicDataDefaults defaults)
        {
            if (defaults == DynamicDataDefaults.Azure)
            {
                NameMapping = DynamicDataNameMapping.PascalCaseDynamicCamelCaseData;
            }
            else if (defaults != DynamicDataDefaults.General)
            {
                throw new ArgumentOutOfRangeException(nameof(defaults));
            }
        }

        /// <summary>
        /// Specifies how properties on <see cref="DynamicData"/> will be accessed in the underlying data buffer.
        /// </summary>
        public DynamicDataNameMapping NameMapping { get; set; }
    }
}
