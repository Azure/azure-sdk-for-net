// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Azure.Messaging.EventHubs.Processor;
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
    public class Sample02_EventProcessorConfigurationLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureLoadBalancingStrategy()
        {
            #region Snippet:EventHubs_Processor_Sample02_LoadBalancingStrategy

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions
            {
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy
            };

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureLoadBalancingIntervals()
        {
            #region Snippet:EventHubs_Processor_Sample02_LoadBalancingIntervals

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions
            {
                LoadBalancingUpdateInterval = TimeSpan.FromSeconds(10),
                PartitionOwnershipExpirationInterval = TimeSpan.FromSeconds(30)
            };

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureTransportWithFullOptions()
        {
            #region Snippet:EventHubs_Processor_Sample02_TransportFullConnectionOptions

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets
                }
            };

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
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

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
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

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets,
                    Proxy = new WebProxy("https://proxyserver:80", true)
                }
            };

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
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

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.ConnectionOptions.TransportType = EventHubsTransportType.AmqpWebSockets;
            processorOptions.ConnectionOptions.Proxy = new WebProxy("https://proxyserver:80", true);

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureCustomEndpointAddress()
        {
            #region Snippet:EventHubs_Processor_Sample02_ConnectionOptionsCustomEndpoint

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.ConnectionOptions.CustomEndpointAddress = new Uri("amqps://app-gateway.mycompany.com");

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
                processorOptions);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureRemoteCertificateValidationCallback()
        {
            #region Snippet:EventHubs_Processor_Sample02_RemoteCertificateValidationCallback

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
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

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.ConnectionOptions.CertificateValidationCallback = ValidateServerCertificate;

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
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

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

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

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
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

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake";
            var consumerGroup = "$Default";

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var processorOptions = new EventProcessorClientOptions();
            processorOptions.RetryOptions.Mode = EventHubsRetryMode.Fixed;
            processorOptions.RetryOptions.MaximumRetries = 5;

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential,
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
