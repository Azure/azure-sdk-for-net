// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;

namespace Azure.Provisioning.RedisEnterprise;

/// <summary>
/// RedisEnterpriseCluster.
/// </summary>
public partial class RedisEnterpriseCluster
{
    /// <summary>
    /// List of private endpoint connections associated with the specified
    /// Redis Enterprise cluster.
    ///
    /// This property is obsoleted in favor of 'PrivateEndpointConnectionResources' property.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepList<RedisEnterprisePrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get { Initialize(); return _privateEndpointConnections!; }
    }
    private BicepList<RedisEnterprisePrivateEndpointConnectionData>? _privateEndpointConnections;

    private partial void DefineAdditionalProperties()
    {
        _privateEndpointConnections = DefineListProperty<RedisEnterprisePrivateEndpointConnectionData>("PrivateEndpointConnections", ["properties", "privateEndpointConnections"], isOutput: true);
    }
}
