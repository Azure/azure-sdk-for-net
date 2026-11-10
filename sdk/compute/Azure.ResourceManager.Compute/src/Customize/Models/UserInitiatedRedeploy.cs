// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Compute.Models
{
    public partial class UserInitiatedRedeploy
    {
        // Independent non-wire state prevents safe flattening, preserving the shipped public wrapper API.
        internal bool SafeFlattenCompatibility { get; set; }
    }
}