// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// [CodeGenType] is required because @@clientName in client.tsp can rename the data model,
// but it cannot rename the generated collection class that GA 1.0.0 shipped as ResourceHealthEventCollection.
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenType("EventCollection")]
    public partial class ResourceHealthEventCollection
    {
    }
}
