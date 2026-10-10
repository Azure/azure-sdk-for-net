// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

/// <summary> The legacy data model for a peer ExpressRoute circuit connection. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is deprecated and it will be removed in a future version. Please use PeerExpressRouteCircuitConnection instead.")]
public partial class PeerExpressRouteCircuitConnectionData : ProvisionableConstruct
{
    private BicepValue<ETag> _eTag;
    private BicepValue<ResourceIdentifier> _expressRouteCircuitPeeringId;
    private BicepValue<ResourceIdentifier> _peerExpressRouteCircuitPeeringId;
    private BicepValue<string> _addressPrefix;
    private BicepValue<CircuitConnectionStatus> _circuitConnectionStatus;
    private BicepValue<string> _connectionName;
    private BicepValue<Guid> _authResourceGuid;
    private BicepValue<NetworkProvisioningState> _provisioningState;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private BicepValue<ResourceType> _resourceType;

    /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
    public BicepValue<ETag> ETag { get { Initialize(); return _eTag; } }

    /// <summary> Gets or sets the ExpressRoute circuit peering resource ID. </summary>
    public BicepValue<ResourceIdentifier> ExpressRouteCircuitPeeringId
    {
        get { Initialize(); return _expressRouteCircuitPeeringId; }
        set { Initialize(); _expressRouteCircuitPeeringId.Assign(value); }
    }

    /// <summary> Gets or sets the peer ExpressRoute circuit peering resource ID. </summary>
    public BicepValue<ResourceIdentifier> PeerExpressRouteCircuitPeeringId
    {
        get { Initialize(); return _peerExpressRouteCircuitPeeringId; }
        set { Initialize(); _peerExpressRouteCircuitPeeringId.Assign(value); }
    }

    /// <summary> The address prefix used for tunnels. </summary>
    public BicepValue<string> AddressPrefix
    {
        get { Initialize(); return _addressPrefix; }
        set { Initialize(); _addressPrefix.Assign(value); }
    }

    /// <summary> ExpressRoute circuit connection state. </summary>
    public BicepValue<CircuitConnectionStatus> CircuitConnectionStatus { get { Initialize(); return _circuitConnectionStatus; } }

    /// <summary> The ExpressRoute circuit connection resource name. </summary>
    public BicepValue<string> ConnectionName
    {
        get { Initialize(); return _connectionName; }
        set { Initialize(); _connectionName.Assign(value); }
    }

    /// <summary> The resource GUID of the authorization used for the connection. </summary>
    public BicepValue<Guid> AuthResourceGuid
    {
        get { Initialize(); return _authResourceGuid; }
        set { Initialize(); _authResourceGuid.Assign(value); }
    }

    /// <summary> The provisioning state of the peer ExpressRoute circuit connection. </summary>
    public BicepValue<NetworkProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }

    /// <summary> Resource ID. </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id; }
        set { Initialize(); _id.Assign(value); }
    }

    /// <summary> Resource name. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name; }
        set { Initialize(); _name.Assign(value); }
    }

    /// <summary> Resource type. </summary>
    public BicepValue<ResourceType> ResourceType { get { Initialize(); return _resourceType; } }

    /// <summary> Creates a new PeerExpressRouteCircuitConnectionData. </summary>
    public PeerExpressRouteCircuitConnectionData()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
        _expressRouteCircuitPeeringId = DefineProperty<ResourceIdentifier>(nameof(ExpressRouteCircuitPeeringId), new string[] { "properties", "expressRouteCircuitPeering", "id" });
        _peerExpressRouteCircuitPeeringId = DefineProperty<ResourceIdentifier>(nameof(PeerExpressRouteCircuitPeeringId), new string[] { "properties", "peerExpressRouteCircuitPeering", "id" });
        _addressPrefix = DefineProperty<string>(nameof(AddressPrefix), new string[] { "properties", "addressPrefix" });
        _circuitConnectionStatus = DefineProperty<CircuitConnectionStatus>(nameof(CircuitConnectionStatus), new string[] { "properties", "circuitConnectionStatus" }, isOutput: true);
        _connectionName = DefineProperty<string>(nameof(ConnectionName), new string[] { "properties", "connectionName" });
        _authResourceGuid = DefineProperty<Guid>(nameof(AuthResourceGuid), new string[] { "properties", "authResourceGuid" });
        _provisioningState = DefineProperty<NetworkProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" });
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" });
        _resourceType = DefineProperty<ResourceType>(nameof(ResourceType), new string[] { "type" }, isOutput: true);
    }
}
