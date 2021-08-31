﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
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
        /// Gets or sets the PrefetchCount that will be used when receiving messages. The default value is 0.
        /// </summary>
        public int PrefetchCount { get; set; }

        /// <summary>
        /// The set of options to use for determining whether a failed operation should be retried and,
        /// if so, the amount of time to wait between retry attempts.  These options also control the
        /// amount of time allowed for receiving messages and other interactions with the Service Bus service.
        /// </summary>
        public ServiceBusRetryOptions ClientRetryOptions
        {
            get => _clientRetryOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(ClientRetryOptions));
                _clientRetryOptions = value;
            }
        }
        private ServiceBusRetryOptions _clientRetryOptions = new ServiceBusRetryOptions();

        /// <summary>
        ///   The type of protocol and transport that will be used for communicating with the Service Bus
        ///   service.
        /// </summary>
        ///
        public ServiceBusTransportType TransportType { get; set; } = ServiceBusTransportType.AmqpTcp;

        /// <summary>
        ///   The proxy to use for communication over web sockets.
        /// </summary>
        ///
        /// <remarks>
        ///   A proxy cannot be used for communication over TCP; if web sockets are not in
        ///   use, specifying a proxy is an invalid option.
        /// </remarks>
        public IWebProxy WebProxy { get; set; }

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
        /// a message. This does not apply for functions that receive a batch of messages.
        /// </summary>
        public Func<ProcessErrorEventArgs, Task> ExceptionHandler { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of messages that will be passed to each function call. This only applies for functions that receive
        /// a batch of messages. The default value is 1000.
        /// </summary>
        public int MaxMessageBatchSize { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the maximum amount of time to wait for a message to be received for the
        /// currently active session. After this time has elapsed, the processor will close the session
        /// and attempt to process another session.
        /// If not specified, the <see cref="ServiceBusRetryOptions.TryTimeout"/> will be used.
        /// </summary>
        public TimeSpan? SessionIdleTimeout { get; set; }

        /// <summary>
        /// Gets or sets the JSON serialization settings to use when binding to POCOs.
        /// </summary>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public JsonSerializerSettings JsonSerializerSettings { get; set; } = new()
        {
            // The default value, DateParseHandling.DateTime, drops time zone information from DateTimeOffets.
            // This value appears to work well with both DateTimes (without time zone information) and DateTimeOffsets.
            DateParseHandling = DateParseHandling.DateTimeOffset,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };
#pragma warning restore AZC0014 // Avoid using banned types in public API

        /// <summary>
        /// Formats the options as JSON objects for display.
        /// </summary>
        /// <returns>Options formatted as JSON.</returns>
        string IOptionsFormatter.Format()
        {
            // Do not include ConnectionString in loggable options.
            var retryOptions = new JObject
            {
                { nameof(ServiceBusClientOptions.RetryOptions.Mode), ClientRetryOptions.Mode.ToString() },
                { nameof(ServiceBusClientOptions.RetryOptions.TryTimeout), ClientRetryOptions.TryTimeout },
                { nameof(ServiceBusClientOptions.RetryOptions.Delay), ClientRetryOptions.Delay },
                { nameof(ServiceBusClientOptions.RetryOptions.MaxDelay), ClientRetryOptions.MaxDelay },
                { nameof(ServiceBusClientOptions.RetryOptions.MaxRetries), ClientRetryOptions.MaxRetries },
            };

            JObject options = new JObject
            {
                { nameof(ClientRetryOptions), retryOptions },
                { nameof(TransportType),  TransportType.ToString()},
                { nameof(WebProxy),  WebProxy is WebProxy proxy ? proxy.Address.AbsoluteUri : string.Empty },
                { nameof(AutoCompleteMessages), AutoCompleteMessages },
                { nameof(PrefetchCount), PrefetchCount },
                { nameof(MaxAutoLockRenewalDuration), MaxAutoLockRenewalDuration },
                { nameof(MaxConcurrentCalls), MaxConcurrentCalls },
                { nameof(MaxConcurrentSessions), MaxConcurrentSessions },
                { nameof(MaxMessageBatchSize), MaxMessageBatchSize },
                { nameof(SessionIdleTimeout), SessionIdleTimeout.ToString() ?? string.Empty }
            };

            return options.ToString(Formatting.Indented);
        }

        internal Task ExceptionReceivedHandler(ProcessErrorEventArgs args)
        {
            ExceptionHandler?.Invoke(args);

            return Task.CompletedTask;
        }

        internal ServiceBusProcessorOptions ToProcessorOptions(bool autoCompleteMessagesOptionEvaluatedValue) =>
            new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = autoCompleteMessagesOptionEvaluatedValue,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                MaxConcurrentCalls = MaxConcurrentCalls
            };

        internal ServiceBusSessionProcessorOptions ToSessionProcessorOptions(bool autoCompleteMessagesOptionEvaluatedValue) =>
            new ServiceBusSessionProcessorOptions
            {
                AutoCompleteMessages = autoCompleteMessagesOptionEvaluatedValue,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                MaxConcurrentSessions = MaxConcurrentSessions,
                SessionIdleTimeout = SessionIdleTimeout
            };

        internal ServiceBusReceiverOptions ToReceiverOptions() =>
            new ServiceBusReceiverOptions
            {
                PrefetchCount = PrefetchCount
            };

        internal ServiceBusClientOptions ToClientOptions() =>
            new ServiceBusClientOptions
            {
                RetryOptions = ClientRetryOptions,
                WebProxy = WebProxy,
                TransportType = TransportType
            };
    }
}
