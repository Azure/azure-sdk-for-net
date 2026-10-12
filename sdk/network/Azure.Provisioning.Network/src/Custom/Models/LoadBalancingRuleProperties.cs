// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class LoadBalancingRuleProperties
{
    private BicepList<WritableSubResource> _backendAddressPools;

    // Preserve the 1.1.0 API only; additional-properties support is tracked by https://github.com/Azure/azure-sdk-for-net/issues/60666.
    /// <summary> Gets or sets additional properties. </summary>
    /// <remarks> This property is retained for compatibility only. Its values are not emitted to Bicep. </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepDictionary<BinaryData> AdditionalProperties { get; set; } = new();

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the backend address pool references. </summary>
    [CodeGenMember("BackendAddressPools")]
    public BicepList<WritableSubResource> BackendAddressPools
    {
        get
        {
            Initialize();
            return _backendAddressPools;
        }
        set
        {
            Initialize();
            _backendAddressPools.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _backendAddressPools = DefineListProperty<WritableSubResource>(nameof(BackendAddressPools), new string[] { "backendAddressPools" });
    }
}
