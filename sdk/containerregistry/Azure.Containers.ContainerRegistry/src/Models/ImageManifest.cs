// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("Manifest")]
    internal partial class ImageManifest
    {
        /// <summary> Media type for this Manifest. </summary>
        public string MediaType { get; set; }
    }
}
