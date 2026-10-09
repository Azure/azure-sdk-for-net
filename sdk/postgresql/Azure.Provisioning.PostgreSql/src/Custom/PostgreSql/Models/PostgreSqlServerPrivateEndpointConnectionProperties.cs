// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// Properties of a private endpoint connection.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use the PostgreSqlFlexibleServer.PrivateEndpointConnectionResources property instead.")]
public partial class PostgreSqlServerPrivateEndpointConnectionProperties : ProvisionableConstruct
{
    /// <summary>
    /// Gets or sets Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> PrivateEndpointId
    {
        get { Initialize(); return _privateEndpointId!; }
    }
    private BicepValue<ResourceIdentifier> _privateEndpointId;

    /// <summary>
    /// Connection state of the private endpoint connection.
    /// </summary>
    public PostgreSqlServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState
    {
        get { Initialize(); return _privateLinkServiceConnectionState!; }
    }
    private PostgreSqlServerPrivateLinkServiceConnectionStateProperty _privateLinkServiceConnectionState;

    /// <summary>
    /// State of the private endpoint connection.
    /// </summary>
    public BicepValue<PostgreSqlPrivateEndpointProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<PostgreSqlPrivateEndpointProvisioningState> _provisioningState;

    /// <summary>
    /// Creates a new PostgreSqlServerPrivateEndpointConnectionProperties.
    /// </summary>
    public PostgreSqlServerPrivateEndpointConnectionProperties()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PostgreSqlServerPrivateEndpointConnectionProperties.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _privateEndpointId = DefineProperty<ResourceIdentifier>("PrivateEndpointId", ["privateEndpoint", "id"], isOutput: true);
        _privateLinkServiceConnectionState = DefineModelProperty<PostgreSqlServerPrivateLinkServiceConnectionStateProperty>("PrivateLinkServiceConnectionState", ["privateLinkServiceConnectionState"], isOutput: true);
        _provisioningState = DefineProperty<PostgreSqlPrivateEndpointProvisioningState>("ProvisioningState", ["provisioningState"], isOutput: true);
    }
}
