// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PacketCaptureData type. </summary>
    public partial class PacketCaptureData
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Nullable<global::System.Boolean> IsContinuousCapture => default;
    }
}
