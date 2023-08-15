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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by ResourceUriString",false)]
        public System.Uri SasUri { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by ResourceUriString", false)]
        public AppServiceTableStorageApplicationLogsConfig(Uri SasUri)
        {
            Argument.AssertNotNull(SasUri, nameof(SasUri));
        }
    }
}
