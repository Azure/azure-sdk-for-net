// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Primitives;

    sealed class MessageReceivePump
    {
        readonly Func<IList<Message>, CancellationToken, Task> onMessageCallback;
        readonly string endpoint;
        readonly MessageBatchHandlerOptions registerHandlerOptions;
        readonly IMessageReceiver messageReceiver;
        readonly CancellationToken pumpCancellationToken;
        readonly SemaphoreSlim maxConcurrentCallsSemaphoreSlim;
        readonly ServiceBusDiagnosticSource diagnosticSource;

        public MessageReceivePump(IMessageReceiver messageReceiver,
            MessageBatchHandlerOptions registerHandlerOptions,
            Func<IList<Message>, CancellationToken, Task> callback,
            Uri endpoint,
            CancellationToken pumpCancellationToken)
        {
            this.messageReceiver = messageReceiver ?? throw new ArgumentNullException(nameof(messageReceiver));
            this.registerHandlerOptions = registerHandlerOptions;
            this.onMessageCallback = callback;
            this.endpoint = endpoint.Authority;
            this.pumpCancellationToken = pumpCancellationToken;
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

        Task RaiseExceptionReceived(Exception e, IEnumerable<Message> messages, string action)
        {
            var messageArray = messages?.ToArray();
            var eventArgs = new ExceptionReceivedEventArgs(e, messageArray, action, this.endpoint, this.messageReceiver.Path, this.messageReceiver.ClientId);
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
                        IList<Message> messages = null;

                        try
                        {
                            messages = await this.messageReceiver.ReceiveAsync(this.registerHandlerOptions.MaxBatchSize, this.registerHandlerOptions.ReceiveTimeOut).ConfigureAwait(false);
                            if (messages != null)
                            {
                                MessagingEventSource.Log.MessageReceiverPumpTaskStart(this.messageReceiver.ClientId, messages, this.maxConcurrentCallsSemaphoreSlim.CurrentCount);

                                TaskExtensionHelper.Schedule(() =>
                                {
                                    if (ServiceBusDiagnosticSource.IsEnabled())
                                    {
                                        return this.MessageDispatchTaskInstrumented(messages, this.registerHandlerOptions.MaxBatchSize);
                                    }
                                    else
                                    {
                                        return this.MessageDispatchTask(messages);
                                    }
                                });
                            }
                        }
                        catch (Exception exception)
                        {
                            // Not reporting an ObjectDisposedException as we're stopping the pump
                            if (!(exception is ObjectDisposedException && this.pumpCancellationToken.IsCancellationRequested))
                            {
                                MessagingEventSource.Log.MessageReceivePumpTaskException(this.messageReceiver.ClientId, string.Empty, exception);
                                await this.RaiseExceptionReceived(exception, messages, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                            }
                        }
                        finally
                        {
                            // Either an exception or for some reason message was null, release semaphore and retry.
                            if (messages == null)
                            {
                                this.maxConcurrentCallsSemaphoreSlim.Release();
                                MessagingEventSource.Log.MessageReceiverPumpTaskStop(this.messageReceiver.ClientId, this.maxConcurrentCallsSemaphoreSlim.CurrentCount);
                            }
                        }
                    });
                }
                catch (Exception exception)
                {
                    // Not reporting an ObjectDisposedException as we're stopping the pump
                    if (!(exception is ObjectDisposedException && this.pumpCancellationToken.IsCancellationRequested))
                    {
                        MessagingEventSource.Log.MessageReceivePumpTaskException(this.messageReceiver.ClientId, string.Empty, exception);
                        await this.RaiseExceptionReceived(exception, null, ExceptionReceivedEventArgsAction.Receive).ConfigureAwait(false);
                    }
                }
            }
        }

        async Task MessageDispatchTaskInstrumented(IList<Message> messages, int batchSize)
        {
            Activity activity;

            if (batchSize == 1)
            {
                activity = this.diagnosticSource.ProcessStart(messages.First());
            }
            else
            {
                activity = this.diagnosticSource.ProcessBatchStart(messages);
            }


            Task processTask = null;
            try
            {
                processTask = MessageDispatchTask(messages);
                await processTask.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                this.diagnosticSource.ReportException(e);
                throw;
            }
            finally
            {
                if (batchSize == 1)
                {
                    this.diagnosticSource.ProcessStop(activity, messages.First(), processTask?.Status);
                }
                else
                {
                    this.diagnosticSource.ProcessBatchStop(activity, messages, processTask?.Status);
                }
            }
        }

        async Task MessageDispatchTask(IList<Message> messages)
        {
            CancellationTokenSource renewLockCancellationTokenSource = null;
            Timer autoRenewLockCancellationTimer = null;

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStart(this.messageReceiver.ClientId, messages);

            if (this.ShouldRenewLock())
            {
                renewLockCancellationTokenSource = new CancellationTokenSource();
                TaskExtensionHelper.Schedule(() => this.RenewMessagesLockTask(messages, renewLockCancellationTokenSource.Token));

                // After a threshold time of renewal('AutoRenewTimeout'), create timer to cancel anymore renewals.
                autoRenewLockCancellationTimer = new Timer(this.CancelAutoRenewLock, renewLockCancellationTokenSource, this.registerHandlerOptions.MaxAutoRenewDuration, TimeSpan.FromMilliseconds(-1));
            }

            try
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStart(this.messageReceiver.ClientId, messages);
                await this.onMessageCallback(messages, this.pumpCancellationToken).ConfigureAwait(false);

                MessagingEventSource.Log.MessageReceiverPumpUserCallbackStop(this.messageReceiver.ClientId, messages);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.MessageReceiverPumpUserCallbackException(this.messageReceiver.ClientId, messages, exception);
                await this.RaiseExceptionReceived(exception, messages, ExceptionReceivedEventArgsAction.UserCallback).ConfigureAwait(false);

                // Nothing much to do if UserCallback throws, Abandon message and Release semaphore.
                if (!(exception is MessageLockLostException))
                {
                    await this.AbandonMessagesIfNeededAsync(messages).ConfigureAwait(false);
                }

                if (ServiceBusDiagnosticSource.IsEnabled())
                {
                    this.diagnosticSource.ReportException(exception);
                }
                // AbandonMessagesIfNeededAsync should take care of not throwing exception
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
            await this.CompleteMessagesIfNeededAsync(messages).ConfigureAwait(false);
            this.maxConcurrentCallsSemaphoreSlim.Release();

            MessagingEventSource.Log.MessageReceiverPumpDispatchTaskStop(this.messageReceiver.ClientId, messages, this.maxConcurrentCallsSemaphoreSlim.CurrentCount);
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

        async Task AbandonMessagesIfNeededAsync(IList<Message> messages)
        {
            if (this.messageReceiver.ReceiveMode == ReceiveMode.PeekLock)
            {
                bool batchAbandonSucceeded;
                if (messages.Count > 1)
                {

                    try
                    {
                        var lockTokens = messages.Select(m => m.SystemProperties.LockToken);

                        await this.messageReceiver.AbandonAsync(lockTokens).ConfigureAwait(false);

                        batchAbandonSucceeded = true;
                    }
                    catch
                    {
                        batchAbandonSucceeded = false;
                    }
                }
                else
                {
                    batchAbandonSucceeded = false;
                }

                if (!batchAbandonSucceeded)
                {
                    foreach (var message in messages)
                    {
                        try
                        {
                            await this.messageReceiver.AbandonAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
                        }
                        catch (Exception exception)
                        {
                            await this.RaiseExceptionReceived(exception, new[] { message }, ExceptionReceivedEventArgsAction.Abandon).ConfigureAwait(false);
                        }
                    }
                }
            }
        }

        async Task CompleteMessagesIfNeededAsync(IList<Message> messages)
        {
            if (this.messageReceiver.ReceiveMode == ReceiveMode.PeekLock &&
                this.registerHandlerOptions.AutoComplete)
            {
                bool batchCompletionSucceeded;

                if (messages.Count > 1)
                {
                    try
                    {
                        var messageLocks = messages.Select(m => m.SystemProperties.LockToken);

                        await this.messageReceiver.CompleteAsync(messageLocks).ConfigureAwait(false);

                        batchCompletionSucceeded = true;
                    }
                    catch
                    {
                        batchCompletionSucceeded = false;
                    }
                }
                else
                {
                    batchCompletionSucceeded = false;
                }

                if (!batchCompletionSucceeded)
                {
                    foreach (var message in messages)
                    {
                        try
                        {
                            await this.messageReceiver.CompleteAsync(message.SystemProperties.LockToken).ConfigureAwait(false);
                        }
                        catch (Exception exception)
                        {
                            await this.RaiseExceptionReceived(exception, new[] { message }, ExceptionReceivedEventArgsAction.Complete).ConfigureAwait(false);
                        }
                    }
                }
            }
        }

        async Task RenewMessagesLockTask(IEnumerable<Message> messages, CancellationToken renewLockCancellationToken)
        {
            var renewableMessages = new HashSet<Message>(messages);

            while (!this.pumpCancellationToken.IsCancellationRequested &&
                   !renewLockCancellationToken.IsCancellationRequested &&
                   renewableMessages.Count > 0)
            {
                try
                {
                    var lowestLockedUntilUtc = renewableMessages.Min(m => m.SystemProperties.LockedUntilUtc);
                    var renewAfterTimeSpan = MessagingUtilities.CalculateRenewAfterDuration(lowestLockedUntilUtc);
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageStart(this.messageReceiver.ClientId, renewableMessages, renewAfterTimeSpan);

                    // We're awaiting the task created by 'ContinueWith' to avoid awaiting the Delay task which may be canceled
                    // by the renewLockCancellationToken. This way we prevent a TaskCanceledException.
                    var delayTask = await Task.Delay(renewAfterTimeSpan, renewLockCancellationToken)
                        .ContinueWith(t => t, TaskContinuationOptions.ExecuteSynchronously)
                        .ConfigureAwait(false);
                    if (delayTask.IsCanceled)
                    {
                        break;
                    }


                    bool batchRenewalSucceeded;

                    if (renewableMessages.Count > 1)
                    {
                        try
                        {
                            await this.messageReceiver.RenewLockAsync(renewableMessages).ConfigureAwait(false);

                            batchRenewalSucceeded = true;
                        }
                        catch
                        {
                            batchRenewalSucceeded = false;
                        }
                    }
                    else
                    {
                        batchRenewalSucceeded = false;
                    }

                    if (!batchRenewalSucceeded)
                    {
                        IList<Message> noLongerRenewableMessages = null;

                        foreach (var renewableMessage in renewableMessages)
                        {
                            try
                            {
                                if (!this.pumpCancellationToken.IsCancellationRequested &&
                                    !renewLockCancellationToken.IsCancellationRequested)
                                {
                                    await this.messageReceiver.RenewLockAsync(renewableMessage).ConfigureAwait(false);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (Exception exception)
                            {
                                MessagingEventSource.Log.MessageReceiverPumpRenewMessageException(this.messageReceiver.ClientId, new[] { renewableMessage }, exception);
                                await this.RaiseExceptionReceived(exception, new[] { renewableMessage }, ExceptionReceivedEventArgsAction.RenewLock).ConfigureAwait(false);

                                if (!MessagingUtilities.ShouldRetry(exception))
                                {
                                    if (noLongerRenewableMessages == null)
                                    {
                                        noLongerRenewableMessages = new List<Message>(renewableMessages.Count);
                                    }

                                    noLongerRenewableMessages.Add(renewableMessage);
                                }
                            }
                        }

                        if (noLongerRenewableMessages != null)
                        {
                            foreach (var noLongerRenewableMessage in noLongerRenewableMessages)
                            {
                                renewableMessages.Remove(noLongerRenewableMessage);
                            }
                        }
                    }

                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageStop(this.messageReceiver.ClientId, renewableMessages);

                }
                catch (Exception exception)
                {
                    MessagingEventSource.Log.MessageReceiverPumpRenewMessageException(this.messageReceiver.ClientId, renewableMessages, exception);

                    // ObjectDisposedException should only happen here because the CancellationToken was disposed at which point
                    // this renew exception is not relevant anymore. Lets not bother user with this exception.
                    if (!(exception is ObjectDisposedException))
                    {
                        await this.RaiseExceptionReceived(exception, renewableMessages, ExceptionReceivedEventArgsAction.RenewLock).ConfigureAwait(false);
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