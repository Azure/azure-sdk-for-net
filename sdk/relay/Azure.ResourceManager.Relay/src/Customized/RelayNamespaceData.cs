// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Relay.Models;
namespace Azure.ResourceManager.Relay
{
    /// <summary> A class representing the RelayNamespace data model. </summary>
    public partial class RelayNamespaceData : TrackedResourceData
    {
        /// <summary> This determines if traffic is allowed over public network. By default it is enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RelayPublicNetworkAccess? PublicNetworkAccess { get; set; }
    }
}
