// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

/// <summary> The traffic type that the detection rule is applied to. </summary>
// The C# clientName customization renames this TypeSpec enum to
// DdosCustomPolicyProtocol, but the provisioning library released it as
// DdosTrafficType and uses that type in public property signatures.
// DdosCustomPolicyProtocol is also an existing released enum with different
// values, so the generated rename cannot replace it.
[CodeGenType("DdosCustomPolicyProtocol")]
public enum DdosTrafficType
{
    /// <summary> Tcp. </summary>
    Tcp = 0,

    /// <summary> Udp. </summary>
    Udp = 1,

    /// <summary> TcpSyn. </summary>
    TcpSyn = 2,
}
