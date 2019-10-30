// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
using Microsoft.Azure.Amqp;
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
            yield return new object[] { new RetryOptions { MaximumRetries = 3, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = RetryMode.Fixed } };
            yield return new object[] { new RetryOptions { MaximumRetries = 0, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = RetryMode.Fixed } };
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresTheEventHubName(string eventHub)
        {
            Assert.That(() => new AmqpProducer(eventHub, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheConnectionScope()
        {
            Assert.That(() => new AmqpProducer("theMostAwesomeHubEvar", "0", null, Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheRetryPolicy()
        {
            Assert.That(() => new AmqpProducer("theMostAwesomeHubEvar", null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheProducerAsClosed()
        {
            var producer = new AmqpProducer("aHub", "0", Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(producer.Closed, Is.False, "The producer should not be closed on creation");

            await producer.CloseAsync(CancellationToken.None);
            Assert.That(producer.Closed, Is.True, "The producer should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var producer = new AmqpProducer("aHub", null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>());
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await producer.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Cancellation should trigger the appropriate exception.");
            Assert.That(producer.Closed, Is.False, "Cancellation should have interrupted closing and left the producer in an open state.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncValidatesTheOptions()
        {
            var producer = new AmqpProducer("aHub", null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(async () => await producer.CreateBatchAsync(null, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncEnsuresMaximumMessageSizeIsPopulated()
        {
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, 512))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())))
                .Verifiable();

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(new BatchOptions(), default);
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
            var options = new BatchOptions { MaximumSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
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
            var options = new BatchOptions { MaximumSizeInBytes = expectedMaximumSize };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
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
            var options = new BatchOptions { MaximumSizeInBytes = 1024 };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
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
            var options = new BatchOptions { MaximumSizeInBytes = 512 };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
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
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendEnumerableValidatesTheEvents()
        {
            var producer = new AmqpProducer("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(async () => await producer.SendAsync(null, new SendOptions(), CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendEnumerableEnsuresNotClosed()
        {
            var producer = new AmqpProducer("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubRetryPolicy>());
            await producer.CloseAsync(CancellationToken.None);

            Assert.That(async () => await producer.SendAsync(Enumerable.Empty<EventData>(), new SendOptions(), CancellationToken.None), Throws.InstanceOf<EventHubsClientClosedException>());
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
            var options = new BatchOptions { PartitionKey = expectedPartitionKey };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<Func<AmqpMessage>>(),
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
        [TestCase("somekEy")]
        public async Task SendEnumerableCreatesTheAmqpMessageFromTheEnumerable(string partitonKey)
        {
            var messageFactory = default(Func<AmqpMessage>);
            var events = new[] { new EventData(new byte[] { 0x15 }) };

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubRetryPolicy>())
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<Func<AmqpMessage>>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<Func<AmqpMessage>, string, CancellationToken>((factory, key, token) => messageFactory = factory)
                .Returns(Task.CompletedTask);

            await producer.Object.SendAsync(events, new SendOptions { PartitionKey = partitonKey }, CancellationToken.None);
            Assert.That(messageFactory, Is.Not.Null, "The batch message factory should have been set.");

            using var batchMessage = new AmqpMessageConverter().CreateBatchFromEvents(events, partitonKey);
            using var factoryMessage = messageFactory();

            Assert.That(factoryMessage.SerializedMessageSize, Is.EqualTo(batchMessage.SerializedMessageSize), "The serialized size of the messages should match.");
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

            var producer = new AmqpProducer("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(async () => await producer.SendAsync(new[] { new EventData(new byte[] { 0x15 }) }, new SendOptions(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendEnumerableRespectsTheRetryPolicy(RetryOptions retryOptions)
        {
            var partitionId = "testMe";
            var retriableException = new EventHubsException(true, "Test");
            var retryPolicy = new BasicRetryPolicy(retryOptions);

            var producer = new Mock<AmqpProducer>("aHub", partitionId, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                 .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(new[] { new EventData(new byte[] { 0x65 }) }, new SendOptions(), cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == partitionId),
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
            var producer = new AmqpProducer("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), Mock.Of<EventHubRetryPolicy>());
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
            var options = new BatchOptions { MaximumSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);

            await producer.Object.CloseAsync(CancellationToken.None);
            Assert.That(async () => await producer.Object.SendAsync(new EventDataBatch(batch, new SendOptions()), CancellationToken.None), Throws.InstanceOf<EventHubsClientClosedException>());
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
            var options = new BatchOptions { PartitionKey = expectedPartitionKey };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<Func<AmqpMessage>>(),
                    ItExpr.Is<string>(value => value == expectedPartitionKey),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask)
                .Verifiable();

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);
            await producer.Object.SendAsync(new EventDataBatch(batch, options), CancellationToken.None);

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
        [TestCase("somekEy")]
        public async Task SendBatchCreatesTheAmqpMessageFromTheBatch(string partitonKey)
        {
            var messageFactory = default(Func<AmqpMessage>);
            var expectedMaximumSize = 512;
            var options = new BatchOptions { PartitionKey = partitonKey };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<Func<AmqpMessage>>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback<Func<AmqpMessage>, string, CancellationToken>((factory, key, token) => messageFactory = factory)
                .Returns(Task.CompletedTask);

            using TransportEventBatch transportBatch = await producer.Object.CreateBatchAsync(options, default);

            using var batch = new EventDataBatch(transportBatch, options);
            batch.TryAdd(new EventData(new byte[] { 0x15 }));

            await producer.Object.SendAsync(batch, CancellationToken.None);
            Assert.That(messageFactory, Is.Not.Null, "The batch message factory should have been set.");

            using var batchMessage = new AmqpMessageConverter().CreateBatchFromMessages(batch.AsEnumerable<AmqpMessage>(), partitonKey);
            using var factoryMessage = messageFactory();

            Assert.That(factoryMessage.SerializedMessageSize, Is.EqualTo(batchMessage.SerializedMessageSize), "The serialized size of the messages should match.");
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
            var options = new BatchOptions { MaximumSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<Func<AmqpMessage>>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            using TransportEventBatch transportBatch = await producer.Object.CreateBatchAsync(options, default);

            using var batch = new EventDataBatch(transportBatch, options);
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
        public async Task SendBatchDoesNotDisposeTheEventsInTheSourceBatch()
        {
            var expectedMaximumSize = 512;
            var options = new BatchOptions { MaximumSizeInBytes = null };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            producer
                .Protected()
                .Setup<Task>("SendAsync",
                    ItExpr.IsAny<Func<AmqpMessage>>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.CompletedTask);

            using TransportEventBatch transportBatch = await producer.Object.CreateBatchAsync(options, default);

            using var batch = new EventDataBatch(transportBatch, options);
            batch.TryAdd(new EventData(new byte[] { 0x15 }));

            await producer.Object.SendAsync(batch, CancellationToken.None);

            Assert.That(batch, Is.Not.Null, "The batch should not have been set to null.");
            Assert.That(() => batch.AsEnumerable<AmqpMessage>().Single().ThrowIfDisposed(), Throws.Nothing, "The events within the source batch should not have been disposed.");
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
            var options = new BatchOptions();
            var retryPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                .Callback(() => SetMaximumMessageSize(producer.Object, expectedMaximumSize))
                .Returns(Task.FromResult(new SendingAmqpLink(new AmqpLinkSettings())));

            using TransportEventBatch batch = await producer.Object.CreateBatchAsync(options, default);
            using CancellationTokenSource cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await producer.Object.SendAsync(new EventDataBatch(batch, options), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void SendBatchRespectsTheRetryPolicy(RetryOptions retryOptions)
        {
            var partitionKey = "testMe";
            var options = new BatchOptions { PartitionKey = partitionKey };
            var retriableException = new EventHubsException(true, "Test");
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var batch = new EventDataBatch(Mock.Of<TransportEventBatch>(), options);

            var producer = new Mock<AmqpProducer>("aHub", null, Mock.Of<AmqpConnectionScope>(), new AmqpMessageConverter(), retryPolicy)
            {
                CallBase = true
            };

            producer
                .Protected()
                .Setup<Task<SendingAmqpLink>>("CreateLinkAndEnsureProducerStateAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<TimeSpan>(),
                    ItExpr.IsAny<CancellationToken>())
                 .Throws(retriableException);

            using CancellationTokenSource cancellationSource = new CancellationTokenSource();
            Assert.That(async () => await producer.Object.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            producer
                .Protected()
                .Verify("CreateLinkAndEnsureProducerStateAsync", Times.Exactly(1 + retryOptions.MaximumRetries),
                    ItExpr.Is<string>(value => value == null),
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
        private static BatchOptions GetEventBatchOptions(AmqpEventBatch batch) =>
            (BatchOptions)
                typeof(AmqpEventBatch)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(batch);

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
    }
}
