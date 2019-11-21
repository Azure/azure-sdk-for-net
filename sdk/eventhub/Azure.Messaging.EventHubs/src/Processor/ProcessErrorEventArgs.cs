// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition whose processing threw an exception, as well as
    ///   the exception that has been thrown.
    /// </summary>
    ///
    public class ProcessErrorEventArgs
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
        ///   The exception that was thrown by the <see cref="EventProcessorClient" />.
        /// </summary>
        ///
        public Exception ProcessorException { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProcessErrorEventArgs"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose processing threw an exception.</param>
        /// <param name="operation">A short description of the operation that was being performed when the exception was thrown.</param>
        /// <param name="exception">The exception that was thrown by the <see cref="EventProcessorClient" />.</param>
        ///
        protected internal ProcessErrorEventArgs(string partitionId,
                                                 string operation,
                                                 Exception exception)
        {
            Argument.AssertNotNullOrEmpty(operation, nameof(operation));
            Argument.AssertNotNull(exception, nameof(exception));

            PartitionId = partitionId;
            Operation = operation;
            ProcessorException = exception;
        }
    }
}
