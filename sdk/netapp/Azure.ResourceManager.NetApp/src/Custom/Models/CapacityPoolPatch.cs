// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class CapacityPoolPatch
    {
        // Backward compatibility: v1.15.0 exposed this required-location ctor. The TypeSpec model
        // declares `location?: string` (optional), so the generator no longer emits a public ctor.
        // Chain to base(location) so Tags is initialized by TrackedResourceData; otherwise Tags
        // stays null and serialization throws.
        /// <summary> Initializes a new instance of <see cref="CapacityPoolPatch"/>. </summary>
        /// <param name="location"> The location. </param>
        public CapacityPoolPatch(AzureLocation location) : base(location) { }

        public float? CustomThroughputMibps
        {
            get => CustomThroughputMibpsInt;
            set => CustomThroughputMibpsInt = value.HasValue ? (int?)value.Value : null;
        }
    }
}
