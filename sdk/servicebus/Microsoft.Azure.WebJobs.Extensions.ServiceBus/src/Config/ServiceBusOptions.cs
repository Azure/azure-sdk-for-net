// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.ServiceBus
{
    /// <summary>
    /// Configuration options for the ServiceBus extension.
    /// </summary>
    public class ServiceBusOptions : IOptionsFormatter
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ServiceBusOptions()
        {
        }

        /// <summary>
        /// Gets or sets the Azure ServiceBus connection string.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the PrefetchCount that will be used when receiving messages. The default value is 0.
        /// </summary>
        public int PrefetchCount { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ServiceBusClientOptions"/> that will be used for sending and receiving messages.
        /// </summary>
        public ServiceBusClientOptions ClientOptions { get; set; } = new ServiceBusClientOptions();

        /// <summary>
        ///  Gets or sets whether to automatically complete messages after successful execution of the function.
        ///  The default value is true.
        /// </summary>
        public bool AutoCompleteMessages { get; set; } = true;

        /// <summary>
        /// Gets or sets the maximum duration within which the lock will be renewed automatically. This
        /// value should be greater than the longest message lock duration; for example, the LockDuration Property.
        /// The default value is 5 minutes. This does not apply for functions that receive a batch of messages.
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
        /// would be passing a different message. This does not apply for functions that receive a batch of messages.
        /// The default is 16 times the return value of <see cref="Utility.GetProcessorCount"/>.
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
        /// The default value is 8. This does not apply for functions that receive a batch of messages.
        /// </summary>
        /// TODO the default value in Track 1 was the default value from the Track 1 SDK, which was 2000.
        /// Verify that we are okay to diverge here.
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
        /// Gets or sets an optional exception handler that will be invoked if an exception occurs while attempting to process
        /// a message. This does not apply for functions that receive a batch of messages.
        /// </summary>
        public Func<ProcessErrorEventArgs, Task> ExceptionHandler { get; set; }

        /// <summary>
        /// Gets or sets an optional <see cref="TimeSpan"/> specifying the maximum time to wait when attempting to receive messages.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used. This only applies for functions that receive
        /// a batch of messages.
        /// </summary>
        /// TODO this should probably be exposed in the Processor as well and would then also apply for functions that receive a single message.
        public TimeSpan? MaxWaitTime { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of messages that will be passed to each function call. This only applies for functions that receive
        /// a batch of messages. The default value is 1000.
        /// </summary>
        public int MaxMessages { get; set; } = 1000;

        public string Format()
        {
            // Do not include ConnectionString in loggable options.
            var retryOptions = new JObject
            {
                { nameof(ServiceBusClientOptions.RetryOptions.Mode), ClientOptions.RetryOptions.Mode.ToString() },
                { nameof(ServiceBusClientOptions.RetryOptions.TryTimeout), ClientOptions.RetryOptions.TryTimeout },
                { nameof(ServiceBusClientOptions.RetryOptions.Delay), ClientOptions.RetryOptions.Delay },
                { nameof(ServiceBusClientOptions.RetryOptions.MaxDelay), ClientOptions.RetryOptions.MaxDelay },
                { nameof(ServiceBusClientOptions.RetryOptions.MaxRetries), ClientOptions.RetryOptions.MaxRetries },
            };

            var clientOptions = new JObject
            {
                { nameof(ServiceBusClientOptions.TransportType),  ClientOptions.TransportType.ToString()},
                { nameof(ServiceBusClientOptions.WebProxy),  ClientOptions.WebProxy?.ToString() ?? string.Empty },
                { nameof(ServiceBusClientOptions.RetryOptions),  retryOptions },
            };

            JObject options = new JObject
            {
                { nameof(ClientOptions), clientOptions },
                { nameof(AutoCompleteMessages), AutoCompleteMessages },
                { nameof(PrefetchCount), PrefetchCount },
                { nameof(MaxAutoLockRenewalDuration), MaxAutoLockRenewalDuration },
                { nameof(MaxConcurrentCalls), MaxConcurrentCalls },
                { nameof(MaxConcurrentSessions), MaxConcurrentSessions },
                { nameof(MaxMessages), MaxMessages },
                { nameof(MaxWaitTime), MaxWaitTime.ToString() ?? string.Empty }
            };

            return options.ToString(Formatting.Indented);
        }

        internal Task ExceptionReceivedHandler(ProcessErrorEventArgs args)
        {
            ExceptionHandler?.Invoke(args);

            return Task.CompletedTask;
        }

        internal ServiceBusProcessorOptions ToProcessorOptions() =>
            new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = AutoCompleteMessages,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                MaxConcurrentCalls = MaxConcurrentCalls
            };

        internal ServiceBusSessionProcessorOptions ToSessionProcessorOptions() =>
            new ServiceBusSessionProcessorOptions
            {
                AutoCompleteMessages = AutoCompleteMessages,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                MaxConcurrentSessions = MaxConcurrentSessions
            };
    }
}
