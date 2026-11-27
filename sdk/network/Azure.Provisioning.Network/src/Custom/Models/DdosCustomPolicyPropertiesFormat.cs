// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

internal partial class DdosCustomPolicyPropertiesFormat
{
    private BicepList<WritableSubResource> _frontEndIPConfiguration;

    // Preserve the WritableSubResource collection shipped in 1.1.0 instead of the generated NetworkSubResource collection.
    /// <summary> Gets or sets the frontend IP configuration references. </summary>
    [CodeGenMember("FrontEndIPConfiguration")]
    public BicepList<WritableSubResource> FrontEndIPConfiguration
    {
        get
        {
            Initialize();
            return _frontEndIPConfiguration;
        }
        set
        {
            Initialize();
            _frontEndIPConfiguration.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _frontEndIPConfiguration = DefineListProperty<WritableSubResource>(nameof(FrontEndIPConfiguration), new string[] { "frontEndIpConfiguration" });
    }
}
