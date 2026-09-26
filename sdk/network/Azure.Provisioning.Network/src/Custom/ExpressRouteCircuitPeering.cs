// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class ExpressRouteCircuitPeering
{
    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="ExpressRouteConnection"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpressRouteConnection instead.")]
    public BicepValue<ResourceIdentifier> ExpressRouteConnectionId => ExpressRouteConnection;

    /// <summary> Gets the peer ExpressRoute circuit connection resources. </summary>
    [CodeGenMember("PeeredConnections")]
    public BicepList<PeerExpressRouteCircuitConnection> PeeredConnectionResources
    {
        get
        {
            if (Properties is null)
            {
                Properties = new ExpressRouteCircuitPeeringPropertiesFormat();
            }
            return Properties.PeeredConnections;
        }
    }

    // Preserve the pre-TypeSpec property name because it maps to the same Bicep property as the generated member.
    /// <inheritdoc cref="PeeredConnectionResources"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use PeeredConnectionResources instead.")]
    public BicepList<PeerExpressRouteCircuitConnectionData> PeeredConnections
    {
        get
        {
            if (Properties is null)
            {
                Properties = new ExpressRouteCircuitPeeringPropertiesFormat();
            }
            return Properties.PeeredConnectionData;
        }
    }

    partial void DefineAdditionalProperties()
    {
    }
}
