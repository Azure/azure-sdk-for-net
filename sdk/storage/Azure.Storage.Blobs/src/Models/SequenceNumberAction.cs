// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Required if the x-ms-blob-sequence-number header is set for the request.
    /// This property applies to page blobs only. This property indicates how the service should modify the blob's sequence number.
    /// </summary>
    [CodeGenModel("SequenceNumberActionType")]
    public enum SequenceNumberAction
    {
        /// <summary>
        /// max
        /// </summary>
        Max,

        /// <summary>
        /// update
        /// </summary>
        Update,

        /// <summary>
        /// increment
        /// </summary>
        Increment
    }
}
