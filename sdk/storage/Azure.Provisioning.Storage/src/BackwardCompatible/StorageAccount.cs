// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

public partial class StorageAccount : ProvisionableResource
{
    /// <summary>
    /// List of private endpoint connection associated with the specified
    /// storage account.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="StorageAccount.PrivateEndpointConnectionResources"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepList<StoragePrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get { Initialize(); return _privateEndpointConnections!; }
    }
    private BicepList<StoragePrivateEndpointConnectionData>? _privateEndpointConnections;

    private partial void DefineAdditionalProperties()
    {
        _privateEndpointConnections = DefineListProperty<StoragePrivateEndpointConnectionData>("PrivateEndpointConnections", ["properties", "privateEndpointConnections"], isOutput: true);
    }
}
