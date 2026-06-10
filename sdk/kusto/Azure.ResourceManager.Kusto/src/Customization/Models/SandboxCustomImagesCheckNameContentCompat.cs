// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class SandboxCustomImagesCheckNameContent
    {
        /// <summary> The type of resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public SandboxCustomImageType ImageType => new SandboxCustomImageType(Type);
    }
}
