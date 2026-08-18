// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.PostgreSql;

public partial class PostgreSqlFlexibleServersPrivateEndpointConnection
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

    private PostgreSqlFlexibleServersPrivateLinkServiceConnectionState _connectionState;
    private BicepValue<PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState> _provisioningState;

    /// <summary>
    /// A collection of information about the state of the connection between
    /// service consumer and provider.
    /// </summary>
    [CodeGenMember("ConnectionState")]
    public PostgreSqlFlexibleServersPrivateLinkServiceConnectionState ConnectionState
    {
        get { Initialize(); return _connectionState; }
        set { Initialize(); AssignOrReplace(ref _connectionState, value); }
    }

    /// <summary>
    /// The provisioning state of the private endpoint connection resource.
    /// </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState; }
    }

    partial void DefineAdditionalProperties()
    {
        _connectionState = DefineModelProperty<PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>(nameof(ConnectionState), ["properties", "privateLinkServiceConnectionState"]);
        _provisioningState = DefineProperty<PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState>(nameof(ProvisioningState), ["properties", "provisioningState"], isOutput: true);
    }
}
