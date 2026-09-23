// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.PostgreSql;

public partial class PostgreSqlFlexibleServer : ProvisionableResource
{
    public static partial class ResourceVersions
    {
        /// <summary> API version "2024-08-01". </summary>
        public static readonly string V2024_08_01 = "2024-08-01";
        /// <summary> API version "2022-12-01". </summary>
        public static readonly string V2022_12_01 = "2022-12-01";
        /// <summary> API version "2021-06-01". </summary>
        public static readonly string V2021_06_01 = "2021-06-01";
    }

    /// <summary>
    /// List of private endpoint connection resources associated with the
    /// specified server.
    /// </summary>
    public BicepList<PostgreSqlFlexibleServersPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            if (Properties is null)
            {
                Properties = new ServerProperties();
            }
            return Properties.PrivateEndpointConnections;
        }
    }

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
    private BicepList<PostgreSqlFlexibleServersPrivateEndpointConnectionData> _privateEndpointConnections;

    partial void DefineAdditionalProperties()
    {
        _privateEndpointConnections = DefineListProperty<PostgreSqlFlexibleServersPrivateEndpointConnectionData>("PrivateEndpointConnections", ["properties", "privateEndpointConnections"], isOutput: true);
    }
}
