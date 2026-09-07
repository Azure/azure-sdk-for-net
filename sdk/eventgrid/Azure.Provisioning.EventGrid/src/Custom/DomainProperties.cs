// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

internal partial class DomainProperties
{
    private BicepList<EventGridPrivateEndpointConnectionData> _customPrivateEndpointConnections;

    // The generated property contains deployable EventGridEventGridDomainPrivateEndpointConnection
    // resources. Preserve the released inline data-model element type on the same wire path.
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _customPrivateEndpointConnections;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customPrivateEndpointConnections = DefineListProperty<EventGridPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), ["privateEndpointConnections"], isOutput: true);
    }
}
