// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusProcessor"/> provides an abstraction around a set of <see cref="ServiceBusReceiver"/>
    /// that allows using an event based model for processing received <see cref="ServiceBusReceivedMessage" />.
    /// It is constructed by calling <see cref="ServiceBusClient.CreateProcessor(string, ServiceBusProcessorOptions)"/>.
    /// The message handler is specified with the <see cref="ProcessMessageAsync"/>
    /// property. The error handler is specified with the <see cref="ProcessErrorAsync"/> property.
    /// To start processing after the handlers have been specified, call <see cref="StartProcessingAsync"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="ServiceBusProcessor" /> is safe to cache and use for the lifetime of an application
    /// or until the <see cref="ServiceBusClient" /> that it was created by is disposed. Caching the processor
    /// is recommended when the application is processing messages regularly.  The sender is responsible for
    /// ensuring efficient network, CPU, and memory use. Calling <see cref="DisposeAsync" /> on the
    /// associated <see cref="ServiceBusClient" /> as the application is shutting down will ensure that
    /// network resources and other unmanaged objects used by the processor are properly cleaned up.
    /// </remarks>
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    public class ServiceBusProcessor : IAsyncDisposable
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private Func<ProcessMessageEventArgs, Task> _processMessageAsync;

        private Func<ProcessSessionMessageEventArgs, Task> _processSessionMessageAsync;

        private Func<ProcessErrorEventArgs, Task> _processErrorAsync;

        internal Func<ProcessSessionEventArgs, Task> _sessionInitializingAsync;

        internal Func<ProcessSessionEventArgs, Task> _sessionClosingAsync;

        // we use int.MaxValue as the maxCount since the concurrency can be changed dynamically by the user
        private readonly SemaphoreSlim _messageHandlerSemaphore = new SemaphoreSlim(0, int.MaxValue);

        private readonly object _optionsLock = new();

        /// <summary>
        /// The primitive for ensuring that the service is not overloaded with
        /// accept session requests.
        /// </summary>
        private readonly SemaphoreSlim _maxConcurrentAcceptSessionsSemaphore = new(0, int.MaxValue);

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim _processingStartStopSemaphore = new(1, 1);

        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        private Task ActiveReceiveTask { get; set; }

        /// <summary>
        /// Gets the fully qualified Service Bus namespace that the receiver is associated with. This is likely
        /// to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        public virtual string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        /// Gets the path of the Service Bus entity that the processor is connected to, specific to the
        /// Service Bus namespace that contains it.
        /// </summary>
        public virtual string EntityPath { get; }

        /// <summary>
        /// Gets the ID used to identify this processor. This can be used to correlate logs and exceptions.
        /// </summary>
        public virtual string Identifier => Options.Identifier;

        /// <summary>
        /// Gets the <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        /// <value>
        /// The receive mode is specified using <see cref="ServiceBusProcessorOptions.ReceiveMode"/>
        /// and has a default mode of <see cref="ServiceBusReceiveMode.PeekLock"/>.
        /// </value>
        public virtual ServiceBusReceiveMode ReceiveMode => Options.ReceiveMode;

        /// <summary>
        /// Gets whether the processor is configured to process session entities.
        /// </summary>
        internal bool IsSessionProcessor { get; }

        /// <summary>
        /// Gets the number of messages that will be eagerly requested from Queues or Subscriptions
        /// during processing. This is intended to help maximize throughput by allowing the
        /// processor to receive from a local cache rather than waiting on a service request.
        /// </summary>
        /// <value>
        /// The prefetch count is specified using <see cref="ServiceBusProcessorOptions.PrefetchCount"/>
        /// and has a default value of 0.
        /// </value>
        public virtual int PrefetchCount => Options.PrefetchCount;

        /// <summary>
        /// Gets whether or not this processor is currently processing messages.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the processor is processing messages; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsProcessing => ActiveReceiveTask != null;

        internal ServiceBusProcessorOptions Options { get; }

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        internal readonly ServiceBusConnection Connection;

        /// <summary>Gets the maximum number of concurrent calls to the
        /// <see cref="ProcessMessageAsync"/> message handler the processor should initiate.
        /// </summary>
        /// <value>
        /// The number of maximum concurrent calls is specified using <see cref="ServiceBusProcessorOptions.MaxConcurrentCalls"/>
        /// and has a default value of 1.
        /// </value>
        public virtual int MaxConcurrentCalls => Options.MaxConcurrentCalls;
        private int _currentConcurrentCalls;

        internal int MaxConcurrentSessions => _maxConcurrentSessions;
        private volatile int _maxConcurrentSessions;
        private int _currentConcurrentSessions;

        internal int MaxConcurrentCallsPerSession => _maxConcurrentCallsPerSession;
        private volatile int _maxConcurrentCallsPerSession;

        private int _currentAcceptSessions;

        internal TimeSpan? MaxReceiveWaitTime => Options.MaxReceiveWaitTime;

        /// <summary>
        /// Gets a value that indicates whether the processor should automatically
        /// complete messages after the message handler has completed processing. If the
        /// message handler triggers an exception, the message will not be automatically
        /// completed.
        /// </summary>
        /// <remarks>
        /// If the message handler triggers an exception and did not settle the message,
        /// then the message will be automatically abandoned, irrespective of <see cref= "AutoCompleteMessages" />.
        /// </remarks>
        /// <value>
        /// The option to auto complete messages is specified using <see cref="ServiceBusProcessorOptions.AutoCompleteMessages"/>
        /// and has a default value of <c>true</c>.
        /// </value>
        public virtual bool AutoCompleteMessages { get; }

        /// <summary>
        /// Gets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property.
        /// </summary>
        /// <remarks>The message renew can continue for sometime in the background
        /// after completion of message and result in a few false MessageLockLostExceptions temporarily.</remarks>
        /// <value>
        /// The maximum duration for lock renewal is specified using <see cref="ServiceBusProcessorOptions.MaxAutoLockRenewalDuration"/>
        /// and has a default value of 5 minutes.
        /// </value>
        public virtual TimeSpan MaxAutoLockRenewalDuration => Options.MaxAutoLockRenewalDuration;

        /// <summary>
        /// The instance of <see cref="ServiceBusEventSource" /> which can be mocked for testing.
        /// </summary>
        internal ServiceBusEventSource Logger { get; set; } = ServiceBusEventSource.Log;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusProcessor"/> has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the processor is closed; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsClosed
        {
            get => _closed;
            private set => _closed = value;
        }

        // If the user has listed named sessions, and they
        // have MaxConcurrentSessions greater or equal to the number
        // of sessions, we can leave the sessions open at all times
        // instead of cycling through them as receive calls time out.
        internal bool KeepOpenOnReceiveTimeout => _sessionIds.Length > 0 && _maxConcurrentSessions >= _sessionIds.Length;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        private readonly string[] _sessionIds;

        private readonly MessagingClientDiagnostics _clientDiagnostics;

        // deliberate usage of List instead of IList for faster enumeration and less allocations
        private readonly List<ReceiverManager> _receiverManagers = new List<ReceiverManager>();
        private readonly ServiceBusSessionProcessor _sessionProcessor;
        internal List<(Task Task, CancellationTokenSource Cts)> TaskTuples { get; private set; } = new();

        private readonly List<ReceiverManager> _orphanedReceiverManagers = new();
        private CancellationTokenSource _handlerCts = new();
        private readonly int _processorCount = Environment.ProcessorCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusProcessor"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="entityPath">The queue name or subscription path to process messages from.</param>
        /// <param name="isSessionEntity">Whether or not the processor is associated with a session entity.</param>
        /// <param name="options">The set of options to use when configuring the processor.</param>
        /// <param name="sessionIds">An optional set of session Ids to limit processing to.
        /// Only applies if isSessionEntity is true.</param>
        /// <param name="maxConcurrentSessions">The max number of sessions that can be processed concurrently.
        /// Only applies if isSessionEntity is true.</param>
        /// <param name="maxConcurrentCallsPerSession">The max number of concurrent calls per session.
        /// Only applies if isSessionEntity is true.</param>
        /// <param name="sessionProcessor">If this is for a session processor, will contain the session processor instance.</param>
        internal ServiceBusProcessor(
            ServiceBusConnection connection,
            string entityPath,
            bool isSessionEntity,
            ServiceBusProcessorOptions options,
            string[] sessionIds = default,
            int maxConcurrentSessions = default,
            int maxConcurrentCallsPerSession = default,
            ServiceBusSessionProcessor sessionProcessor = default)
        {
            Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
            connection.ThrowIfClosed();

            Options = options?.Clone() ?? new ServiceBusProcessorOptions();
            Connection = connection;
            EntityPath = EntityNameFormatter.FormatEntityPath(entityPath, Options.SubQueue);
            Options.Identifier = string.IsNullOrEmpty(Options.Identifier) ? DiagnosticUtilities.GenerateIdentifier(EntityPath) : Options.Identifier;

            _maxConcurrentSessions = maxConcurrentSessions;
            _maxConcurrentCallsPerSession = maxConcurrentCallsPerSession;
            _sessionIds = sessionIds ?? Array.Empty<string>();
            _sessionProcessor = sessionProcessor;

            if (isSessionEntity)
            {
                Options.MaxConcurrentCalls = (_sessionIds.Length > 0
                    ? Math.Min(_sessionIds.Length, _maxConcurrentSessions)
                    : _maxConcurrentSessions) * _maxConcurrentCallsPerSession;
            }

            AutoCompleteMessages = Options.AutoCompleteMessages;

            IsSessionProcessor = isSessionEntity;
           _clientDiagnostics = new MessagingClientDiagnostics(
                DiagnosticProperty.DiagnosticNamespace,
                DiagnosticProperty.ResourceProviderNamespace,
                DiagnosticProperty.ServiceBusServiceContext,
                FullyQualifiedNamespace,
                EntityPath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusProcessor"/> class for mocking.
        /// </summary>
        protected ServiceBusProcessor()
        {
            // assign default options since some of the properties reach into the options
            Options = new ServiceBusProcessorOptions();
            _sessionIds = Array.Empty<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusProcessor"/> class for use with derived types.
        /// </summary>
        /// <param name="client">The client instance to use for the processor.</param>
        /// <param name="queueName">The name of the queue to processor from.</param>
        /// <param name="options">The set of options to use when configuring the processor.</param>
        protected ServiceBusProcessor(ServiceBusClient client, string queueName, ServiceBusProcessorOptions options) :
            this(client?.Connection, queueName, false, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusProcessor"/> class for use with derived types.
        /// </summary>
        /// <param name="client">The client instance to use for the processor.</param>
        /// <param name="topicName">The topic to create a processor for.</param>
        /// <param name="subscriptionName">The subscription to create a processor for.</param>
        /// <param name="options">The set of options to use when configuring the processor.</param>
        protected ServiceBusProcessor(ServiceBusClient client, string topicName, string subscriptionName,
            ServiceBusProcessorOptions options) :
            this(client?.Connection, EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName), false, options)
        {
        }

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// The handler responsible for processing messages received from the Queue
        /// or Subscription.
        /// Implementation is mandatory.
        /// </summary>
        /// <remarks>
        /// It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        /// a deadlock scenario.
        /// </remarks>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.",
            Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessMessageEventArgs, Task> ProcessMessageAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processMessageAsync != default)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }

                EnsureNotRunningAndInvoke(() => _processMessageAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processMessageAsync != value)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }

                EnsureNotRunningAndInvoke(() => _processMessageAsync = default);
            }
        }

        /// <summary>
        /// The handler responsible for processing messages received from the Queue
        /// or Subscription. Implementation is mandatory.
        /// </summary>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.",
            Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        internal event Func<ProcessSessionMessageEventArgs, Task> ProcessSessionMessageAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessSessionMessageAsync));

                if (_processSessionMessageAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processSessionMessageAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessSessionMessageAsync));

                if (_processSessionMessageAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processSessionMessageAsync = default);
            }
        }

        /// <summary>
        /// The handler responsible for processing unhandled exceptions thrown while
        /// this processor is running.
        /// Implementation is mandatory.
        /// </summary>
        /// <remarks>
        /// It is not recommended that the state of the processor be managed directly from within this handler; requesting to start or stop the processor may result in
        /// a deadlock scenario.
        /// </remarks>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.",
            Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessErrorEventArgs, Task> ProcessErrorAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != default)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != value)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = default);
            }
        }

        /// <summary>
        /// Optional handler that can be set to be notified when a new session is about to be processed.
        /// </summary>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.",
            Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        internal event Func<ProcessSessionEventArgs, Task> SessionInitializingAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(SessionInitializingAsync));

                if (_sessionInitializingAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _sessionInitializingAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(SessionInitializingAsync));
                if (_sessionInitializingAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _sessionInitializingAsync = default);
            }
        }

        /// <summary>
        /// Optional handler that can be set to be notified when a session is about to be closed for processing.
        /// This means that the most recent <see cref="ServiceBusReceiver.ReceiveMessageAsync"/> call timed out so there are currently no messages
        /// available to be received for the session.
        /// </summary>
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.",
            Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        internal event Func<ProcessSessionEventArgs, Task> SessionClosingAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(SessionClosingAsync));

                if (_sessionClosingAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _sessionClosingAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(SessionClosingAsync));
                if (_sessionClosingAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _sessionClosingAsync = default);
            }
        }

        /// <summary>
        /// Invokes the process message event handler after a message has been received.
        /// This method can be overridden to raise an event manually for testing purposes.
        /// </summary>
        /// <param name="args">The event args containing information related to the message.</param>
        protected internal virtual async Task OnProcessMessageAsync(ProcessMessageEventArgs args)
        {
            try
            {
                await _processMessageAsync(args).ConfigureAwait(false);
            }
            finally
            {
                args.EndExecutionScope();
            }
        }

        /// <summary>
        /// Invokes the error event handler when an error has occurred during processing.
        /// This method can be overridden to raise an event manually for testing purposes.
        /// </summary>
        /// <param name="args">The event args containing information related to the error.</param>
        protected internal virtual async Task OnProcessErrorAsync(ProcessErrorEventArgs args)
        {
            await _processErrorAsync(args).ConfigureAwait(false);
        }

        internal async Task OnProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
        {
            try
            {
                await _processSessionMessageAsync(args).ConfigureAwait(false);
            }
            finally
            {
                args.EndExecutionScope();
            }
        }

        internal async Task OnSessionInitializingAsync(ProcessSessionEventArgs args)
        {
            await _sessionInitializingAsync(args).ConfigureAwait(false);
        }

        internal async Task OnSessionClosingAsync(ProcessSessionEventArgs args)
        {
            await _sessionClosingAsync(args).ConfigureAwait(false);
        }

        /// <summary>
        /// Signals the processor to begin processing messages. Should this method be
        /// called while the processor is already running, an
        /// <see cref="InvalidOperationException"/> is thrown.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to
        /// signal the request to cancel the start operation.  This won't affect the
        /// processor once it starts running.
        /// </param>
        /// <exception cref="InvalidOperationException">
        ///   This can occur if the processor is already running. This can be checked via the <see cref="IsProcessing"/> property.
        ///   This can also occur if event handlers have not been specified for the <see cref="ProcessMessageAsync"/> or
        ///   the <see cref="ProcessErrorAsync"/> events.
        /// </exception>
        public virtual async Task StartProcessingAsync(
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusProcessor));
            Connection.ThrowIfClosed();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            bool releaseGuard = false;
            try
            {
                await _processingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                releaseGuard = true;

                if (ActiveReceiveTask == null)
                {
                    Logger.StartProcessingStart(Identifier);

                    try
                    {
                        ValidateMessageHandler();
                        ValidateErrorHandler();
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // We expect the token source to be null, but we are playing safe.

                        RunningTaskTokenSource?.Cancel();
                        RunningTaskTokenSource?.Dispose();
                        RunningTaskTokenSource = new CancellationTokenSource();

                        // Start the main running task.
                        ActiveReceiveTask = RunReceiveTaskAsync(RunningTaskTokenSource.Token);
                    }
                    catch (Exception exception)
                    {
                        Logger.StartProcessingException(Identifier, exception.ToString());
                        throw;
                    }

                    Logger.StartProcessingComplete(Identifier);
                }
                else
                {
                    throw new InvalidOperationException(Resources.RunningMessageProcessorCannotPerformOperation);
                }
            }
            finally
            {
                if (releaseGuard)
                {
                    _processingStartStopSemaphore.Release();
                }
            }
        }

        private void ReconcileReceiverManagers(int maxConcurrentSessions, int prefetchCount)
        {
            if (_receiverManagers.Count == 0)
            {
                if (IsSessionProcessor)
                {
                    var numReceivers = _sessionIds.Length > 0 ? _sessionIds.Length : _maxConcurrentSessions;
                    for (int i = 0; i < numReceivers; i++)
                    {
                        var sessionId = _sessionIds.Length > 0 ? _sessionIds[i] : null;

                        _receiverManagers.Add(
                            new SessionReceiverManager(
                                _sessionProcessor,
                                sessionId,
                                _maxConcurrentAcceptSessionsSemaphore,
                                _clientDiagnostics,
                                KeepOpenOnReceiveTimeout));
                    }
                }
                else
                {
                    _receiverManagers.Add(
                        new ReceiverManager(
                            this,
                            _clientDiagnostics,
                            false));
                }
            }
            else
            {
                if (IsSessionProcessor && _sessionIds.Length == 0)
                {
                    var diffSessions = maxConcurrentSessions - _currentConcurrentSessions;

                    if (diffSessions > 0)
                    {
                        for (int i = 0; i < diffSessions; i++)
                        {
                            _receiverManagers.Add(
                                new SessionReceiverManager(
                                    _sessionProcessor,
                                    null,
                                    _maxConcurrentAcceptSessionsSemaphore,
                                    _clientDiagnostics,
                                    KeepOpenOnReceiveTimeout));
                        }
                    }
                    else
                    {
                        int diffSessionsLimit = Math.Abs(diffSessions);
                        for (int i = 0; i < diffSessionsLimit; i++)
                        {
                            // These should generally be closed as part of the normal bookkeeping in SessionReceiverManager,
                            // but we will track them so that they can be explicitly closed when stopping, just like we do with
                            // _receiverManagers.
                            _orphanedReceiverManagers.Add(_receiverManagers[0]);

                            // these tasks will be awaited when closing the orphaned receivers as part of CloseAsync
                            _ = _receiverManagers[0].CancelAsync();
                            _receiverManagers.RemoveAt(0);
                        }
                    }
                }

                int receiverManagers = _receiverManagers.Count;
                for (int i = 0; i < receiverManagers; i++)
                {
                    var receiverManager = _receiverManagers[i];
                    receiverManager.UpdatePrefetchCount(prefetchCount);
                }
            }
        }

        private void ValidateErrorHandler()
        {
            if (_processErrorAsync == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessErrorAsync)));
            }
        }

        private void ValidateMessageHandler()
        {
            if (IsSessionProcessor)
            {
                if (_processSessionMessageAsync == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                        Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessMessageAsync)));
                }
            }
            else if (_processMessageAsync == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessMessageAsync)));
            }
        }

        /// <summary>
        /// Signals the processor to stop processing messaging. Should this method be
        /// called while the processor is not running, no action is taken. This method
        /// will not close the underlying receivers, but will cause the receivers to stop
        /// receiving. Any in-flight message handlers will be awaited, and this method will not return
        /// until all in-flight message handlers have returned. To close the underlying receivers, <see cref="CloseAsync"/>
        /// should be called. If <see cref="CloseAsync"/> is called, the processor cannot be restarted.
        /// If you wish to resume processing at some point after calling this method, you can call
        /// <see cref="StartProcessingAsync"/>.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to
        /// signal the request to cancel the stop operation. If the operation is successfully
        /// canceled, the processor will keep running.</param>
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default)
        {
            bool releaseGuard = false;
            try
            {
                await _processingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                releaseGuard = true;

                if (ActiveReceiveTask != null)
                {
                    Logger.StopProcessingStart(Identifier);
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    // Cancel the current running task. Catch any exception that are triggered due to customer token registrations, and
                    // log these as warnings as we don't want to forego stopping due to these exceptions.
                    try
                    {
                        RunningTaskTokenSource.Cancel();
                    }
                    catch (Exception exception)
                    {
                        Logger.ProcessorStoppingCancellationWarning(Identifier, exception.ToString());
                    }

                    RunningTaskTokenSource.Dispose();
                    RunningTaskTokenSource = null;

                    // Now that a cancellation request has been issued, wait for the running task to finish.  In case something
                    // unexpected happened and it stopped working midway, this is the moment we expect to catch an exception.
                    try
                    {
                        await ActiveReceiveTask.ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Nothing to do here.  These exceptions are expected.
                    }
                    finally
                    {
                        // If an unexpected exception occurred while awaiting the receive task, we still want to dispose and set to null
                        // as the task is complete and there is no use in awaiting it again if StopProcessingAsync is called again.
                        ActiveReceiveTask.Dispose();
                        ActiveReceiveTask = null;
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.StopProcessingException(Identifier, exception.ToString());
                throw;
            }
            finally
            {
                if (releaseGuard)
                {
                    _processingStartStopSemaphore.Release();
                }
            }

            Logger.StopProcessingComplete(Identifier);
        }

        /// <summary>
        /// Runs the Receive task in as many threads as are
        /// specified in the <see cref="MaxConcurrentCalls"/> property.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        private async Task RunReceiveTaskAsync(CancellationToken cancellationToken)
        {
            CancellationTokenSource linkedHandlerTcs = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _handlerCts.Token);

            try
            {
                while (!cancellationToken.IsCancellationRequested && !Connection.IsClosed)
                {
                    await ReconcileConcurrencyAsync().ConfigureAwait(false);

                    foreach (ReceiverManager receiverManager in _receiverManagers)
                    {
                        // reset the linkedHandlerTcs if it was already cancelled due to user updating the concurrency
                        // do this before the synchronous Wait call as that does not respect the TCS.
                        if (linkedHandlerTcs.IsCancellationRequested)
                        {
                            linkedHandlerTcs.Dispose();
                            linkedHandlerTcs = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _handlerCts.Token);
                            break;
                        }

                        // Do a quick synchronous check before we resort to async/await with the state-machine overhead.
                        if (!_messageHandlerSemaphore.Wait(0, CancellationToken.None))
                        {
                            try
                            {
                                await _messageHandlerSemaphore.WaitAsync(linkedHandlerTcs.Token).ConfigureAwait(false);
                            }
                            catch (OperationCanceledException)
                            {
                                linkedHandlerTcs.Dispose();
                                // reset the linkedHandlerTcs if it was already cancelled due to user updating the concurrency
                                linkedHandlerTcs = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _handlerCts.Token);
                                // allow the loop to wake up when tcs is signaled
                                break;
                            }
                        }

                        // hold onto all the tasks that we are starting so that when cancellation is requested,
                        // we can await them to make sure we surface any unexpected exceptions, i.e. exceptions
                        // other than TaskCanceledExceptions
                        // Instead of using the array overload which allocates an array, we use the overload that has two parameters
                        // and pass in CancellationToken.None. This should be safe since CanBeCanceled will return false.
                        var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, CancellationToken.None);

                        TaskTuples.Add(
                            (
                                ReceiveAndProcessMessagesAsync(receiverManager, linkedCts.Token),
                                linkedCts)
                        );

                        if (TaskTuples.Count > Options.MaxConcurrentCalls)
                        {
                            List<(Task Task, CancellationTokenSource Cts)> remaining = new();
                            foreach (var tuple in TaskTuples)
                            {
                                if (tuple.Task.IsCompleted)
                                {
                                    tuple.Cts.Dispose();
                                }
                                else
                                {
                                    remaining.Add(tuple);
                                }
                            }

                            TaskTuples = remaining;
                        }
                    }
                }

                // If the main loop is aborting due to the connection being canceled, then
                // force the processor to stop.
                if (!cancellationToken.IsCancellationRequested && Connection.IsClosed)
                {
                    Logger.ProcessorClientClosedException(Identifier);

                    // Because this is a highly unusual situation
                    // and goes against the goal of resiliency for the processor, surface
                    // a fatal exception with an explicit message detailing that processing
                    // will be stopped.
                    try
                    {
                        await OnProcessErrorAsync(
                                new ProcessErrorEventArgs(
                                    new ObjectDisposedException(nameof(ServiceBusConnection),
                                        Resources.DisposedConnectionMessageProcessorMustStop),
                                    ServiceBusErrorSource.Receive,
                                    FullyQualifiedNamespace,
                                    EntityPath,
                                    Identifier,
                                    cancellationToken))
                            .ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        // Don't bubble up exceptions raised from customer exception handler.
                        Logger.ProcessorErrorHandlerThrewException(ex.ToString(), Identifier);
                    }

                    // This call will deadlock if awaited, as StopProcessingAsync awaits
                    // completion of this task.  The processor is already known to be in a bad
                    // state and exceptions in StopProcessingAsync are likely and will be logged
                    // in that call.  There is little value in surfacing those expected exceptions
                    // to the customer error handler as well; allow StopProcessingAsync to run
                    // in a fire-and-forget manner.
                    _ = StopProcessingAsync(CancellationToken.None);
                }
            }
            finally
            {
                try
                {
                    // await all tasks using WhenAll so that we ensure every task finishes even if there are exceptions
                    // (rather than try/catch each await)
                    await Task.WhenAll(TaskTuples.Select(t => t.Task)).ConfigureAwait(false);
                }
                finally
                {
                    foreach (var (_, cts) in TaskTuples)
                    {
                        cts.Dispose();
                    }

                    TaskTuples.Clear();

                    linkedHandlerTcs.Dispose();
                }
            }
        }

        private async Task ReceiveAndProcessMessagesAsync(
            ReceiverManager receiverManager,
            CancellationToken cancellationToken)
        {
            try
            {
                await receiverManager.ReceiveAndProcessMessagesAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _messageHandlerSemaphore.Release();
            }
        }

        /// <summary>
        /// Invokes a specified action only if this <see cref="ServiceBusProcessor" /> instance is not running.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        /// <exception cref="InvalidOperationException">Method is invoked while the event processor is running.</exception>
        internal void EnsureNotRunningAndInvoke(Action action)
        {
            if (ActiveReceiveTask == null)
            {
                try
                {
                    _processingStartStopSemaphore.Wait();
                    if (ActiveReceiveTask == null)
                    {
                        action?.Invoke();
                    }
                    else
                    {
                        throw new InvalidOperationException(Resources.RunningMessageProcessorCannotPerformOperation);
                    }
                }
                finally
                {
                    _processingStartStopSemaphore.Release();
                }
            }
            else
            {
                throw new InvalidOperationException(Resources.RunningMessageProcessorCannotPerformOperation);
            }
        }

        /// <summary>
        /// Performs the task needed to clean up resources used by the <see cref="ServiceBusProcessor" />. Any in-flight message handlers will
        /// be awaited. Once all message handling has completed, the underlying links will be closed. After this point, the method will return.
        /// This is equivalent to calling <see cref="DisposeAsync"/>.
        /// </summary>
        /// <param name="cancellationToken"> An optional<see cref="CancellationToken"/> instance to signal the
        /// request to cancel the operation.</param>
        public virtual async Task CloseAsync(
            CancellationToken cancellationToken = default)
        {
            IsClosed = true;

            if (IsProcessing)
            {
                await StopProcessingAsync(cancellationToken).ConfigureAwait(false);
            }

            foreach (ReceiverManager receiverManager in _receiverManagers.Concat(_orphanedReceiverManagers))
            {
                await receiverManager.CloseReceiverIfNeeded(cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Performs the task needed to clean up resources used by the <see cref="ServiceBusProcessor" />. Any in-flight message handlers will
        /// be awaited. Once all message handling has completed, the underlying links will be closed. After this point, the method will return.
        /// This is equivalent to calling <see cref="CloseAsync"/>.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            await CloseAsync().ConfigureAwait(false);
            _handlerCts.Dispose();
            _messageHandlerSemaphore.Dispose();
            _maxConcurrentAcceptSessionsSemaphore.Dispose();
            _processingStartStopSemaphore.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Updates the concurrency for the processor. This method can be used to dynamically change the concurrency of a running processor.
        /// </summary>
        /// <param name="maxConcurrentCalls">The new max concurrent calls value. This will be reflected in the <see cref="ServiceBusProcessor.MaxConcurrentCalls"/>
        /// property.</param>
        public void UpdateConcurrency(int maxConcurrentCalls)
        {
            lock (_optionsLock)
            {
                Options.MaxConcurrentCalls = maxConcurrentCalls;
                WakeLoop();
            }
        }

        /// <summary>
        /// Updates the prefetch count for the processor. This method can be used to dynamically change the prefetch count of a running processor.
        /// </summary>
        /// <param name="prefetchCount">The new prefetch count value. This will be reflected in the <see cref="ServiceBusProcessor.PrefetchCount"/>
        /// property.</param>
        public void UpdatePrefetchCount(int prefetchCount)
        {
            lock (_optionsLock)
            {
                Options.PrefetchCount = prefetchCount;
                WakeLoop();
            }
        }

        internal void UpdateConcurrency(int maxConcurrentSessions, int maxConcurrentCallsPerSession)
        {
            Argument.AssertAtLeast(maxConcurrentSessions, 1, nameof(maxConcurrentSessions));
            Argument.AssertAtLeast(maxConcurrentCallsPerSession, 1, nameof(maxConcurrentCallsPerSession));

            lock (_optionsLock)
            {
                Options.MaxConcurrentCalls = (_sessionIds.Length > 0
                    ? Math.Min(_sessionIds.Length, maxConcurrentSessions)
                    : maxConcurrentSessions) * maxConcurrentCallsPerSession;
                _maxConcurrentSessions = maxConcurrentSessions;
                _maxConcurrentCallsPerSession = maxConcurrentCallsPerSession;
                WakeLoop();
            }
        }

        private void WakeLoop()
        {
            // wake up the handler loop
            var handlerCts = Interlocked.Exchange(ref _handlerCts, new CancellationTokenSource());
            handlerCts.Cancel();
            handlerCts.Dispose();
        }

        private async Task ReconcileConcurrencyAsync()
        {
            int maxConcurrentCalls = 0;
            int maxConcurrentSessions = 0;
            int prefetchCount = 0;

            lock (_optionsLock)
            {
                // read synchronized values once to avoid race conditions
                maxConcurrentCalls = Options.MaxConcurrentCalls;
                prefetchCount = Options.PrefetchCount;
                maxConcurrentSessions = _maxConcurrentSessions;
            }

            int diff = maxConcurrentCalls - _currentConcurrentCalls;

            // increasing concurrency
            if (diff > 0)
            {
                _messageHandlerSemaphore.Release(diff);
            }
            // decreasing concurrency
            else if (diff < 0)
            {
                var activeTasks = TaskTuples.Where(t => !t.Task.IsCompleted).ToList();
                int excessTasks = activeTasks.Count - maxConcurrentCalls;

                // cancel excess tasks
                for (int i = 0; i < excessTasks; i++)
                {
                    activeTasks[i].Cts.Cancel();
                }

                int diffLimit = Math.Abs(diff);
                // limit the number of new tasks that can spawn to newly specified concurrency
                for (int i = 0; i < diffLimit; i++)
                {
                    await _messageHandlerSemaphore.WaitAsync().ConfigureAwait(false);
                }
            }

            if (IsSessionProcessor)
            {
                int maxAcceptSessions = Math.Min(maxConcurrentCalls, 2 * _processorCount);
                int diffAcceptSessions = maxAcceptSessions - _currentAcceptSessions;
                if (diffAcceptSessions > 0)
                {
                    _maxConcurrentAcceptSessionsSemaphore.Release(diffAcceptSessions);
                }
                else
                {
                    int diffAcceptLimit = Math.Abs(diffAcceptSessions);
                    for (int i = 0; i < diffAcceptLimit; i++)
                    {
                        await _maxConcurrentAcceptSessionsSemaphore.WaitAsync().ConfigureAwait(false);
                    }
                }
                _currentAcceptSessions = maxAcceptSessions;
            }

            ReconcileReceiverManagers(maxConcurrentSessions, prefetchCount);

            _currentConcurrentCalls = maxConcurrentCalls;
            _currentConcurrentSessions = maxConcurrentSessions;
        }
    }
}
