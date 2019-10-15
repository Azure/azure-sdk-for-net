// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Metadata;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpEventHubConsumer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpEventHubConsumerTests
    {
        /// <summary>
        ///   The set of test cases for respecting basic retry configuration.
        /// </summary>
        ///
        public static IEnumerable<object[]> RetryOptionTestCases()
        {
            yield return new object[] { new RetryOptions { MaximumRetries = 3, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = RetryMode.Fixed }};
            yield return new object[] { new RetryOptions { MaximumRetries = 0, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = RetryMode.Fixed }};
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
            Assert.That(() => new AmqpEventHubConsumer(eventHub, "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new AmqpEventHubConsumer("myHub", group, "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), new LastEnqueuedEventProperties("hub", "0")), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new AmqpEventHubConsumer("aHub", "$DEFAULT", partition, EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheEventPosition()
        {
            Assert.That(() => new AmqpEventHubConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", null, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            Assert.That(() => new AmqpEventHubConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", EventPosition.FromOffset(1), null, Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), new LastEnqueuedEventProperties("hub", "0")), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheConnectionScope()
        {
            Assert.That(() => new AmqpEventHubConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", EventPosition.FromSequenceNumber(123), new EventHubConsumerOptions(), null, Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheRetryPolicy()
        {
            Assert.That(() => new AmqpEventHubConsumer("theMostAwesomeHubEvar", "$DEFAULT", "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), null, new LastEnqueuedEventProperties("hub", "0")), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheConsumerAsClosed()
        {
            var consumer = new AmqpEventHubConsumer("aHub", "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null);
            Assert.That(consumer.Closed, Is.False, "The consumer should not be closed on creation");

            await consumer.CloseAsync(CancellationToken.None);
            Assert.That(consumer.Closed, Is.True, "The consumer should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var consumer = new AmqpEventHubConsumer("aHub", "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null);
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await consumer.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Cancellation should trigger the appropriate exception.");
            Assert.That(consumer.Closed, Is.False, "Cancellation should have interrupted closing and left the consumer in an open state.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateRetryPolicyValidatesTheRetryPolicy()
        {
            var consumer = new AmqpEventHubConsumer("aHub", "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null);
            Assert.That(() => consumer.UpdateRetryPolicy(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateRetryPolicyUpdatesTheRetryPolicy()
        {
            var newPolicy = new BasicRetryPolicy(new RetryOptions { Delay = TimeSpan.FromMilliseconds(50) });
            var consumer = new AmqpEventHubConsumer("aHub", "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), Mock.Of<EventHubRetryPolicy>(), null);

            Assert.That(GetActiveRetryPolicy(consumer), Is.Not.SameAs(newPolicy), "The initial policy should be a unique instance");

            consumer.UpdateRetryPolicy(newPolicy);
            Assert.That(GetActiveRetryPolicy(consumer), Is.SameAs(newPolicy), "The updated policy should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateRetryPolicyUpdatesTheOperationTimeout()
        {
            var initialPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            var initialTimeout = initialPolicy.CalculateTryTimeout(0);
            var consumer = new AmqpEventHubConsumer("aHub", "$DEFAULT", "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<AmqpConnectionScope>(), Mock.Of<AmqpMessageConverter>(), initialPolicy, null);

            Assert.That(GetTimeout(consumer), Is.EqualTo(initialTimeout), "The initial timeout should match");

            var newPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromMilliseconds(50) });
            TimeSpan newTimeout = newPolicy.CalculateTryTimeout(0);

            consumer.UpdateRetryPolicy(newPolicy);
            Assert.That(GetTimeout(consumer), Is.EqualTo(newTimeout), "The updated timeout should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.ReceiveAsync" />
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
            var options = new EventHubConsumerOptions { Identifier = "OMG!" };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            var consumer = new AmqpEventHubConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy, null);
            Assert.That(async () => await consumer.ReceiveAsync(count, null, cancellationSource.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.ReceiveAsync" />
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
            var options = new EventHubConsumerOptions { Identifier = "OMG!" };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var consumer = new AmqpEventHubConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy, null);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.ReceiveAsync" />
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
            var options = new EventHubConsumerOptions { Identifier = "OMG!" };
            var retryPolicy = new BasicRetryPolicy(new RetryOptions());
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            var consumer = new AmqpEventHubConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy, null);
            await consumer.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf<EventHubsObjectClosedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubConsumer.ReceiveAsync" />
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
            var options = new EventHubConsumerOptions { Identifier = "OMG!" };
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(Task.FromResult(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

             mockScope
                .Setup(scope => scope.OpenConsumerLinkAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubConsumerOptions>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()))
                .Throws(retriableException);

            var consumer = new AmqpEventHubConsumer(eventHub, consumerGroup, partition, eventPosition, options, mockScope.Object, Mock.Of<AmqpMessageConverter>(), retryPolicy, null);
            Assert.That(async () => await consumer.ReceiveAsync(100, null, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope
                .Verify(scope => scope.OpenConsumerLinkAsync(
                    It.Is<string>(value => value == consumerGroup),
                    It.Is<string>(value => value == partition),
                    It.Is<EventPosition>(value => value == eventPosition),
                    It.Is<EventHubConsumerOptions>(value => value == options),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Gets the active retry policy for the given client, using the
        ///   private field.
        /// </summary>
        ///
        private static EventHubRetryPolicy GetActiveRetryPolicy(AmqpEventHubConsumer target) =>
            (EventHubRetryPolicy)
                typeof(AmqpEventHubConsumer)
                    .GetField("_retryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(target);

        /// <summary>
        ///   Gets the active operation timeout for the given client, using the
        ///   private field.
        /// </summary>
        ///
        private static TimeSpan GetTimeout(AmqpEventHubConsumer target) =>
            (TimeSpan)
                typeof(AmqpEventHubConsumer)
                    .GetField("_tryTimeout", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(target);
    }
}
