// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using Primitives;

    /// <summary>Provides options associated with message pump processing using
    /// <see cref="QueueClient.OnMessageAsync(System.Action{BrokeredMessage, CancellationToken})" /> and
    /// <see cref="SubscriptionClient.OnMessageAsync(System.Action{BrokeredMessage, CancellationToken})" />.</summary>
    public sealed class OnMessageOptions
    {
        int maxConcurrentCalls;
        TimeSpan autoRenewTimeout;

        /// <summary>Initializes a new instance of the <see cref="OnMessageOptions" /> class.
        /// Default Values:
        ///     <see cref="MaxConcurrentCalls"/> = 1
        ///     <see cref="AutoComplete"/> = true
        ///     <see cref="ReceiveTimeOut"/> = 1 minute
        ///     <see cref="AutoRenewTimeout"/> = 5 minutes
        /// </summary>
        public OnMessageOptions()
        {
            this.MaxConcurrentCalls = 1;
            this.AutoComplete = true;
            this.ReceiveTimeOut = Constants.DefaultOperationTimeout;
            this.AutoRenewTimeout = Constants.ClientPumpRenewLockTimeout;
        }

        /// <summary>Occurs when an exception is received. Enables you to be notified of any errors encountered by the message pump.
        /// When errors are received calls will automatically be retried, so this is informational. </summary>
        public event EventHandler<ExceptionReceivedEventArgs> ExceptionReceived;

        /// <summary>Gets or sets the maximum number of concurrent calls to the callback the message pump should initiate.</summary>
        /// <value>The maximum number of concurrent calls to the callback.</value>
        public int MaxConcurrentCalls
        {
            get
            {
                return this.maxConcurrentCalls;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(Resources.MaxConcurrentCallsMustBeGreaterThanZero.FormatForUser(value));
                }

                this.maxConcurrentCalls = value;
            }
        }

        /// <summary>Gets or sets a value that indicates whether the message-pump should call
        /// <see cref="QueueClient.Complete(System.Guid)" /> or
        /// <see cref="SubscriptionClient.Complete(System.Guid)" /> on messages after the callback has completed processing.</summary>
        /// <value>true to complete the message processing automatically on successful execution of the operation; otherwise, false.</value>
        public bool AutoComplete { get; set; }

        /// <summary>Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property. </summary>
        /// <value>The maximum duration during which locks are automatically renewed.</value>
        public TimeSpan AutoRenewTimeout
        {
            get
            {
                return this.autoRenewTimeout;
            }

            set
            {
                TimeoutHelper.ThrowIfNegativeArgument(value, "value");
                this.autoRenewTimeout = value;
            }
        }

        internal bool AutoRenewLock
        {
            get { return this.AutoRenewTimeout > TimeSpan.Zero; }
        }

        internal ClientEntity MessageClientEntity { get; set; }

        internal TimeSpan ReceiveTimeOut { get; set; }

        internal void RaiseExceptionReceived(ExceptionReceivedEventArgs e)
        {
            this.ExceptionReceived?.Invoke(this.MessageClientEntity, e);
        }
    }
}