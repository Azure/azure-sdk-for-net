// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class AzureFirewallPacketCaptureFlags
    {
        // Generation restores the 1.15 FlagsType name; retain the 1.16.1/1.17 rename
        // as a deprecated alias so assignments and serialization share canonical storage.
        /// <summary> The flags to capture. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `FlagsType` instead", false)]
        public AzureFirewallPacketCaptureFlagsType? Type
        {
            get => FlagsType;
            set => FlagsType = value;
        }
    }
}
