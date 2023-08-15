// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class AppServiceTableStorageApplicationLogsConfig
    {
        /// <summary> Uri of the resource. </summary>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by ResourceUriString")]
        public System.Uri SasUri { get; set; }

        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        [ObsoleteAttribute("This property has been replaced by ResourceUriString")]
        public AppServiceTableStorageApplicationLogsConfig(System.Uri SasUri)
        {
            Argument.AssertNotNull(SasUri, nameof(SasUri));
        }
    }
}
