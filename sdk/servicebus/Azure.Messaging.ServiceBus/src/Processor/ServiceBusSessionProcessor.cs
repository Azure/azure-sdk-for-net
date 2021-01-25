// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Plugins;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusSessionProcessor"/> provides an abstraction around a set of <see cref="ServiceBusSessionReceiver"/> that
    /// allows using an event based model for processing received <see cref="ServiceBusReceivedMessage" />.
    /// It is constructed by calling <see cref="ServiceBusClient.CreateSessionProcessor(string, ServiceBusSessionProcessorOptions)"/>.
    /// The message handler is specified with the <see cref="ProcessMessageAsync"/>
    /// property. The error handler is specified with the <see cref="ProcessErrorAsync"/> property.
    /// To start processing after the handlers have been specified, call <see cref="StartProcessingAsync"/>.
    /// </summary>
    public class ServiceBusSessionProcessor : IAsyncDisposable
    {
        private readonly ServiceBusProcessor _innerProcessor;

        /// <inheritdoc cref="ServiceBusProcessor.EntityPath"/>
        public string EntityPath => _innerProcessor.EntityPath;

        /// <summary>
        /// Gets the ID to identify this processor. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new processor has a unique ID.</remarks>
        internal string Identifier => _innerProcessor.Identifier;

        /// <inheritdoc cref="ServiceBusProcessor.ReceiveMode"/>
        public ServiceBusReceiveMode ReceiveMode => _innerProcessor.ReceiveMode;

        /// <inheritdoc cref="ServiceBusProcessor.PrefetchCount"/>
        public int PrefetchCount => _innerProcessor.PrefetchCount;

        /// <inheritdoc cref="ServiceBusProcessor.IsProcessing"/>
        public bool IsProcessing => _innerProcessor.IsProcessing;

        /// <inheritdoc cref="ServiceBusProcessor.AutoCompleteMessages"/>
        public bool AutoCompleteMessages => _innerProcessor.AutoCompleteMessages;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusSessionProcessor"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the processor is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed => _innerProcessor.IsClosed;

        /// <summary>
        /// Gets the maximum duration within which the session lock will be
        /// renewed automatically.
        /// </summary>
        ///
        /// <value>The maximum duration during which session locks are automatically renewed.</value>
        ///
        /// <remarks>The session lock renewal can continue for sometime in the background
        /// after completion of message and result in a few false SessionLockLost exceptions temporarily.
        /// </remarks>
        public TimeSpan MaxAutoLockRenewalDuration => _innerProcessor.MaxAutoLockRenewalDuration;

        /// <summary>Gets the maximum number of sessions that will be processed concurrently by the processor.
        /// The default value is 8.</summary>
        public int MaxConcurrentSessions => _innerProcessor.MaxConcurrentSessions;

        /// <summary>
        /// Gets the maximum number of calls to the callback the processor will initiate per session.
        /// Thus the total number of callbacks will be equal to MaxConcurrentSessions * MaxConcurrentCallsPerSession.
        /// The default value is 1.
        /// </summary>
        public int MaxConcurrentCallsPerSession => _innerProcessor.MaxConcurrentCallsPerSession;

        /// <inheritdoc cref="ServiceBusProcessor.FullyQualifiedNamespace"/>
        public string FullyQualifiedNamespace => _innerProcessor.FullyQualifiedNamespace;

        internal ServiceBusSessionProcessor(
            ServiceBusConnection connection,
            string entityPath,
            IList<ServiceBusPlugin> plugins,
            ServiceBusSessionProcessorOptions options)
        {
            _innerProcessor = new ServiceBusProcessor(
                connection,
                entityPath,
                true,
                plugins,
                options.ToProcessorOptions(),
                options.SessionIds.ToArray(),
                options.MaxConcurrentSessions,
                options.MaxConcurrentCallsPerSession);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionProcessor"/> class for mocking.
        /// </summary>
        protected ServiceBusSessionProcessor()
        {
        }

        /// <summary>
        /// The handler responsible for processing messages received from the Queue or Subscription. Implementation is mandatory.
        /// </summary>
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
        /// The handler responsible for processing unhandled exceptions thrown while this processor is running.
        /// Implementation is mandatory.
        /// </summary>
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
        /// Optional handler that can be set to be notified when a new session is about to be processed.
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
        /// Optional handler that can be set to be notified when a session is about to be closed for processing.
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

        /// <inheritdoc cref="ServiceBusProcessor.StartProcessingAsync(CancellationToken)"/>
        public virtual async Task StartProcessingAsync(CancellationToken cancellationToken = default) =>
            await _innerProcessor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="ServiceBusProcessor.StopProcessingAsync(CancellationToken)"/>
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

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSessionProcessor" />.
        /// </summary>
        /// <param name="cancellationToken"> An optional<see cref="CancellationToken"/> instance to signal the
        /// request to cancel the operation.</param>
        public virtual async Task CloseAsync(
            CancellationToken cancellationToken = default) =>
            await _innerProcessor.CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSessionProcessor" />.
        ///   This is equivalent to calling <see cref="CloseAsync"/> with the default <see cref="LinkCloseMode"/>.
        /// </summary>
        public async ValueTask DisposeAsync() =>
            await CloseAsync().ConfigureAwait(false);
    }
}
