// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Primitives;

    /// <summary>Provides options associated with session pump processing using
    /// <see cref="QueueClient.RegisterSessionHandler(Func{IMessageSession, Message, CancellationToken, Task}, SessionHandlerOptions)" /> and
    /// <see cref="SubscriptionClient.RegisterSessionHandler(Func{IMessageSession, Message, CancellationToken, Task}, SessionHandlerOptions)" />.</summary>
    public sealed class SessionHandlerOptions
    {
        int maxConcurrentSessions;
        TimeSpan messageWaitTimeout;
        TimeSpan maxAutoRenewDuration;

        /// <summary>Initializes a new instance of the <see cref="SessionHandlerOptions" /> class.
        /// Default Values:
        ///     <see cref="MaxConcurrentSessions"/> = 2000
        ///     <see cref="AutoComplete"/> = true
        ///     <see cref="MessageWaitTimeout"/> = 1 minute
        ///     <see cref="MaxAutoRenewDuration"/> = 5 minutes
        /// </summary>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        public SessionHandlerOptions(Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
        {
            // These are default values
            this.AutoComplete = true;
            this.MaxConcurrentSessions = 2000;
            this.MessageWaitTimeout = TimeSpan.FromMinutes(1);
            this.MaxAutoRenewDuration = Constants.ClientPumpRenewLockTimeout;
            this.ExceptionReceivedHandler = exceptionReceivedHandler ?? throw new ArgumentNullException(nameof(exceptionReceivedHandler));
        }

        /// <summary>Occurs when an exception is received. Enables you to be notified of any errors encountered by the session pump.
        /// When errors are received calls will automatically be retried, so this is informational. </summary>
        public Func<ExceptionReceivedEventArgs, Task> ExceptionReceivedHandler { get; }

        /// <summary>Gets or sets the duration for which the session lock will be renewed automatically. If a session lock is going to expire,
        /// this value is the max duration for the session lock to be automatically renewed. </summary>
        /// <remarks>If this auto renewal fails, clients will receive an exception in the ExceptionReceivedHandler. </remarks>
        /// <value>The duration for which the session renew its state. Default is 5 min.</value>
        public TimeSpan MaxAutoRenewDuration
        {
            get => this.maxAutoRenewDuration;

            set
            {
                TimeoutHelper.ThrowIfNegativeArgument(value, nameof(value));
                this.maxAutoRenewDuration = value;
            }
        }

        /// <summary>Gets or sets the timeout to wait for receiving a message. This is the time the session-pump waits before closing down the current 
        /// session and switching to a different session. </summary>
        /// <remarks>This value has an impact on the message throughput. If the value is very large, then every time the SDK waits for this duration 
        /// before closing to make sure that all the messages have been received. If users are having a lot of sessions and fewer messages per session, 
        /// try setting this to be a relative smaller value based on how frequent new messages arrive in the session. </remarks>
        /// <value>The time to wait for receiving the message. Default is 1 min.</value>
        public TimeSpan MessageWaitTimeout
        {
            get => this.messageWaitTimeout;

            set
            {
                TimeoutHelper.ThrowIfNegativeArgument(value, nameof(value));
                this.messageWaitTimeout = value;
            }
        }

        /// <summary>Gets or sets the maximum number of existing sessions that the User wants to handle concurrently. Setting this value to be 
        /// greater than the max number of active sessions in the service will not increase message throughput. </summary>
        /// <remarks>The session-pump (SDK) will accept MaxConcurrentSessions number of sessions in parallel and dispatch the messages. The messages 
        /// within a session are delivered sequentially. If more than <see cref="MaxConcurrentSessions"/> number of sessions are present in the 
        /// entity, they will be accepted one-by-one after closing the existing sessions.</remarks>
        /// <value>The maximum number of sessions that the User wants to handle concurrently. Default is 2000.</value>
        public int MaxConcurrentSessions
        {
            get => this.maxConcurrentSessions;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(Resources.MaxConcurrentCallsMustBeGreaterThanZero.FormatForUser(value));
                }

                this.maxConcurrentSessions = value;
                this.MaxConcurrentAcceptSessionCalls = Math.Min(value, 2 * Environment.ProcessorCount);
            }
        }

        /// <summary>Gets or sets whether the autocomplete option for messages in the session handler is enabled. 
        /// If this value is true, if the handler returns without any failure, then the message is completed and will not show up in the session; if any 
        /// exception is thrown from the handler, the message is abandoned and the DeliveryCount of this message will increase by one. 
        /// If this value is false, if the handler returns without any failure, then user has to write the logic to explicitly complete the message, 
        /// otherwise the message is not considered 'completed' and will reappear in the session.  </summary>
        /// <value>true if the autocomplete option of the session handler is enabled; otherwise, false. Default is ture. </value>
        public bool AutoComplete { get; set; }

        internal bool AutoRenewLock => this.MaxAutoRenewDuration > TimeSpan.Zero;

        internal int MaxConcurrentAcceptSessionCalls { get; set; }

        internal async Task RaiseExceptionReceived(ExceptionReceivedEventArgs eventArgs)
        {
            try
            {
                await this.ExceptionReceivedHandler(eventArgs).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.ExceptionReceivedHandlerThrewException(exception);
            }
        }
    }
}