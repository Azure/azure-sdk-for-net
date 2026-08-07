// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.HybridContainerService.Models
{
    // TypeSpec spreads AgentPoolProfile into this model, while the GA SDK exposed it as the base type.
    public partial class HybridContainerServiceNamedAgentPoolProfile : HybridContainerServiceAgentPoolProfile
    {
    }
}
