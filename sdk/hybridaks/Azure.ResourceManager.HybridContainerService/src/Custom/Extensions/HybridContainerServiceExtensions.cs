// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService
{
    // The TypeSpec generator adds raw-scope helpers that duplicate the GA resource hierarchy accessors.
    [CodeGenSuppress("GetHybridContainerServiceAgentPool")]
    [CodeGenSuppress("GetHybridContainerServiceAgentPoolAsync")]
    [CodeGenSuppress("GetHybridContainerServiceAgentPools")]
    [CodeGenSuppress("GetHybridIdentityMetadata")]
    [CodeGenSuppress("GetProvisionedClusterUpgradeProfile")]
    public static partial class HybridContainerServiceExtensions
    {
    }
}
