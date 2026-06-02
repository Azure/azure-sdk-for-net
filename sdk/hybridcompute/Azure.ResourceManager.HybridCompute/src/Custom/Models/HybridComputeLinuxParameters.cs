// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;

namespace Azure.ResourceManager.HybridCompute.Models
{
    [SuppressMessage("Azure.ClientSdk.Analyzers", "AZC0030", Justification = "Backward-compat justification: the migrated SDK preserves the AutoRest GA-compatible Linux patch parameter type name.")]
    public partial class HybridComputeLinuxParameters
    {
    }
}