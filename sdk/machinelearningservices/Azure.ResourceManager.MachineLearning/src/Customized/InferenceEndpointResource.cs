// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: this resource has a bodyless PATCH operation. The generator currently falls back to
    // full-resource PUT tag helpers in that case, but this resource does not have a tag-specific update
    // contract, so suppress those generated helpers rather than updating tags through the full PUT path.
    [CodeGenSuppress("AddTagAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AddTag", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("SetTagsAsync", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("SetTags", typeof(IDictionary<string, string>), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTagAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("RemoveTag", typeof(string), typeof(CancellationToken))]
    public partial class InferenceEndpointResource : ArmResource
    {
    }
}
