// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.MixedReality.RemoteRendering
{
    /// <summary> Settings for the conversion input. </summary>
    [CodeGenModel("ConversionInputSettings")]
    public partial class AssetConversionInputOptions
    {
        /// <summary> The URI of the Azure blob storage container containing the input model. </summary>
        [CodeGenMember("StorageContainerUri")]
        public Uri StorageContainerUri { get; }
        /// <summary> The relative path starting at blobPrefix (or at the container root if blobPrefix is not specified) to the input model. Must point to file with a supported file format ending. </summary>
        [CodeGenMember("RelativeInputAssetPath")]
        public string RelativeInputAssetPath { get; }
    }
}
