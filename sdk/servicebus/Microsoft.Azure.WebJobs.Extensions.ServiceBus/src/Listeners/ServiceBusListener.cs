// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal sealed class ServiceBusListener : IListener, IScaleMonitorProvider
    {
        private readonly ITriggeredFunctionExecutor _triggerExecutor;
        private readonly string _entityPath;
        private readonly bool _isSessionsEnabled;
        private readonly bool _autoCompleteMessagesOptionEvaluatedValue;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly ServiceBusOptions _serviceBusOptions;
        private readonly bool _singleDispatch;
        private readonly ILogger<ServiceBusListener> _logger;

        private readonly Lazy<MessageProcessor> _messageProcessor;
        private readonly Lazy<ServiceBusReceiver> _batchReceiver;
        private readonly Lazy<ServiceBusClient> _client;
        private readonly Lazy<SessionMessageProcessor> _sessionMessageProcessor;
        private readonly Lazy<ServiceBusScaleMonitor> _scaleMonitor;
        private readonly ConcurrencyManager _concurrencyManager;

        private volatile bool _disposed;
        private volatile bool _started;
        // Serialize execution of StopAsync to avoid calling Unregister* concurrently
        private readonly SemaphoreSlim _stopAsyncSemaphore = new SemaphoreSlim(1, 1);
        private readonly string _functionId;
        private CancellationTokenRegistration _batchReceiveRegistration;
        private Task _batchLoop;

        public ServiceBusListener(
            string functionId,
            ServiceBusEntityType entityType,
            string entityPath,
            bool isSessionsEnabled,
            bool autoCompleteMessagesOptionEvaluatedValue,
            ITriggeredFunctionExecutor triggerExecutor,
            ServiceBusOptions options,
            string connection,
            MessagingProvider messagingProvider,
            ILoggerFactory loggerFactory,
            bool singleDispatch,
            ServiceBusClientFactory clientFactory,
            ConcurrencyManager concurrencyManager)
        {
            _entityPath = entityPath;
            _isSessionsEnabled = isSessionsEnabled;
            _autoCompleteMessagesOptionEvaluatedValue = autoCompleteMessagesOptionEvaluatedValue;
            _triggerExecutor = triggerExecutor;
            _cancellationTokenSource = new CancellationTokenSource();
            _logger = loggerFactory.CreateLogger<ServiceBusListener>();
            _concurrencyManager = concurrencyManager;
            _functionId = functionId;

            ServiceBusProcessorStrategy processorStrategy = null;
            if (_concurrencyManager.Enabled)
            {
                processorStrategy = new DynamicServiceBusProcessorStrategy(_concurrencyManager, functionId);
            }

            _client = new Lazy<ServiceBusClient>(
                () =>
                    clientFactory.CreateClientFromSetting(connection));

            _batchReceiver = new Lazy<ServiceBusReceiver>(
                () => messagingProvider.CreateBatchMessageReceiver(
                    _client.Value,
                    _entityPath,
                    options.ToReceiverOptions()));

            _messageProcessor = new Lazy<MessageProcessor>(
                () => messagingProvider.CreateMessageProcessor(
                    _client.Value,
                    _entityPath,
                    options.ToProcessorOptions(_autoCompleteMessagesOptionEvaluatedValue, strategy: processorStrategy)));

            _sessionMessageProcessor = new Lazy<SessionMessageProcessor>(
                () => messagingProvider.CreateSessionMessageProcessor(
                    _client.Value,
                    _entityPath,
                    options.ToSessionProcessorOptions(_autoCompleteMessagesOptionEvaluatedValue, strategy: processorStrategy)));

            _scaleMonitor = new Lazy<ServiceBusScaleMonitor>(
                () => new ServiceBusScaleMonitor(
                    functionId,
                    entityType,
                    _entityPath,
                    connection,
                    _batchReceiver,
                    loggerFactory,
                    clientFactory));

            _singleDispatch = singleDispatch;
            _serviceBusOptions = options;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (_started)
            {
                throw new InvalidOperationException("The listener has already been started.");
            }

            if (_singleDispatch)
            {
                if (_isSessionsEnabled)
                {
                    _sessionMessageProcessor.Value.Processor.ProcessMessageAsync += ProcessSessionMessageAsync;
                    await _sessionMessageProcessor.Value.Processor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _messageProcessor.Value.Processor.ProcessMessageAsync += ProcessMessageAsync;
                    await _messageProcessor.Value.Processor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                _batchLoop = RunBatchReceiveLoopAsync(_cancellationTokenSource.Token);
            }
            _started = true;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            await _stopAsyncSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            {
                try
                {
                    if (!_started)
                    {
                        throw new InvalidOperationException("The listener has not yet been started or has already been stopped.");
                    }

                    _cancellationTokenSource.Cancel();

                    // CloseAsync method stop new messages from being processed while allowing in-flight messages to be processed.
                    if (_singleDispatch)
                    {
                        if (_isSessionsEnabled)
                        {
                            await _sessionMessageProcessor.Value.Processor.CloseAsync(cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            await _messageProcessor.Value.Processor.CloseAsync(cancellationToken).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        await _batchLoop.ConfigureAwait(false);
                        await _batchReceiver.Value.CloseAsync(cancellationToken).ConfigureAwait(false);
                    }

                    _started = false;
                }
                finally
                {
                    _stopAsyncSemaphore.Release();
                }
            }
        }

        public void Cancel()
        {
            ThrowIfDisposed();
            _cancellationTokenSource.Cancel();
        }

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_cancellationTokenSource")]
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            // Running callers might still be using the cancellation token.
            // Mark it canceled but don't dispose of the source while the callers are running.
            // Otherwise, callers would receive ObjectDisposedException when calling token.Register.
            // For now, rely on finalization to clean up _cancellationTokenSource's wait handle (if allocated).
            _cancellationTokenSource.Cancel();

            if (_batchReceiver.IsValueCreated)
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                _batchReceiver.Value.CloseAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }

            if (_messageProcessor.IsValueCreated)
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                _messageProcessor.Value.Processor.CloseAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }

            if (_client.IsValueCreated)
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                _client.Value.DisposeAsync().AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }

            _stopAsyncSemaphore.Dispose();
            _cancellationTokenSource.Dispose();
            _batchReceiveRegistration.Dispose();

            _disposed = true;
        }

        internal async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _cancellationTokenSource.Token))
            {
                var actions = new ServiceBusMessageActions(args);
                if (!await _messageProcessor.Value.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token).ConfigureAwait(false))
                {
                    return;
                }

                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message);
                input.MessageActions = actions;

                TriggeredFunctionData data = input.GetTriggerFunctionData();
                FunctionResult result = await _triggerExecutor.TryExecuteAsync(data, linkedCts.Token).ConfigureAwait(false);
                await _messageProcessor.Value.CompleteProcessingMessageAsync(actions, args.Message, result, linkedCts.Token).ConfigureAwait(false);
            }
        }

        internal async Task ProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
        {
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _cancellationTokenSource.Token))
            {
                var actions = new ServiceBusSessionMessageActions(args);
                if (!await _sessionMessageProcessor.Value.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token).ConfigureAwait(false))
                {
                    return;
                }

                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message);
                input.MessageActions = actions;

                TriggeredFunctionData data = input.GetTriggerFunctionData();
                FunctionResult result = await _triggerExecutor.TryExecuteAsync(data, linkedCts.Token).ConfigureAwait(false);
                await _sessionMessageProcessor.Value.CompleteProcessingMessageAsync(actions, args.Message, result, linkedCts.Token).ConfigureAwait(false);
            }
        }

        private async Task RunBatchReceiveLoopAsync(CancellationToken cancellationToken)
        {
            ServiceBusClient sessionClient = null;
            ServiceBusReceiver receiver = null;
            if (_isSessionsEnabled)
            {
                sessionClient = _client.Value;
            }
            else
            {
                receiver = _batchReceiver.Value;
            }

            while (true)
            {
                try
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogInformation("Message processing has been stopped or cancelled");
                        return;
                    }

                    if (_concurrencyManager.Enabled)
                    {
                        // Dynamic concurrency is enabled so consult ConcurrencyManager to see if we're safe to start new invocations.
                        // Because we're only executing functions below one at a time serially, we only need to check here whether throttles
                        // are enabled.
                        var concurrencyStatus = _concurrencyManager.GetStatus(_functionId);
                        if (concurrencyStatus.ThrottleStatus.State == ThrottleState.Enabled)
                        {
                            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                            continue;
                        }
                    }

                    if (_isSessionsEnabled && (receiver == null || receiver.IsClosed))
                    {
                        try
                        {
                            receiver = await sessionClient.AcceptNextSessionAsync(
                                _entityPath,
                                new ServiceBusSessionReceiverOptions
                                {
                                    PrefetchCount = _serviceBusOptions.PrefetchCount
                                },
                                cancellationToken).ConfigureAwait(false);
                        }
                        catch (ServiceBusException ex)
                            when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
                        {
                            // it's expected if the entity is empty, try next time
                            continue;
                        }
                    }

                    IReadOnlyList<ServiceBusReceivedMessage> messages =
                        await receiver.ReceiveMessagesAsync(
                            _serviceBusOptions.MaxBatchSize,
                            cancellationToken: cancellationToken).AwaitWithCancellation(cancellationToken);

                    if (messages.Count > 0)
                    {
                        ServiceBusReceivedMessage[] messagesArray = messages.ToArray();
                        ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateBatch(messagesArray);
                        if (_isSessionsEnabled)
                        {
                            input.MessageActions = new ServiceBusSessionMessageActions((ServiceBusSessionReceiver)receiver);
                        }
                        else
                        {
                            input.MessageActions = new ServiceBusMessageActions(receiver);
                        }
                        FunctionResult result = await _triggerExecutor.TryExecuteAsync(input.GetTriggerFunctionData(), cancellationToken).ConfigureAwait(false);

                        // Complete batch of messages only if the execution was successful
                        if (_autoCompleteMessagesOptionEvaluatedValue)
                        {
                            if (result.Succeeded)
                            {
                                List<Task> completeTasks = new List<Task>();
                                foreach (ServiceBusReceivedMessage message in messagesArray)
                                {
                                    // skip messages that were settled in the user's function
                                    if (input.MessageActions.SettledMessages.Contains(message))
                                    {
                                        continue;
                                    }

                                    // Pass CancellationToken.None to allow autocompletion to finish even when shutting down
                                    completeTasks.Add(receiver.CompleteMessageAsync(message, CancellationToken.None));
                                }

                                await Task.WhenAll(completeTasks).ConfigureAwait(false);
                            }
                            else
                            {
                                List<Task> abandonTasks = new List<Task>();
                                foreach (ServiceBusReceivedMessage message in messagesArray)
                                {
                                    // skip messages that were settled in the user's function
                                    if (input.MessageActions.SettledMessages.Contains(message))
                                    {
                                        continue;
                                    }

                                    // Pass CancellationToken.None to allow abandon to finish even when shutting down
                                    abandonTasks.Add(receiver.AbandonMessageAsync(message, cancellationToken: CancellationToken.None));
                                }

                                await Task.WhenAll(abandonTasks).ConfigureAwait(false);
                            }
                        }
                    }
                    else
                    {
                        // Close the session and release the session lock after draining all messages for the accepted session.
                        if (_isSessionsEnabled)
                        {
                            // Use CancellationToken.None to attempt to close the receiver even when shutting down
                            await receiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                        }
                    }
                }
                catch (ObjectDisposedException)
                {
                    // Ignore as we are stopping the host
                }
                catch (OperationCanceledException)
                    when(cancellationToken.IsCancellationRequested)
                {
                    // Ignore as we are stopping the host
                    _logger.LogInformation("Message processing has been stopped or cancelled");
                }
                catch (Exception ex)
                {
                    // Log another exception
                    _logger.LogError(ex, $"An unhandled exception occurred in the message batch receive loop");

                    if (_isSessionsEnabled && receiver != null)
                    {
                        // Attempt to close the session and release session lock to accept a new session on the next loop iteration
                        try
                        {
                            // Use CancellationToken.None to attempt to close the receiver even when shutting down
                            await receiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                        }
                        catch
                        {
                            // Best effort
                            receiver = null;
                        }
                    }
                }
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor.Value;
        }

        /// <summary>
        /// Dynamic strategy that adjusts the concurrency level over time.
        /// </summary>
        private class DynamicServiceBusProcessorStrategy : ServiceBusProcessorStrategy
        {
            private readonly ConcurrencyManager _concurrencyManager;
            private readonly string _functionId;
            private readonly object _syncLock = new object();
            private readonly List<ReceiverInfo> _activeReceiveTasks = new List<ReceiverInfo>();

            public DynamicServiceBusProcessorStrategy(ConcurrencyManager concurrencyManager, string functionId)
            {
                _concurrencyManager = concurrencyManager;
                _functionId = functionId;
            }

            public override async Task AdjustReceiverCountAsync(Func<CancellationToken, Task> createReceiver, CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    lock (_syncLock)
                    {
                        // periodic cleanup of completed tasks
                        var completedReceiveTasks = _activeReceiveTasks.Where(p => p.Task.IsCompleted).ToArray();
                        foreach (var currReceiveTask in completedReceiveTasks)
                        {
                            _activeReceiveTasks.Remove(currReceiveTask);
                        }
                    }

                    var concurrencyStatus = _concurrencyManager.GetStatus(_functionId);

                    int activeReceiverCount = _activeReceiveTasks.Count;
                    if (activeReceiverCount > concurrencyStatus.CurrentConcurrency)
                    {
                        lock (_syncLock)
                        {
                            // we're over the limit of receivers, so we need to cancel one
                            var receiverToCancel = _activeReceiveTasks.First();
                            _activeReceiveTasks.Remove(receiverToCancel);
                            receiverToCancel.TokenSource.Cancel();
                        }
                    }
                    else if (activeReceiverCount < concurrencyStatus.CurrentConcurrency)
                    {
                        // our current receive count is under limit so we're clear to start another
                        lock (_syncLock)
                        {
                            var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                            ReceiverInfo info = new ReceiverInfo
                            {
                                Task = createReceiver(tokenSource.Token),
                                TokenSource = tokenSource
                            };
                            _activeReceiveTasks.Add(info);
                        }
                        break;
                    }
                    else
                    {
                        // we're at our current receiver limit so no adjustment to be made
                        // we want to wait for a bit before checking again
                        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            public override ReceiverStatus GetReceiverStatus()
            {
                // This dynamic receiver strategy ensures that the receiver count stays less than or equal
                // to the current concurrency level. So below, it suffices to check whether throttles are enabled.
                // If throttles are currently enabled, the receive loop will continue without receiving a message.
                var concurrencyStatus = _concurrencyManager.GetStatus(_functionId);

                return new ReceiverStatus
                {
                    CanReceive = concurrencyStatus.ThrottleStatus.State != ThrottleState.Enabled
                };
            }

            public override Task StopReceiverAsync(Task receiveTask, CancellationToken cancellationToken)
            {
                lock (_syncLock)
                {
                    var taskToRemove = _activeReceiveTasks.FirstOrDefault(p => p.Task == receiveTask);
                    if (taskToRemove != null)
                    {
                        // TODO: should we remove this immediately here?
                        _activeReceiveTasks.Remove(taskToRemove);
                    }
                }

                return Task.CompletedTask;
            }

            public override async Task CompleteAsync()
            {
                // hold onto all the tasks that we are starting so that when cancellation is requested,
                // we can await them to make sure we surface any unexpected exceptions, i.e. exceptions
                // other than TaskCanceledExceptions
                var receiveTasks = _activeReceiveTasks.Select(p => p.Task).ToArray();
                await Task.WhenAll(receiveTasks).ConfigureAwait(false);
            }

            private class ReceiverInfo
            {
                public Task Task { get; set; }
                public CancellationTokenSource TokenSource { get; set; }
            }
        }
    }
}
