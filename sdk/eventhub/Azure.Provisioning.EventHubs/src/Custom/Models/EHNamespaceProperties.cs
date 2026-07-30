// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.EventHubs
{
    internal partial class EHNamespaceProperties
    {
        // The public CodeGenMember customization suppresses the original generated property on this
        // flattened model, so preserve the renamed resource-list backing property here.
        private BicepList<EventHubsPrivateEndpointConnection> _privateEndpointConnectionResources;

        // Backing storage for EventHubsNamespace.PrivateEndpointConnections compatibility. This stays on
        // EHNamespaceProperties because the public EventHubsNamespace property is flattened from this model.
#pragma warning disable CS0618 // EventHubsPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        private BicepList<EventHubsPrivateEndpointConnectionData> _privateEndpointConnections;
#pragma warning restore CS0618

        internal BicepList<EventHubsPrivateEndpointConnection> PrivateEndpointConnectionResources
        {
            get
            {
                Initialize();
                return _privateEndpointConnectionResources;
            }
            set
            {
                Initialize();
                _privateEndpointConnectionResources.Assign(value);
            }
        }

#pragma warning disable CS0618 // EventHubsPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        internal BicepList<EventHubsPrivateEndpointConnectionData> PrivateEndpointConnections
#pragma warning restore CS0618
        {
            get
            {
                Initialize();
                return _privateEndpointConnections;
            }
            set
            {
                Initialize();
                _privateEndpointConnections.Assign(value);
            }
        }

        partial void DefineAdditionalProperties()
        {
            _privateEndpointConnectionResources = DefineListProperty<EventHubsPrivateEndpointConnection>(nameof(PrivateEndpointConnectionResources), new string[] { "privateEndpointConnections" });
#pragma warning disable CS0618 // EventHubsPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
            _privateEndpointConnections = DefineListProperty<EventHubsPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "privateEndpointConnections" });
#pragma warning restore CS0618
        }
    }
}
