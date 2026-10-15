// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    internal partial class RegistryPrivateEndpointConnectionProperties
    {
        // Allow the shipped flattened setter to replace an explicitly null collection.
        public IList<string> GroupIds { get; set; } = new ChangeTrackingList<string>();
    }
}
