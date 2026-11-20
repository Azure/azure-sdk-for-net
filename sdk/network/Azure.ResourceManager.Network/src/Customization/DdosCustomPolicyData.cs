// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class DdosCustomPolicyData
    {
        // Retain the obsolete 1.15 compatibility API; current TypeSpec has no protocolCustomSettings field.
        // Keep the persistent per-instance list shipped in 1.16.1/1.17 without adding wire serialization.
        /// <summary> The protocol-specific DDoS policy customization parameters. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        public IList<ProtocolCustomSettings> ProtocolCustomSettings { get; } = new List<ProtocolCustomSettings>();
    }
}
