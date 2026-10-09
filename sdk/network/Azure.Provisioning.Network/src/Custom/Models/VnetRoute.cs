// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class VnetRoute
{
    private BicepList<WritableSubResource> _bgpConnections;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets the BGP connection references. </summary>
    [CodeGenMember("BgpConnections")]
    public BicepList<WritableSubResource> BgpConnections
    {
        get
        {
            Initialize();
            return _bgpConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _bgpConnections = DefineListProperty<WritableSubResource>(nameof(BgpConnections), new string[] { "bgpConnections" }, isOutput: true);
    }
}
