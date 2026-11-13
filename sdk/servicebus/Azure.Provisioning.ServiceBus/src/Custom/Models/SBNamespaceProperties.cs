// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.ServiceBus
{
    internal partial class SBNamespaceProperties
    {
        // The public CodeGenMember customization suppresses the original generated property on this
        // flattened model, so preserve the renamed resource-list backing property here.
        private BicepList<ServiceBusPrivateEndpointConnection> _privateEndpointConnectionResources;

        // Backing storage for ServiceBusNamespace.PrivateEndpointConnections compatibility. This stays on
        // SBNamespaceProperties because the public ServiceBusNamespace property is flattened from this model.
#pragma warning disable CS0618 // ServiceBusPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        private BicepList<ServiceBusPrivateEndpointConnectionData> _privateEndpointConnections;
#pragma warning restore CS0618

        internal BicepList<ServiceBusPrivateEndpointConnection> PrivateEndpointConnectionResources
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

#pragma warning disable CS0618 // ServiceBusPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
        internal BicepList<ServiceBusPrivateEndpointConnectionData> PrivateEndpointConnections
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

        // Define both properties on the service wire path so old and new public views serialize identically.
        partial void DefineAdditionalProperties()
        {
            _privateEndpointConnectionResources = DefineListProperty<ServiceBusPrivateEndpointConnection>(nameof(PrivateEndpointConnectionResources), new string[] { "privateEndpointConnections" });
#pragma warning disable CS0618 // ServiceBusPrivateEndpointConnectionData is intentionally preserved for obsolete compatibility APIs.
            _privateEndpointConnections = DefineListProperty<ServiceBusPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "privateEndpointConnections" });
#pragma warning restore CS0618
        }
    }
}
