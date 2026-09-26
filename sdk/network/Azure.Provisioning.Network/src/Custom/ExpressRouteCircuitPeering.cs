// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Network;

public partial class ExpressRouteCircuitPeering
{
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

    /// <summary> Gets the peer ExpressRoute circuit connection data models. </summary>
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

internal partial class ExpressRouteCircuitPeeringPropertiesFormat
{
#pragma warning disable CS0618
    private BicepList<PeerExpressRouteCircuitConnectionData> _peeredConnectionData;

    internal BicepList<PeerExpressRouteCircuitConnectionData> PeeredConnectionData
    {
        get { Initialize(); return _peeredConnectionData; }
    }

    partial void DefineAdditionalProperties()
    {
        _peeredConnectionData = DefineListProperty<PeerExpressRouteCircuitConnectionData>("PeeredConnections", new string[] { "peeredConnections" }, isOutput: true);
    }
#pragma warning restore CS0618
}
