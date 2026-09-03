// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class EventGridNamespace
{
    /// <summary> Gets or sets the private endpoint connections. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get => Properties is null ? default : Properties.PrivateEndpointConnections;
        set
        {
            if (Properties is null)
            {
                Properties = new NamespaceProperties();
            }
            Properties.PrivateEndpointConnections = value;
        }
    }

    public static partial class ResourceVersions
    {
        /// <summary> API version "2025-02-15". </summary>
        public static readonly string V2025_02_15 = "2025-02-15";
    }
}
