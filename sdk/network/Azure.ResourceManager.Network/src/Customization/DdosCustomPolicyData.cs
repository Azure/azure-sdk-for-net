// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the DdosCustomPolicy data model.
    /// A DDoS custom policy in a resource group.
    /// </summary>
    public partial class DdosCustomPolicyData : NetworkTrackedResourceData
    {
        /// <summary> The list of public IPs associated with the DDoS custom policy resource. This list is read-only. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<WritableSubResource> PublicIPAddresses { get => new ChangeTrackingList<WritableSubResource>(); }
        /// <summary> The protocol-specific DDoS policy customization parameters. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ProtocolCustomSettings> ProtocolCustomSettings { get => new ChangeTrackingList<ProtocolCustomSettings>(); }
    }
}
