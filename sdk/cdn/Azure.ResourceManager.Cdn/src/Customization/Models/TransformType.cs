// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used UriDecode/UriEncode instead of UrlDecode/UrlEncode
    public readonly partial struct TransformType
    {
        [CodeGenMember("UrlDecode")]
        public static TransformType UriDecode { get; } = new TransformType(UrlDecodeValue);

        [CodeGenMember("UrlEncode")]
        public static TransformType UriEncode { get; } = new TransformType(UrlEncodeValue);
    }
}
