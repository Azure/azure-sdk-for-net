// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The <see cref="ServiceBusProcessor"/> provides an abstraction around a set of <see cref="ServiceBusReceiver"/> that
    /// allows using an event based model for processing received <see cref="ServiceBusReceivedMessage" />. It is constructed by calling
    /// <see cref="ServiceBusClient.CreateProcessor(string, ServiceBusProcessorOptions)"/>.
    /// The event handler is specified with the <see cref="ProcessMessageAsync"/>
    /// property. The error handler is specified with the <see cref="ProcessErrorAsync"/> property.
    /// To start processing after the handlers have been specified, call <see cref="StartProcessingAsync"/>.
    /// </summary>
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    public class ServiceBusProcessor
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private Func<ProcessMessageEventArgs, Task> _processMessageAsync;

        private Func<ProcessSessionMessageEventArgs, Task> _processSessionMessageAsync;

        private Func<ProcessErrorEventArgs, Task> _processErrorAsync = default;

        private Func<ProcessSessionEventArgs, Task> _sessionInitializingAsync;

        private Func<ProcessSessionEventArgs, Task> _sessionClosingAsync;

        private SemaphoreSlim MessageHandlerSemaphore;

        /// <summary>
        ///
        /// </summary>
        private SemaphoreSlim MaxConcurrentAcceptSessionsSemaphore { get; set; }

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim ProcessingStartStopSemaphore = new SemaphoreSlim(1, 1);

        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        private Task ActiveReceiveTask { get; set; }

        /// <summary>
        /// The fully qualified Service Bus namespace that the receiver is associated with.  This is likely
        /// to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        public string FullyQualifiedNamespace => _connection.FullyQualifiedNamespace;

        /// <summary>
        /// The path of the Service Bus entity that the processor is connected to, specific to the
        /// Service Bus namespace that contains it.
        /// </summary>
        public string EntityPath { get; private set; }

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID.</remarks>
        internal string Identifier { get; private set; }

        /// <summary>
        /// The <see cref="ReceiveMode"/> used to specify how messages are received. Defaults to PeekLock mode.
        /// </summary>
        public ReceiveMode ReceiveMode { get; }

        /// <summary>
        /// Indicates whether the processor is configured to process session entities.
        /// </summary>
        internal bool IsSessionProcessor { get; }

        /// <summary>
        /// The number of messages that will be eagerly requested from Queues or Subscriptions
        /// during processing. This is intended to help maximize throughput by allowing the
        /// processor to receive from a local cache rather than waiting on a service request.
        /// </summary>
        public int PrefetchCount { get; }

        /// <summary>
        /// Indicates whether or not this <see cref="ServiceBusProcessor"/> is currently processing messages.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the client is processing messages; otherwise, <c>false</c>.
        /// </value>
        public bool IsProcessing => ActiveReceiveTask != null;

        private readonly ServiceBusProcessorOptions _options;

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        private readonly ServiceBusConnection _connection;

        /// <summary>Gets or sets the maximum number of concurrent calls to the
        /// <see cref="ProcessMessageAsync"/> event handler the processor should initiate.
        /// </summary>
        ///
        /// <value>The maximum number of concurrent calls to the event handler.</value>
        public int MaxConcurrentCalls
        {
            get => _maxConcurrentCalls;

            private set
            {
                _maxConcurrentCalls = value;
                _maxConcurrentAcceptSessions = Math.Min(value, 2 * Environment.ProcessorCount);
            }
        }

        /// <summary>
        /// The maximum amount of time to wait for each Receive call using the processor's underlying receiver. If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        public TimeSpan? MaxReceiveWaitTime { get; }

        private int _maxConcurrentCalls;
        private int _maxConcurrentAcceptSessions;

        private const int DefaultMaxConcurrentCalls = 1;
        private const int DefaultMaxConcurrentSessions = 8;

        /// <summary>Gets or sets a value that indicates whether the <see cref="ServiceBusProcessor"/> should automatically
        /// complete messages after the event handler has completed processing. If the event handler
        /// triggers an exception, the message will not be automatically completed.</summary>
        ///
        /// <value>true to complete the message processing automatically on successful execution of the operation; otherwise, false.</value>
        public bool AutoComplete { get; }

        /// <summary>
        /// Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property.
        /// </summary>
        ///
        /// <value>The maximum duration during which locks are automatically renewed.</value>
        ///
        /// <remarks>The message renew can continue for sometime in the background
        /// after completion of message and result in a few false MessageLockLostExceptions temporarily.</remarks>
        public TimeSpan MaxAutoLockRenewalDuration { get; }

        /// <summary>
        ///   The instance of <see cref="ServiceBusEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal ServiceBusEventSource Logger { get; set; } = ServiceBusEventSource.Log;

        private readonly string[] _sessionIds;
        private readonly EntityScopeFactory _scopeFactory;
        private readonly IList<ReceiverManager> _receiverManagers = new List<ReceiverManager>();

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessor"/> class.
        /// </summary>
        ///
        /// <param name="entityPath"></param>
        /// <param name="isSessionEntity"></param>
        /// <param name="sessionIds"></param>
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="options"></param>
        ///
        internal ServiceBusProcessor(
            ServiceBusConnection connection,
            string entityPath,
            bool isSessionEntity,
            ServiceBusProcessorOptions options,
            string[] sessionIds = default)
        {
            Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
            connection.ThrowIfClosed();

            _options = options?.Clone() ?? new ServiceBusProcessorOptions();
            _connection = connection;
            EntityPath = entityPath;
            Identifier = DiagnosticUtilities.GenerateIdentifier(EntityPath);

            ReceiveMode = _options.ReceiveMode;
            PrefetchCount = _options.PrefetchCount;
            MaxAutoLockRenewalDuration = _options.MaxAutoLockRenewalDuration;
            MaxConcurrentCalls = _options.MaxConcurrentCalls;
            if (MaxConcurrentCalls == 0)
            {
                MaxConcurrentCalls = isSessionEntity ? DefaultMaxConcurrentSessions : DefaultMaxConcurrentCalls;
            }
            MessageHandlerSemaphore = new SemaphoreSlim(
                MaxConcurrentCalls,
                MaxConcurrentCalls);

            MaxConcurrentAcceptSessionsSemaphore = new SemaphoreSlim(
                _maxConcurrentAcceptSessions,
                _maxConcurrentAcceptSessions);

            MaxReceiveWaitTime = _options.MaxReceiveWaitTime;
            AutoComplete = _options.AutoComplete;

            EntityPath = entityPath;
            IsSessionProcessor = isSessionEntity;
            _sessionIds = sessionIds ?? Array.Empty<string>();
            _scopeFactory = new EntityScopeFactory(EntityPath, FullyQualifiedNamespace);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusProcessor"/> class for mocking.
        /// </summary>
        protected ServiceBusProcessor()
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
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        /// The event responsible for processing messages received from the Queue or Subscription.
        /// Implementation is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
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
        /// The event responsible for processing messages received from the Queue or Subscription. Implementation
        /// is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        internal event Func<ProcessSessionMessageEventArgs, Task> ProcessSessionMessageAsync
        {
            add
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processSessionMessageAsync != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }
                EnsureNotRunningAndInvoke(() => _processSessionMessageAsync = value);

            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processSessionMessageAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processSessionMessageAsync = default);
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
        /// Optional event that can be set to be notified when a new session is about to be processed.
        /// </summary>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
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
        /// Optional event that can be set to be notified when a session is about to be closed for processing.
        /// This means that the most recent <see cref="ServiceBusReceiver.ReceiveMessageAsync"/> call timed out so there are currently no messages
        /// available to be received for the session.
        /// </summary>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
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
        /// Signals the <see cref="ServiceBusProcessor" /> to begin processing messages. Should this method be called while the processor
        /// is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="ServiceBusProcessor" /> once it starts running.</param>
        public virtual async Task StartProcessingAsync(
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            if (ActiveReceiveTask == null)
            {
                Logger.StartProcessingStart(Identifier);
                bool releaseGuard = false;

                try
                {
                    await ProcessingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                    releaseGuard = true;
                    ValidateMessageHandler();
                    ValidateErrorHandler();
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    InitializeReceiverManagers();

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
                finally
                {
                    if (releaseGuard)
                    {
                        ProcessingStartStopSemaphore.Release();
                    }
                }
                Logger.StartProcessingComplete(Identifier);
            }
            else
            {
                throw new InvalidOperationException(Resources.RunningMessageProcessorCannotPerformOperation);
            }
        }

        private void InitializeReceiverManagers()
        {
            if (IsSessionProcessor)
            {
                var numReceivers = _sessionIds.Length > 0 ? _sessionIds.Length : MaxConcurrentCalls;
                for (int i = 0; i < numReceivers; i++)
                {
                    var sessionId = _sessionIds.Length > 0 ? _sessionIds[i] : null;
                    _receiverManagers.Add(
                        new SessionReceiverManager(
                            _connection,
                            FullyQualifiedNamespace,
                            EntityPath,
                            Identifier,
                            sessionId,
                            _options,
                            _sessionInitializingAsync,
                            _sessionClosingAsync,
                            _processSessionMessageAsync,
                            _processErrorAsync,
                            MaxConcurrentAcceptSessionsSemaphore,
                            _scopeFactory));
                }
            }
            else
            {
                _receiverManagers.Add(
                    new ReceiverManager(
                        _connection,
                        FullyQualifiedNamespace,
                        EntityPath,
                        Identifier,
                        _options,
                        _processMessageAsync,
                        _processErrorAsync,
                        _scopeFactory));
            }
        }

        private void ValidateErrorHandler()
        {
            if (_processErrorAsync == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessErrorAsync)));
            }
        }

        private void ValidateMessageHandler()
        {
            if (IsSessionProcessor)
            {
                if (_processSessionMessageAsync == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessMessageAsync)));
                }
            }
            else if (_processMessageAsync == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessMessageAsync)));
            }
        }

        /// <summary>
        /// Signals the <see cref="ServiceBusProcessor" /> to stop processing events. Should this method be called while the processor
        /// is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="ServiceBusProcessor" /> will keep running.</param>
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default)
        {
            bool releaseGuard = false;
            try
            {
                if (ActiveReceiveTask != null)
                {
                    Logger.StopProcessingStart(Identifier);
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    await ProcessingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                    releaseGuard = true;

                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    // Cancel the current running task.

                    RunningTaskTokenSource.Cancel();
                    RunningTaskTokenSource.Dispose();
                    RunningTaskTokenSource = null;

                    // Now that a cancellation request has been issued, wait for the running task to finish.  In case something
                    // unexpected happened and it stopped working midway, this is the moment we expect to catch an exception.
                    try
                    {
                        await ActiveReceiveTask.ConfigureAwait(false);
                    }
                    catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException)
                    {
                        // Nothing to do here.  These exceptions are expected.
                    }

                    ActiveReceiveTask.Dispose();
                    ActiveReceiveTask = null;

                    foreach (ReceiverManager receiverManager in _receiverManagers)
                    {
                        await receiverManager.CloseReceiverIfNeeded(
                            cancellationToken,
                            forceClose: true)
                            .ConfigureAwait(false);
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
                    ProcessingStartStopSemaphore.Release();
                }
            }
            Logger.StopProcessingComplete(Identifier);
        }

        /// <summary>
        /// Runs the Receive task in as many threads as are
        /// specified in the <see cref="MaxConcurrentCalls"/> property.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        private async Task RunReceiveTaskAsync(
            CancellationToken cancellationToken)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (ReceiverManager receiverManager in _receiverManagers)
                    {
                        await MessageHandlerSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                        // hold onto all the tasks that we are starting so that when cancellation is requested,
                        // we can await them to make sure we surface any unexpected exceptions, i.e. exceptions
                        // other than TaskCanceledExceptions
                        tasks.Add(ReceiveAndProcessMessagesAsync(receiverManager, cancellationToken));
                    }
                    if (tasks.Count > MaxConcurrentCalls)
                    {
                        tasks.RemoveAll(t => t.IsCompleted);
                    }
                }
            }
            finally
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
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
                MessageHandlerSemaphore.Release();
            }
        }

        /// <summary>
        /// Invokes a specified action only if this <see cref="ServiceBusProcessor" /> instance is not running.
        /// </summary>
        ///
        /// <param name="action">The action to invoke.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked while the event processor is running.</exception>
        internal void EnsureNotRunningAndInvoke(Action action)
        {
            if (ActiveReceiveTask == null)
            {
                try
                {
                    ProcessingStartStopSemaphore.Wait();
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
                    ProcessingStartStopSemaphore.Release();
                }
            }
            else
            {
                throw new InvalidOperationException(Resources.RunningMessageProcessorCannotPerformOperation);
            }
        }
    }
}
