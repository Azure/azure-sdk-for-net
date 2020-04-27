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

    sealed class MessageReceivePump
    {
        readonly Func<Message, CancellationToken, Task> onMessageCallback;
        readonly string endpoint;
        readonly MessageHandlerOptions registerHandlerOptions;
        readonly IMessageReceiver messageReceiver;
        readonly CancellationToken pumpCancellationToken;
        readonly SemaphoreSlim maxConcurrentCallsSemaphoreSlim;
        readonly ServiceBusDiagnosticSource diagnosticSource;

        public MessageReceivePump(IMessageReceiver messageReceiver,
            MessageHandlerOptions registerHandlerOptions,
            Func<Message, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken pumpCancellationToken)
        {
            this.messageReceiver = messageReceiver ?? throw new ArgumentNullException(nameof(messageReceiver));
            this.registerHandlerOptions = registerHandlerOptions;
            onMessageCallback = callback;
            this.endpoint = endpoint.Authority;
            this.pumpCancellationToken = pumpCancellationToken;
            maxConcurrentCallsSemaphoreSlim = new SemaphoreSlim(this.registerHandlerOptions.MaxConcurrentCalls);
            diagnosticSource = new ServiceBusDiagnosticSource(messageReceiver.Path, endpoint);
        }

        public void StartPump()
        {
            TaskExtensionHelper.Schedule(() => MessagePumpTaskAsync());
        }

        bool ShouldRenewLock()
        {
            return
                messageReceiver.ReceiveMode == ReceiveMode.PeekLock &&
                registerHandlerOptions.AutoRenewLock;
        }

        Task RaiseExceptionReceived(Exception e, string action)
        {
            var eventArgs = new ExceptionReceivedEventArgs(e, action, endpoint, messageReceiver.Path, messageReceiver.ClientId);
            return registerHandlerOptions.RaiseExceptionReceived(eventArgs);
        }

        async Task MessagePumpTaskAsync()
        {
            while (!pumpCancellationToken.IsCancellationRequested)
            {
                try
                {
                    await maxConcurrentCallsSemaphoreSlim.WaitAsync(pumpCancellationToken).ConfigureAwait(false);

                    TaskExtensionHelper.Schedule(async () =>
                    {
                        Message message = null;
                        try
                        {
                            message = await messageReceiver.ReceiveAsync(registerHandlerOptions.ReceiveTimeOut).ConfigureAwait(false);
                            if (message != null)
                            {
                                MessagingEventSource.Log.MessageReceiverPumpTaskStart(messageReceiver.ClientId, message, maxConcurrentCallsSemaphoreSlim.CurrentCount);

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
                        catch (OperationCanceledException) when (pumpCancellationToken.IsCancellationRequested) 
                        {
                            // Ignore as we are stopping the pump
                        }
                        catch (ObjectDisposedException) when (pumpCancellationToken.IsCancellationRequested)
                        {
                            // Ignore as we are stopping the pump
                        }
                        catch (Exception exception)
                        {
                            MessagingEventSource.Log.MessageReceivePumpTaskException(messageReceiver.ClientId, string.Empty, exception);
                            await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                        }
                        finally
                        {
                            // Either an exception or for some reason message was null, release semaphore and retry.
                            if (message == null)
                            {
                                maxConcurrentCallsSemaphoreSlim.Release();
                                MessagingEventSource.Log.MessageReceiverPumpTaskStop(messageReceiver.ClientId, maxConcurrentCallsSemaphoreSlim.CurrentCount);
                            }
                        }
                    });
                }
                catch (OperationCanceledException) when (pumpCancellationToken.IsCancellationRequested)
                {
                    // Ignore as we are stopping the pump
                }
                catch (ObjectDisposedException) when (pumpCancellationToken.IsCancellationRequested)
                {
                    // Ignore as we are stopping the pump
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.MessageReceivePumpTaskException(messageReceiver.ClientId, string.Empty, exception);
                    await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                }
            }
        }

        async Task MessageDispatchTaskInstrumented(Message message)
        {
            Activity activity = diagnosticSource.ProcessStart(message);
            Task processTask = null;
            try
            {
                processTask = MessageDispatchTask(message);
                await processTask.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                diagnosticSource.ReportException(e);
                throw;
            }
            finally
            {
                diagnosticSource.ProcessStop(activity, message, processTask?.Status);
            }
        }

        async Task MessageDispatchTask(Message message)
        {
            CancellationTokenSource renewLockCancellationTokenSource = null;
            Timer autoRenewLockCancellationTimer = null;

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStart(messageReceiver.ClientId, message);

            if (ShouldRenewLock())
            {
                renewLockCancellationTokenSource = new CancellationTokenSource();
                TaskExtensionHelper.Schedule(() => RenewMessageLockTask(message, renewLockCancellationTokenSource.Token));

                // After a threshold time of renewal('AutoRenewTimeout'), create timer to cancel anymore renewals.
                autoRenewLockCancellationTimer = new Timer(CancelAutoRenewLock, renewLockCancellationTokenSource, registerHandlerOptions.MaxAutoRenewDuration, TimeSpan.FromMilliseconds(-1));
            }

            try
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStart(messageReceiver.ClientId, message);
                await onMessageCallback(message, pumpCancellationToken).ConfigureAwait(false);

                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStop(messageReceiver.ClientId, message);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackException(messageReceiver.ClientId, message, exception);
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.UserCallback).ConfigureAwait(false);

                // Nothing much to do if UserCallback throws, Abandon message and Release semaphore.
                if (!(exception is MessageLockLostException))
                {
                    await AbandonMessageIfNeededAsync(message).ConfigureAwait(false);
                }

                if (ServiceBusDiagnosticSource.IsEnabled())
                {
                    diagnosticSource.ReportException(exception);
                }
                // AbandonMessageIfNeededAsync should take care of not throwing exception
                maxConcurrentCallsSemaphoreSlim.Release();

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
            maxConcurrentCallsSemaphoreSlim.Release();

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStop(messageReceiver.ClientId, message, maxConcurrentCallsSemaphoreSlim.CurrentCount);
        }

        void CancelAutoRenewLock(object state)
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

        async Task AbandonMessageIfNeededAsync(Message message)
        {
            try
            {
                if (messageReceiver.ReceiveMode == ReceiveMode.PeekLock)
                {
                    await messageReceiver.AbandonAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Abandon).ConfigureAwait(false);
            }
        }

        async Task CompleteMessageIfNeededAsync(Message message)
        {
            try
            {
                if (messageReceiver.ReceiveMode == ReceiveMode.PeekLock &&
                    registerHandlerOptions.AutoComplete)
                {
                    await messageReceiver.CompleteAsync(new[] { message.SystemProperties.LockToken }).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Complete).ConfigureAwait(false);
            }
        }

        async Task RenewMessageLockTask(Message message, CancellationToken renewLockCancellationToken)
        {
            while (!pumpCancellationToken.IsCancellationRequested &&
                   !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    var amount = MessagingUtilities.CalculateRenewAfterDuration(message.SystemProperties.LockedUntilUtc);
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageStart(messageReceiver.ClientId, message, amount);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    var delayTask = await Task.Delay(amount, renewLockCancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }

                    if (!pumpCancellationToken.IsCancellationRequested &&
                        !renewLockCancellationToken.IsCancellationRequested)
                    {
                        await messageReceiver.RenewLockAsync(message).ConfigureAwait(false);
                        MessagingEventSource.Log.MessageReceiverPumpRenewMessageStop(messageReceiver.ClientId, message);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageException(messageReceiver.ClientId, message, exception);

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