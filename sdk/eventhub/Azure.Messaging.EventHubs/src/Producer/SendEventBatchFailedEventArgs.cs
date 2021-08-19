// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
<<<<<<< HEAD
<<<<<<< HEAD
using System.Threading;
=======
>>>>>>> 88750fe801 (Adding skeleton files)
=======
using System.Threading;
>>>>>>> dcfbe04dad (responding to feedback)

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   Contains information about a batch that was unable to be published, as well
    ///   as the exception that occurred and the partition that the batch was being published
    ///   to.
    /// </summary>
    ///
<<<<<<< HEAD
<<<<<<< HEAD
    internal class SendEventBatchFailedEventArgs : EventArgs
=======
    public class SendEventBatchFailedEventArgs : EventArgs
>>>>>>> 88750fe801 (Adding skeleton files)
=======
    internal class SendEventBatchFailedEventArgs : EventArgs
>>>>>>> c7457cff4d (updated to internal classes)
    {
        /// <summary>
        ///   The set of events that were in the batch that failed to publish.
        /// </summary>
        ///
<<<<<<< HEAD
<<<<<<< HEAD
        public IReadOnlyList<EventData> EventBatch { get; }
=======
        public IEnumerable<EventData> EventBatch { get; set; }
>>>>>>> 88750fe801 (Adding skeleton files)
=======
        public IReadOnlyList<EventData> EventBatch { get; }
>>>>>>> dcfbe04dad (responding to feedback)

        /// <summary>
        ///   The exception that occurred when trying to publish the batch.
        /// </summary>
        ///
<<<<<<< HEAD
<<<<<<< HEAD
        public Exception Exception { get; }
=======
        public Exception Exception { get; set; }
>>>>>>> 88750fe801 (Adding skeleton files)
=======
        public Exception Exception { get; }
>>>>>>> dcfbe04dad (responding to feedback)

        /// <summary>
        ///   The identifier of the partition to which the batch was being published.
        /// </summary>
        ///
<<<<<<< HEAD
<<<<<<< HEAD
        public string PartitionId { get; }

        /// <summary>
        ///   A <see cref="System.Threading.CancellationToken"/> to indicate that the producer is being closed
        ///    or disposed and is requesting that the handler stop its activities.
        /// </summary>
        ///
        /// <remarks>
        ///   The handler processing events has responsibility for deciding whether or not to honor
        ///   the cancellation request.  If the application chooses not to do so, the producer will wait for the
        ///   handler to complete before shutting down.
        /// </remarks>
        ///
        public CancellationToken CancellationToken { get; }
=======
        public string PartitionId { get; set; }
>>>>>>> 88750fe801 (Adding skeleton files)
=======
        public string PartitionId { get; }

        /// <summary>
        /// A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        ///
        public CancellationToken CancellationToken { get; }
>>>>>>> dcfbe04dad (responding to feedback)

        /// <summary>
        ///   Initializes a new instance of the <see cref="SendEventBatchFailedEventArgs"/> class.
        /// </summary>
        /// <param name="eventBatch">The set of events that were in the batch that failed to publish.</param>
        /// <param name="exception">The exception that occurred when trying to publish the batch.</param>
        /// <param name="partitionId">The identifier of the partition to which the batch was being published.</param>
<<<<<<< HEAD
<<<<<<< HEAD
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public SendEventBatchFailedEventArgs(IReadOnlyList<EventData> eventBatch,
                                             Exception exception,
                                             string partitionId,
                                             CancellationToken cancellationToken = default)
=======
=======
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.</param>
>>>>>>> dcfbe04dad (responding to feedback)
        ///
        public SendEventBatchFailedEventArgs(IReadOnlyList<EventData> eventBatch,
                                             Exception exception,
<<<<<<< HEAD
                                             string partitionId)
>>>>>>> 88750fe801 (Adding skeleton files)
=======
                                             string partitionId,
                                             CancellationToken cancellationToken = default)
>>>>>>> dcfbe04dad (responding to feedback)
        {
            EventBatch = eventBatch;
            Exception = exception;
            PartitionId = partitionId;
<<<<<<< HEAD
<<<<<<< HEAD
            CancellationToken = cancellationToken;
=======
>>>>>>> 88750fe801 (Adding skeleton files)
=======
            CancellationToken = cancellationToken;
>>>>>>> dcfbe04dad (responding to feedback)
        }
    }
}
