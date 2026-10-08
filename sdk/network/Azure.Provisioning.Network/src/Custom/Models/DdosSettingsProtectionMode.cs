// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

/// <summary> The DDoS protection mode of the public IP. </summary>
// The C# clientName customization renames this TypeSpec enum to
// DdosSettingsProtectionCoverage, but the provisioning library released it as
// DdosSettingsProtectionMode and uses that type in public property signatures.
// DdosSettingsProtectionCoverage is also an existing released enum with
// different values, so the generated rename cannot replace it.
[CodeGenType("DdosSettingsProtectionCoverage")]
public enum DdosSettingsProtectionMode
{
    /// <summary> VirtualNetworkInherited. </summary>
    VirtualNetworkInherited = 0,

    /// <summary> Enabled. </summary>
    Enabled = 1,

    /// <summary> Disabled. </summary>
    Disabled = 2,
}
