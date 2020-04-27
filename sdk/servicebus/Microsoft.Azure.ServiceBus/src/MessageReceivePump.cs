// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Primitives;

    internal sealed class MessageReceivePump
    {
	    private readonly Func<Message, CancellationToken, Task> _onMessageCallback;
	    private readonly string _endpoint;
	    private readonly MessageHandlerOptions _registerHandlerOptions;
	    private readonly IMessageReceiver _messageReceiver;
	    private readonly CancellationToken _pumpCancellationToken;
	    private readonly SemaphoreSlim _maxConcurrentCallsSemaphoreSlim;
	    private readonly ServiceBusDiagnosticSource _diagnosticSource;

        public MessageReceivePump(IMessageReceiver messageReceiver,
            MessageHandlerOptions registerHandlerOptions,
            Func<Message, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken pumpCancellationToken)
        {
            this._messageReceiver = messageReceiver ?? throw new ArgumentNullException(nameof(messageReceiver));
            this._registerHandlerOptions = registerHandlerOptions;
            _onMessageCallback = callback;
            this._endpoint = endpoint.Authority;
            this._pumpCancellationToken = pumpCancellationToken;
            _maxConcurrentCallsSemaphoreSlim = new SemaphoreSlim(this._registerHandlerOptions.MaxConcurrentCalls);
            _diagnosticSource = new ServiceBusDiagnosticSource(messageReceiver.Path, endpoint);
        }

        public void StartPump()
        {
            TaskExtensionHelper.Schedule(() => MessagePumpTaskAsync());
        }

        private bool ShouldRenewLock()
        {
            return
                _messageReceiver.ReceiveMode == ReceiveMode.PeekLock &&
                _registerHandlerOptions.AutoRenewLock;
        }

        private Task RaiseExceptionReceived(Exception e, string action)
        {
            var eventArgs = new ExceptionReceivedEventArgs(e, action, _endpoint, _messageReceiver.Path, _messageReceiver.ClientId);
            return _registerHandlerOptions.RaiseExceptionReceived(eventArgs);
        }

        private async Task MessagePumpTaskAsync()
        {
            while (!_pumpCancellationToken.IsCancellationRequested)
            {
                try
                {
                    await _maxConcurrentCallsSemaphoreSlim.WaitAsync(_pumpCancellationToken).ConfigureAwait(false);

                    TaskExtensionHelper.Schedule(async () =>
                    {
                        Message message = null;
                        try
                        {
                            message = await _messageReceiver.ReceiveAsync(_registerHandlerOptions.ReceiveTimeOut).ConfigureAwait(false);
                            if (message != null)
                            {
                                MessagingEventSource.Log.MessageReceiverPumpTaskStart(_messageReceiver.ClientId, message, _maxConcurrentCallsSemaphoreSlim.CurrentCount);

                                TaskExtensionHelper.Schedule(() =>
                                {
                                    if (ServiceBusDiagnosticSource.IsEnabled())
                                    {
                                        return MessageDispatchTaskInstrumented(message);
                                    }
                                    else
                                    {
                                        return MessageDispatchTask(message);
                                    }
                                });
                            }
                        }
                        catch (OperationCanceledException) when (_pumpCancellationToken.IsCancellationRequested) 
                        {
                            // Ignore as we are stopping the pump
                        }
                        catch (ObjectDisposedException) when (_pumpCancellationToken.IsCancellationRequested)
                        {
                            // Ignore as we are stopping the pump
                        }
                        catch (Exception exception)
                        {
                            MessagingEventSource.Log.MessageReceivePumpTaskException(_messageReceiver.ClientId, string.Empty, exception);
                            await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                        }
                        finally
                        {
                            // Either an exception or for some reason message was null, release semaphore and retry.
                            if (message == null)
                            {
                                _maxConcurrentCallsSemaphoreSlim.Release();
                                MessagingEventSource.Log.MessageReceiverPumpTaskStop(_messageReceiver.ClientId, _maxConcurrentCallsSemaphoreSlim.CurrentCount);
                            }
                        }
                    });
                }
                catch (OperationCanceledException) when (_pumpCancellationToken.IsCancellationRequested)
                {
                    // Ignore as we are stopping the pump
                }
                catch (ObjectDisposedException) when (_pumpCancellationToken.IsCancellationRequested)
                {
                    // Ignore as we are stopping the pump
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.MessageReceivePumpTaskException(_messageReceiver.ClientId, string.Empty, exception);
                    await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                }
            }
        }

        private async Task MessageDispatchTaskInstrumented(Message message)
        {
            Activity activity = _diagnosticSource.ProcessStart(message);
            Task processTask = null;
            try
            {
                processTask = MessageDispatchTask(message);
                await processTask.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _diagnosticSource.ReportException(e);
                throw;
            }
            finally
            {
                _diagnosticSource.ProcessStop(activity, message, processTask?.Status);
            }
        }

        private async Task MessageDispatchTask(Message message)
        {
            CancellationTokenSource renewLockCancellationTokenSource = null;
            Timer autoRenewLockCancellationTimer = null;

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStart(_messageReceiver.ClientId, message);

            if (ShouldRenewLock())
            {
                renewLockCancellationTokenSource = new CancellationTokenSource();
                TaskExtensionHelper.Schedule(() => RenewMessageLockTask(message, renewLockCancellationTokenSource.Token));

                // After a threshold time of renewal('AutoRenewTimeout'), create timer to cancel anymore renewals.
                autoRenewLockCancellationTimer = new Timer(CancelAutoRenewLock, renewLockCancellationTokenSource, _registerHandlerOptions.MaxAutoRenewDuration, TimeSpan.FromMilliseconds(-1));
            }

            try
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStart(_messageReceiver.ClientId, message);
                await _onMessageCallback(message, _pumpCancellationToken).ConfigureAwait(false);

                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStop(_messageReceiver.ClientId, message);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackException(_messageReceiver.ClientId, message, exception);
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.UserCallback).ConfigureAwait(false);

                // Nothing much to do if UserCallback throws, Abandon message and Release semaphore.
                if (!(exception is MessageLockLostException))
                {
                    await AbandonMessageIfNeededAsync(message).ConfigureAwait(false);
                }

                if (ServiceBusDiagnosticSource.IsEnabled())
                {
                    _diagnosticSource.ReportException(exception);
                }
                // AbandonMessageIfNeededAsync should take care of not throwing exception
                _maxConcurrentCallsSemaphoreSlim.Release();

                return;
            }
            finally
            {
                renewLockCancellationTokenSource?.Cancel();
                renewLockCancellationTokenSource?.Dispose();
                autoRenewLockCancellationTimer?.Dispose();
            }

            // If we've made it this far, user callback completed fine. Complete message and Release semaphore.
            await CompleteMessageIfNeededAsync(message).ConfigureAwait(false);
            _maxConcurrentCallsSemaphoreSlim.Release();

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStop(_messageReceiver.ClientId, message, _maxConcurrentCallsSemaphoreSlim.CurrentCount);
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

        private async Task AbandonMessageIfNeededAsync(Message message)
        {
            try
            {
                if (_messageReceiver.ReceiveMode == ReceiveMode.PeekLock)
                {
                    await _messageReceiver.AbandonAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Abandon).ConfigureAwait(false);
            }
        }

        private async Task CompleteMessageIfNeededAsync(Message message)
        {
            try
            {
                if (_messageReceiver.ReceiveMode == ReceiveMode.PeekLock &&
                    _registerHandlerOptions.AutoComplete)
                {
                    await _messageReceiver.CompleteAsync(new[] { message.SystemProperties.LockToken }).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Complete).ConfigureAwait(false);
            }
        }

        private async Task RenewMessageLockTask(Message message, CancellationToken renewLockCancellationToken)
        {
            while (!_pumpCancellationToken.IsCancellationRequested &&
                   !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    var amount = MessagingUtilities.CalculateRenewAfterDuration(message.SystemProperties.LockedUntilUtc);
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageStart(_messageReceiver.ClientId, message, amount);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    var delayTask = await Task.Delay(amount, renewLockCancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }

                    if (!_pumpCancellationToken.IsCancellationRequested &&
                        !renewLockCancellationToken.IsCancellationRequested)
                    {
                        await _messageReceiver.RenewLockAsync(message).ConfigureAwait(false);
                        MessagingEventSource.Log.MessageReceiverPumpRenewMessageStop(_messageReceiver.ClientId, message);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageException(_messageReceiver.ClientId, message, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.RenewLock).ConfigureAwait(false);
                    }

                    if (!MessagingUtilities.ShouldRetry(exception))
                    {
                        break;
                    }
                }
            }
        }
    }
}