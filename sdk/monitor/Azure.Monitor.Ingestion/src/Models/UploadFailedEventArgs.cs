// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The event argument models configured with the EventHandler to upload logs to Azure Monitor.
    /// </summary>
    public class UploadFailedEventArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFailedEventArgs"/> class.
        /// </summary>
        /// <param name="failedLogs"></param>
        /// <param name="exception"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="clientDiagnostics"></param>
        /// <param name="cancellationToken"></param>
        internal UploadFailedEventArgs(IEnumerable<object> failedLogs, Exception exception, bool isRunningSynchronously, ClientDiagnostics clientDiagnostics, CancellationToken cancellationToken) : this (failedLogs, exception, isRunningSynchronously, cancellationToken)
        {
            ClientDiagnostics = clientDiagnostics;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFailedEventArgs"/> class.
        /// </summary>
        /// <param name="failedLogs"></param>
        /// <param name="exception"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public UploadFailedEventArgs(IEnumerable<object> failedLogs, Exception exception, bool isRunningSynchronously, CancellationToken cancellationToken) : base(isRunningSynchronously, cancellationToken)
        {
            FailedLogs = failedLogs.ToList();
            Exception = exception;
        }

        /// <summary>
        /// The list of logs in the batch that failed to upload.
        /// </summary>
        public IReadOnlyList<object> FailedLogs { get; }
        /// <summary>
        /// The exception from the batch that failed to upload.
        /// </summary>
        public Exception Exception { get; }

        internal ClientDiagnostics ClientDiagnostics;
    }
}
