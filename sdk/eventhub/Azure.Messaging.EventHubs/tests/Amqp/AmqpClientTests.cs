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
using Microsoft.Azure.Amqp;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpClientTests
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
            Assert.That(() => new AmqpClient(host, "test-path", Mock.Of<TokenCredential>(), new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new AmqpClient("my.eventhub.com", path, Mock.Of<TokenCredential>(), new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheCredential()
        {
            Assert.That(() => new AmqpClient("my.eventhub.com", "somePath", null, new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            Assert.That(() => new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheClientAsClosed()
        {
            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            Assert.That(client.Closed, Is.False, "The client should not be closed on creation");

            await client.CloseAsync(CancellationToken.None);
            Assert.That(client.Closed, Is.True, "The client should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            using var cancellationSource = new CancellationTokenSource();

            cancellationSource.Cancel();
            Assert.That(async () => await client.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.Dispose"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeClosesTheClient()
        {
            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            Assert.That(client.Closed, Is.False, "The client should not be closed on creation");

            await client.DisposeAsync();
            Assert.That(client.Closed, Is.True, "The client should be closed after disposal");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPropertiesAsyncRespectsTheCancellationTokenIfSetWhenCalled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPropertiesAsync(Mock.Of<EventHubRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPropertiesAsyncValidatesTheRetryPolicy()
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPropertiesAsync(null, cancellationSource.Token), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPropertiesAsyncRespectsClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await client.GetPropertiesAsync(Mock.Of<EventHubRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
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
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)))
                .Verifiable();

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage))
                .Callback(() => cancellationSource.Cancel())
                .Verifiable();

            // Because the AMQP library is not friendly to mocking, only the path up to conversion can be tested without external
            // dependencies.  To ensure that execution stops after that point, the converter triggers cancellation that should take
            // place immediately following the conversion and result in a well-known exception.

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubConnectionOptions(), null, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(Mock.Of<EventHubRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

            mockCredential.VerifyAll();
            mockConverter.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
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
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void GetPartitionPropertiesAsyncValidatesThePartition(string partition)
        {
            ExactTypeConstraint typeConstraint = partition is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partition, Mock.Of<EventHubRetryPolicy>(), CancellationToken.None), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncValidatesTheRetryPolicy()
        {
            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPartitionPropertiesAsync("1", null, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncRespectsTheCancellationTokenIfSetWhenCalled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPartitionPropertiesAsync("Fred", Mock.Of<EventHubRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesAsyncValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await client.GetPartitionPropertiesAsync("Fred", Mock.Of<EventHubRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
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
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)))
                .Verifiable();

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage))
                .Callback(() => cancellationSource.Cancel())
                .Verifiable();

            // Because the AMQP library is not friendly to mocking, only the path up to conversion can be tested without external
            // dependencies.  To ensure that execution stops after that point, the converter triggers cancellation that should take
            // place immediately following the conversion and result in a well-known exception.

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubConnectionOptions(), null, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, Mock.Of<EventHubRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

            mockCredential.VerifyAll();
            mockConverter.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
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
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
               .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.CreateConsumer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateConsumerValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(() => client.CreateConsumer("group", "0", EventPosition.Earliest, new EventHubConsumerClientOptions()), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.CreateProducer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateProducerValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new AmqpClient("my.eventhub.com", "somePath", Mock.Of<TokenCredential>(), new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(() => client.CreateProducer(new EventHubProducerClientOptions()), Throws.InstanceOf<EventHubsClientClosedException>());
        }

        /// <summary>
        ///   A client mock allowing internal constructs to be injected for testing purposes.
        /// </summary>
        ///
        private class InjectableMockClient : AmqpClient
        {
            public InjectableMockClient(string host,
                                        string eventHubName,
                                        TokenCredential credential,
                                        EventHubConnectionOptions clientOptions,
                                        AmqpConnectionScope connectionScope,
                                        AmqpMessageConverter messageConverter) : base(host, eventHubName, credential, clientOptions, connectionScope, messageConverter)
            {
            }
        }
    }
}
