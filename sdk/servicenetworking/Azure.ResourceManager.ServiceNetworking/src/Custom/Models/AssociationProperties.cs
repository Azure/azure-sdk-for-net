// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ServiceNetworking.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceNetworking.Models
{
    // The definition in Swagger and TSP is not `Lifecycle.Read`, so this property is manually added back.
    [CodeGenType(nameof(AssociationProperties))]
    internal partial class AssociationProperties
    {
        /// <summary> Association Type. </summary>
        [CodeGenMember("AssociationType")]
        public TrafficControllerAssociationType? AssociationType { get; set; }
    }
}
