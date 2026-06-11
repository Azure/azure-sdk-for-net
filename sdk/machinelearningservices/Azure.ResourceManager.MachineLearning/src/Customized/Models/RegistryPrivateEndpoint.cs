// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: suppress the generated duplicate SubnetArmId member; the property is already
    // provided by the custom base model used for registry private endpoints.
    [CodeGenSuppress("SubnetArmId", typeof(ResourceIdentifier))]
    public partial class RegistryPrivateEndpoint
    {
    }
}
