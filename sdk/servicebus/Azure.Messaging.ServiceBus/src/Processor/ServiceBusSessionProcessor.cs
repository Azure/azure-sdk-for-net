// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
    /// <remarks>
    /// The <see cref="ServiceBusSessionProcessor" /> is safe to cache and use for the lifetime of an application
    /// or until the <see cref="ServiceBusClient" /> that it was created by is disposed. Caching the processor
    /// is recommended when the application is processing messages regularly.  The sender is responsible for
    /// ensuring efficient network, CPU, and memory use. Calling <see cref="DisposeAsync" /> on the
    /// associated <see cref="ServiceBusClient" /> as the application is shutting down will ensure that
    /// network resources and other unmanaged objects used by the processor are properly cleaned up.
    /// </remarks>
    public class ServiceBusSessionProcessor : IAsyncDisposable
    {
        /// <summary>
        /// The <see cref="ServiceBusProcessor"/> that the session processor delegates to.
        /// This can be overriden for testing purposes.
        /// </summary>
        protected internal virtual ServiceBusProcessor InnerProcessor { get; }

        /// <inheritdoc cref="ServiceBusProcessor.EntityPath"/>
        public virtual string EntityPath => InnerProcessor.EntityPath;

        /// <summary>
        /// Gets the Identifier used to identify this processor client.  If <c>null</c> or empty, a random unique value will be will be used.
        /// </summary>
        public virtual string Identifier => InnerProcessor.Identifier;

        /// <inheritdoc cref="ServiceBusProcessor.ReceiveMode"/>
        public virtual ServiceBusReceiveMode ReceiveMode => InnerProcessor.ReceiveMode;

        /// <inheritdoc cref="ServiceBusProcessor.PrefetchCount"/>
        public virtual int PrefetchCount => InnerProcessor.PrefetchCount;

        /// <inheritdoc cref="ServiceBusProcessor.IsProcessing"/>
        public virtual bool IsProcessing => InnerProcessor.IsProcessing;

        /// <inheritdoc cref="ServiceBusProcessor.AutoCompleteMessages"/>
        public virtual bool AutoCompleteMessages => InnerProcessor.AutoCompleteMessages;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusSessionProcessor"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the processor is closed; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsClosed => InnerProcessor.IsClosed;

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
        public virtual TimeSpan MaxAutoLockRenewalDuration => InnerProcessor.MaxAutoLockRenewalDuration;

        /// <summary>Gets the maximum number of sessions that will be processed concurrently by the processor.
        /// The default value is 8.</summary>
        public virtual int MaxConcurrentSessions => InnerProcessor.MaxConcurrentSessions;

        /// <summary>
        /// Gets the maximum number of calls to the callback the processor will initiate per session.
        /// Thus the total number of callbacks will be equal to MaxConcurrentSessions * MaxConcurrentCallsPerSession.
        /// The default value is 1.
        /// </summary>
        public virtual int MaxConcurrentCallsPerSession => InnerProcessor.MaxConcurrentCallsPerSession;

        /// <inheritdoc cref="ServiceBusProcessor.FullyQualifiedNamespace"/>
        public virtual string FullyQualifiedNamespace => InnerProcessor.FullyQualifiedNamespace;

        /// <summary>
        /// Gets the maximum amount of time to wait for a message to be received for the
        /// currently active session. After this time has elapsed, the processor will close the session
        /// and attempt to process another session.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        public virtual TimeSpan? SessionIdleTimeout => InnerProcessor.MaxReceiveWaitTime;

        internal ServiceBusSessionProcessor(
            ServiceBusConnection connection,
            string entityPath,
            ServiceBusSessionProcessorOptions options)
        {
            options ??= new ServiceBusSessionProcessorOptions();
            InnerProcessor = new ServiceBusProcessor(
                connection,
                entityPath,
                true,
                options.ToProcessorOptions(),
                options.SessionIds.ToArray(),
                options.MaxConcurrentSessions,
                options.MaxConcurrentCallsPerSession,
                this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionProcessor"/> class for mocking.
        /// </summary>
        protected ServiceBusSessionProcessor()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionProcessor"/> class for use with derived types.
        /// </summary>
        /// <param name="client">The client instance to use for the processor.</param>
        /// <param name="queueName">The queue to create a processor for.</param>
        /// <param name="options">The set of options to use when configuring the processor.</param>
        protected ServiceBusSessionProcessor(ServiceBusClient client, string queueName, ServiceBusSessionProcessorOptions options) :
            this(client?.Connection, queueName,  options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusSessionProcessor"/> class for use with derived types.
        /// </summary>
        /// <param name="client">The client instance to use for the processor.</param>
        /// <param name="topicName">The topic to create a processor for.</param>
        /// <param name="subscriptionName">The subscription to create a processor for.</param>
        /// <param name="options">The set of options to use when configuring the processor.</param>
        protected ServiceBusSessionProcessor(ServiceBusClient client, string topicName, string subscriptionName, ServiceBusSessionProcessorOptions options) :
            this(client?.Connection, EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName),  options)
        {
        }

        /// <summary>
        /// Invokes the process message event handler after a message has been received.
        /// This method can be overriden to raise an event manually for testing purposes.
        /// </summary>
        /// <param name="args">The event args containing information related to the session message.</param>
        protected internal virtual async Task OnProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
        {
            await InnerProcessor.OnProcessSessionMessageAsync(args).ConfigureAwait(false);
        }

        /// <inheritdoc cref="ServiceBusProcessor.OnProcessErrorAsync(ProcessErrorEventArgs)"/>
        protected internal virtual async Task OnProcessErrorAsync(ProcessErrorEventArgs args)
        {
            await InnerProcessor.OnProcessErrorAsync(args).ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes the session open event handler when a new session is about to be processed.
        /// This method can be overriden to raise an event manually for testing purposes.
        /// </summary>
        /// <param name="args">The event args containing information related to the session.</param>
        protected internal virtual async Task OnSessionInitializingAsync(ProcessSessionEventArgs args)
        {
            await InnerProcessor.OnSessionInitializingAsync(args).ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes the session close event handler when a session is about to be closed for processing.
        /// This method can be overriden to raise an event manually for testing purposes.
        /// </summary>
        /// <param name="args">The event args containing information related to the session.</param>
        protected internal virtual async Task OnSessionClosingAsync(ProcessSessionEventArgs args)
        {
            await InnerProcessor.OnSessionClosingAsync(args).ConfigureAwait(false);
        }

        /// <summary>
        /// The handler responsible for processing messages received from the Queue or Subscription. Implementation is mandatory.
        /// </summary>
        /// <remarks>
        /// It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        /// a deadlock scenario.
        /// </remarks>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessSessionMessageEventArgs, Task> ProcessMessageAsync
        {
            add
            {
                InnerProcessor.ProcessSessionMessageAsync += value;
            }

            remove
            {
                InnerProcessor.ProcessSessionMessageAsync -= value;
            }
        }

        /// <summary>
        /// The handler responsible for processing unhandled exceptions thrown while this processor is running.
        /// Implementation is mandatory.
        /// </summary>
        /// <remarks>
        /// It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        /// a deadlock scenario.
        /// </remarks>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessErrorEventArgs, Task> ProcessErrorAsync
        {
            add
            {
                InnerProcessor.ProcessErrorAsync += value;
            }

            remove
            {
                InnerProcessor.ProcessErrorAsync -= value;
            }
        }

        /// <summary>
        /// Optional handler that can be set to be notified when a new session is about to be processed.
        /// </summary>
        /// <remarks>
        /// It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        /// a deadlock scenario.
        /// </remarks>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessSessionEventArgs, Task> SessionInitializingAsync
        {
            add
            {
                InnerProcessor.SessionInitializingAsync += value;
            }

            remove
            {
                InnerProcessor.SessionInitializingAsync -= value;
            }
        }

        /// <summary>
        /// Optional handler that can be set to be notified when a session is about to be closed for processing.
        /// This means that the most recent <see cref="ServiceBusReceiver.ReceiveMessageAsync"/> call timed out, or
        /// that <see cref="ProcessSessionMessageEventArgs.ReleaseSession"/> was called in the <see cref="ProcessMessageAsync"/> handler.
        /// </summary>
        /// <remarks>
        /// It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        /// a deadlock scenario.
        /// </remarks>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessSessionEventArgs, Task> SessionClosingAsync
        {
            add
            {
                InnerProcessor.SessionClosingAsync += value;
            }

            remove
            {
                InnerProcessor.SessionClosingAsync -= value;
            }
        }

        /// <inheritdoc cref="ServiceBusProcessor.StartProcessingAsync(CancellationToken)"/>
        public virtual async Task StartProcessingAsync(CancellationToken cancellationToken = default) =>
            await InnerProcessor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);

        /// <inheritdoc cref="ServiceBusProcessor.StopProcessingAsync(CancellationToken)"/>
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default) =>
            await InnerProcessor.StopProcessingAsync(cancellationToken).ConfigureAwait(false);

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
            await InnerProcessor.CloseAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSessionProcessor" />.
        ///   This is equivalent to calling <see cref="CloseAsync"/>.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            await CloseAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Updates the concurrency for the processor. This method can be used to dynamically change the concurrency of a running processor.
        /// </summary>
        /// <param name="maxConcurrentSessions">The new max concurrent sessions value. This will be reflected in the
        /// <see cref="ServiceBusSessionProcessor.MaxConcurrentSessions"/>property.</param>
        /// <param name="maxConcurrentCallsPerSession">The new max concurrent calls per session value. This will be reflect in the
        /// <see cref="ServiceBusSessionProcessor.MaxConcurrentCallsPerSession"/>.</param>
        public void UpdateConcurrency(int maxConcurrentSessions, int maxConcurrentCallsPerSession)
        {
            InnerProcessor.UpdateConcurrency(maxConcurrentSessions, maxConcurrentCallsPerSession);
        }

        /// <summary>
        /// Updates the prefetch count for the processor. This method can be used to dynamically change the prefetch count of a running processor.
        /// </summary>
        /// <param name="prefetchCount">The new prefetch count value. This will be reflected in the <see cref="ServiceBusProcessor.PrefetchCount"/>
        /// property.</param>
        public void UpdatePrefetchCount(int prefetchCount)
        {
            InnerProcessor.UpdatePrefetchCount(prefetchCount);
        }
    }
}
