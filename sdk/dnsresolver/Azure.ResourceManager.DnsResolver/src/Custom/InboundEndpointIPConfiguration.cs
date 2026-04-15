// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.DnsResolver.Models
{
    // Backward-compatibility shim for the pre-migration WritableSubResource constructor.
    public partial class InboundEndpointIPConfiguration
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InboundEndpointIPConfiguration(WritableSubResource subnet) : this(subnet?.Id)
        {
        }
    }
}

#pragma warning restore CS1591
