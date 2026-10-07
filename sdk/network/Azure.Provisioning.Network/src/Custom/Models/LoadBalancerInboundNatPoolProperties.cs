// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class LoadBalancerInboundNatPoolProperties
{
    // Preserve the 1.1.0 API only; additional-properties support is tracked by https://github.com/Azure/azure-sdk-for-net/issues/60666.
    /// <summary> Gets or sets additional properties. </summary>
    /// <remarks> This property is retained for compatibility only. Its values are not emitted to Bicep. </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepDictionary<BinaryData> AdditionalProperties { get; set; } = new();
}
