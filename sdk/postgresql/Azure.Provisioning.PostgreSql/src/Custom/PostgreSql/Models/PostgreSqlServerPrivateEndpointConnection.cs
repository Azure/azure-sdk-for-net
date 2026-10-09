// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

/// <summary>
/// A private endpoint connection under a server.
/// </summary>
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is obsoleted and will be removed in a future version. Please use the PostgreSqlFlexibleServer.PrivateEndpointConnectionResources property instead.")]
public partial class PostgreSqlServerPrivateEndpointConnection : ProvisionableConstruct
{
    /// <summary>
    /// Resource ID of the Private Endpoint Connection.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier> _id;

    /// <summary>
    /// Private endpoint connection properties.
    /// </summary>
    public PostgreSqlServerPrivateEndpointConnectionProperties Properties
    {
        get { Initialize(); return _properties!; }
    }
    private PostgreSqlServerPrivateEndpointConnectionProperties _properties;

    /// <summary>
    /// Creates a new PostgreSqlServerPrivateEndpointConnection.
    /// </summary>
    public PostgreSqlServerPrivateEndpointConnection()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// PostgreSqlServerPrivateEndpointConnection.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _properties = DefineModelProperty<PostgreSqlServerPrivateEndpointConnectionProperties>("Properties", ["properties"], isOutput: true);
    }
}
