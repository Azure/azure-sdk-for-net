// Copyright (c) .NET Foundation. All rights reserved.
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
            BatchMessageOptions = new BatchMessageOptions();
            SingleMessageOptions = new SingleMessageOptions();
        }

        /// <summary>
        /// Gets or sets the options to use for functions that bind
        /// to multiple <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        public BatchMessageOptions BatchMessageOptions { get; set; }

        /// <summary>
        /// Gets or sets the options to use for functions that bind
        /// to a single <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        public SingleMessageOptions SingleMessageOptions { get; set; }

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
                { nameof(SingleMessageOptions), ConstructProcessingJObject()},
                { nameof(BatchMessageOptions), ConstructBatchProcessingJObject() },
            };

            return options.ToString(Formatting.Indented);
        }

        private JObject ConstructBatchProcessingJObject()
        {
            return new()
            {
                { nameof(BatchMessageOptions.MaxMessages), BatchMessageOptions.MaxMessages },
                { nameof(BatchMessageOptions.MaxReceiveWaitTime), BatchMessageOptions.MaxReceiveWaitTime.ToString() ?? string.Empty }
            };
        }

        private JObject ConstructProcessingJObject()
        {
            return new()
            {
                {nameof(SingleMessageOptions.MaxAutoLockRenewalDuration), SingleMessageOptions.MaxAutoLockRenewalDuration},
                {nameof(SingleMessageOptions.MaxConcurrentCalls), SingleMessageOptions.MaxConcurrentCalls},
                {nameof(SingleMessageOptions.MaxConcurrentSessions), SingleMessageOptions.MaxConcurrentSessions},
                {nameof(SingleMessageOptions.SessionIdleTimeout), SingleMessageOptions.SessionIdleTimeout.ToString() ?? string.Empty},
            };
        }

        internal Task ExceptionReceivedHandler(ProcessErrorEventArgs args)
        {
            SingleMessageOptions.ExceptionHandler?.Invoke(args);

            return Task.CompletedTask;
        }

        internal ServiceBusProcessorOptions ToProcessorOptions() =>
            new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = AutoCompleteMessages,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = SingleMessageOptions.MaxAutoLockRenewalDuration,
                MaxConcurrentCalls = SingleMessageOptions.MaxConcurrentCalls
            };

        internal ServiceBusSessionProcessorOptions ToSessionProcessorOptions() =>
            new ServiceBusSessionProcessorOptions
            {
                AutoCompleteMessages = AutoCompleteMessages,
                PrefetchCount = PrefetchCount,
                MaxAutoLockRenewalDuration = SingleMessageOptions.MaxAutoLockRenewalDuration,
                MaxConcurrentSessions = SingleMessageOptions.MaxConcurrentSessions,
                SessionIdleTimeout = SingleMessageOptions.SessionIdleTimeout
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
