// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Compatibility;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;
using TrackOne;
using TrackOne.Amqp;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneEventHubClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TrackOneEventHubClientTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresTheHost(string host)
        {
            Assert.That(() => new TrackOneEventHubClient(host, "test-path", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresTheEventHubName(string path)
        {
            Assert.That(() => new TrackOneEventHubClient("my.eventhub.com", path, Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheCredential()
        {
            Assert.That(() => new TrackOneEventHubClient("my.eventhub.com", "somePath", null, new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            Assert.That(() => new TrackOneEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), null, Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheDefaultRetryPolicy()
        {
            Assert.That(() => new TrackOneEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateFailsOnUnknownConnectionType()
        {
            var options = new EventHubClientOptions
            {
                TransportType = (TransportType)Int32.MinValue
            };

            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();

            Assert.That(() => TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateFailsForUnknownCredentialType()
        {
            var options = new EventHubClientOptions();
            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var credential = Mock.Of<TokenCredential>();

            Assert.That(() => TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientCreatesTheProperClientType()
        {
            var options = new EventHubClientOptions();
            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var client = TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry);

            try
            {
                Assert.That(client, Is.Not.Null, "The client should have been returned.");
                Assert.That(client, Is.InstanceOf<AmqpEventHubClient>(), "The client should be specific to the AMQP protocol.");
            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task CreateClientTranslatesTheTransportType(TransportType connectionType)
        {
            var options = new EventHubClientOptions
            {
                TransportType = connectionType
            };

            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry);

            try
            {
                if (connectionType.ToString().ToLower().Contains("websockets"))
                {
                    Assert.That(client.ConnectionStringBuilder.TransportType.ToString().ToLower(), Contains.Substring("websockets"), "The transport type should be based on WebSockets.");
                }
                else
                {
                    Assert.That(client.ConnectionStringBuilder.TransportType.ToString().ToLower(), Does.Not.Contain("websockets"), "The transport type should be based on TCP.");
                }

            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientTranslatesTheSharedKeyCredential()
        {
            var options = new EventHubClientOptions();
            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry);

            try
            {
                Assert.That(client.InternalTokenProvider, Is.InstanceOf<TrackOneSharedAccessTokenProvider>(), "The token provider should be the track one SAS adapter.");
                Assert.That(((TrackOneSharedAccessTokenProvider)client.InternalTokenProvider).SharedAccessSignature.Value, Is.EqualTo(signature.Value), "The SAS should match.");

            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientTranslatesTheEventHubCredential()
        {
            var options = new EventHubClientOptions();
            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var credential = new EventHubTokenCredential(Mock.Of<TokenCredential>(), resource);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry);

            try
            {
                Assert.That(client.InternalTokenProvider, Is.InstanceOf<TrackOneGenericTokenProvider>(), "The token provider should be the track one generic adapter.");
                Assert.That(((TrackOneGenericTokenProvider)client.InternalTokenProvider).Credential, Is.EqualTo(credential), "The source credential should match.");

            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientFormsTheCorrectEndpoint()
        {
            var options = new EventHubClientOptions();
            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry);

            try
            {
                var endpoint = client.ConnectionStringBuilder.Endpoint;
                Assert.That(endpoint.Scheme.ToLowerInvariant(), Contains.Substring(options.TransportType.GetUriScheme().ToLowerInvariant()), "The scheme should be part of the endpoint.");
                Assert.That(endpoint.Host.ToLowerInvariant(), Contains.Substring(host.ToLowerInvariant()), "The host should be part of the endpoint.");
                Assert.That(endpoint.AbsolutePath.ToLowerInvariant(), Contains.Substring(eventHubName.ToLowerInvariant()), "The host should be part of the endpoint.");
            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientPopulatesTheEventHubName()
        {
            var options = new EventHubClientOptions();
            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry);

            try
            {
                Assert.That(client.EventHubName, Is.EqualTo(eventHubName), "The client should recognize the Event Hub path.");
            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientPopulatesTheProxy()
        {
            var options = new EventHubClientOptions
            {
                TransportType = TransportType.AmqpWebSockets,
                Proxy = Mock.Of<IWebProxy>()
            };

            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetry);

            try
            {
                Assert.That(client.WebProxy, Is.SameAs(options.Proxy), "The client should honor the proxy.");
            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientUsesClientOptionsForTheRetryPolicy()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var options = new EventHubClientOptions
            {
                TransportType = TransportType.AmqpWebSockets,
                RetryOptions = retryOptions
            };

            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => Mock.Of<EventHubRetryPolicy>());

            try
            {
                Assert.That(client.RetryPolicy, Is.Not.Null, "The client should have a retry policy.");

                var sourcePolicy = GetSourcePolicy((TrackOneRetryPolicy)client.RetryPolicy);
                Assert.That(sourcePolicy, Is.InstanceOf<BasicRetryPolicy>(), "The source retry policy should be a basic retry policy.");

                var clientPolicy = (BasicRetryPolicy)sourcePolicy;
                Assert.That(clientPolicy.Options.Delay, Is.EqualTo(retryOptions.Delay), "The delays should match.");
                Assert.That(clientPolicy.Options.MaximumDelay, Is.EqualTo(retryOptions.MaximumDelay), "The maximum delays should match.");
                Assert.That(clientPolicy.Options.MaximumRetries, Is.EqualTo(retryOptions.MaximumRetries), "The maximum retries should match.");
                Assert.That(clientPolicy.Options.TryTimeout, Is.EqualTo(retryOptions.TryTimeout), "The per-try timeouts should match.");
            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientUsesDefaultPolicyForTheRetryPolicy()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var options = new EventHubClientOptions();
            options.ClearRetryOptions();

            var host = "my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetryPolicy = new BasicRetryPolicy(retryOptions);
            var client = (AmqpEventHubClient)TrackOneEventHubClient.CreateClient(host, eventHubName, credential, options, () => defaultRetryPolicy);

            try
            {
                Assert.That(client.RetryPolicy, Is.Not.Null, "The client should have a retry policy.");
                Assert.That(client.RetryPolicy, Is.InstanceOf<TrackOneRetryPolicy>(), "The client should always use the track one compatibility retry policy.");

                var clientPolicy = GetSourcePolicy((TrackOneRetryPolicy)client.RetryPolicy);
                Assert.That(clientPolicy, Is.SameAs(defaultRetryPolicy), "The default policy should have been used as the source policy.");
            }
            finally
            {
                await client?.CloseAsync();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateClientSetsTheOperationTimeout()
        {
            var retryOptions = new RetryOptions
            {
                TryTimeout = TimeSpan.FromMinutes(59)
            };

            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var options = new EventHubClientOptions { RetryOptions = retryOptions };
            var defaultRetryPolicy = new BasicRetryPolicy(retryOptions);
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetryPolicy, (host, path, credential, options, retry) => mock);

            try
            {
                await client.GetPropertiesAsync(default);

                var innerClient = GetTrackOneClient(client);
                Assert.That(innerClient.ConnectionStringBuilder.OperationTimeout, Is.EqualTo(defaultRetryPolicy.CalculateTryTimeout(0)));
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotDelegateIfTheClientWasNotCreated()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            await client.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDelegatesToTheClient()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            // Invoke an operation to force the client to be lazily instantiated.  Otherwise,
            // Close does not delegate the call.

            await client.GetPropertiesAsync(default);
            await client.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPropertiesAsyncDelegatesToTheClient()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                await client.GetPropertiesAsync(default);
                Assert.That(mock.WasGetRuntimeInvoked, Is.True);
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesAsyncDelegatesToTheClient()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                var partitionId = "0123";

                await client.GetPartitionPropertiesAsync(partitionId, CancellationToken.None);
                Assert.That(mock.GetPartitionRuntimePartitionInvokedWith, Is.EqualTo(partitionId));
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateProducer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateProducerDelegatesToTheClient()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                var producerOptions = new EventHubProducerOptions { PartitionId = "45345" };

                // Because the producer is lazily instantiated, an operation needs to be requested to force creation.  Because we are returning a null
                // producer from within the mock client, that operation will fail with a null reference exception.

                Assert.That(async () => await client.CreateProducer(producerOptions, defaultRetry)?.SendAsync(new[] { new EventData(new byte[] { 0x12 }) }), Throws.InstanceOf<NullReferenceException>(), "because the EventDataSender was not populated.");
                Assert.That(mock.CreateProducerInvokedWith, Is.EqualTo(producerOptions.PartitionId));
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateProducer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateProducerUsesRetryOptionsWhenProvided()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                var retryOptions = new RetryOptions
                {
                    Delay = TimeSpan.FromSeconds(1),
                    MaximumDelay = TimeSpan.FromSeconds(2),
                    TryTimeout = TimeSpan.FromSeconds(3),
                    MaximumRetries = 99,
                };

                var producerOptions = new EventHubProducerOptions
                {
                    PartitionId = "45345",
                    RetryOptions = retryOptions
                };

                var producer = client.CreateProducer(producerOptions, defaultRetry);
                Assert.That(producer.RetryPolicy, Is.InstanceOf<BasicRetryPolicy>(), "The consumer should have been created using the options.");

                var producerRetry = (BasicRetryPolicy)producer.RetryPolicy;
                Assert.That(producerRetry.Options.Delay, Is.EqualTo(retryOptions.Delay), "The delays should match.");
                Assert.That(producerRetry.Options.MaximumDelay, Is.EqualTo(retryOptions.MaximumDelay), "The maximum delays should match.");
                Assert.That(producerRetry.Options.MaximumRetries, Is.EqualTo(retryOptions.MaximumRetries), "The maximum retries should match.");
                Assert.That(producerRetry.Options.TryTimeout, Is.EqualTo(retryOptions.TryTimeout), "The per-try timeouts should match.");
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateProducer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateProducerUsesDefaultRetryPolicyWhenNoOptionsAreProvided()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                var producerOptions = new EventHubProducerOptions
                {
                    PartitionId = "45345",
                    RetryOptions = null
                };

                var producer = client.CreateProducer(producerOptions, defaultRetry);
                Assert.That(producer.RetryPolicy, Is.SameAs(defaultRetry));
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateConsumer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateConsumerDelegatesToTheClient()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                var partitionId = "32234";
                var consumerGroup = "AGroup";
                var eventPosition = EventPosition.FromOffset(34);
                var consumerOptions = new EventHubConsumerOptions { Identifier = "Test" };

                // Because the consumer is lazily instantiated, an operation needs to be requested to force creation.  Because we are returning a null
                // consumer from within the mock client, that operation will fail with a null reference exception.

                Assert.That(async () => await client.CreateConsumer(consumerGroup, partitionId, eventPosition, consumerOptions, defaultRetry).ReceiveAsync(10), Throws.InstanceOf<NullReferenceException>(), "because the PartitionReceiver was not populated.");

                (var calledConsumerGroup, var calledPartition, var calledPosition, var calledPriority, var calledOptions) = mock.CreateReceiverInvokedWith;

                Assert.That(calledConsumerGroup, Is.EqualTo(consumerGroup), "The consumer group should match.");
                Assert.That(calledPartition, Is.EqualTo(partitionId), "The partition should match.");
                Assert.That(calledPosition.Offset, Is.EqualTo(eventPosition.Offset), "The event position offset should match.");
                Assert.That(calledOptions.Identifier, Is.EqualTo(consumerOptions.Identifier), "The options should match.");
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateConsumer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateConsumerUsesRetryOptionsWhenProvided()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                var partitionId = "32234";
                var consumerGroup = "AGroup";
                var eventPosition = EventPosition.FromOffset(34);

                var retryOptions = new RetryOptions
                {
                    Delay = TimeSpan.FromSeconds(1),
                    MaximumDelay = TimeSpan.FromSeconds(2),
                    TryTimeout = TimeSpan.FromSeconds(3),
                    MaximumRetries = 99,
                };

                var consumerOptions = new EventHubConsumerOptions
                {
                    Identifier = "Test",
                    RetryOptions = retryOptions
                };

                var consumer = client.CreateConsumer(consumerGroup, partitionId, eventPosition, consumerOptions, defaultRetry);
                Assert.That(consumer.RetryPolicy, Is.InstanceOf<BasicRetryPolicy>(), "The consumer should have been created using the options.");

                var consumerRetry = (BasicRetryPolicy)consumer.RetryPolicy;
                Assert.That(consumerRetry.Options.Delay, Is.EqualTo(retryOptions.Delay), "The delays should match.");
                Assert.That(consumerRetry.Options.MaximumDelay, Is.EqualTo(retryOptions.MaximumDelay), "The maximum delays should match.");
                Assert.That(consumerRetry.Options.MaximumRetries, Is.EqualTo(retryOptions.MaximumRetries), "The maximum retries should match.");
                Assert.That(consumerRetry.Options.TryTimeout, Is.EqualTo(retryOptions.TryTimeout), "The per-try timeouts should match.");
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CreateConsumer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateConsumerUsesDefaultRetryPolicyWhenNoOptionsAreProvided()
        {
            var options = new EventHubClientOptions();
            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var defaultRetry = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetry, (host, path, credential, options, retry) => mock);

            try
            {
                var partitionId = "32234";
                var consumerGroup = "AGroup";
                var eventPosition = EventPosition.FromOffset(34);
                var consumerOptions = new EventHubConsumerOptions
                {
                    Identifier = "Test",
                    RetryOptions = null
                };

                var consumer = client.CreateConsumer(consumerGroup, partitionId, eventPosition, consumerOptions, defaultRetry);
                Assert.That(consumer.RetryPolicy, Is.SameAs(defaultRetry));
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void RetryPolicyIsUpdatedWhenTheClientIsNotCreated()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var options = new EventHubClientOptions();
            var defaultRetryPolicy = new BasicRetryPolicy(retryOptions);
            var newRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetryPolicy, (host, path, credential, options, retry) => mock);

            client.UpdateRetryPolicy(newRetryPolicy);

            var activePolicy = GetRetryPolicy(client);
            Assert.That(activePolicy, Is.SameAs(newRetryPolicy));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task RetryPolicyIsUpdatedWhenTheClientCreated()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var options = new EventHubClientOptions();
            var defaultRetryPolicy = new BasicRetryPolicy(retryOptions);
            var newRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetryPolicy, (host, path, credential, options, retry) => mock);

            try
            {
                await client.GetPropertiesAsync(default);

                client.UpdateRetryPolicy(newRetryPolicy);

                var activePolicy = GetRetryPolicy(client);

                Assert.That(activePolicy, Is.SameAs(newRetryPolicy), "The client's retry policy should be updated.");
                Assert.That(mock.RetryPolicy, Is.TypeOf<TrackOneRetryPolicy>(), "The track one client retry policy should be a custom compatibility wrapper.");

                var trackOnePolicy = GetSourcePolicy((TrackOneRetryPolicy)mock.RetryPolicy);
                Assert.That(trackOnePolicy, Is.SameAs(newRetryPolicy), "The new retry policy should have been used as the source for the compatibility wrapper.");
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OperationTimeoutIsUpdatedWhenTheClientCreated()
        {
            var retryOptions = new RetryOptions
            {
                TryTimeout = TimeSpan.FromMinutes(18)
            };

            var host = "http://my.eventhub.com";
            var eventHubName = "some-path";
            var resource = $"amqps://{ host }/{ eventHubName }";
            var signature = new SharedAccessSignature(resource, "keyName", "KEY", TimeSpan.FromHours(1));
            var credential = new SharedAccessSignatureCredential(signature);
            var options = new EventHubClientOptions();
            var defaultRetryPolicy = new BasicRetryPolicy(new RetryOptions());
            var newRetryPolicy = new BasicRetryPolicy(retryOptions);
            var mock = new ObservableClientMock(host, eventHubName, credential, options);
            var client = new TrackOneEventHubClient(host, eventHubName, credential, options, defaultRetryPolicy, (host, path, credential, options, retry) => mock);

            try
            {
                await client.GetPropertiesAsync(default);
                client.UpdateRetryPolicy(newRetryPolicy);

                var innerClient = GetTrackOneClient(client);
                Assert.That(innerClient.ConnectionStringBuilder.OperationTimeout, Is.EqualTo(newRetryPolicy.CalculateTryTimeout(0)));
            }
            finally
            {
                await client?.CloseAsync(default);
            }
        }

        /// <summary>
        ///   Gets the retry policy from a <see cref="TrackOneEventHubClient" />
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="client">The client to retrieve the retry policy from.</param>
        ///
        /// <returns>The retry policy</returns>
        ///
        private static EventHubRetryPolicy GetRetryPolicy(TrackOneEventHubClient client) =>
            (EventHubRetryPolicy)
                typeof(TrackOneEventHubClient)
                    .GetField("_retryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(client);

        /// <summary>
        ///   Gets the retry policy used as the source of a <see cref="TrackOneRetryPolicy" />
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="policy">The policy to retrieve the source policy from.</param>
        ///
        /// <returns>The retry policy</returns>
        ///
        private static EventHubRetryPolicy GetSourcePolicy(TrackOneRetryPolicy policy) =>
            (EventHubRetryPolicy)
                typeof(TrackOneRetryPolicy)
                    .GetField("_sourcePolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(policy);

        /// <summary>
        ///   Gets the track one Event Hub client used by a <see cref="TrackOneEventHubClient" />
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="client">The client to retrieve the inner track one client from.</param>
        ///
        /// <returns>The track one client</returns>
        ///
        private static TrackOne.EventHubClient GetTrackOneClient(TrackOneEventHubClient client) =>
            (TrackOne.EventHubClient)
                typeof(TrackOneEventHubClient)
                    .GetProperty("TrackOneClient", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(client);

        /// <summary>
        ///   Allows for observation of operations performed by the client for testing purposes.
        /// </summary>
        ///
        private class ObservableClientMock : TrackOne.EventHubClient
        {
            public bool WasCloseAsyncInvoked;
            public bool WasGetRuntimeInvoked;
            public string GetPartitionRuntimePartitionInvokedWith;
            public string CreateProducerInvokedWith;
            public (string ConsumerGroup, string Partition, TrackOne.EventPosition StartingPosition, long? Priority, TrackOne.ReceiverOptions Options) CreateReceiverInvokedWith;


            public ObservableClientMock(string host,
                                        string path,
                                        TokenCredential credential,
                                        EventHubClientOptions options) : base(new TrackOne.EventHubsConnectionStringBuilder(new Uri(host), path, "keyName", "KEY!", options.RetryOptions.TryTimeout))
            {
            }

            protected override Task OnCloseAsync()
            {
                WasCloseAsyncInvoked = true;
                return Task.CompletedTask;
            }

            protected override PartitionReceiver OnCreateReceiver(string consumerGroupName, string partitionId, TrackOne.EventPosition eventPosition, long? epoch, TrackOne.ReceiverOptions consumerOptions)
            {
                CreateReceiverInvokedWith =
                (
                   consumerGroupName,
                   partitionId,
                   eventPosition,
                   epoch,
                   consumerOptions
                );

                return default(PartitionReceiver);
            }

            protected override Task<EventHubPartitionRuntimeInformation> OnGetPartitionRuntimeInformationAsync(string partitionId)
            {
                GetPartitionRuntimePartitionInvokedWith = partitionId;

                var partitionRuntimeInformation = new EventHubPartitionRuntimeInformation();
                partitionRuntimeInformation.LastEnqueuedOffset = "-1";

                return Task.FromResult(partitionRuntimeInformation);
            }

            protected override Task<EventHubRuntimeInformation> OnGetRuntimeInformationAsync()
            {
                WasGetRuntimeInvoked = true;
                return Task.FromResult(new EventHubRuntimeInformation());
            }

            internal override EventDataSender OnCreateEventSender(string partitionId)
            {
                CreateProducerInvokedWith = partitionId;
                return default(EventDataSender);
            }
        }
    }
}
