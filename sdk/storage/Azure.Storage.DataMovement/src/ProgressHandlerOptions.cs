// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options associated with transfer progress tracking.
    /// </summary>
    public class ProgressHandlerOptions
    {
        /// <summary>
        /// Set to true to populate BytesTransferred of <see cref="DataTransferProgress"/> in
        /// progress reports. Set to false to not track BytesTransferred (value will be null).
        /// Default value is false.
        /// </summary>
        public bool TrackBytesTransferred { get; set; } = false;
    }
}
