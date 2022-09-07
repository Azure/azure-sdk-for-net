// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The model representing the error and the associated logs that failed when uploading a subset of logs to Azure Monitor.
    /// </summary>
    public class UploadLogsError
    {
        internal UploadLogsError(ResponseError error, IEnumerable<Object> failedLogs)
        {
            Argument.AssertNotNull(failedLogs, nameof(failedLogs));
            Error = error;
            FailedLogs = failedLogs;
        }

        /// <summary>
        ///  List of logs that failed to upload.
        /// </summary>
        public IEnumerable<Object> FailedLogs { get; }

        /// <summary>
        /// The response error containing the error details returned by the service.
        /// </summary>
        public ResponseError Error { get; }
    }
}
