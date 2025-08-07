// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A class representing the MachineLearningPrivateEndpointConnection data model.
    /// The Private Endpoint Connection resource.
    /// </summary>
    public partial class MachineLearningPrivateEndpointConnectionData : TrackedResourceData
    {
        private MachineLearningPrivateEndpoint _privateEndpoint;

        /// <summary> The resource of private end point. </summary>
        public MachineLearningPrivateEndpoint PrivateEndpoint
        {
            get
            {
                return _privateEndpoint is null ? new MachineLearningPrivateEndpoint(SubResourceId, SubResourceId, _serializedAdditionalRawData) : _privateEndpoint;
            }

            set
            {
                _privateEndpoint = value;
            }
        }
    }
}
