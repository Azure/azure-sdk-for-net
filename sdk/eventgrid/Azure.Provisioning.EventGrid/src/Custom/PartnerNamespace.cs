// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class PartnerNamespace
{
    // The shared TypeSpec parent union currently generates this collection with the
    // EventGridDomainPrivateEndpointConnection resource type. Keep that generated shape under a distinct name.
    /// <summary> Gets the private endpoint connection resources. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridDomainPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            if (Properties is null)
            {
                Properties = new PartnerNamespaceProperties();
            }
            return Properties.PrivateEndpointConnections;
        }
    }

    /// <summary>
    /// Gets the private endpoint connection data models.
    /// This compatibility property preserves the previous generated model shape.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
#pragma warning disable CS0618 // EventGridPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections =>
#pragma warning restore CS0618
        Properties is null ? default : Properties.PrivateEndpointConnectionData;

    public static partial class ResourceVersions
    {
        /// <summary> API version "2025-02-15". </summary>
        public static readonly string V2025_02_15 = "2025-02-15";
        /// <summary> API version "2022-06-15". </summary>
        public static readonly string V2022_06_15 = "2022-06-15";
    }
}
