// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    internal class DownloadRangeEventArgs : DataTransferEventArgs
    {
        public bool Success { get; }

        public long Offset { get; }

        /// <summary>
        /// Will be 0 if Success is false
        /// </summary>
        public long BytesTransferred { get; }

        /// <summary>
        /// Stream results of the range downloaded if Sucess is true
        /// </summary>
        public Stream Result { get; }

        /// <summary>
        /// If <see cref="Success"/> is false, this value will be populated
        /// with the exception that was thrown.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="transferId">
        /// Id of the transfer
        /// </param>
        /// <param name="success">
        /// Whether or not the download range call was successful
        /// </param>
        /// <param name="offset"></param>
        /// <param name="result"></param>
        /// <param name="bytesTransferred"></param>
        /// <param name="exception"></param>
        /// <param name="isRunningSynchronously"></param>
        /// <param name="cancellationToken"></param>
        public DownloadRangeEventArgs(
            string transferId,
            bool success,
            long offset,
            long bytesTransferred,
            Stream result,
            Exception exception,
            bool isRunningSynchronously,
            CancellationToken cancellationToken) :
            base(transferId, isRunningSynchronously, cancellationToken)
        {
            if (success && exception != null)
            {
                Argument.AssertNull(exception, nameof(exception));
            }
            else if (!success && exception == null)
            {
                Argument.AssertNotNull(exception, nameof(exception));
            }
            Success = success;
            Offset = offset;
            BytesTransferred = bytesTransferred;
            Result = result;
            Exception = exception;
        }
    }
}
