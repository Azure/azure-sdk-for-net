// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: restore protected constructor on output-only type.

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class OutboundNetworkDependenciesEndpoint
    {
        /// <summary> Initializes a new instance of <see cref="OutboundNetworkDependenciesEndpoint"/>. </summary>
        protected OutboundNetworkDependenciesEndpoint(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData)
            : base(id, name, resourceType, systemData)
        {
        }
    }
}
