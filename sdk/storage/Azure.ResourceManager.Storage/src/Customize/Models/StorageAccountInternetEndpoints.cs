// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountInternetEndpoints
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("blob")]
        public Uri BlobUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("file")]
        public Uri FileUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("web")]
        public Uri WebUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dfs")]
        public Uri DfsUri { get; }
    }
}
