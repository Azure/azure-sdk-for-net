// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden BurstFloorIops alias for renamed BurstFloorIOPS property.
// Could use @@clientName in spec but would lose the improved name.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BurstingConstants
    {
        /// <summary> Backward-compatible alias for BurstFloorIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("burstFloorIOPS")]
        public int? BurstFloorIops => BurstFloorIOPS;
    }
}
