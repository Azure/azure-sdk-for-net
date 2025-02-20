// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Diagnostics;
using Azure.Core.Shared;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal sealed class ServiceBusListener : IListener, IScaleMonitorProvider, ITargetScalerProvider
    {
        private readonly ITriggeredFunctionExecutor _triggerExecutor;
        private readonly string _entityPath;
        private readonly bool _isSessionsEnabled;
        private readonly bool _autoCompleteMessages;
        private readonly int _maxMessageBatchSize;
        private readonly CancellationTokenSource _stoppingCancellationTokenSource;
        private readonly CancellationTokenSource _functionExecutionCancellationTokenSource;
        private readonly ServiceBusOptions _serviceBusOptions;
        private readonly bool _singleDispatch;
        private readonly ILogger<ServiceBusListener> _logger;

        private readonly Lazy<MessageProcessor> _messageProcessor;
        private readonly Lazy<ServiceBusReceiver> _batchReceiver;
        private readonly Lazy<ServiceBusClient> _client;
        private readonly Lazy<SessionMessageProcessor> _sessionMessageProcessor;
        private readonly Lazy<ServiceBusScaleMonitor> _scaleMonitor;
        private readonly Lazy<ServiceBusTargetScaler> _targetScaler;
        private readonly Lazy<ServiceBusAdministrationClient> _administrationClient;
        private readonly ConcurrencyUpdateManager _concurrencyUpdateManager;

        // Minimum batch size support
        private Task _backgroundCacheMonitoringTask;
        private readonly SemaphoreSlim _cachedMessagesGuard;
        private readonly bool _supportMinBatchSize;
        private CancellationTokenSource _backgroundCacheMonitoringCts;
        private ServiceBusMessageManager _cachedMessagesManager;
        private ValueStopwatch _cycleDuration;
        private ServiceBusMessageActions _monitoringCycleMessageActions;
        private ServiceBusReceiveActions _monitoringCycleReceiveActions;
        private ServiceBusReceiver _monitoringCycleReceiver;

        // internal for testing
        internal volatile bool Disposed;
        internal volatile bool Started;

        // Serialize execution of StopAsync to avoid calling Unregister* concurrently
        private readonly SemaphoreSlim _stopAsyncSemaphore = new SemaphoreSlim(1, 1);
        private readonly string _functionId;
        private Task _batchLoop;
        private Lazy<string> _details;
        private Lazy<MessagingClientDiagnostics> _clientDiagnostics;
        private readonly IDrainModeManager _drainModeManager;
        private readonly MessagingProvider _messagingProvider;

        public ServiceBusListener(
            string functionId,
            ServiceBusEntityType entityType,
            string entityPath,
            bool isSessionsEnabled,
            bool autoCompleteMessages,
            int maxMessageBatchSize,
            ITriggeredFunctionExecutor triggerExecutor,
            ServiceBusOptions options,
            string connection,
            MessagingProvider messagingProvider,
            ILoggerFactory loggerFactory,
            bool singleDispatch,
            ServiceBusClientFactory clientFactory,
            ConcurrencyManager concurrencyManager,
            IDrainModeManager drainModeManager)
        {
            _entityPath = entityPath;
            _isSessionsEnabled = isSessionsEnabled;
            _autoCompleteMessages = autoCompleteMessages;
            _maxMessageBatchSize = maxMessageBatchSize;
            _triggerExecutor = triggerExecutor;
            _stoppingCancellationTokenSource = new CancellationTokenSource();
            _functionExecutionCancellationTokenSource = new CancellationTokenSource();
            _logger = loggerFactory.CreateLogger<ServiceBusListener>();
            _functionId = functionId;
            _drainModeManager = drainModeManager;
            _messagingProvider = messagingProvider;

            _client = new Lazy<ServiceBusClient>(
                () => clientFactory.CreateClientFromSetting(connection));

            _batchReceiver = new Lazy<ServiceBusReceiver>(
                () => messagingProvider.CreateBatchMessageReceiver(
                    _client.Value,
                    _entityPath,
                    options.ToReceiverOptions()));

            _messageProcessor = new Lazy<MessageProcessor>(
                () =>
                {
                    var processorOptions = options.ToProcessorOptions(_autoCompleteMessages, concurrencyManager.Enabled);
                    return messagingProvider.CreateMessageProcessor(_client.Value, _entityPath, processorOptions);
                });

            _sessionMessageProcessor = new Lazy<SessionMessageProcessor>(
                () =>
                {
                    var sessionProcessorOptions = options.ToSessionProcessorOptions(_autoCompleteMessages, concurrencyManager.Enabled);
                    return messagingProvider.CreateSessionMessageProcessor(_client.Value,_entityPath, sessionProcessorOptions);
                });

            _administrationClient = new Lazy<ServiceBusAdministrationClient>(
                () => clientFactory.CreateAdministrationClient(connection));

            _scaleMonitor = new Lazy<ServiceBusScaleMonitor>(
                () => new ServiceBusScaleMonitor(
                    functionId,
                    _entityPath,
                    entityType,
                    _batchReceiver,
                    _administrationClient,
                    loggerFactory
                    ));

            _targetScaler = new Lazy<ServiceBusTargetScaler>(
                () => new ServiceBusTargetScaler(
                    functionId,
                    _entityPath,
                    entityType,
                    _batchReceiver,
                    _administrationClient,
                    options,
                    _isSessionsEnabled,
                    _singleDispatch,
                    loggerFactory
                    ));

            _clientDiagnostics = new Lazy<MessagingClientDiagnostics>(
                () => new MessagingClientDiagnostics(
                    DiagnosticProperty.DiagnosticNamespace,
                    DiagnosticProperty.ResourceProviderNamespace,
                    DiagnosticProperty.ServiceBusServiceContext,
                    _batchReceiver.Value.FullyQualifiedNamespace,
                    _batchReceiver.Value.EntityPath));

            if (concurrencyManager.Enabled)
            {
                _concurrencyUpdateManager = new ConcurrencyUpdateManager(concurrencyManager, _messageProcessor, _sessionMessageProcessor, _isSessionsEnabled, _functionId, _logger);
            }

            _singleDispatch = singleDispatch;
            _serviceBusOptions = options;

            _supportMinBatchSize = options.MinMessageBatchSize > 1;

            _details = new Lazy<string>(() => $"namespace='{_client.Value?.FullyQualifiedNamespace}', entityPath='{_entityPath}', singleDispatch='{_singleDispatch}', " +
                $"isSessionsEnabled='{_isSessionsEnabled}', functionId='{_functionId}'");

            if (_supportMinBatchSize)
            {
                _cachedMessagesManager = new(_maxMessageBatchSize, options.MinMessageBatchSize);
                _cachedMessagesGuard = new SemaphoreSlim(1, 1);
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (Started)
            {
                throw new InvalidOperationException("The listener has already been started.");
            }
            Started = true;

            try
            {
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
                    _batchLoop = RunBatchReceiveLoopAsync(_stoppingCancellationTokenSource);
                }
            }
            catch
            {
                // If we get an exception while attempting to start, reset the Started flag to false so that the host can attempt to
                // start the listener again.
                Started = false;
                throw;
            }

            _logger.LogDebug($"ServiceBus listener started ({_details.Value})");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (!_drainModeManager.IsDrainModeEnabled)
            {
                _functionExecutionCancellationTokenSource.Cancel();
            }

            ThrowIfDisposed();

            _logger.LogDebug($"Attempting to stop ServiceBus listener ({_details.Value})");

            _concurrencyUpdateManager?.Stop();

            await _stopAsyncSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                if (!Started)
                {
                    throw new InvalidOperationException("The listener has not yet been started or has already been stopped.");
                }

                // This will also cancel the background monitoring task through the linked cancellation token source.
                _stoppingCancellationTokenSource.Cancel();

                // CloseAsync method stop new messages from being processed while allowing in-flight messages to be processed.
                if (_singleDispatch)
                {
                    if (_isSessionsEnabled)
                    {
                        await _sessionMessageProcessor.Value.Processor.StopProcessingAsync(cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        await _messageProcessor.Value.Processor.StopProcessingAsync(cancellationToken).ConfigureAwait(false);
                    }
                }
                else
                {
                    // Wait for the batch loop to complete.
                    await _batchLoop.ConfigureAwait(false);

                    // Wait for the background loop to complete, since the cancellation token was canceled above, this will allow
                    // any already started function invocations to finish.
                    if (_backgroundCacheMonitoringCts != null)
                    {
                        await _backgroundCacheMonitoringTask.ConfigureAwait(false);
                    }

                    // Try to dispatch any already received messages.
                    await DispatchRemainingMessages(_monitoringCycleReceiver, _monitoringCycleMessageActions, _monitoringCycleReceiveActions, cancellationToken).ConfigureAwait(false);
                }

                Started = false;
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

        public void Cancel()
        {
            ThrowIfDisposed();
            _stoppingCancellationTokenSource.Cancel();
        }

        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_cancellationTokenSource")]
        public void Dispose()
        {
            if (Disposed)
            {
                return;
            }

            _logger.LogDebug($"Attempting to dispose ServiceBus listener ({_details.Value})");

            // Running callers might still be using the cancellation token.
            // Mark it canceled but don't dispose of the source while the callers are running.
            // Otherwise, callers would receive ObjectDisposedException when calling token.Register.
            // For now, rely on finalization to clean up _cancellationTokenSource's wait handle (if allocated).
            _stoppingCancellationTokenSource.Cancel();
            _functionExecutionCancellationTokenSource.Cancel();

            // ServiceBusClient and receivers will be disposed in CachedClientCleanupService, so as not to dispose it while it's still in
            // use by other listeners. Processors are disposed here as they cannot be shared amongst listeners.

            if (_messageProcessor.IsValueCreated)
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                _messageProcessor.Value.Processor.CloseAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }

            if (_sessionMessageProcessor.IsValueCreated)
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                _sessionMessageProcessor.Value.Processor.CloseAsync(CancellationToken.None).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }

            _stopAsyncSemaphore.Dispose();
            _stoppingCancellationTokenSource.Dispose();
            _concurrencyUpdateManager?.Dispose();

            // No need to dispose the _functionExecutionCancellationTokenSource since we don't create it as a linked token and
            // it won't use a timer, so the Dispose method is essentially a no-op. The downside to disposing it is that
            // any customers who are trying to use it to cancel their own operations would get an ObjectDisposedException.

            Disposed = true;

            _logger.LogDebug($"ServiceBus listener disposed({_details.Value})");
        }

        internal async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            EnsureIsRunning();

            _concurrencyUpdateManager?.MessageProcessed();

            using (CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _stoppingCancellationTokenSource.Token))
            {
                var actions = new ServiceBusMessageActions(args);
                _messagingProvider.ActionsCache.TryAdd(args.Message.LockToken, (args.Message, actions));

                if (!await _messageProcessor.Value.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token).ConfigureAwait(false))
                {
                    return;
                }

                var receiveActions = new ServiceBusReceiveActions(args);
                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message, actions, receiveActions, _client.Value);

                TriggeredFunctionData data = input.GetTriggerFunctionData();

                FunctionResult result = await _triggerExecutor.TryExecuteAsync(data, _functionExecutionCancellationTokenSource.Token).ConfigureAwait(false);
                try
                {
                    await _messageProcessor.Value.CompleteProcessingMessageAsync(actions, args.Message, result, linkedCts.Token)
                        .ConfigureAwait(false);
                }
                finally
                {
                    receiveActions.EndExecutionScope();
                    _messagingProvider.ActionsCache.TryRemove(args.Message.LockToken, out _);
                }
            }
        }

        internal async Task ProcessSessionMessageAsync(ProcessSessionMessageEventArgs args)
        {
            EnsureIsRunning();

            _concurrencyUpdateManager?.MessageProcessed();

            using (CancellationTokenSource linkedCts =
                CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken, _stoppingCancellationTokenSource.Token))
            {
                var actions = new ServiceBusSessionMessageActions(args);
                _messagingProvider.ActionsCache.TryAdd(args.Message.LockToken, (args.Message, actions));
                if (_isSessionsEnabled)
                {
                    _messagingProvider.SessionActionsCache.TryAdd(args.Message.SessionId, actions);
                }

                if (!await _sessionMessageProcessor.Value.BeginProcessingMessageAsync(actions, args.Message, linkedCts.Token)
                    .ConfigureAwait(false))
                {
                    return;
                }

                var receiveActions = new ServiceBusReceiveActions(args);
                ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateSingle(args.Message, actions, receiveActions, _client.Value);

                TriggeredFunctionData data = input.GetTriggerFunctionData();
                FunctionResult result = await _triggerExecutor.TryExecuteAsync(data, _functionExecutionCancellationTokenSource.Token).ConfigureAwait(false);

                if (actions.ShouldReleaseSession)
                {
                    args.ReleaseSession();
                }

                try
                {
                    await _sessionMessageProcessor.Value.CompleteProcessingMessageAsync(actions, args.Message, result, linkedCts.Token)
                        .ConfigureAwait(false);
                }
                finally
                {
                    receiveActions.EndExecutionScope();
                    _messagingProvider.ActionsCache.TryRemove(args.Message.LockToken, out _);
                    if (_isSessionsEnabled)
                    {
                        _messagingProvider.SessionActionsCache.TryRemove(args.Message.SessionId, out _);
                    }
                }
            }
        }

        private void EnsureIsRunning()
        {
            if (!Started || Disposed)
            {
                var message =
                    $"Message received for a listener that is not in a running state. The message will not be delivered to the function, and instead will be abandoned. " +
                    $"(Listener started = {Started}, Listener disposed = {Disposed}, {_details.Value})";
                _logger.LogWarning(message);
                throw new InvalidOperationException(message);
            }
        }

        private async Task RunBatchReceiveLoopAsync(CancellationTokenSource cancellationTokenSource)
        {
            var cancellationToken = cancellationTokenSource.Token;
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

                            // Processing messages from a new session, create a new message cache for that session
                             _cachedMessagesManager = new ServiceBusMessageManager(
                                    maxBatchSize: _maxMessageBatchSize,
                                    minBatchSize: _serviceBusOptions.MinMessageBatchSize);
                        }
                        catch (ServiceBusException ex)
                            when (ex.Reason == ServiceBusFailureReason.ServiceTimeout)
                        {
                            // it's expected if the entity is empty, try next time
                            continue;
                        }
                    }

                    // For non-session receiver, we just fall back to the operation timeout.
                    TimeSpan? maxWaitTime = _isSessionsEnabled ? _serviceBusOptions.SessionIdleTimeout : null;

                    var messages = await receiver.ReceiveMessagesAsync(
                        _maxMessageBatchSize,
                        maxWaitTime,
                        cancellationTokenSource.Token).ConfigureAwait(false);

                    if (messages.Count > 0)
                    {
                        var messageActions = _isSessionsEnabled
                            ? new ServiceBusSessionMessageActions((ServiceBusSessionReceiver)receiver)
                            : new ServiceBusMessageActions(receiver);

                        foreach (var message in messages)
                        {
                            _messagingProvider.ActionsCache.TryAdd(message.LockToken, (message, messageActions));
                            if (_isSessionsEnabled)
                            {
                                _messagingProvider.SessionActionsCache.TryAdd(message.SessionId, (ServiceBusSessionMessageActions)messageActions);
                            }
                        }

                        var receiveActions = new ServiceBusReceiveActions(receiver);

                        ServiceBusReceivedMessage[] messagesArray = _supportMinBatchSize ? Array.Empty<ServiceBusReceivedMessage>() : messages.ToArray();

                        if (_supportMinBatchSize)
                        {
                            var acquiredSemaphore = false;
                            try
                            {
                                if (!_cachedMessagesGuard.Wait(0, cancellationTokenSource.Token))
                                {
                                    await _cachedMessagesGuard.WaitAsync(cancellationTokenSource.Token).ConfigureAwait(false);
                                }
                                acquiredSemaphore = true;

                                // Get set of messages to use for batch here.
                                messagesArray = _cachedMessagesManager.GetBatchofMessagesWithCached(messages.ToArray());
                            }
                            finally
                            {
                                if (acquiredSemaphore)
                                {
                                    _cachedMessagesGuard.Release();
                                }
                            }
                        }

                        if (messagesArray.Length > 0 || !_supportMinBatchSize)
                        {
                            CancelExistingMonitoringTasks();

                            ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateBatch(
                                messagesArray,
                                messageActions,
                                receiveActions,
                                _client.Value);

                            await TriggerWithMessagesInternal(messagesArray, input, receiver, receiveActions, messageActions, cancellationToken).ConfigureAwait(false);
                        }

                        if (_supportMinBatchSize && _cachedMessagesManager.HasCachedMessages)
                        {
                            if (_backgroundCacheMonitoringCts == null)
                            {
                                var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                                _backgroundCacheMonitoringCts = linkedCts;
                                _backgroundCacheMonitoringTask = MonitorCache(linkedCts.Token);
                            }
                            _monitoringCycleReceiver = receiver;
                            _monitoringCycleMessageActions = messageActions;
                            _monitoringCycleReceiveActions = receiveActions;
                        }
                    }
                    else
                    {
                        // Close the session and release the session lock after draining all messages for the accepted session.
                        if (_isSessionsEnabled)
                        {
                            CancelExistingMonitoringTasks();

                            var messageActions = new ServiceBusSessionMessageActions((ServiceBusSessionReceiver)receiver);
                            var receiveActions = new ServiceBusReceiveActions(receiver);

                            // We know we will not get any more messages from this session, so send what is left.
                            await DispatchRemainingMessages(receiver, messageActions, receiveActions, cancellationToken).ConfigureAwait(false);

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
                    var errorMessage = $"An unhandled exception occurred in the message batch receive loop ({_details.Value}).";

                    if (_supportMinBatchSize)
                    {
                        errorMessage += " If a minimum batch size was set, any cached session messages will be abandoned.";
                    }
                    // Log another exception
                    _logger.LogError(ex, errorMessage);

                    if (_isSessionsEnabled && receiver != null)
                    {
                        // Attempt to close the session and release session lock to accept a new session on the next loop iteration

                        // Cancel any monitoring tasks since we are closing the receiver. The next batch loop iteration will drop any
                        // remaining messages in the cache.
                        CancelExistingMonitoringTasks();
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

        private void CancelExistingMonitoringTasks()
        {
            if (_backgroundCacheMonitoringCts != null)
            {
                // Cancel any background monitoring cycles that are in progress
                _backgroundCacheMonitoringCts.Cancel();
                _backgroundCacheMonitoringCts.Dispose();
                _backgroundCacheMonitoringCts = null;
            }
        }

        private async Task TriggerWithMessagesInternal(ServiceBusReceivedMessage[] messagesArray,
                                                   ServiceBusTriggerInput input,
                                                   ServiceBusReceiver receiver,
                                                   ServiceBusReceiveActions receiveActions,
                                                   ServiceBusMessageActions messageActions,
                                                   CancellationToken cancellationToken)
        {
            await TriggerAndCompleteMessagesInternal(messagesArray, input, receiver, receiveActions, messageActions, cancellationToken).ConfigureAwait(false);

            if (_isSessionsEnabled)
            {
                if (((ServiceBusSessionMessageActions)messageActions).ShouldReleaseSession)
                {
                    // Dispatch any remaining messages for this session before releasing
                    if (_supportMinBatchSize)
                    {
                        await DispatchRemainingMessages(receiver, messageActions, receiveActions, cancellationToken).ConfigureAwait(false);
                    }

                    // Use CancellationToken.None to attempt to close the receiver even when shutting down
                    await receiver.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }
            }
        }

        private async Task TriggerAndCompleteMessagesInternal(ServiceBusReceivedMessage[] messagesArray,
                                                   ServiceBusTriggerInput input,
                                                   ServiceBusReceiver receiver,
                                                   ServiceBusReceiveActions receiveActions,
                                                   ServiceBusMessageActions messageActions,
                                                   CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.Value.CreateScope(
                            _isSessionsEnabled ? Constants.ProcessSessionMessagesActivityName : Constants.ProcessMessagesActivityName,
                            ActivityKind.Consumer,
                            MessagingDiagnosticOperation.Process);

            try
            {
                scope.SetMessageData(messagesArray);

                scope.Start();
                FunctionResult result = await _triggerExecutor
                    .TryExecuteAsync(input.GetTriggerFunctionData(), _functionExecutionCancellationTokenSource.Token).ConfigureAwait(false);
                if (result.Exception != null)
                {
                    scope.Failed(result.Exception);
                }

                receiveActions.EndExecutionScope();

                var processedMessages = messagesArray.Concat(receiveActions.Messages.Keys);
                // Complete batch of messages only if the execution was successful
                if (_autoCompleteMessages && result.Succeeded)
                {
                    List<Task> completeTasks = new List<Task>(messagesArray.Length + receiveActions.Messages.Keys.Count);
                    foreach (ServiceBusReceivedMessage message in processedMessages)
                    {
                        // Skip messages that were settled in the user's function
                        if (input.MessageActions.SettledMessages.ContainsKey(message))
                        {
                            continue;
                        }

                        // Pass CancellationToken.None to allow autocompletion to finish even when shutting down
                        completeTasks.Add(receiver.CompleteMessageAsync(message, CancellationToken.None));
                    }

                    await Task.WhenAll(completeTasks).ConfigureAwait(false);
                }
                else if (!result.Succeeded)
                {
                    // For failed executions, we abandon the messages regardless of the autoCompleteMessages configuration.
                    // This matches the behavior that happens for single dispatch functions as the processor does the same thing
                    // in the Service Bus SDK.

                    List<Task> abandonTasks = new();
                    foreach (ServiceBusReceivedMessage message in processedMessages)
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
            finally
            {
                foreach (var message in input.Messages)
                {
                    _messagingProvider.ActionsCache.TryRemove(message.LockToken, out _);
                    if (_isSessionsEnabled)
                    {
                        _messagingProvider.SessionActionsCache.TryRemove(message.SessionId, out _);
                    }
                }
            }
        }

        private async Task DispatchRemainingMessages(ServiceBusReceiver receiver, ServiceBusMessageActions messageActions, ServiceBusReceiveActions receiveActions, CancellationToken cancellationToken)
        {
            if (_supportMinBatchSize && _cachedMessagesManager.HasCachedMessages)
            {
                var acquiredSemaphore = false;
                ServiceBusReceivedMessage[] batchMessages;
                try
                {
                    if (!_cachedMessagesGuard.Wait(0, cancellationToken))
                    {
                        await _cachedMessagesGuard.WaitAsync(cancellationToken).ConfigureAwait(false);
                    }
                    acquiredSemaphore = true;

                    // Get all the messages left in the cache.
                    batchMessages = _cachedMessagesManager.GetBatchofMessagesWithCached(allowPartialBatch: true);
                }
                finally
                {
                    if (acquiredSemaphore)
                    {
                        _cachedMessagesGuard.Release();
                    }
                }

                if (batchMessages.Length > 0)
                {
                    ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateBatch(
                    batchMessages,
                    messageActions,
                    receiveActions,
                    _client.Value);

                    await TriggerAndCompleteMessagesInternal(batchMessages, input, receiver, receiveActions, messageActions, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        private async Task MonitorCache(CancellationToken backgroundCancellationToken)
        {
            var acquiredSemaphore = false;
            try
            {
                _cycleDuration = ValueStopwatch.StartNew();

                // Wait max wait time after starting this task before checking the number of messages.
                while (_cycleDuration.GetElapsedTime() < _serviceBusOptions.MaxBatchWaitTime && !backgroundCancellationToken.IsCancellationRequested)
                {
                    var remainingTime = GetRemainingTime(_cycleDuration.GetElapsedTime());
                    await Task.Delay(remainingTime, backgroundCancellationToken).ConfigureAwait(false);
                }

                // This will throw if the cancellation token has been canceled.
                if (!_cachedMessagesGuard.Wait(0, backgroundCancellationToken))
                {
                    await _cachedMessagesGuard.WaitAsync(backgroundCancellationToken).ConfigureAwait(false);
                }
                acquiredSemaphore = true;

                // Since max wait time has passed, pull all messages out of the cache and invoke the function on it.
                var triggerMessages = _cachedMessagesManager.GetBatchofMessagesWithCached(allowPartialBatch: true);

                if (triggerMessages.Length > 0)
                {
                    ServiceBusTriggerInput input = ServiceBusTriggerInput.CreateBatch(
                            triggerMessages,
                            _monitoringCycleMessageActions,
                            _monitoringCycleReceiveActions,
                            _client.Value);

        await TriggerWithMessagesInternal(triggerMessages, input, _monitoringCycleReceiver, _monitoringCycleReceiveActions, _monitoringCycleMessageActions, backgroundCancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _logger.LogDebug($"Service Bus Listener has waited MaxWaitTime since last invocation but there are no messages still being held.");
                }

                // After one wait cycle, cancel the background task cancellation token source. It can be assumed that there will never be more than the
                // minimum batch size number of messages in the cache. The monitoring cycle will be restarted by the receive batch loop if needed.
                CancelExistingMonitoringTasks();
            }
            catch (OperationCanceledException)
            {
                // Do nothing.
            }
            finally
            {
                if (acquiredSemaphore)
                {
                    _cachedMessagesGuard.Release();
                }
            }
        }

        private TimeSpan GetRemainingTime(TimeSpan elapsed)
        {
            if ((_serviceBusOptions.MaxBatchWaitTime == Timeout.InfiniteTimeSpan) || (_serviceBusOptions.MaxBatchWaitTime == TimeSpan.Zero) || (elapsed == TimeSpan.Zero))
            {
                return _serviceBusOptions.MaxBatchWaitTime;
            }

            if (elapsed >= _serviceBusOptions.MaxBatchWaitTime)
            {
                return TimeSpan.Zero;
            }

            return TimeSpan.FromMilliseconds(_serviceBusOptions.MaxBatchWaitTime.TotalMilliseconds - elapsed.TotalMilliseconds);
        }

        private void ThrowIfDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException(null);
            }
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor.Value;
        }

        public ITargetScaler GetTargetScaler()
        {
            return _targetScaler.Value;
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
                        // Per session call concurrency is limited to 1 when dynamic concurrency is enabled,
                        // meaning the number of sessions are 1:1 with invocations.
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
