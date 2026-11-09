// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Network;

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
