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
    /// A <see cref="ServiceBusProcessor"/> is responsible for processing <see cref="ServiceBusReceivedMessage" /> from a specific
    /// entity using event handlers. It is constructed by calling
    ///  <see cref="ServiceBusClient.CreateProcessor(string, ServiceBusProcessorOptions)"/>.
    /// The event handler is specified with the <see cref="ProcessMessageAsync"/>
    /// property. The error handler is specified with the <see cref="ProcessErrorAsync"/> property.
    /// To start processing after the handlers have been specified, call <see cref="StartProcessingAsync"/>.
    /// </summary>
    public class ServiceBusProcessor
    {
        private Func<ProcessMessageEventArgs, Task> _processMessage;

        private Func<ProcessSessionMessageEventArgs, Task> _processSessionMessage;

        private Func<ProcessErrorEventArgs, Task> _processErrorAsync = default;

        private SemaphoreSlim MessageHandlerSemaphore;

        /// <summary>
        ///
        /// </summary>
        private SemaphoreSlim MaxConcurrentAcceptSessionsSemaphore { get; set; }

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim ProcessingStartStopSemaphore = new SemaphoreSlim(1, 1);

        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        internal virtual ServiceBusReceiver Receiver { get; set; }

        private Task ActiveReceiveTask { get; set; }

        /// <summary>
        /// Called when a 'process message' event is triggered.
        /// </summary>
        ///
        /// <param name="args">The set of arguments to identify the context of the event to be processed.</param>
        private Task OnProcessMessageAsync(ProcessMessageEventArgs args) =>
            _processMessage(args);

        /// <summary>
        /// Called when a 'process message' event is triggered.
        /// </summary>
        ///
        /// <param name="args">The set of arguments to identify the context of the event to be processed.</param>
        private Task OnProcessSessionMessageAsync(ProcessSessionMessageEventArgs args) => _processSessionMessage(args);

        /// <summary>
        /// Called when a 'process error' event is triggered.
        /// </summary>
        ///
        /// <param name="eventArgs">The set of arguments to identify the context of the error to be processed.</param>
        private Task OnProcessErrorAsync(ProcessErrorEventArgs eventArgs) => _processErrorAsync(eventArgs);

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

        internal bool AutoRenewLock => MaxAutoLockRenewalDuration > TimeSpan.Zero;

        private readonly string _sessionId;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessor"/> class.
        /// </summary>
        ///
        /// <param name="entityPath"></param>
        /// <param name="isSessionEntity"></param>
        /// <param name="sessionId"></param>
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="options"></param>
        ///
        internal ServiceBusProcessor(
            ServiceBusConnection connection,
            string entityPath,
            bool isSessionEntity,
            ServiceBusProcessorOptions options,
            string sessionId = default)
        {
            Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
            connection.ThrowIfClosed();

            options = options?.Clone() ?? new ServiceBusProcessorOptions();
            _connection = connection;
            EntityPath = entityPath;
            Identifier = DiagnosticUtilities.GenerateIdentifier(EntityPath);

            ReceiveMode = options.ReceiveMode;
            PrefetchCount = options.PrefetchCount;
            MaxAutoLockRenewalDuration = options.MaxAutoLockRenewalDuration;
            MaxConcurrentCalls = options.MaxConcurrentCalls;
            MaxReceiveWaitTime = options.MaxReceiveWaitTime;
            AutoComplete = options.AutoComplete;

            EntityPath = entityPath;
            IsSessionProcessor = isSessionEntity;
            _sessionId = sessionId;
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

                if (_processMessage != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }
                EnsureNotRunningAndInvoke(() => _processMessage = value);

            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processMessage != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processMessage = default);
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

                if (_processSessionMessage != default)
                {
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }
                EnsureNotRunningAndInvoke(() => _processSessionMessage = value);

            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processSessionMessage != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processSessionMessage = default);
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
                    throw new NotSupportedException(Resources.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != value)
                {
                    throw new ArgumentException(Resources.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = default);
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
            if (ActiveReceiveTask == null && MessageHandlerSemaphore == null)
            {
                ServiceBusEventSource.Log.StartProcessingStart(Identifier);
                await ProcessingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                ValidateMessageHandler();
                ValidateErrorHandler();

                try
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    ServiceBusReceiverOptions receiverOptions = CreateReceiverOptions();

                    if (IsSessionProcessor)
                    {
                        if (MaxConcurrentCalls == 0)
                        {
                            MaxConcurrentCalls = DefaultMaxConcurrentSessions;
                        }
                        if (_sessionId != null)
                        {
                            // only create a new receiver if a specific session
                            // is specified, otherwise thread local receivers will be used
                            Receiver = await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                                EntityPath,
                                _connection,
                                _sessionId,
                                receiverOptions,
                                cancellationToken).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        if (MaxConcurrentCalls == 0)
                        {
                            MaxConcurrentCalls = DefaultMaxConcurrentCalls;
                        }
                        // even when not using sessions, we create a new receiver
                        // in case processing options have been changed
                        Receiver = new ServiceBusReceiver(
                            connection: _connection,
                            entityPath: EntityPath,
                            isSessionEntity: false,
                            options: receiverOptions);
                    }
                    MessageHandlerSemaphore = new SemaphoreSlim(
                        MaxConcurrentCalls,
                        MaxConcurrentCalls);

                    MaxConcurrentAcceptSessionsSemaphore = new SemaphoreSlim(
                        _maxConcurrentAcceptSessions,
                        _maxConcurrentAcceptSessions);

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
                    ServiceBusEventSource.Log.StartProcessingException(Identifier, exception);
                    throw;
                }
                finally
                {
                    ProcessingStartStopSemaphore.Release();
                }
                ServiceBusEventSource.Log.StartProcessingComplete(Identifier);
            }
            else
            {
                throw new InvalidOperationException(Resources.RunningMessageProcessorCannotPerformOperation);
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
                if (_processSessionMessage == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessMessageAsync)));
                }
            }
            else if (_processMessage == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.CannotStartMessageProcessorWithoutHandler, nameof(ProcessMessageAsync)));
            }
        }

        private ServiceBusReceiverOptions CreateReceiverOptions()
        {
            return new ServiceBusReceiverOptions()
            {
                ReceiveMode = ReceiveMode,
                PrefetchCount = PrefetchCount
            };
        }

        /// <summary>
        /// Signals the <see cref="ServiceBusProcessor" /> to stop processing events. Should this method be called while the processor
        /// is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="ServiceBusProcessor" /> will keep running.</param>
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            try
            {
                if (ActiveReceiveTask != null)
                {
                    ServiceBusEventSource.Log.StopProcessingStart(Identifier);

                    await ProcessingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

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
                }
            }
            catch (Exception exception)
            {
                ServiceBusEventSource.Log.StopProcessingException(Identifier, exception);
                throw;
            }
            finally
            {
                ProcessingStartStopSemaphore.Release();
            }
            ServiceBusEventSource.Log.StopProcessingComplete(Identifier);
        }

        /// <summary>
        /// Runs the Receive task in as many threads as are
        /// specified in the <see cref="MaxConcurrentCalls"/> property.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        private async Task RunReceiveTaskAsync(
            CancellationToken cancellationToken)
        {
            IList<Task> tasks = new List<Task>();
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await MessageHandlerSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                    // hold onto all the tasks that we are starting so that when cancellation is requested,
                    // we can await them to make sure we surface any unexpected exceptions, i.e. exceptions
                    // other than TaskCanceledExceptions
                    tasks.Add(GetAndProcessMessagesAsync(cancellationToken));
                }
            }
            finally
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
        }

        private async Task GetAndProcessMessagesAsync(
            CancellationToken cancellationToken)
        {
            ServiceBusReceiver receiver = null;
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.Receive;
            bool useThreadLocalReceiver = false;
            CancellationTokenSource renewSessionLockCancellationSource = null;
            Task renewSessionLock = null;
            try
            {
                ServiceBusReceiverOptions receiverOptions = CreateReceiverOptions();
                if (IsSessionProcessor && _sessionId == null)
                {
                    errorSource = ServiceBusErrorSource.AcceptMessageSession;
                    useThreadLocalReceiver = true;
                    bool releaseSemaphore = false;
                    try
                    {
                        try
                        {
                            await MaxConcurrentAcceptSessionsSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
                            // only attempt to release semaphore if WaitAsync is successful,
                            // otherwise SemaphoreFullException can occur.
                            releaseSemaphore = true;
                        }
                        catch (OperationCanceledException)
                        {
                            // propagate as TCE so it will be handled by the outer catch block
                            throw new TaskCanceledException();
                        }
                        try
                        {
                            receiver = await ServiceBusSessionReceiver.CreateSessionReceiverAsync(
                                entityPath: EntityPath,
                                connection: _connection,
                                options: receiverOptions,
                                cancellationToken: cancellationToken).ConfigureAwait(false);
                        }
                        catch (ServiceBusException ex)
                        when (ex.Reason == ServiceBusException.FailureReason.ServiceTimeout)
                        {
                            // these exceptions are expected when no messages are available
                            // so simply return and allow this to be tried again on next thread
                            return;
                        }
                        renewSessionLockCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                        renewSessionLock = RenewSessionLock(
                            receiver: (ServiceBusSessionReceiver)receiver,
                            renewSessionLockCancellationSource);
                    }
                    finally
                    {
                        if (releaseSemaphore)
                        {
                            MaxConcurrentAcceptSessionsSemaphore.Release();
                        }
                    }
                }
                else
                {
                    receiver = Receiver;
                }

                // loop within the context of this thread
                while (!cancellationToken.IsCancellationRequested)
                {
                    errorSource = ServiceBusErrorSource.Receive;
                    ServiceBusReceivedMessage message = await receiver.ReceiveAsync(
                        MaxReceiveWaitTime,
                        cancellationToken).ConfigureAwait(false);
                    if (message == null)
                    {
                        // if we are processing next available session, and no messages were returned:
                        // 1. cancel the renew session lock task
                        // 2. break out of the loop to allow requesting another session from the service
                        if (IsSessionProcessor && _sessionId == null)
                        {
                            await CancelTask(
                                renewSessionLockCancellationSource,
                                renewSessionLock).ConfigureAwait(false);

                            break;
                        }
                        // otherwise just continue receiving using this receiver, since the link wouldn't
                        // change anyway
                        else
                        {
                            continue;
                        }
                    }

                    await ProcessOneMessage(
                        receiver,
                        message,
                        cancellationToken)
                        .ConfigureAwait(false);

                }
            }
            catch (Exception ex)
            {
                // Our token would only be canceled when user calls StopProcessingAsync. We don't
                // need to spam the exception handler with these exceptions.
                if (!(ex is TaskCanceledException))
                {
                    await RaiseExceptionReceived(
                            new ProcessErrorEventArgs(ex, errorSource, FullyQualifiedNamespace, EntityPath)).ConfigureAwait(false);
                }
            }
            finally
            {
                MessageHandlerSemaphore.Release();
                if (useThreadLocalReceiver && receiver != null)
                {
                    await receiver.DisposeAsync().ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Cancels the specified cancellation source and awaits the specified task.
        /// </summary>
        /// <param name="cancellationSource">CancellationTokenSource to cancel</param>
        /// <param name="task">Associated task to await</param>
        private static async Task CancelTask(
            CancellationTokenSource cancellationSource,
            Task task)
        {
            try
            {
                if (cancellationSource != null)
                {
                    cancellationSource.Cancel();
                    await task.ConfigureAwait(false);
                }
            }
            catch (Exception ex) when (ex is TaskCanceledException)
            {
                // Nothing to do here.  These exceptions are expected.
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <param name="processorCancellationToken"></param>
        /// <returns></returns>
        private async Task ProcessOneMessage(
            ServiceBusReceiver receiver,
            ServiceBusReceivedMessage message,
            CancellationToken processorCancellationToken)
        {
            ServiceBusErrorSource errorSource = ServiceBusErrorSource.Receive;
            CancellationTokenSource renewLockCancellationTokenSource = null;
            Task renewLock = null;

            try
            {
                if (!IsSessionProcessor && ReceiveMode == ReceiveMode.PeekLock && AutoRenewLock)
                {
                    renewLockCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(processorCancellationToken);
                    renewLock = RenewMessageLock(
                        receiver,
                        message,
                        renewLockCancellationTokenSource);
                }

                errorSource = ServiceBusErrorSource.UserCallback;

                if (IsSessionProcessor)
                {
                    await OnProcessSessionMessageAsync(
                        new ProcessSessionMessageEventArgs(
                            message,
                            (ServiceBusSessionReceiver)receiver,
                            processorCancellationToken))
                        .ConfigureAwait(false);
                }
                else
                {
                    await OnProcessMessageAsync(
                        new ProcessMessageEventArgs(
                            message,
                            receiver,
                            processorCancellationToken))
                        .ConfigureAwait(false);
                }

                if (ReceiveMode == ReceiveMode.PeekLock && AutoComplete)
                {
                    errorSource = ServiceBusErrorSource.Complete;
                    // don't pass the processor cancellation token
                    // as we want in flight autocompletion to be able
                    // to finish
                    await receiver.CompleteAsync(
                        message.LockToken,
                        CancellationToken.None)
                        .ConfigureAwait(false);
                }

                await CancelTask(renewLockCancellationTokenSource, renewLock).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                processorCancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(ex, errorSource, FullyQualifiedNamespace, EntityPath)).ConfigureAwait(false);

                // if the message or session lock was lost, do not attempt to abandon the message
                if (ReceiveMode == ReceiveMode.PeekLock &&
                    (!(ex is ServiceBusException sbException) ||
                    (sbException.Reason != ServiceBusException.FailureReason.SessionLockLost) &&
                     sbException.Reason != ServiceBusException.FailureReason.MessageLockLost))
                {
                    await receiver.AbandonAsync(message.LockToken).ConfigureAwait(false);
                }
            }
            finally
            {
                renewLockCancellationTokenSource?.Cancel();
                renewLockCancellationTokenSource?.Dispose();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <returns></returns>
        private async Task RenewMessageLock(
            ServiceBusReceiver receiver,
            ServiceBusReceivedMessage message,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(MaxAutoLockRenewalDuration);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockStart(Identifier, 1, message.LockToken);
                    TimeSpan delay = CalculateRenewDelay(message.LockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, cancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }

                    await receiver.RenewMessageLockAsync(message, cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewMessageLockComplete(Identifier);
                }

                catch (Exception exception)
                {
                    // if the renewLock token was cancelled, throw a TaskCanceledException as we don't want
                    // to propagate to user error handler. This will be handled by the caller.
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    ServiceBusEventSource.Log.ProcesserRenewMessageLockException(Identifier, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await RaiseExceptionReceived(
                            new ProcessErrorEventArgs(
                                exception,
                                ServiceBusErrorSource.RenewLock,
                                FullyQualifiedNamespace,
                                EntityPath)).ConfigureAwait(false);
                    }

                    // if the error was not transient, break out of the loop
                    if (!(exception as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="cancellationTokenSource"></param>
        /// <returns></returns>
        private async Task RenewSessionLock(
            ServiceBusSessionReceiver receiver,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(MaxAutoLockRenewalDuration);
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockStart(Identifier, receiver.SessionId);
                    TimeSpan delay = CalculateRenewDelay(receiver.SessionLockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, cancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }
                    await receiver.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
                    ServiceBusEventSource.Log.ProcessorRenewSessionLockComplete(Identifier);
                }

                catch (Exception exception)
                {
                    // if the renewLock token was cancelled, throw a TaskCanceledException as we don't want
                    // to propagate to user error handler. This will be handled by the caller.
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    ServiceBusEventSource.Log.ProcessorRenewSessionLockException(Identifier, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await RaiseExceptionReceived(
                            new ProcessErrorEventArgs(
                                exception,
                                ServiceBusErrorSource.RenewLock,
                                FullyQualifiedNamespace,
                                EntityPath)).ConfigureAwait(false);
                    }

                    // if the error was not transient, break out of the loop
                    if (!(exception as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lockedUntil"></param>
        /// <returns></returns>
        private static TimeSpan CalculateRenewDelay(DateTimeOffset lockedUntil)
        {
            var remainingTime = lockedUntil - DateTimeOffset.UtcNow;

            if (remainingTime < TimeSpan.FromMilliseconds(400))
            {
                return TimeSpan.Zero;
            }

            var buffer = TimeSpan.FromTicks(Math.Min(remainingTime.Ticks / 2, Constants.MaximumRenewBufferDuration.Ticks));
            var renewAfter = remainingTime - buffer;

            return renewAfter;
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <returns></returns>
        private async Task RaiseExceptionReceived(ProcessErrorEventArgs eventArgs)
        {
            try
            {
                await OnProcessErrorAsync(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // don't bubble up exceptions raised from customer exception handler
                MessagingEventSource.Log.ExceptionReceivedHandlerThrewException(exception);
            }
        }
    }
}
