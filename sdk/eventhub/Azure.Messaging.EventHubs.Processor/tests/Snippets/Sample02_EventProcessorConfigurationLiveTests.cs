// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample02_EventProcessorConfiguration sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample02_EventProcessorConfigurationLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureTransportWithFullOptions()
        {
            #region Snippet:EventHubs_Processor_Sample02_TransportFullConnectionOptions

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var processorOptions = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets
                }
            };

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureTransportByProperty()
        {
            #region Snippet:EventHubs_Processor_Sample02_TransportProperty

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureProxyWithFullOptions()
        {
            #region Snippet:EventHubs_Processor_Sample02_ProxyFullConnectionOptions

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var processorOptions = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("https://proxyserver:80", true)
                }
            };

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureProxyByProperty()
        {
            #region Snippet:EventHubs_Processor_Sample02_ProxyProperty

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;
            processorOptions.ConnectionOptions.Proxy = new WebProxy("https://proxyserver:80", true);

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureRetryWithFullOptions()
        {
            #region Snippet:EventHubs_Processor_Sample02_RetryWithFullOptions

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var processorOptions = new EventProcessorClientOptions
            {
                RetryOptions = new EventHubsRetryOptions
                {
                    Mode = EventHubsRetryMode.Exponential,
                    MaximumRetries = 5,
                    Delay = TimeSpan.FromMilliseconds(800),
                    MaximumDelay = TimeSpan.FromSeconds(10)
                }
            };

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureRetryByProperty()
        {
            #region Snippet:EventHubs_Processor_Sample02_RetryByProperty

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = "not-real";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = "fakeHub";
            /*@@*/ consumerGroup = "fakeConsumer";

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.RetryOptions.Mode = EventHubsRetryMode.Fixed;
            processorOptions.RetryOptions.MaximumRetries = 5;

            var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CustomRetry()
        {
            #region Snippet:EventHubs_Processor_Sample02_CustomRetryUse

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
            #region Snippet:EventHubs_Processor_Sample02_RetryOptionsTryTimeout

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
            #region Snippet:EventHubs_Processor_Sample02_ConnectionOptionsDefaultProxy

            var options = new EventHubConnectionOptions
            {
                TransportType = EventHubsTransportType.AmqpWebSockets,
                Proxy = HttpClient.DefaultProxy
            };

            #endregion

            Assert.That(options, Is.Not.Null);
        }
#endif

        #region Snippet:EventHubs_Processor_Sample02_CustomRetryPolicy

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
