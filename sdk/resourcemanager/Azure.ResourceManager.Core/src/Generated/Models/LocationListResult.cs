﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary> Location list operation response. </summary>
    internal partial class LocationListResult
    {
        /// <summary> Initializes a new instance of LocationListResult. </summary>
        internal LocationListResult()
        {
            Value = new ChangeTrackingList<LocationExpanded>();
        }

        /// <summary> Initializes a new instance of LocationListResult. </summary>
        /// <param name="value"> An array of locations. </param>
        internal LocationListResult(IReadOnlyList<LocationExpanded> value)
        {
            Value = value;
        }

        /// <summary> An array of locations. </summary>
        public IReadOnlyList<LocationExpanded> Value { get; }
    }
}
