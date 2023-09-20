// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Scale;
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
        /// To specify an infinite duration, use <see cref="Timeout.InfiniteTimeSpan"/> or <value>-00:00:00.0010000</value>
        /// if specifying via host.json.
        /// </summary>
        public TimeSpan MaxAutoLockRenewalDuration
        {
            get => _maxAutoRenewDuration;

            set
            {
                if (value != Timeout.InfiniteTimeSpan)
                {
                    Argument.AssertNotNegative(value, nameof(MaxAutoLockRenewalDuration));
                }

                _maxAutoRenewDuration = value;
            }
        }
        private TimeSpan _maxAutoRenewDuration = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Gets or sets the maximum number of messages that can be processed concurrently by a function.
        /// This setting does not apply for functions that receive a batch of messages. The default is 16 times
        /// the return value of <see cref="Utility.GetProcessorCount"/>. When <see cref="ConcurrencyOptions.DynamicConcurrencyEnabled"/>
        /// is true, this value will be ignored, and concurrency will be increased/decreased dynamically.
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
        /// The default value is 8. This applies only to functions that set <see cref="ServiceBusTriggerAttribute.IsSessionsEnabled"/>
        /// to <c>true</c>. This does not apply for functions that receive a batch of messages.
        /// When <see cref="ConcurrencyOptions.DynamicConcurrencyEnabled"/> is true, this value will be ignored,
        /// and concurrency will be increased/decreased dynamically.
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
        private int _maxConcurrentSessions = 8;

        /// <summary>
        /// Gets or sets the maximum number of concurrent calls to the function per session.
        /// Thus the total number of concurrent calls will be equal to MaxConcurrentSessions * MaxConcurrentCallsPerSession.
        /// The default value is 1. This applies only to functions that set <see cref="ServiceBusTriggerAttribute.IsSessionsEnabled"/>
        /// to <c>true</c>. This does not apply for functions that receive a batch of messages.
        /// When <see cref="ConcurrencyOptions.DynamicConcurrencyEnabled"/> is true, this value will be ignored,
        /// and concurrency will be increased/decreased dynamically.
        /// </summary>
        ///
        /// <value>The maximum number of concurrent calls to the message handler for each session that is being processed.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///   A value that is not positive is attempted to be set for the property.
        /// </exception>
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
        /// Gets or sets an optional error handler that will be invoked if an exception occurs while attempting to process
        /// a message. This does not apply for functions that receive a batch of messages.
        /// </summary>
        public Func<ProcessErrorEventArgs, Task> ProcessErrorAsync { get; set; }

        /// <summary>
        /// Optional handler that can be set to be notified when a new session is about to be processed.
        /// </summary>
        public Func<ProcessSessionEventArgs, Task> SessionInitializingAsync { get; set; }

        /// <summary>
        /// Optional handler that can be set to be notified when a session is about to be closed for processing.
        /// </summary>
        public Func<ProcessSessionEventArgs, Task> SessionClosingAsync { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of messages that will be passed to each function call. This only applies for functions that receive
        /// a batch of messages. The default value is 1000.
        /// </summary>
        public int MaxMessageBatchSize { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the minimum number of messages desired for a batch. This setting applies only to functions that
        /// receive multiple messages. This value must be less than <see cref="MaxMessageBatchSize"/> and is used in
        /// conjunction with <see cref="MaxBatchWaitTime"/>. If <see cref="MaxBatchWaitTime"/> passes and less than
        /// <see cref="MinMessageBatchSize"/> has been received, the function will be invoked with a partial batch.
        /// Default 1.
        /// </summary>
        /// <remarks>
        /// The minimum size is not a strict guarantee, as a partial batch will be dispatched if a full batch cannot be
        /// prepared before the <see cref="MaxBatchWaitTime"/> has elapsed.
        /// </remarks>
        public int MinMessageBatchSize { get; set; } = 1;

        /// <summary>
        /// Gets or sets the maximum time that the trigger should wait to fill a batch before invoking the function.
        /// This is only considered when <see cref="MinMessageBatchSize"/> is set to larger than 1 and is otherwise unused.
        /// If less than <see cref="MinMessageBatchSize" /> messages were available before the wait time elapses, the function
        /// will be invoked with a partial batch. This value should be no longer then 50% of the entity message lock duration.
        /// Therefore, the maximum allowed value is 2 minutes and 30 seconds.
        /// Otherwise, you may get lock exceptions when messages are pulled from the cache.
        /// The default value is 30 seconds.
        /// </summary>
        public TimeSpan MaxBatchWaitTime { get; set; } = TimeSpan.FromSeconds(30);

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

        /// <summary>
        /// <inheritdoc cref="ServiceBusClientOptions.EnableCrossEntityTransactions"/>
        /// </summary>
        public bool EnableCrossEntityTransactions { get; set; }

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
                { nameof(MaxConcurrentCallsPerSession), MaxConcurrentCallsPerSession },
                { nameof(MaxMessageBatchSize), MaxMessageBatchSize },
                { nameof(MinMessageBatchSize), MinMessageBatchSize },
                { nameof(MaxBatchWaitTime), MaxBatchWaitTime },
                { nameof(SessionIdleTimeout), SessionIdleTimeout.ToString() ?? string.Empty },
                { nameof(EnableCrossEntityTransactions), EnableCrossEntityTransactions }
            };

            return options.ToString(Formatting.Indented);
        }

        internal async Task ExceptionReceivedHandler(ProcessErrorEventArgs args)
        {
            var processErrorAsync = ProcessErrorAsync;
            if (processErrorAsync != null)
            {
                await processErrorAsync(args).ConfigureAwait(false);
            }
        }

        internal async Task SessionInitializingHandler(ProcessSessionEventArgs args)
        {
            var sessionInitializingAsync = SessionInitializingAsync;
            if (sessionInitializingAsync != null)
            {
                await sessionInitializingAsync(args).ConfigureAwait(false);
            }
        }

        internal async Task SessionClosingHandler(ProcessSessionEventArgs args)
        {
            var sessionClosingAsync = SessionClosingAsync;
            if (sessionClosingAsync != null)
            {
                await sessionClosingAsync(args).ConfigureAwait(false);
            }
        }

        internal ServiceBusProcessorOptions ToProcessorOptions(bool autoCompleteMessagesOptionEvaluatedValue, bool dynamicConcurrencyEnabled)
        {
           var processorOptions = new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = autoCompleteMessagesOptionEvaluatedValue,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration
            };

            if (dynamicConcurrencyEnabled)
            {
                // when DC is enabled, concurrency starts at 1 and will be dynamically adjusted over time
                // by UpdateConcurrency.
                processorOptions.MaxConcurrentCalls = 1;
            }
            else
            {
                processorOptions.MaxConcurrentCalls = MaxConcurrentCalls;
            }

            return processorOptions;
        }

        internal ServiceBusSessionProcessorOptions ToSessionProcessorOptions(bool autoCompleteMessagesOptionEvaluatedValue, bool dynamicConcurrencyEnabled)
        {
            var processorOptions = new ServiceBusSessionProcessorOptions
            {
                AutoCompleteMessages = autoCompleteMessagesOptionEvaluatedValue,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = MaxAutoLockRenewalDuration,
                SessionIdleTimeout = SessionIdleTimeout
            };

            if (dynamicConcurrencyEnabled)
            {
                // when DC is enabled, session concurrency starts at 1 and will be dynamically adjusted over time
                // by UpdateConcurrency.
                processorOptions.MaxConcurrentSessions = 1;

                // Currently dynamic concurrency does not scale the number of concurrent calls per session.
                processorOptions.MaxConcurrentCallsPerSession = 1;
            }
            else
            {
                processorOptions.MaxConcurrentSessions = MaxConcurrentSessions;
                processorOptions.MaxConcurrentCallsPerSession = MaxConcurrentCallsPerSession;
            }

            return processorOptions;
        }

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
                TransportType = TransportType,
                EnableCrossEntityTransactions = EnableCrossEntityTransactions
            };
    }
}
