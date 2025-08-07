// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpConsumer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpConsumerTests
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
        ///   The set of test cases for general case exceptions.
        /// </summary>
        ///
        public static IEnumerable<object[]> GeneralExceptionTestCases()
        {
           yield return new object[] { new Exception() };
           yield return new object[] { new DivideByZeroException() };
           yield return new object[] { new OutOfMemoryException() };
           yield return new object[] { new EventHubsException("test", "fake", EventHubsException.FailureReason.ClientClosed) };
           yield return new object[] { new EventHubsException(true, "test", "fake", EventHubsException.FailureReason.ServiceBusy) };
           yield return new object[] { new EventHubsException(false, "test", "fake", EventHubsException.FailureReason.GeneralError) };
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
            Assert.That(() => new AmqpConsumer(eventHub, "$DEFAULT", "0", null, EventPosition.Earliest, true, false, null, null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresTheConsumerGroup(string group)
        {
            Assert.That(() => new AmqpConsumer("myHub", group, "0", "", EventPosition.Earliest, true, false, null, null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresThePartition(string partition)
        {
            Assert.That(() => new AmqpConsumer("aHub", "$DEFAULT", partition, "te5t-z", EventPosition.Earliest, true, false, null, null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheConnectionScope()
        {
            Assert.That(() => new AmqpConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", null, EventPosition.FromSequenceNumber(123), true, false, null, null, null, null, Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheMessageConverter()
        {
            Assert.That(() => new AmqpConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", "", EventPosition.FromSequenceNumber(123), true, false, null, null, null, Mock.Of<AmqpConnectionScope>(), null, Mock.Of<EventHubsRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheRetryPolicy()
        {
            Assert.That(() => new AmqpConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", "fake", EventPosition.Latest, true, false, null, null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheConsumerAsClosed()
        {
            var consumer = new AmqpConsumer("aHub", "$DEFAULT", "0", "dummy", EventPosition.Earliest, true, false, null, null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>());
            Assert.That(consumer.IsClosed, Is.False, "The consumer should not be closed on creation");

            await consumer.CloseAsync(CancellationToken.None);
            Assert.That(consumer.IsClosed, Is.True, "The consumer should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var consumer = new AmqpConsumer("aHub", "$DEFAULT", "0", null, EventPosition.Earliest, true, false, null, null, null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubsRetryPolicy>());
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await consumer.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Cancellation should trigger the appropriate exception.");
            Assert.That(consumer.IsClosed, Is.False, "Cancellation should have interrupted closing and left the consumer in an open state.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(-32768)]
        [TestCase(-1)]
        [TestCase(0)]
        public void ReceiveAsyncValidatesTheMaximumMessageCount(int count)
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, true, true, null, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(count, null, cancellationSource.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncRespectsTheCancellationTokenIfSetWhenCalled()
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, true, true, null, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReceiveAsyncAppliesTheRetryPolicy(EventHubsRetryOptions retryOptions)
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var trackLastEnqueued = false;
            var invalidateOnSteal = true;
            var ownerLevel = 123L;
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenConsumerLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<EventPosition>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<long?>(),
                   It.IsAny<long?>(),
                   It.IsAny<bool>(),
                   It.IsAny<string>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, trackLastEnqueued, invalidateOnSteal, ownerLevel, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope
                .Verify(scope => scope.OpenConsumerLinkAsync(
                    It.Is<string>(value => value == consumerGroup),
                    It.Is<string>(value => value == partition),
                    It.Is<EventPosition>(value => value == eventPosition),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<long?>(),
                    It.Is<long?>(value => value == ownerLevel),
                    It.Is<bool>(value => value == trackLastEnqueued),
                    It.Is<string>(value => value == identifier),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReceiveAsyncConsidersOperationCanceledExceptionAsRetriable(EventHubsRetryOptions retryOptions)
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var trackLastEnqueued = false;
            var invalidateOnSteal = true;
            var ownerLevel = 123L;
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new OperationCanceledException();
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenConsumerLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<EventPosition>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<long?>(),
                   It.IsAny<long?>(),
                   It.IsAny<bool>(),
                   It.IsAny<string>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, trackLastEnqueued, invalidateOnSteal, ownerLevel, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope
                .Verify(scope => scope.OpenConsumerLinkAsync(
                    It.Is<string>(value => value == consumerGroup),
                    It.Is<string>(value => value == partition),
                    It.Is<EventPosition>(value => value == eventPosition),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<long?>(),
                    It.Is<long?>(value => value == ownerLevel),
                    It.Is<bool>(value => value == trackLastEnqueued),
                    It.Is<string>(value => value == identifier),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void ReceiveAsyncAppliesTheRetryPolicyForAmqpErrors(EventHubsRetryOptions retryOptions)
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var trackLastEnqueued = false;
            var invalidateOnSteal = true;
            var ownerLevel = 123L;
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, "dummy");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenConsumerLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<EventPosition>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<long?>(),
                   It.IsAny<long?>(),
                   It.IsAny<bool>(),
                   It.IsAny<string>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, trackLastEnqueued, invalidateOnSteal, ownerLevel, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope
                .Verify(scope => scope.OpenConsumerLinkAsync(
                    It.Is<string>(value => value == consumerGroup),
                    It.Is<string>(value => value == partition),
                    It.Is<EventPosition>(value => value == eventPosition),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<long?>(),
                    It.Is<long?>(value => value == ownerLevel),
                    It.Is<bool>(value => value == trackLastEnqueued),
                    It.Is<string>(value => value == identifier),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var trackLastEnqueued = false;
            var invalidateOnSteal = true;
            var ownerLevel = 123L;
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenConsumerLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<EventPosition>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<long?>(),
                   It.IsAny<long?>(),
                   It.IsAny<bool>(),
                   It.IsAny<string>(),
                   It.IsAny<CancellationToken>()))
               .Throws(embeddedException);

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, trackLastEnqueued, invalidateOnSteal, ownerLevel, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            mockScope
                .Verify(scope => scope.OpenConsumerLinkAsync(
                    It.Is<string>(value => value == consumerGroup),
                    It.Is<string>(value => value == partition),
                    It.Is<EventPosition>(value => value == eventPosition),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<long?>(),
                    It.Is<long?>(value => value == ownerLevel),
                    It.Is<bool>(value => value == trackLastEnqueued),
                    It.Is<string>(value => value == identifier),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var trackLastEnqueued = false;
            var invalidateOnSteal = true;
            var ownerLevel = 123L;
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var embeddedException = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockScope
               .Setup(scope => scope.OpenConsumerLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<EventPosition>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<long?>(),
                   It.IsAny<long?>(),
                   It.IsAny<bool>(),
                   It.IsAny<string>(),
                   It.IsAny<CancellationToken>()))
               .Throws(embeddedException);

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, trackLastEnqueued, invalidateOnSteal, ownerLevel, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            mockScope
                .Verify(scope => scope.OpenConsumerLinkAsync(
                    It.Is<string>(value => value == consumerGroup),
                    It.Is<string>(value => value == partition),
                    It.Is<EventPosition>(value => value == eventPosition),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<uint>(),
                    It.IsAny<long?>(),
                    It.Is<long?>(value => value == ownerLevel),
                    It.Is<bool>(value => value == trackLastEnqueued),
                    It.Is<string>(value => value == identifier),
                    It.IsAny<CancellationToken>()),
                Times.Once());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncValidatesClosed()
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var options = new EventHubConsumerClientOptions();
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, true, false, null, null, null, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            await consumer.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveAsyncValidatesConnectionClosed()
        {
            var endpoint = new Uri("amqps://not.real.com");
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var identifier = "cusTOM-1D";
            var eventPosition = EventPosition.FromOffset("123");
            var options = new EventHubConsumerClientOptions();
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var mockCredential = new EventHubTokenCredential(Mock.Of<TokenCredential>());

            var scope = new AmqpConnectionScope(endpoint, endpoint, eventHub, mockCredential, EventHubsTransportType.AmqpTcp, null, TimeSpan.FromSeconds(30));
            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, identifier, eventPosition, true, false, null, null, null, scope, Mock.Of<AmqpMessageConverter>(), retryPolicy);

            scope.Dispose();

            Assert.That(async () => await consumer.ReceiveAsync(100, null, CancellationToken.None),
                Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.CloseConsumerLink "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseConsumerLinkDetectsAStolenPartition()
        {
            var eventHub = "fake-hub";
            var terminalException = new AmqpException(new Error { Condition = AmqpErrorCode.Stolen });
            var link = new ReceivingAmqpLink(new AmqpLinkSettings());
            var mockConsumer = new MockAmqpConsumer(eventHub, true, terminalException);

            try
            {
                mockConsumer.InvokeCloseConsumerLink(link);
                Assert.That(GetActivePartitionStolenException(mockConsumer), Is.SameAs(terminalException));
            }
            finally
            {
                link?.SafeClose();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.CloseConsumerLink "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(GeneralExceptionTestCases))]
        public void CloseConsumerLinkIgnoresGeneralExceptions(Exception terminalException)
        {
            var eventHub = "fake-hub";
            var link = new ReceivingAmqpLink(new AmqpLinkSettings());
            var mockConsumer = new MockAmqpConsumer(eventHub, true, terminalException);

            try
            {
                mockConsumer.InvokeCloseConsumerLink(link);
                Assert.That(GetActivePartitionStolenException(mockConsumer), Is.Null);
            }
            finally
            {
                link?.SafeClose();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.OpenConsumerLink "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task OpenConsumerLinkSurfacesAStolenPartition()
        {
            var eventHub = "fake-hub";
            var terminalException = new EventHubsException(eventHub, "Expected", EventHubsException.FailureReason.ConsumerDisconnected);
            var capturedException = default(Exception);
            var mockConsumer = new MockAmqpConsumer(eventHub, true, terminalException);

            SetActivePartitionStolenException(mockConsumer, terminalException);

            try
            {
                await mockConsumer.InvokeCreateConsumerLinkAsync("cg", "0", "", EventPosition.Earliest, 300, null, 34, true, TimeSpan.FromSeconds(30), CancellationToken.None);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been surfaced.");
            Assert.That(capturedException.GetType(), Is.EqualTo(terminalException.GetType()), "The captured exception was not of the expected type.");
            Assert.That(capturedException, Is.SameAs(terminalException), "The mocked terminal exception should have been surfaced.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.OpenConsumerLink "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncSurfacesStolenPartitionWhenInvalidated()
        {
            var eventHub = "fake-hub";
            var terminalException = new AmqpException(AmqpErrorCode.Stolen, "This is a terminal exception message.");
            var expectedException = terminalException.TranslateServiceException(eventHub);
            var capturedException = default(Exception);
            var mockConsumer = new MockAmqpConsumer(eventHub, true, terminalException);

            SetActivePartitionStolenException(mockConsumer, terminalException);

            try
            {
                await mockConsumer.ReceiveAsync(10, TimeSpan.FromSeconds(1), CancellationToken.None);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been surfaced.");
            Assert.That(capturedException.GetType(), Is.EqualTo(expectedException.GetType()), "The captured exception was not of the expected type.");
            Assert.That(capturedException.Message, Is.EqualTo(expectedException.Message), "The mocked terminal exception should have been surfaced.");

            // Because the terminal exception was injected, it should not attempt to open the actual link.

            mockConsumer.MockConnectionScope
               .Verify(scope => scope.OpenConsumerLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<EventPosition>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<long?>(),
                   It.IsAny<long?>(),
                   It.IsAny<bool>(),
                   It.IsAny<string>(),
                   It.IsAny<CancellationToken>()),
               Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.OpenConsumerLink "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenConsumerLinkClearsTheStolenExceptionWhenInvalidateIsNotSet()
        {
            var eventHub = "fake-hub";
            var terminalException = new AmqpException(new Error { Condition = AmqpErrorCode.Stolen });
            var mockConsumer = new MockAmqpConsumer(eventHub, false, terminalException);

            SetActivePartitionStolenException(mockConsumer, terminalException);
            Assert.That(async () => await mockConsumer.InvokeCreateConsumerLinkAsync("cg", "0", null, EventPosition.Earliest, 300, null, 34, true, TimeSpan.FromSeconds(30), CancellationToken.None), Throws.InstanceOf(terminalException.GetType()), "The exception should have been surfaced on the first call.");
            Assert.That(async () => await mockConsumer.InvokeCreateConsumerLinkAsync("cg", "0", "", EventPosition.Earliest, 300, null, 34, true, TimeSpan.FromSeconds(30), CancellationToken.None), Throws.Nothing, "The second call should not throw.");
            Assert.That(async () => await mockConsumer.InvokeCreateConsumerLinkAsync("cg", "0", "fake-id", EventPosition.Earliest, 300, null, 34, true, TimeSpan.FromSeconds(30), CancellationToken.None), Throws.Nothing, "The third call should not throw.");

            var capturedException = GetActivePartitionStolenException(mockConsumer);
            Assert.That(capturedException, Is.Null, "The active exception should have been cleared after it was surfaced.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.OpenConsumerLink "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OpenConsumerLinkPreservesTheStolenExceptionWhenInvalidateIsSet()
        {
            var eventHub = "fake-hub";
            var terminalException = new EventHubsException(eventHub, "Expected", EventHubsException.FailureReason.ConsumerDisconnected);
            var mockConsumer = new MockAmqpConsumer(eventHub, true, terminalException);

            SetActivePartitionStolenException(mockConsumer, terminalException);
            Assert.That(async () => await mockConsumer.InvokeCreateConsumerLinkAsync("cg", "0", "fake-id", EventPosition.Earliest, 300, null, 34, true, TimeSpan.FromSeconds(30), CancellationToken.None), Throws.InstanceOf(terminalException.GetType()), "The exception should have been surfaced on the first call.");
            Assert.That(async () => await mockConsumer.InvokeCreateConsumerLinkAsync("cg", "0", "", EventPosition.Earliest, 300, null, 34, true, TimeSpan.FromSeconds(30), CancellationToken.None), Throws.InstanceOf(terminalException.GetType()), "The exception should have been surfaced on the second call.");
            Assert.That(async () => await mockConsumer.InvokeCreateConsumerLinkAsync("cg", "0", null, EventPosition.Earliest, 300, null, 34, true, TimeSpan.FromSeconds(30), CancellationToken.None), Throws.InstanceOf(terminalException.GetType()), "The exception should have been surfaced on the third call.");

            var capturedException = GetActivePartitionStolenException(mockConsumer);
            Assert.That(capturedException, Is.SameAs(terminalException), "The active exception should have been preserved after the calls were completed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.OpenConsumerLink "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncDetectsAndCapturesAStolenPartition()
        {
            var eventHub = "fake-hub";
            var terminalException = new AmqpException(AmqpErrorCode.Stolen, "This is a terminal exception message.");
            var expectedException = terminalException.TranslateServiceException(eventHub);
            var capturedException = default(Exception);
            var mockConsumer = new MockAmqpConsumer(eventHub, true, terminalException);

            mockConsumer.MockConnectionScope
               .Setup(scope => scope.OpenConsumerLinkAsync(
                   It.IsAny<string>(),
                   It.IsAny<string>(),
                   It.IsAny<EventPosition>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<uint>(),
                   It.IsAny<long?>(),
                   It.IsAny<long?>(),
                   It.IsAny<bool>(),
                   It.IsAny<string>(),
                   It.IsAny<CancellationToken>()))
               .Throws(terminalException);

            try
            {
                await mockConsumer.ReceiveAsync(10, TimeSpan.FromSeconds(1), CancellationToken.None);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.Not.Null, "An exception should have been surfaced.");
            Assert.That(capturedException.GetType(), Is.EqualTo(expectedException.GetType()), "The captured exception was not of the expected type.");
            Assert.That(capturedException.Message, Is.EqualTo(expectedException.Message), "The mocked terminal exception should have been surfaced.");

            var preservedException = GetActivePartitionStolenException(mockConsumer);
            Assert.That(preservedException, Is.SameAs(terminalException), "The preserved exception should match the terminal exception.");
        }

        /// <summary>
        ///   Gets the active partition stolen exception for a consumer, using its
        ///   private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the exception from.</param>
        ///
        /// <returns>The active partition stolen exception of the <paramref name="consumer"/>, if present; otherwise, <c>null</c>.</returns>
        ///
        private Exception GetActivePartitionStolenException(AmqpConsumer consumer) =>
            (Exception)
                typeof(AmqpConsumer)
                    .GetField("_activePartitionStolenException", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Sets the active partition stolen exception for a consumer, using its
        ///   private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the exception from.</param>
        /// <param name="exception">The exception to set.</param>
        ///
        private void SetActivePartitionStolenException(AmqpConsumer consumer,
                                                       Exception exception) =>
            typeof(AmqpConsumer)
                .GetField("_activePartitionStolenException", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(consumer, exception);

        /// <summary>
        ///   A class that an be used for testing members of the consumer
        ///   that are not part of the public API surface.
        /// </summary>
        ///
        private class MockAmqpConsumer : AmqpConsumer
        {
            public Mock<AmqpConnectionScope> MockConnectionScope;
            public Exception TransformedTerminalException;

            public MockAmqpConsumer(string eventHubName,
                                    bool invalidateConsumerWhenPartitionIsStolen) : this(eventHubName, invalidateConsumerWhenPartitionIsStolen, new(), null)
            {
            }

            public MockAmqpConsumer(string eventHubName,
                                    bool invalidateConsumerWhenPartitionIsStolen,
                                    Exception transformedTerminalException) : this(eventHubName, invalidateConsumerWhenPartitionIsStolen, new(), transformedTerminalException)
            {
            }

            public MockAmqpConsumer(string eventHubName,
                                    bool invalidateConsumerWhenPartitionIsStolen,
                                    Mock<AmqpConnectionScope> mockConnectionScope,
                                    Exception transformedTerminalException) : base(eventHubName, "fake", "0", "mock-1", EventPosition.Earliest, true, invalidateConsumerWhenPartitionIsStolen, null, null, null, mockConnectionScope.Object, new(), new BasicRetryPolicy(new()))
            {
                MockConnectionScope = mockConnectionScope;
                TransformedTerminalException = transformedTerminalException;
            }

            public Task<ReceivingAmqpLink> InvokeCreateConsumerLinkAsync(string consumerGroup,
                                                                         string partitionId,
                                                                         string consumerIdentifier,
                                                                         EventPosition eventStartingPosition,
                                                                         uint prefetchCount,
                                                                         long? prefetchSizeInBytes,
                                                                         long? ownerLevel,
                                                                         bool trackLastEnqueuedEventProperties,
                                                                         TimeSpan timeout,
                                                                         CancellationToken cancellationToken) => CreateConsumerLinkAsync(consumerGroup, partitionId, consumerIdentifier, eventStartingPosition, prefetchCount, prefetchSizeInBytes, ownerLevel, trackLastEnqueuedEventProperties, timeout, cancellationToken);

            public void InvokeCloseConsumerLink(ReceivingAmqpLink link) => CloseConsumerLink(link);

            protected override Exception GetTerminalException(ReceivingAmqpLink link) => TransformedTerminalException;
        }
    }
}
