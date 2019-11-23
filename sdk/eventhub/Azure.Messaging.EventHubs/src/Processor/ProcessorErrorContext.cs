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
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor" />
    ///
    public class ProcessorErrorContext
    {
        /// <summary>
        ///   The identifier of the partition whose processing threw an exception.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The exception that was thrown by the <c>EventProcessorClient</c>.
        /// </summary>
        ///
        public Exception ProcessorException { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProcessorErrorContext"/> class.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose processing threw an exception.</param>
        /// <param name="exception">The exception that was thrown by the <c>EventProcessorClient</c>.</param>
        ///
        protected internal ProcessorErrorContext(string partitionId,
                                                 Exception exception)
        {
            Argument.AssertNotNull(exception, nameof(exception));

            PartitionId = partitionId;
            ProcessorException = exception;
        }
    }
}
