// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerRegistry
{
    // Suppress the generated ModelFactory method that takes internal WebhookProperties
    // as a parameter (causes CS0051: inconsistent accessibility).
    [CodeGenSuppress("ContainerRegistryWebhookData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(WebhookProperties))]
    public static partial class ArmContainerRegistryModelFactory
    {
    }
}
