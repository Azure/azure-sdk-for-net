// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The static website properties for blob storage. </summary>
    [CodeGenType("StaticWebsite")]
    public partial class BlobServiceStaticWebsite
    {
        /// <summary> Indicates whether static website support is enabled for the specified account. </summary>
        [CodeGenMember("Enabled")]
        [WirePath("enabled")]
        public bool IsEnabled { get; set; }
    }
}
