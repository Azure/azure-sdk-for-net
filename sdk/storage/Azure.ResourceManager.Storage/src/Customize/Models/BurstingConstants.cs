// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BurstingConstants
    {
        /// <summary> Backward-compatible alias for BurstFloorIOPS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? BurstFloorIops => BurstFloorIOPS;
    }
}
