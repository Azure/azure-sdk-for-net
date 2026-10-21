// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class TroubleshootingContent
    {
        /// <summary> Initializes a new instance of <see cref="TroubleshootingContent"/>. </summary>
        /// <param name="targetResourceId"> The target resource to troubleshoot. </param>
        /// <param name="storageId"> The storage account for troubleshooting output. </param>
        /// <param name="storagePath"> The absolute storage path. </param>
        public TroubleshootingContent(ResourceIdentifier targetResourceId, ResourceIdentifier storageId, Uri storagePath)
            : this(targetResourceId, storageId, storagePath?.AbsoluteUri)
        {
        }

        // Keep the native string path, including relative paths, behind the released URI facade.
        /// <summary> Gets the storage path as an absolute or relative URI. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, use StoragePath instead", false)]
        public Uri StorageUri => StoragePath is null ? null : new Uri(StoragePath, UriKind.RelativeOrAbsolute);
    }
}
