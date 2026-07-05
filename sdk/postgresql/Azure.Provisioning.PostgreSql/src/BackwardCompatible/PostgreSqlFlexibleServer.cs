// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

public partial class PostgreSqlFlexibleServer : ProvisionableResource
{
    /// <summary>
    /// List of private endpoint connections associated with the specified
    /// server.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="PostgreSqlFlexibleServer.PrivateEndpointConnectionResources"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepList<PostgreSqlFlexibleServersPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get { Initialize(); return _privateEndpointConnections!; }
    }
    private BicepList<PostgreSqlFlexibleServersPrivateEndpointConnectionData>? _privateEndpointConnections;

    private partial void DefineAdditionalProperties()
    {
        _privateEndpointConnections = DefineListProperty<PostgreSqlFlexibleServersPrivateEndpointConnectionData>("PrivateEndpointConnections", ["properties", "privateEndpointConnections"], isOutput: true);
    }
}
