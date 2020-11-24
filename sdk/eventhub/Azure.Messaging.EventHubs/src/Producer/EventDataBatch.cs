// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   A set of <see cref="EventData" /> with size constraints known up-front,
    ///   intended to be sent to the Event Hubs service in a single operation.
    ///   When published, the result is atomic; either all events that belong to the batch
    ///   were successful or all have failed.  Partial success is not possible.
    /// </summary>
    ///
    /// <remarks>
    ///   The operations for this class are thread-safe and will prevent changes when
    ///   actively being published to the Event Hubs service.
    /// </remarks>
    ///
    public sealed class EventDataBatch : IDisposable
    {
        /// <summary>An object instance to use as the synchronization root for ensuring the thread-safety of operations.</summary>
        private readonly object SyncGuard = new object();

        /// <summary>A flag indicating that the batch is locked, such as when in use during a publish operation.</summary>
        private bool _locked;

        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
        ///   well as any overhead for the batch itself when sent to the Event Hubs service.
        /// </summary>
        ///
        public long MaximumSizeInBytes => InnerBatch.MaximumSizeInBytes;

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
        ///   service.
        /// </summary>
        ///
        public long SizeInBytes => InnerBatch.SizeInBytes;

        /// <summary>
        ///   The publishing sequence number assigned to the first event in the batch at the time
        ///   the batch was successfully published.
        /// </summary>
        ///
        /// <value>
        ///   The sequence number of the first event in the batch, if the batch was successfully
        ///   published by a sequence-aware producer.  If the producer was not configured to apply
        ///   sequence numbering or if the batch has not yet been successfully published, this member
        ///   will be <c>null</c>.
        /// </value>
        ///
        /// <remarks>
        ///   The starting published sequence number is only populated and relevant when certain features
        ///   of the producer are enabled.  For example, it is used by idempotent publishing.
        /// </remarks>
        ///
        public int? StartingPublishedSequenceNumber { get; internal set; }

        /// <summary>
        ///   The count of events contained in the batch.
        /// </summary>
        ///
        public int Count => InnerBatch.Count;

        /// <summary>
        ///   The set of options that should be used when publishing the batch.
        /// </summary>
        ///
        internal SendEventOptions SendOptions { get; }

        /// <summary>
        ///   The transport-specific batch responsible for performing the batch operations
        ///   in a manner compatible with the associated <see cref="TransportProducer" />.
        /// </summary>
        ///
        private TransportEventBatch InnerBatch { get; }

        /// <summary>
        ///   The fully qualified Event Hubs namespace that the batch is associated with.  To be used
        ///   during instrumentation.
        /// </summary>
        ///
        private string FullyQualifiedNamespace { get; }

        /// <summary>
        ///   The name of the Event Hub that the batch is associated with, specific to the
        ///   Event Hubs namespace that contains it.  To be used during instrumentation.
        /// </summary>
        ///
        private string EventHubName { get; }

        /// <summary>
        ///   The list of diagnostic identifiers of events added to this batch.  To be used during
        ///   instrumentation.
        /// </summary>
        ///
        private List<string> EventDiagnosticIdentifiers { get; } = new List<string>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventDataBatch"/> class.
        /// </summary>
        ///
        /// <param name="transportBatch">The  transport-specific batch responsible for performing the batch operations.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to use for instrumentation.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the events with during instrumentation.</param>
        /// <param name="sendOptions">The set of options that should be used when publishing the batch.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        internal EventDataBatch(TransportEventBatch transportBatch,
                                string fullyQualifiedNamespace,
                                string eventHubName,
                                SendEventOptions sendOptions)
        {
            Argument.AssertNotNull(transportBatch, nameof(transportBatch));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(sendOptions, nameof(sendOptions));

            InnerBatch = transportBatch;
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            EventHubName = eventHubName;
            SendOptions = sendOptions;
        }

        /// <summary>
        ///   Attempts to add an event to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="eventData">The event to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the event was added; otherwise, <c>false</c>.</returns>
        ///
        public bool TryAdd(EventData eventData)
        {
            lock (SyncGuard)
            {
                AssertNotLocked();

                eventData = eventData.Clone();
                EventDataInstrumentation.InstrumentEvent(eventData, FullyQualifiedNamespace, EventHubName);

                var added = InnerBatch.TryAdd(eventData);

                if ((added) && (EventDataInstrumentation.TryExtractDiagnosticId(eventData, out string diagnosticId)))
                {
                    EventDiagnosticIdentifiers.Add(diagnosticId);
                }

                return added;
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventDataBatch" />.
        /// </summary>
        ///
        public void Dispose()
        {
            lock (SyncGuard)
            {
                AssertNotLocked();
                InnerBatch.Dispose();
            }
        }

        /// <summary>
        ///   Clears the batch, removing all events and resetting the
        ///   available size.
        /// </summary>
        ///
        internal void Clear()
        {
            lock (SyncGuard)
            {
                AssertNotLocked();
                InnerBatch.Clear();
            }
        }

        /// <summary>
        ///   Represents the batch as an enumerable set of specific representations of an event.
        /// </summary>
        ///
        /// <typeparam name="T">The specific event representation being requested.</typeparam>
        ///
        /// <returns>The set of events as an enumerable of the requested type.</returns>
        ///
        internal IEnumerable<T> AsEnumerable<T>() => InnerBatch.AsEnumerable<T>();

        /// <summary>
        ///   Gets the list of diagnostic identifiers of events added to this batch.
        /// </summary>
        ///
        /// <returns>A read-only list of diagnostic identifiers.</returns>
        ///
        internal IReadOnlyList<string> GetEventDiagnosticIdentifiers() => EventDiagnosticIdentifiers;

        /// <summary>
        ///   Locks the batch to prevent new events from being added while a service
        ///   operation is active.
        /// </summary>
        ///
        internal void Lock()
        {
            lock (SyncGuard)
            {
                _locked = true;
            }
        }

        /// <summary>
        ///   Unlocks the batch, allowing new events to be added.
        /// </summary>
        ///
        internal void Unlock()
        {
            lock (SyncGuard)
            {
                _locked = false;
            }
        }

        /// <summary>
        ///   Validates that the batch is not in a locked state, triggering an
        ///   invalid operation if it is.
        /// </summary>
        ///
        /// <exception cref="InvalidOperationException">Occurs when the batch is locked.</exception>
        ///
        private void AssertNotLocked()
        {
            if (_locked)
            {
                throw new InvalidOperationException(Resources.EventBatchIsLocked);
            }
        }
    }
}
