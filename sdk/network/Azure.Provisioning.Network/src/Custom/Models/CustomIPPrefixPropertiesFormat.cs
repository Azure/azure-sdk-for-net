// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class CustomIPPrefixPropertiesFormat
{
    private BicepList<WritableSubResource> _publicIPPrefixes;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets the public IP prefix references. </summary>
    [CodeGenMember("PublicIPPrefixes")]
    public BicepList<WritableSubResource> PublicIPPrefixes
    {
        get
        {
            Initialize();
            return _publicIPPrefixes;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _publicIPPrefixes = DefineListProperty<WritableSubResource>(nameof(PublicIPPrefixes), new string[] { "publicIpPrefixes" }, isOutput: true);
    }
}
