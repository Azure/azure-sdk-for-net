// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ServiceNetworking.Models;

namespace Azure.ResourceManager.ServiceNetworking
{
    // add the property back for backward compatibility
    public partial class TrafficControllerAssociationData
    {
        /// <summary> Association Type. </summary>
        public TrafficControllerAssociationType? AssociationType { get; set; }
    }
}
