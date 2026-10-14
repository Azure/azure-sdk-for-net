// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class VirtualNetworkPropertiesFormat
{
    private BicepList<WritableSubResource> _ipAllocations;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the IP allocation references. </summary>
    [CodeGenMember("IPAllocations")]
    public BicepList<WritableSubResource> IPAllocations
    {
        get
        {
            Initialize();
            return _ipAllocations;
        }
        set
        {
            Initialize();
            _ipAllocations.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _ipAllocations = DefineListProperty<WritableSubResource>(nameof(IPAllocations), new string[] { "ipAllocations" });
    }
}
