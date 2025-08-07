// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample02_EventHubsClients sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample02_EventHubsClientsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureProducerTransportWithFullOptions()
        {
            #region Snippet:EventHubs_Sample02_ProducerTransportFullConnectionOptions

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producerOptions = new EventHubProducerClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets
                }
            };

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                producerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureProducerTransportByProperty()
        {
            #region Snippet:EventHubs_Sample02_ProducerTransportProperty

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producerOptions = new EventHubProducerClientOptions();
            producerOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                producerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureProducerProxyWithFullOptions()
        {
            #region Snippet:EventHubs_Sample02_ProducerProxyFullConnectionOptions

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producerOptions = new EventHubProducerClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("https://proxyserver:80", true)
                }
            };

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                producerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureProducerProxyByProperty()
        {
            #region Snippet:EventHubs_Sample02_ProducerProxyProperty

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producerOptions = new EventHubProducerClientOptions();
            producerOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;
            producerOptions.ConnectionOptions.Proxy = new WebProxy("https://proxyserver:80", true);

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                producerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureCustomEndpointAddress()
        {
            #region Snippet:EventHubs_Sample02_ConnectionOptionsCustomEndpoint

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            var producerOptions = new EventHubProducerClientOptions();
            producerOptions.ConnectionOptions.CustomEndpointAddress = new Uri("amqps://app-gateway.mycompany.com");

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                producerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureRemoteCertificateValidationCallback()
        {
            #region Snippet:EventHubs_Sample02_RemoteCertificateValidationCallback

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fakse";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif

            static bool ValidateServerCertificate(
                  object sender,
                  X509Certificate certificate,
                  X509Chain chain,
                  SslPolicyErrors sslPolicyErrors)
            {
                if ((sslPolicyErrors == SslPolicyErrors.None)
                    || (certificate.Issuer == "My Company CA"))
                {
                     return true;
                }

                // Do not allow communication with unauthorized servers.

                return false;
            }

            var producerOptions = new EventHubProducerClientOptions();
            producerOptions.ConnectionOptions.CertificateValidationCallback = ValidateServerCertificate;

            var producer = new EventHubProducerClient(
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                producerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureConsumerRetryWithFullOptions()
        {
            #region Snippet:EventHubs_Sample02_ConsumerRetryWithFullOptions

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var consumerOptions = new EventHubConsumerClientOptions
            {
                RetryOptions = new EventHubsRetryOptions
                {
                    Mode = EventHubsRetryMode.Exponential,
                    MaximumRetries = 5,
                    Delay = TimeSpan.FromMilliseconds(800),
                    MaximumDelay = TimeSpan.FromSeconds(10)
                }
            };

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                consumerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await consumer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureConsumerRetryByProperty()
        {
            #region Snippet:EventHubs_Sample02_ConsumerRetryByProperty

#if SNIPPET
            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var credential = new DefaultAzureCredential();
#else
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var credential = EventHubsTestEnvironment.Instance.Credential;
#endif
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var consumerOptions = new EventHubConsumerClientOptions();
            consumerOptions.RetryOptions.Mode = EventHubsRetryMode.Fixed;
            consumerOptions.RetryOptions.MaximumRetries = 5;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                consumerOptions);

            #endregion

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await consumer.CloseAsync(cancellationSource.Token).IgnoreExceptions();
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CustomRetry()
        {
            #region Snippet:EventHubs_Sample02_CustomRetryUse

            var options = new EventHubsRetryOptions
            {
                CustomRetryPolicy = new ExampleRetryPolicy()
            };

            #endregion

            Assert.That(options, Is.Not.Null);
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void TryTimeoutConfiguration()
        {
            #region Snippet:EventHubs_Sample02_RetryOptionsTryTimeout

            var options = new EventHubsRetryOptions
            {
                TryTimeout = TimeSpan.FromMinutes(1)
            };

            #endregion

            Assert.That(options, Is.Not.Null);
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsDefaultProxy()
        {
            #region Snippet:EventHubs_Sample02_ConnectionOptionsDefaultProxy

            var options = new EventHubConnectionOptions
            {
                TransportType = EventHubsTransportType.AmqpWebSockets,
                Proxy = HttpClient.DefaultProxy
            };

            #endregion

            Assert.That(options, Is.Not.Null);
        }

        #region Snippet:EventHubs_Sample02_CustomRetryPolicy

        public class ExampleRetryPolicy : EventHubsRetryPolicy
        {
            public override TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount)
            {
                // Only allow 5 retries.

                if (attemptCount > 5)
                {
                    return null;
                }

                // Only retry EventHubsExceptions that are flagged transient.  Use
                // a fixed delay of 1/4 second per attempt, for simplicity.

                return ((lastException is EventHubsException ex) && (ex.IsTransient))
                    ? TimeSpan.FromMilliseconds(250)
                    : default(TimeSpan?);
            }

            // Always use a 60 second timeout for operations.

            public override TimeSpan CalculateTryTimeout(int attemptCount) =>
                TimeSpan.FromSeconds(60);
        }

        #endregion

        /// <summary>
        ///   Serves as a shim to allow the illustration of using
        ///   the DefaultProxy, which is supported on .NET Core and later,
        ///   across all target frameworks.
        /// </summary>
        ///
        public static class HttpClient
        {
            public static WebProxy DefaultProxy { get; set; }
        }
    }
}
