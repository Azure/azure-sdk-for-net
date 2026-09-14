// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class EventGridNamespace
{
    // The C# parent-type customization excludes namespaces, so the generated collection uses the
    // shared EventGridDomainPrivateEndpointConnection resource type. Preserve that generated shape.
    /// <summary> Gets or sets the private endpoint connection resources. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridDomainPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            if (Properties is null)
            {
                Properties = new NamespaceProperties();
            }
            return Properties.PrivateEndpointConnections;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new NamespaceProperties();
            }
            Properties.PrivateEndpointConnections = value;
        }
    }

    /// <summary>
    /// Gets or sets the private endpoint connection data models.
    /// This compatibility property preserves the previous generated model shape.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
#pragma warning disable CS0618 // EventGridPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
#pragma warning restore CS0618
    {
        get
        {
            if (Properties is null)
            {
                Properties = new NamespaceProperties();
            }
            return Properties.PrivateEndpointConnectionData;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new NamespaceProperties();
            }
            Properties.PrivateEndpointConnectionData = value;
        }
    }

    public static partial class ResourceVersions
    {
        /// <summary> API version "2025-02-15". </summary>
        public static readonly string V2025_02_15 = "2025-02-15";
    }
}
