// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Storage;

// TypeSpec emits StoragePrivateEndpointConnection as a resource but omits this shipped data-model view, which the
// obsolete PrivateEndpointConnections compatibility property still exposes.
/// <summary>
/// A class representing the StoragePrivateEndpointConnection data model.
/// The Private Endpoint Connection resource.
///
/// This type is obsoleted and will be removed in future versions. Please use
/// <see cref="StoragePrivateEndpointConnection"/> instead.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class StoragePrivateEndpointConnectionData : ProvisionableConstruct
{
    // TypeSpec omits this shipped data-model view; retain its PrivateEndpointId output for compatibility.
    /// <summary>
    /// Gets Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> PrivateEndpointId
    {
        get { Initialize(); return _privateEndpointId!; }
    }
    private BicepValue<ResourceIdentifier>? _privateEndpointId;

    // TypeSpec omits this shipped data-model view; retain its ConnectionState property for compatibility.
    /// <summary>
    /// A collection of information about the state of the connection between
    /// service consumer and provider.
    /// </summary>
    public StoragePrivateLinkServiceConnectionState ConnectionState
    {
        get { Initialize(); return _connectionState!; }
        set { Initialize(); AssignOrReplace(ref _connectionState, value); }
    }
    private StoragePrivateLinkServiceConnectionState? _connectionState;

    // TypeSpec omits this shipped data-model view; retain its ProvisioningState output for compatibility.
    /// <summary>
    /// The provisioning state of the private endpoint connection resource.
    /// </summary>
    public BicepValue<StoragePrivateEndpointConnectionProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<StoragePrivateEndpointConnectionProvisioningState>? _provisioningState;

    // TypeSpec omits this shipped data-model view; retain its Id output for compatibility.
    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    // TypeSpec omits this shipped data-model view; retain its Name output for compatibility.
    /// <summary>
    /// Gets the Name.
    /// </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _name!; }
    }
    private BicepValue<string>? _name;

    // TypeSpec omits this shipped data-model view; retain its SystemData output for compatibility.
    /// <summary>
    /// Gets the SystemData.
    /// </summary>
    public SystemData SystemData
    {
        get { Initialize(); return _systemData!; }
    }
    private SystemData? _systemData;

    /// <summary>
    /// Creates a new StoragePrivateEndpointConnectionData.
    /// </summary>
    public StoragePrivateEndpointConnectionData()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// StoragePrivateEndpointConnectionData.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _privateEndpointId = DefineProperty<ResourceIdentifier>("PrivateEndpointId", ["properties", "privateEndpoint", "id"], isOutput: true);
        _connectionState = DefineModelProperty<StoragePrivateLinkServiceConnectionState>("ConnectionState", ["properties", "privateLinkServiceConnectionState"]);
        _provisioningState = DefineProperty<StoragePrivateEndpointConnectionProvisioningState>("ProvisioningState", ["properties", "provisioningState"], isOutput: true);
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _name = DefineProperty<string>("Name", ["name"], isOutput: true);
        _systemData = DefineModelProperty<SystemData>("SystemData", ["systemData"], isOutput: true);
    }
}
