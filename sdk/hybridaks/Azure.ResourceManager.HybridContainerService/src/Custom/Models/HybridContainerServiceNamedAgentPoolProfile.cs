// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.HybridContainerService.Models
{
    // TypeSpec models the named profile with spreads, while the previous SDK exposed this
    // inheritance relationship. The partial base declaration restores only that type contract.
    public partial class HybridContainerServiceNamedAgentPoolProfile : HybridContainerServiceAgentPoolProfile
    {
    }
}
