// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    internal partial class VirtualHubProperties
    {
        // Replace the internal element type so the flattened API retains WritableSubResource and reads service data.
        /// <summary> List of references to IpConfigurations. </summary>
        public IReadOnlyList<WritableSubResource> IPConfigurations { get; } = new ChangeTrackingList<WritableSubResource>();
    }
}
