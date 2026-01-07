// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ServiceNetworking.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceNetworking.Models
{
   [CodeGenType(nameof(AssociationProperties))]
   internal partial class AssociationProperties
   {
       /// <summary> Association Type. </summary>
       [CodeGenMember("AssociationType")]
       public TrafficControllerAssociationType? AssociationType { get; set; }
   }
}
