// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class AppServiceTableStorageApplicationLogsConfig
    {
        /// <summary> Uri of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by ResourceUriString", false)]
        public System.Uri SasUri { get; set; }

        /// <summary> Initializes a new instance of <see cref="AppServiceTableStorageApplicationLogsConfig"/>. </summary>
        /// <param name="SasUri"> SAS URL to an Azure table with add/query/delete permissions. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by ResourceUriString", false)]
        public AppServiceTableStorageApplicationLogsConfig(Uri SasUri)
        {
            Argument.AssertNotNull(SasUri, nameof(SasUri));
        }
    }
}
