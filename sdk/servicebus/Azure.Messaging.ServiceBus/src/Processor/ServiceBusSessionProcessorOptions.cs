// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The set of options that can be specified when creating a
    /// <see cref="ServiceBusSessionProcessor" /> to configure its behavior.
    /// </summary>
    public class ServiceBusSessionProcessorOptions
    {
        /// <inheritdoc cref="ServiceBusProcessorOptions.PrefetchCount"/>
        public int PrefetchCount
        {
            get
            {
                return _prefetchCount;
            }
            set
            {
                Argument.AssertAtLeast(value, 0, nameof(PrefetchCount));
                _prefetchCount = value;
            }
        }
        private int _prefetchCount;

        /// <inheritdoc cref="ServiceBusProcessorOptions.ReceiveMode"/>
        public ServiceBusReceiveMode ReceiveMode { get; set; } = ServiceBusReceiveMode.PeekLock;

        /// <summary>Gets or sets a value that indicates whether the processor
        /// should automatically complete messages after the <see cref="ServiceBusSessionProcessor.ProcessMessageAsync"/>
        /// handler has completed processing. If the message handler triggers an exception,
        /// the message will not be automatically completed. The default value is true.
        /// </summary>
        ///
        /// <value>true to complete the message automatically on successful execution of the event handler;
        /// otherwise, false.</value>
        public bool AutoCompleteMessages { get; set; } = true;

        /// <summary>
        /// Gets or sets the maximum duration within which the session lock will be renewed automatically. This value
        /// should be greater than the queue's LockDuration Property.
        /// </summary>
        ///
        /// <value>The maximum duration during which session locks are automatically renewed.</value>
        /// <remarks>The session lock renewal can continue for sometime in the background
        /// after completion of message and result in a few false SessionLockLost exceptions temporarily.</remarks>
        public TimeSpan MaxAutoLockRenewalDuration
        {
            get => _maxAutoRenewDuration;

            set
            {
                Argument.AssertNotNegative(value, nameof(MaxAutoLockRenewalDuration));
                _maxAutoRenewDuration = value;
            }
        }
        private TimeSpan _maxAutoRenewDuration = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Gets or sets the maximum amount of time to wait for each Receive call using the processor's underlying
        /// receiver.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        ///
        /// <remarks>If no message is returned for a call
        /// to Receive, a new session will be requested by the processor.
        /// Hence, if this value is set to be too low, it could cause new sessions to be requested
        /// more often than necessary.
        /// </remarks>
        internal TimeSpan? MaxReceiveWaitTime
        {
            get => _maxReceiveWaitTime;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertPositive(value.Value, nameof(MaxReceiveWaitTime));
                }

                _maxReceiveWaitTime = value;
            }
        }
        private TimeSpan? _maxReceiveWaitTime;

        /// <summary>
        /// Gets or sets the maximum number of sessions that can be processed concurrently by the processor.
        /// The default value is 8.
        /// </summary>
        ///
        /// <value>The maximum number of concurrent sessions to process.</value>
        public int MaxConcurrentSessions
        {
            get => _maxConcurrentSessions;

            set
            {
                Argument.AssertAtLeast(value, 1, nameof(MaxConcurrentSessions));
                _maxConcurrentSessions = value;
            }
        }
        private int _maxConcurrentSessions = 8;

        /// <summary>
        /// Gets or sets the maximum number of concurrent calls to the message handler the processor should initiate per session.
        /// Thus the total number of concurrent calls will be equal to MaxConcurrentSessions * MaxConcurrentCallsPerSession.
        /// The default value is 1.
        /// </summary>
        ///
        /// <value>The maximum number of concurrent calls to the message handler for each session that is being processed.</value>
        public int MaxConcurrentCallsPerSession
        {
            get => _maxConcurrentCallsPerSessions;

            set
            {
                Argument.AssertAtLeast(value, 1, nameof(MaxConcurrentCallsPerSession));
                _maxConcurrentCallsPerSessions = value;
            }
        }
        private int _maxConcurrentCallsPerSessions = 1;

        /// <summary>
        /// Gets an optional list of session IDs to scope
        /// the <see cref="ServiceBusSessionProcessor"/> to. If the list is
        /// left empty, the processor will not be limited to any specific
        /// session IDs.
        /// </summary>
        public IList<string> SessionIds { get; } = new List<string>();

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        internal ServiceBusProcessorOptions ToProcessorOptions() =>
            new ServiceBusProcessorOptions
            {
                ReceiveMode = ReceiveMode,
                PrefetchCount = PrefetchCount,
                AutoCompleteMessages = AutoCompleteMessages,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                MaxReceiveWaitTime = MaxReceiveWaitTime
            };
    }
}
