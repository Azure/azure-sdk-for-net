// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the TroubleshootingContent type. </summary>
    public partial class TroubleshootingContent
    {
        // Keep the native string path, including relative paths, behind the released URI facade.
        /// <summary> Gets the storage path as an absolute or relative URI. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, use StoragePath instead", false)]
        public Uri StorageUri => StoragePath is null ? null : new Uri(StoragePath, UriKind.RelativeOrAbsolute);
    }
}
