// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Nginx.Models
{
    /// <summary> Nginx Configuration File. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ContentHash), "contentHash")]
    public partial class NginxConfigurationFile
    {
        /// <summary> Gets or sets the Content. </summary>
        public string ContentHash { get; set; }     // The service returns a "contentHash" field that is missing from the spec
    }
}
