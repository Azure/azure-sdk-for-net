// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the shipped SubnetArmId property for MachineLearningPrivateEndpoint.
    // The generated ARM common private endpoint model only carries Id, but the previous SDK exposed
    // the workspace private endpoint shape with SubnetArmId as well.
    public partial class MachineLearningPrivateEndpoint
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningPrivateEndpoint"/>. </summary>
        /// <param name="id"> e.g. /subscriptions/{networkSubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Network/privateEndpoints/{privateEndpointName}. </param>
        /// <param name="subnetArmId"> The subnetId that the private endpoint is connected to. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal MachineLearningPrivateEndpoint(ResourceIdentifier id, ResourceIdentifier subnetArmId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Id = id;
            SubnetArmId = subnetArmId;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The subnetId that the private endpoint is connected to. </summary>
        public ResourceIdentifier SubnetArmId { get; set; }
    }
}
