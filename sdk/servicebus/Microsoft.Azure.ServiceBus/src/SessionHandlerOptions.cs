﻿// Copyright (c) Microsoft. All rights reserved.
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

        /// <summary>Gets or sets the duration for which the session lock will be renewed automatically.</summary>
        /// <value>The duration for which the session renew its state.</value>
        public TimeSpan MaxAutoRenewDuration
        {
            get => this.maxAutoRenewDuration;

            set
            {
                TimeoutHelper.ThrowIfNegativeArgument(value, nameof(value));
                this.maxAutoRenewDuration = value;
            }
        }

        /// <summary>Gets or sets the time to wait for receiving a message.</summary>
        /// <value>The time to wait for receiving the message.</value>
        public TimeSpan MessageWaitTimeout
        {
            get => this.messageWaitTimeout;

            set
            {
                TimeoutHelper.ThrowIfNegativeArgument(value, nameof(value));
                this.messageWaitTimeout = value;
            }
        }

        /// <summary>Gets or sets the maximum number of existing sessions that the User wants to handle concurrently.</summary>
        /// <value>The maximum number of sessions that the User wants to handle concurrently.</value>
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

        /// <summary>Gets or sets whether the autocomplete option of the session handler is enabled.</summary>
        /// <value>true if the autocomplete option of the session handler is enabled; otherwise, false.</value>
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