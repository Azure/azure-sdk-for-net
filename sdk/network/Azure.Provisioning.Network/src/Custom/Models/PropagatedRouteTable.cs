// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class PropagatedRouteTable
{
    private BicepList<WritableSubResource> _ids;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the route table references. </summary>
    [CodeGenMember("Ids")]
    public BicepList<WritableSubResource> Ids
    {
        get
        {
            Initialize();
            return _ids;
        }
        set
        {
            Initialize();
            _ids.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _ids = DefineListProperty<WritableSubResource>(nameof(Ids), new string[] { "ids" });
    }
}
