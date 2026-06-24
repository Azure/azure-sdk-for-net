// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    // GA exposed Info as IReadOnlyList<T> while the generated flattened property is IList<T>, and no
    // client.tsp decorator can change the collection interface. Re-expose it as IReadOnlyList<T> to preserve
    // the GA surface; the generator omits its IList<T> version because this custom member defines the name.
    public partial class ResourceHealthEventImpactedResourceData
    {
        /// <summary> Additional information. </summary>
        public IReadOnlyList<ResourceHealthKeyValueItem> Info => Properties?.Info as IReadOnlyList<ResourceHealthKeyValueItem>;
    }
}
