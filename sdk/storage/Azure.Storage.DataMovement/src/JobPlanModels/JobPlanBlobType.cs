// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Storage.DataMovement
{
    internal enum JobPlanBlobType
    {
        /// <summary>
        /// Detect blob type
        /// </summary>
        Detect = 0,
        /// <summary>
        /// Block Blob
        /// </summary>
        BlockBlob = 1,
        /// <summary>
        /// Page Blob
        /// </summary>
        PageBlob = 2,
        /// <summary>
        /// Append Blob
        /// </summary>
        AppendBlob = 3,
    }
}
