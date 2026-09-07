// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.EventGrid;

internal partial class PartnerNamespaceProperties
{
#pragma warning disable CS0618 // EventGridPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
    private BicepList<EventGridPrivateEndpointConnectionData> _privateEndpointConnectionData;
#pragma warning restore CS0618

    // Backing storage for the obsolete flattened property on PartnerNamespace.
#pragma warning disable CS0618 // EventGridPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
    internal BicepList<EventGridPrivateEndpointConnectionData> PrivateEndpointConnectionData
#pragma warning restore CS0618
    {
        get
        {
            Initialize();
            return _privateEndpointConnectionData;
        }
    }

    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // EventGridPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        _privateEndpointConnectionData = DefineListProperty<EventGridPrivateEndpointConnectionData>(nameof(PrivateEndpointConnectionData), ["privateEndpointConnections"], isOutput: true);
#pragma warning restore CS0618
    }
}
