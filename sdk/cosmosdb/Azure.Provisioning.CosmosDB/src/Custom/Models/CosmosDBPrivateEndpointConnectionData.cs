// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CosmosDB;

/// <summary> A private endpoint connection. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("Use CosmosDBPrivateEndpointConnection instead.")]
public partial class CosmosDBPrivateEndpointConnectionData : ProvisionableConstruct
{
    private BicepValue<ResourceIdentifier> _privateEndpointId;
    private CosmosDBPrivateLinkServiceConnectionStateProperty _connectionState;
    private BicepValue<string> _groupId;
    private BicepValue<string> _provisioningState;
    private BicepValue<ResourceIdentifier> _id;
    private BicepValue<string> _name;
    private SystemData _systemData;

    /// <summary> Creates a new CosmosDBPrivateEndpointConnectionData. </summary>
    public CosmosDBPrivateEndpointConnectionData()
    {
    }

    /// <summary> Resource ID of the private endpoint. </summary>
    public BicepValue<ResourceIdentifier> PrivateEndpointId
    {
        get
        {
            Initialize();
            return _privateEndpointId;
        }
        set
        {
            Initialize();
            _privateEndpointId.Assign(value);
        }
    }

    /// <summary> Connection state of the private endpoint connection. </summary>
    public CosmosDBPrivateLinkServiceConnectionStateProperty ConnectionState
    {
        get
        {
            Initialize();
            return _connectionState;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _connectionState, value);
        }
    }

    /// <summary> Group ID of the private endpoint. </summary>
    public BicepValue<string> GroupId
    {
        get
        {
            Initialize();
            return _groupId;
        }
        set
        {
            Initialize();
            _groupId.Assign(value);
        }
    }

    /// <summary> Provisioning state of the private endpoint. </summary>
    public BicepValue<string> ProvisioningState
    {
        get
        {
            Initialize();
            return _provisioningState;
        }
        set
        {
            Initialize();
            _provisioningState.Assign(value);
        }
    }

    /// <summary> Gets the resource identifier. </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get
        {
            Initialize();
            return _id;
        }
    }

    /// <summary> Gets the resource name. </summary>
    public BicepValue<string> Name
    {
        get
        {
            Initialize();
            return _name;
        }
    }

    /// <summary> Gets the resource system metadata. </summary>
    public SystemData SystemData
    {
        get
        {
            Initialize();
            return _systemData;
        }
    }

    /// <inheritdoc />
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _privateEndpointId = DefineProperty<ResourceIdentifier>(nameof(PrivateEndpointId), new string[] { "properties", "privateEndpoint", "id" });
        _connectionState = DefineModelProperty<CosmosDBPrivateLinkServiceConnectionStateProperty>(nameof(ConnectionState), new string[] { "properties", "privateLinkServiceConnectionState" });
        _groupId = DefineProperty<string>(nameof(GroupId), new string[] { "properties", "groupId" });
        _provisioningState = DefineProperty<string>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" });
        _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
    }
}
