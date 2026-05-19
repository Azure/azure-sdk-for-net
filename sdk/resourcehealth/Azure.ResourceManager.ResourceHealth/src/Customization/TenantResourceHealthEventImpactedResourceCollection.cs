// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// [CodeGenType] is required because @@clientName cannot rename the generated collection class,
// so this preserves the GA 1.0.0 name TenantResourceHealthEventImpactedResourceCollection.
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenType("TenantEventImpactedResourceCollection")]
    public partial class TenantResourceHealthEventImpactedResourceCollection
    {
    }
}
