// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure;

namespace Azure.ResourceManager.NetApp
{
    public partial class SnapshotPolicyData
    {
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ETag? ETag => ETagValue is string etag ? new ETag(etag) : null;
    }
}
