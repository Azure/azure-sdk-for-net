// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountInternetEndpoints
    {
        /// <summary> Backward-compatible alias for Blob. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("blob")]
        public Uri BlobUri => !string.IsNullOrEmpty(Blob) ? new Uri(Blob) : null;

        /// <summary> Backward-compatible alias for File. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("file")]
        public Uri FileUri => !string.IsNullOrEmpty(File) ? new Uri(File) : null;

        /// <summary> Backward-compatible alias for Web. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("web")]
        public Uri WebUri => !string.IsNullOrEmpty(Web) ? new Uri(Web) : null;

        /// <summary> Backward-compatible alias for Dfs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dfs")]
        public Uri DfsUri => !string.IsNullOrEmpty(Dfs) ? new Uri(Dfs) : null;
    }
}
