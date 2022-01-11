﻿// Copyright (c) .NET Foundation. All rights reserved.
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
        private readonly ConcurrencyUpdateManager _concurrencyUpdateManager;

        private volatile bool _disposed;
        private volatile bool _started;
        // Serialize execution of StopAsync to avoid calling Unregister* concurrently
        private readonly SemaphoreSlim _stopAsyncSemaphore = new SemaphoreSlim(1, 1);
        private readonly string _functionId;
        private CancellationTokenRegistration _batchReceiveRegistration;
        private Task _batchLoop;
        private Lazy<string> _details;

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
            _functionId = functionId;

            _client = new Lazy<ServiceBusClient>(
                () =>
                    clientFactory.CreateClientFromSetting(connection));

            _batchReceiver = new Lazy<ServiceBusReceiver>(
                () => messagingProvider.CreateBatchMessageReceiver(
                    _client.Value,
                    _entityPath,
                    options.ToReceiverOptions()));

            _messageProcessor = new Lazy<MessageProcessor>(
                () =>
                {
                    var processorOptions = options.ToProcessorOptions(_autoCompleteMessagesOptionEvaluatedValue, concurrencyManager.Enabled);
                    return messagingProvider.CreateMessageProcessor(_client.Value, _entityPath, processorOptions);
                });

            _sessionMessageProcessor = new Lazy<SessionMessageProcessor>(
                () =>
                {
                    var sessionProcessorOptions = options.ToSessionProcessorOptions(_autoCompleteMessagesOptionEvaluatedValue, concurrencyManager.Enabled);
                    return messagingProvider.CreateSessionMessageProcessor(_client.Value,_entityPath, sessionProcessorOptions);
                });

            _scaleMonitor = new Lazy<ServiceBusScaleMonitor>(
                () => new ServiceBusScaleMonitor(
                    functionId,
                    entityType,
                    _entityPath,
                    connection,
                    _batchReceiver,
                    loggerFactory,
                    clientFactory));

            if (concurrencyManager.Enabled)
            {
                _concurrencyUpdateManager = new ConcurrencyUpdateManager(concurrencyManager, _messageProcessor, _sessionMessageProcessor, _isSessionsEnabled, _functionId, _logger);
            }

            _singleDispatch = singleDispatch;
            _serviceBusOptions = options;

            _details = new Lazy<string>(() => $"namespace='{_client.Value?.FullyQualifiedNamespace}', enityPath='{_entityPath}', singleDispatch='{_singleDispatch}', " +
                $"isSessionsEnabled='{_isSessionsEnabled}', functionId='{_functionId}'");
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

                _concurrencyUpdateManager?.Start();
            }
            else
            {
                _batchLoop = RunBatchReceiveLoopAsync(_cancellationTokenSource.Token);
            }
            _started = true;

            _logger.LogDebug($"ServiceBus listener started ({_details.Value})");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            _concurrencyUpdateManager?.Stop();

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
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"ServiceBus listener exception during stopping ({_details.Value})");
                    throw;
                }
                finally
                {
                    _stopAsyncSemaphore.Release();
                    _logger.LogDebug($"ServiceBus listener stopped ({_details.Value})");
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
            _concurrencyUpdateManager?.Dispose();

            _disposed = true;
        }

        internal async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            _concurrencyUpdateManager?.MessageProcessed();

            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _cancellationTokenSource.Token))
            {
                var actions = new ServiceBusMessageActions(args);
                if (!await _messageProcessor.Value.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token).ConfigureAwait(false))
                {
                    return;
                }

                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message, actions, _client.Value);

                TriggeredFunctionData data = input.GetTriggerFunctionData();
                FunctionResult result = await _triggerExecutor.TryExecuteAsync(data, linkedCts.Token).ConfigureAwait(false);
                await _messageProcessor.Value.CompleteProcessingMessageAsync(actions, args.Message, result, linkedCts.Token).ConfigureAwait(false);
            }
        }

        internal async Task ProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
        {
            _concurrencyUpdateManager?.MessageProcessed();

            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _cancellationTokenSource.Token))
            {
                var actions = new ServiceBusSessionMessageActions(args);
                if (!await _sessionMessageProcessor.Value.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token).ConfigureAwait(false))
                {
                    return;
                }

                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message, actions, _client.Value);

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

            // The batch receive loop below only executes functions at a concurrency level of 1,
            // so we don't need to do anything special when DynamicConcurrency is enabled. If in
            // the future we make this loop concurrent, we'll have to check with ConcurrencyManager.
            while (true)
            {
                try
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        _logger.LogInformation($"Message processing has been stopped or cancelled ({_details.Value})");
                        return;
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
                            _serviceBusOptions.MaxMessageBatchSize,
                            cancellationToken: cancellationToken).AwaitWithCancellation(cancellationToken);

                    if (messages.Count > 0)
                    {
                        ServiceBusReceivedMessage[] messagesArray = messages.ToArray();
                        ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateBatch(
                            messagesArray,
                            _isSessionsEnabled ? new ServiceBusSessionMessageActions((ServiceBusSessionReceiver)receiver) : new ServiceBusMessageActions(receiver),
                            _client.Value);

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
                                    if (input.MessageActions.SettledMessages.ContainsKey(message))
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
                                    if (input.MessageActions.SettledMessages.ContainsKey(message))
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
                    _logger.LogInformation($"Message processing has been stopped or cancelled ({_details.Value})");
                }
                catch (Exception ex)
                {
                    // Log another exception
                    _logger.LogError(ex, $"An unhandled exception occurred in the message batch receive loop ({_details.Value})");

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
        /// Responsible for handling dynamic concurrency concurrency updates for message processors.
        /// </summary>
        internal class ConcurrencyUpdateManager : IDisposable
        {
            private const int ConcurrencyUpdateIntervalMS = 1000;

            private readonly Timer _concurrencyUpdateTimer;
            private readonly ConcurrencyManager _concurrencyManager;
            private readonly string _functionId;
            private readonly bool _isSessionsEnabled;
            private readonly Lazy<MessageProcessor> _messageProcessor;
            private readonly Lazy<SessionMessageProcessor> _sessionMessageProcessor;
            private readonly ILogger _logger;

            private volatile bool _messagesProcessedSinceLastConcurrencyUpdate;
            private bool _disposed;

            public ConcurrencyUpdateManager(ConcurrencyManager concurrencyManager, Lazy<MessageProcessor> messageProcessor, Lazy<SessionMessageProcessor> sessionMessageProcessor, bool sessionsEnabled, string functionId, ILogger logger)
            {
                _concurrencyManager = concurrencyManager;
                _messageProcessor = messageProcessor;
                _sessionMessageProcessor = sessionMessageProcessor;
                _isSessionsEnabled = sessionsEnabled;
                _functionId = functionId;
                _logger = logger;

                if (concurrencyManager.Enabled)
                {
                    _concurrencyUpdateTimer = new Timer(UpdateConcurrency, null, Timeout.Infinite, Timeout.Infinite);
                }
            }

            public void Start()
            {
                _concurrencyUpdateTimer?.Change(ConcurrencyUpdateIntervalMS, Timeout.Infinite);
            }

            public void Stop()
            {
                _concurrencyUpdateTimer?.Change(Timeout.Infinite, Timeout.Infinite);
            }

            public void MessageProcessed()
            {
                _messagesProcessedSinceLastConcurrencyUpdate = true;
            }

            private void UpdateConcurrency(object state)
            {
                try
                {
                    UpdateConcurrency();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled exception in concurrency update handler.");
                }
                finally
                {
                    _concurrencyUpdateTimer.Change(ConcurrencyUpdateIntervalMS, Timeout.Infinite);
                }
            }

            /// <summary>
            /// Check current concurrency levels for this function, and adjust processor concurrency as necessary.
            /// </summary>
            public void UpdateConcurrency()
            {
                if (!_messagesProcessedSinceLastConcurrencyUpdate)
                {
                    // if the function is currently inactive, we can skip the concurrency update check
                    return;
                }
                _messagesProcessedSinceLastConcurrencyUpdate = false;

                // below we'll dynamically update the processor with new concurrency values if any
                // need to be changed
                var concurrencyStatus = _concurrencyManager.GetStatus(_functionId);
                var currentConcurrency = concurrencyStatus.CurrentConcurrency;

                if (_isSessionsEnabled)
                {
                    var sessionProcessor = _sessionMessageProcessor.Value.Processor;
                    if (currentConcurrency != sessionProcessor.MaxConcurrentSessions)
                    {
                        // Per session call concurrency is limited to 1 meaning sessions are 1:1 with invocations.
                        // So we can scale MaxConcurrentSessions 1:1 with CurrentConcurrency.
                        sessionProcessor.UpdateConcurrency(currentConcurrency, sessionProcessor.MaxConcurrentCallsPerSession);
                    }
                }
                else
                {
                    var processor = _messageProcessor.Value.Processor;
                    if (currentConcurrency != processor.MaxConcurrentCalls)
                    {
                        processor.UpdateConcurrency(currentConcurrency);
                    }
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _concurrencyUpdateTimer?.Dispose();
                    }

                    _disposed = true;
                }
            }

            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }
    }
}
