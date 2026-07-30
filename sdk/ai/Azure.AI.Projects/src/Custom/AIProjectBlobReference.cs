// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.Projects
{
    /// <summary> Blob reference details. </summary>
    [CodeGenType("AIProjectBlobReference")]
    public partial class AIProjectBlobReference
    {
        /// <summary> The absolute URI of the referenced blob. </summary>
        public Uri BlobUri { get; }
    }
}
