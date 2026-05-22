// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: gallery patch models previously inherited ResourceData through their update base type.
    // Without this base type, ApiCompat reports removed ResourceData inheritance for all derived gallery patch models.
    public partial class UpdateResourceDefinition : ResourceData
    {
    }
}
