// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample13_AdvancedConfiguration : ServiceBusLiveTestBase
    {
        public void ConfigureProxy()
        {
            #region Snippet:ServiceBusConfigureTransport
            var client = new ServiceBusClient("<connection-string>", new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets,
                WebProxy = new WebProxy("<proxy-address>")
            });
            #endregion
        }

        public void ConfigureRetryOptions()
        {
            #region Snippet:ServiceBusConfigureRetryOptions
            var client = new ServiceBusClient("<connection-string>", new ServiceBusClientOptions
            {
                RetryOptions = new ServiceBusRetryOptions
                {
                    TryTimeout = TimeSpan.FromSeconds(60),
                    MaxRetries = 3,
                    Delay = TimeSpan.FromSeconds(.8)
                }
            });
            #endregion
        }

        public void ConfigurePrefetchReceiver()
        {
            #region Snippet:ServiceBusConfigurePrefetchReceiver
            var client = new ServiceBusClient("<connection-string>");
            ServiceBusReceiver receiver = client.CreateReceiver("<queue-name>", new ServiceBusReceiverOptions
            {
                PrefetchCount = 10
            });
            #endregion
        }

        public void ConfigurePrefetchProcessor()
        {
            #region Snippet:ServiceBusConfigurePrefetchProcessor
            var client = new ServiceBusClient("<connection-string>");
            ServiceBusProcessor processor = client.CreateProcessor("<queue-name>", new ServiceBusProcessorOptions
            {
                PrefetchCount = 10
            });
            #endregion
        }
    }
}