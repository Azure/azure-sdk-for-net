// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

/// <summary> Type of connection monitor. </summary>
// The C# clientName customization renames this TypeSpec enum to
// ConnectionMonitorEndpointType, but the provisioning library released it as
// ConnectionMonitorType and uses that type in public property signatures.
// ConnectionMonitorEndpointType is also an existing released enum with
// different values, so the generated rename cannot replace it.
[CodeGenType("ConnectionMonitorEndpointType")]
public enum ConnectionMonitorType
{
    /// <summary> MultiEndpoint. </summary>
    MultiEndpoint = 0,

    /// <summary> SingleSourceDestination. </summary>
    SingleSourceDestination = 1,
}
