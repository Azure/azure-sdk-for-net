// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;

namespace Azure.MixedReality.RemoteRendering
{
    [CodeGenModel("ConversionOutputSettings")]
    public partial class AssetConversionOutputOptions
    {
        /// <summary> The URI of the Azure blob storage container containing the input model. </summary>
        [CodeGenMember("StorageContainerUri")]
        public Uri StorageContainerUri { get; }
    }
}
