// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectivityHopInfo
    {
        // Generation restores the 1.15 ConnectivityHopType name. Preserve the 1.16.1/1.17
        // rename as a deprecated alias so response and factory values remain connected.
        /// <summary> The type of the hop. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `ConnectivityHopType` instead", false)]
        public string Type => ConnectivityHopType;
    }
}
