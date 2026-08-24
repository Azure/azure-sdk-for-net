// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core;

namespace Azure.Provisioning.Storage;

public partial class StoragePrivateEndpointConnection
{
    private BicepValue<ResourceIdentifier>? _privateEndpointId;

    // TypeSpec emits the flattened private endpoint ID as string. Preserve the shipped
    // ResourceIdentifier property type on the same output path.
    /// <summary> Gets the private endpoint resource identifier. </summary>
    public BicepValue<ResourceIdentifier> PrivateEndpointId
    {
        get { Initialize(); return _privateEndpointId!; }
    }

    partial void DefineAdditionalProperties()
    {
        _privateEndpointId = DefineProperty<ResourceIdentifier>(nameof(PrivateEndpointId), ["properties", "privateEndpoint", "id"], isOutput: true);
    }
}
