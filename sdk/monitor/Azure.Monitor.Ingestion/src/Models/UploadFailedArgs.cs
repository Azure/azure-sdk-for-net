// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Serialization;

namespace Azure.Monitor.Ingestion
{
    /// <summary>
    /// The options model to configure the request to upload logs to Azure Monitor.
    /// </summary>
    public class UploadFailedArgs : SyncAsyncEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFailedArgs"/> class.
        /// </summary>
        /// <param name="failedLogs"></param>
        /// <param name="exception"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public UploadFailedArgs(int failedLogs, Exception exception, bool isRunningSynchronously, CancellationToken cancellationToken) : base(isRunningSynchronously, cancellationToken)
        {
            FailedLogs = failedLogs;
            Exception = exception;
        }
        /// <summary>
        /// test
        /// </summary>
        public int FailedLogs { get; }
        /// <summary>
        /// test
        /// </summary>
        public Exception Exception { get; }
    }
}
