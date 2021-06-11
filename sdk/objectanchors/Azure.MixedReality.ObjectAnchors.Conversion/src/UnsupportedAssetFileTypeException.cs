// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// An Exception thrown durin an attempt to provide an unsupported asset file type in an asset conversion operation
    /// </summary>
    public class UnsupportedAssetFileTypeException : Exception
    {
        internal UnsupportedAssetFileTypeException(AssetFileType assetFileType)
            : base($"The provided asset file type of \"{assetFileType}\" is invalid. Supported file types: {string.Join(", ", AssetFileType.validAssetFileTypeValues)}")
        {
        }
    }
}
