// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public partial class PacketCaptureContent
    {
        // TODO: Remove when https://github.com/Azure/azure-sdk-for-net/pull/62632 is available in the generator.
        /// <summary> Gets the continuous capture compatibility value. </summary>
        public bool? IsContinuousCapture => Properties?.IsContinuousCapture;
    }
}
