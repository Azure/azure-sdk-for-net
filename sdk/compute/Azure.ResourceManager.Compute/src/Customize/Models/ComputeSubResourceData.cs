// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: VM scale set extension data and patch models previously inherited ResourceData.
    // Without this base type, ApiCompat reports removed ResourceData inheritance for those derived public models.
    public partial class ComputeSubResourceData : ResourceData
    {
    }
}
