// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class AvailabilitySetData
    {
        // Preserve the non-virtual flattened properties shipped in Compute 1.18.0 while
        // keeping the underlying ComputeWriteableSubResourceData.Id virtual for GA compatibility.
        // Remove these forwarding compatibility members when the next major version permits it.
        /// <summary> Resource Id. </summary>
        public ResourceIdentifier ProximityPlacementGroupId
        {
            get
            {
                return Properties is null ? default : Properties.ProximityPlacementGroupId;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new AvailabilitySetProperties();
                }
                Properties.ProximityPlacementGroupId = value;
            }
        }
    }
}
