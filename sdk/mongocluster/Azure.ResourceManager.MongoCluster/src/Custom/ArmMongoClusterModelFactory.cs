// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.MongoCluster;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MongoCluster.Models
{
    /// <summary> A factory class for creating instances of the models for mocking. </summary>
    public static partial class ArmMongoClusterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MongoClusterPrivateEndpointConnectionProperties"/>. </summary>
        /// <param name="groupIds"> The group ids for the private endpoint resource. </param>
        /// <param name="privateEndpointId"> The private endpoint resource. </param>
        /// <param name="privateLinkServiceConnectionState"> A collection of information about the state of the connection between service consumer and provider. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint connection resource. </param>
        /// <returns> A new <see cref="Models.MongoClusterPrivateEndpointConnectionProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MongoClusterPrivateEndpointConnectionProperties MongoClusterPrivateEndpointConnectionProperties(IEnumerable<string> groupIds = null, ResourceIdentifier privateEndpointId = null, MongoClusterPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, MongoClusterPrivateEndpointConnectionProvisioningState? provisioningState = null)
        {
            groupIds ??= new ChangeTrackingList<string>();

            return new MongoClusterPrivateEndpointConnectionProperties(groupIds.ToList(), default, privateLinkServiceConnectionState, provisioningState, additionalBinaryDataProperties: null);
        }
    }
}
