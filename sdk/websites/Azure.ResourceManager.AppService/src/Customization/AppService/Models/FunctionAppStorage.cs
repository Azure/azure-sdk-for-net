// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class FunctionAppStorage
    {
        // Add this property back to avoid breaking change with the fix for issue #52912
        /// <summary>
        /// Property to set the URL for the selected Azure Storage type. Example: For blobContainer, the value could be https://&lt;storageAccountName&gt;.blob.core.windows.net/&lt;containerName&gt;.
        /// </summary>
        [WirePath("value")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri Value
        {
            get
            {
                if (AzureStorageUriStringValue is null)
                    return null;
                return Uri.TryCreate(AzureStorageUriStringValue, UriKind.Absolute, out var uri) ? uri : null;
            }
            set => AzureStorageUriStringValue = value?.AbsoluteUri;
        }
    }
}
