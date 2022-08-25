// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// test
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
        /// test
        /// </summary>
        public IEnumerable<Object> FailedLogs { get; }

        /// <summary>
        /// test
        /// </summary>
        public ResponseError Error { get; }
    }
}
