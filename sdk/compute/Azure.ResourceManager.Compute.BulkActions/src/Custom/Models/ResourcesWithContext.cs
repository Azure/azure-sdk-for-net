// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    public partial class ResourcesWithContext
    {
        // Keep this wrapper distinct from UserRequestResources to avoid duplicate Resources members on request models.
        // Independent non-wire state prevents safe flattening without changing the shipped public API.
        internal bool SafeFlattenCompatibility { get; set; }
    }
}