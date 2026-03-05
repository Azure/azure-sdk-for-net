// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.LoadTesting.Models
{
    // This type is generated from a ResourceUpdateModel<> template instantiation,
    // which cannot be targeted by @@clientName in TypeSpec client.tsp.
    // We use CodeGenType to rename it from LoadTestProfileMappingResourceUpdateProperties.
    /// <summary> The updatable properties of the LoadTestProfileMappingResource. </summary>
    [CodeGenType("LoadTestProfileMappingResourceUpdateProperties")]
    public partial class LoadTestProfileMappingUpdateProperties { }
}
