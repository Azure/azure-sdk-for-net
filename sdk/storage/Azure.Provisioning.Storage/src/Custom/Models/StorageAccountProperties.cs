// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

/// <summary> Properties of the storage account. </summary>
internal partial class StorageAccountProperties
{
    // TypeSpec generates a nested resource list named PrivateEndpointConnections, but the shipped new API names it PrivateEndpointConnectionResources.
    private BicepList<StoragePrivateEndpointConnection> _privateEndpointConnectionResources;

    // The shipped old API keeps the PrivateEndpointConnections name with its data-model element type.
    private BicepList<StoragePrivateEndpointConnectionData> _privateEndpointConnections;

    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<StoragePrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            Initialize();
            return _privateEndpointConnectionResources;
        }
    }

    internal BicepList<StoragePrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _privateEndpointConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        // Both output aliases share the response path because they preserve the shipped new and old views of the same wire property.
        _privateEndpointConnectionResources = DefineListProperty<StoragePrivateEndpointConnection>(nameof(PrivateEndpointConnectionResources), new string[] { "privateEndpointConnections" }, isOutput: true, isRequired: false);
        _privateEndpointConnections = DefineListProperty<StoragePrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "privateEndpointConnections" }, isOutput: true, isRequired: false);
    }
}
