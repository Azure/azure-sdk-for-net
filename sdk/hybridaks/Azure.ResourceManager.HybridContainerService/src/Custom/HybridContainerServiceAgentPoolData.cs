// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.HybridContainerService.Models;

namespace Azure.ResourceManager.HybridContainerService
{
    public partial class HybridContainerServiceAgentPoolData
    {
        // The former AutoRest SDK exposed tags for this proxy resource even though the service
        // schema has no tags property. Retain the source-compatible collection without putting it
        // on the wire.
        /// <summary> Resource tags. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, string> Tags { get; } = new ChangeTrackingDictionary<string, string>();
    }
}
