// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: suppress a generated duplicate member. RegistryPrivateEndpoint inherits the
    // customized PrivateEndpointBase.SubnetArmId, but generation still emits a new SubnetArmId here.
    [CodeGenSuppress("SubnetArmId", typeof(ResourceIdentifier))]
    public partial class RegistryPrivateEndpoint
    {
    }
}
