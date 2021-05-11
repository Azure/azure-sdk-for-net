// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Configuration options for functions that bind to a single <see cref="ServiceBusReceivedMessage"/>.
    /// </summary>
    public class SingleMessageOptions
    {
        /// <summary>
        /// Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property.
        /// The default value is 5 minutes.
        /// </summary>
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

        /// <summary>Gets or sets the maximum number of concurrent calls to a function. Note each call
        /// would be passing a different message. The default is 16 times the return value of
        /// <see cref="Utility.GetProcessorCount"/>.
        /// </summary>
        public int MaxConcurrentCalls
        {
            get => _maxConcurrentCalls;

            set
            {
                Argument.AssertAtLeast(value, 1, nameof(MaxConcurrentCalls));
                _maxConcurrentCalls = value;
            }
        }
        private int _maxConcurrentCalls = Utility.GetProcessorCount() * 16;

        /// <summary>
        /// Gets or sets the maximum number of sessions that can be processed concurrently by a function.
        /// The default value is 8.
        /// </summary>
        public int MaxConcurrentSessions
        {
            get => _maxConcurrentSessions;

            set
            {
                Argument.AssertAtLeast(value, 1, nameof(MaxConcurrentSessions));
                _maxConcurrentSessions = value;
            }
        }
        // TODO the default value in Track 1 was the default value from the Track 1 SDK, which was 2000.
        // Verify that we are okay to diverge here.
        private int _maxConcurrentSessions = 8;

        /// <summary>
        /// Gets or sets an optional exception handler that will be invoked if an exception occurs while attempting to process
        /// a message.
        /// </summary>
        public Func<ProcessErrorEventArgs, Task> ExceptionHandler { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of time to wait for a message to be received for the
        /// currently active session. After this time has elapsed, the processor will close the session
        /// and attempt to process another session.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        public TimeSpan? SessionIdleTimeout { get; set; }
    }
}