// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // CUSTOM: Preserve the GA enum backing values. The generator emits contiguous
    // values starting at 0, but this enum was previously shipped with values 1-3.
    /// <summary> Describes the severity of signature: 1 - High, 2 - Medium, 3 - Low. </summary>
    [CodeGenType("FirewallPolicyIDPSSignatureSeverity")]
    public enum FirewallPolicyIDPSSignatureSeverity
    {
        /// <summary> 1. </summary>
        _1 = 1,
        /// <summary> 2. </summary>
        _2 = 2,
        /// <summary> 3. </summary>
        _3 = 3
    }
}
