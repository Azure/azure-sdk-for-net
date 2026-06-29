// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // Gallery image tag updates go through the image PATCH operation, where the service
    // requires the existing OS type to preserve the image platform metadata.
    [CodeGenTagPatchHook(nameof(PrepareTagPatch))]
    public partial class GalleryImageResource
    {
        private void PrepareTagPatch(GalleryImagePatch patch, GalleryImageData current)
        {
            patch.OSType = current.OSType;
        }
    }
}
