﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Microsoft.Azure.Amqp;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpEventHubClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpEventHubClientTests
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
        public void ConstructorRequiresTheHost(string host)
        {
            Assert.That(() => new AmqpEventHubClient(host, "test-path", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new AmqpEventHubClient("my.eventhub.com", path, Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheCredential()
        {
            Assert.That(() => new AmqpEventHubClient("my.eventhub.com", "somePath", null, new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            Assert.That(() => new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), null, Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheDefaultRetryPolicy()
        {
            Assert.That(() => new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheClientAsClosed()
        {
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(client.Closed, Is.False, "The client should not be closed on creation");

            await client.CloseAsync(CancellationToken.None);
            Assert.That(client.Closed, Is.True, "The client should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await client.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.Dispose"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeClosesTheClient()
        {
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(client.Closed, Is.False, "The client should not be closed on creation");

            await client.DisposeAsync();
            Assert.That(client.Closed, Is.True, "The client should be closed after disposal");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateRetryPolicyValidatesTheRetryPolicy()
        {
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(() => client.UpdateRetryPolicy(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateRetryPolicyUpdatesTheRetryPolicy()
        {
            var newPolicy = new BasicRetryPolicy(new RetryOptions { Delay = TimeSpan.FromMilliseconds(50) });
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(GetActiveRetryPolicy(client), Is.Not.SameAs(newPolicy), "The initial policy should be a unique instance");

            client.UpdateRetryPolicy(newPolicy);
            Assert.That(GetActiveRetryPolicy(client), Is.SameAs(newPolicy), "The updated policy should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void UpdateRetryPolicyUpdatesTheOperationTimeout()
        {
            var initialPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromSeconds(17) });
            TimeSpan initialTimeout = initialPolicy.CalculateTryTimeout(0);
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), initialPolicy);

            Assert.That(GetTimeout(client), Is.EqualTo(initialTimeout), "The initial timeout should match");

            var newPolicy = new BasicRetryPolicy(new RetryOptions { TryTimeout = TimeSpan.FromMilliseconds(50) });
            TimeSpan newTimeout = newPolicy.CalculateTryTimeout(0);

            client.UpdateRetryPolicy(newPolicy);
            Assert.That(GetTimeout(client), Is.EqualTo(newTimeout), "The updated timeout should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPropertiesAsyncRespectsTheCancellationTokenIfSetWhenCalled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(async () => await client.GetPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPropertiesAsyncRespectsClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await client.GetPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPropertiesAsyncCreatesTheRequest()
        {
            var eventHubName = "myName";
            var tokenValue = "123ABC";
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(Task.FromResult(new AccessToken(tokenValue, DateTimeOffset.MaxValue)))
                .Verifiable();

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage))
                .Callback(() => cancellationSource.Cancel())
                .Verifiable();

            // Because the AMQP library is not friendly to mocking, only the path up to conversion can be tested without external
            // dependencies.  To ensure that execution stops after that point, the converter triggers cancellation that should take
            // place immediately following the conversion and result in a well-known exception.

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>(), null, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

            mockCredential.VerifyAll();
            mockConverter.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void GetPropertiesAsyncRespectsTheRetryPolicy(RetryOptions retryOptions)
        {
            var eventHubName = "myName";
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

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubClientOptions(), retryPolicy, mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void GetPartitionPropertiesAsyncValidatesThePartition(string partition)
        {
            ExactTypeConstraint typeConstraint = partition is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partition, CancellationToken.None), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncRespectsTheCancellationTokenIfSetWhenCalled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(async () => await client.GetPartitionPropertiesAsync("Fred", cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesAsyncValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await client.GetPartitionPropertiesAsync("Fred", cancellationSource.Token), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncCreatesTheRequest()
        {
            var eventHubName = "myName";
            var partitionId = "Barney";
            var tokenValue = "123ABC";
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<TokenCredential>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(Task.FromResult(new AccessToken(tokenValue, DateTimeOffset.MaxValue)))
                .Verifiable();

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage))
                .Callback(() => cancellationSource.Cancel())
                .Verifiable();

            // Because the AMQP library is not friendly to mocking, only the path up to conversion can be tested without external
            // dependencies.  To ensure that execution stops after that point, the converter triggers cancellation that should take
            // place immediately following the conversion and result in a well-known exception.

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubClientOptions(), Mock.Of<EventHubRetryPolicy>(), null, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

            mockCredential.VerifyAll();
            mockConverter.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void GetPartitionPropertiesAsyncRespectsTheRetryPolicy(RetryOptions retryOptions)
        {
            var eventHubName = "myName";
            var partitionId = "Barney";
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

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
               .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubClientOptions(), retryPolicy, mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.CreateConsumer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateConsumerValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var mockRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), mockRetryPolicy);
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(() => client.CreateConsumer("group", "0", EventPosition.Earliest, new EventHubConsumerOptions(), mockRetryPolicy), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventHubClient.CreateProducer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateProducerValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var mockRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var client = new AmqpEventHubClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubClientOptions(), mockRetryPolicy);
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(() => client.CreateProducer(new EventHubProducerOptions(), mockRetryPolicy), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   Gets the active retry policy for the given client, using the
        ///   private field.
        /// </summary>
        ///
        private static EventHubRetryPolicy GetActiveRetryPolicy(AmqpEventHubClient target) =>
            (EventHubRetryPolicy)
                typeof(AmqpEventHubClient)
                    .GetField("_retryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(target);

        /// <summary>
        ///   Gets the active operation timeout for the given client, using the
        ///   private field.
        /// </summary>
        ///
        private static TimeSpan GetTimeout(AmqpEventHubClient target) =>
            (TimeSpan)
                typeof(AmqpEventHubClient)
                    .GetField("_tryTimeout", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(target);

        /// <summary>
        ///   A client mock allowing internal constructs to be injected for testing purposes.
        /// </summary>
        ///
        private class InjectableMockClient : AmqpEventHubClient
        {
            public InjectableMockClient(string host,
                                        string eventHubName,
                                        TokenCredential credential,
                                        EventHubClientOptions clientOptions,
                                        EventHubRetryPolicy defaultRetryPolicy,
                                        AmqpConnectionScope connectionScope,
                                        AmqpMessageConverter messageConverter) : base(host, eventHubName, credential, clientOptions, defaultRetryPolicy, connectionScope, messageConverter)
            {
            }
        }
    }
}
