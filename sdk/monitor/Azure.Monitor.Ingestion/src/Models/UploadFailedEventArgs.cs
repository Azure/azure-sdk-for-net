// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The options model to configure the request to upload logs to Azure Monitor.
    /// </summary>
    public class UploadFailedEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFailedEventArgs"/> class.
        /// </summary>
        /// <param name="failedLogs"></param>
        /// <param name="exception"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public UploadFailedEventArgs(List<object> failedLogs, Exception exception, bool isRunningSynchronously, CancellationToken cancellationToken) : base(isRunningSynchronously, cancellationToken)
        {
            FailedLogs = failedLogs;
            Exception = exception;
        }

        /// <summary>
        /// test
        /// </summary>
        public IReadOnlyList<object> FailedLogs { get; }
        /// <summary>
        /// test
        /// </summary>
        public Exception Exception { get; }

        internal ClientDiagnostics _clientDiagnostics;
    }
}
