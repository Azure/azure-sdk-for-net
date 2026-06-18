// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the CloudServiceSwapData type. </summary>
    public partial class CloudServiceSwapData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::Azure.ResourceManager.Network.Models.SwapSlotType> CloudServiceSwapSlotType
        {
            get => default;
            set { } // Compatibility setter: previous GA surface was settable; generated model treats this service-populated property as read-only.
        }
    }
}
