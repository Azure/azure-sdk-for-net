// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about an exception that occurred within the processor, whether for a specific partition
    ///   or as part of the processor's internal operations.
    /// </summary>
    ///
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
    ///
    [SuppressMessage("Usage", "AZC0034:Type name 'ProcessErrorEventArgs' conflicts with 'Azure.Messaging.ServiceBus.ProcessErrorEventArgs (from Azure.Messaging.ServiceBus)'. Consider renaming to 'ProcessorProcessErrorEventArgsClient' or 'ProcessorProcessErrorEventArgsService' to avoid confusion.", Justification = "Existing name with a stable release.")]
    public struct ProcessErrorEventArgs
    {
        /// <summary>
        ///   The identifier of the partition being processed when the exception occurred.  If the exception did
        ///   not occur for a specific partition, this value will be <c>null</c>.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   A short description of the operation that was being performed when the exception occurred.
        /// </summary>
        ///
        public string Operation { get; }

        /// <summary>
        ///   The exception that was occurred during processing.
        /// </summary>
        ///
        public Exception Exception { get; }

        /// <summary>
        ///   A <see cref="System.Threading.CancellationToken"/> to indicate that the processor is requesting that the handler
        ///   stop its activities.  If this token is requesting cancellation, then  the processor is attempting to shutdown.
        /// </summary>
        ///
        /// <remarks>
        ///   The handler processing the error has responsibility for deciding whether or not to honor
        ///   the cancellation request.  If the application chooses not to do so, the processor will wait for the
        ///   handler to complete before taking further action.
        /// </remarks>
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
