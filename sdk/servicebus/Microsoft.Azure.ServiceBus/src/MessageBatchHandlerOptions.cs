// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Primitives;

    /// <summary>Provides options associated with message pump processing using
    /// <see cref="QueueClient.RegisterMessageBatchHandler(Func{IList{Message}, CancellationToken, Task}, MessageHandlerOptions)" /> and
    /// <see cref="SubscriptionClient.RegisterMessageBatchHandler(Func{IList{Message}, CancellationToken, Task}, MessageHandlerOptions)" />.</summary>
    public sealed class MessageBatchHandlerOptions
        : MessageHandlerOptions
    {
        int maxBatchSize;

        /// <summary>Initializes a new instance of the <see cref="MessageBatchHandlerOptions" /> class.
        /// Default Values:
        ///     <see cref="MaxBatchSize"/> = 100
        ///     <see cref="MaxConcurrentCalls"/> = 1
        ///     <see cref="AutoComplete"/> = true
        ///     <see cref="ReceiveTimeOut"/> = 1 minute
        ///     <see cref="MaxAutoRenewDuration"/> = 5 minutes
        /// </summary>
        /// <param name="exceptionReceivedHandler">A <see cref="Func{T1, TResult}"/> that is invoked during exceptions.
        /// <see cref="ExceptionReceivedEventArgs"/> contains contextual information regarding the exception.</param>
        public MessageBatchHandlerOptions(Func<ExceptionReceivedEventArgs, Task> exceptionReceivedHandler)
            : base(exceptionReceivedHandler)
        {
            this.MaxBatchSize = 100;
        }

        internal MessageBatchHandlerOptions(MessageHandlerOptions messageHandlerOptions)
            : base(messageHandlerOptions.ExceptionReceivedHandler)
        {
            this.MaxBatchSize = 1;
            this.MaxConcurrentCalls = messageHandlerOptions.MaxConcurrentCalls;
            this.AutoComplete = messageHandlerOptions.AutoComplete;
            // BLOCKER: Determine if we should make this work or just remove.
            //this.ReceiveTimeOut = messageHandlerOptions.ReceiveTimeOut;
            this.MaxAutoRenewDuration = messageHandlerOptions.MaxAutoRenewDuration;
        }

        /// <summary>Gets or sets the maximum number of concurrent calls to the callback the message pump should initiate.</summary>
        /// <value>The maximum number of concurrent calls to the callback.</value>
        public int MaxBatchSize
        {
            get => this.maxBatchSize;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(Resources.MaxBatchSizeMustBeGreaterThanZero.FormatForUser(value));
                }

                this.maxBatchSize = value;
            }
        }
    }
}