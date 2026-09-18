// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class CloudServiceSwapData
    {
        /// <summary> Specifies slot info on a cloud service. </summary>
        public SwapSlotType? CloudServiceSwapSlotType
        {
            get => SwapResourceSlotType;
            set => SwapResourceSlotType = value;
        }
    }
}
