// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class CloudServiceSwapData
    {
        // Restores the released CloudServiceSwapSlotType API as an alias of the canonical generated SwapResourceSlotType property.
        /// <summary> Specifies slot info on a cloud service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsoleted and will be removed in a future version. Please use SwapResourceSlotType instead.")]
        public SwapSlotType? CloudServiceSwapSlotType
        {
            get => SwapResourceSlotType;
            set => SwapResourceSlotType = value;
        }
    }
}
