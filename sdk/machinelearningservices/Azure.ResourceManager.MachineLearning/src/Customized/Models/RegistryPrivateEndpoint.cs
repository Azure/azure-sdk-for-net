// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: preserve the legacy RegistryPrivateEndpoint compatibility type after the
    // generated private endpoint base type was renamed to MachineLearningPrivateEndpoint.
    public partial class RegistryPrivateEndpoint : MachineLearningPrivateEndpoint
    {
        /// <summary> Initializes a new instance of <see cref="RegistryPrivateEndpoint"/>. </summary>
        public RegistryPrivateEndpoint()
        {
        }

        internal RegistryPrivateEndpoint(ResourceIdentifier id, IDictionary<string, BinaryData> serializedAdditionalRawData, ResourceIdentifier subnetArmId)
            : base(id, subnetArmId, serializedAdditionalRawData)
        {
        }
    }
}
