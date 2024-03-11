// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            yield return new object[] { new EventHubsRetryOptions { MaximumRetries = 3, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = EventHubsRetryMode.Fixed } };
            yield return new object[] { new EventHubsRetryOptions { MaximumRetries = 0, Delay = TimeSpan.FromMilliseconds(1), MaximumDelay = TimeSpan.FromMilliseconds(10), Mode = EventHubsRetryMode.Fixed } };
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
            Assert.That(() => new AmqpClient(host, "test-path", TimeSpan.FromDays(1), Mock.Of<EventHubTokenCredential>(), new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new AmqpClient("my.eventhub.com", path, TimeSpan.FromDays(1), Mock.Of<EventHubTokenCredential>(), new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheCredential()
        {
            Assert.That(() => new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), null, new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorRequiresTheOptions()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOperationTimeout()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromMilliseconds(-1), credential.Object, null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorInitializesTheEndpointsWithDefaults()
        {
            var options = new EventHubConnectionOptions();
            var endpoint = new Uri("http://my.endpoint.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient(endpoint.Host, "somePath", TimeSpan.FromDays(1), credential.Object, options);

            Assert.That(client.ConnectionEndpoint.Host, Is.EqualTo(endpoint.Host), "The connection endpoint should have used the namespace URI.");
            Assert.That(client.ServiceEndpoint.Host, Is.EqualTo(endpoint.Host), "The service endpoint should have used the namespace URI.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorInitializesTheEndpointsWithOptions()
        {
            var options = new EventHubConnectionOptions { CustomEndpointAddress = new Uri("sb://iam.custom.net") };
            var endpoint = new Uri("http://my.endpoint.com");
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient(endpoint.Host, "somePath", TimeSpan.FromDays(1), credential.Object, options);

            Assert.That(client.ConnectionEndpoint.Host, Is.EqualTo(options.CustomEndpointAddress.Host), "The connection endpoint should have used the custom endpoint URI from the options.");
            Assert.That(client.ServiceEndpoint.Host, Is.EqualTo(endpoint.Host), "The service endpoint should have used the namespace URI.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(true, "amqps")]
        [TestCase(false, "amqp")]
        public void ConstructorRespectsTheUseTlsOption(bool useTls,
                                                       string expectedScheme)
        {
            var options = new EventHubConnectionOptions
            {
                CustomEndpointAddress = new Uri("sb://iam.custom.net"),
                TransportType = EventHubsTransportType.AmqpTcp
            };

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.endpoint.com", "somePath", TimeSpan.FromDays(1), credential.Object, options, useTls);

            Assert.That(client.ConnectionEndpoint.Host, Is.EqualTo(options.CustomEndpointAddress.Host), "The connection endpoint should have used the custom endpoint URI from the options.");
            Assert.That(client.ConnectionEndpoint.Scheme, Is.EqualTo(expectedScheme), "The connection endpoint scheme should reflect the TLS setting.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseMarksTheClientAsClosed()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            Assert.That(client.IsClosed, Is.False, "The client should not be closed on creation");

            await client.CloseAsync(CancellationToken.None);
            Assert.That(client.IsClosed, Is.True, "The client should be marked as closed after closing");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.CloseAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseRespectsTheCancellationToken()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
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
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            Assert.That(client.IsClosed, Is.False, "The client should not be closed on creation");

            await client.DisposeAsync();
            Assert.That(client.IsClosed, Is.True, "The client should be closed after disposal");
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPropertiesAsync(Mock.Of<EventHubsRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await client.GetPropertiesAsync(Mock.Of<EventHubsRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
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
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)))
                .Verifiable();

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage))
                .Verifiable();

            // Because the AMQP library is not friendly to mocking, only the path up to conversion can be tested without external
            // dependencies.  To ensure that execution stops after that point, the mock retry policy specifies an immediate timeout.

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), null, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(Mock.Of<EventHubsRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TimeoutException>());

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
        public void GetPropertiesAsyncAppliesTheRetryPolicy(EventHubsRetryOptions retryOptions)
        {
            var eventHubName = "myName";
            var operationTimeout = TimeSpan.FromSeconds(26);
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, operationTimeout, mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(operationTimeout, It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void GetPropertiesAsyncConsidersOperationCanceledExceptionAsRetriable(EventHubsRetryOptions retryOptions)
        {
            var eventHubName = "myName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new OperationCanceledException();
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void GetPropertiesAsyncAppliesTheRetryPolicyForAmqpErrors(EventHubsRetryOptions retryOptions)
        {
            var eventHubName = "myName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, "dummy");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPropertiesAsyncDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var eventHubName = "myName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Throws(embeddedException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(retryPolicy, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPropertiesAsyncDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var eventHubName = "myName";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var embeddedException = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreateEventHubPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
                .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Throws(embeddedException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPropertiesAsync(retryPolicy, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Once());
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partition, Mock.Of<EventHubsRetryPolicy>(), CancellationToken.None), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncValidatesTheRetryPolicy()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            Assert.That(async () => await client.GetPartitionPropertiesAsync("Fred", Mock.Of<EventHubsRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await client.GetPartitionPropertiesAsync("Fred", Mock.Of<EventHubsRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
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
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)))
                .Verifiable();

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage))
                .Verifiable();

            // Because the AMQP library is not friendly to mocking, only the path up to conversion can be tested without external
            // dependencies.  To ensure that execution stops after that point, the mock retry policy specifies an immediate timeout.

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), null, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, Mock.Of<EventHubsRetryPolicy>(), cancellationSource.Token), Throws.InstanceOf<TimeoutException>());

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
        public void GetPartitionPropertiesAsyncAppliesTheRetryPolicy(EventHubsRetryOptions retryOptions)
        {
            var eventHubName = "myName";
            var partitionId = "Barney";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new EventHubsException(true, "Test");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
               .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void GetPartitionPropertiesAsyncConsidersOperationCanceledExceptionAsRetriable(EventHubsRetryOptions retryOptions)
        {
            var eventHubName = "myName";
            var partitionId = "Barney";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = new OperationCanceledException();
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
               .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetryOptionTestCases))]
        public void GetPartitionPropertiesAsyncAppliesTheRetryPolicyForAmqpErrors(EventHubsRetryOptions retryOptions)
        {
            var eventHubName = "myName";
            var partitionId = "Barney";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(retryOptions);
            var retriableException = AmqpError.CreateExceptionForError(new Error { Condition = AmqpError.ServerBusyError }, "dummy");
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
               .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
               .Throws(retriableException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, retryPolicy, cancellationSource.Token), Throws.InstanceOf(retriableException.GetType()));

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Exactly(1 + retryOptions.MaximumRetries));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncDetectsAnEmbeddedErrorForOperationCanceled()
        {
            var eventHubName = "myName";
            var partitionId = "Barney";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
               .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
               .Throws(embeddedException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, retryPolicy, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var eventHubName = "myName";
            var partitionId = "Barney";
            var tokenValue = "123ABC";
            var retryPolicy = new BasicRetryPolicy(new EventHubsRetryOptions());
            var embeddedException = new OperationCanceledException("", new AmqpException(new Error { Condition = AmqpError.ArgumentError }));
            var mockConverter = new Mock<AmqpMessageConverter>();
            var mockCredential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var mockScope = new Mock<AmqpConnectionScope>();

            using var cancellationSource = new CancellationTokenSource();

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.Is<CancellationToken>(value => value == cancellationSource.Token)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.MaxValue)));

            mockConverter
                .Setup(converter => converter.CreatePartitionPropertiesRequest(It.Is<string>(value => value == eventHubName), It.Is<string>(value => value == partitionId), It.Is<string>(value => value == tokenValue)))
                .Returns(default(AmqpMessage));

            mockScope
               .Setup(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
               .Throws(embeddedException);

            var client = new InjectableMockClient("my.eventhub.com", eventHubName, TimeSpan.FromDays(1), mockCredential.Object, new EventHubConnectionOptions(), mockScope.Object, mockConverter.Object);
            Assert.That(async () => await client.GetPartitionPropertiesAsync(partitionId, retryPolicy, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());

            mockScope.Verify(scope => scope.OpenManagementLinkAsync(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()), Times.Once());
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(() => client.CreateConsumer("group", "0", "id", EventPosition.Earliest, Mock.Of<EventHubsRetryPolicy>(), false, false, null, null, null), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
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

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var client = new AmqpClient("my.eventhub.com", "somePath", TimeSpan.FromDays(1), credential.Object, new EventHubConnectionOptions());
            await client.CloseAsync(cancellationSource.Token);

            Assert.That(() => client.CreateProducer(null, "", TransportProducerFeatures.None, null, Mock.Of<EventHubsRetryPolicy>()), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
        }

        /// <summary>
        ///   A client mock allowing internal constructs to be injected for testing purposes.
        /// </summary>
        ///
        private class InjectableMockClient : AmqpClient
        {
            public InjectableMockClient(string host,
                                        string eventHubName,
                                        TimeSpan operationTimeout,
                                        EventHubTokenCredential credential,
                                        EventHubConnectionOptions clientOptions,
                                        AmqpConnectionScope connectionScope,
                                        AmqpMessageConverter messageConverter) : base(host, eventHubName, true, operationTimeout, credential, clientOptions, connectionScope, messageConverter)
            {
            }
        }
    }
}
