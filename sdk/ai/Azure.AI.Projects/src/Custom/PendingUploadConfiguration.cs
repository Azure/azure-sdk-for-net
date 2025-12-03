// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects
{
    public partial class PendingUploadConfiguration
    {
        /// <summary> BlobReference is the only supported type. </summary>
        public PendingUploadType PendingUploadType { get; } = "BlobReference";
    }
}
