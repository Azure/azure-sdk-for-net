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
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal sealed class ServiceBusListener : IListener, IScaleMonitorProvider
    {
        private readonly MessagingProvider _messagingProvider;
        private readonly ITriggeredFunctionExecutor _triggerExecutor;
        private readonly string _functionId;
        private readonly EntityType _entityType;
        private readonly string _entityPath;
        private readonly bool _isSessionsEnabled;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly MessageProcessor _messageProcessor;
        private readonly ServiceBusAccount _serviceBusAccount;
        private readonly ServiceBusOptions _serviceBusOptions;
        private readonly ILoggerFactory _loggerFactory;
        private readonly bool _singleDispatch;
        private readonly ILogger<ServiceBusListener> _logger;

        private Lazy<ServiceBusReceiver> _batchReceiver;
        private Lazy<ServiceBusClient> _sessionClient;
        private bool _disposed;
        private bool _started;
        // Serialize execution of StopAsync to avoid calling Unregister* concurrently
        private readonly SemaphoreSlim _stopAsyncSemaphore = new SemaphoreSlim(1, 1);

        private SessionMessageProcessor _sessionMessageProcessor;

        private Lazy<ServiceBusScaleMonitor> _scaleMonitor;

        public ServiceBusListener(string functionId, EntityType entityType, string entityPath, bool isSessionsEnabled, ITriggeredFunctionExecutor triggerExecutor,
            ServiceBusOptions config, ServiceBusAccount serviceBusAccount, MessagingProvider messagingProvider, ILoggerFactory loggerFactory, bool singleDispatch)
        {
            _functionId = functionId;
            _entityType = entityType;
            _entityPath = entityPath;
            _isSessionsEnabled = isSessionsEnabled;
            _triggerExecutor = triggerExecutor;
            _cancellationTokenSource = new CancellationTokenSource();
            _messagingProvider = messagingProvider;
            _serviceBusAccount = serviceBusAccount;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<ServiceBusListener>();
            _batchReceiver = CreateMessageReceiver();
            _sessionClient = CreateSessionClient();
            _scaleMonitor = new Lazy<ServiceBusScaleMonitor>(() => new ServiceBusScaleMonitor(_functionId, _entityType, _entityPath, _serviceBusAccount.ConnectionString, _batchReceiver, _loggerFactory));
            _singleDispatch = singleDispatch;

            if (_isSessionsEnabled)
            {
                _sessionMessageProcessor = _messagingProvider.CreateSessionMessageProcessor(_entityPath, _serviceBusAccount.ConnectionString);
            }
            else
            {
                _messageProcessor = _messagingProvider.CreateMessageProcessor(entityPath, _serviceBusAccount.ConnectionString);
            }
            _serviceBusOptions = config;
        }

        internal ServiceBusReceiver BatchReceiver => _batchReceiver.Value;

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
                    _sessionMessageProcessor.Processor.ProcessMessageAsync += ProcessSessionMessageAsync;
                    await _sessionMessageProcessor.Processor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _messageProcessor.Processor.ProcessMessageAsync += ProcessMessageAsync;
                    await _messageProcessor.Processor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                StartMessageBatchReceiver(_cancellationTokenSource.Token);
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

                    // Unregister* methods stop new messages from being processed while allowing in-flight messages to complete.
                    // As the amount of time functions are allowed to complete processing varies by SKU, we specify max timespan
                    // as the amount of time Service Bus SDK should wait for in-flight messages to complete procesing after
                    // unregistering the message handler so that functions have as long as the host continues to run time to complete.
                    if (_singleDispatch)
                    {
                        if (_isSessionsEnabled)
                        {
                            await _sessionMessageProcessor.Processor.StopProcessingAsync(cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            await _messageProcessor.Processor.StopProcessingAsync(cancellationToken).ConfigureAwait(false);
                        }
                    }
                    // Batch processing will be stopped via the _started flag on its next iteration

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
            if (!_disposed)
            {
                // Running callers might still be using the cancellation token.
                // Mark it canceled but don't dispose of the source while the callers are running.
                // Otherwise, callers would receive ObjectDisposedException when calling token.Register.
                // For now, rely on finalization to clean up _cancellationTokenSource's wait handle (if allocated).
                _cancellationTokenSource.Cancel();

                if (_batchReceiver != null && _batchReceiver.IsValueCreated)
                {
                    BatchReceiver.CloseAsync().Wait();
                    _batchReceiver = null;
                }

                if (_sessionClient != null && _sessionClient.IsValueCreated)
                {
#pragma warning disable AZC0107 // DO NOT call public asynchronous method in synchronous scope.
                    _sessionClient.Value.DisposeAsync().EnsureCompleted();
#pragma warning restore AZC0107 // DO NOT call public asynchronous method in synchronous scope.
                    _sessionClient = null;
                }

                _stopAsyncSemaphore.Dispose();
                _cancellationTokenSource.Dispose();

                _disposed = true;
            }
        }

        private Lazy<ServiceBusReceiver> CreateMessageReceiver()
        {
            return new Lazy<ServiceBusReceiver>(() => _messagingProvider.CreateBatchMessageReceiver(_entityPath, _serviceBusAccount.ConnectionString));
        }

        private Lazy<ServiceBusClient> CreateSessionClient()
        {
            return new Lazy<ServiceBusClient>(() => _messagingProvider.CreateSessionClient(_serviceBusAccount.ConnectionString));
        }

        internal async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _cancellationTokenSource.Token))
            {
                var actions = new ServiceBusMessageActions(args);
                if (!await _messageProcessor.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token).ConfigureAwait(false))
                {
                    return;
                }

                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message);
                input.MessageActions = actions;

                TriggeredFunctionData data = input.GetTriggerFunctionData();
                FunctionResult result = await _triggerExecutor.TryExecuteAsync(data, linkedCts.Token).ConfigureAwait(false);
                await _messageProcessor.CompleteProcessingMessageAsync(actions, args.Message, result, linkedCts.Token).ConfigureAwait(false);
            }
        }

        internal async Task ProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
        {
            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _cancellationTokenSource.Token))
            {
                var actions = new ServiceBusSessionMessageActions(args);
                if (!await _sessionMessageProcessor.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token).ConfigureAwait(false))
                {
                    return;
                }

                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message);
                input.MessageActions = actions;

                TriggeredFunctionData data = input.GetTriggerFunctionData();
                FunctionResult result = await _triggerExecutor.TryExecuteAsync(data, linkedCts.Token).ConfigureAwait(false);
                await _sessionMessageProcessor.CompleteProcessingMessageAsync(actions, args.Message, result, linkedCts.Token).ConfigureAwait(false);
            }
        }

        internal void StartMessageBatchReceiver(CancellationToken cancellationToken)
        {
            ServiceBusClient sessionClient = null;
            ServiceBusReceiver receiver = null;
            if (_isSessionsEnabled)
            {
                sessionClient = _sessionClient.Value;
            }
            else
            {
                receiver = BatchReceiver;
            }

            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        if (!_started || cancellationToken.IsCancellationRequested)
                        {
                            _logger.LogInformation("Message processing has been stopped or cancelled");
                            return;
                        }

                        if (_isSessionsEnabled && ( receiver == null || receiver.IsClosed))
                        {
                            try
                            {
                                receiver = await sessionClient.AcceptNextSessionAsync(_entityPath, new ServiceBusSessionReceiverOptions
                                {
                                    PrefetchCount = _serviceBusOptions.PrefetchCount
                                }).ConfigureAwait(false);
                            }
                            catch (ServiceBusException ex)
                            when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
                            {
                                // it's expected if the entity is empty, try next time
                                continue;
                            }
                        }

                        IReadOnlyList<ServiceBusReceivedMessage> messages =
                            await receiver.ReceiveMessagesAsync(_serviceBusOptions.MaxMessages).ConfigureAwait(false);

                        if (messages != null)
                        {
                            ServiceBusReceivedMessage[] messagesArray = messages.ToArray();
                            ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateBatch(messagesArray);
                            if (_isSessionsEnabled)
                            {
                                input.MessageActions = new ServiceBusSessionMessageActions((ServiceBusSessionReceiver) receiver);
                            }
                            else
                            {
                                input.MessageActions = new ServiceBusMessageActions(receiver);
                            }
                            FunctionResult result = await _triggerExecutor.TryExecuteAsync(input.GetTriggerFunctionData(), cancellationToken).ConfigureAwait(false);

                            if (cancellationToken.IsCancellationRequested)
                            {
                                return;
                            }

                            // Complete batch of messages only if the execution was successful
                            if (_serviceBusOptions.AutoCompleteMessages && _started)
                            {
                                if (result.Succeeded)
                                {
                                    List<Task> completeTasks = new List<Task>();
                                    foreach (ServiceBusReceivedMessage message in messagesArray)
                                    {
                                        completeTasks.Add(receiver.CompleteMessageAsync(message));
                                    }
                                    await Task.WhenAll(completeTasks).ConfigureAwait(false);
                                }
                                else
                                {
                                    List<Task> abandonTasks = new List<Task>();
                                    foreach (ServiceBusReceivedMessage message in messagesArray)
                                    {
                                        abandonTasks.Add(receiver.AbandonMessageAsync(message));
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
                                await receiver.CloseAsync().ConfigureAwait(false);
                            }
                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        // Ignore as we are stopping the host
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
                                await receiver.CloseAsync().ConfigureAwait(false);
                            }
                            catch
                            {
                                // Best effort
                                receiver = null;
                            }
                        }
                    }
                }
            }, cancellationToken);
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
    }
}
