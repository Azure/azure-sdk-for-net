// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition whose processing threw an exception, as well as
    ///   the exception that has been thrown.
    /// </summary>
    ///
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
    ///
    public struct ProcessErrorEventArgs
    {
        /// <summary>
        ///   The identifier of the partition whose processing threw an exception.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   A short description of the operation that was being performed when the exception was thrown.
        /// </summary>
        ///
        public string Operation { get; }

        /// <summary>
        ///   The exception that was thrown by the <c>EventProcessorClient</c>.
        /// </summary>
        ///
        public Exception Exception { get; }

        /// <summary>
        ///   A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        ///
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProcessErrorEventArgs"/> structure.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose processing threw an exception.</param>
        /// <param name="operation">A short description of the operation that was being performed when the exception was thrown.</param>
        /// <param name="exception">The exception that was thrown by the <c>EventProcessorClient</c>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public ProcessErrorEventArgs(string partitionId,
                                     string operation,
                                     Exception exception,
                                     CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            Argument.AssertNotNull(exception, nameof(exception));

            PartitionId = partitionId;
            Operation = operation;
            Exception = exception;
            CancellationToken = cancellationToken;
        }
    }
}
