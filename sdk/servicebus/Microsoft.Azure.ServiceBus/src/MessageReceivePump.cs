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
        public readonly SemaphoreSlim maxConcurrentCallsSemaphoreSlim;
        public readonly MessageHandlerOptions registerHandlerOptions;
        readonly Func<Message, CancellationToken, Task> onMessageCallback;
        readonly string endpoint;
        readonly IMessageReceiver messageReceiver;
        readonly CancellationToken pumpCancellationToken;
        readonly CancellationToken runningTaskCancellationToken;
        readonly ServiceBusDiagnosticSource diagnosticSource;

        public MessageReceivePump(IMessageReceiver messageReceiver,
            MessageHandlerOptions registerHandlerOptions,
            Func<Message, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken pumpCancellationToken,
            CancellationToken runningTaskCancellationToken)
        {
            this.messageReceiver = messageReceiver ?? throw new ArgumentNullException(nameof(messageReceiver));
            this.registerHandlerOptions = registerHandlerOptions;
            this.onMessageCallback = callback;
            this.endpoint = endpoint.Authority;
            this.pumpCancellationToken = pumpCancellationToken;
            this.runningTaskCancellationToken = runningTaskCancellationToken;
            this.maxConcurrentCallsSemaphoreSlim = new SemaphoreSlim(this.registerHandlerOptions.MaxConcurrentCalls);
            this.diagnosticSource = new ServiceBusDiagnosticSource(messageReceiver.Path, endpoint);
        }

        public void StartPump()
        {
            TaskExtensionHelper.Schedule(() => this.MessagePumpTaskAsync());
        }

        bool ShouldRenewLock()
        {
            return
                this.messageReceiver.ReceiveMode == ReceiveMode.PeekLock &&
                this.registerHandlerOptions.AutoRenewLock;
        }

        Task RaiseExceptionReceived(Exception e, string action)
        {
            var eventArgs = new ExceptionReceivedEventArgs(e, action, this.endpoint, this.messageReceiver.Path, this.messageReceiver.ClientId);
            return this.registerHandlerOptions.RaiseExceptionReceived(eventArgs);
        }

        async Task MessagePumpTaskAsync()
        {
            while (!this.pumpCancellationToken.IsCancellationRequested)
            {
                try
                {
                    await this.maxConcurrentCallsSemaphoreSlim.WaitAsync(this.pumpCancellationToken).ConfigureAwait(false);

                    TaskExtensionHelper.Schedule(async () =>
                    {
                        Message message = null;
                        try
                        {
                            message = await this.messageReceiver.ReceiveAsync(this.registerHandlerOptions.ReceiveTimeOut).ConfigureAwait(false);
                            if (message != null)
                            {
                                MessagingEventSource.Log.MessageReceiverPumpTaskStart(this.messageReceiver.ClientId, message, this.maxConcurrentCallsSemaphoreSlim.CurrentCount);

                                TaskExtensionHelper.Schedule(() =>
                                {
                                    if (ServiceBusDiagnosticSource.IsEnabled())
                                    {
                                        return this.MessageDispatchTaskInstrumented(message);
                                    }
                                    else
                                    {
                                        return this.MessageDispatchTask(message);
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
                            MessagingEventSource.Log.MessageReceivePumpTaskException(this.messageReceiver.ClientId, string.Empty, exception);
                            await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                        }
                        finally
                        {
                            // Either an exception or for some reason message was null, release semaphore and retry.
                            if (message == null)
                            {
                                this.maxConcurrentCallsSemaphoreSlim.Release();
                                MessagingEventSource.Log.MessageReceiverPumpTaskStop(this.messageReceiver.ClientId, this.maxConcurrentCallsSemaphoreSlim.CurrentCount);
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
                    MessagingEventSource.Log.MessageReceivePumpTaskException(this.messageReceiver.ClientId, string.Empty, exception);
                    await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                }
            }
        }

        async Task MessageDispatchTaskInstrumented(Message message)
        {
            Activity activity = this.diagnosticSource.ProcessStart(message);
            Task processTask = null;
            try
            {
                processTask = MessageDispatchTask(message);
                await processTask.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.diagnosticSource.ReportException(e);
                throw;
            }
            finally
            {
                this.diagnosticSource.ProcessStop(activity, message, processTask?.Status);
            }
        }

        async Task MessageDispatchTask(Message message)
        {
            CancellationTokenSource renewLockCancellationTokenSource = null;
            Timer autoRenewLockCancellationTimer = null;

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStart(this.messageReceiver.ClientId, message);

            if (this.ShouldRenewLock())
            {
                renewLockCancellationTokenSource = new CancellationTokenSource();
                TaskExtensionHelper.Schedule(() => this.RenewMessageLockTask(message, renewLockCancellationTokenSource.Token));

                // After a threshold time of renewal('AutoRenewTimeout'), create timer to cancel anymore renewals.
                autoRenewLockCancellationTimer = new Timer(this.CancelAutoRenewLock, renewLockCancellationTokenSource, this.registerHandlerOptions.MaxAutoRenewDuration, TimeSpan.FromMilliseconds(-1));
            }

            try
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStart(this.messageReceiver.ClientId, message);
                await this.onMessageCallback(message, this.runningTaskCancellationToken).ConfigureAwait(false);

                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStop(this.messageReceiver.ClientId, message);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackException(this.messageReceiver.ClientId, message, exception);
                await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.UserCallback).ConfigureAwait(false);

                // Nothing much to do if UserCallback throws, Abandon message and Release semaphore.
                if (!(exception is MessageLockLostException))
                {
                    await this.AbandonMessageIfNeededAsync(message).ConfigureAwait(false);
                }

                if (ServiceBusDiagnosticSource.IsEnabled())
                {
                    this.diagnosticSource.ReportException(exception);
                }
                // AbandonMessageIfNeededAsync should take care of not throwing exception
                this.maxConcurrentCallsSemaphoreSlim.Release();

                return;
            }
            finally
            {
                renewLockCancellationTokenSource?.Cancel();
                renewLockCancellationTokenSource?.Dispose();
                autoRenewLockCancellationTimer?.Dispose();
            }

            // If we've made it this far, user callback completed fine. Complete message and Release semaphore.
            await this.CompleteMessageIfNeededAsync(message).ConfigureAwait(false);
            this.maxConcurrentCallsSemaphoreSlim.Release();

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStop(this.messageReceiver.ClientId, message, this.maxConcurrentCallsSemaphoreSlim.CurrentCount);
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
                if (this.messageReceiver.ReceiveMode == ReceiveMode.PeekLock)
                {
                    await this.messageReceiver.AbandonAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Abandon).ConfigureAwait(false);
            }
        }

        async Task CompleteMessageIfNeededAsync(Message message)
        {
            try
            {
                if (this.messageReceiver.ReceiveMode == ReceiveMode.PeekLock &&
                    this.registerHandlerOptions.AutoComplete)
                {
                    await this.messageReceiver.CompleteAsync(new[] { message.SystemProperties.LockToken }).ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.Complete).ConfigureAwait(false);
            }
        }

        async Task RenewMessageLockTask(Message message, CancellationToken renewLockCancellationToken)
        {
            while (!this.pumpCancellationToken.IsCancellationRequested &&
                   !renewLockCancellationToken.IsCancellationRequested)
            {
                try
                {
                    var amount = MessagingUtilities.CalculateRenewAfterDuration(message.SystemProperties.LockedUntilUtc);
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageStart(this.messageReceiver.ClientId, message, amount);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    var delayTask = await Task.Delay(amount, renewLockCancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }

                    if (!this.pumpCancellationToken.IsCancellationRequested &&
                        !renewLockCancellationToken.IsCancellationRequested)
                    {
                        await this.messageReceiver.RenewLockAsync(message).ConfigureAwait(false);
                        MessagingEventSource.Log.MessageReceiverPumpRenewMessageStop(this.messageReceiver.ClientId, message);
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageException(this.messageReceiver.ClientId, message, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await this.RaiseExceptionReceived(exception, ExceptionReceivedEventArgsAction.RenewLock).ConfigureAwait(false);
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