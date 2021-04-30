// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary> Location list operation response. </summary>
    internal partial class LocationListResult
    {
        /// <summary> Initializes a new instance of LocationListResult. </summary>
        internal LocationListResult()
        {
            Value = new ChangeTrackingList<LocationData>();
        }

        /// <summary> Initializes a new instance of LocationListResult. </summary>
        /// <param name="value"> An array of locations. </param>
        internal LocationListResult(IReadOnlyList<LocationData> value)
        {
            Value = value;
        }

        /// <summary> An array of locations. </summary>
        public IReadOnlyList<LocationData> Value { get; }
    }
}
