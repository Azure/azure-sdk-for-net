// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService.Mocking
{
    // The TypeSpec generator adds mockable raw-scope helpers that duplicate the GA resource hierarchy accessors.
    /// <summary> A class to add extension methods to <see cref="Azure.ResourceManager.ArmClient"/>. </summary>
    [CodeGenSuppress("GetHybridContainerServiceAgentPool")]
    [CodeGenSuppress("GetHybridContainerServiceAgentPoolAsync")]
    [CodeGenSuppress("GetHybridContainerServiceAgentPools")]
    [CodeGenSuppress("GetHybridIdentityMetadata")]
    [CodeGenSuppress("GetProvisionedClusterUpgradeProfile")]
    public partial class MockableHybridContainerServiceArmClient
    {
    }
}
