// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
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
            Assert.That(() => new AmqpConsumer(eventHub, "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerClientOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new AmqpConsumer("myHub", group, "0", EventPosition.Earliest, new EventHubConsumerClientOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new AmqpConsumer("aHub", "$DEFAULT", partition, EventPosition.Earliest, new EventHubConsumerClientOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheEventPosition()
        {
            Assert.That(() => new AmqpConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", null, new EventHubConsumerClientOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            Assert.That(() => new AmqpConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", EventPosition.FromOffset(1), null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheConnectionScope()
        {
            Assert.That(() => new AmqpConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", EventPosition.FromSequenceNumber(123), new EventHubConsumerClientOptions(), null, Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheRetryPolicy()
        {
            Assert.That(() => new AmqpConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", EventPosition.Latest, new EventHubConsumerClientOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheConsumerAsClosed()
        {
            var consumer = new AmqpConsumer("aHub", "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerClientOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(consumer.Closed, Is.False, "The consumer should not be closed on creation");

            await consumer.CloseAsync(CancellationToken.None);
            Assert.That(consumer.Closed, Is.True, "The consumer should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpConsumer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var consumer = new AmqpConsumer("aHub", "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerClientOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>());
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await consumer.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Cancellation should trigger the appropriate exception.");
            Assert.That(consumer.Closed, Is.False, "Cancellation should have interrupted closing and left the consumer in an open state.");
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
            var eventPosition = EventPosition.FromOffset(123);
            var options = new EventHubConsumerClientOptions { Identifier = "OMG!" };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
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
            var eventPosition = EventPosition.FromOffset(123);
            var options = new EventHubConsumerClientOptions { Identifier = "OMG!" };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
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
        public void ReceiveAsyncRespectsTheRetryPolicy(RetryOptions retryOptions)
        {
            var eventHub = "eventHubName";
            var consumerGroup = "$DEFAULT";
            var partition = "3";
            var eventPosition = EventPosition.FromOffset(123);
            var options = new EventHubConsumerClientOptions { Identifier = "OMG!" };
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
                   It.IsAny<EventHubConsumerClientOptions>(),
                   It.IsAny<TimeSpan>(),
                   It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope
                .Verify(scope => scope.OpenConsumerLinkAsync(
                    It.Is<string>(value => value == consumerGroup),
                    It.Is<string>(value => value == partition),
                    It.Is<EventPosition>(value => value == eventPosition),
                    It.Is<EventHubConsumerClientOptions>(value => value == options),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
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
            var eventPosition = EventPosition.FromOffset(123);
            var options = new EventHubConsumerClientOptions { Identifier = "OMG!" };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            var consumer = new AmqpConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy);
            await consumer.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf<EventHubsClientClosedException>());
        }
    }
}
