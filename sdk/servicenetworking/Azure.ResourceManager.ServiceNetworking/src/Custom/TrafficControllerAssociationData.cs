// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ServiceNetworking.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceNetworking
{
    // The definition in Swagger and TSP is not `Lifecycle.Read`, so this property is manually added back.
    public partial class TrafficControllerAssociationData
    {
        /// <summary> Association Type. </summary>
        [CodeGenMember("associationType")]
        public TrafficControllerAssociationType? AssociationType { get; set; }
    }
}
