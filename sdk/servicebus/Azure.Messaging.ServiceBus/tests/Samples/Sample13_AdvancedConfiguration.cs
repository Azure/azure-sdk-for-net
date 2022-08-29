// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample13_AdvancedConfiguration : ServiceBusLiveTestBase
    {
        [Test]
        public void ConfigureProxy()
        {
            #region Snippet:ServiceBusConfigureTransport
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString, new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets,
                WebProxy = new WebProxy("https://myproxyserver:80")
            });
            #endregion

            Assert.AreEqual(ServiceBusTransportType.AmqpWebSockets, client.TransportType);
        }

        [Test]
        public void ConfigureRetryOptions()
        {
            #region Snippet:ServiceBusConfigureRetryOptions
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString, new ServiceBusClientOptions
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

        [Test]
        public void ConfigurePrefetchReceiver()
        {
            #region Snippet:ServiceBusConfigurePrefetchReceiver
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver("<queue-name>", new ServiceBusReceiverOptions
            {
                PrefetchCount = 10
            });
            #endregion

            Assert.AreEqual(10, receiver.PrefetchCount);
        }

        [Test]
        public void ConfigurePrefetchProcessor()
        {
            #region Snippet:ServiceBusConfigurePrefetchProcessor
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString);
            ServiceBusProcessor processor = client.CreateProcessor("<queue-name>", new ServiceBusProcessorOptions
            {
                PrefetchCount = 10
            });
            #endregion

            Assert.AreEqual(10, processor.PrefetchCount);
        }
    }
}