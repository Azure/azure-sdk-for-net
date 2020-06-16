// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusSessionProcessor"/> provides an abstraction around a set of <see cref="ServiceBusSessionReceiver"/> that
    /// allows using an event based model for processing received <see cref="ServiceBusReceivedMessage" />.
    /// It is constructed by calling <see cref="ServiceBusClient.CreateSessionProcessor(string, ServiceBusSessionProcessorOptions)"/>.
    /// The event handler is specified with the <see cref="ProcessMessageAsync"/>
    /// property. The error handler is specified with the <see cref="ProcessErrorAsync"/> property.
    /// To start processing after the handlers have been specified, call <see cref="StartProcessingAsync"/>.
    /// </summary>
    public class ServiceBusSessionProcessor
    {
        private readonly ServiceBusProcessor _innerProcessor;

        /// <summary>
        /// The path of the Service Bus entity that the processor is connected to, specific to the
        /// Service Bus namespace that contains it.
        /// </summary>
        public string EntityPath => _innerProcessor.EntityPath;

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID.</remarks>
        internal string Identifier => _innerProcessor.Identifier;

        /// <summary>
        /// The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        public ReceiveMode ReceiveMode => _innerProcessor.ReceiveMode;

        /// <summary>
        /// The number of messages that will be eagerly requested from Queues or Subscriptions and queued locally without regard to
        /// whether a processing is currently active, intended to help maximize throughput by allowing the receiver to receive
        /// from a local cache rather than waiting on a service request.
        /// </summary>
        public int PrefetchCount => _innerProcessor.PrefetchCount;

        /// <summary>
        /// Indicates whether or not this <see cref="ServiceBusSessionProcessor"/> is currently processing messages.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the client is processing messages; otherwise, <c>false</c>.
        /// </value>
        public bool IsProcessing => _innerProcessor.IsProcessing;

        /// <summary>Gets or sets a value that indicates whether the <see cref="ServiceBusSessionProcessor"/> should automatically
        /// complete messages after the event handler has completed processing. If the event handler
        /// triggers an exception, the message will not be automatically completed.</summary>
        ///
        /// <value>true to complete the message processing automatically on successful execution of the operation; otherwise, false.</value>
        public bool AutoComplete => _innerProcessor.AutoComplete;

        /// <summary>
        /// Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property.
        /// </summary>
        ///
        /// <value>The maximum duration during which locks are automatically renewed.</value>
        ///
        /// <remarks>The message renew can continue for sometime in the background
        /// after completion of message and result in a few false MessageLockLostExceptions temporarily.</remarks>
        public TimeSpan MaxAutoLockRenewalDuration => _innerProcessor.MaxAutoLockRenewalDuration;

        /// <summary>Gets or sets the maximum number of concurrent calls to the
        /// <see cref="ProcessMessageAsync"/> event handler the processor should initiate.
        /// </summary>
        ///
        /// <value>The maximum number of concurrent calls to the event handler.</value>
        public int MaxConcurrentCalls => _innerProcessor.MaxConcurrentCalls;

        /// <summary>
        /// The fully qualified Service Bus namespace that the receiver is associated with.  This is likely
        /// to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        public string FullyQualifiedNamespace => _innerProcessor.FullyQualifiedNamespace;

        /// <summary>
        /// The maximum amount of time to wait for each Receive call using the processor's underlying receiver. If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        public TimeSpan? MaxReceiveWaitTime => _innerProcessor.MaxReceiveWaitTime;

        internal ServiceBusSessionProcessor(
            ServiceBusConnection connection,
            string entityPath,
            ServiceBusSessionProcessorOptions options)
        {
            _innerProcessor = new ServiceBusProcessor(
                connection,
                entityPath,
                true,
                options.ToProcessorOptions(),
                options.SessionIds);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionProcessor"/> class for mocking.
        /// </summary>
        protected ServiceBusSessionProcessor()
        {
        }

        /// <summary>
        /// The event responsible for processing messages received from the Queue or Subscription. Implementation
        /// is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessSessionMessageEventArgs, Task> ProcessMessageAsync
        {
            add
            {
                _innerProcessor.ProcessSessionMessageAsync += value;

            }

            remove
            {
                _innerProcessor.ProcessSessionMessageAsync -= value;
            }
        }

        /// <summary>
        /// The event responsible for processing unhandled exceptions thrown while this processor is running.
        /// Implementation is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessErrorEventArgs, Task> ProcessErrorAsync
        {
            add
            {
                _innerProcessor.ProcessErrorAsync += value;
            }

            remove
            {
                _innerProcessor.ProcessErrorAsync -= value;
            }
        }

        /// <summary>
        /// Optional event that can be set to be notified when a new session is about to be processed.
        /// </summary>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessSessionEventArgs, Task> SessionInitializingAsync
        {
            add
            {
                _innerProcessor.SessionInitializingAsync += value;

            }

            remove
            {
                _innerProcessor.SessionInitializingAsync -= value;
            }
        }

        /// <summary>
        /// Optional event that can be set to be notified when a session is about to be closed for processing.
        /// This means that the most recent <see cref="ServiceBusReceiver.ReceiveMessageAsync"/> call timed out,
        /// so there are currently no messages available to be received for the session.
        /// </summary>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessSessionEventArgs, Task> SessionClosingAsync
        {
            add
            {
                _innerProcessor.SessionClosingAsync += value;
            }

            remove
            {
                _innerProcessor.SessionClosingAsync -= value;
            }
        }

        /// <summary>
        /// Signals the <see cref="ServiceBusSessionProcessor" /> to begin processing messages. Should this method be called while the processor
        /// is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="ServiceBusSessionProcessor" /> once it starts running.</param>
        public virtual async Task StartProcessingAsync(CancellationToken cancellationToken = default) =>
            await _innerProcessor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Signals the <see cref="ServiceBusSessionProcessor" /> to stop processing events. Should this method be called while the processor
        /// is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="ServiceBusSessionProcessor" /> will keep running.</param>
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default) =>
            await _innerProcessor.StopProcessingAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
