// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.SignalR;

// The TypeSpec generator now emits SignalRPrivateEndpointConnection as a child resource.
// Preserve the previously shipped data model for source and binary compatibility.
/// <summary> The data model for a SignalR private endpoint connection. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This class is deprecated and it will be removed in a future version. Please use SignalRPrivateEndpointConnection instead.")]
public partial class SignalRPrivateEndpointConnectionData : ProvisionableConstruct
{
    private BicepValue<SignalRProvisioningState> _provisioningState;
    private BicepValue<ResourceIdentifier> _privateEndpointId;
    private BicepList<string> _groupIds;
    private SignalRPrivateLinkServiceConnectionState _connectionState;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private SystemData _systemData;

    /// <summary> Gets the resource provisioning state. </summary>
    public BicepValue<SignalRProvisioningState> ProvisioningState { get { Initialize(); return _provisioningState; } }

    /// <summary> Gets or sets the private endpoint resource identifier. </summary>
    public BicepValue<ResourceIdentifier> PrivateEndpointId { get { Initialize(); return _privateEndpointId; } set { Initialize(); _privateEndpointId.Assign(value); } }

    /// <summary> Gets the private endpoint group identifiers. </summary>
    public BicepList<string> GroupIds { get { Initialize(); return _groupIds; } }

    /// <summary> Gets or sets the private endpoint connection state. </summary>
    public SignalRPrivateLinkServiceConnectionState ConnectionState { get { Initialize(); return _connectionState; } set { Initialize(); AssignOrReplace(ref _connectionState, value); } }

    /// <summary> Gets the resource identifier. </summary>
    public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }

    /// <summary> Gets the resource name. </summary>
    public BicepValue<string> Name { get { Initialize(); return _name; } }

    /// <summary> Gets resource system metadata. </summary>
    public SystemData SystemData { get { Initialize(); return _systemData; } }

    /// <summary> Creates a new instance of <see cref="SignalRPrivateEndpointConnectionData"/>. </summary>
    public SignalRPrivateEndpointConnectionData()
    {
    }

    /// <inheritdoc/>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _provisioningState = DefineProperty<SignalRProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
        _privateEndpointId = DefineProperty<ResourceIdentifier>(nameof(PrivateEndpointId), new string[] { "properties", "privateEndpoint", "id" });
        _groupIds = DefineListProperty<string>(nameof(GroupIds), new string[] { "properties", "groupIds" }, isOutput: true);
        _connectionState = DefineModelProperty<SignalRPrivateLinkServiceConnectionState>(nameof(ConnectionState), new string[] { "properties", "privateLinkServiceConnectionState" });
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
    }
}
