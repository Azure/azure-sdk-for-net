// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// [CodeGenType] is required because @@clientName only renames the EventData model;
// it does not rename the generated resource class, so this preserves the GA 1.0.0 name ResourceHealthEventResource.
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    [CodeGenType("EventResource")]
    public partial class ResourceHealthEventResource
    {
    }
}
