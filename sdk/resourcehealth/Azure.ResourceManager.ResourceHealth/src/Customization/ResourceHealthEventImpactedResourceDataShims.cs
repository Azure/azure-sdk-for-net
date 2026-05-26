// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenSuppress("Info")]
    public partial class ResourceHealthEventImpactedResourceData
    {
        /// <summary> Additional information. </summary>
        // This shim is required because the generated property is IList<T>, while GA 1.0.0 exposed IReadOnlyList<T>,
        // and @@alternateType cannot change the collection interface type.
        public IReadOnlyList<ResourceHealthKeyValueItem> Info => Properties?.Info as IReadOnlyList<ResourceHealthKeyValueItem>;
    }
}
