// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class VirtualHubProperties
{
    private BicepList<WritableSubResource> _ipConfigurations;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets the IP configuration references. </summary>
    [CodeGenMember("IPConfigurations")]
    public BicepList<WritableSubResource> IPConfigurations
    {
        get
        {
            Initialize();
            return _ipConfigurations;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _ipConfigurations = DefineListProperty<WritableSubResource>(nameof(IPConfigurations), new string[] { "ipConfigurations" }, isOutput: true);
    }
}
