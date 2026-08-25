// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Preserve the legacy private endpoint connection property while exposing
// the newly generated resource type under a distinct name.
internal partial class CosmosDBAccountProperties
{
    private BicepList<CosmosDBPrivateEndpointConnection> _privateEndpointConnectionResources;
#pragma warning disable CS0618 // Required to store the obsolete compatibility type.
    private BicepList<CosmosDBPrivateEndpointConnectionData> _privateEndpointConnections;
#pragma warning restore CS0618

    /// <summary> Gets the private endpoint connection resources. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<CosmosDBPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            Initialize();
            return _privateEndpointConnectionResources;
        }
    }

    /// <summary> Gets the private endpoint connections. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use PrivateEndpointConnectionResources instead.")]
    public BicepList<CosmosDBPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _privateEndpointConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _privateEndpointConnectionResources = DefineListProperty<CosmosDBPrivateEndpointConnection>(
            nameof(PrivateEndpointConnectionResources),
            new string[] { "privateEndpointConnections" },
            isOutput: true);

#pragma warning disable CS0618 // Required to initialize the obsolete compatibility type.
        _privateEndpointConnections = new BicepList<CosmosDBPrivateEndpointConnectionData>();
#pragma warning restore CS0618
        ((IBicepValue)_privateEndpointConnections).Expression = _privateEndpointConnectionResources.Compile();
        ((IBicepValue)_privateEndpointConnections).SetReadOnly();
    }
}
