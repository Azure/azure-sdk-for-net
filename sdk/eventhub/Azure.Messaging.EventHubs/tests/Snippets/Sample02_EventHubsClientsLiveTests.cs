// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample02_EventHubsClientsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConfigureProducerTransportWithFullOptions()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample02_ProducerTransportFullConnectionOptions

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producerOptions = new EventHubProducerClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets
                }
            };

            var producer = new EventHubProducerClient(
                connectionString,
                eventHubName,
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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample02_ProducerTransportProperty

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producerOptions = new EventHubProducerClientOptions();
            producerOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

            var producer = new EventHubProducerClient(
                connectionString,
                eventHubName,
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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample02_ProducerProxyFullConnectionOptions

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producerOptions = new EventHubProducerClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("https://proxyserver:80", true)
                }
            };

            var producer = new EventHubProducerClient(
                connectionString,
                eventHubName,
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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample02_ProducerProxyProperty

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producerOptions = new EventHubProducerClientOptions();
            producerOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;
            producerOptions.ConnectionOptions.Proxy = new WebProxy("https://proxyserver:80", true);

            var producer = new EventHubProducerClient(
                connectionString,
                eventHubName,
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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample02_ConsumerRetryWithFullOptions

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

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
                connectionString,
                eventHubName,
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
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample02_ConsumerRetryByProperty

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var consumerOptions = new EventHubConsumerClientOptions();
            consumerOptions.RetryOptions.Mode = EventHubsRetryMode.Fixed;
            consumerOptions.RetryOptions.MaximumRetries = 5;

            var consumer = new EventHubConsumerClient(
                consumerGroup,
                connectionString,
                eventHubName,
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

#if NETCOREAPP3_1 || NET5
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
#endif

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
    }
}
