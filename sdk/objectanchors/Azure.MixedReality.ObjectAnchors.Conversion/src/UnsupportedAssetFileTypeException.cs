// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// An Exception thrown durin an attempt to provide an unsupported asset file type in an asset conversion operation
    /// </summary>
    public class UnsupportedAssetFileTypeException : Exception
    {
        internal UnsupportedAssetFileTypeException(AssetFileType assetFileType, IEnumerable<AssetFileType> supportedAssetFileTypes)
            : base($"The provided asset file type of \"{assetFileType}\" is unsupported by Azure Object Anchors for conversion. Supported file types: {string.Join(", ", supportedAssetFileTypes)}")
        {
            AttemptedFileType = assetFileType;
            SupportedAssetFileTypes = supportedAssetFileTypes;
        }

        /// <summary>
        /// The unsupported filetype provided for asset conversion
        /// </summary>
        public AssetFileType AttemptedFileType { get; }

        /// <summary>
        /// The list of file types supported by Azure Object Anchors Conversion
        /// </summary>
        public IEnumerable<AssetFileType> SupportedAssetFileTypes { get; }
    }
}
