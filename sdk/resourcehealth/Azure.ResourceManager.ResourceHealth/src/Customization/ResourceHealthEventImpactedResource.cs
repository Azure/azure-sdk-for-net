// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// [CodeGenType] is required because @@clientName can rename the impacted resource data model,
// but it cannot rename the generated resource class that GA 1.0.0 shipped as ResourceHealthEventImpactedResource.
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenType("ImpactedResource")]
    public partial class ResourceHealthEventImpactedResource
    {
    }
}
