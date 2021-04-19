// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   Contains information about a partition that has attempted to receive an event from the Azure Event Hub
    ///   service in an <c>EventProcessorClient</c> context, as well as the received event, if any.  It
    ///   also provides a way of creating a checkpoint based on the information contained in the associated event.
    /// </summary>
    ///
    /// <seealso href="https://www.nuget.org/packages/Azure.Messaging.EventHubs.Processor">Azure.Messaging.EventHubs.Processor (NuGet)</seealso>
    ///
    public struct ProcessEventArgs
    {
        /// <summary>
        ///   Indicates whether or not the arguments contain an event to be processed.  In
        ///   the case where no event is contained, then the context and creation of
        ///   checkpoints are also unavailable.
        /// </summary>
        ///
        /// <value><c>true</c> if the arguments contain an event to be processed; otherwise, <c>false</c>.</value>
        ///
        public bool HasEvent => ((Data != null) && (Partition != null));

        /// <summary>
        ///   The context of the Event Hub partition this instance is associated with.
        /// </summary>
        ///
        public PartitionContext Partition { get; }

        /// <summary>
        ///   The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.
        /// </summary>
        ///
        /// <remarks>
        ///   Ownership of this data, including the memory that holds its <see cref="EventData.EventBody" />,
        ///   is assumed to transfer to consumers of the <see cref="ProcessEventArgs" />.  It may be considered
        ///   immutable and is safe to access so long as the reference is held.
        /// </remarks>
        ///
        public EventData Data { get; }

        /// <summary>
        ///   A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.
        /// </summary>
        ///
        public CancellationToken CancellationToken { get; }

        /// <summary>
        ///   The callback to be called upon <see cref="UpdateCheckpointAsync" /> call.
        /// </summary>
        ///
        private Func<CancellationToken, Task> UpdateCheckpointAsyncImplementation { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProcessEventArgs"/> structure.
        /// </summary>
        ///
        /// <param name="partition">The context of the Event Hub partition this instance is associated with.</param>
        /// <param name="data">The received event to be processed.  Expected to be <c>null</c> if the receive call has timed out.</param>
        /// <param name="updateCheckpointImplementation">The callback to be called upon <see cref="UpdateCheckpointAsync" /> call.</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public ProcessEventArgs(PartitionContext partition,
                                EventData data,
                                Func<CancellationToken, Task> updateCheckpointImplementation,
                                CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(updateCheckpointImplementation, nameof(updateCheckpointImplementation));

            Partition = partition;
            Data = data;
            UpdateCheckpointAsyncImplementation = updateCheckpointImplementation;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        ///   Updates the checkpoint for the <see cref="PartitionContext" /> and <see cref="EventData" /> associated with
        ///   this event.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="System.Threading.CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when <see cref="Partition" /> and <see cref="Data" /> are <c>null</c>.</exception>
        ///
        public Task UpdateCheckpointAsync(CancellationToken cancellationToken = default) => UpdateCheckpointAsyncImplementation(cancellationToken);
    }
}
