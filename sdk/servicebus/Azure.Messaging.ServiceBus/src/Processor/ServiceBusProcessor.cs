// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A client responsible for reading <see cref="ServiceBusMessage" /> from a specific entity
    ///   as a member of a specific consumer group.
    ///
    ///   A consumer may be exclusive, which asserts ownership over associated partitions for the consumer
    ///   group to ensure that only one consumer from that group is reading the from the partition.
    ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
    ///
    ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
    ///   group to be actively reading events from a given partition.  These non-exclusive consumers are
    ///   sometimes referred to as "Non-Epoch Consumers."
    /// </summary>
    ///
    public class ServiceBusProcessor : IAsyncDisposable
    {
        private Func<ProcessMessageEventArgs, Task> _processMessage;

        private Func<ProcessErrorEventArgs, Task> _processErrorAsync = default;
        /// <summary>The primitive for synchronizing access during start and set handler operations.</summary>

        private readonly object EventHandlerGuard = new object();
        /// <summary>The primitive for synchronizing access during start and close operations.</summary>

        private SemaphoreSlim MessageHandlerSemaphore;
        private int _maxConcurrentCalls = 4;
        private TimeSpan _maxAutoRenewDuration;

        /// <summary>The primitive for synchronizing access during start and close operations.</summary>

        private readonly SemaphoreSlim ProcessingStartStopSemaphore = new SemaphoreSlim(1, 1);

        private CancellationTokenSource RunningTaskTokenSource { get; set; }

        private ServiceBusReceiver Receiver { get; set; }

        /// <summary>
        ///   The running task responsible for performing partition load balancing between multiple <see cref="ServiceBusProcessor" />
        ///   instances, as well as managing partition processing tasks and ownership.
        /// </summary>
        ///
        private Task ActiveReceiveTask { get; set; }

        /// <summary>
        ///   Called when a 'process message' event is triggered.
        /// </summary>
        ///
        /// <param name="args">The set of arguments to identify the context of the event to be processed.</param>
        ///
        private Task OnProcessMessageAsync(ProcessMessageEventArgs args) => _processMessage(args);

        /// <summary>
        ///   Called when a 'process error' event is triggered.
        /// </summary>
        ///
        /// <param name="eventArgs">The set of arguments to identify the context of the error to be processed.</param>
        ///
        private Task OnProcessErrorAsync(ProcessErrorEventArgs eventArgs) => _processErrorAsync(eventArgs);

        /// <summary>
        ///   The fully qualified Service Bus namespace that the consumer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => _connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the Service Bus entity that the consumer is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public ReceiveMode ReceiveMode { get; set; } = ReceiveMode.PeekLock;

        /// <summary>
        ///
        /// </summary>
        public bool UseSessions { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int PrefetchCount
        {
            get
            {
                return _prefetchCount;
            }
            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(PrefetchCount), value, "Value cannot be less than 0.");
                }
                _prefetchCount = value;
            }
        }
        private int _prefetchCount = 0;

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  These options also control the
        ///   amount of time allowed for publishing events and other interactions with the Service Bus service.
        /// </summary>
        ///
        public ServiceBusRetryOptions RetryOptions
        {
            get => _retryOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(RetryOptions));
                _retryOptions = value;
            }
        }

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private ServiceBusRetryOptions _retryOptions = new ServiceBusRetryOptions();

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusProcessor"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed => Receiver == null || Receiver.IsClosed;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private ServiceBusRetryPolicy RetryPolicy => Receiver.RetryPolicy;

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        ///
        private readonly ServiceBusConnection _connection;

        /// <summary>Gets or sets the maximum number of concurrent calls to the callback the message pump should initiate.</summary>
        /// <value>The maximum number of concurrent calls to the callback.</value>
        public int MaxConcurrentCalls
        {
            get => _maxConcurrentCalls;

            set
            {
                if (value <= 0)
                {
                    //throw new ArgumentOutOfRangeException(Resources.MaxConcurrentCallsMustBeGreaterThanZero.FormatForUser(value));
                }

                _maxConcurrentCalls = value;
            }
        }

        /// <summary>Gets or sets a value that indicates whether the message-pump should call
        ///  cref="QueueClient.CompleteAsync(string)" /> or
        ///  cref="SubscriptionClient.CompleteAsync(string)" /> on messages after the callback has completed processing.</summary>
        /// <value>true to complete the message processing automatically on successful execution of the operation; otherwise, false.</value>
        public bool AutoComplete { get; set; }

        /// <summary>Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property. </summary>
        /// <value>The maximum duration during which locks are automatically renewed.</value>
        /// <remarks>The message renew can continue for sometime in the background
        /// after completion of message and result in a few false MessageLockLostExceptions temporarily.</remarks>
        public TimeSpan MaxAutoLockRenewalDuration
        {
            get => _maxAutoRenewDuration;

            set
            {
                TimeoutHelper.ThrowIfNegativeArgument(value, nameof(value));
                _maxAutoRenewDuration = value;
            }
        }

        internal bool AutoRenewLock => MaxAutoLockRenewalDuration > TimeSpan.Zero;

        /// <summary>
        ///
        /// </summary>
        public TimeSpan MaxReceiveTimeout { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SessionId { get; set; }


        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessor"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="entityName"></param>
        ///
        internal ServiceBusProcessor(
            ServiceBusConnection connection,
            string entityName)
        {
            _connection = connection;
            EntityName = entityName;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusProcessor"/> class.
        /// </summary>
        ///
        protected ServiceBusProcessor()
        {
        }

        /// <summary>
        ///   Closes the consumer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            if (Receiver != null)
            {
                await Receiver.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusProcessor" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   The event responsible for processing events received from the Event Hubs service.  Implementation
        ///   is mandatory.
        /// </summary>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "Guidance does not apply; this is an event.")]
        [SuppressMessage("Usage", "AZC0003:DO make service methods virtual.", Justification = "This member follows the standard .NET event pattern; override via the associated On<<EVENT>> method.")]
        public event Func<ProcessMessageEventArgs, Task> ProcessMessageAsync
        {
            add
            {
                lock (EventHandlerGuard)
                {

                    Argument.AssertNotNull(value, nameof(ProcessMessageAsync));

                    if (_processMessage != default)
                    {
                        throw new NotSupportedException(Resources1.HandlerHasAlreadyBeenAssigned);
                    }
                    EnsureNotRunningAndInvoke(() => _processMessage = value);
                }
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
        ///   The event responsible for processing unhandled exceptions thrown while this processor is running.
        ///   Implementation is mandatory.
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
        ///   Signals the <see cref="ServiceBusProcessor" /> to begin processing events.  Should this method be called while the processor
        ///   is running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the start operation.  This won't affect the <see cref="ServiceBusProcessor" /> once it starts running.</param>
        ///
        /// exception cref="EventHubsException">Occurs when this <see cref="ServiceBusProcessor" /> instance is already closed./exception>
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked without <see cref="ProcessMessageAsync" /> or <see cref="ProcessErrorAsync" /> set.</exception>
        ///
        public virtual async Task StartProcessingAsync(
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            if (ActiveReceiveTask == null && MessageHandlerSemaphore == null)
            {
                MessageHandlerSemaphore = new SemaphoreSlim(
                    MaxConcurrentCalls,
                    MaxConcurrentCalls);
                await ProcessingStartStopSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    ServiceBusReceiverOptions receiverOptions = CreateReceiverOptions();

                    if (UseSessions)
                    {
                        if (SessionId != null)
                        {
                            // only create a new receiver if a specific session
                            // is specified, otherwise thread local receivers will be used
                            Receiver = await ServiceBusReceiver.CreateSessionReceiverAsync(
                                EntityName,
                                _connection,
                                SessionId,
                                receiverOptions,
                                cancellationToken).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        // even when not using sessions, we create a new receiver
                        // in case processing options have been changed
                        Receiver = ServiceBusReceiver.CreateReceiver(
                            EntityName,
                            _connection,
                            receiverOptions);
                    }

                    // TODO do we need the event handler guard in addition
                    // to ProcessingStartStopSemaphore?
                    lock (EventHandlerGuard)
                    {
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        if (ActiveReceiveTask == null)
                        {
                            if (_processMessage == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources1.CannotStartEventProcessorWithoutHandler, nameof(ProcessMessageAsync)));
                            }

                            if (_processErrorAsync == null)
                            {
                                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources1.CannotStartEventProcessorWithoutHandler, nameof(ProcessErrorAsync)));
                            }

                            // We expect the token source to be null, but we are playing safe.

                            RunningTaskTokenSource?.Cancel();
                            RunningTaskTokenSource?.Dispose();
                            RunningTaskTokenSource = new CancellationTokenSource();

                            // Start the main running task.  It is responsible for managing the active partition processing tasks and
                            // for partition load balancing among multiple event processor instances.

                            //Logger.EventProcessorStart(Identifier);
                            ActiveReceiveTask = RunReceiveTaskAsync(
                                RunningTaskTokenSource.Token);
                        }
                    }
                }
                finally
                {
                    ProcessingStartStopSemaphore.Release();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private ServiceBusReceiverOptions CreateReceiverOptions()
        {
            return new ServiceBusReceiverOptions()
            {
                ReceiveMode = ReceiveMode,
                RetryOptions = RetryOptions,
                PrefetchCount = PrefetchCount
            };
        }

        /// <summary>
        ///   Signals the <see cref="ServiceBusProcessor" /> to stop processing events.  Should this method be called while the processor
        ///   is not running, no action is taken.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the stop operation.  If the operation is successfully canceled, the <see cref="ServiceBusProcessor" /> will keep running.</param>
        ///
        public virtual async Task StopProcessingAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            //Logger.EventProcessorStopStart(Identifier);
            await ProcessingStartStopSemaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                if (ActiveReceiveTask != null)
                {
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
                if (Receiver != null)
                {
                    await Receiver.CloseAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                ProcessingStartStopSemaphore.Release();
                //Logger.EventProcessorStopComplete(Identifier);
            }
        }

        /// <summary>
        ///   Runs the Receive task in as many threads as are
        ///   specified in the <see cref="MaxConcurrentCalls"/> property.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        private async Task RunReceiveTaskAsync(
            CancellationToken cancellationToken)
        {
            IList<Task> tasks = new List<Task>();
            while (!cancellationToken.IsCancellationRequested)
            {
                await MessageHandlerSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

                try
                {
                    tasks.Add(GetAndProcessMessagesAsync(cancellationToken));
                }
                catch (Exception)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                }
            }
            // If cancellation has been requested, throw an exception so we can keep a consistent behavior.
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }

        private async Task GetAndProcessMessagesAsync(
            CancellationToken cancellationToken)
        {
            CancellationTokenSource renewLockCancellationTokenSource = null;
            bool useThreadLocalConsumer = false;
            Task renewLock = null;
            ServiceBusReceiver receiver;

            if (UseSessions && SessionId == null)
            {
                // If the user didn't specify a session, but this is a sessionful receiver,
                // we want to allow each thread to have its own consumer so we can access
                // multiple sessions concurrently.
                ServiceBusReceiverOptions receiverOptions = CreateReceiverOptions();
                receiver = await ServiceBusReceiver.CreateSessionReceiverAsync(
                    EntityName,
                    _connection,
                    SessionId,
                    receiverOptions,
                    cancellationToken).ConfigureAwait(false);
                useThreadLocalConsumer = true;
            }
            else
            {
                receiver = Receiver;
            }

            try
            {
                // loop within the context of this thread
                while (!cancellationToken.IsCancellationRequested)
                {
                    ServiceBusReceivedMessage message = null;
                    var action = ExceptionReceivedEventArgsAction.Receive;
                    try
                    {
                        IEnumerable<ServiceBusReceivedMessage> messages = await receiver.ReceiveBatchAsync(
                            1,
                            cancellationToken).ConfigureAwait(false);
                        var enumerator = messages.GetEnumerator();
                        if (enumerator.MoveNext())
                        {
                            message = enumerator.Current;
                        }
                        else
                        {
                            // no messages returned, so exit the loop as we are likely out of messages
                            // in the case of sessions, this means we will create a new consumer and potentially use a different session
                            break;
                        }

                        if (ReceiveMode == ReceiveMode.PeekLock && AutoRenewLock)
                        {
                            action = ExceptionReceivedEventArgsAction.RenewLock;
                            renewLockCancellationTokenSource = new CancellationTokenSource();
                            renewLockCancellationTokenSource.CancelAfter(MaxAutoLockRenewalDuration);
                            renewLock = RenewLock(
                                receiver,
                                message,
                                cancellationToken,
                                renewLockCancellationTokenSource.Token);
                        }

                        action = ExceptionReceivedEventArgsAction.UserCallback;

                        await OnProcessMessageAsync(new ProcessMessageEventArgs(message, receiver, cancellationToken)).ConfigureAwait(false);

                        try
                        {
                            if (renewLockCancellationTokenSource != null)
                            {
                                renewLockCancellationTokenSource.Cancel();
                                await renewLock.ConfigureAwait(false);
                            }
                        }
                        catch (Exception ex) when (ex is OperationCanceledException)
                        {
                            // Nothing to do here.  These exceptions are expected.
                        }

                        if (ReceiveMode == ReceiveMode.PeekLock && AutoComplete)
                        {
                            action = ExceptionReceivedEventArgsAction.Complete;
                            await receiver.CompleteAsync(
                                message,
                                cancellationToken)
                                .ConfigureAwait(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        await RaiseExceptionReceived(
                            // TODO - add clientId implementation and pass as last argument to ExceptionReceivedEventArgs
                            new ProcessErrorEventArgs(ex, action, FullyQualifiedNamespace, EntityName, "")).ConfigureAwait(false);
                        await receiver.AbandonAsync(message).ConfigureAwait(false);

                    }
                    finally
                    {
                        renewLockCancellationTokenSource?.Cancel();
                        renewLockCancellationTokenSource?.Dispose();
                    }
                }
            }
            finally
            {
                MessageHandlerSemaphore.Release();
                if (useThreadLocalConsumer)
                {
                    await receiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
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
            CancellationToken eventCancellationToken,
            CancellationToken renewLockCancellationToken)
        {
            while (!eventCancellationToken.IsCancellationRequested && !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    DateTimeOffset lockedUntil = default;
                    if (UseSessions)
                    {
                        lockedUntil = receiver.SessionManager.LockedUntilUtc;
                    }
                    else
                    {
                        lockedUntil = message.LockedUntilUtc;
                    }

                    TimeSpan delay = CalculateRenewDelay(lockedUntil);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    Task delayTask = await Task.Delay(delay, renewLockCancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }

                    if (UseSessions)
                    {
                        await receiver.SessionManager.RenewSessionLockAsync(renewLockCancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await receiver.RenewLockAsync(message, renewLockCancellationToken).ConfigureAwait(false);
                    }
                    //MessagingEventSource.Log.MessageReceiverPumpRenewMessageStop(this.messageReceiver.ClientId, message);
                }

                catch (Exception exception)
                {
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
                                EntityName,
                                "")).ConfigureAwait(false);
                    }

                    if (!(exception as ServiceBusException)?.IsTransient == true)
                    {
                        break;
                    }
                }
            }
        }

        private static TimeSpan CalculateRenewDelay(DateTimeOffset lockedUntilUtc)
        {
            var remainingTime = lockedUntilUtc - DateTime.UtcNow;

            if (remainingTime < TimeSpan.FromMilliseconds(400))
            {
                return TimeSpan.Zero;
            }

            var buffer = TimeSpan.FromTicks(Math.Min(remainingTime.Ticks / 2, Constants.MaximumRenewBufferDuration.Ticks));
            var renewAfter = remainingTime - buffer;

            return renewAfter;
        }

        /// <summary>
        ///   Invokes a specified action only if this <see cref="ServiceBusProcessor" /> instance is not running.
        /// </summary>
        ///
        /// <param name="action">The action to invoke.</param>
        ///
        /// <exception cref="InvalidOperationException">Occurs when this method is invoked while the event processor is running.</exception>
        ///
        private void EnsureNotRunningAndInvoke(Action action)
        {
            if (ActiveReceiveTask == null)
            {
                lock (EventHandlerGuard)
                {
                    if (ActiveReceiveTask == null)
                    {
                        action?.Invoke();
                    }
                    else
                    {
                        throw new InvalidOperationException(Resources1.RunningMessageProcessorCannotPerformOperation);
                    }
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
                MessagingEventSource.Log.ExceptionReceivedHandlerThrewException(exception);
            }
        }
    }
}
