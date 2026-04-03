// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used UriDecode/UriEncode instead of UrlDecode/UrlEncode
    public readonly partial struct PreTransformCategory
    {
        [CodeGenMember("UrlDecode")]
        public static PreTransformCategory UriDecode { get; } = new PreTransformCategory(UrlDecodeValue);

        [CodeGenMember("UrlEncode")]
        public static PreTransformCategory UriEncode { get; } = new PreTransformCategory(UrlEncodeValue);
    }
}
