// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: the service requires osType on GalleryImage tag PATCH requests.
    // The previous AutoRest configuration used update-required-copy: GalleryImage: OSType.
    [CodeGenTagPatchHook(nameof(PrepareTagPatch))]
    public partial class GalleryImageResource
    {
        private void PrepareTagPatch(GalleryImagePatch patch, GalleryImageData current)
        {
            patch.OSType = current.OSType;
        }
    }
}
