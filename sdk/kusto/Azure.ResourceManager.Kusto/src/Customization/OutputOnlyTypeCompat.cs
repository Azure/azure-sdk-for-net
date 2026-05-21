// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: the old GA SDK had protected constructors on this
// output-only type. The TypeSpec generator marks it effectively sealed.

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoPrivateLinkResourceData
    {
        /// <summary> Initializes a new instance of <see cref="KustoPrivateLinkResourceData"/>. </summary>
        protected KustoPrivateLinkResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData)
            : base(id, name, resourceType, systemData)
        {
        }
    }
}
