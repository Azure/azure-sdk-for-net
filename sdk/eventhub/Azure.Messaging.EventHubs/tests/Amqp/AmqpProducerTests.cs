// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Shared;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpProducer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpProducerTests
    {
        /// <summary>
        ///   The set of test cases for respecting basic retry configuration.
        /// </summary>
        ///
        public static IEnumerable<object[]> RetryOptionTestCases()
        {
            yield return new object[] { new EventHubsRetryOptions { MaximumRetries = 3, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = EventHubsRetryMode.Fixed } };
            yield return new object[] { new EventHubsRetryOptions { MaximumRetries = 0, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = EventHubsRetryMode.Fixed } };
        }

        /// <summary>
        /// Mock client diagnostics instance to pass through to EventDataBatch constructor.
        /// </summary>
        private static MessagingClientDiagnostics MockClientDiagnostics { get; } = new("mock", "mock", "mock", "mock", "mock");

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresTheEventHubName(string eventHub)
        {
            Assert.That(() => new AmqpProducer(eventHub, null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheConnectionScope()
        {
            Assert.That(() => new AmqpProducer("theMostAwesomeHubEvar", "0", "", null, Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>(), TransportProducerFeatures.IdempotentPublishing), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheRetryPolicy()
        {
            Assert.That(() => new AmqpProducer("theMostAwesomeHubEvar", null, "fake-id", Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), null, TransportProducerFeatures.IdempotentPublishing, new PartitionPublishingOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheProducerAsClosed()
        {
            var producer = new AmqpProducer("aHub", "0", "fake-", Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>());
            Assert.That(producer.IsClosed, Is.False, "The producer should not be closed on creation");

            await producer.CloseAsync(CancellationToken.None);
            Assert.That(producer.IsClosed, Is.True, "The producer should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var producer = new AmqpProducer("aHub", null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>());
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await producer.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Cancellation should trigger the appropriate exception.");
            Assert.That(producer.IsClosed, Is.False, "Cancellation should have interrupted closing and left the producer in an open state.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateLinkAndEnsureProducerStateAsyncRespectsPartitionOptions()
        {
            var expectedOptions = new PartitionPublishingOptions { ProducerGroupId = 1, OwnerLevel = 4, StartingSequenceNumber = 88 };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var producer = new Mock<AmqpProducer>("aHub", null, null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.IdempotentPublishing, expectedOptions)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            await producer.Object.ReadInitializationPublishingPropertiesAsync(default);

            Func<PartitionPublishingOptions, PartitionPublishingOptions, bool> areOptionsEqual = (first, second) =>
                first.ProducerGroupId == second.ProducerGroupId
                && first.OwnerLevel == second.OwnerLevel
                && first.StartingSequenceNumber == second.StartingSequenceNumber;

            producer
                .Protected()
                .Verify<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.Is<PartitionPublishingOptions>(options => areOptionsEqual(options, expectedOptions)),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateLinkAndEnsureProducerStateAsyncClearsTheStartingSequenceNumberAfterInitialization()
        {
            var expectedOptions = new PartitionPublishingOptions { ProducerGroupId = 1, OwnerLevel = 4, StartingSequenceNumber = 88 };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var mockConnectionScope = new Mock<AmqpConnectionScope>();

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", mockConnectionScope.Object, new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.IdempotentPublishing, expectedOptions)
            {
                CallBase = true
            };

            mockConnectionScope
                .Setup(scope => scope.OpenProducerLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<TransportProducerFeatures>(),
                    It.Is<PartitionPublishingOptions>(options => options.StartingSequenceNumber == expectedOptions.StartingSequenceNumber),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
               .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings { MaxMessageSize = 512 })))
               .Verifiable();

            Assert.That(GetPartitionPublishingOptions(producer.Object).StartingSequenceNumber, Is.EqualTo(expectedOptions.StartingSequenceNumber), "The initial options should have the sequence number set.");

            await producer.Object.ReadInitializationPublishingPropertiesAsync(default);
            Assert.That(GetPartitionPublishingOptions(producer.Object).StartingSequenceNumber, Is.Null, "After initializing state, the active options should not have a sequence number.");

            mockConnectionScope.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncValidatesTheOptions()
        {
            var producer = new AmqpProducer("aHub", null, "", Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>());
            Assert.That(async () => await producer.CreateBatchAsync(null, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateBatchAsyncEnsuresNotClosed(bool createLinkBeforehand)
        {
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            if (createLinkBeforehand)
            {
                producer
                    .Protected()
                    .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                        ItExpr.IsAny<string>(),
                        ItExpr.IsAny<string>(),
                        ItExpr.IsAny<PartitionPublishingOptions>(),
                        ItExpr.IsAny<TimeSpan>(),
                        ItExpr.IsAny<CancellationToken>())
                    .Callback(() => SetMaximumMessageSize(producer.Object, 100))
                    .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                    .Verifiable();

                Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), CancellationToken.None), Throws.Nothing);
            }

            await producer.Object.CloseAsync(CancellationToken.None);

            Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), CancellationToken.None), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncEnsuresConnectionNotClosed()
        {
            var endpoint = new Uri("amqps://not.real.com");
            var eventHub = "eventHubName";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var options = new EventHubProducerClientOptions();
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var mockCredential = new EventHubTokenCredential(Mock.Of<TokenCredential>());

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, mockCredential, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromSeconds(30));
            scope.Dispose();

            var producer = new AmqpProducer(eventHub, partition, identifier, scope, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            await producer.CloseAsync(CancellationToken.None);

            Assert.That(async () => await producer.CreateBatchAsync(new CreateBatchOptions(), CancellationToken.None),
                Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncEnsuresMaximumMessageSizeIsPopulated()
        {
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, 512))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(new CreateBatchOptions(), default);
            producer.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncDefaultsTheMaximumSizeWhenNotProvided()
        {
            var expectedMaximumSize = 512;
            var options = new CreateBatchOptions { MaximumSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);
            Assert.That(options.MaximumSizeInBytes, Is.EqualTo(expectedMaximumSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncRespectsTheMaximumSizeWhenProvided()
        {
            var expectedMaximumSize = 512;
            var options = new CreateBatchOptions { MaximumSizeInBytes = expectedMaximumSize };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize + 27))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);
            Assert.That(options.MaximumSizeInBytes, Is.EqualTo(expectedMaximumSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncVerifiesTheMaximumSize()
        {
            var linkMaximumSize = 512;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 1024 };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, linkMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            Assert.That(async () => await producer.Object.CreateBatchAsync(options, default), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncBuildsAnAmqpEventBatchWithTheOptions()
        {
            var options = new CreateBatchOptions { MaximumSizeInBytes = 512 };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, options.MaximumSizeInBytes.Value + 982))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);

            Assert.That(batch, Is.Not.Null, "The created batch should be populated.");
            Assert.That(batch, Is.InstanceOf<AmqpEventBatch>(), $"The created batch should be an { nameof(AmqpEventBatch) }.");
            Assert.That(GetEventBatchOptions((AmqpEventBatch)batch), Is.SameAs(options), "The provided options should have been used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CreateBatchAsyncRespectsTheCancellationTokenIfSetWhenCalled(bool createLinkBeforehand)
        {
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, 100))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            if (createLinkBeforehand)
            {
                Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), cancellationTokenSource.Token), Throws.Nothing);
            }

            cancellationTokenSource.Cancel();

            Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), cancellationTokenSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void CreateBatchAsyncAppliesTheRetryPolicy(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "customIDE34";
            var retriableException = new EventHubsException(true, "Test");
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                 .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void CreateBatchAsyncConsidersOperationCanceledExceptionAsRetriable(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "testIDEntif13r";
            var retriableException = new OperationCanceledException();
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void CreateBatchAsyncAppliesTheRetryPolicyForAmqpErrors(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "testIDEntif13r";
            var retriableException = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, "dummy");
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var identifier = "testIDEntif13r";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var embeddedException = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
            var identifier = "testIDEntif13r";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReadInitializationPublishingPropertiesAsyncEnsuresNotClosed(bool createLinkBeforehand)
        {
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            if (createLinkBeforehand)
            {
                producer
                    .Protected()
                    .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                        ItExpr.IsAny<string>(),
                        ItExpr.IsAny<string>(),
                        ItExpr.IsAny<PartitionPublishingOptions>(),
                        ItExpr.IsAny<TimeSpan>(),
                        ItExpr.IsAny<CancellationToken>())
                    .Callback(() =>
                    {
                        SetMaximumMessageSize(producer.Object, 100);
                        SetInitializedPartitionProperties(producer.Object, new PartitionPublishingProperties(false, null, null, null));
                    })
                    .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                    .Verifiable();

                Assert.That(async () => await producer.Object.CreateBatchAsync(new CreateBatchOptions(), CancellationToken.None), Throws.Nothing);
            }

            await producer.Object.CloseAsync(CancellationToken.None);
            Assert.That(async () => await producer.Object.ReadInitializationPublishingPropertiesAsync(CancellationToken.None), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadInitializationPublishingPropertiesAsyncEnsuresConnectionNotClosed()
        {
            var endpoint = new Uri("amqps://not.real.com");
            var eventHub = "eventHubName";
            var partition = "3";
            var identifier = "testIDEntif13r";
            var options = new EventHubProducerClientOptions();
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var mockCredential = new EventHubTokenCredential(Mock.Of<TokenCredential>());

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, mockCredential, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromSeconds(30));
            scope.Dispose();

            var producer = new AmqpProducer(eventHub, partition, identifier, scope, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            await producer.CloseAsync(CancellationToken.None);

            Assert.That(async () => await producer.ReadInitializationPublishingPropertiesAsync(CancellationToken.None),
                Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadInitializationPublishingPropertiesAsyncEnsuresPropertiesArePopulated()
        {
            var expectedProperties = new PartitionPublishingProperties(false, null, null, null);
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetInitializedPartitionProperties(producer.Object, expectedProperties))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            await producer.Object.ReadInitializationPublishingPropertiesAsync(default);
            producer.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadInitializationPublishingPropertiesAsyncReturnsPropertiesOnInitialization()
        {
            var expectedProperties = new PartitionPublishingProperties(true, 3, 17, 32768);
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetInitializedPartitionProperties(producer.Object, expectedProperties))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            var actualProperties = await producer.Object.ReadInitializationPublishingPropertiesAsync(default);
            Assert.That(actualProperties, Is.SameAs(expectedProperties), "The correct instance of the properties should have been returned.");

            producer.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadInitializationPublishingPropertiesAsyncReturnsCachedProperties()
        {
            var expectedProperties = new PartitionPublishingProperties(true, 3, 17, 32768);
            var callbackProperties = expectedProperties;
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() =>
                {
                    SetInitializedPartitionProperties(producer.Object, callbackProperties);
                    callbackProperties = new PartitionPublishingProperties(false, null, null, null);
                })
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            // The first invocation should trigger initialization and return the new value.

            var actualProperties = await producer.Object.ReadInitializationPublishingPropertiesAsync(default);
            Assert.That(actualProperties, Is.SameAs(expectedProperties), "The correct instance of the properties should have been returned for the first call.");

            // The subsequent invocations should not trigger link creation and should return the cached value.

            actualProperties = await producer.Object.ReadInitializationPublishingPropertiesAsync(default);
            Assert.That(actualProperties, Is.SameAs(expectedProperties), "The correct instance of the properties should have been returned for the second call.");

            actualProperties = await producer.Object.ReadInitializationPublishingPropertiesAsync(default);
            Assert.That(actualProperties, Is.SameAs(expectedProperties), "The correct instance of the properties should have been returned for the third call.");

            producer
                .Protected()
                .Verify<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadInitializationPublishingPropertiesAsyncRespectsTheCancellationTokenIfSetWhenCalled()
        {
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetInitializedPartitionProperties(producer.Object, new PartitionPublishingProperties(false, null, null, null)))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            Assert.That(async () => await producer.Object.ReadInitializationPublishingPropertiesAsync(cancellationTokenSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReadInitializationPublishingPropertiesAsyncAppliesTheRetryPolicy(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "customID234";
            var retriableException = new EventHubsException(true, "Test");
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                 .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.ReadInitializationPublishingPropertiesAsync(cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReadInitializationPublishingPropertiesAsyncConsidersOperationCanceledExceptionAsRetriable(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var retriableException = new OperationCanceledException();
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.ReadInitializationPublishingPropertiesAsync(cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReadInitializationPublishingPropertiesAsyncAppliesTheRetryPolicyForAmqpErrors(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "123~~";
            var retriableException = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, "dummy");
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.ReadInitializationPublishingPropertiesAsync(cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadInitializationPublishingPropertiesAsyncDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var identifier = "!!!!";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.ReadInitializationPublishingPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.ReadInitializationPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadInitializationPublishingPropertiesAsyncDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var embeddedException = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.ReadInitializationPublishingPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendEnumerableValidatesTheEvents()
        {
            var producer = new AmqpProducer("aHub", null, null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubsRetryPolicy>(), TransportProducerFeatures.None);
            Assert.That(async () => await producer.SendAsync(null, new SendEventOptions(), CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendEnumerableEnsuresNotClosed()
        {
            var producer = new AmqpProducer("aHub", null, null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubsRetryPolicy>(), TransportProducerFeatures.IdempotentPublishing);
            await producer.CloseAsync(CancellationToken.None);

            Assert.That(async () => await producer.SendAsync(Array.Empty<EventData>(), new SendEventOptions(), CancellationToken.None), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendEnumerableEnsuresConnectionNotClosed()
        {
            var endpoint = new Uri("amqps://not.real.com");
            var eventHub = "eventHubName";
            var partition = "3";
            var identifier = "testIDEntif13r";
            var options = new EventHubProducerClientOptions();
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var mockCredential = new EventHubTokenCredential(Mock.Of<TokenCredential>());

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, mockCredential, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromSeconds(30));
            var producer = new AmqpProducer(eventHub, partition, identifier, scope, Mock.Of<AmqpMessageConverter>(), retryPolicy);

            scope.Dispose();

            Assert.That(async () => await producer.SendAsync(Array.Empty<EventData>(), new SendEventOptions(), CancellationToken.None),
                Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendEnumerableUsesThePartitionKey()
        {
            var expectedPartitionKey = "some key";
            var options = new SendEventOptions { PartitionKey = expectedPartitionKey };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<IReadOnlyCollection<AmqpMessage>>(),
                    ItExpr.Is<string>(value => value == expectedPartitionKey),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            await producer.Object.SendAsync(new[] { new EventData(new byte[] { 0x15 }) }, options, CancellationToken.None);
            producer.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("someKey")]
        public async Task SendEnumerableCreatesTheAmqpMessageFromTheEnumerable(string partitionKey)
        {
            var amqpMessages = default(IReadOnlyCollection<AmqpMessage>);
            var events = new List<EventData> { new EventData(new byte[] { 0x15 }) };
            var converter = new AmqpMessageConverter();

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubsRetryPolicy>(), TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<IReadOnlyCollection<AmqpMessage>>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<IReadOnlyCollection<AmqpMessage>, string, CancellationToken>((messages, key, token) => amqpMessages = messages)
                .Returns(Task.CompletedTask);

            await producer.Object.SendAsync(events, new SendEventOptions { PartitionKey = partitionKey }, CancellationToken.None);

            Assert.That(amqpMessages, Is.Not.Null, "The AMQP messages should have been set.");
            Assert.That(amqpMessages.Count, Is.EqualTo(events.Count), "An AMQP message should exist for each source event.");

            using var batchMessage = converter.CreateBatchFromEvents(events, partitionKey);
            using var amqpSourceMessage = converter.CreateBatchFromMessages(amqpMessages, partitionKey);

            Assert.That(amqpSourceMessage.SerializedMessageSize, Is.EqualTo(batchMessage.SerializedMessageSize), "The serialized size of the messages should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendEnumerableRespectsTheCancellationTokenIfSetWhenCalled()
        {
            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var producer = new AmqpProducer("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubsRetryPolicy>());
            Assert.That(async () => await producer.SendAsync(new[] { new EventData(new byte[] { 0x15 }) }, new SendEventOptions(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendEnumerableAppliesTheRetryPolicy(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "customID3234";
            var retriableException = new EventHubsException(true, "Test");
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                 .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(new[] { new EventData(new byte[] { 0x65 }) }, new SendEventOptions(), cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendEnumerableConsidersOperationCanceledExceptionAsRetriable(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "customID3234";
            var retriableException = new OperationCanceledException();
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(new[] { new EventData(new byte[] { 0x65 }) }, new SendEventOptions(), cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendEnumerableAppliesTheRetryPolicyForAmqpErrors(EventHubsRetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var identifier = "customID3234";
            var retriableException = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, "dummy");
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(new[] { new EventData(new byte[] { 0x65 }) }, new SendEventOptions(), cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendEnumerableDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var identifier = "customID3234";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(new[] { new EventData(new byte[] { 0x65 }) }, new SendEventOptions(), cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendEnumerableDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var embeddedException = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
            var identifier = "customID3234";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(new[] { new EventData(new byte[] { 0x65 }) }, new SendEventOptions(), cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendBatchValidatesTheBatch()
        {
            var producer = new AmqpProducer("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubsRetryPolicy>());
            Assert.That(async () => await producer.SendAsync(null, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendBatchEnsuresNotClosed()
        {
            var expectedMaximumSize = 512;
            var options = new CreateBatchOptions { MaximumSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);

            await producer.Object.CloseAsync(CancellationToken.None);
            Assert.That(async () => await producer.Object.SendAsync(new EventDataBatch(batch, "ns", "eh", new SendEventOptions(), MockClientDiagnostics), CancellationToken.None), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendBatchEnsuresConnectionNotClosed()
        {
            var endpoint = new Uri("amqps://not.real.com");
            var eventHub = "eventHubName";
            var partition = "3";
            var identifier = "customID3234";
            var options = new EventHubProducerClientOptions();
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var mockCredential = new EventHubTokenCredential(Mock.Of<TokenCredential>());

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, mockCredential, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromSeconds(30));
            var producer = new AmqpProducer(eventHub, partition, identifier, scope, Mock.Of<AmqpMessageConverter>(), retryPolicy);

            scope.Dispose();

            Assert.That(async () => await producer.SendAsync(EventHubsModelFactory.EventDataBatch(2048, new List<EventData>()), CancellationToken.None),
                Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendBatchUsesThePartitionKey()
        {
            var expectedMaximumSize = 512;
            var expectedPartitionKey = "some key";
            var options = new CreateBatchOptions { PartitionKey = expectedPartitionKey };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<IReadOnlyCollection<AmqpMessage>>(),
                    ItExpr.Is<string>(value => value == expectedPartitionKey),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);
            await producer.Object.SendAsync(new EventDataBatch(batch, "ns", "eh", options, MockClientDiagnostics), CancellationToken.None);

            producer.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("someKey")]
        public async Task SendBatchCreatesTheAmqpMessageFromTheBatch(string partitionKey)
        {
            var amqpMessages = default(IReadOnlyCollection<AmqpMessage>);
            var expectedMaximumSize = 512;
            var options = new CreateBatchOptions { PartitionKey = partitionKey };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var converter = new AmqpMessageConverter();

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<IReadOnlyCollection<AmqpMessage>>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<IReadOnlyCollection<AmqpMessage>, string, CancellationToken>((messages, key, token) => amqpMessages = messages)
                .Returns(Task.CompletedTask);

            using TransportEventBatch transportBatch = await producer.Object.CreateBatchAsync(options, default);

            using var batch = new EventDataBatch(transportBatch, "ns", "eh", options, new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock"));
            batch.TryAdd(new EventData(new byte[] { 0x15 }));

            var messages = batch.AsReadOnlyCollection<AmqpMessage>();
            await producer.Object.SendAsync(batch, CancellationToken.None);

            Assert.That(amqpMessages, Is.Not.Null, "The AMQP messages should have been set.");
            Assert.That(amqpMessages.Count, Is.EqualTo(messages.Count), "An AMQP message should exist for each source event.");

            using var batchMessage = converter.CreateBatchFromMessages(messages, partitionKey);
            using var amqpSourceMessage = converter.CreateBatchFromMessages(amqpMessages, partitionKey);

            Assert.That(amqpSourceMessage.SerializedMessageSize, Is.EqualTo(batchMessage.SerializedMessageSize), "The serialized size of the messages should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendBatchDoesNotDisposeTheEventDataBatch()
        {
            var expectedMaximumSize = 512;
            var options = new CreateBatchOptions { MaximumSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<IReadOnlyCollection<AmqpMessage>>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            using TransportEventBatch transportBatch = await producer.Object.CreateBatchAsync(options, default);

            using var batch = new EventDataBatch(transportBatch, "ns", "eh", options, new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock"));
            batch.TryAdd(new EventData(new byte[] { 0x15 }));

            await producer.Object.SendAsync(batch, CancellationToken.None);

            Assert.That(batch, Is.Not.Null, "The batch should not have been set to null.");
            Assert.That(() => batch.TryAdd(new EventData(new byte[] { 0x23 })), Throws.Nothing, "The batch should not have been disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendBatchRespectsTheCancellationTokenIfSetWhenCalled()
        {
            var expectedMaximumSize = 512;
            var options = new CreateBatchOptions();
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, "fake-id", Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);
            using CancellationTokenSource cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await producer.Object.SendAsync(new EventDataBatch(batch, "ns", "eh", options, MockClientDiagnostics), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendBatchAppliesTheRetryPolicy(EventHubsRetryOptions retryOptions)
        {
            var partitionKey = "testMe";
            var identifier = "customID3234";
            var options = new CreateBatchOptions { PartitionKey = partitionKey };
            var retriableException = new EventHubsException(true, "Test");
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var batch = EventHubsModelFactory.EventDataBatch(100, new List<EventData>(), options);

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                 .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendBatchConsidersOperationCanceledExceptionAsRetriable(EventHubsRetryOptions retryOptions)
        {
            var partitionKey = "testMe";
            var identifier = "customID3234";
            var options = new CreateBatchOptions { PartitionKey = partitionKey };
            var retriableException = new OperationCanceledException();
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var batch = EventHubsModelFactory.EventDataBatch(100, new List<EventData>(), options);

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendBatchAppliesTheRetryPolicyForAmqpErrors(EventHubsRetryOptions retryOptions)
        {
            var partitionKey = "testMe";
            var identifier = "customID3234";
            var options = new CreateBatchOptions { PartitionKey = partitionKey };
            var retriableException = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, "dummy");
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var batch = EventHubsModelFactory.EventDataBatch(100, new List<EventData>(), options);

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendBatchDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var partitionKey = "testMe";
            var identifier = "customID3234";
            var options = new CreateBatchOptions { PartitionKey = partitionKey };
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var batch = EventHubsModelFactory.EventDataBatch(100, new List<EventData>(), options);

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendBatchDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var partitionKey = "testMe";
            var identifier = "customID3234";
            var options = new CreateBatchOptions { PartitionKey = partitionKey };
            var embeddedException = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var batch = EventHubsModelFactory.EventDataBatch(100, new List<EventData>(), options);

            var producer = new Mock<AmqpProducer>("aHub", null, identifier, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy, TransportProducerFeatures.None, null)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Throws(embeddedException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Once(),
                    ItExpr.Is<string>(value => value == null),
                    ItExpr.Is<string>(value => value == identifier),
                    ItExpr.IsAny<PartitionPublishingOptions>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Gets set of batch options that a <see cref="AmqpEventBatch" /> is using
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="batch">The batch to retrieve the source policy from.</param>
        ///
        /// <returns>The batch options.</returns>
        ///
        private static CreateBatchOptions GetEventBatchOptions(AmqpEventBatch batch) =>
            (CreateBatchOptions)
                typeof(AmqpEventBatch)
                    .GetField("_options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(batch);

        /// <summary>
        ///   Gets the active set of publishing options for a partition by accessing its private field.
        /// </summary>
        ///
        /// <param name="target">The producer to retrieve the options from.</param>
        ///
        /// <returns>The partition publishing options.</returns>
        ///
        private static PartitionPublishingOptions GetPartitionPublishingOptions(AmqpProducer target) =>
            (PartitionPublishingOptions)
                typeof(AmqpProducer)
                    .GetProperty("ActiveOptions", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(target);

        /// <summary>
        ///   Sets the maximum message size for the given producer, using its
        ///   private accessor.
        /// </summary>
        ///
        private static void SetMaximumMessageSize(AmqpProducer target, long value)
        {
            typeof(AmqpProducer)
                .GetProperty("MaximumMessageSize", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty)
                .SetValue(target, value);
        }

        /// <summary>
        ///   Sets the initialized partition properties for the given producer, using its
        ///   private accessor.
        /// </summary>
        ///
        private static void SetInitializedPartitionProperties(AmqpProducer target, PartitionPublishingProperties value)
        {
            typeof(AmqpProducer)
                .GetProperty("InitializedPartitionProperties", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty)
                .SetValue(target, value);
        }
    }
}
