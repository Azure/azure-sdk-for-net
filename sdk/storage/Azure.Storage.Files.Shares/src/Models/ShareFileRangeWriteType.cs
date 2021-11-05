// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Specify one of the following options: - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match to perform the update. - Clear: Clears the specified range and releases the space used in storage for that range. To clear a range, set the Content-Length header to zero, and set the Range header to a value that indicates the range to clear, up to maximum file size.
    /// </summary>
    [CodeGenModel("FileRangeWriteType")]
    public enum ShareFileRangeWriteType
    {
        /// <summary>
        /// update
        /// </summary>
        Update,

        /// <summary>
        /// clear
        /// </summary>
        Clear
    }
}
