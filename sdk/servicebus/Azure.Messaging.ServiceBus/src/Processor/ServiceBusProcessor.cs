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
    /// A processor is responsible for receiving <see cref="ServiceBusReceivedMessage" /> from a specific entity.
    /// </summary>
    ///
    public class ServiceBusProcessor
    {
        private Func<ProcessMessageEventArgs, Task> _processMessage;

        private Func<ProcessErrorEventArgs, Task> _processErrorAsync = default;

        private SemaphoreSlim MessageHandlerSemaphore;

        /// <summary>
        ///
        /// </summary>
        private SemaphoreSlim MaxConcurrentAcceptSessionsSemaphore { get; set; }

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>
        private readonly SemaphoreSlim ProcessingStartStopSemaphore = new SemaphoreSlim(1, 1);

        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        private ServiceBusReceiver Receiver { get; set; }

        private Task ActiveReceiveTask { get; set; }

        /// <summary>
        /// Called when a 'process message' event is triggered.
        /// </summary>
        ///
        /// <param name="args">The set of arguments to identify the context of the event to be processed.</param>
        private Task OnProcessMessageAsync(ProcessMessageEventArgs args) => _processMessage(args);

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
        public bool IsSessionProcessor { get; }

        /// <summary>
        /// The number of messages that will be eagerly requested from Queues or Subscriptions and queued locally without regard to
        /// whether a processing is currently active, intended to help maximize throughput by allowing the receiver to receive
        /// from a local cache rather than waiting on a service request.
        /// </summary>
        public int PrefetchCount { get; }

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private ServiceBusRetryOptions _retryOptions = new ServiceBusRetryOptions();

        /// <summary>
        /// Indicates whether or not this <see cref="ServiceBusProcessor"/> has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsProcessing => ActiveReceiveTask != null;

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        private readonly ServiceBusConnection _connection;

        /// <summary>Gets or sets the maximum number of concurrent calls to the callback the message pump should initiate.</summary>
        /// <value>The maximum number of concurrent calls to the callback.</value>
        public int MaxConcurrentCalls
        {
            get => _maxConcurrentCalls;

            private set
            {
                _maxConcurrentCalls = value;
                _maxConcurrentAcceptSessions = Math.Min(value, 2 * Environment.ProcessorCount);
            }
        }

        private int _maxConcurrentCalls;
        private int _maxConcurrentAcceptSessions;
        private const int DefaultMaxConcurrentCalls = 1;
        private const int DefaultMaxConcurrentSessions = 8;

        /// <summary>Gets or sets a value that indicates whether the message-pump should call
        /// Receiver.CompleteAsync() on messages after the callback has completed processing.</summary>
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
            Argument.AssertNotNull(options, nameof(options));
            connection.ThrowIfClosed();

            _connection = connection;
            EntityPath = entityPath;
            Identifier = DiagnosticUtilities.GenerateIdentifier(EntityPath);

            _retryOptions = _connection.RetryOptions;
            ReceiveMode = options.ReceiveMode;
            PrefetchCount = options.PrefetchCount;
            MaxAutoLockRenewalDuration = options.MaxAutoLockRenewalDuration;
            MaxConcurrentCalls = options.MaxConcurrentCalls;
            AutoComplete = options.AutoComplete;

            EntityPath = entityPath;
            IsSessionProcessor = isSessionEntity;
            _sessionId = sessionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusProcessor"/> class.
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
        /// The event responsible for processing messages received from the Queue or Subscription. Implementation
        /// is mandatory.
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
                    throw new NotSupportedException(Resources1.HandlerHasAlreadyBeenAssigned);
                }
                EnsureNotRunningAndInvoke(() => _processMessage = value);

            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                if (_processMessage != value)
                {
                    throw new ArgumentException(Resources1.HandlerHasNotBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processMessage = default);
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
                    throw new NotSupportedException(Resources1.HandlerHasAlreadyBeenAssigned);
                }

                EnsureNotRunningAndInvoke(() => _processErrorAsync = value);
            }

            remove
            {
                Argument.AssertNotNull(value, nameof(ProcessErrorAsync));

                if (_processErrorAsync != value)
                {
                    throw new ArgumentException(Resources1.HandlerHasNotBeenAssigned);
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
                if (_processMessage == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources1.CannotStartEventProcessorWithoutHandler, nameof(ProcessMessageAsync)));
                }

                if (_processErrorAsync == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources1.CannotStartEventProcessorWithoutHandler, nameof(ProcessErrorAsync)));
                }
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
                            Receiver = await ServiceBusReceiver.CreateSessionReceiverAsync(
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
                throw new InvalidOperationException(Resources1.RunningMessageProcessorCannotPerformOperation);
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
            //Logger.EventProcessorStopStart(Identifier);
            try
            {
                if (ActiveReceiveTask != null)
                {
                    ServiceBusEventSource.Log.StopProcessingStart(Identifier);

                    await ProcessingStartStopSemaphore.WaitAsync().ConfigureAwait(false);

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
                    catch (Exception)
                    {
                        //Logger.LoadBalancingTaskError(Identifier, ex.Message);
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
        ///
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
            ExceptionReceivedEventArgsAction action = ExceptionReceivedEventArgsAction.Receive;
            bool useThreadLocalReceiver = false;
            CancellationTokenSource linkedCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            Task renewSessionLock = null;
            try
            {
                ServiceBusReceiverOptions receiverOptions = CreateReceiverOptions();
                if (IsSessionProcessor && _sessionId == null)
                {
                    action = ExceptionReceivedEventArgsAction.AcceptMessageSession;
                    useThreadLocalReceiver = true;
                    await MaxConcurrentAcceptSessionsSemaphore.WaitAsync().ConfigureAwait(false);
                    try
                    {
                        receiver = await ServiceBusReceiver.CreateSessionReceiverAsync(
                            entityPath: EntityPath,
                            connection: _connection,
                            options: receiverOptions,
                            cancellationToken: cancellationToken).ConfigureAwait(false);
                        renewSessionLock = RenewLock(
                            receiver: receiver,
                            message: null,
                            linkedCancellationSource);
                    }
                    finally
                    {
                        MaxConcurrentAcceptSessionsSemaphore.Release();
                    }
                }
                else
                {
                    receiver = Receiver;
                }

                // loop within the context of this thread
                while (!cancellationToken.IsCancellationRequested)
                {
                    action = ExceptionReceivedEventArgsAction.Receive;
                    IEnumerable<ServiceBusReceivedMessage> messages = await receiver.ReceiveBatchAsync(
                        1,
                        cancellationToken).ConfigureAwait(false);
                    IEnumerator<ServiceBusReceivedMessage> enumerator = messages.GetEnumerator();
                    ServiceBusReceivedMessage message;
                    if (enumerator.MoveNext())
                    {
                        message = enumerator.Current;
                    }
                    else
                    {
                        // if we are processing next available session, and no messages were returned:
                        // 1. cancel the renew session lock task
                        // 2. break out of the loop to allow requesting another session from the service
                        if (IsSessionProcessor && _sessionId == null)
                        {
                            await CancelTask(
                                linkedCancellationSource,
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
                        linkedCancellationSource.Token)
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
                            new ProcessErrorEventArgs(ex, action, FullyQualifiedNamespace, EntityPath)).ConfigureAwait(false);
                }
            }
            finally
            {
                MessageHandlerSemaphore.Release();
                if (useThreadLocalReceiver)
                {
                    await receiver.DisposeAsync().ConfigureAwait(false);
                }
            }
        }

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

        private async Task ProcessOneMessage(
            ServiceBusReceiver receiver,
            ServiceBusReceivedMessage message,
            CancellationToken cancellationToken)
        {
            CancellationTokenSource renewLockCancellationTokenSource = null;
            ExceptionReceivedEventArgsAction action = ExceptionReceivedEventArgsAction.Receive;
            Task renewLock = null;

            try
            {
                if (!IsSessionProcessor && ReceiveMode == ReceiveMode.PeekLock && AutoRenewLock)
                {
                    renewLock = RenewLock(
                        receiver,
                        message,
                        renewLockCancellationTokenSource);
                }

                action = ExceptionReceivedEventArgsAction.UserCallback;

                await OnProcessMessageAsync(new ProcessMessageEventArgs(message, receiver, cancellationToken)).ConfigureAwait(false);

                if (ReceiveMode == ReceiveMode.PeekLock && AutoComplete)
                {
                    action = ExceptionReceivedEventArgsAction.Complete;
                    await receiver.CompleteAsync(
                        message.LockToken,
                        cancellationToken)
                        .ConfigureAwait(false);
                }

                await CancelTask(renewLockCancellationTokenSource, renewLock).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                await RaiseExceptionReceived(
                    new ProcessErrorEventArgs(ex, action, FullyQualifiedNamespace, EntityPath)).ConfigureAwait(false);

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

        private void CancelAutoRenewLock(object state)
        {
            var renewLockCancellationTokenSource = (CancellationTokenSource)state;
            try
            {
                renewLockCancellationTokenSource.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // Ignore this race.
            }
        }

        private async Task RenewLock(
            ServiceBusReceiver receiver,
            ServiceBusReceivedMessage message,
            CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.CancelAfter(MaxAutoLockRenewalDuration);
            var cancellationToken = cancellationTokenSource.Token;
            ServiceBusSessionManager sessionManager = null;
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    DateTimeOffset lockedUntil = default;
                    if (IsSessionProcessor)
                    {
                        sessionManager = receiver.GetSessionManager();
                        lockedUntil = sessionManager.LockedUntil;
                    }
                    else
                    {
                        lockedUntil = message.LockedUntil;
                    }

                    TimeSpan delay = CalculateRenewDelay(lockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, cancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }

                    if (IsSessionProcessor)
                    {
                        await sessionManager.RenewSessionLockAsync(cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await receiver.RenewMessageLockAsync(message, cancellationToken).ConfigureAwait(false);
                    }
                    //MessagingEventSource.Log.MessageReceiverPumpRenewMessageStop(this.messageReceiver.ClientId, message);
                }

                catch (Exception exception)
                {
                    // if the renewLock token was cancelled, throw a TaskCanceledException as we don't want
                    // to propagate to user error handler. This will be handled by the caller.
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    //MessagingEventSource.Log.MessageReceiverPumpRenewMessageException(this.messageReceiver.ClientId, message, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await RaiseExceptionReceived(
                            new ProcessErrorEventArgs(
                                exception,
                                ExceptionReceivedEventArgsAction.RenewLock,
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
        private void EnsureNotRunningAndInvoke(Action action)
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
                        throw new InvalidOperationException(Resources1.RunningMessageProcessorCannotPerformOperation);
                    }
                }
                finally
                {
                    ProcessingStartStopSemaphore.Release();
                }
            }
            else
            {
                throw new InvalidOperationException(Resources1.RunningMessageProcessorCannotPerformOperation);
            }
        }

        internal async Task RaiseExceptionReceived(ProcessErrorEventArgs eventArgs)
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

        private void ValidateNotProcessing()
        {
            if (IsProcessing)
            {
                throw new InvalidOperationException("Properties cannot be changed while processing. Call StopProcessingAsync to allow changing property values.");
            }
        }
    }
}
