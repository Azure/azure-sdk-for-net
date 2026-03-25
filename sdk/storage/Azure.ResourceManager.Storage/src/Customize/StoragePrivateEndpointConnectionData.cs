// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: The prior GA SDK flattened the nested
// StoragePrivateEndpointConnectionProperties bag so that ConnectionState,
// ProvisioningState, and PrivateEndpointId were top-level properties on
// the data class. The TypeSpec-generated code keeps them under a
// Properties object. This customization re-exposes the flattened
// accessors so existing callers that reference e.g.
//   data.ConnectionState
//   data.ProvisioningState
//   data.PrivateEndpointId
// continue to compile and work without changes.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary> The Private Endpoint Connection resource. </summary>
    public partial class StoragePrivateEndpointConnectionData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="StoragePrivateEndpointConnectionData"/>. </summary>
        public StoragePrivateEndpointConnectionData()
        {
        }

        /// <summary> Resource properties. </summary>
        [WirePath("properties")]
        internal StoragePrivateEndpointConnectionProperties Properties { get; set; }

        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        [WirePath("properties.privateLinkServiceConnectionState")]
        public StoragePrivateLinkServiceConnectionState ConnectionState
        {
            get
            {
                return Properties is null ? default : Properties.ConnectionState;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new StoragePrivateEndpointConnectionProperties(value);
                    return;
                }
                Properties.ConnectionState = value;
            }
        }

        /// <summary> The provisioning state of the private endpoint connection resource. </summary>
        [WirePath("properties.provisioningState")]
        public StoragePrivateEndpointConnectionProvisioningState? ProvisioningState
        {
            get
            {
                return Properties is null ? default : Properties.ProvisioningState;
            }
        }

        /// <summary> The ARM identifier for Private Endpoint. </summary>
        [WirePath("properties.privateEndpoint.id")]
        public ResourceIdentifier PrivateEndpointId
        {
            get
            {
                if (Properties is null || Properties.PrivateEndpointId is null)
                    return default;
                return new ResourceIdentifier(Properties.PrivateEndpointId);
            }
        }
    }
}
