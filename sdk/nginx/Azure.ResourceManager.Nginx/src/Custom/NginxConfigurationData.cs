// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Nginx
{
    /// <summary> A class representing the NginxConfiguration data model. </summary>
    public partial class NginxConfigurationData : ResourceData
    {
        /// <summary> Gets or sets the location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureLocation? Location { get; set; }        // This was a spec breaking change, so we’re adding the property back to restore backward compatibility.
    }
}
